using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;

namespace Epoint.Modules.AS
{
	public partial class frmDmTg_Edit : Epoint.Systems.Customizes.frmEdit
	{

        #region Phuong thuc

		public frmDmTg_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;

			this.enuNew_Edit = enuNew_Edit;
            this.Text = enuNew_Edit == enuEdit.New ? "Them moi tang giam" : "Sua tang giam";

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
		}

		private bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_Tg.Text.Trim() == string.Empty)
            {
				Common.MsgCancel(Languages.GetLanguage("Ma_Tg") + " " +
							  Languages.GetLanguage("Not_Null"));
				
				return false;
            }			

			if (txtTen_Tg.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ten_Tg") + " " +
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "ASTG", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_TG", drEdit);

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

        #endregion 
	}
}