using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Elements;
using System.Data.OleDb;
using System.Reflection;

namespace Epoint.Modules.GL
{
    public partial class frmDuDauGL_View : Epoint.Modules.frmOpening_View
    {
        #region Fields

        private DataTable dtDuDauGL;
        private DataRow drCurrent;
        private BindingSource bdsDuDauGL = new BindingSource();
        private dgvControl dgvDuDauGL = new dgvControl();

        #endregion

        #region Methods

        public frmDuDauGL_View()
        {
            InitializeComponent();

        }

        public override void Load()
        {
            this.Build();
            this.FillData();
            this.BindingLanguage();

            this.Show();
        }

        private void Build()
        {
            this.dgvDuDauGL.strZone = "GLDUDAU_VIEW";
            this.dgvDuDauGL.Dock = DockStyle.Fill;

            this.Controls.Add(dgvDuDauGL);

            this.dgvDuDauGL.BuildGridView();
        }

        public void FillData()
        {
            string[] strArrName = { "Tk", "Nam", "Child", "Ma_DvCs" };
            object[] objArrValue = { "", Element.sysWorkingYear, false, Element.sysMa_DvCs };

            dtDuDauGL = SQLExec.ExecuteReturnDt("Sp_GetDuDauGL", strArrName, objArrValue, CommandType.StoredProcedure);
            dtDuDauGL.Columns.Add("Bold", typeof(bool), "Have_Child");

            bdsDuDauGL.DataSource = dtDuDauGL;
            bdsDuDauGL.Position = 0;
            //bdsDuDauGL.Filter = "TRIM(Ma_Dt) = '' AND TRIM(Ma_Sp) = ''";

            dgvDuDauGL.DataSource = bdsDuDauGL;

            this.ExportControl = dgvDuDauGL;
            this.bdsSearch = bdsDuDauGL;
        }

        public override void EnterProcess()
        {
            Detail();
        }

        private void Detail()
        {
            drCurrent = ((DataRowView)bdsDuDauGL.Current).Row;

            if (!(bool)drCurrent["Have_Child"])
                return;

            frmDuDauGLCt_View frmDetail = new frmDuDauGLCt_View();
            frmDetail.Load((string)drCurrent["Tk"]);

            this.UpdateTotal(drCurrent);
        }

        private void UpdateTotal(DataRow dr)
        {
            string strTk = ((string)dr["Tk"]).Trim();

            string[] strArrName = { "Tk", "Nam", "Child", "Ma_DvCs" };
            object[] objArrValue = { strTk, Element.sysWorkingYear, true, Element.sysMa_DvCs };

            DataTable dtTotal = SQLExec.ExecuteReturnDt("Sp_GetDuDauGL", strArrName, objArrValue, CommandType.StoredProcedure);

            dr["Du_No"] = Common.SumDCValue(dtTotal, "Du_No", "");
            dr["Du_Co"] = Common.SumDCValue(dtTotal, "Du_Co", "");
            dr["Du_No_Nt"] = Common.SumDCValue(dtTotal, "Du_No_Nt", "");
            dr["Du_Co_Nt"] = Common.SumDCValue(dtTotal, "Du_Co_Nt", "");
            dr["Du_No0"] = Common.SumDCValue(dtTotal, "Du_No0", "");
            dr["Du_Co0"] = Common.SumDCValue(dtTotal, "Du_Co0", "");
            dr["Du_No_Nt0"] = Common.SumDCValue(dtTotal, "Du_No_Nt0", "");
            dr["Du_Co_Nt0"] = Common.SumDCValue(dtTotal, "Du_Co_Nt0", "");
        }

//        public virtual void Import_Excel()
//        {
//            string strTableName = "GLDUDAU";

//            int iSttIdent = (Int32)SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Ident00),1) FROM " + strTableName);
//            OpenFileDialog ofdlg = new OpenFileDialog();

//            ofdlg.DefaultExt = "xls";
//            ofdlg.Filter = "*.xls|*.xls";

//            if (ofdlg.ShowDialog() != DialogResult.OK)
//                return;

//            string probeConnStr = @"Provider=Microsoft.Jet.OLEDB.4.0;
//						Data Source= " + ofdlg.FileName + ";" +
//                        "Extended Properties=\"Excel 8.0;HDR=YES\"";

//            using (OleDbConnection probeConn = new OleDbConnection(probeConnStr))
//            {
//                probeConn.Open();
//                string probe = "SELECT * FROM [Sheet1$] " + //Sheet1$A1:A65536
//                                "Where Nam IS NOT NULL AND TK IS NOT NULL";

//                using (OleDbDataAdapter oleDbDapter = new OleDbDataAdapter(probe, probeConn))
//                {
//                    DataTable tbExcel = new DataTable();
//                    oleDbDapter.Fill(tbExcel);

//                    DataTable dtStruct = DataTool.SQLGetDataTable(strTableName, "TOP 0 * ", " 0 = 1", null);
//                    DataTable dtStruct2 = dtStruct.Clone();
//                    DataRow drNewRow = dtStruct.NewRow();
//                    dtStruct.Rows.Add(drNewRow);

//                    foreach (DataColumn dc in dtStruct2.Columns)
//                        if (dc.DataType.ToString() == "System.Byte[]")
//                        {
//                            dtStruct.Columns.Remove(dc.ColumnName);
//                            dtStruct.AcceptChanges();
//                        }


//                    //if (drNewRow.Table.Columns.Contains("Hinh"))
//                    //{
//                    //    drNewRow.Table.Columns.Remove("Hinh");
//                    //    drNewRow.Table.AcceptChanges();
//                    //}

//                    Common.SetDefaultDataRow(ref drNewRow);

//                    string strMsg = (Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn có muốn ghi đè lên dữ liệu đã tồn tại không" : "Do you want to override exists data");
//                    bool bIs_Overide = Common.MsgYes_No(strMsg);

//                    foreach (DataRow drExcel in tbExcel.Rows)
//                    {
//                        Common.CopyDataRow(drExcel, drNewRow);
//                        string strStt = iSttIdent.ToString().Trim().PadLeft(10, '0');
//                        drNewRow["Stt"] = Element.sysMa_DvCs + "80" + strStt;
//                        drNewRow.AcceptChanges();

//                        //if (bIs_Overide && DataTool.SQLCheckExist(strTableName, "Stt", (string)drExcel["Stt"]))
//                        //    DataTool.SQLUpdate(enuEdit.Edit, strTableName, ref drNewRow);
//                        //else
//                        DataTool.SQLUpdate(enuEdit.New, strTableName, ref drNewRow);
//                        iSttIdent++;
//                    }
//                }
//            }

//            //Type type = this.GetType();
//            //type.InvokeMember("FillData", BindingFlags.InvokeMethod, null, this, null);
//            FillData();
//            Common.MsgOk(Languages.GetLanguage("End_Process"));
//        }


        private void Import_Excel()
        {

            string strTableName = "GLDUDAU";

            OpenFileDialog dialog = new OpenFileDialog
            {
                DefaultExt = "xls",
                Filter = "*.xls|*.xls"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;\r\n\t\t\t\t\t\tData Source= " + dialog.FileName + ";Extended Properties=\"Excel 8.0;HDR=YES\"";
                int num = 0;
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string selectCommandText = "SELECT * FROM [Sheet1$] Where Nam IS NOT NULL AND Tk IS NOT NULL ";
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommandText, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        DataTable table2 = DataTool.SQLGetDataTable(strTableName, "TOP 0 * ", " 0 = 1", null);
                        DataTable table3 = table2.Clone();
                        DataRow row = table2.NewRow();
                        table2.Rows.Add(row);
                        Common.SetDefaultDataRow(ref row);
                        bool flag = false;
                        bool flag2 = false;
                        foreach (DataRow row2 in dataTable.Rows)
                        {
                            //Common.SetDefaultDataRow(ref row2);
                            Common.CopyDataRow(row2, row);
                            Common.SetDefaultDataRow(ref row);
                            row.AcceptChanges();
                            row["Stt"] = Common.GetNewStt("08", true);
                            while (DataTool.SQLCheckExist(strTableName, "Stt", row["Stt"]))
                            {
                                row["Stt"] = Common.GetNewStt("08", true);
                            }
                            if (DataTool.SQLCheckExist(strTableName, new string[] { "Ma_DvCs", "Nam", "Tk", "Ma_Dt", "Ma_Sp" }, new object[] { Element.sysMa_DvCs, row["Nam"], row["Tk"], row["Ma_Dt"], row["Ma_Sp"] }))
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
                                        DataRow row3 = SQLExec.ExecuteReturnDt("SELECT * FROM " + strTableName + " WHERE Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Nam = '" + row["Nam"].ToString() + "' AND Tk = '" + row["Tk"].ToString() + "' AND Ma_Dt = '" + row["Ma_Dt"].ToString() + "' AND Ma_Sp = '" + row["Ma_Sp"].ToString() + "'").Rows[0];
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
                SQLExec.Execute("update GLDUDAU set Ma_Dt = RTRIM(LTRIM(Ma_Dt)) , tk = RTRIM(LTRIM(tk))");
                this.FillData();
                Common.MsgOk(Languages.GetLanguage("End_Process") + " " + num.ToString() + " dòng được cập nhật !");
            }
        }


        #endregion

        #region Update

        public override void Edit(enuEdit enuNew_Edit)
        {
            if (bdsDuDauGL.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai            
            if (bdsDuDauGL.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsDuDauGL.Current).Row, ref drCurrent);
            else
                drCurrent = dtDuDauGL.NewRow();

            //Neu co chi tiet thi vao chi tiet
            if (enuNew_Edit == enuEdit.Edit && ((bool)drCurrent["Have_Child"]))
            {
                this.Detail();
                return;
            }

            //Kiểm tra khóa số dư
            if (enuNew_Edit == enuEdit.New)
            {
                string strSQLExec =
                    "SELECT TOP 1 Locked_Sdk FROM SYSNAM " +
                        " WHERE Nam = " + Element.sysWorkingYear + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";

                if ((bool)SQLExec.ExecuteReturnValue(strSQLExec))
                {
                    Common.MsgCancel("Số dư đầu đã khóa!");
                    return;
                }
            }

            frmDuDauGL_Edit frmEdit = new frmDuDauGL_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            //Accept
            if (frmEdit.isAccept)
            {
                //Kiem tra Tk_Dt, Tk_Sp
                if ((bool)drCurrent["Tk_Dt"] || (bool)drCurrent["Tk_Sp"])
                {
                    drCurrent["Ma_Dt"] = string.Empty;
                    drCurrent["Ma_Sp"] = string.Empty;
                    drCurrent["Have_Child"] = 1;

                    //Neu da ton tai Tk roi thi khong can them vao nua
                    int iCurrent = bdsDuDauGL.Find("Tk", (string)drCurrent["Tk"]);

                    if (iCurrent >= 0)
                    {
                        dtDuDauGL.RejectChanges();

                        bdsDuDauGL.Position = iCurrent;
                        drCurrent = ((DataRowView)bdsDuDauGL.Current).Row;

                        this.UpdateTotal(drCurrent);

                        return;
                    }

                    this.UpdateTotal(drCurrent);
                }

                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsDuDauGL.Position >= 0)
                        dtDuDauGL.ImportRow(drCurrent);
                    else
                        dtDuDauGL.Rows.Add(drCurrent);

                    bdsDuDauGL.Position = bdsDuDauGL.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsDuDauGL.Current).Row);

                dtDuDauGL.AcceptChanges();

            }
            //else
            //    dtDuDauGL.RejectChanges();
        }

        public override void Delete()
        {
            if (bdsDuDauGL.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsDuDauGL.Current).Row;

            //Neu co chi tiet thi vao chi tiet
            if ((bool)drCurrent["Have_Child"])
            {
                this.Detail();
                return;
            }

            //Kiểm tra khóa số dư
            string strSQLExec =
                "SELECT TOP 1 Locked_Sdk FROM SYSNAM " +
                    " WHERE Nam = " + Element.sysWorkingYear + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";

            if ((bool)SQLExec.ExecuteReturnValue(strSQLExec))
            {
                Common.MsgCancel("Số dư đầu đã khóa!");
                return;
            }

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("GLDUDAU", drCurrent))
            {
                bdsDuDauGL.RemoveAt(bdsDuDauGL.Position);
                dtDuDauGL.AcceptChanges();
            }
        }

        #endregion

        #region Events
        protected override void OnKeyDown(KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F10 && Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New) && Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit))
                Import_Excel();
            else
            {
                base.OnKeyDown(e);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            double dbTDu_No = Common.SumDCValue(dtDuDauGL, "Du_No", "");
            double dbTDu_Co = Common.SumDCValue(dtDuDauGL, "Du_Co", "");

            if (dbTDu_No - dbTDu_Co != 0)
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Số dư đầu không cân\n Tổng(Dư nợ - Dư có):\n" : "Opening balance error\n Amount(Debit - Credit):\n";
                strMsg += dbTDu_No.ToString("N") + " - " + dbTDu_Co.ToString("N") + " = " + (dbTDu_No - dbTDu_Co).ToString("N");
                Common.MsgOk(strMsg);
            }
            base.OnClosed(e);
        }
        #endregion
    }
}
