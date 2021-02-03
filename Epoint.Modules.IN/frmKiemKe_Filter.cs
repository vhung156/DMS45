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

namespace Epoint.Modules.IN
{
    public partial class frmKiemKe_Filter : Epoint.Systems.Customizes.frmEdit
	{
		#region Methods

        public frmKiemKe_Filter()
		{
			InitializeComponent();
		
			txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);			
			txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);

            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}        

		public void Load()
		{
			this.BindingLanguage();

			this.ShowDialog();
		}		

		#endregion

		#region Events

		void txtMa_Kho_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Kho.Text.Trim();
			bool bRequire = false;

            //Lists.frmKho frmLookup = new Epoint.Lists.frmKho();
			DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Kho.Text = string.Empty;
				lbtTen_Kho.Text = string.Empty;
			}
			else
			{
				txtMa_Kho.Text = drLookup["Ma_Kho"].ToString();
				lbtTen_Kho.Text = drLookup["Ten_Kho"].ToString();
			}

			dicName.SetValue(lbtTen_Kho.Name, lbtTen_Kho.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}		

		void txtMa_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt.Text.Trim();
			bool bRequire = false;

            //Lists.frmVatTu frmLookup = new Epoint.Lists.frmVatTu();
			DataRow drLookup = Lookup.ShowLookup( "Ma_Vt" ,strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt.Text = string.Empty;
				lbtTen_Vt.Text = string.Empty;
			}
			else
			{
				txtMa_Vt.Text = drLookup["Ma_Vt"].ToString();
				lbtTen_Vt.Text = drLookup["Ten_Vt"].ToString();
			}

			dicName.SetValue(lbtTen_Vt.Name, lbtTen_Vt.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

        void btCancel_Click(object sender, EventArgs e)
        {
            isAccept = false;
            this.Close();
        }

        void btAccept_Click(object sender, EventArgs e)
        {
            isAccept = true;                     
            this.Close();
        }

		#endregion		
        
	}
}
