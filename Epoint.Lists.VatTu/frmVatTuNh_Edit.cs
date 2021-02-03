using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Data;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;

namespace Epoint.Lists
{
    public partial class frmVatTuNh_Edit : Epoint.Lists.frmEdit
    {

        #region Phuong thuc

		public frmVatTuNh_Edit()
		{
			InitializeComponent();

			txtMa_Nh_Vt_Cha.Enter += new EventHandler(txtMa_Nh_Vt_Cha_Enter);
			txtMa_Nh_Vt_Cha.Validating += new CancelEventHandler(txtMa_Nh_Vt_Cha_Validating);
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			if (txtMa_Nh_Vt_Cha.Text.Trim() != string.Empty)
			{
				lbtTen_Nh_Vt_Cha.Text = DataTool.SQLGetNameByCode("LIVATTUNH", "Ma_Nh_Vt", "Ten_Nh_Vt", txtMa_Nh_Vt_Cha.Text.Trim());
				dicName.Add(lbtTen_Nh_Vt_Cha.Name, lbtTen_Nh_Vt_Cha.Text);
			}
			else
				lbtTen_Nh_Vt_Cha.Text = string.Empty;
		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_Nh_Vt.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Nh_Vt") + " " +
							  Languages.GetLanguage("Not_Null"));

				return false;

            }			

			if (txtTen_Nh_Vt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Nh_Vt") + " " +
							  Languages.GetLanguage("Not_Null"));

				return false;
			}

            if (txtMa_Nh_Vt.Text.Trim() == txtMa_Nh_Vt_Cha.Text.Trim())
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Nh_Vt_Cha") + " " +
							  Languages.GetLanguage("Invalid"));
                return false;
            }

            return bvalid;
        }

		public override bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "LIVATTUNH", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("Ma_Nh_Vt", drEdit);

			return true;
		}
        #endregion

        #region Su kien

		private void txtMa_Nh_Vt_Cha_Enter(object sender, EventArgs e)
		{
			lbtTen_Nh_Vt_Cha.Text = dicName.GetValue(lbtTen_Nh_Vt_Cha.Name);
		}
		void txtMa_Nh_Vt_Cha_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nh_Vt_Cha.Text.Trim();
			bool bRequire = false;

			frmVatTuNh frmLookup = new frmVatTuNh();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIVATTUNH", "Ma_Nh_Vt", strValue, bRequire, "Nh_Cuoi = 0", "Nh_Cuoi = 0");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nh_Vt_Cha.Text = string.Empty;
				lbtTen_Nh_Vt_Cha.Text = string.Empty;
			}
			else
			{
				txtMa_Nh_Vt_Cha.Text = ((string)drLookup["Ma_Nh_Vt"]).Trim();
				lbtTen_Nh_Vt_Cha.Text = ((string)drLookup["Ten_Nh_Vt"]).Trim();
			}

			dicName.SetValue(lbtTen_Nh_Vt_Cha.Name, lbtTen_Nh_Vt_Cha.Text);
        }

        #endregion
    }
}