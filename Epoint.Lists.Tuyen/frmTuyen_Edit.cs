using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;

namespace Epoint.Lists
{
    public partial class frmTuyen_Edit : Epoint.Lists.frmEdit
	{
        #region Phuong thuc

		public frmTuyen_Edit()
		{
			InitializeComponent();

			txtMa_Tuyen_Cha.Enter += new EventHandler(txtMa_Tuyen_Cha_Enter);
			txtMa_Tuyen_Cha.Validating += new CancelEventHandler(txtMa_Tuyen_Cha_Validating);
            txtMa_CBNV_Bh.Validating += new CancelEventHandler(txtMa_CbNv_Bh_Validating);
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

			if (txtMa_Tuyen_Cha.Text.Trim() != string.Empty)
			{
				lbtTen_Tuyen_Cha.Text = DataTool.SQLGetNameByCode("LITUYEN", "Ma_Tuyen", "Ten_Tuyen", txtMa_Tuyen_Cha.Text.Trim());
				dicName.Add(lbtTen_Tuyen_Cha.Name, lbtTen_Tuyen_Cha.Text);
			}
			else
				lbtTen_Tuyen_Cha.Text = string.Empty;


            if (txtMa_CBNV_Bh.Text.Trim() != string.Empty)
            {
                lbtMa_CBNV_Bh.Text = DataTool.SQLGetNameByCode("LINHANVIEN", "Ma_CBNV", "Ten_CBNV", txtMa_CBNV_Bh.Text.Trim());
                dicName.Add(lbtMa_CBNV_Bh.Name, lbtMa_CBNV_Bh.Text);
            }
            else
                lbtMa_CBNV_Bh.Text = string.Empty;



            if (txtMa_CbNv_Gh.Text.Trim() != string.Empty)
            {
                lbtMa_CBNV_GH.Text = DataTool.SQLGetNameByCode("LINHANVIEN", "Ma_CBNV", "Ten_CBNV", txtMa_CbNv_Gh.Text.Trim());
                dicName.Add(lbtMa_CBNV_GH.Name, lbtMa_CBNV_GH.Text);
            }
            else
                lbtMa_CBNV_GH.Text = string.Empty;
		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_Tuyen.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Tuyen") + " " +
							  Languages.GetLanguage("Not_Null"));
                return false;
            }			

			if (txtTen_Tuyen.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Tuyen") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}			

            if (txtMa_Tuyen.Text.Trim() == txtMa_Tuyen_Cha.Text.Trim())
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Tuyen_Cha") + " " +
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "LITUYEN", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("Ma_Tuyen", drEdit);

			return true;
		}
        #endregion

        #region Su kien

		private void txtMa_Tuyen_Cha_Enter(object sender, EventArgs e)
		{
			lbtTen_Tuyen_Cha.Text = dicName.GetValue(lbtTen_Tuyen_Cha.Name);
		}

		void txtMa_Tuyen_Cha_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Tuyen_Cha.Text.Trim();
			bool bRequire = false;

			frmTuyen frmLookup = new frmTuyen();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LITUYEN", "Ma_Tuyen", strValue, bRequire, "Nh_Cuoi = 0");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Tuyen_Cha.Text = string.Empty;
				lbtTen_Tuyen_Cha.Text = string.Empty;
			}
			else
			{
                txtMa_Tuyen_Cha.Text = ((string)drLookup["Ma_Tuyen"]).Trim();
				lbtTen_Tuyen_Cha.Text = ((string)drLookup["Ten_Tuyen"]).Trim();
			}

			dicName.SetValue(lbtTen_Tuyen_Cha.Name, lbtTen_Tuyen_Cha.Text);
		}

        void txtMa_CbNv_Bh_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_CBNV_Bh.Text.Trim();
            bool bRequire = false;
           
            DataRow drLookup = Lookup.ShowLookup("Ma_Cbnv", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_CBNV_Bh.Text = string.Empty;
                lbtMa_CBNV_Bh.Text = string.Empty;
            }
            else
            {
                txtMa_CBNV_Bh.Text = ((string)drLookup["Ma_Cbnv"]).Trim();
                lbtMa_CBNV_Bh.Text = ((string)drLookup["Ten_CbNv"]).Trim();
            }

            dicName.SetValue(lbtMa_CBNV_Bh.Name, lbtMa_CBNV_Bh.Text);
        }
        #endregion 
	}
}