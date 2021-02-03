using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Lists;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;


namespace Epoint.Modules
{
	public partial class frmHanTt_Filter : Epoint.Systems.Customizes.frmEdit
	{
		public frmHanTt_Filter()
		{
			InitializeComponent();

			chkDu_Cuoi_Only.Checked = false;

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtTk.Validating += new CancelEventHandler(txtTk_Validating);
			txtMa_Dt.Validating +=new CancelEventHandler(txtMa_Dt_Validating);
		}

		public void Load()
		{
			BindingLanguage();		
            
			dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
			dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);

			this.ShowDialog();
		}

		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = false;

            //frmDoiTuong frmLookup = new frmDoiTuong();
			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

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

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}
        
		void txtTk_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk.Text.Trim();
			bool bRequire = false;

            //frmTaiKhoan frmLookup = new frmTaiKhoan();
			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "");

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
	}
}
