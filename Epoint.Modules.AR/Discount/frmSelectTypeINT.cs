using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;

namespace Epoint.Modules.AR
{
	public partial class frmSelectTypeINT : Epoint.Systems.Customizes.frmEdit
	{
		#region Declare
		bool Is_CtSo = false;
		#endregion

		#region Contructor
        public frmSelectTypeINT()
		{
			InitializeComponent();

			this.tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
			this.btSave.Click += new EventHandler(btSave_Click);
			
		}
		#endregion

		#region Phuong thuc
		public void Load(DataRow drEdit)
		{
			this.drEdit = drEdit;
			Common.ScaterMemvar(this, ref drEdit);
			btSave.Enabled = false;

			this.ShowDialog();
		}

		public void Load(DataRow drEdit, bool Is_CTSO)
		{
			this.drEdit = drEdit;
			Common.ScaterMemvar(this, ref drEdit);
			btSave.Enabled = false;
			Is_CtSo = Is_CTSO;
			this.ShowDialog();
		}

		private bool FormCheckValid()
		{
			return true;
		}

		private bool Save()
		{
			string strSQLExec = string.Empty;			
			drEdit.AcceptChanges();

			return true;
		}
		#endregion

		#region Event
		
		void chkDuyet_CheckedChanged(object sender, EventArgs e)
		{
			this.txtDuyet_Log.Text = Common.GetCurrent_Log();
			btSave.Enabled = true;
		}

		void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Common.ScaterMemvar(this, ref drEdit);

			btSave.Enabled = false;
		}

		void btSave_Click(object sender, EventArgs e)
		{
			if (this.FormCheckValid())
			{
				this.Save();
				this.Close();
			}
		}

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (!Element.sysIs_Admin)
			{
				string strLoai_Duyet = string.Empty;

				switch (drEdit["Ma_Ct"].ToString().Trim())
				{
					case "SO":
						strLoai_Duyet = "DUYET_CT_SO";
						break;
					case "PO":
						strLoai_Duyet = "DUYET_CT_PO";
						break;
					case "BG":
						strLoai_Duyet = "DUYET_CT_BG";
						break;
					case "NM":
						strLoai_Duyet = "DUYET_CT_NM";
						break;
					case "HD":
						strLoai_Duyet = "DUYET_CT_HD";
						break;
					case "CAST":
						strLoai_Duyet = "DUYET_CT_CAST";
						break;
					case "NX":
						strLoai_Duyet = "DUYET_CT_NX";
						break;
				}

				//strLoai_Duyet = (string)SQLExec.ExecuteReturnValue("SELECT Phan_Quyen_Duyet FROM R00DMCT WHERE Ma_Ct = '" + drEdit["Ma_Ct"].ToString().Trim() + "'");

				if ((strLoai_Duyet == "") || Common.CheckPermission(strLoai_Duyet, Epoint.Systems.enuPermission_Type.Allow_Access) == false)
				{	
					btSave.Enabled = false;
				}
			}
		}

		
	}
}
