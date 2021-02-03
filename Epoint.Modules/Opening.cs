using System;
using System.Collections.Generic;
using System.Text;
using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;

namespace Epoint.Modules
{
    public class Opening
    {
        public static bool UpdateDuDauGL(frmOpening_Edit frmEdit)
        {
            if ((string)frmEdit.drEdit["Stt"] == string.Empty)
                return false;

            if (!DataTool.SQLUpdate(frmEdit.enuNew_Edit, "GLDUDAU", ref frmEdit.drEdit))
                return false;

            //Luu vao Queue
            bool bSaveQueue = false;
            if (bSaveQueue)
            {
                string strStt = (string)frmEdit.drEdit["Stt"];
                string strSpExec = "SP_CDK_UPDATE_SOCAI '" + strStt + "'";

                if (frmEdit.enuNew_Edit == enuEdit.Edit)
                {
                    SQLExec.Execute("DELETE FROM SYSQUEUE WHERE Stt = '" + strStt + "'");
                }

                Common.SQLPushQueue(SQLExec.GetSQLCommand(), strSpExec, strStt);
            }

            return true;
        }

        public static bool UpdateDuDauIN(frmOpening_Edit frmEdit)
        {
            if ((string)frmEdit.drEdit["Stt"] == string.Empty)
                return false;

            if (!DataTool.SQLUpdate(frmEdit.enuNew_Edit, "INDUDAU", ref frmEdit.drEdit))
                return false;

            //Luu vao Queue
            bool bSaveQueue = false;
            if (bSaveQueue)
            {
                string strStt = (string)frmEdit.drEdit["Stt"];
                string strSpExec = "SP_CDV_UPDATE_THEKHO '" + strStt + "'";

                if (frmEdit.enuNew_Edit == enuEdit.Edit)
                {
                    SQLExec.Execute("DELETE FROM SYSQUEUE WHERE Stt = '" + strStt + "'");
                }

                Common.SQLPushQueue(SQLExec.GetSQLCommand(), strSpExec, strStt);
            }

            return true;
        }

        public static bool UpdateDuDauIN(frmOpening_Edit frmEdit, string TableName)
        {
            if ((string)frmEdit.drEdit["Stt"] == string.Empty)
                return false;

            if (!DataTool.SQLUpdate(frmEdit.enuNew_Edit, TableName, ref frmEdit.drEdit))
                return false;

            //Luu vao Queue
            bool bSaveQueue = false;
            if (bSaveQueue)
            {
                string strStt = (string)frmEdit.drEdit["Stt"];
                string strSpExec = "SP_CDV_UPDATE_THEKHO '" + strStt + "'";

                if (frmEdit.enuNew_Edit == enuEdit.Edit)
                {
                    SQLExec.Execute("DELETE FROM SYSQUEUE WHERE Stt = '" + strStt + "'");
                }

                Common.SQLPushQueue(SQLExec.GetSQLCommand(), strSpExec, strStt);
            }

            return true;
        }


        public static void Import_Excel(string strTableName)
        {


            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "xls files (*.xls;*.xlsx)|*.xls;*.xlsx";
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                String strConnectString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                     "Data Source=" + dialog.FileName + ";Extended Properties=Excel 8.0;";

                int num = 0;
                using (OleDbConnection connection = new OleDbConnection(strConnectString))
                {
                    connection.Open();

                    string selectCommandText = "SELECT * FROM [Sheet1$] Where Ma_Vt IS NOT NULL ";

                    using (OleDbDataAdapter oleDbDapter = new OleDbDataAdapter(selectCommandText, connection))
                    {
                        DataTable dataTable = new DataTable();
                        oleDbDapter.Fill(dataTable);
                        DataTable table2 = DataTool.SQLGetDataTable(strTableName, "TOP 0 * ", " 0 = 1", null);
                        DataTable table3 = table2.Clone();
                        DataRow row = table2.NewRow();
                        table2.Rows.Add(row);
                        Common.SetDefaultDataRow(ref row);
                        bool flag = false;
                        bool flag2 = false;
                        foreach (DataRow row2 in dataTable.Rows)
                        {
                            Common.CopyDataRow(row2, row);
                            row.AcceptChanges();
                            row["Stt"] = Common.GetNewStt("08", true);
                            if (DataTool.SQLCheckExist(strTableName, new string[] { "Ma_DvCs", "Ma_Kho", "Ma_Vt" }, new object[] { Element.sysMa_DvCs, row["Ma_Kho"], row["Ma_Vt"] }))
                            {
                                if (!flag)
                                {
                                    string strMsg = (Element.sysLanguage == enuLanguageType.Vietnamese) ? "Bạn có ghi đè dữ liệu đã tồn tại ?" : "Do you want to override exists data ?";
                                    flag2 = Common.MsgYes_No(strMsg);
                                    flag = true;
                                }
                                if (flag2)
                                {
                                    if (row.Table.Columns.Contains("Ident00"))
                                    {
                                        DataRow row3 = SQLExec.ExecuteReturnDt("SELECT * FROM " + strTableName + " WHERE Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Ma_Kho = '" + row["Ma_Kho"].ToString() + "' AND Ma_Vt = '" + row["Ma_Vt"].ToString() + "'").Rows[0];
                                        if (row != null)
                                        {
                                            row["Ident00"] = row3["Ident00"];
                                        }
                                    }
                                    DataTool.SQLUpdate(enuEdit.Edit, strTableName, ref row);
                                    num++;
                                }
                            }
                            else
                            {
                                DataTool.SQLUpdate(enuEdit.New, strTableName, ref row);
                                num++;
                            }
                        }
                    }
                }

                SQLExec.Execute("update " + strTableName + " set Ma_Kho = RTRIM(LTRIM(Ma_Kho)) , Ma_Vt = RTRIM(LTRIM(Ma_Vt))");


                Common.MsgOk(Languages.GetLanguage("End_Process") + " " + num.ToString() + " dòng được cập nhật");
            }

        }
    }
}
