using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Commons;

namespace Epoint.Modules
{
	public partial class frmIn_CT_Tien_NT : Epoint.Systems.Customizes.frmEdit
	{
		public frmIn_CT_Tien_NT()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		new public void Load(DataRow drViewPh)
		{
			Common.ScaterMemvar(this, ref drViewPh);
			BindingLanguage();

			ShowDialog();
		}

		private void btAccept_Click(object sender, EventArgs e)
		{
			isAccept = true;
			this.Close();
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}
	}
}
