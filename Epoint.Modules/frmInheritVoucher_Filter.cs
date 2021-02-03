using System;
using System.Collections;
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
using Epoint.Systems.Elements;
using Epoint.Systems.Customizes;
using Epoint.Modules;
using Epoint.Systems.Data;

namespace Epoint.Modules
{
	public partial class frmInheritVoucher_Filter : Epoint.Systems.Customizes.frmEdit
	{
		frmVoucher_Edit frmEditCt;
        public string strMa_Ct_Current;

		public frmInheritVoucher_Filter()
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

		public new void Load(frmVoucher_Edit frmEditCt)
		{
			this.frmEditCt = frmEditCt;
			this.dteNgay_Ct1.Text = Library.DateToStr((DateTime)frmEditCt.drEditPh["Ngay_Ct"]);
			this.dteNgay_Ct2.Text = this.dteNgay_Ct1.Text;

			this.BindingLanguage();

            Init();
			this.ShowDialog();
		}
        private void Init()
        {
            this.strMa_Ct_Current = frmEditCt.strMa_Ct;
            switch (strMa_Ct_Current)
            {
                case "NM":
                    txtMa_Ct.Text = "PO";
                    break;

                case "NK":
                    txtMa_Ct.Text = "PO";
                    break;

                case "MTL":
                    txtMa_Ct.Text = "NM";
                    break;

                case "CP":
                    txtMa_Ct.Text = "NM";
                    break;

                case "HD":
                    txtMa_Ct.Text = "SO";
                    break;

                case "TL":
                    txtMa_Ct.Text = "HD";
                    break;

                case "SO":
                    txtMa_Ct.Text = "BG";

                    break;

                case "PX":
                    txtMa_Ct.Text = "HD";
                    break;

                case "PXB":
                    txtMa_Ct.Text = "HD";
                    break;

                case "PT":
                    txtMa_Ct.Text = "HD";
                    break;

                case "BC":
                    txtMa_Ct.Text = "HD";
                    break;

                case "PC":
                    txtMa_Ct.Text = "NM";
                    break;

                case "BN":
                    txtMa_Ct.Text = "NM";
                    break;

                default:
                    txtMa_Ct.Text = "SO";
                    break;
            }

        }
		void XemChungTu()
		{
            string strMa_Ct = txtMa_Ct.Text.Trim();

            Hashtable ht = new Hashtable();

            ht["MA_CT"] = txtMa_Ct.Text;
            ht["NGAY_CT1"] = Library.StrToDate(dteNgay_Ct1.Text);
            ht["NGAY_CT2"] = Library.StrToDate(dteNgay_Ct2.Text);
            ht["SO_CT1"] = txtSo_Ct1.Text;
            ht["SO_CT2"] = txtSo_Ct2.Text;
            ht["MA_DT"] = txtMa_Dt.Text;
            ht["MA_KHO"] = txtMa_Kho.Text;            
            ht["MA_NH_VT"] = txtMa_Nh_Vt.Text;
            ht["MA_VT"] = txtMa_Vt.Text;
            ht["GETKEY_ONLY"] = true;
            ht["MA_DVCS"] = Element.sysMa_DvCs;

            string strKey = (string)SQLExec.ExecuteReturnValue("sp_GetKeyPh", ht, CommandType.StoredProcedure);

            DataRow drDmCt = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", strMa_Ct_Current);
            string strTable_Ct = (string)drDmCt["Table_Ct"];

            frmInheritVoucher_View frm = new frmInheritVoucher_View();            
            frm.Load(frmEditCt, strMa_Ct, strKey);
            
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			XemChungTu();

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

            //frmDoiTuong frmLookup = new frmDoiTuong();
            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt.Text = string.Empty;
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
			DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Vt", strValue, bRequire, "");

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
