using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Lists;

namespace Epoint.Modules.AR
{
	public partial class frmDiscFreeItem_Edit : Epoint.Systems.Customizes.frmEdit
	{
        public frmDiscFreeItem_Edit()
		{
			InitializeComponent();

            this.txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{

            if (txtMa_Vt.Text.Trim() != string.Empty)
            {
                lbtTen_Vt.Text = DataTool.SQLGetNameByCode("LIVATTU", "Ma_Vt", "Ten_Vt", txtMa_Vt.Text.Trim());
                dicName.Add(lbtTen_Vt.Name, lbtTen_Vt.Text);
            }
            else
                lbtTen_Vt.Text = string.Empty;


            if (txtMa_Kho.Text.Trim() != string.Empty)
            {
                lbtTen_Kho.Text = DataTool.SQLGetNameByCode("LIKHO", "Ma_Kho", "Ten_Kho", txtMa_Kho.Text.Trim());
                dicName.Add(lbtTen_Kho.Name, lbtTen_Kho.Text);
            }
            else
                lbtTen_Kho.Text = string.Empty;



            DataRow drDmVt = DataTool.SQLGetDataRowByID("LIVATTU", "Ma_Vt", txtMa_Vt.Text);
            if (drDmVt != null)
            {
                string strDvt_Chuan = (string)drDmVt["Dvt"];

                string inputMask = (string)drDmVt["Dvt"];

                for (int i = 1; i <= 3; i++)
                    inputMask += (string)drDmVt["Dvt" + i] == string.Empty ? string.Empty : "," + (string)drDmVt["Dvt" + i];

                if (inputMask != string.Empty)
                    inputMask += "," + inputMask;
                if (inputMask == null || inputMask == string.Empty)
                    return;

                txtDvt.InputMask = inputMask;
            }
		}

		private bool FormCheckValid()
		{
			if (txtMa_Vt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Vt") + " " +
						Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtMa_Kho.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Kho") + " " +
						Languages.GetLanguage("Not_Null"));
				return false;
			}			

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			if (drEdit.Table.Columns.Contains("Ten_Vt"))
				drEdit["Ten_Vt"] = lbtTen_Vt.Text;

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "OM_DISCFREEITEM", ref drEdit))
				return false;

			return true;
		}


		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				this.isAccept = true;
				this.Close();
			}
		}
		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}

        void txtMa_Vt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt.Text.Trim();
            bool bRequire = false;

            //frmVatTu frmLookup = new frmVatTu();
            DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Vt.Text = string.Empty;
                lbtTen_Vt.Text = string.Empty;
            }
            else
            {
                txtMa_Vt.Text = ((string)drLookup["Ma_Vt"]).Trim();
                lbtTen_Vt.Text = ((string)drLookup["Ten_Vt"]).Trim();
                txtDvt.Text = ((string)drLookup["Dvt"]).Trim();
            }

            DataRow drDmVt = DataTool.SQLGetDataRowByID("LIVATTU", "Ma_Vt", txtMa_Vt.Text);
            if (drDmVt != null)
            {
                string strDvt_Chuan = (string)drDmVt["Dvt"];

                string inputMask = (string)drDmVt["Dvt"];

                for (int i = 1; i <= 3; i++)
                    inputMask += (string)drDmVt["Dvt" + i] == string.Empty ? string.Empty : "," + (string)drDmVt["Dvt" + i];

                if (inputMask != string.Empty)
                    inputMask += "," + inputMask;
                if (inputMask == null || inputMask == string.Empty)
                    return;

                txtDvt.InputMask = inputMask;
            }
            dicName.SetValue(lbtTen_Vt.Name, lbtTen_Vt.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }
	}
}
