using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Data;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Lists;
using Epoint.Systems;
using Epoint.Systems.Commons;

namespace Epoint.Modules.AS
{
	public partial class frmCtTsHMon_Edit : Epoint.Systems.Customizes.frmEdit
	{
		#region Khai bao
		DataTable dtStt_Ngia;
		#endregion

		#region Phuong thuc

		public frmCtTsHMon_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtMa_Ts.Enter += new EventHandler(txtMa_Ts_Enter);
			txtMa_Ts.Validating += new CancelEventHandler(txtMa_Ts_Validating);

			txtTk_No.Enter += new EventHandler(txtTk_No_Enter);
			txtTk_No.Validating += new CancelEventHandler(txtTk_No_Validating);

			txtTk_Co.Enter += new EventHandler(txtTk_Co_Enter);
			txtTk_Co.Validating += new CancelEventHandler(txtTk_Co_Validating);

			txtMa_Bp.Enter += new EventHandler(txtMa_Bp_Enter);
			txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);

			txtMa_Km.Enter += new EventHandler(txtMa_Km_Enter);
			txtMa_Km.Validating += new CancelEventHandler(txtMa_Km_Validating);

            txtMa_Sp.Enter += new EventHandler(txtMa_Sp_Enter);
            txtMa_Sp.Validating += new CancelEventHandler(txtMa_Sp_Validating);

			cboStt.TextChanged += new EventHandler(cboStt_NGia_TextChanged);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;

			this.enuNew_Edit = enuNew_Edit;
			this.Text = enuNew_Edit == enuEdit.New ? "Them moi nhan vien" : "Sua nhan vien";

			Common.ScaterMemvar(this, ref drEdit);

			LoadDicName();
			BindingLanguage();

			//Fill Combo
			string strMa_Ts = (string)drEdit["Ma_Ts"];
			dtStt_Ngia = SQLExec.ExecuteReturnDt("SELECT Stt AS Stt_NGia, Dien_Giai FROM ASTSNG WHERE Ma_Ts = '" + strMa_Ts + "'");
			//dtStt_Ngia.Rows.Add("*", "Tất cả");
			cboStt.lstItem.Width = 300;
			cboStt.lstItem.BuildListView("STT_NGIA:100,DIEN_GIAI:200");
			cboStt.lstItem.FillListView(dtStt_Ngia);

			if (dtStt_Ngia.Select("Stt_NGia = '" + cboStt.Text + "'").Length > 0)
				lbtTen_Ts_NGia.Text = (string)dtStt_Ngia.Select("Stt_NGia = '" + cboStt.Text + "'")[0]["Dien_Giai"];
			else
				lbtTen_Ts_NGia.Text = "";

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			//Ma_Ts
			if (txtMa_Ts.Text.Trim() != string.Empty)
			{
				lbtTen_Ts.Text = DataTool.SQLGetNameByCode("ASTS", "Ma_Ts", "Ten_Ts", txtMa_Ts.Text.Trim());
				dicName.Add(lbtTen_Ts.Name, lbtTen_Ts.Text);
			}
			else
				lbtTen_Ts.Text = string.Empty;

			//Tk_No
			if (txtTk_No.Text.Trim() != string.Empty)
			{
				lbtTen_Tk_No.Text = DataTool.SQLGetNameByCode("LITAIKHOAN", "Tk", "Ten_Tk", txtTk_No.Text.Trim());
				dicName.Add(lbtTen_Tk_No.Name, lbtTen_Tk_No.Text);
			}
			else
				lbtTen_Tk_No.Text = string.Empty;

			//Tk_Co
			if (txtTk_Co.Text.Trim() != string.Empty)
			{
				lbtTen_Tk_Co.Text = DataTool.SQLGetNameByCode("LITAIKHOAN", "Tk", "Ten_Tk", txtTk_Co.Text.Trim());
				dicName.Add(lbtTen_Tk_Co.Name, lbtTen_Tk_Co.Text);
			}
			else
				lbtTen_Tk_Co.Text = string.Empty;

			//Ma_Bp
			if (txtMa_Bp.Text.Trim() != string.Empty)
			{
				lbtTen_Bp.Text = DataTool.SQLGetNameByCode("LIBOPHAN", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
				dicName.Add(lbtTen_Bp.Name, lbtTen_Bp.Text);
			}
			else
				lbtTen_Bp.Text = string.Empty;

			//Ma_Km
			if (txtMa_Km.Text.Trim() != string.Empty)
			{
				lbtTen_Km.Text = DataTool.SQLGetNameByCode("LIKHOANMUC", "Ma_Km", "Ten_Km", txtMa_Km.Text.Trim());
				dicName.Add(lbtTen_Km.Name, lbtTen_Km.Text);
			}
			else
				lbtTen_Km.Text = string.Empty;

			//Ma_Sp
			if (txtMa_Sp.Text.Trim() != string.Empty)
			{
				lbtTen_Sp.Text = DataTool.SQLGetNameByCode("LISANPHAM", "Ma_Sp", "Ten_Sp", txtMa_Sp.Text.Trim());
				dicName.Add(lbtTen_Sp.Name, lbtTen_Sp.Text);
			}
			else
				lbtTen_Sp.Text = string.Empty;
		}

		private bool FormCheckValid()
		{
			bool bvalid = true;

			if (cboStt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("cobMa_CtTsNGia") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtMa_Ts.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Ts") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (dteNgay_Ps.Text.Replace(" ", "") == "//")
			{
				Common.MsgOk(Languages.GetLanguage("Ngay_Ps") + " " +
							  Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (txtTk_No.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Tk_No") + " " +
							  Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (txtTk_Co.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Tk_Co") + " " +
							  Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (txtMa_Bp.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Bp") + " " +
							  Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			return bvalid;
		}

		private bool Save()
		{
			if (!Common.CheckDataLocked(Library.StrToDate(dteNgay_Ps.Text)))
			{
				Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
				return false;
			}

			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Kiem tra Valid CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "ASTSHMON", ref drEdit))
				return false;

			return true;
		}

		#endregion

		#region Su kien

		#region Accept
		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				isAccept = true;
				this.Close();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}
		#endregion

		#region Ma_Ts
		private void txtMa_Ts_Enter(object sender, EventArgs e)
		{
			lbtTen_Ts.Text = dicName.GetValue(lbtTen_Ts.Name);
		}

		void txtMa_Ts_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Ts.Text.Trim();
			bool bRequire = true;

			frmCtTs frmLookup = new frmCtTs();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "ASTS", "Ma_Ts", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				lbtTen_Ts.Text = string.Empty;
				lbtTen_Ts.Text = string.Empty;
			}
			else
			{
				txtMa_Ts.Text = ((string)drLookup["Ma_Ts"]).Trim();
				lbtTen_Ts.Text = ((string)drLookup["Ten_Ts"]).Trim();
			}

			dicName.SetValue(lbtTen_Ts.Name, lbtTen_Ts.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}
		#endregion

		#region Ma_Bp
		private void txtMa_Bp_Enter(object sender, EventArgs e)
		{
			lbtTen_Bp.Text = dicName.GetValue(lbtTen_Bp.Name);
		}

		void txtMa_Bp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Bp.Text.Trim();
			bool bRequire = true;

			frmBoPhan frmLookup = new frmBoPhan();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIBOPHAN", "Ma_Bp", strValue, bRequire, "", "Nh_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				lbtTen_Bp.Text = string.Empty;
				lbtTen_Bp.Text = string.Empty;
			}
			else
			{
				txtMa_Bp.Text = ((string)drLookup["Ma_Bp"]).Trim();
				lbtTen_Bp.Text = ((string)drLookup["Ten_Bp"]).Trim();
			}

			dicName.SetValue(lbtTen_Bp.Name, lbtTen_Bp.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}
		#endregion

		#region Tk_No
		private void txtTk_No_Enter(object sender, EventArgs e)
		{
			lbtTen_Tk_No.Text = dicName.GetValue(lbtTen_Tk_No.Name);
		}

		void txtTk_No_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk_No.Text.Trim();
			bool bRequire = true;

			frmTaiKhoan frmLookup = new frmTaiKhoan();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LITAIKHOAN", "Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				lbtTen_Tk_No.Text = string.Empty;
				lbtTen_Tk_No.Text = string.Empty;
			}
			else
			{
				txtTk_No.Text = ((string)drLookup["Tk"]).Trim();
				lbtTen_Tk_No.Text = ((string)drLookup["Ten_Tk"]).Trim();
			}

			dicName.SetValue(lbtTen_Tk_No.Name, lbtTen_Tk_No.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}
		#endregion

		#region Tk_Co
		private void txtTk_Co_Enter(object sender, EventArgs e)
		{
			lbtTen_Tk_Co.Text = dicName.GetValue(lbtTen_Tk_Co.Name);
		}

		void txtTk_Co_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk_Co.Text.Trim();
			bool bRequire = true;

			frmTaiKhoan frmLookup = new frmTaiKhoan();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LITAIKHOAN", "Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				lbtTen_Tk_Co.Text = string.Empty;
				lbtTen_Tk_Co.Text = string.Empty;
			}
			else
			{
				txtTk_Co.Text = ((string)drLookup["Tk"]).Trim();
				lbtTen_Tk_Co.Text = ((string)drLookup["Ten_Tk"]).Trim();
			}

			dicName.SetValue(lbtTen_Tk_Co.Name, lbtTen_Tk_Co.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}
		#endregion

		#region Ma_Km
		private void txtMa_Km_Enter(object sender, EventArgs e)
		{
			lbtTen_Km.Text = dicName.GetValue(lbtTen_Km.Name);
		}

		void txtMa_Km_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Km.Text.Trim();
			bool bRequire = false;

			frmKhoanMuc frmLookup = new frmKhoanMuc();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIKHOANMUC", "Ma_Km", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				lbtTen_Km.Text = string.Empty;
				lbtTen_Km.Text = string.Empty;
			}
			else
			{
				txtMa_Km.Text = ((string)drLookup["Ma_Km"]).Trim();
				lbtTen_Km.Text = ((string)drLookup["Ten_Km"]).Trim();
			}

			dicName.SetValue(lbtTen_Km.Name, lbtTen_Km.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}
		#endregion

		#region Ma_Sp

		private void txtMa_Sp_Enter(object sender, EventArgs e)
		{
			lbtTen_Sp.Text = dicName.GetValue(lbtTen_Sp.Name);
		}

		void txtMa_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Sp.Text.Trim();
			bool bRequire = false;

			//Kiem tra whether tai khoan theo doi san pham
			object objTk_Sp = SQLExec.ExecuteReturnValue(
						"SELECT TOP 1 Tk_Sp FROM LITAIKHOAN " + 
							"WHERE Tk LIKE ('" + txtTk_No.Text + "%') OR Tk LIKE ('" + txtTk_Co.Text + "%')" +
							"ORDER BY Tk_Sp DESC");

			if (objTk_Sp != null && (bool)objTk_Sp)
				bRequire = (bool)objTk_Sp;

			frmSanPham frmLookup = new frmSanPham();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LISANPHAM", "Ma_Sp", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				lbtTen_Sp.Text = string.Empty;
				lbtTen_Sp.Text = string.Empty;
			}
			else
			{
				txtMa_Sp.Text = ((string)drLookup["Ma_Sp"]).Trim();
				lbtTen_Sp.Text = ((string)drLookup["Ten_Sp"]).Trim();
			}

			dicName.SetValue(lbtTen_Sp.Name, lbtTen_Sp.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

		#endregion

		#region cboStt_NGia
		void cboStt_NGia_TextChanged(object sender, EventArgs e)
		{
			if (dtStt_Ngia == null) return;
			if (dtStt_Ngia.Select("Stt_NGia = '" + cboStt.Text + "'").Length > 0)
				lbtTen_Ts_NGia.Text = (string)dtStt_Ngia.Select("Stt_NGia = '" + cboStt.Text + "'")[0]["Dien_Giai"];
			else
				lbtTen_Ts_NGia.Text = "";
		}
		#endregion

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (this.enuNew_Edit == enuEdit.Edit)
			{
				if (!Common.CheckDataLocked((DateTime)drEdit["Ngay_Ps"]))
				{
					this.dteNgay_Ps.Enabled = false;
					this.btgAccept.btAccept.Enabled = false;

					return;
				}
			}
		}
	}
}