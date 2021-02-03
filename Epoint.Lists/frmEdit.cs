using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems;
using Epoint.Systems.Elements;

namespace Epoint.Lists
{
    public partial class frmEdit : Epoint.Systems.Customizes.frmEdit
    {
        #region Methods

        public frmEdit()
        {
            InitializeComponent();

            this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            this.KeyDown += new KeyEventHandler(frmEdit_KeyDown);
        }

        void frmEdit_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.S:
                    if (e.Control)
                    {
                        if (this.Save())
                        {
                            isAccept = true;
                            this.Close();
                            //base.ShowSuccessMessage("Thành công !");
                        }
                    }
                    break;
            }
        }

        new public virtual void Load(enuEdit enuNew_Edit, DataRow drEdit)
        {

        }

        public virtual bool FormCheckValid()
        {
            return true;
        }

        public virtual bool Save()
        {
            return true;
        }

        #endregion

        #region Events

        private void btAccept_Click(object sender, EventArgs e)
        {
            if (this.Save())
            {
                isAccept = true;
                this.Close();
                //base.ShowSuccessMessage("Thành công !");
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            isAccept = false;
            this.Close();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!Element.Is_Running)
                return;
            //Kiem tra Permission
            switch (this.enuNew_Edit)
            {
                case enuEdit.New:
                    this.btgAccept.btAccept.Enabled = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New);
                    break;
                case enuEdit.Edit:
                    this.btgAccept.btAccept.Enabled = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit);
                    break;
                default:
                    break;
            }

            //Mac dinh Ma_Data --> theo tham so he thong
            if ((string)Parameters.GetParaValue("AUTO_DEFAULT_MA_DATA") == "1")
                this.ucMa_Data.cboMa_Data.Text = "*";
            else
                this.ucMa_Data.cboMa_Data.Text = Element.sysMa_Data;

            //Mac dinh Ma_Data --> theo SYSDMDVCS_DEFAULTLIST
            string strMa_Data = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT Ma_DvCs FROM SYSDMDVCS_DEFAULTLIST WHERE Ma_Dm ='" + this.Object_ID + "'"));
            if (strMa_Data == "*")
                this.ucMa_Data.cboMa_Data.Text = strMa_Data;
        }

        #endregion
    }
}
