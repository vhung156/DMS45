using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Elements;
using Epoint.Systems.Data;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;
using Epoint.Lists;

namespace Epoint.Modules.AS
{
	public partial class frmCtTsNGia_Edit : Epoint.Systems.Customizes.frmEdit
	{
		#region Contructor

		public frmCtTsNGia_Edit()
		{
			InitializeComponent();

			txtMa_Tte.TextChanged += new EventHandler(txtMa_Tte_TextChanged);

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtMa_Nv.Enter += new EventHandler(txtMa_Nv_Enter);
			txtMa_Nv.Validating += new CancelEventHandler(txtMa_Nv_Validating);
			txtMa_Tg.Enter += new EventHandler(txtMa_Tg_Enter);
			txtMa_Tg.Validating += new CancelEventHandler(txtMa_Tg_Validating);

			txtTk_No.Validating += new CancelEventHandler(txtTk_No_Validating);
			txtTk_Co.Validating += new CancelEventHandler(txtTk_Co_Validating);
			txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
			txtMa_Km.Validating += new CancelEventHandler(txtMa_Km_Validating);
			txtMa_Sp.Validating += new CancelEventHandler(txtMa_Sp_Validating);

			chkTinh_Kh.CheckedChanged += new EventHandler(chkTinh_Kh_CheckedChanged);

			numTien_NG_Nt.Validating += new CancelEventHandler(numTien_NG_Nt_Validating);
			numTien_HM_Nt.Validating += new CancelEventHandler(numTien_Hao_Mon_Validating);
			numTien_CL_Nt.Validating += new CancelEventHandler(numTien_Con_Lai_Validating);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;

			Common.ScaterMemvar(this, ref drEdit);

			this.Init();
			this.LoadDicName();
			this.BindingLanguage();

			this.ShowDialog();
		}

		#endregion

		#region Phuong thuc

		private void Init()
		{
			this.Ma_Tte_Show();            
		}

		private void Ma_Tte_Show()
		{
			if (this.txtMa_Tte.Text.Trim() == Element.sysMa_Tte)
			{
				this.numTien_HM.Visible = false;
				this.numTien_NG.Visible = false;
				this.numTien_CL.Visible = false;
			}
			else
			{
				this.numTien_HM.Visible = true;
				this.numTien_NG.Visible = true;
				this.numTien_CL.Visible = true;
			}
		}

		private void LoadDicName()
		{
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

            //Ma_Tg
            if (txtMa_Tg.Text.Trim() != string.Empty)
            {
                lbtTen_Tg.Text = DataTool.SQLGetNameByCode("ASTG", "Ma_Tg", "Ten_Tg", txtMa_Tg.Text.Trim());
                dicName.Add(lbtTen_Tg.Name, lbtTen_Tg.Text);
            }
            else
                lbtTen_Tg.Text = string.Empty;

            //Ma_Nv
            if (txtMa_Nv.Text.Trim() != string.Empty)
            {
                lbtTen_Nv.Text = DataTool.SQLGetNameByCode("LINGUONVON", "Ma_Nv", "Ten_Nv", txtMa_Nv.Text.Trim());
                dicName.Add(lbtTen_Nv.Name, lbtTen_Nv.Text);
            }
            else
                lbtTen_Nv.Text = string.Empty;
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

		private void Tinh_Tien()
		{
			if (numTy_Gia.Value == 0)
				numTy_Gia.Value = 1;

			this.numTien_NG.Value = Math.Round(this.numTien_NG_Nt.Value * this.numTy_Gia.Value, 0, MidpointRounding.AwayFromZero);
			this.numTien_HM.Value = Math.Round(this.numTien_HM_Nt.Value * this.numTy_Gia.Value, 0, MidpointRounding.AwayFromZero);
			this.numTien_CL.Value = Math.Round(this.numTien_CL_Nt.Value * this.numTy_Gia.Value, 0, MidpointRounding.AwayFromZero);
		}

		private bool FormCheckValid()
		{
			if (dteNgay_Ps.Text.Replace(" ", "") == "//")
			{
				Common.MsgOk(Languages.GetLanguage("Ngay_Ps") + " " +
							 Languages.GetLanguage("Cannot_Empty"));
				return false;
			}
			if (txtMa_Tg.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Tg") + " " +
							 Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (chkTinh_Kh.Checked)
			{
				if (txtNgay_Bd_Kh.IsNull)
				{
					Common.MsgOk(Languages.GetLanguage("Ngay_Bd_Kh") + " " + Languages.GetLanguage("Cannot_Empty"));
					return false;
				}

				//if (numSo_Thang_Kh.Value == 0)
				//{
				//    Common.MsgOk(Languages.GetLanguage("So_Thang_Kh") + " " + Languages.GetLanguage("Cannot_Empty"));
				//    return false;
				//}

				if (txtTk_No.Text == string.Empty)
				{
					Common.MsgOk(Languages.GetLanguage("Tk_No") + " " + Languages.GetLanguage("Cannot_Empty"));
					return false;
				}
				if (txtTk_Co.Text == string.Empty)
				{
					Common.MsgOk(Languages.GetLanguage("Tk_Co") + " " + Languages.GetLanguage("Cannot_Empty"));
					return false;
				}
			}

			if (txtDien_Giai.Text == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Dien_Giai") + " " + Languages.GetLanguage("Cannot_Empty"));

				return false;
			}

			return true;
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

			////Xac dinh Stt
			if (this.enuNew_Edit == enuEdit.New)
				drEdit["Stt"] = Common.GetNewStt("06", true);

			//Kiem tra Valid CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "ASTSNG", ref drEdit))
				return false;

			return true;
		}

		#endregion

		#region Su kien

		void txtMa_Tte_TextChanged(object sender, EventArgs e)
		{
			this.Ma_Tte_Show();
		}

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


		#region Ma_Ts
		//void txtMa_Ts_Enter(object sender, EventArgs e)
		//{
		//    lbtTen_Ts.Text = dicName.GetValue(lbtTen_Ts.Name);
		//}

		//void txtMa_Ts_Validating(object sender, CancelEventArgs e)
		//{
		//    string strValue = txtMa_Ts.Text.Trim();
		//    bool bRequire = true;

		//    frmCtTs frmLookup = new frmCtTs();
		//    DataRow drLookup = Lookup.ShowLookup(frmLookup, "R06CTTS", "Ma_Ts", strValue, bRequire, "");

		//    if (bRequire && drLookup == null)
		//        e.Cancel = true;

		//    if (drLookup == null)
		//    {
		//        lbtTen_Ts.Text = string.Empty;
		//        lbtTen_Ts.Text = string.Empty;
		//    }
		//    else
		//    {
		//        txtMa_Ts.Text = ((string)drLookup["Ma_Ts"]).Trim();
		//        lbtTen_Ts.Text = ((string)drLookup["Ten_Ts"]).Trim();
		//    }

		//    dicName.SetValue(lbtTen_Ts.Name, lbtTen_Ts.Text);
		//}
		#endregion

		#region Ma_Nv
		void txtMa_Nv_Enter(object sender, EventArgs e)
		{
			lbtTen_Nv.Text = dicName.GetValue(lbtTen_Nv.Name);
		}

		void txtMa_Nv_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nv.Text.Trim();
			bool bRequire = false;

            frmNguonVon frmLookup = new frmNguonVon();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LINGUONVON", "Ma_Nv", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				lbtTen_Nv.Text = string.Empty;
				lbtTen_Nv.Text = string.Empty;
			}
			else
			{
				txtMa_Nv.Text = ((string)drLookup["Ma_Nv"]).Trim();
				lbtTen_Nv.Text = ((string)drLookup["Ten_Nv"]).Trim();
			}

			dicName.SetValue(lbtTen_Nv.Name, lbtTen_Nv.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}
		#endregion

		#region Ma_Tg
		void txtMa_Tg_Enter(object sender, EventArgs e)
		{
			lbtTen_Tg.Text = dicName.GetValue(lbtTen_Tg.Name);
		}

		void txtMa_Tg_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Tg.Text.Trim();
			bool bRequire = false;

			frmDmTg frmLookup = new frmDmTg();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "ASTG", "Ma_Tg", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				lbtTen_Tg.Text = string.Empty;
				lbtTen_Tg.Text = string.Empty;
			}
			else
			{
				txtMa_Tg.Text = ((string)drLookup["Ma_Tg"]).Trim();
				lbtTen_Tg.Text = ((string)drLookup["Ten_Tg"]).Trim();
			}

			dicName.SetValue(lbtTen_Tg.Name, lbtTen_Tg.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}
		#endregion

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

		void txtMa_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Sp.Text.Trim();
			bool bRequire = false;

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

		void chkTinh_Kh_CheckedChanged(object sender, EventArgs e)
		{
            lblSo_Thang.Enabled = chkTinh_Kh.Checked;
            numSo_Thang_Kh.Enabled = chkTinh_Kh.Checked;
            lblNgay_Tinh_Kh.Enabled = chkTinh_Kh.Checked;
            txtNgay_Bd_Kh.Enabled = chkTinh_Kh.Checked;
            lblTk_No.Enabled = chkTinh_Kh.Checked;
            txtTk_No.Enabled = chkTinh_Kh.Checked;
            lblTk_Co.Enabled = chkTinh_Kh.Checked;
            txtTk_Co.Enabled = chkTinh_Kh.Checked;
		}

		void numTien_NG_Nt_Validating(object sender, CancelEventArgs e)
		{
			//numTien_CL_Nt.Value = numTien_NG_Nt.Value - numTien_HM_Nt.Value;

			this.Tinh_Tien();
		}

		void numTien_Con_Lai_Validating(object sender, CancelEventArgs e)
		{
			if (numTien_NG_Nt.Value < numTien_CL_Nt.Value)
			{
				Common.MsgCancel("Tiền nguyên giá nhỏ hơn tiền còn lại");
				e.Cancel = true;
				return;
			}
			else
			{
				numTien_HM_Nt.Value = numTien_NG_Nt.Value - numTien_CL_Nt.Value;
			}

			this.Tinh_Tien();
		}

			void numTien_Hao_Mon_Validating(object sender, CancelEventArgs e)
		{
			if (numTien_NG_Nt.Value < numTien_HM_Nt.Value)
			{
				Common.MsgCancel("Tiền nguyên giá nhỏ hơn tiền còn lại");
				e.Cancel = true;
				return;
			}
			else
			{
				numTien_CL_Nt.Value = numTien_NG_Nt.Value - numTien_HM_Nt.Value;
			}

			this.Tinh_Tien();
		}

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