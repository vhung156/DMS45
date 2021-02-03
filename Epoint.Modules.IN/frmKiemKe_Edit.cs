using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//Epoint
using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;
using Epoint.Lists;

namespace Epoint.Modules.IN
{
    public partial class frmKiemKe_Edit : Epoint.Systems.Customizes.frmEdit
    {
        #region Methods

        public frmKiemKe_Edit()
        {
            InitializeComponent();

            txtMa_Kho.Enter += new EventHandler(txtMa_Kho_Enter);
            txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);

            txtMa_Vt.Enter += new EventHandler(txtMa_Vt_Enter);
            txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);

            this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
        }

        public void Load(enuEdit enuNew_Edit, DataRow drEdit)
        {
            this.enuNew_Edit = enuNew_Edit;
            this.drEdit = drEdit;

            Common.ScaterMemvar(this, ref drEdit);

            this.ShowDialog();
        }

        public bool FormCheckValid()
        {
            if (txtMa_Kho.Text.Trim() == string.Empty)
            {
                Common.MsgCancel(Languages.GetLanguage("Ma_Kho") + " " + Languages.GetLanguage("Cannot_Empty"));
                return false;
            }

            if (txtMa_Vt.Text.Trim() == string.Empty)
            {
                Common.MsgCancel(Languages.GetLanguage("Ma_Vt") + " " + Languages.GetLanguage("Cannot_Empty"));
                return false;
            }

            if (txtNgay_Ct.IsNull)
            {
                Common.MsgCancel(Languages.GetLanguage("Date") + " " + Languages.GetLanguage("Cannot_Empty"));
                return false;
            }

            return true;
        }

        public bool Save()
        {
            //if (!Common.CheckDataLocked(Library.StrToDate(txtNgay_Ct.Text)))
            //{
            //    Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
            //    return false;
            //}

            Common.GatherMemvar(this, ref drEdit);

            if (!FormCheckValid())
                return false;

            if (!DataTool.SQLUpdate(enuNew_Edit, "INKIEMKE", ref drEdit))
                return false;

            return true;
        }

        #endregion

        #region Events
        void txtMa_Kho_Enter(object sender, EventArgs e)
        {
            lbtTen_Kho.Text = dicName.GetValue(lbtTen_Kho.Name);
        }

        void txtMa_Kho_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Kho.Text;
            bool bRequire = false;

            //frmKho frmLookup = new frmKho();
            DataRow drLookup = Lookup.ShowLookup( "Ma_Kho", strValue, bRequire, "");

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

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        void txtMa_Vt_Enter(object sender, EventArgs e)
        {
            lbtTen_Vt.Text = dicName.GetValue(lbtTen_Vt.Name);
        }

        void txtMa_Vt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt.Text;
            bool bRequire = false;

            //frmVatTu frmLookup = new frmVatTu();
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

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
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
            this.isAccept = false;            
            this.Close();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);            
        }        

        #endregion
    }
}
