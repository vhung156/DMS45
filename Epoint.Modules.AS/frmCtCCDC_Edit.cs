using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Lists;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Elements;
using Epoint.Systems.Data;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;

namespace Epoint.Modules.AS
{
	public partial class frmCtCCDC_Edit : Epoint.Systems.Customizes.frmEdit
	{

		#region Phuong thuc

		public frmCtCCDC_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtMa_Nh_Ts.Enter += new EventHandler(txtMa_Nh_Ts_Enter);
			txtMa_Nh_Ts.Validating += new CancelEventHandler(txtMa_Nh_Ts_Validating);

			//txtMa_CCDC.TextChanged += new EventHandler(txtMA_CCDC_TextChanged);
            //txtMA_CCDC.Validating += new CancelEventHandler(txtMA_CCDC_Validating);

			txtTk_CCDC.Enter += new EventHandler(txtTk_Ts_Enter);
			txtTk_CCDC.Validating += new CancelEventHandler(txtTk_CCDC_Validating);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;

			Common.ScaterMemvar(this, ref drEdit);

            this.Init();
			LoadDicName();
			BindingLanguage();

			this.ShowDialog();
		}
        private void Init()
        {
            //this.Ma_Tte_Show();
        }

		private void LoadDicName()
		{
			//Ten_Tk
			if (txtTk_CCDC.Text.Trim() != string.Empty)
			{
				lbtTen_Tk_CCDC.Text = DataTool.SQLGetNameByCode("LITAIKHOAN", "Tk", "Ten_Tk", txtTk_CCDC.Text.Trim());
				dicName.Add(lbtTen_Tk_CCDC.Name, lbtTen_Tk_CCDC.Text);
			}
			else
				lbtTen_Tk_CCDC.Text = string.Empty;

			//Ma_Nh_Ts
			if (txtMa_Nh_Ts.Text.Trim() != string.Empty)
			{
				lbtTen_Nh_Ts.Text = DataTool.SQLGetNameByCode("ASTSNH", "Ma_Nh_Ts", "Ten_Nh_Ts", txtMa_Nh_Ts.Text.Trim());
				dicName.Add(lbtTen_Nh_Ts.Name, lbtTen_Nh_Ts.Text);
			}
			else
				lbtTen_Nh_Ts.Text = string.Empty;

            //MA_CCDC
            if (txtMa_CCDC.Text.Trim() != string.Empty)
            {
                txtTen_CCDC.Text = DataTool.SQLGetNameByCode("ASCCDC", "MA_CCDC", "Ten_CCDC", txtMa_CCDC.Text.Trim());
                dicName.Add(txtTen_CCDC.Name, txtTen_CCDC.Text);
            }
            else
                txtTen_CCDC.Text = string.Empty;
		}

		private bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtMa_CCDC.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("MA_CCDC") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtTen_CCDC.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_CCDC") + " " +
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

			//Kiem tra Valid CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "ASCCDC", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_CCDC", drEdit);

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
        
		void txtTk_Ts_Enter(object sender, EventArgs e)
		{
			lbtTen_Tk_CCDC.Text = dicName.GetValue(lbtTen_Tk_CCDC.Name);
		}

		void txtTk_CCDC_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk_CCDC.Text.Trim();
			bool bRequire = true;

			frmTaiKhoan frmLookup = new frmTaiKhoan();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LITAIKHOAN", "Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				lbtTen_Tk_CCDC.Text = string.Empty;
				lbtTen_Tk_CCDC.Text = string.Empty;
			}
			else
			{
				txtTk_CCDC.Text = ((string)drLookup["Tk"]).Trim();
				lbtTen_Tk_CCDC.Text = ((string)drLookup["Ten_Tk"]).Trim();
			}

			dicName.SetValue(lbtTen_Tk_CCDC.Name, lbtTen_Tk_CCDC.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}
        //void txtMA_CCDC_Validating(object sender, CancelEventArgs e)
        //{
        //    string strValue = txtMA_CCDC.Text.Trim();
        //    bool bRequire = false;            

        //    frmQuickLookup frmLookup = new frmQuickLookup("VW_TAISANLIST", "CtCCDC");
        //    DataRow drLookup = Lookup.ShowLookup(frmLookup, "VW_TAISANLIST", "MA_CCDC", strValue, bRequire, null);

        //    if (bRequire && drLookup == null)
        //        e.Cancel = true;

        //    if (drLookup == null)
        //    {
        //        txtMA_CCDC.Text = string.Empty;
        //        txtTen_CCDC.Text = string.Empty;
        //    }
        //    else
        //    {
        //        txtMA_CCDC.Text = drLookup["MA_CCDC"].ToString();
        //        txtTen_CCDC.Text = ((string)drLookup["Ten_CCDC"]).Trim();
        //    }
        //    dicName.SetValue(txtTen_CCDC.Name, txtTen_CCDC.Text);
        //}

        //void txtMA_CCDC_TextChanged(object sender, EventArgs e)
        //{
        //    if (this.enuNew_Edit == enuEdit.New)
        //        this.txtSo_The.Text = this.txtMa_CCDC.Text;
        //}

		void txtMa_Nh_Ts_Enter(object sender, EventArgs e)
		{
			lbtTen_Nh_Ts.Text = dicName.GetValue(lbtTen_Nh_Ts.Name);
		}

		void txtMa_Nh_Ts_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nh_Ts.Text.Trim();
			bool bRequire = true;

			frmDmNhTs frmLookup = new frmDmNhTs();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "ASTSNH", "Ma_Nh_Ts", strValue, bRequire, "", "Nh_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				lbtTen_Nh_Ts.Text = string.Empty;
				lbtTen_Nh_Ts.Text = string.Empty;
			}
			else
			{
				txtMa_Nh_Ts.Text = ((string)drLookup["Ma_Nh_Ts"]).Trim();
				lbtTen_Nh_Ts.Text = ((string)drLookup["Ten_Nh_Ts"]).Trim();
			}

			dicName.SetValue(lbtTen_Nh_Ts.Name, lbtTen_Nh_Ts.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}                       
		#endregion

	}
}