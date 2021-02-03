//System
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//Epoint
using Epoint.Systems.Controls;
using Epoint.Systems.Data;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Epoint.Lists;
using Epoint.Systems.Commons;
using Epoint.Modules;
using System.Collections;

namespace Epoint.Modules.CA
{
	public partial class frmCt_View : frmVoucher_View
	{
		public frmCt_View()
		{            
			InitializeComponent();
            this.btnPXK.Click += new EventHandler(btnPXK_Click);
		}		

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsViewPh.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;
		
			if (bdsViewPh.Position >= 0)
				drCurrent = ((DataRowView)bdsViewPh.Current).Row;
			else
			{
				drCurrent = dtViewPh.NewRow();
				drCurrent["Ma_Ct"] = strMa_Ct_List.Split(',')[0];
				drCurrent["Stt"] = "0";
				drCurrent["Ma_Tte"] = Element.sysMa_Tte;
				drCurrent["Ty_Gia"] = 1;
			}

			frmCtTien_Edit frmEdit = new frmCtTien_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent, dsVoucher);

            if (frmEdit.isAccept && (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Edit))
            {
                bdsViewPh.Position = bdsViewPh.Find("Stt", frmEdit.strStt);
            }
		}

		public override void Delete()
		{
			if (bdsViewPh.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsViewPh.Current).Row;

			if (!Common.CheckDataLocked((DateTime)drCurrent["Ngay_Ct"]))
				return;

			if (!Element.sysIs_Admin)
			{
				string strCreate_User = (string)drCurrent["Create_Log"];

				if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
				{
					string strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM SYSMEMBER WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";

					if (!strUser_Allow.Contains("*,")) //Được phép sửa tất cả
					{
                        if (!strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
                        {
							Common.MsgCancel("Không được xóa chứng từ do " + strCreate_User.Substring(14) + " lập, liên hệ với Admin!");
							return;
						}
					}
				}
			}

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE"), "N"))
				return;

			string strMa_Ct = ((string)drCurrent["Ma_Ct"]).Trim();
			string strStt = ((string)drCurrent["Stt"]).Trim();

			if (Voucher.SQLDeleteCt(strStt, strMa_Ct))
			{

                SQLExec.Execute("DELETE GLTHANHTOANCT WHERE STT_PT = '" + strStt + "'");
                SQLExec.Execute("DELETE GLTHANHTOAN WHERE STT = '" + strStt + "'");

				bdsViewPh.RemoveAt(bdsViewPh.Position);
				dtViewPh.AcceptChanges();			
			}
		}

		public override void EditHanTt()
		{
			if (bdsViewPh.Position < 0)
				return;
		
			drCurrent = ((DataRowView)bdsViewPh.Current).Row;
			string strStt = (string)drCurrent["Stt"];

			if (DataTool.SQLCheckExist("vw_CongNo", "Stt", strStt))
			{
				DateTime dtNgay_Ct = (DateTime)drCurrent["Ngay_Ct"];
				string strMa_Ct = (string)drCurrent["Ma_Ct"];

				frmHanTt_View frm = new frmHanTt_View();

				frm.Load(dtNgay_Ct, "", "", strStt, strMa_Ct);
			}
		}

        //public override bool Filter_ShowForm(DataRow drFilter)
        //{
        //    frmFilter frmFilter = new frmFilter();
        //    frmFilter.Load(drFilter);

        //    return frmFilter.isAccept;
        //}

		#endregion		

        void btnPXK_Click(object sender, EventArgs e)
        {
            if (bdsViewCt.Position < 0)
                return;

            DataRow drCurrentCt = ((DataRowView)bdsViewCt.Current).Row;

            if (!Common.CheckDataLocked((DateTime)drCurrentCt["Ngay_Ct"]))
                return;

             if (!Common.MsgYes_No("Bạn có chắc hủy thanh toán khách hàng :" + drCurrentCt["MA_DT"].ToString()))
                         return ;

            Hashtable ht = new Hashtable();
            ht.Add("STT_PT", drCurrentCt["Stt"].ToString());
            ht.Add("STT_HD", "");
            ht.Add("SO_CT_HD", drCurrentCt["Ten_Dtgtgt"].ToString());
            ht.Add("MA_DT", drCurrentCt["MA_DT"].ToString());
            ht.Add("STT0", drCurrentCt["STT0"].ToString());
            ht.Add("MA_DVCS", Element.sysMa_DvCs);

            SQLExec.Execute("sp_CA_CancelThanhToan", ht, CommandType.StoredProcedure);

            MessageBox.Show("Hủy thanh toán thành công!");
        }
	}
}