using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems;
using Epoint.Systems.Elements;


namespace Epoint.Lists
{
	public partial class frmNghiepVu : Epoint.Lists.frmView
	{

		#region Khai bao bien
		DataTable dtNghiepVu;
		DataRow drCurrent;
		BindingSource bdsNghiepVu = new BindingSource();		
        dgvControl dgvNghiepVu = new dgvControl();

		#endregion

		#region Contructor

		public frmNghiepVu()
		{
			InitializeComponent();

			dgvNghiepVu.MouseDoubleClick += new MouseEventHandler(dgvNghiepVu_MouseDoubleClick);
            btExport.Click += new EventHandler(btExport_Click);
            btRefresh.Click += new EventHandler(btRefresh_Click);
		}
                
		public override void Load()
		{
            Init();
            Build();
			FillData();
			BindingLanguage();

			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}

		public override void LoadLookup()
		{
			this.Load();
		}
        private void Init()
        {
            htHistory["DIEN_GIAI"] = "Danh mục nghiệp vụ";
            strTableName = "LINGHIEPVU";
            strCode = "MA_NVU";
            strName = "TEN_NVU";
        }
		#endregion

		#region Build, FillData
		private void Build()
		{
            dgvNghiepVu.Dock = DockStyle.Fill;
            //this.Controls.Add(dgvNghiepVu);
            //this.Endable_Container();
            if (isLookup)
            {
                this.splitContainer.Panel2.Controls.Add(splControl1);
                this.splControl1.Panel1.Controls.Add(dgvNghiepVu);
            }
            else
            {
                this.splControl1.Panel1.Controls.Add(dgvNghiepVu);
            }

            dgvNghiepVu.strZone = "NghiepVu";
            dgvNghiepVu.BuildGridView(this.isLookup);

            ExportControl = dgvNghiepVu;
        }

		public void FillData()
		{            
            dtNghiepVu = DataTool.SQLGetDataTable("LINGHIEPVU", null, this.strLookupKeyFilter, null);
            bdsNghiepVu.DataSource = dtNghiepVu;

            //Uy quyen cho lop co so tim kiem           
            bdsSearch = bdsNghiepVu;
            ExportControl = dgvNghiepVu;

            dgvNghiepVu.DataSource = bdsNghiepVu;
            bdsNghiepVu.Position = 0;

            if (this.isLookup)
                this.MoveToLookupValue();
            
            dgvNghiepVu.Select();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtNghiepVu.Rows.Count - 1; i++)
				if (((string)dtNghiepVu.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsNghiepVu.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsNghiepVu.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsNghiepVu.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsNghiepVu.Current).Row, ref drCurrent);
			else
				drCurrent = dtNghiepVu.NewRow();

			frmNghiepVu_Edit frmEdit = new frmNghiepVu_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
                //Cập nhật History
                DataRow drHistory = drCurrent;
                htHistory["CODE"] = drHistory[strCode];
                htHistory["NAME"] = drHistory[strName];

                if (enuNew_Edit == enuEdit.New)
                {
                    htHistory["UPDATE_TYPE"] = "N";
                    UpdateHistory();
                }
                else if (enuNew_Edit == enuEdit.Edit && ((string)drHistory[strCode] != (string)((DataRowView)bdsNghiepVu.Current)[strCode] || (string)drHistory[strName] != (string)((DataRowView)bdsNghiepVu.Current)[strName]))
                {
                    htHistory["UPDATE_TYPE"] = "E";
                    htHistory["CODE_OLD"] = ((DataRowView)bdsNghiepVu.Current)[strCode];
                    htHistory["NAME_OLD"] = ((DataRowView)bdsNghiepVu.Current)[strName];
                    UpdateHistory();
                }
                //Cập nhật dữ liệu danh mục
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsNghiepVu.Position >= 0)
						dtNghiepVu.ImportRow(drCurrent);
					else
						dtNghiepVu.Rows.Add(drCurrent);

					bdsNghiepVu.Position = bdsNghiepVu.Find("MA_NVU", drCurrent["MA_NVU"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsNghiepVu.Current).Row);

				dtNghiepVu.AcceptChanges();
			}
            //else
            //    dtNghiepVu.RejectChanges();
		}

		public override void Delete()
		{           
            if (bdsNghiepVu.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsNghiepVu.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;
            
            if (DataTool.SQLCheckExist("vw_SoCai", strCode, drCurrent[strCode]))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
                    "Mã nghiệp vụ: {" + drCurrent[strName].ToString() + "}  đã được sử dụng trong chứng từ" :
                    "Transaction code: {" + drCurrent[strName].ToString() + "}  used in voucher";

                Common.MsgCancel(strMsg);
                return;
            }

            if (DataTool.SQLDelete("LINGHIEPVU", drCurrent))
            {
                ////Sync Delete----------
                //string Is_Sync = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM SYSPARAMETER WHERE Parameter_ID = 'SYNC_BEGIN'"));
                //if (Is_Sync == "1")
                //{
                //    SqlConnection sqlCon = SQLExecSync1.GetNewSQLConnectionSync1();
                //    if (sqlCon.State != ConnectionState.Open)
                //    {
                //        SQLExec.Execute("UPDATE SYSPARAMETER SET Parameter_Value = 0 WHERE Parameter_ID = 'SYNC_BEGIN'");
                //        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Quá trình đồng bộ đang bị gián đoạn. Vui lòng chờ trong ít phút !" : "The synchronization process is interrupted. Please wait a few minutes !";
                //        Common.MsgCancel(strMsg);
                //    }
                //    else
                //    {
                //        DataToolSync1.SQLDelete("LINGHIEPVU", drCurrent);
                //    }
                //}
                ////-----------------------

                //Cập nhật History
                htHistory["CODE"] = drCurrent[strCode];
                htHistory["NAME"] = drCurrent[strName];
                htHistory["UPDATE_TYPE"] = "D";
                UpdateHistory();
                
                bdsNghiepVu.RemoveAt(bdsNghiepVu.Position);
                dtNghiepVu.AcceptChanges();
            }
		}

		public override void MergeID()
		{
			if (bdsNghiepVu.Count <= 0)
				return;

			drCurrent = ((DataRowView)bdsNghiepVu.Current).Row;
			string strOldValue = (string)drCurrent["Ma_Nvu"];

			frmMergeID frm = new frmMergeID();

			frm.Load("LINGHIEPVU", "Ma_NVu", "Ten_NVu", strOldValue, "NghiepVu");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Ma_NVu", "LINGHIEPVU", strOldValue, strNewValue))
				{
                    ////Sync data-------------
                    //string Is_Sync = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM SYSPARAMETER WHERE Parameter_ID = 'SYNC_BEGIN'"));
                    //if (Is_Sync == "1")
                    //{
                    //    SqlConnection sqlCon = SQLExecSync1.GetNewSQLConnectionSync1();
                    //    if (sqlCon.State != ConnectionState.Open)
                    //    {
                    //        SQLExec.Execute("UPDATE SYSPARAMETER SET Parameter_Value = 0 WHERE Parameter_ID = 'SYNC_BEGIN'");
                    //        string strMsg1 = Element.sysLanguage == enuLanguageType.Vietnamese ? "Quá trình đồng bộ đang bị gián đoạn. Vui lòng chờ trong ít phút !" : "The synchronization process is interrupted. Please wait a few minutes !";
                    //        Common.MsgCancel(strMsg1);
                    //    }
                    //    else
                    //    {
                    //        DataToolSync1.SQLMergeID("Ma_Nvu", "LINGHIEPVU", strOldValue, strNewValue);
                    //    }
                    //}
                    ////----------------------

                    //Cập nhật History
                    htHistory["CODE"] = drCurrent[strCode];
                    htHistory["NAME"] = drCurrent[strName];
                    htHistory["UPDATE_TYPE"] = "D";
                    UpdateHistory();

					bdsNghiepVu.RemoveCurrent();
					bdsNghiepVu.Position = bdsNghiepVu.Find("Ma_NVu", strNewValue);
				}
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsNghiepVu == null || bdsNghiepVu.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsNghiepVu.Current).Row;
			DataTable dtTemp = dtNghiepVu.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsNghiepVu.Position < 0)
				return;

            if (isLookup && EnterValid())
            {
                drLookup = ((DataRowView)bdsNghiepVu.Current).Row;
                this.Close();             
            }         
		}

		#endregion 

		#region Su kien
        void dgvNghiepVu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.isLookup)
                this.EnterProcess();
            else
                this.Edit(enuEdit.Edit);
        }

        void btExport_Click(object sender, EventArgs e)
        {
            dgvExport.bSortMode = false;
            dgvExport.strZone = "NghiepVu";
            dgvExport.BuildGridView();
            dgvExport.DataSource = bdsNghiepVu;

            string strTitle = ((Control)ExportControl).FindForm().Text;
            if (strTitle.Contains(","))
                strTitle = strTitle.Split(',')[0];

            ExportList(dgvExport, strTitle);
        }

        void btRefresh_Click(object sender, EventArgs e)
        {
            FillData();
        }

		#endregion 
	}
}