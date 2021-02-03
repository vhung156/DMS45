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
using Epoint.Systems.Elements;
using System.Data.OleDb;
using System.Collections;

namespace Epoint.Modules.GL
{
	public partial class frmDuDauHanTt_View : Epoint.Systems.Customizes.frmView
	{
		#region Khai bao bien

        private string strTableName = "GLDUDAUHANTT";
		private DataTable dtSdHtt;
		private DataRow drCurrent;
		private BindingSource bdsSdHtt = new BindingSource();
		private dgvControl dgvSdHtt = new dgvControl();
		public bool bLookupByGroup = false;
        private string Tk_List = string.Empty;
		#endregion 

		#region Contructor
		public frmDuDauHanTt_View()
		{
			InitializeComponent();
		}
			
		public override void Load()
		{
			Build();
			FillData();
			BindingLanguage();
            this.Tk_List = Parameters.GetParaValue("TK_CONGNO_LIST").ToString();
			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}
		
		#endregion

		#region Build, FillData
		private void Build()
		{
			dgvSdHtt.Dock = DockStyle.Fill;
            dgvSdHtt.strZone = "GLDUDAUHANTT_VIEW";

			dgvSdHtt.BuildGridView(this.isLookup);

			this.Controls.Add(dgvSdHtt);
			this.ExportControl = dgvSdHtt;
		}

		private void FillData()	
		{
			//dtSdHtt = SQLExec.ExecuteReturnDt("sp_GetCDHanTt '" + Element.sysMa_DvCs + "'");
            dtSdHtt = DataTool.SQLGetDataTable("GLDUDAUHANTT", "", "Nam = " + Element.sysWorkingYear.ToString() + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'", "Tk, Ma_Dt, Stt, Ngay_Ct, Ma_Ct, So_Ct");
            //dtSdHtt = DataTool.SQLGetDataTable("GLDUDAUHANTT", null, null, null);

			bdsSdHtt.DataSource = dtSdHtt;
			dgvSdHtt.DataSource = bdsSdHtt;

			if (bdsSdHtt.Count >= 0)
				bdsSdHtt.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsSdHtt;
		}

		#endregion 

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsSdHtt.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsSdHtt.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsSdHtt.Current).Row, ref drCurrent);
			else
				drCurrent = dtSdHtt.NewRow();

			//Kiểm tra khóa số dư
			if (enuNew_Edit == enuEdit.New)
			{
				string strSQLExec =
					"SELECT TOP 1 Locked_SdHanTt FROM SYSNAM " +
						" WHERE Nam = " + Element.sysWorkingYear + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";

				if ((bool)SQLExec.ExecuteReturnValue(strSQLExec))
				{
					Common.MsgCancel("Số dư đầu đã khóa!");
					return;
				}
			}

			frmDuDauHanTt_Edit frmEdit = new frmDuDauHanTt_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsSdHtt.Position >= 0)
						dtSdHtt.ImportRow(drCurrent);
					else
						dtSdHtt.Rows.Add(drCurrent);

					bdsSdHtt.Position = bdsSdHtt.Find("Ident00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsSdHtt.Current).Row);
				}

				dtSdHtt.AcceptChanges();
			}
			//else
			//    dtCdHtt.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsSdHtt.Position < 0)
				return;

			//Kiểm tra khóa số dư
			string strSQLExec0 =
				"SELECT TOP 1 Locked_SdHanTt FROM SYSNAM " +
					" WHERE Nam = " + Element.sysWorkingYear + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";

			if ((bool)SQLExec.ExecuteReturnValue(strSQLExec0))
			{
				Common.MsgCancel("Số dư đầu đã khóa!");
				return;
			}

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			drCurrent = ((DataRowView)bdsSdHtt.Current).Row;
			string strStt = (string)drCurrent["Stt"];

			string strSQLExec = string.Empty;

			//if((bool)drCurrent["Is_UngTruoc"])
			//    strSQLExec = "DELETE FROM R80UNGTRUOC WHERE Stt = '" + strStt + "' ;" +
			//                   "DELETE FROM R80HANTT0 WHERE Stt = '" + strStt + "'";				 
			//else
			//    strSQLExec = "DELETE FROM R80HANTT WHERE Stt = '" + strStt + "' ;" +
			//                    "DELETE FROM R80HANTT0 WHERE Stt_Hd = '" + strStt + "'";

			strSQLExec = "DELETE FROM GLDUDAUHANTT WHERE Stt = '" + strStt + "'";

			if (SQLExec.Execute(strSQLExec))
			{
                if (Common.InlistLike(drCurrent["TK"].ToString(), this.Tk_List))
                {
                    Hashtable htPara = new Hashtable();
                    htPara["MA_DVCS"] = Element.sysMa_DvCs;
                    htPara["STT"] = strStt;
                    htPara["IS_UPDATE"] = "D";
                    SQLExec.Execute("sp_UpdateSdHantt", htPara, CommandType.StoredProcedure);

                }


				bdsSdHtt.RemoveAt(bdsSdHtt.Position);
				dtSdHtt.AcceptChanges();


			}
		}

		#endregion 
	

        
        public void Import_Excel()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                DefaultExt = "xls",
                Filter = "*.xls|*.xls"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;\r\n\t\t\t\t\t\tData Source= " + dialog.FileName + ";Extended Properties=\"Excel 8.0;HDR=YES\""))
                {
                    connection.Open();
                    string selectCommandText = "SELECT * FROM [Sheet1$] Where Ma_Dt IS NOT NULL AND Tk IS NOT NULL AND Ma_Ct IS NOT NULL";
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommandText, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        DataTable tableStruct = DataTool.SQLGetDataTable("GLDUDAUHANTT", "TOP 0 * ", " 0 = 1", null);
                        DataTable table3 = tableStruct.Clone();
                        DataRow row = tableStruct.NewRow();
                        tableStruct.Rows.Add(row);
                        foreach (DataColumn column in table3.Columns)
                        {
                            if (column.DataType.ToString() == "System.Byte[]")
                            {
                                tableStruct.Columns.Remove(column.ColumnName);
                                tableStruct.AcceptChanges();
                            }
                        }
                        Common.SetDefaultDataRow(ref row);
                        foreach (DataRow row2 in dataTable.Rows)
                        {
                            Common.CopyDataRow(row2, row);
                            row.AcceptChanges();
                            row["Stt"] = Common.GetNewStt("08", true);
                            while (DataTool.SQLCheckExist("GLDUDAUHANTT", "Stt", row["Stt"]))
                            {
                                row["Stt"] = Common.GetNewStt("08", true);
                            }
                            DataTool.SQLUpdate(enuEdit.New, "GLDUDAUHANTT", ref row);
                        }
                    }
                    this.FillData();
                    Common.MsgOk(Languages.GetLanguage("End_Process"));
                    connection.Close();
                }
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F10 && Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New) && Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit))
                Import_Excel(true);
            else
            {
                base.OnKeyDown(e);
            }
        }

        public virtual void Import_Excel(bool CheckAPI)
        {
            OpenFileDialog ofdlg = new OpenFileDialog();
            ofdlg.Filter = "xls files (*.xls;*.xlsx)|*.xls;*.xlsx";
            ofdlg.RestoreDirectory = true;


            if (ofdlg.ShowDialog() != DialogResult.OK)
                return;

            DataTable dtImport = Common.ReadExcel(ofdlg.FileName);
            string strMsg = (Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn có muốn ghi đè lên mẫu tin đã tồn tại không ?" : "Do you want to override exists data ?");
            bool bIs_Overide = Common.MsgYes_No(strMsg);
            SaveData(dtImport, bIs_Overide);

        }
        private void SaveData(DataTable tbExcel, bool bIs_Overide)
        {
            try
            {
                DataTable table2 = DataTool.SQLGetDataTable("GLDUDAUHANTT", "TOP 0 * ", " 0 = 1", null);
                DataTable table3 = table2.Clone();
                DataRow row = table2.NewRow();
                table2.Rows.Add(row);
                foreach (DataColumn column in table3.Columns)
                {
                    if (column.DataType.ToString() == "System.Byte[]")
                    {
                        table2.Columns.Remove(column.ColumnName);
                        table2.AcceptChanges();
                    }
                }
                Common.SetDefaultDataRow(ref row);
                foreach (DataRow row2 in tbExcel.Rows)
                {
                    Common.CopyDataRow(row2, row);
                    row.AcceptChanges();
                    row["Stt"] = Common.GetNewStt("08", true);
                    while (DataTool.SQLCheckExist("GLDUDAUHANTT", "Stt", row["Stt"]))
                    {
                        row["Stt"] = Common.GetNewStt("08", true);
                    }
                    DataTool.SQLUpdate(enuEdit.New, "GLDUDAUHANTT", ref row);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi import code : " + ex.ToString());
            }
            }


    }	
}