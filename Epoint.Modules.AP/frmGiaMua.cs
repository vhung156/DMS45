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
using System.Data.Odbc;

namespace Epoint.Modules.AP
{
	public partial class frmGiaMua : Epoint.Systems.Customizes.frmView
	{
		DataTable dtGiaMua;
		BindingSource bdsGiaMua = new BindingSource();
		DataRow drCurrent;
		dgvControl dgvGiaMua = new dgvControl();

		public frmGiaMua()
		{			
			InitializeComponent();
		}

		public override void Load()
		{
			this.Build();
			this.FillData();

			this.Show();
		}

		private void Build()
		{
			dgvGiaMua.Dock = DockStyle.Fill;
			dgvGiaMua.strZone = "GiaMua";
			dgvGiaMua.BuildGridView();

			this.Controls.Add(dgvGiaMua);
		}

		private void FillData()
		{
			string strSQLExec = "SELECT GiaMua.*, DmVt.Ten_Vt, DmDt.Ten_Dt FROM APGIAMUA GiaMua " +
				" LEFT JOIN LIVATTU DmVt ON GiaMua.Ma_Vt = DmVt.Ma_Vt " +
				" LEFT JOIN LIDOITUONG DmDt ON GiaMua.Ma_Dt = DmDt.Ma_Dt";

			dtGiaMua = SQLExec.ExecuteReturnDt(strSQLExec);

			bdsGiaMua.DataSource = dtGiaMua;
			dgvGiaMua.DataSource = bdsGiaMua;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsGiaMua.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsGiaMua.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsGiaMua.Current).Row, ref drCurrent);
			else
				drCurrent = dtGiaMua.NewRow();

			frmGiaMua_Edit frmEdit = new frmGiaMua_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsGiaMua.Position >= 0)
						dtGiaMua.ImportRow(drCurrent);
					else
						dtGiaMua.Rows.Add(drCurrent);

					bdsGiaMua.Position = bdsGiaMua.Find("Ident00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsGiaMua.Current).Row);
				}

				dtGiaMua.AcceptChanges();
			}
			else
				dtGiaMua.RejectChanges();
		}
        public virtual void Import_Excel()
        {
            string strTableName = "APGIAMUA";
            OpenFileDialog ofdlg = new OpenFileDialog();

            ofdlg.DefaultExt = "xls";
            ofdlg.Filter = "*.xls|*.xls";

            if (ofdlg.ShowDialog() != DialogResult.OK)
                return;

//            string probeConnStr = @"Provider=Microsoft.Jet.OLEDB.4.0;
//						Data Source= " + ofdlg.FileName + ";" +
//                        "Extended Properties=\"Excel 8.0;HDR=YES\"";
            //string strConnectString =
            //            "Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};DBQ=" + ofdlg.FileName;
            
            String strConnectString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                 "Data Source=" + ofdlg.FileName + ";Extended Properties=Excel 8.0;";

            using (OleDbConnection connection = new OleDbConnection(strConnectString))
                {
                    connection.Open();

                    string selectCommandText = "SELECT * FROM [Sheet1$] Where Ma_Vt IS NOT NULL ";
                    using (OleDbDataAdapter oleDbDapter = new OleDbDataAdapter(selectCommandText, connection))
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
		public override void Delete()
		{
			if (bdsGiaMua.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsGiaMua.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("APGIAMUA", drCurrent))
			{
				bdsGiaMua.RemoveAt(bdsGiaMua.Position);
				dtGiaMua.AcceptChanges();
			}
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
