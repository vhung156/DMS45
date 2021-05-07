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

namespace Epoint.Modules
{
	public partial class frmMemberSetup_Edit : Epoint.Systems.Customizes.frmEdit
	{
        #region Phuong thuc

		public frmMemberSetup_Edit()
		{
			InitializeComponent();

		  this.btMa_Kho_Access.Click += new EventHandler(btbtMa_Kho_Access_Click);
		  btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + ", " + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);
			BindingLanguage();
			this.ShowDialog();
		}		

		private bool FormCheckValid()
        {
            bool bvalid = true ;
           
            return bvalid;
        }

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Luu vao CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "SYSMEMBER", ref drEdit))
				return false;

			return true;
		}

	   #endregion

	   #region Su kien
	   void btbtMa_Kho_Access_Click(object sender, EventArgs e)
	   {
		  string strValue = txtMa_Kho_Access.Text.Trim();

		  string strMember_ID_Old = txtMa_Kho_Access.Text.Trim();

		  DataRow drLookup = Lookup.ShowMultiLookupNew("Ma_Kho", strValue, true, "Nh_Cuoi= 1 ","", "");
		  if (drLookup != null)
		  {
			 if (strMember_ID_Old != "")
				txtMa_Kho_Access.Text = strMember_ID_Old + "," + drLookup["MuiltiSelectValue"].ToString();
			 if (strMember_ID_Old == "")
				txtMa_Kho_Access.Text = strMember_ID_Old + drLookup["MuiltiSelectValue"].ToString();
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
			isAccept = false;
			this.Close();
		}

        #endregion 		
	}
}