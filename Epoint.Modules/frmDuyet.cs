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

namespace Epoint.Modules
{
	public partial class frmDuyet : Epoint.Systems.Customizes.frmEdit
	{
		public frmDuyet()
		{
			InitializeComponent();

			this.tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);

			this.chkDuyet.CheckedChanged += new EventHandler(chkDuyet_CheckedChanged);

			this.btSave.Click += new EventHandler(btSave_Click);			
		}

		public void Load(DataRow drEdit)
		{
			this.drEdit = drEdit;

			Common.ScaterMemvar(this, ref drEdit);

            //chkDuyet.Enabled = !chkDuyet.Checked;

            //btSave.Enabled = false;

			this.ShowDialog();
		}

		private bool FormCheckValid()
		{
			if (dteNgay_Ct.IsNull)
			{
				Common.MsgCancel(Languages.GetLanguage("Ngay_Ct,Not_Null"));
				return false;
			}

			return true;
		}

		private bool Save()
		{
			string strSQLExec = string.Empty;
			Hashtable htPara;

			//Lưu phần Checked vào GLVOUCHER
			if (chkDuyet.Enabled)
			{
				htPara = new Hashtable();
				htPara.Add("DUYET", chkDuyet.Checked);
				htPara.Add("DUYET_LOG", txtDuyet_Log.Text);
                htPara.Add("MA_CBNV_GH", txtMa_CbNV_GH.Text);
				htPara.Add("STT", drEdit["Stt"]);

                strSQLExec = @"UPDATE GLVOUCHER SET Duyet = @Duyet, Duyet_Log = @Duyet_Log ,Ma_CbNV_Gh =  @Ma_CbNV_Gh 
                                WHERE Stt = @Stt ";

               

				if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
				{
					drEdit["Duyet"] = chkDuyet.Checked;
					drEdit["Duyet_Log"] = txtDuyet_Log.Text;
                    drEdit["MA_CBNV_GH"] = txtMa_CbNV_GH.Text;


                      strSQLExec = @" UPDATE ARBan SET Duyet = @Duyet,Ma_CbNV_Gh =  @Ma_CbNV_Gh 
                                WHERE Stt = @Stt ";

                      SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
				}


              
			}

			return true;
		}

		void chkDuyet_CheckedChanged(object sender, EventArgs e)
		{
			if (chkDuyet.Checked)
				this.txtDuyet_Log.Text = Common.GetCurrent_Log();
			else
				this.txtDuyet_Log.Text = string.Empty;

			this.btSave.Enabled = true;
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
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (!Element.sysIs_Admin)
			{
				if (!Common.CheckPermission("DUYET", Epoint.Systems.enuPermission_Type.Allow_Access))
					tabControl1.TabPages.Remove(tabPage3);
			}
		}
	}
}
