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
using Epoint.Systems.Commons;

namespace Epoint.Modules.AS
{
	public partial class frmDmNhCCDC_Edit : Epoint.Systems.Customizes.frmEdit
	{
        #region Phuong thuc

		public frmDmNhCCDC_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtMa_Nh_Ts_Cha.Enter += new EventHandler(txtMa_Bp_Cha_Enter);
			txtMa_Nh_Ts_Cha.Validating += new CancelEventHandler(txtMa_Bp_Cha_Validating);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;

			this.enuNew_Edit = enuNew_Edit;
            this.Text = enuNew_Edit == enuEdit.New ? "Them moi nhom tai san" : "Sua nhom tai san";		

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{

			if (txtMa_Nh_Ts_Cha.Text.Trim() != string.Empty)
			{
				lbtMa_Nh_Ts_Cha.Text = DataTool.SQLGetNameByCode("ASTSNH", "Ma_Nh_Ts", "Ten_Nh_Ts", txtMa_Nh_Ts_Cha.Text.Trim());
				dicName.Add(lbtMa_Nh_Ts_Cha.Name, lbtMa_Nh_Ts_Cha.Text);
			}
			else
				lbtMa_Nh_Ts_Cha.Text = string.Empty;

		}

		private bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_Nh_Ts.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Nh_Ts") + " " +
							  Languages.GetLanguage("Not_Null"));
                return false;
            }			

			if (txtTen_Nh_Ts.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Nh_Ts") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}			

            if (txtMa_Nh_Ts.Text.Trim() == txtMa_Nh_Ts_Cha.Text.Trim())
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Nh_Ts_Cha") + " " +
							  Languages.GetLanguage("Invalid"));
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

			//Kiem tra Valid CSDL			
			if (!DataTool.SQLUpdate(enuNew_Edit, "ASTSNH", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_NH_TS", drEdit);

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

		private void txtMa_Bp_Cha_Enter(object sender, EventArgs e)
		{
			lbtMa_Nh_Ts_Cha.Text = dicName.GetValue(lbtMa_Nh_Ts_Cha.Name);
		}

		void txtMa_Bp_Cha_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nh_Ts_Cha.Text.Trim();
			bool bRequire = false;

			frmDmNhTs frmLookup = new frmDmNhTs();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "ASTSNH", "Ma_Nh_Ts", strValue, bRequire, "Nh_Cuoi = '0'");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nh_Ts_Cha.Text = string.Empty;
				lbtMa_Nh_Ts_Cha.Text = string.Empty;
			}
			else
			{
				txtMa_Nh_Ts_Cha.Text = ((string)drLookup["Ma_Nh_Ts"]).Trim();
				lbtMa_Nh_Ts_Cha.Text = ((string)drLookup["Ten_Nh_Ts"]).Trim();
			}

			dicName.SetValue(lbtMa_Nh_Ts_Cha.Name, lbtMa_Nh_Ts_Cha.Text);
		}
        #endregion 
	}
}