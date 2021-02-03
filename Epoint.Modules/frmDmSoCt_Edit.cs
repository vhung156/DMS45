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
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;

namespace Epoint.Modules
{
	public partial class frmDmSoCt_Edit : Epoint.Systems.Customizes.frmEdit
	{	

        #region Phuong thuc

		public frmDmSoCt_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}                	

		new public void Load(enuEdit enuNew_Edit, ref DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + ", " + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{ 
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			if (!FormCheckValid())
				return false;

			if (!DataTool.SQLUpdate(enuNew_Edit, "SYSDMSOCT", ref drEdit))
				return false;

			return true;
		}

		private bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_Ct.Text.Trim() == string.Empty)
            {
				EpointMessage.MsgOk(Languages.GetLanguage("Ma_Ct") + " " +
							  Languages.GetLanguage("Not_Null"));
                return false;
            }			
			
            return bvalid;
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


        #endregion

       
    }
}