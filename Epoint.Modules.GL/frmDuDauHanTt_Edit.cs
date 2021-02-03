using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;

namespace Epoint.Modules.GL
{
	public partial class frmDuDauHanTt_Edit : Epoint.Modules.frmOpening_Edit
	{
		#region Methods

        private string Tk_List = string.Empty;
		public frmDuDauHanTt_Edit()
		{
			InitializeComponent();

			txtMa_Tte.TextChanged += new EventHandler(txtMa_Tte_TextChanged);

			txtMa_Dt.Enter += new EventHandler(txtMa_Dt_Enter);
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);

			txtTk.Enter += new EventHandler(txtTk_Enter);
			txtTk.Validating += new CancelEventHandler(txtTk_Validating);

			numTien_No_Nt0.Validating += new CancelEventHandler(numTien_No_Nt0_Validating);
			numTien_Tt_Nt0.Validating += new CancelEventHandler(numTien_Tt_Nt0_Validating);

			numTien_Tt0.Validating += new CancelEventHandler(numTien_Tt0_Validating);
			numTien_No0.Validating += new CancelEventHandler(numTien_No0_Validating);

			numTy_Gia.Validating += new CancelEventHandler(numTy_Gia_Validating);

			chkIs_UngTruoc.CheckedChanged += new EventHandler(chkIs_UngTruoc_CheckedChanged);
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

            this.Tk_List = Parameters.GetParaValue("TK_CONGNO_LIST").ToString();


			if (enuNew_Edit == enuEdit.New)
			{
				this.drEdit["Tien_Tt"] = 0;
				this.drEdit["Tien_Tt_Nt"] = 0;
			}
            //else
            //    chkIs_UngTruoc.Enabled = false;

			Common.ScaterMemvar(this, ref drEdit);

			this.chkUngTruoc_Valid();

			this.ShowDialog();
		}

		public void LoadDicName()
		{
			if (txtMa_Dt.Text.Trim() != string.Empty)
			{
				lbtTen_Dt.Text = DataTool.SQLGetNameByCode("LIDOITUONG", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
				dicName.Add(lbtTen_Dt.Name, lbtTen_Dt.Text);
			}
			else
				lbtTen_Dt.Text = string.Empty;

			if (txtTk.Text.Trim() != string.Empty)
			{
				lbtTen_Tk.Text = DataTool.SQLGetNameByCode("LITAIKHOAN", "Tk", "Ten_Tk", txtTk.Text.Trim());
				dicName.Add(lbtTen_Tk.Name, lbtTen_Tk.Text);
			}
			else
				lbtTen_Tk.Text = string.Empty;
		}

		private void Ma_Tte_Validating()
		{
			string strMa_Tte = txtMa_Tte.Text;

			if (strMa_Tte == Element.sysMa_Tte)
			{
				numTy_Gia.Value = 1;
				numTy_Gia.bReadOnly = true;

				this.pnlTien_No_Nt.Visible = false;
				this.pnlTien_No.Visible = true;
				this.pnlTien_No.Left = this.pnlTien_No_Nt.Left;
			}
			else
			{
				numTy_Gia.bReadOnly = false;

				if (txtMa_Tte.bTextChange)
				{
					Hashtable ht = new Hashtable();
					ht.Add("NGAY_CT", Library.StrToDate(dteNgay_Ct.Text));
					ht.Add("MA_TTE", strMa_Tte);

					numTy_Gia.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("sp_GetTyGia", ht, CommandType.StoredProcedure));
				}

				this.pnlTien_No_Nt.Visible = true;
				this.pnlTien_No.Visible = true;
				this.pnlTien_No.Left = this.pnlTien_No_Nt.Right;
			}
		}

		private void Tinh_Tien()
		{
			if (txtMa_Tte.Text == Element.sysMa_Tte)
			{
				numTien_No.Value = numTien_No0.Value - numTien_Tt0.Value;
				numTien_No_Nt.Value = numTien_No_Nt0.Value - numTien_Tt_Nt0.Value;
			}
			else
			{
				double dbTron_Tien = Convert.ToDouble(Parameters.GetParaValue("Tron_Ty_Gia"));

				if (Math.Abs(numTy_Gia.Value * numTien_No_Nt0.Value - numTien_No0.Value) > dbTron_Tien)
					numTien_No0.Value = Math.Round(numTien_No_Nt0.Value * numTy_Gia.Value, 0, MidpointRounding.AwayFromZero);

				if (Math.Abs(numTy_Gia.Value * numTien_Tt_Nt0.Value - numTien_Tt0.Value) > dbTron_Tien)
					numTien_Tt0.Value = Math.Round(numTien_Tt_Nt0.Value * numTy_Gia.Value, 0, MidpointRounding.AwayFromZero);

				numTien_No_Nt.Value = numTien_No_Nt0.Value - numTien_Tt_Nt0.Value;
				numTien_No.Value = numTien_No0.Value - numTien_Tt0.Value;
			}
		}

		public override bool FormCheckValid()
		{
			if (txtMa_Ct.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Ct") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (dteNgay_Ct.IsNull)
			{
				Common.MsgCancel(Languages.GetLanguage("Ngay_Ct") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (txtMa_Dt.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Dt") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (txtTk.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Tk") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}
			return true;
		}

		public override bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

            
            drEdit["Nam"] = Element.sysWorkingYear;
			drEdit["Ma_DvCs"] = Element.sysMa_DvCs;
			if (enuNew_Edit == enuEdit.New)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			if (this.enuNew_Edit == enuEdit.New)
			{
				drEdit["Stt"] = Common.GetNewStt("08", true);
				while (DataTool.SQLCheckExist("vw_HanTt", "Stt", drEdit["Stt"]))
				{
					drEdit["Stt"] = Common.GetNewStt("08", true);
				}
			}

			if (txtMa_Tte.Text == Element.sysMa_Tte)
			{
				drEdit["Ty_Gia"] = 1;
				drEdit["Tien_No_Nt0"] = 0;
				drEdit["Tien_Tt_Nt0"] = 0;
				drEdit["Tien_No_Nt"] = 0;
			}

			if (!DataTool.SQLUpdate(this.enuNew_Edit, "GLDUDAUHANTT", ref drEdit))
				return false;


            if(Common.InlistLike(txtTk.Text,this.Tk_List))
            {
                Hashtable htPara = new Hashtable();
                htPara["MA_DVCS"] = Element.sysMa_DvCs;
                htPara["STT"] = drEdit["Stt"].ToString();
                htPara["IS_UPDATE"] = "N";
                SQLExec.Execute("sp_UpdateSdHantt", htPara, CommandType.StoredProcedure);
            }

//            if (chkIs_UngTruoc.Checked)
//            {//Ứng trước
//                if (enuNew_Edit == enuEdit.Edit)
//                {
//                    string strSQLExec = @"IF EXISTS (SELECT Stt FROM vw_HanTt WHERE Stt = '" + (string)drEdit["Stt"] + @"' AND Is_SoDuDau = 1) 
//										 DELETE vw_HanTt WHERE Stt = '" + (string)drEdit["Stt"] + @"' AND Is_SoDuDau = 1";

//                    SQLExec.Execute(strSQLExec);
//                }

//                if (!DataTool.SQLUpdate(this.enuNew_Edit, "R80UNGTRUOC", ref drEdit))
//                    return false;
//            }
//            else
//            {// HanTt
//                if (enuNew_Edit == enuEdit.Edit)
//                {
//                    string strSQLExec = @"IF EXISTS (SELECT Stt FROM R80UNGTRUOC WHERE Stt = '" + (string)drEdit["Stt"] + @"' AND Is_SoDuDau = 1) 
//										 DELETE R80UNGTRUOC WHERE Stt = '" + (string)drEdit["Stt"] + @"' AND Is_SoDuDau = 1";

//                    SQLExec.Execute(strSQLExec);
//                }

//                if (!DataTool.SQLUpdate(this.enuNew_Edit, "vw_HanTt", ref drEdit))
//                    return false;
//            }


			return true;
		}

		void chkUngTruoc_Valid()
		{
			if (chkIs_UngTruoc.Checked)
			{
				numTien_Tt0.Enabled = false;
				numTien_Tt_Nt0.Enabled = false;
			}
			else
			{
				numTien_Tt0.Enabled = true;
				numTien_Tt_Nt0.Enabled = true;
			}
		}

		#endregion

		#region Events

		void txtMa_Tte_TextChanged(object sender, EventArgs e)
		{
            if (this.ActiveControl == txtMa_Tte)
                this.Ma_Tte_Validating();
		}

		void numTy_Gia_Validating(object sender, CancelEventArgs e)
		{
			this.Tinh_Tien();
		}

		void numTien_No_Nt0_Validating(object sender, CancelEventArgs e)
		{
			this.Tinh_Tien();
		}

		void numTien_Tt_Nt0_Validating(object sender, CancelEventArgs e)
		{
			this.Tinh_Tien();
		}

		void numTien_Tt0_Validating(object sender, CancelEventArgs e)
		{
			this.Tinh_Tien();
		}

		void numTien_No0_Validating(object sender, CancelEventArgs e)
		{
			this.Tinh_Tien();
		}

		void txtMa_Dt_Enter(object sender, EventArgs e)
		{
			lbtTen_Dt.Text = dicName.GetValue(lbtTen_Dt.Name);
		}
		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = true;

            //Lists.frmDoiTuong frmLookup = new Lists.frmDoiTuong();
			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt.Text = string.Empty;
				lbtTen_Dt.Text = string.Empty;
			}
			else
			{
				txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt.Text = drLookup["Ten_Dt"].ToString();
			}

			dicName[lbtTen_Dt.Name] = lbtTen_Dt.Text;

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

		void txtTk_Enter(object sender, EventArgs e)
		{
			lbtTen_Tk.Text = dicName.GetValue(lbtTen_Tk.Name);
		}
		void txtTk_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk.Text.Trim();
			bool bRequire = true;

            //Lists.frmTaiKhoan frmLookup = new Epoint.Lists.frmTaiKhoan();
			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk.Text = string.Empty;
				lbtTen_Tk.Text = string.Empty;
			}
			else
			{
				txtTk.Text = drLookup["Tk"].ToString();
				lbtTen_Tk.Text = drLookup["Ten_Tk"].ToString();
			}

			dicName.SetValue(lbtTen_Tk.Name, lbtTen_Tk.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

		void chkIs_UngTruoc_CheckedChanged(object sender, EventArgs e)
		{
			this.chkUngTruoc_Valid();
		}

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			//Kiểm tra khóa số dư
			string strSQLExec =
				"SELECT TOP 1 Locked_SdHanTt FROM SYSNAM " +
					" WHERE Nam = " + Element.sysWorkingYear + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";

            if (SQLExec.ExecuteReturnDt(strSQLExec).Rows.Count > 0 && (bool)SQLExec.ExecuteReturnValue(strSQLExec))
			{
				this.btgAccept.btAccept.Enabled = false;
			}
		}

       
	}
}
