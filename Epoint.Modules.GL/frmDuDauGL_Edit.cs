using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
	public partial class frmDuDauGL_Edit : Epoint.Modules.frmOpening_Edit
	{
		#region Methods

		public frmDuDauGL_Edit()
		{
			InitializeComponent();

            this.txtMa_Dt.Enabled = false;
            this.txtMa_Sp.Enabled = false;

			this.txtTk.Validating += new CancelEventHandler(txtTk_Validating);
			this.txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			this.txtMa_Sp.Validating += new CancelEventHandler(txtMa_Sp_Validating);

			numDu_No.Validating += new CancelEventHandler(numDu_No_Validating);
			numDu_Co.Validating += new CancelEventHandler(numDu_Co_Validating);
			numDu_No_Nt.Validating += new CancelEventHandler(numDu_No_Nt_Validating);
			numDu_Co_Nt.Validating += new CancelEventHandler(numDu_Co_Nt_Validating);			
		}		

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			if (enuNew_Edit == enuEdit.New)
			{
				drEdit["Du_No0"] = 0;
				drEdit["Du_Co0"] = 0;
				drEdit["Du_No_Nt0"] = 0;
				drEdit["Du_Co_Nt0"] = 0;
			}

			Common.ScaterMemvar(this, ref drEdit);

			this.txtTk.Focus();

			BindingLanguage();
			LoadDicName();
			this.ShowDialog();
		}

		private void LoadDicName()
		{
			if (txtTk.Text.Trim() != string.Empty)
			{
				lbtTen_Tk.Text = DataTool.SQLGetNameByCode("LITAIKHOAN", "Tk", "Ten_Tk", txtTk.Text.Trim());
				dicName.Add(lbtTen_Tk.Name, lbtTen_Tk.Text);
			}
			else
				lbtTen_Tk.Text = string.Empty;

			if (txtMa_Dt.Text.Trim() != string.Empty)
			{
				lbtTen_Dt.Text = DataTool.SQLGetNameByCode("LIDOITUONG", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
				dicName.Add(lbtTen_Dt.Name, lbtTen_Dt.Text);
			}
			else
				lbtTen_Dt.Text = string.Empty;

			if (txtMa_Sp.Text.Trim() != string.Empty)
			{
				lbtTen_Sp.Text = DataTool.SQLGetNameByCode("LISANPHAM", "Ma_Sp", "Ten_Sp", txtMa_Sp.Text.Trim());
				dicName.Add(lbtTen_Sp.Name, lbtTen_Sp.Text);
			}
			else
				lbtTen_Sp.Text = string.Empty;
		}

		public override bool FormCheckValid()
		{
			if (txtTk.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Tk") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if ((bool)drEdit["Tk_Dt"] && (txtMa_Dt.Text.Trim() == string.Empty))
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Dt") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if ((bool)drEdit["Tk_Sp"] && (txtMa_Sp.Text.Trim() == string.Empty))
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Sp") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			bool Is_Check = false;

			if (enuNew_Edit == enuEdit.Edit)
			{
				if ((string)drEdit["Tk"] == (string)drEdit["Tk", DataRowVersion.Original] &&
					(string)drEdit["Ma_Dt"] == (string)drEdit["Ma_Dt", DataRowVersion.Original] &&
					(string)drEdit["Ma_Sp"] == (string)drEdit["Ma_Sp", DataRowVersion.Original])
					Is_Check = false;
				else
					Is_Check = true;
			}

			if (enuNew_Edit == enuEdit.New || Is_Check)
			{
				if (DataTool.SQLCheckExist("GLDUDAU", new string[] { "Nam", "Tk", "Ma_Dt", "Ma_Sp", "Ma_DvCs" }, new object[] { Element.sysWorkingYear, txtTk.Text, txtMa_Dt.Text, txtMa_Sp.Text, Element.sysMa_DvCs }))
				{
					string strMsg = "Nam = {" + Element.sysWorkingYear + "}, Tk = {" + txtTk.Text + "}, Ma_Dt = {" + txtMa_Dt.Text + "}, Ma_Sp = {" + txtMa_Sp.Text + "}, Ma_DvCs = {" + Element.sysMa_DvCs + "}";
					strMsg += Element.sysLanguage == enuLanguageType.English ? " must be unique" : " phải duy nhất";

					Common.MsgCancel(strMsg);
					return false;
				}
			}

			this.Tk_Valid();
			return true;
		}

		public override bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Kiem tra cac du lieu can thiet
			if (!(bool)drEdit["Tk_Dt"])
				drEdit["Ma_Dt"] = string.Empty;

			if (!(bool)drEdit["Tk_Sp"])
				drEdit["Ma_Sp"] = string.Empty;

			if (drEdit.Table.Columns.Contains("Ten_Tk"))
				drEdit["Ten_Tk"] = lbtTen_Tk.Text;

			if (drEdit.Table.Columns.Contains("Ten_Dt"))
				drEdit["Ten_Dt"] = lbtTen_Dt.Text;

			if (drEdit.Table.Columns.Contains("Ten_Sp"))
				drEdit["Ten_Sp"] = lbtTen_Sp.Text;

			drEdit["Have_Child"] = 0;
			drEdit["Nam"] = Element.sysWorkingYear;
			drEdit["Ma_DvCs"] = Element.sysMa_DvCs;
			if (enuNew_Edit == enuEdit.New)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Xac dinh Stt
			if (this.enuNew_Edit == enuEdit.New)
			{
				drEdit["Stt"] = Common.GetNewStt("08", true);
				while (DataTool.SQLCheckExist("GLDUDAU", "Stt", drEdit["Stt"]))
				{
					drEdit["Stt"] = Common.GetNewStt("08", true);
				}
			}				

			//Luu xuong CSDL
			if (!Opening.UpdateDuDauGL(this))
				return false;

			return true;
		}

		private void Tk_Valid()
		{
			if (drEdit == null)
				return;

			if (drEdit["Tk_Dt"] != DBNull.Value)
			{
				txtMa_Dt.Enabled = (bool)drEdit["Tk_Dt"];
                txtMa_Dt.Focus();
			}

			if (drEdit["Tk_Sp"] != DBNull.Value)
			{
				txtMa_Sp.Enabled = (bool)drEdit["Tk_Sp"];
                txtMa_Dt.Focus();
			}
		}

		#endregion

		#region Events

		void txtTk_Validating(object sender, CancelEventArgs e)
		{           
			string strValue = txtTk.Text.Trim();
			bool bRequire = true;

			Lists.frmTaiKhoan frmLookup = new Epoint.Lists.frmTaiKhoan();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LITAIKHOAN", "Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

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

                drEdit["Tk_Dt"] = drLookup["Tk_Dt"];
                drEdit["Tk_Sp"] = drLookup["Tk_Sp"];
			}

            this.Tk_Valid();
            dicName.SetValue(lbtTen_Tk.Name, lbtTen_Tk.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = true;

			Lists.frmDoiTuong frmLookup = new Epoint.Lists.frmDoiTuong();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIDOITUONG", "Ma_Dt", strValue, bRequire, "", "");

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

			dicName.SetValue(lbtTen_Dt.Name, lbtTen_Dt.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

		void txtMa_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Sp.Text.Trim();
			bool bRequire = true;

			Lists.frmSanPham frmLookup = new Epoint.Lists.frmSanPham();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LISANPHAM", "Ma_Sp", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Sp.Text = string.Empty;
				lbtTen_Sp.Text = string.Empty;
			}
			else
			{
				txtMa_Sp.Text = drLookup["Ma_Sp"].ToString();
				lbtTen_Sp.Text = drLookup["Ten_Sp"].ToString();
			}

			dicName.SetValue(lbtTen_Sp.Name, lbtTen_Sp.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

		void numDu_No_Validating(object sender, CancelEventArgs e)
		{
			if (numDu_No0.Value == 0)
				numDu_No0.Value = numDu_No.Value;
		}

		void numDu_Co_Validating(object sender, CancelEventArgs e)
		{
			if (numDu_Co0.Value == 0)
				numDu_Co0.Value = numDu_Co.Value;
		}

		void numDu_No_Nt_Validating(object sender, CancelEventArgs e)
		{
			if (numDu_No_Nt0.Value == 0)
				numDu_No_Nt0.Value = numDu_No_Nt.Value;
		}

		void numDu_Co_Nt_Validating(object sender, CancelEventArgs e)
		{
			if (numDu_Co_Nt0.Value == 0)
				numDu_Co_Nt0.Value = numDu_Co_Nt.Value;
		}
		
		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			//Kiểm tra khóa số dư
			string strSQLExec =
				"SELECT TOP 1 Locked_Sdk FROM SYSNAM " +
					" WHERE Nam = " + Element.sysWorkingYear + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";

			if ((bool)SQLExec.ExecuteReturnValue(strSQLExec))
			{
				this.btgAccept.btAccept.Enabled = false;
			}
		}
	}
}
