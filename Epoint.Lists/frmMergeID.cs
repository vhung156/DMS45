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
using Epoint.Systems.Customizes;
using Epoint.Systems.Elements;

namespace Epoint.Lists
{
	public partial class frmMergeID : Epoint.Systems.Customizes.frmEdit
	{

		string strTableName = string.Empty ;
		string strColumn_Type = string.Empty;
		string strColumnName = string.Empty;
		string strOldValue = string.Empty;
		public string strNewValue = string.Empty;
		string strZone = string.Empty;

		public frmMergeID()
		{
			InitializeComponent();
			txtMa_Moi.Validating += new CancelEventHandler(txtMa_Moi_Validating);

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public void Load(string strTableName, string strColumn_Type, string strColumnName, string strOldValue, string strZone)
		{
			this.strTableName = strTableName;
			this.strColumn_Type = strColumn_Type;
			this.strColumnName= strColumnName;		
			this.strZone = strZone;

			txtMa_Cu.Text = strOldValue;            
			lbtTen_Ma_Cu.Text = DataTool.SQLGetNameByCode(strTableName, strColumn_Type, strColumnName, strOldValue);

			this.BindingLanguage();
			this.ShowDialog();
		}

		void txtMa_Moi_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Moi.Text.Trim();
			bool bRequire = true;

			if (DataTool.SQLCheckExist(strTableName, strColumn_Type, strValue))
			{
				lbtTen_Ma_Moi.Text = DataTool.SQLGetNameByCode(strTableName, strColumn_Type, strColumnName, strValue);
				return;
			}

			frmQuickLookup frm = new frmQuickLookup(strTableName, strZone);
			frm.Load();

			DataRow drLookup = frm.drLookup; 

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Moi.Text = string.Empty;
				lbtTen_Ma_Moi.Text = string.Empty;
			}
			else
			{
				txtMa_Moi.Text = ((string)drLookup[strColumn_Type]).Trim();
				lbtTen_Ma_Moi.Text = ((string)drLookup[strColumnName]).Trim();
			}            
        }

		private void btAccept_Click(object sender, EventArgs e)
		{
			strNewValue = txtMa_Moi.Text;

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
