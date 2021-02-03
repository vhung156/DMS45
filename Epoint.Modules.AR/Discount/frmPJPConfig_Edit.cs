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
using Epoint.Systems.Elements;
using System.Collections;

namespace Epoint.Modules.AR
{
    public partial class frmPJPConfig_Edit : Epoint.Lists.frmEdit
    {

        #region Khai báo
        //private string Ma_CtKM_Old = string.Empty;

        #endregion

        #region Phuong thuc

        public frmPJPConfig_Edit()
		{
			InitializeComponent();

            this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}
		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
        {
            if (Element.Is_Running)
            {
                this.drEdit = drEdit;
                this.enuNew_Edit = enuNew_Edit;
                this.Tag = (char)enuNew_Edit + "," + this.Tag;
                
                this.BindingCombobox();
                Common.ScaterMemvar(this, ref drEdit);

                BindingLanguage();
                LoadDicName();

                if (this.enuNew_Edit == enuEdit.Edit)
                {
                    txtMa_PJP.Enabled = false;
                }
                this.ShowDialog();
            }
		}

		private void LoadDicName()
		{

		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_PJP.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ma_PJP") + " " +
                        Languages.GetLanguage("Not_Null"));
                return false;
            }

            if (txtTen_PJP.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ten_PJP") + " " +
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



            //Luu xuong CSDL
            if (!DataTool.SQLUpdate(enuNew_Edit, "OM_PJP", ref drEdit))
                return false;

            return true;
        }	
        private void BindingCombobox()
        {
        }
        #endregion

        #region Su kien
       
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
		
        #endregion 
	}
}