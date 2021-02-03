using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using System.Data.OleDb;
using System.Reflection;

namespace Epoint.Modules.AR
{
    public partial class frmGiaBan : Epoint.Systems.Customizes.frmView
    {
        DataTable dtGiaBan;
        BindingSource bdsGiaBan = new BindingSource();
        DataRow drCurrent;
        dgvGridControl dgvGiaBan = new dgvGridControl();

        public frmGiaBan()
        {
            InitializeComponent();

            this.txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
            this.txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);


            this.txtMa_Vt.TextChanged += new EventHandler(txtMa_Vt_TextChanged);
            this.txtMa_Dt.TextChanged += new EventHandler(txtMa_Dt_TextChanged);
        }

        public override void Load()
        {
            this.Build();
            this.FillData();

            this.Show();
        }

        private void Build()
        {
            dgvGiaBan.Dock = DockStyle.Fill;
            dgvGiaBan.strZone = "GiaBan";
            dgvGiaBan.BuildGridView();
            this.pnlGiaban.Controls.Add(dgvGiaBan);
            //this.Controls.Add(dgvGiaBan);
        }

        private void FillData()
        {
            string strSQLExec = @"SELECT GiaBan.*, DmVt.Ten_Vt, DmDt.Ten_Dt,DmDt.Dia_Chi ,DmDt.MA_CBNV_BH ,Ten_CbNv = ISNULL( nv.Ten_CbNv,'') 
                                    FROM ARGIABAN GiaBan " +
                                @" LEFT JOIN LIVATTU DmVt ON GiaBan.Ma_Vt = DmVt.Ma_Vt " +
                                @" INNER JOIN LIDOITUONG DmDt ON GiaBan.Ma_Dt = DmDt.Ma_Dt
                                   LEFT JOIN LINHANVIEN nv ON DmDt.MA_CBNV_BH = nv.Ma_CbNv  ";


//            string strSQLExec = @"SELECT GiaBan.*, DmVt.Ten_Vt, DmDt.Ten_Dt ,DmDt.MA_CBNV_BH 
//                                    FROM ARGIABAN GiaBan " +
//                                @" LEFT JOIN LIVATTU DmVt ON GiaBan.Ma_Vt = DmVt.Ma_Vt " +
//                                @" INNER JOIN LIDOITUONG DmDt ON GiaBan.Ma_Dt = DmDt.Ma_Dt
//                                   ";
            dtGiaBan = SQLExec.ExecuteReturnDt(strSQLExec);

            bdsGiaBan.DataSource = dtGiaBan;
            dgvGiaBan.DataSource = bdsGiaBan;


            ExportControl = dgvGiaBan;
            bdsSearch = bdsGiaBan;
        }
        public void Filter()
        {
            string strKey = "(1 = 1) ";

            if (txtMa_Vt.Text != string.Empty)
                strKey = strKey + " AND (Ma_Vt = '" + txtMa_Vt.Text + "')";


            if (txtMa_Dt.Text != string.Empty)
                strKey = strKey + " AND (Ma_Dt = '" + txtMa_Dt.Text + "')";

            this.bdsGiaBan.Filter = strKey;


        }

        void txtMa_Vt_TextChanged(object sender, EventArgs e)
        {
            this.Filter();
        }
        void txtMa_Dt_TextChanged(object sender, EventArgs e)
        {
            this.Filter();
        }

        void txtMa_Vt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt.Text.Trim();
            bool bRequire = false;

         
            DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Vt.Text = string.Empty;
                lbtTen_Vt.Text = string.Empty;
            }
            else
            {
                txtMa_Vt.Text = ((string)drLookup["Ma_Vt"]).Trim();
                lbtTen_Vt.Text = ((string)drLookup["Ten_Vt"]).Trim();
               

            }

            

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt.Text.Trim();
            bool bRequire = false;

           
            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt.Text = string.Empty;
                lbtTen_Dt.Text = string.Empty;
            }
            else
            {
                txtMa_Dt.Text = ((string)drLookup["Ma_Dt"]).Trim();
                lbtTen_Dt.Text = ((string)drLookup["Ten_Dt"]).Trim();




            }

         

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }
        public override void Edit(enuEdit enuNew_Edit)
        {
            if (bdsGiaBan.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai            
            if (bdsGiaBan.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsGiaBan.Current).Row, ref drCurrent);
            else
                drCurrent = dtGiaBan.NewRow();

            frmGiaBan_Edit frmEdit = new frmGiaBan_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            //Accept
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsGiaBan.Position >= 0)
                        dtGiaBan.ImportRow(drCurrent);
                    else
                        dtGiaBan.Rows.Add(drCurrent);

                    bdsGiaBan.Position = bdsGiaBan.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsGiaBan.Current).Row);
                }

                dtGiaBan.AcceptChanges();
            }
            else
                dtGiaBan.RejectChanges();
        }

        public override void Delete()
        {
            if (bdsGiaBan.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsGiaBan.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("ARGIABAN", drCurrent))
            {
                bdsGiaBan.RemoveAt(bdsGiaBan.Position);
                dtGiaBan.AcceptChanges();
            }
        }
        public virtual void Import_Excel()
        {
            string strTableName = "ARGIABAN";
            OpenFileDialog ofdlg = new OpenFileDialog();

            ofdlg.DefaultExt = "xls";
            ofdlg.Filter = "*.xls|*.xls";

            if (ofdlg.ShowDialog() != DialogResult.OK)
                return;

            String strConnectString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
               "Data Source=" + ofdlg.FileName + ";Extended Properties=Excel 8.0;";

            using (OleDbConnection probeConn = new OleDbConnection(strConnectString))
            {
                probeConn.Open();
                string probe = "SELECT * FROM [Sheet1$] " + //Sheet1$A1:A65536
                                "Where Ma_Vt IS NOT NULL AND Gia IS NOT NULL";

                using (OleDbDataAdapter oleDbDapter = new OleDbDataAdapter(probe, probeConn))
                {
                    DataTable tbExcel = new DataTable();
                    oleDbDapter.Fill(tbExcel);

                    DataTable dtStruct = DataTool.SQLGetDataTable(strTableName, "TOP 0 * ", " 0 = 1", null);
                    DataTable dtStruct2 = dtStruct.Clone();
                    DataRow drNewRow = dtStruct.NewRow();
                    dtStruct.Rows.Add(drNewRow);

                    foreach (DataColumn dc in dtStruct2.Columns)
                        if (dc.DataType.ToString() == "System.Byte[]")
                        {
                            dtStruct.Columns.Remove(dc.ColumnName);
                            dtStruct.AcceptChanges();
                        }



                    Common.SetDefaultDataRow(ref drNewRow);

                    string strMsg = (Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn có muốn ghi đè lên mẫu tin đã tồn tại không ?" : "Do you want to override exists data ?");
                    bool bIs_Overide = Common.MsgYes_No(strMsg);

                    foreach (DataRow drExcel in tbExcel.Rows)
                    {
                        Common.CopyDataRow(drExcel, drNewRow);
                        drNewRow.AcceptChanges();
                        DataTool.SQLUpdate(enuEdit.New, strTableName, ref drNewRow);
                    }
                }
            }

            Common.MsgOk(Languages.GetLanguage("End_Process"));
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F10 && Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New) && Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit))
                Import_Excel();
            else
            {
                base.OnKeyDown(e);
            }
        }
    }
}
