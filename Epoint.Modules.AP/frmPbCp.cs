using System;
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
using Epoint.Systems.Customizes;
using Epoint.Modules;
using Epoint.Systems.Data;

namespace Epoint.Modules.AP
{
	public partial class frmPbCp : Epoint.Systems.Customizes.frmEdit
	{   
        frmVoucher_Edit frmEditCtNM;        

		public frmPbCp()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);			
		}

		public new void Load(frmVoucher_Edit frmEditCtNM)
		{
			this.frmEditCtNM = frmEditCtNM;			

			this.BindingLanguage();

			this.ShowDialog();
		}		
		void btAccept_Click(object sender, EventArgs e)
		{   
			isAccept = true;
			this.Close();
		}
		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}		
	}	 
}
