using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Elements;
using System.Collections;
using System.Data.OleDb;
using System.Reflection;
using System.Data.Odbc;

namespace Epoint.Modules.AS
{
	public partial class frmCtTs : Epoint.Systems.Customizes.frmView
	{
		#region Khai bao bien

		private DataTable dtCtTs;
		private DataTable dtCtTsNGia;
		private DataTable dtCtTsHMon;
		private DataTable dtCtTsStatus;

		private DataRow drCurrent;
		private BindingSource bdsCtTs = new BindingSource();
		private BindingSource bdsCtTsNGia = new BindingSource();
		private BindingSource bdsCtTsHMon = new BindingSource();
		private BindingSource bdsCtTsStatus = new BindingSource();

		private string strMa_Nh_Ts = string.Empty;
		public bool bLookupByGroup = false;
		public bool bLastLookupProcess = false;

		DataRow Row;

		#endregion

		#region Contructor

		public frmCtTs()
		{
			InitializeComponent();

			this.btNew.Click += new EventHandler(btNew_Click);
			this.btEdit.Click += new EventHandler(btEdit_Click);
			this.btDelete.Click += new EventHandler(btDelete_Click);
            this.btRefresh.Click += new EventHandler(btRefresh_Click);
            linkHelp.LinkClicked += new LinkLabelLinkClickedEventHandler(linkHelp_LinkClicked);

			bdsCtTs.PositionChanged += new EventHandler(bdsCtTs_PositionChanged);

			dgvCtTs.Enter += new EventHandler(dgvCtTs_Enter);
			dgvCtTsHMon.Enter += new EventHandler(dgvCtTsHMon_Enter);
			dgvCtTsNGia.Enter += new EventHandler(dgvCtTsNGia_Enter);
			dgvCtTsNGia.CellClick += new DataGridViewCellEventHandler(dgvCtTsNGia_CellClick);

			dgvCtTsStatus.Enter += new EventHandler(dgvCtTsStatus_Enter);			

		}
		public override void Load()
		{
			Build();
			FillData();
			BindingLanguage();

			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}

		public void Load(string strMa_Nh_Ts)
		{
            this.strMa_Nh_Ts = strMa_Nh_Ts;
            //string strTen_Nh_Ts = DataTool.SQLGetNameByCode("ASTSNH", "Ma_Nh_Ts", "Ten_Nh_Ts", strMa_Nh_Ts);
            //this.lblTSCDList.Text = strTen_Nh_Ts + " (" + strMa_Nh_Ts + ")";

            this.Load();
		}

		public override void LoadLookup()
		{
			if (!bLastLookupProcess && Parameters.GetParaValue("ACCESS_TS").ToString() == "1") //Truy cap theo nhom
				this.LoadLookupByGroup();
			else
				this.Load();
		}

		private void LoadLookupByGroup()
		{//Lookup danh muc doi tuong theo nhom

			string strValue = this.strLookupValue;
			bool bRequire = this.bLookupRequire;
			string strKeyFilter = this.strLookupKeyFilter;

			frmDmNhTs frm = new frmDmNhTs();
			frm.bEnterFinish = false;

			Lookup.ShowLookup(frm, "ASTSNH", "Ma_Nh_Ts", strValue, bRequire, strKeyFilter, "Nh_Cuoi = '1'");

			this.bIsEnter = frm.bIsEnter;
			this.drLookup = frm.drLookup;
			this.Close();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			dgvCtTs.strZone = "CTTS";
			dgvCtTs.BuildGridView(this.isLookup);

			dgvCtTsNGia.strZone = "CTTSNGIA";
			dgvCtTsNGia.BuildGridView();
			
			DataGridViewButtonColumn dgvcDieu_Chinh = new DataGridViewButtonColumn();
			dgvcDieu_Chinh.Width = 100;
			dgvcDieu_Chinh.Name = "DIEU_CHINH_TS";
			dgvcDieu_Chinh.DataPropertyName = "DIEU_CHINH_TS";            
			dgvCtTsNGia.Columns.Insert(7, dgvcDieu_Chinh);

			dgvCtTsHMon.strZone = "CTTSHMON";
			dgvCtTsHMon.BuildGridView();

			dgvCtTsStatus.strZone = "CTTSSTATUS";
			dgvCtTsStatus.BuildGridView();
		}

		public void FillData()
		{
			string strKey = string.Empty;
			if (this.isLookup)
				strKey = this.strLookupKeyFilter;
			else
				strKey = (strMa_Nh_Ts == string.Empty ? string.Empty : "Ma_Ts IN (SELECT Ma_Ts FROM ASTS WHERE Ma_Nh_Ts = '" + strMa_Nh_Ts + "')");

			strKey += (strKey.Trim() != string.Empty) ? " AND " : "";
			strKey += " (Ma_Ts IN (SELECT Ma_Ts FROM ASTS WHERE Ma_DvCs = '" + Element.sysMa_DvCs + "'))";

			dtCtTs = DataTool.SQLGetDataTable("ASTS", null, strKey, "Ma_Ts");
			bdsCtTs.DataSource = dtCtTs;
			dgvCtTs.DataSource = bdsCtTs;

			dtCtTsNGia = DataTool.SQLGetDataTable("ASTSNG", "*, N'Tăng giảm Ts' AS DIEU_CHINH_TS", strKey, "Ma_Ts, Ngay_Ps, Ma_TG");
			bdsCtTsNGia.DataSource = dtCtTsNGia;
			dgvCtTsNGia.DataSource = bdsCtTsNGia;

			string strSQLExec = "SELECT T1.*, T2.Dien_Giai FROM ASTSHM T1 JOIN ASTSNG T2 ON T1.Ma_Ts = T2.Ma_Ts AND T1.Stt = T2.Stt ";
			dtCtTsHMon = SQLExec.ExecuteReturnDt(strSQLExec);
			//dtCtTsHMon = DataTool.SQLGetDataTable("vw_CTTSHMON", null, strKey, "Ma_Ts, Ngay_Ps");
			bdsCtTsHMon.DataSource = dtCtTsHMon;
			dgvCtTsHMon.DataSource = bdsCtTsHMon;

			strSQLExec = "SELECT T1.*, T2.Dien_Giai FROM ASTSLC T1 JOIN ASTSNG T2 ON T1.Ma_Ts = T2.Ma_Ts AND T1.Stt = T2.Stt  ";
			//dtCtTsStatus = DataTool.SQLGetDataTable("vw_CTTSSTATUS", null, strKey, "Ma_Ts, Ngay_Ps");
			dtCtTsStatus = SQLExec.ExecuteReturnDt(strSQLExec);
			bdsCtTsStatus.DataSource = dtCtTsStatus;
			dgvCtTsStatus.DataSource = bdsCtTsStatus;

			bdsSearch = bdsCtTs;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == String.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtCtTs.Rows.Count - 1; i++)
				if (((string)dtCtTs.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsCtTs.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			//Nguyên giá TS
			if (dgvCtTsNGia.Focused)
			{
				this.Edit_CtTsNGia(enuNew_Edit);
				return;
			}
			//Hao mòn TS
			if (dgvCtTsHMon.Focused)
			{
				this.Edit_CtTsHMon(enuNew_Edit);
				return;
			}
			//Trạng thái TS
			if (dgvCtTsStatus.Focused)
			{
				this.Edit_CtTsStatus(enuNew_Edit);
				return;
			}

			//Thông tin tài sản
			this.Edit_CtTs(enuNew_Edit);

		}

		public void Edit_CtTs(enuEdit enuNew_Edit)
		{
			if (bdsCtTs.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsCtTs.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCtTs.Current).Row, ref drCurrent);
			else
				drCurrent = dtCtTs.NewRow();

			drCurrent["Ma_DvCs"] = Element.sysMa_DvCs;

			if (enuNew_Edit == enuEdit.New)
				drCurrent["Ma_Nh_Ts"] = strMa_Nh_Ts;

			frmCtTs_Edit frmEdit = new frmCtTs_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
					if (bdsCtTs.Position >= 0)
						dtCtTs.ImportRow(drCurrent);
					else
						dtCtTs.Rows.Add(drCurrent);
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtTs.Current).Row);

					string strMa_Ts = (string)drCurrent["Ma_Ts"];
					string strMa_Ts_Old = (string)drCurrent["Ma_Ts", DataRowVersion.Original];
					if (strMa_Ts != strMa_Ts_Old)
					{
						DataRow[] drArr = dtCtTsNGia.Select("Ma_Ts = '" + strMa_Ts_Old + "'");
						for (int i = 0; i < drArr.Length; i++)
						{
							drArr[i]["Ma_Ts"] = strMa_Ts;
						}

						drArr = dtCtTsHMon.Select("Ma_Ts = '" + strMa_Ts_Old + "'");
						for (int i = 0; i < drArr.Length; i++)
						{
							drArr[i]["Ma_Ts"] = strMa_Ts;
							drArr[i].AcceptChanges();
						}

						drArr = dtCtTsStatus.Select("Ma_Ts = '" + strMa_Ts_Old + "'");
						for (int i = 0; i < drArr.Length; i++)
						{
							drArr[i]["Ma_Ts"] = strMa_Ts;
							drArr[i].AcceptChanges();
						}

						bdsCtTsNGia.Filter = "(Ma_Ts = '" + strMa_Ts + "')";
						bdsCtTsHMon.Filter = "(Ma_Ts = '" + strMa_Ts + "')";
						bdsCtTsStatus.Filter = "(Ma_Ts = '" + strMa_Ts + "')";
					}
				}

				dtCtTs.AcceptChanges();
			}
			else
				dtCtTs.RejectChanges();
		}

		private void Edit_CtTsNGia(enuEdit enuNew_Edit)
		{
			if (bdsCtTs.Count == 0)
				return;

			if (bdsCtTsNGia.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsCtTsNGia.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCtTsNGia.Current).Row, ref drCurrent);
			else
				drCurrent = dtCtTsNGia.NewRow();

			if (enuNew_Edit == enuEdit.New)
			{
				string strMa_Ts = (string)((DataRowView)bdsCtTs.Current).Row["Ma_Ts"];
				if (!DataTool.SQLCheckExist("ASTS", "Ma_Ts", strMa_Ts))
				{
					Common.MsgCancel(strMa_Ts + " " + Languages.GetLanguage("Not_Exist"));
					return;
				}

				drCurrent["Ma_Ts"] = strMa_Ts;
			}

			frmCtTsNGia_Edit frmEdit = new frmCtTsNGia_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
                    if (bdsCtTsNGia.Position >= 0)
                    {
                        drCurrent["DIEU_CHINH_TS"] = "Tăng giảm Ts";
                        dtCtTsNGia.ImportRow(drCurrent);
                    }
                    else
                    {
                        drCurrent["DIEU_CHINH_TS"] = "Tăng giảm Ts";
                        dtCtTsNGia.Rows.Add(drCurrent);
                    }
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtTsNGia.Current).Row);
				}

				dtCtTsNGia.AcceptChanges();

				#region Cập nhật vao các bảng Hao mòn, Trạng thái

				//string strStt = (string)drCurrent["Stt"];

				////Cập nhật phần hao mòn
				//DataRow[] drArr;
				//DataRow dr;

				//drArr = dtCtTsHMon.Select("Stt = '" + strStt + "'");
				//if (drArr.Length == 0)
				//    dr = dtCtTsHMon.NewRow();
				//else
				//    dr = drArr[0];

				//Common.CopyDataRow(drCurrent, dr);
				//dr["Is_Auto_Insert"] = true;

				//DataTool.SQLUpdate(enuNew_Edit, "ASTSHM", ref drCurrent);

				////Cập nhật phần trạng thái
				//drArr = dtCtTsStatus.Select("Stt = '" + strStt + "'");
				//if (drArr.Length == 0)
				//    dr = dtCtTsHMon.NewRow();
				//else
				//    dr = drArr[0];

				//Common.CopyDataRow(drCurrent, dr);
				//dr["Is_Auto_Insert"] = true;

				//DataTool.SQLUpdate(enuNew_Edit, "ASTSLC", ref drCurrent);

				#endregion
			}
			else
				dtCtTsNGia.RejectChanges();
		}

		private void Edit_CtTsHMon(enuEdit enuNew_Edit)
		{
			if (bdsCtTs.Count == 0)
				return;

			if (bdsCtTsHMon.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsCtTsHMon.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCtTsHMon.Current).Row, ref drCurrent);
			else
				drCurrent = dtCtTsHMon.NewRow();

			if (enuNew_Edit == enuEdit.New)
			{
				string strMa_Ts = (string)((DataRowView)bdsCtTs.Current).Row["Ma_Ts"];
				if (!DataTool.SQLCheckExist("ASTS", "Ma_Ts", strMa_Ts))
				{
					Common.MsgCancel(strMa_Ts + " " + Languages.GetLanguage("Not_Exist"));
					return;
				}

				drCurrent["Ma_Ts"] = ((DataRowView)bdsCtTs.Current).Row["Ma_Ts"];
			}

			frmCtTsHMon_Edit frmEdit = new frmCtTsHMon_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
					if (bdsCtTsHMon.Position >= 0)
						dtCtTsHMon.ImportRow(drCurrent);
					else
						dtCtTsHMon.Rows.Add(drCurrent);
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtTsHMon.Current).Row);
				}

				dtCtTsHMon.AcceptChanges();
			}
			else
				dtCtTsHMon.RejectChanges();
		}

		private void Edit_CtTsStatus(enuEdit enuNew_Edit)
		{
			if (bdsCtTs.Count == 0)
				return;

			if (bdsCtTsStatus.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsCtTsStatus.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCtTsStatus.Current).Row, ref drCurrent);
			else
				drCurrent = dtCtTsStatus.NewRow();

			if (enuNew_Edit == enuEdit.New)
			{
				string strMa_Ts = (string)((DataRowView)bdsCtTs.Current).Row["Ma_Ts"];
				if (!DataTool.SQLCheckExist("ASTS", "Ma_Ts", strMa_Ts))
				{
					Common.MsgCancel(strMa_Ts + " " + Languages.GetLanguage("Not_Exist"));
					return;
				}

				drCurrent["Ma_Ts"] = ((DataRowView)bdsCtTs.Current).Row["Ma_Ts"];
			}

			frmCtTsStatus_Edit frmEdit = new frmCtTsStatus_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
					if (bdsCtTsStatus.Position >= 0)
						dtCtTsStatus.ImportRow(drCurrent);
					else
						dtCtTsStatus.Rows.Add(drCurrent);
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtTsStatus.Current).Row);
				}

				dtCtTsStatus.AcceptChanges();
			}
			else
				dtCtTsStatus.RejectChanges();
		}

		public override void Delete()
		{
			//Nguyên giá TS
			if (dgvCtTsNGia.Focused)
			{
				this.Delete_CtTsNGia();
				return;
			}
			//Hao mòn TS
			if (dgvCtTsHMon.Focused)
			{
				this.Delete_CtTsHMon();
				return;
			}
			//Trạng thái TS
			if (dgvCtTsStatus.Focused)
			{
				this.Delete_CtTsStatus();
				return;
			}

			if (bdsCtTs.Position < 0)
				return;

			if (bdsCtTsNGia.Count != 0 || bdsCtTsHMon.Count != 0 || bdsCtTsStatus.Count != 0)
			{
				Common.MsgCancel("Không xóa được khi có dữ liệu chi tiết!!!");
				return;
			}

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("ASTS", drCurrent))
			{
				bdsCtTs.RemoveAt(bdsCtTs.Position);
				dtCtTs.AcceptChanges();
			}
		}

		private void Delete_CtTsNGia()
		{
			if (bdsCtTsNGia.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCtTsNGia.Current).Row;

			//if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
			if (!Common.MsgYes_No("Dữ liệu của chi tiết nguyên giá này cũng bị xoá trên bảng hao mòn và luân chuyển Ts \n Bạn có chắc xoá không ? "))
				return;

			string _Stt_del = drCurrent["Stt"].ToString().Trim();
			string _Ma_Ts_del = drCurrent["Ma_Ts"].ToString().Trim();

			Hashtable ht = new Hashtable();
			ht.Add("STT", _Stt_del);
			ht.Add("MA_TS", _Ma_Ts_del);

			SQLExec.Execute("Sp_Delete_CTTSNGIA", ht, CommandType.StoredProcedure);

			bdsCtTsNGia.RemoveAt(bdsCtTsNGia.Position);
			dtCtTsNGia.AcceptChanges();

			for (int i = 0; i < dtCtTsHMon.Rows.Count; i++)
			{
				Row = dtCtTsHMon.Rows[i];
				if (Row["Stt"].ToString().Trim() == _Stt_del && Row["Ma_Ts"].ToString().Trim() == _Ma_Ts_del)
					dtCtTsHMon.Rows.Remove(Row);
			}

			for (int i = 0; i < dtCtTsStatus.Rows.Count; i++)
			{
				Row = dtCtTsStatus.Rows[i];
				if (Row["Stt"].ToString().Trim() == _Stt_del && Row["Ma_Ts"].ToString().Trim() == _Ma_Ts_del)
					dtCtTsStatus.Rows.Remove(Row);
			}

			//if (DataTool.SQLDelete("ASTSNG", drCurrent))
			//{
			//    bdsCtTsNGia.RemoveAt(bdsCtTsNGia.Position);
			//    dtCtTsNGia.AcceptChanges();
			//}
		}

		private void Delete_CtTsHMon()
		{
			if (bdsCtTsHMon.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCtTsHMon.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("ASTSHM", drCurrent))
			{
				bdsCtTsHMon.RemoveAt(bdsCtTsHMon.Position);
				dtCtTsHMon.AcceptChanges();
			}
		}

		private void Delete_CtTsStatus()
		{
			if (bdsCtTsStatus.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCtTsStatus.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("ASTSLC", drCurrent))
			{
				bdsCtTsStatus.RemoveAt(bdsCtTsStatus.Position);
				dtCtTsStatus.AcceptChanges();
			}
		}

		#endregion
        #region Import Excel
        public virtual void Import_Excel()
        {
            //OpenFileDialog dialog = new OpenFileDialog
            //{
            //    DefaultExt = "xls",
            //    Filter = "*.xls|*.xls"
            //};
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "xls files (*.xls;*.xlsx)|*.xls;*.xlsx";
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string strConnectString =
                        "Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};DBQ=" + dialog.FileName;

                

                OdbcCommand odbcComm = new OdbcCommand();

                using (OdbcConnection connection = new OdbcConnection(strConnectString))
                {
                    connection.Open();
                    string selectCommandText = "SELECT * FROM [Sheet1$] Where Ma_Ts IS NOT NULL AND Ten_Ts IS NOT NULL";
                    string strMsg = (Element.sysLanguage == enuLanguageType.Vietnamese) ? "Bạn có muốn ghi đè dữ liệu đã tồn tại không ? " : "Do you want to override exists data?";
                    bool flag = Common.MsgYes_No(strMsg);
                    using (OdbcDataAdapter adapter = new OdbcDataAdapter(selectCommandText, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        DataTable tableASTS = DataTool.SQLGetDataTable("ASTS", "TOP 0 * ", " 0 = 1", null);
                        DataRow row = tableASTS.NewRow();
                        tableASTS.Rows.Add(row);
                        DataTable tableTSNGIA = DataTool.SQLGetDataTable("ASTSNG", "TOP 0 * ", " 0 = 1", null);
                        DataRow row2 = tableTSNGIA.NewRow();
                        tableTSNGIA.Rows.Add(row2);
                        Common.SetDefaultDataRow(ref row);
                        Common.SetDefaultDataRow(ref row2);
                        foreach (DataRow row3 in dataTable.Rows)
                        {
                            Common.CopyDataRow(row3, row);
                            row.AcceptChanges();
                            Common.CopyDataRow(row3, row2);
                            row2.AcceptChanges();
                            if (flag && DataTool.SQLCheckExist("ASTS", "Ma_Ts", (string)row3["Ma_Ts"]))
                            {
                                DataTool.SQLUpdate(enuEdit.Edit, "ASTS", ref row);
                                SQLExec.Execute("DELETE FROM ASTSNG WHERE Ma_Ts = '" + ((string)row3["Ma_Ts"]) + "'");
                                row2["Stt"] = Common.GetNewStt("06", true);
                                DataTool.SQLUpdate(enuEdit.New, "ASTSNG", ref row2);
                            }
                            else if (!DataTool.SQLCheckExist("ASTS", "Ma_Ts", (string)row3["Ma_Ts"]))
                            {
                                DataTool.SQLUpdate(enuEdit.New, "ASTS", ref row);
                                row2["Stt"] = Common.GetNewStt("06", true);
                                DataTool.SQLUpdate(enuEdit.New, "ASTSNG", ref row2);
                            }
                        }
                    }
                    base.GetType().InvokeMember("FillData", BindingFlags.InvokeMethod, null, this, null);
                }
                /*
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;\r\n\t\t\t\t\t\tData Source= " + dialog.FileName + ";Extended Properties=\"Excel 8.0;HDR=YES\""))
                {
                    connection.Open();
                    string selectCommandText = "SELECT * FROM [Sheet1$] Where Ma_Ts IS NOT NULL AND Ten_Ts IS NOT NULL";
                    string strMsg = (Element.sysLanguage == enuLanguageType.Vietnamese) ? "Bạn có muốn ghi đè dữ liệu đã tồn tại không ? " : "Do you want to override exists data?";
                    bool flag = Common.MsgYes_No(strMsg);
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommandText, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        DataTable tableASTS = DataTool.SQLGetDataTable("ASTS", "TOP 0 * ", " 0 = 1", null);
                        DataRow row = tableASTS.NewRow();
                        tableASTS.Rows.Add(row);
                        DataTable tableTSNGIA = DataTool.SQLGetDataTable("ASTSNG", "TOP 0 * ", " 0 = 1", null);
                        DataRow row2 = tableTSNGIA.NewRow();
                        tableTSNGIA.Rows.Add(row2);
                        Common.SetDefaultDataRow(ref row);
                        Common.SetDefaultDataRow(ref row2);
                        foreach (DataRow row3 in dataTable.Rows)
                        {
                            Common.CopyDataRow(row3, row);
                            row.AcceptChanges();
                            Common.CopyDataRow(row3, row2);
                            row2.AcceptChanges();
                            if (flag && DataTool.SQLCheckExist("ASTS", "Ma_Ts", (string)row3["Ma_Ts"]))
                            {
                                DataTool.SQLUpdate(enuEdit.Edit, "ASTS", ref row);
                                SQLExec.Execute("DELETE FROM ASTSNG WHERE Ma_Ts = '" + ((string)row3["Ma_Ts"]) + "'");
                                row2["Stt"] = Common.GetNewStt("06", true);
                                DataTool.SQLUpdate(enuEdit.New, "ASTSNG", ref row2);
                            }
                            else if (!DataTool.SQLCheckExist("ASTS", "Ma_Ts", (string)row3["Ma_Ts"]))
                            {
                                DataTool.SQLUpdate(enuEdit.New, "ASTS", ref row);
                                row2["Stt"] = Common.GetNewStt("06", true);
                                DataTool.SQLUpdate(enuEdit.New, "ASTSNG", ref row2);
                            }
                        }
                    }
                    base.GetType().InvokeMember("FillData", BindingFlags.InvokeMethod, null, this, null);
                }
                 */ 
                 
                Common.MsgOk(Languages.GetLanguage("End_Process"));
            }
        }

 

 

        #endregion

        #region Su kien

        void bdsCtTs_PositionChanged(object sender, EventArgs e)
		{
            string strFilter = "";
            if (bdsCtTs.Count != 0)
            {
                drCurrent = ((DataRowView)bdsCtTs.Current).Row;
                strFilter = "(Ma_Ts = '" + (string)drCurrent["Ma_Ts"] + "')";

            }

			bdsCtTsNGia.Filter = strFilter;
			bdsCtTsHMon.Filter = strFilter;
			bdsCtTsStatus.Filter = strFilter;
		}

		void btNew_Click(object sender, EventArgs e)
		{
			if (this.tabControl1.SelectedTab == tpCtTsNGia)
				Edit_CtTsNGia(enuEdit.New);

			else if (this.tabControl1.SelectedTab == tpCtTsHMon)
				Edit_CtTsHMon(enuEdit.New);

			else if (this.tabControl1.SelectedTab == tpCtTsStatus)
				Edit_CtTsStatus(enuEdit.New);
		}

		void btEdit_Click(object sender, EventArgs e)
		{
			if (this.tabControl1.SelectedTab == tpCtTsNGia)
				Edit_CtTsNGia(enuEdit.Edit);

			else if (this.tabControl1.SelectedTab == tpCtTsHMon)
				Edit_CtTsHMon(enuEdit.Edit);

			else if (this.tabControl1.SelectedTab == tpCtTsStatus)
				Edit_CtTsStatus(enuEdit.Edit);
		}

		void btDelete_Click(object sender, EventArgs e)
		{
			if (this.tabControl1.SelectedTab == tpCtTsNGia)
				Delete_CtTsNGia();

			else if (this.tabControl1.SelectedTab == tpCtTsHMon)
				Delete_CtTsHMon();

			else if (this.tabControl1.SelectedTab == tpCtTsStatus)
				Delete_CtTsStatus();
		}

        void btRefresh_Click(object sender, EventArgs e)
        {
            FillData();
        }

        void linkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string currentDir = Environment.CurrentDirectory;
            System.Diagnostics.Process.Start(currentDir + @"\Help\Accounting.chm");
        }

		void dgvCtTsStatus_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
		}

		void dgvCtTsNGia_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
		}

		void dgvCtTsNGia_CellClick(object sender, DataGridViewCellEventArgs e)
		{

			if (dgvCtTsNGia.CurrentCell.OwningColumn.DataPropertyName == "IS_GIAM_TS")
			{
				drCurrent = ((DataRowView)bdsCtTsNGia.Current).Row;

				if ((bool)drCurrent["IS_GIAM_TS"] == true)
				{
					if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
						return;

					drCurrent["NGAY_GIAM_TS"] = new DateTime(1900, 1, 1);
					drCurrent["MA_GIAM_TS"] = "";
					drCurrent["IS_GIAM_TS"] = false;

					DataTool.SQLUpdate(enuEdit.Edit, "ASTSNG", ref drCurrent);
				}
				else
				{
					frmGiam_Ts_Edit Giam_Ts_Edit = new frmGiam_Ts_Edit();
					Giam_Ts_Edit.Load(enuEdit.Edit, drCurrent);
				}
			}
			else if (dgvCtTsNGia.CurrentCell.OwningColumn.DataPropertyName == "DIEU_CHINH_TS")
			{
				if (bdsCtTsNGia.Count < 0)
					return;

				drCurrent = ((DataRowView)bdsCtTsNGia.Current).Row;

				frmCtTsDChinh frm = new frmCtTsDChinh();
				frm.MdiParent = this.MdiParent;
				frm.Load(drCurrent);

                frm.Show();                
                Common.AddFormOnCurentTab(frm);
			}
		}

		void dgvCtTsHMon_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
		}

		void dgvCtTs_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
		}
        
        protected override void OnKeyDown(KeyEventArgs e)
        {
           if (((e.KeyCode == Keys.F10) && Common.CheckPermission(base.Object_ID, enuPermission_Type.Allow_New)) && Common.CheckPermission(base.Object_ID, enuPermission_Type.Allow_Edit))
            {
                this.Import_Excel();
            }
            else if ((((e.Control && e.Alt) && (e.Shift && (e.KeyCode == Keys.D))) && (Common.CheckPermission(base.Object_ID, enuPermission_Type.Allow_New) && Common.CheckPermission(base.Object_ID, enuPermission_Type.Allow_Edit))) && Common.CheckPermission(base.Object_ID, enuPermission_Type.Allow_Delete))
            {
                string strMsg = (Element.sysLanguage == enuLanguageType.Vietnamese) ? "Bạn có chắc xóa hết dữ liệu ?" : "Are you sure delete all?";
                if (Common.MsgYes_No(strMsg, "N"))
                {
                    if (SQLExec.Execute("DELETE FROM ASTS WHERE Ma_DvCs = '" + Element.sysMa_Data + "'"))
                    {
                        base.GetType().InvokeMember("FillData", BindingFlags.InvokeMethod, null, this, null);
                    }
                    if (SQLExec.Execute("DELETE FROM ASTSNG WHERE Ma_DvCs = '" + Element.sysMa_Data + "'"))
                    {
                        base.GetType().InvokeMember("FillData", BindingFlags.InvokeMethod, null, this, null);
                        Common.MsgOk(Languages.GetLanguage("End_Process"));
                    }
                }
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

 

 

		#endregion
	}
}