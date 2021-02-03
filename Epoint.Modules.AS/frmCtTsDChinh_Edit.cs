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
	public partial class frmCtTsDChinh_Edit : Epoint.Systems.Customizes.frmEdit
	{
		#region Contructor
		public DataRow drCtTsNGia;

		public frmCtTsDChinh_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			numTien_NG_Nt.Validating += new CancelEventHandler(numTien_NG_Nt_Validating);
			numTien_HM_Nt.Validating += new CancelEventHandler(numTien_Hao_Mon_Validating);
			numTien_CL_Nt.Validating += new CancelEventHandler(numTien_Con_Lai_Validating);

			txtMa_Tg.Validating += new CancelEventHandler(txtMa_Giam_Validating);
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
			if ((string)drCtTsNGia["Ma_Tte"] == Element.sysMa_Tte)
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
            //Ma_Tg
            if (txtMa_Tg.Text.Trim() != string.Empty)
            {
                lbtTen_Tg.Text = DataTool.SQLGetNameByCode("ASTG", "Ma_Tg", "Ten_Tg", txtMa_Tg.Text.Trim());
                dicName.Add(lbtTen_Tg.Name, lbtTen_Tg.Text);
            }
            else
                lbtTen_Tg.Text = string.Empty;
		}

		private void Tinh_Tien()
		{
			double dbTy_Gia = Convert.ToDouble(drCtTsNGia["Ty_Gia"]);
			if (dbTy_Gia == 0)
				dbTy_Gia = 1;

			this.numTien_NG.Value = Math.Round(this.numTien_NG_Nt.Value * dbTy_Gia, 0, MidpointRounding.AwayFromZero);
			this.numTien_HM.Value = Math.Round(this.numTien_HM_Nt.Value * dbTy_Gia, 0, MidpointRounding.AwayFromZero);
			this.numTien_CL.Value = Math.Round(this.numTien_CL_Nt.Value * dbTy_Gia, 0, MidpointRounding.AwayFromZero);
		}

		private bool FormCheckValid()
		{
			if (dteNgay_Ps.Text.Replace(" ", "") == "//")
			{
				Common.MsgOk(Languages.GetLanguage("Ngay_Ps") + " " +
							 Languages.GetLanguage("Cannot_Empty"));
				return false;
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

			//Kiem tra Valid CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "ASTSDC", ref drEdit))
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

		void numTien_NG_Nt_Validating(object sender, CancelEventArgs e)
		{
			this.Tinh_Tien();
		}

		void numTien_Con_Lai_Validating(object sender, CancelEventArgs e)
		{
			if (!chkIs_Giam_Ts.Checked)
				numTien_HM_Nt.Value = numTien_NG_Nt.Value - numTien_CL_Nt.Value;

			this.Tinh_Tien();
		}

		void numTien_Hao_Mon_Validating(object sender, CancelEventArgs e)
		{
			if (!chkIs_Giam_Ts.Checked)
				numTien_CL_Nt.Value = numTien_NG_Nt.Value - numTien_HM_Nt.Value;

			this.Tinh_Tien();
		}

		void txtMa_Giam_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Tg.Text.Trim();
			bool bRequire = true;

			frmDmTg frmLookup = new frmDmTg();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "ASTG", "Ma_Tg", strValue, bRequire, null);

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