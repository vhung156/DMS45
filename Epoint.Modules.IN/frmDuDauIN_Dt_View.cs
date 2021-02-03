using System;
using System.Collections;
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

namespace Epoint.Modules.IN
{
	public partial class frmDuDauIN_Dt_View : Epoint.Systems.Customizes.frmView
	{
		#region Fields

		private DataTable dtDuDauIN;
		private DataTable dtDuDauINCt;

		private DataRow drCurrent;
		private BindingSource bdsDuDauIN = new BindingSource();
		private BindingSource bdsDuDauINCt = new BindingSource();

		private dgvControl dgvDuDauIN = new dgvControl();
		private dgvControl dgvDuDauINCt = new dgvControl();

		#endregion

		#region Methods

        public frmDuDauIN_Dt_View()
		{
			InitializeComponent();
		}

		public void Load()
		{
			this.Build();
			this.FillData();
			this.BindingLanguage();

			this.Show();
		}

		private void Build()
		{
            this.dgvDuDauIN.strZone = "INDUDAU_VIEW";
			this.dgvDuDauIN.Dock = DockStyle.Fill;

            this.dgvDuDauINCt.strZone = "INDUDAU_VIEWCT";
			this.dgvDuDauINCt.Dock = DockStyle.Fill;

			this.Controls.Add(dgvDuDauIN);
			this.Controls.Add(dgvDuDauINCt);

			this.dgvDuDauIN.BuildGridView();
			this.dgvDuDauINCt.BuildGridView();

			this.dgvDuDauINCt.Visible = false;
		}

		private void FillData()
		{
			string strQuery = @"SELECT DmKho.Ma_Kho, DmKho.Ten_Kho, ISNULL(Ton_Dau, 0) AS Ton_Dau, ISNULL(Du_Dau, 0) AS Du_Dau, ISNULL(Du_Dau_Nt, 0) AS Du_Dau_Nt
									 FROM LIKHO DmKho LEFT JOIN 
										 (SELECT Ma_Kho, ISNULL(SUM(Ton_Dau), 0) AS Ton_Dau, ISNULL(SUM(Du_Dau), 0) AS Du_Dau, ISNULL(SUM(Du_Dau_Nt), 0) AS Du_Dau_Nt 
											FROM INDUDAU
											WHERE YEAR(Ngay_Ct) = " + Element.sysWorkingYear + @" AND (Ma_DvCs = '" + Element.sysMa_DvCs + @"' OR Ma_DvCs = '*')
											GROUP BY Ma_Kho) DuDauIN
											ON DmKho.Ma_Kho = DuDauIN.Ma_Kho";

			dtDuDauIN = SQLExec.ExecuteReturnDt(strQuery);

			bdsDuDauIN.DataSource = dtDuDauIN;

			dgvDuDauIN.DataSource = bdsDuDauIN;

			bdsSearch = bdsDuDauIN;
			ExportControl = dgvDuDauIN;
		}
        

        private void Import_Excel()
        {

            string strTableName = "INDUDAU_DT";
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
                    string selectCommandText = "SELECT * FROM [Sheet1$] Where Ma_Kho IS NOT NULL AND Ma_Vt IS NOT NULL ";
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
                SQLExec.Execute("update INDUDAU_DT set Ma_Kho = RTRIM(LTRIM(Ma_Kho)) , Ma_Vt = RTRIM(LTRIM(Ma_Vt))");

                this.EnterValid();
                Common.MsgOk(Languages.GetLanguage("End_Process") + " " + num.ToString() + " dòng được cập nhật");
            }
        }

 

 

        #endregion

		#region Update

        public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDuDauINCt.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;
            if (dtDuDauINCt == null)
                return;
			//Copy hang hien tai            
			if (bdsDuDauINCt.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDuDauINCt.Current).Row, ref drCurrent);
			else
				drCurrent = dtDuDauINCt.NewRow();

			//Kiểm tra khóa số dư
			if (enuNew_Edit == enuEdit.New)
			{
				string strSQLExec =
					"SELECT TOP 1 Locked_Sdv FROM SYSNAM " +
						" WHERE Nam = " + Element.sysWorkingYear + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";

				if ((bool)SQLExec.ExecuteReturnValue(strSQLExec))
				{
					Common.MsgCancel("Số dư đầu đã khóa!");
					return;
				}

				drCurrent["Ma_Kho"] = ((DataRowView)bdsDuDauIN.Current)["Ma_Kho"];
			}

			frmDuDauIN_Edit frmEdit = new frmDuDauIN_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDuDauINCt.Position >= 0)
						dtDuDauINCt.ImportRow(drCurrent);
					else
						dtDuDauINCt.Rows.Add(drCurrent);

					bdsDuDauINCt.Position = bdsDuDauINCt.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDuDauINCt.Current).Row);

				//this.UpdateTotal(drCurrent);

				dtDuDauINCt.AcceptChanges();
			}
			//else
			//    dtDuDauINCt.RejectChanges();
		}

        public override void Delete()
		{
			if (bdsDuDauINCt.Position < 0)
				return;

            if (dtDuDauINCt == null)
                return;

			DataRow drCurrent = ((DataRowView)bdsDuDauINCt.Current).Row;


			//Kiểm tra khóa số dư
			string strSQLExec =
				"SELECT TOP 1 Locked_Sdv FROM SYSNAM " +
					" WHERE Nam = " + Element.sysWorkingYear + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";

			if ((bool)SQLExec.ExecuteReturnValue(strSQLExec))
			{
				Common.MsgCancel("Số dư đầu đã khóa!");
				return;
			}

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("INDUDAU_DT", drCurrent))
			{
				bdsDuDauINCt.RemoveAt(bdsDuDauINCt.Position);
				dtDuDauINCt.AcceptChanges();
			}
		}

		#endregion

		#region Events

		void EnterValid()
		{
			Hashtable ht = new Hashtable();
            //ht["MA_KHO"] = ((DataRowView)bdsDuDauIN.Current)["Ma_Kho"];
			ht["NAM"] = Element.sysWorkingYear;
			ht["MA_DVCS"] = Element.sysMa_DvCs;

			dtDuDauINCt = SQLExec.ExecuteReturnDt("Sp_GetDuDauINDT", ht, CommandType.StoredProcedure);

			bdsDuDauINCt.DataSource = dtDuDauINCt;
			dgvDuDauINCt.DataSource = bdsDuDauINCt;

			dgvDuDauINCt.Visible = true;
			dgvDuDauIN.Visible = false;

			bdsSearch = bdsDuDauINCt;
			ExportControl = dgvDuDauINCt;
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Enter:
					EnterValid();
					return;

				case Keys.Escape:
					if (dgvDuDauINCt.Visible)
					{
						dgvDuDauIN.Visible = true;
						dgvDuDauINCt.Visible = false;

						bdsSearch = bdsDuDauIN;
						ExportControl = dgvDuDauIN;                        
					}
					else

                        Common.CloseCurrentFormOnMain();
					return;

			}

			if (this.ActiveControl == dgvDuDauINCt)
			{
				switch (e.KeyCode)
				{
					case Keys.F2:
						this.Edit(enuEdit.New);
						return;

					case Keys.F3:
						this.Edit(enuEdit.Edit);
						return;

					case Keys.F8:
						this.Delete();
						return;
				}
			}
           
            if (e.KeyCode == Keys.F10 && Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New) && Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit))
                Import_Excel();
			
            base.OnKeyDown(e);
		}

		#endregion
	}
}
