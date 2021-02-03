using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems;
using Epoint.Systems.Elements;

namespace Epoint.Modules
{
	public partial class frmInheritVoucher_View: Epoint.Systems.Customizes.frmView
	{

		#region Khai bao bien
		public DataTable dtViewCt;
		BindingSource bdsViewCt = new BindingSource();
		
		string strMa_Ct = string.Empty;
		string strKey = string.Empty;
		double dbTien_Pb_Nt = 0;
		string strLoai_Pb = "1";
		frmVoucher_Edit frmEditCt;

		#endregion 						

		#region Contructor

		public frmInheritVoucher_View()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public void Load(frmVoucher_Edit frmEditCt, string strMa_Ct, string strKey)
		{
			this.frmEditCt = frmEditCt;
			this.strMa_Ct = strMa_Ct;
			this.strKey = strKey;
			
			Build();
			FillData();
			BindingLanguage();
            			
			ShowDialog();		  
		}	
		
		#endregion

		#region Build, FillData
		private void Build()
		{			
			dgvViewCt.strZone = "INHERIT_VOUCHER";
			dgvViewCt.BuildGridView(this.isLookup);

			this.Controls.Add(dgvViewCt);
			dgvViewCt.ReadOnly = false;
		}

		private void FillData()
		{
			bdsViewCt = new BindingSource();

			DataRow drDmCt = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", strMa_Ct);
			string strTable_Ct = (string)drDmCt["Table_Ct"];
            string strSelect = " *, CAST(0 AS BIT) AS Chon";

            if(strMa_Ct == "LSX")
                dtViewCt = SQLExec.ExecuteReturnDt("SELECT T1.*, T1.So_Luong AS So_Luong9, CAST (0 AS MONEY) AS Gia_Nt9, CAST (0 AS MONEY) Tien_Nt9, T2.Ngay_Ct, T2.So_Ct, CAST(0 AS BIT) AS Chon FROM MALSX T1 JOIN MACTLSX T2 ON T1.Stt = T2.Stt ORDER BY T2.Ngay_Ct, T2.So_Ct");
            else 
                dtViewCt = DataTool.SQLGetDataTable(strTable_Ct, strSelect, strKey, "Ngay_Ct, So_Ct");
            
            bdsViewCt.DataSource = dtViewCt;
			dgvViewCt.DataSource = bdsViewCt;

			bdsViewCt.Position = 0;

			foreach (DataGridViewColumn dgvc in dgvViewCt.Columns)
				dgvc.ReadOnly = true;

			dgvViewCt.Columns["Chon"].ReadOnly = false;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsViewCt;
		}

        private void UpdatefrmEditCt()
        {
            DataTable dtEditCt = frmEditCt.dtEditCt;
            DataRow drEditCt = dtEditCt.NewRow();
            Common.CopyDataRow(dtEditCt.Rows[0], drEditCt);

            //Thong: Xoa dong rong dau tien
            if (frmEditCt.strMa_Ct == "PT" || frmEditCt.strMa_Ct == "PC" || frmEditCt.strMa_Ct == "BC" || frmEditCt.strMa_Ct == "BN")
            {
                if (dtEditCt.Rows.Count > 0 && (Convert.ToDouble(drEditCt["Tien_Nt"]) == 0 ||Convert.ToDouble(drEditCt["Tien_Nt9"]) == 0))
                    dtEditCt.Rows.Clear();
            }
            else
            {
                if (dtEditCt.Rows.Count > 0 && (string)drEditCt["Ma_Vt"] == string.Empty)
                    dtEditCt.Rows.Clear();
            }
            
            //Thông: Nếu người dùng muốn xóa các dòng dữ liệu cũ
            if (chkDelete.Checked)
                frmEditCt.dtEditCt.Rows.Clear();
                       
                        
            DataRow[] drChonCt = dtViewCt.Select("Chon = true");

            //Copy du lieu len Header khi su dung chuc nang Ke thua du lieu 
            //if ((bool)frmEditCt.drDmCt["Is_CopyDataHeader"])
            //{
            //    Common.CopyDataRow(drChonCt[0], frmEditCt.drEditPh, "Ma_Dt, Ong_Ba, Dia_Chi");
            //    Common.ScaterMemvar(frmEditCt, ref frmEditCt.drEditPh);
            //}

            foreach (DataRow drViewCt in drChonCt)
            {
                DataRow drEditCtNew = frmEditCt.dtEditCt.NewRow();
                Common.CopyDataRow(drEditCt, drEditCtNew);

                if (frmEditCt.strMa_Ct == "PT" || frmEditCt.strMa_Ct == "BC") //Ke thua tu Hoa don ban hang
                {
                    drEditCtNew["Tien_Nt9"] = drViewCt["Tien_Nt2"];
                    drEditCtNew["Tien_Nt"] = drViewCt["Tien_Nt2"];
                    drEditCtNew["Tien"] = drViewCt["Tien_Nt2"];
                    drEditCtNew["TK_Co"] = drViewCt["Tk_No2"];
                    drEditCtNew["Ma_Dt"] = drViewCt["Ma_Dt"];                    
                    drEditCtNew["Ma_Bp"] = drViewCt["Ma_Bp"];
                    drEditCtNew["Ma_Km"] = drViewCt["Ma_Km"];
                }
                else if (frmEditCt.strMa_Ct == "PC" || frmEditCt.strMa_Ct == "BN") //Ke thua tu Phieu nhap mua
                {
                    drEditCtNew["Tien_Nt9"] = Convert.ToDouble(drViewCt["Tien_Nt"]) + Convert.ToDouble (drViewCt["Tien_Nt3"]);
                    drEditCtNew["Tien_Nt"] = Convert.ToDouble(drViewCt["Tien_Nt"]) + Convert.ToDouble(drViewCt["Tien_Nt3"]);
                    drEditCtNew["Tien"] = Convert.ToDouble(drViewCt["Tien_Nt"]) + Convert.ToDouble(drViewCt["Tien_Nt3"]);
                    drEditCtNew["TK_No"] = drViewCt["Tk_Co"];
                    drEditCtNew["Ma_Dt"] = drViewCt["Ma_Dt"];
                    drEditCtNew["Ma_Bp"] = drViewCt["Ma_Bp"];
                    drEditCtNew["Ma_Km"] = drViewCt["Ma_Km"];
                }
                else
                {
                    if (dtViewCt.Columns.Contains("Ma_Vt"))
                        drEditCtNew["Ma_Vt"] = drViewCt["Ma_Vt"];

                    if (dtViewCt.Columns.Contains("Ten_Vt"))
                        drEditCtNew["Ten_Vt"] = drViewCt["Ten_Vt"];

                    if (dtViewCt.Columns.Contains("Ma_Kho"))
                        drEditCtNew["Ma_Kho"] = drViewCt["Ma_Kho"];

                    if (dtViewCt.Columns.Contains("Ma_Po") && drEditCtNew.Table.Columns.Contains("Ma_Po"))
                        drEditCtNew["Ma_Po"] = drViewCt["Ma_Po"];

                    if (dtViewCt.Columns.Contains("Ma_So") && drEditCtNew.Table.Columns.Contains("Ma_So"))
                        drEditCtNew["Ma_So"] = drViewCt["Ma_So"];

                    if (dtViewCt.Columns.Contains("Ma_Dt"))
                        drEditCtNew["Ma_Dt"] = drViewCt["Ma_Dt"];

                    if (dtViewCt.Columns.Contains("Ma_Sp"))
                        drEditCtNew["Ma_Sp"] = drViewCt["Ma_Sp"];

                    // BG
                    if (drEditCtNew.Table.Columns.Contains("Ma_So_Invoice"))
                        drEditCtNew["Ma_So_Invoice"] = drViewCt["So_Ct"];

                    if (dtViewCt.Columns.Contains("Ten_Sp"))
                        drEditCtNew["Ten_Sp"] = drViewCt["Ten_Sp"];

                    if (dtViewCt.Columns.Contains("Dvt"))
                        drEditCtNew["Dvt"] = drViewCt["Dvt"];

                    //Phieu Chi phi mua hang
                    if (frmEditCt.strMa_Ct != "CP")
                    {
                        drEditCtNew["So_Luong9"] = drViewCt["So_Luong9"];
                        drEditCtNew["Gia_Nt9"] = drViewCt["Gia_Nt9"];
                        drEditCtNew["Tien_Nt9"] = drViewCt["Tien_Nt9"];
                    }

                    //Hoa don ban hang và tra lai
                    if (strMa_Ct == "HD" && frmEditCt.strMa_Ct == "TL")
                    {
                        if (dtViewCt.Columns.Contains("Tk_Co"))
                            drEditCtNew["Tk_No"] = drViewCt["Tk_Co"];

                        if (dtViewCt.Columns.Contains("Tk_No"))
                            drEditCtNew["Tk_Co"] = drViewCt["Tk_No"];

                        drEditCtNew["Gia_Nt"] = drViewCt["Gia_Nt9"];
                        drEditCtNew["Gia"] = drViewCt["Gia"];
                        drEditCtNew["Tien_Nt9"] = drViewCt["Tien_Nt9"];
                        drEditCtNew["Tien_Nt"] = drViewCt["Tien_Nt"];
                        drEditCtNew["Tien"] = drViewCt["Tien"];
                    }

                    //Phieu SO
                    if (strMa_Ct != "SO" && frmEditCt.strMa_Ct == "HD")
                    {
                        drEditCtNew["Gia_Nt2"] = drViewCt["Gia_Nt"];
                        drEditCtNew["Gia2"] = drViewCt["Gia"];
                        drEditCtNew["Tien_Nt9"] = drViewCt["Tien_Nt9"];
                        drEditCtNew["Tien_Nt2"] = drViewCt["Tien_Nt"];
                        drEditCtNew["Tien2"] = drViewCt["Tien"];
                    }

                    //Phieu NM
                    if (frmEditCt.strMa_Ct == "NM")
                    {
                        drEditCtNew["Gia_Nt"] = drViewCt["Gia_Nt"];
                        drEditCtNew["Gia"] = drViewCt["Gia"];
                        drEditCtNew["Tien_Nt9"] = drViewCt["Tien_Nt9"];
                        drEditCtNew["Tien_Nt"] = drViewCt["Tien_Nt"];
                        drEditCtNew["Tien"] = drViewCt["Tien"];
                    }

                    //Hoa don ban hang
                    if (frmEditCt.strMa_Ct == "HD")
                    {
                        drEditCtNew["Tien_Nt9"] = drViewCt["Tien_Nt9"];
                        drEditCtNew["Tien_Nt2"] = drViewCt["Tien_Nt"];
                        drEditCtNew["Tien2"] = drViewCt["Tien"];
                    }                    
                }

                //Stt_Org
                if (drEditCtNew.Table.Columns.Contains("Stt_Org"))
                    drEditCtNew["Stt_Org"] = drViewCt["Stt"];

                if (drEditCtNew.Table.Columns.Contains("So_Ct0"))
                {
                    drEditCtNew["So_Ct0"] = drViewCt["So_Ct0"].ToString().Trim();
                    drEditCtNew["Ngay_Ct0"] = drViewCt["Ngay_Ct0"];
                    drEditCtNew["So_Seri0"] = drViewCt["So_Seri0"].ToString().Trim();
                }

                drEditCtNew["Stt0"] = Common.MaxDCValue(dtEditCt, "Stt0") + 1;

                dtEditCt.Rows.Add(drEditCtNew);
            }

            dtEditCt.AcceptChanges();

            //Cập nhật Tk_No2 = Tk hàng bán trả lại	
            foreach (DataRow dr in dtEditCt.Rows)
            {
                if (frmEditCt.strMa_Ct.Trim() != "PT" && frmEditCt.strMa_Ct.Trim() != "PC" && frmEditCt.strMa_Ct.Trim() != "BN" && frmEditCt.strMa_Ct.Trim() != "BC")
                {
                    string strMa_Vt = (string)dr["Ma_Vt"];

                    if ((bool)frmEditCt.drDmCt["Is_Hd"] && (string)frmEditCt.drDmCt["Nh_Ct"] == "1") //Phieu tra lai
                        dr["Tk_No2"] = DataTool.SQLGetNameByCode("LIVATTU", "Ma_Vt", "Tk_Hbtl", strMa_Vt);
                    else if ((bool)frmEditCt.drDmCt["Is_Hd"] && (string)frmEditCt.drDmCt["Nh_Ct"] == "2")// Hoa don ban hang
                    {
                        dr["Tk_Co2"] = DataTool.SQLGetNameByCode("LIVATTU", "Ma_Vt", "Tk_Dt", strMa_Vt);
                        dr["Tk_No"] = DataTool.SQLGetNameByCode("LIVATTU", "Ma_Vt", "Tk_Gv", strMa_Vt);
                        dr["Tk_Co"] = DataTool.SQLGetNameByCode("LIVATTU", "Ma_Vt", "Tk_Vt", strMa_Vt);
                    }
                    else if ((string)frmEditCt.drDmCt["Nh_Ct"] == "1" && frmEditCt.dtEditCt.Columns.Contains("Tk_No"))
                    {
                        dr["Tk_No"] = DataTool.SQLGetNameByCode("LIVATTU", "Ma_Vt", "Tk_Vt", strMa_Vt);
                    }
                    else if ((string)frmEditCt.drDmCt["Nh_Ct"] == "2" && frmEditCt.dtEditCt.Columns.Contains("Tk_Co"))
                    {
                        dr["Tk_Co"] = DataTool.SQLGetNameByCode("LIVATTU", "Ma_Vt", "Tk_Vt", strMa_Vt);
                    }
                }
            }

        }

		#endregion		

		#region Su kien	

		protected override void OnKeyDown(KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Space:
					DataRow drCurrent = ((DataRowView)bdsViewCt.Current).Row;
					drCurrent["Chon"] = !(bool)drCurrent["Chon"];
					break;
			}

			if (e.Control)
			{
				switch (e.KeyCode)
				{
					case Keys.A:
						foreach (DataRow dr in dtViewCt.Rows)
							dr["Chon"] = true;
						break;
					case Keys.U:
						foreach (DataRow dr in dtViewCt.Rows)
							dr["Chon"] = false;
						break;
				}
			}

			base.OnKeyDown(e);
		}

		void btAccept_Click(object sender, EventArgs e)
		{
            this.UpdatefrmEditCt();
            this.Close();
		}
		void btCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		#endregion 
	}
}