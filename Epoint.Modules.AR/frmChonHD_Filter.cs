using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Controls;
using Epoint.Lists;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;
using Epoint.Modules;

namespace Epoint.Modules.AR
{
	public partial class frmChonHD_Filter : Epoint.Systems.Customizes.frmEdit
	{
		frmVoucher_Edit frmEditCtHD;

		public frmChonHD_Filter()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);			
			txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);
			txtMa_Nh_Vt.Validating += new CancelEventHandler(txtMa_Nh_Vt_Validating);
			txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
		}

		public new void Load(frmVoucher_Edit frmEditCtHD)
		{
			this.frmEditCtHD = frmEditCtHD;

			this.dteNgay_Ct1.Text = Library.DateToStr(Epoint.Systems.Elements.Element.sysNgay_Ct1);
			this.dteNgay_Ct2.Text = Library.DateToStr(Epoint.Systems.Elements.Element.sysNgay_Ct2);
			this.txtMa_Dt.Text = (string)frmEditCtHD.drEditPh["Ma_Dt"];

			this.BindingLanguage();

			ShowDialog();
		}

		void XemHoaDon()
		{	
			string strMa_Ct = txtMa_Ct.Text.Trim();
			string strKey = "(0 = 0) ";// = TRUE

			if (!(txtMa_Ct.Text.Trim() == string.Empty))
				strKey += " AND (Ma_Ct = '" + txtMa_Ct.Text.Trim() + "')";

			if (!dteNgay_Ct1.IsNull)
				strKey += " AND (Ngay_Ct >= '" + dteNgay_Ct1.Text.Trim() + "')";

			if (!dteNgay_Ct2.IsNull)
				strKey += " AND (Ngay_Ct <= '" + dteNgay_Ct2.Text.Trim() + "')";

			if (!(txtSo_Ct1.Text.Trim() == string.Empty))
				strKey += " AND (So_Ct >= '" + txtSo_Ct1.Text.Trim() + "')";

			if (!(txtSo_Ct2.Text.Trim() == string.Empty))
				strKey += " AND (So_Ct <= '" + txtSo_Ct2.Text.Trim() + "')";

			if (!(txtMa_Dt.Text.Trim() == string.Empty))
				strKey += " AND (Ma_Dt = '" + txtMa_Dt.Text.Trim() + "')";

			//Chua xu ly theo Ma_KhN
			if (!(txtMa_Kho.Text.Trim() == string.Empty))
				strKey += " AND (Ma_Kho = '" + txtMa_Kho.Text.Trim() + "')";

			if (!(txtMa_Vt.Text.Trim() == string.Empty))
				strKey += " AND (Ma_Vt = '" + txtMa_Vt.Text.Trim() + "')";

			if (!(txtMa_Nh_Vt.Text.Trim() == string.Empty))
				strKey += " AND (Ma_Vt  IN  (SELECT Ma_Vt FROM LIVATTU WHERE Ma_Nh_Vt = '" + txtMa_Nh_Vt.Text.Trim() + "'))";

			frmChonHD_View frm = new frmChonHD_View();
			frm.Load(frmEditCtHD, strMa_Ct, strKey);
		}	

		void btAccept_Click(object sender, EventArgs e)
		{

			XemHoaDon();

			isAccept = true;
			this.Close();
		}
		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}

		void txtMa_Ct_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Ct.Text.Trim();
			bool bRequire = true;

			frmQuickLookup frmLookup = new frmQuickLookup("SYSDMCT", "DMCT");
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "SYSDMCT", "Ma_Ct", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Ct.Text = string.Empty;
				lbtMa_Ct.Text = string.Empty;
			}
			else
			{
				txtMa_Ct.Text = drLookup["Ma_Ct"].ToString();
				lbtMa_Ct.Text = drLookup["Ten_Ct"].ToString();

				dicName.SetValue(lbtMa_Ct.Name, lbtMa_Ct.Text);
			}

		}

		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = false;

			frmDoiTuong frmLookup = new frmDoiTuong();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIDOITUONG", "Ma_Dt", strValue, bRequire, "");

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

			dicName[lbtTen_Dt.Name] = lbtTen_Dt.Text;

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}
		void txtMa_Kho_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Kho.Text.Trim();
			bool bRequire = false;

            //frmKho frmLookup = new frmKho();
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

			dicName[lbtTen_Kho.Name] = lbtTen_Kho.Text;

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

		void txtMa_Nh_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nh_Vt.Text.Trim();
			bool bRequire = false;

            //frmVatTuNh frmLookup = new frmVatTuNh();
			DataRow drLookup = Lookup.ShowLookup( "Ma_Nh_Vt", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nh_Vt.Text = string.Empty;
				lbtTen_Nh_Vt.Text = string.Empty;
			}
			else
			{
				txtMa_Nh_Vt.Text = drLookup["Ma_Nh_Vt"].ToString();
				lbtTen_Nh_Vt.Text = drLookup["Ten_Nh_Vt"].ToString();
			}

			dicName[lbtTen_Nh_Vt.Name] = lbtTen_Nh_Vt.Text;

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

            //frmVatTu frmLookup = new frmVatTu();
			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "");

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

			dicName[lbtTen_Vt.Name] = lbtTen_Vt.Text;

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}		
	}	 
}
