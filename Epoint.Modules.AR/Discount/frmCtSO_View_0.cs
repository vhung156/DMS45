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
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Epoint.Lists;
using Epoint.Systems.Commons;

namespace Epoint.Modules.AR
{
	public partial class frmCtSO_View : frmVoucher_View
	{
		#region Contructor

        public frmCtSO_View()
		{
			InitializeComponent();
            //this.btnPXK.Click += new EventHandler(btnPXK_Click);
            //btDiscoutDetail.Click += new EventHandler(btDiscoutDetail_Click);
		}	

		#endregion		
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


            frmSaleOrder_Edit frmEdit = new frmSaleOrder_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, dsVoucher);

            if (frmEdit.isAccept && (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Edit))
            {
                //this.FillDataNew();
                if (drCurrent.Table.Columns.Contains("Ma_Tuyen"))
                    drCurrent["Ma_Tuyen"] = Epoint.Systems.Data.DataTool.SQLGetNameByCode("LIDOITUONG", "Ma_Dt", "Ma_Tuyen", drCurrent["Ma_Dt"].ToString());
                bdsViewPh.Position = bdsViewPh.Find("Stt", frmEdit.strStt);
            }

        }

        public override void Delete()
        {
            if (bdsViewPh.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsViewPh.Current).Row;

            if (!Common.CheckDataLocked((DateTime)drCurrent["Ngay_Ct"]))
            {
                Common.MsgCancel("Đã khóa chứng từ không được xóa !");
                return;
            }
            if (Voucher.CheckDataLockedCtHanTtHD((string)drCurrent["Stt"]))
            {
                Common.MsgCancel("Chứng từ đã được thanh toán không được xóa !");
                return;

            }
            if (Voucher.CheckDataLockedPXK((string)drCurrent["Stt"]))
            {
                Common.MsgCancel("Chứng từ đã được tạo phiếu xuất kho: " + (string)drCurrent["So_Ct_Lap"] + " không được xóa !");
                return;

            }
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
        void btDiscoutDetail_Click(object sender, EventArgs e)
        {
            if (bdsViewPh.Position < 0)
                return;

            if (bdsViewPh.Position >= 0)
                drCurrent = ((DataRowView)bdsViewPh.Current).Row;


            frmDiscountDetail_View frm = new frmDiscountDetail_View();
            //frm.strMa_Ct = drCurrent["Ma_Ct"].ToString();
            //frm.strStt  = drCurrent["Stt"].ToString();
            frm.Load(drCurrent["Ma_Ct"].ToString(), drCurrent["Stt"].ToString());
            //frm.ShowDialog();

        }

        void btnPXK_Click(object sender, EventArgs e)
        {
            DataRow[] drArrPrint = dtViewPh.Select("CHON = true");

            if (drArrPrint.Length == 0)
                return;


            DataRow drEditPXK = DataTool.SQLGetDataTable("OM_PXK", null, "0=1", "Ma_PX").NewRow();

            drEditPXK["NGAY_CT"] = Library.DateToStr(DateTime.Now);
            drEditPXK["MA_PX"] = "PX001";
            drCurrent = ((DataRowView)bdsViewPh.Current).Row;


            string strReport_File_First = string.Empty;

            DataTable dt = new DataTable();

            DataColumn drSTT = new DataColumn("Stt", typeof(string));
            DataColumn drMa_PX = new DataColumn("Ma_PX", typeof(string));
            DataColumn drSo_Ct = new DataColumn("So_Ct", typeof(string));
            DataColumn drMa_Dt = new DataColumn("Ma_Dt", typeof(string));
            DataColumn drTen_Dt = new DataColumn("Ten_Dt", typeof(string));
            DataColumn drTTien = new DataColumn("TTien", typeof(double));
            DataColumn drMa_DvCs = new DataColumn("Ma_DvCs", typeof(string));
            dt.Columns.Add(drSTT);
            dt.Columns.Add(drMa_PX);
            dt.Columns.Add(drSo_Ct);
            dt.Columns.Add(drMa_Dt);
            dt.Columns.Add(drTen_Dt);
            dt.Columns.Add(drTTien);
            dt.Columns.Add(drMa_DvCs);
            if (drArrPrint.Length > 0)
            {
                for (int i = 0; i < drArrPrint.Length; i++)
                {

                    drCurrent = drArrPrint[i];

                    DataRow drtemp = dt.NewRow();
                    drtemp["Stt"] = drCurrent["Stt"];
                    drtemp["So_Ct"] = drCurrent["So_Ct"];
                    drtemp["Ma_Dt"] = drCurrent["Ma_Dt"];
                    drtemp["Ten_Dt"] = DataTool.SQLGetNameByCode("LIDOITUONG", "MA_DT", "Ten_Dt", drCurrent["Ma_Dt"].ToString());
                    drtemp["TTien"] = drCurrent["TTien"];
                    drtemp["Ma_Dvcs"] = Element.sysMa_DvCs;


                    dt.Rows.Add(drtemp);


                }
            }

            frmGopPXK_Edit frm = new frmGopPXK_Edit();
            frm.dtDetail = dt;
            frm.Load(enuEdit.New, drEditPXK);


            this.FillDataNew();
        }


        #endregion
    }
}