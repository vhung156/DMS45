using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Lists;

namespace Epoint.Modules.POS
{
	public partial class frmCa_Edit : Epoint.Systems.Customizes.frmEdit
	{
		#region Methods
		public frmCa_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{

		}

		private bool CheckFormValid()
		{
			if (this.txtMa_Ca.Text == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Ca") + " " + Languages.GetLanguage("Not_Empty"));
				return false;
			}

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			if (!this.CheckFormValid())
				return false;

			if (!DataTool.SQLUpdate(enuNew_Edit, "LICA", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_CA", drEdit);

			return true;
		}

		#endregion

		#region Events

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
			this.Close();
		}

		#endregion
	}
}
