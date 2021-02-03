using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;
using Epoint.Lists;

namespace Epoint.Modules.GL
{
	public partial class frmDuDauXdCb_Edit : Epoint.Systems.Customizes.frmEdit
	{

        #region Phuong thuc

		public frmDuDauXdCb_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtMa_Sp.Enter += new EventHandler(txtMa_Sp_Enter);
			txtMa_Sp.Validating += new CancelEventHandler(txtMa_Sp_Validating);

			txtMa_Nv.Enter += new EventHandler(txtMa_Nv_Enter);
			txtMa_Nv.Validating += new CancelEventHandler(txtMa_Nv_Validating);

			txtTk.Enter += new EventHandler(txtTk_Enter);
			txtTk.Validating += new CancelEventHandler(txtTk_Validating);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;

			this.enuNew_Edit = enuNew_Edit;
			this.Text = enuNew_Edit == enuEdit.New ? "Thêm mới số dư xây dựng cơ bản" : "Sữa số dư xây dựng cơ bản";

			Common.ScaterMemvar(this, ref drEdit);

			//BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			//txtMa_Sp
			if (txtMa_Sp.Text.Trim() != string.Empty)
			{
				lbtTen_Sp.Text = DataTool.SQLGetNameByCode("LISANPHAM", "Ma_Sp", "Ten_Sp", txtMa_Sp.Text.Trim());
				dicName.SetValue(lbtTen_Sp.Name, lbtTen_Sp.Text);
			}
			else
				lbtTen_Sp.Text = string.Empty;
		}

		private bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_Sp.Text.Trim() == string.Empty)
            {
				Common.MsgCancel(Languages.GetLanguage("Ma_Sp") + " " +
							  Languages.GetLanguage("Not_Null"));
				
				return false;
            }

			if (dteNgay_Ct.IsNull)
			{
				Common.MsgCancel(Languages.GetLanguage("Ngay_Ct") + " " +
							  Languages.GetLanguage("Not_Null"));

				return false;
			}			


            return bvalid;
        }

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "GLDUDAUXDCB", ref drEdit))
				return false;			

			return true;
		}

        #endregion

        #region Su kien

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

		void txtMa_Sp_Enter(object sender, EventArgs e)
		{
			lbtTen_Sp.Text = dicName.GetValue(lbtTen_Sp.Name);
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
				txtMa_Nv.Text = string.Empty;
				lbtTen_Nv.Text = string.Empty;
			}
			else
			{
				txtMa_Nv.Text = drLookup["Ma_Nv"].ToString();
				lbtTen_Nv.Text = drLookup["Ten_Nv"].ToString();
			}

			dicName.SetValue(lbtTen_Nv.Name, lbtTen_Nv.Text);

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

			frmTaiKhoan frmLookup = new frmTaiKhoan();
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
			}

			dicName.SetValue(lbtTen_Tk.Name, lbtTen_Tk.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

        #endregion 

	}
}