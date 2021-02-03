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
using System.Reflection;
using System.Data.OleDb;

namespace Epoint.Modules.AS
{
	public partial class frmCtCCDC : Epoint.Systems.Customizes.frmView
	{
		#region Khai bao bien

		private DataTable dtCtCCDC;
		private DataTable dtCtCCDCNGia;
		private DataTable dtCtCCDCHMon;
		private DataTable dtCtCCDCStatus;

		private DataRow drCurrent;
		private BindingSource bdsCtCCDC = new BindingSource();
		private BindingSource bdsCtCCDCNGia = new BindingSource();
		private BindingSource bdsCtCCDCHMon = new BindingSource();
		private BindingSource bdsCtCCDCStatus = new BindingSource();

		private string strMa_Nh_Ts = string.Empty;
		public bool bLookupByGroup = false;
		public bool bLastLookupProcess = false;

		DataRow Row;

		#endregion

		#region Contructor

		public frmCtCCDC()
		{
			InitializeComponent();

			this.btNew.Click += new EventHandler(btNew_Click);
			this.btEdit.Click += new EventHandler(btEdit_Click);
			this.btDelete.Click += new EventHandler(btDelete_Click);
            this.btRefresh.Click += new EventHandler(btRefresh_Click);
            linkHelp.LinkClicked += new LinkLabelLinkClickedEventHandler(linkHelp_LinkClicked);

			bdsCtCCDC.PositionChanged += new EventHandler(bdsCtCCDC_PositionChanged);
            btImport.Click += new EventHandler(btImport_Click);
			dgvCtCCDC.Enter += new EventHandler(dgvCtCCDC_Enter);
			dgvCtCCDCHMon.Enter += new EventHandler(dgvCtCCDCHMon_Enter);
			dgvCtCCDCNGia.Enter += new EventHandler(dgvCtCCDCNGia_Enter);
			dgvCtCCDCNGia.CellClick += new DataGridViewCellEventHandler(dgvCtCCDCNGia_CellClick);

			dgvCtCCDCStatus.Enter += new EventHandler(dgvCtCCDCStatus_Enter);
			

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
            //string strTen_Nh_Ts = DataTool.SQLGetNameByCode("ASCCDCNH", "Ma_Nh_Ts", "Ten_Nh_Ts", strMa_Nh_Ts);
            //this.lblTSCDList.Text = strTen_Nh_Ts + " (" + strMa_Nh_Ts + ")";

            this.Load();
		}

		public override void LoadLookup()
		{
			if (!bLastLookupProcess && Parameters.GetParaValue("ACCESS_CCDC").ToString() == "1") //Truy cap theo nhom
				this.LoadLookupByGroup();
			else
				this.Load();
		}

		private void LoadLookupByGroup()
		{//Lookup danh muc doi tuong theo nhom

			string strValue = this.strLookupValue;
			bool bRequire = this.bLookupRequire;
			string strKeyFilter = this.strLookupKeyFilter;

            frmDmNhCCDC frm = new frmDmNhCCDC();
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
			dgvCtCCDC.strZone = "DMCCDC";
			dgvCtCCDC.BuildGridView(this.isLookup);

			dgvCtCCDCNGia.strZone = "CtCCDCNGIA";
			dgvCtCCDCNGia.BuildGridView();
			
            //DataGridViewButtonColumn dgvcDieu_Chinh = new DataGridViewButtonColumn();
            //dgvcDieu_Chinh.Width = 100;
            //dgvcDieu_Chinh.Name = "DIEU_CHINH_TS";
            //dgvcDieu_Chinh.DataPropertyName = "DIEU_CHINH_TS";            
            //dgvCtCCDCNGia.Columns.Insert(7, dgvcDieu_Chinh);

			dgvCtCCDCHMon.strZone = "CtCCDCHMON";
			dgvCtCCDCHMon.BuildGridView();

			dgvCtCCDCStatus.strZone = "CtCCDCSTATUS";
			dgvCtCCDCStatus.BuildGridView();
		}

		public void FillData()
		{
			string strKey = string.Empty;
			if (this.isLookup)
				strKey = this.strLookupKeyFilter;
			else
				strKey = (strMa_Nh_Ts == string.Empty ? string.Empty : "Ma_CCDC IN (SELECT Ma_CCDC FROM ASCCDC WHERE Ma_Nh_Ts = '" + strMa_Nh_Ts + "')");

			strKey += (strKey.Trim() != string.Empty) ? " AND " : "";
			strKey += " (Ma_CCDC IN (SELECT Ma_CCDC FROM ASCCDC WHERE Ma_DvCs = '" + Element.sysMa_DvCs + "'))";

            //Get du lieu tai san
            Hashtable ht = new Hashtable();
            ht["MA_NH_TS"] = strMa_Nh_Ts;
                        
            dtCtCCDC = DataTool.SQLGetDataTable("ASCCDC", null, strKey, "Ma_CCDC");
            bdsCtCCDC.DataSource = dtCtCCDC;
            dgvCtCCDC.DataSource = bdsCtCCDC;

			dtCtCCDCNGia = DataTool.SQLGetDataTable("ASCCDCNG", "*", strKey, "Ma_CCDC, Ngay_Ps");
			bdsCtCCDCNGia.DataSource = dtCtCCDCNGia;
			dgvCtCCDCNGia.DataSource = bdsCtCCDCNGia;

			string strSQLExec = "SELECT T1.*, T2.Dien_Giai FROM ASCCDCHM T1 JOIN ASCCDCNG T2 ON T1.Ma_CCDC = T2.Ma_CCDC AND T1.Stt = T2.Stt ";
			dtCtCCDCHMon = SQLExec.ExecuteReturnDt(strSQLExec);
			//dtCtCCDCHMon = DataTool.SQLGetDataTable("vw_CtCCDCHMON", null, strKey, "Ma_CCDC, Ngay_Ps");
			bdsCtCCDCHMon.DataSource = dtCtCCDCHMon;
			dgvCtCCDCHMon.DataSource = bdsCtCCDCHMon;

			strSQLExec = "SELECT T1.*, T2.Dien_Giai FROM ASCCDCLC T1 JOIN ASCCDCNG T2 ON T1.Ma_CCDC = T2.Ma_CCDC AND T1.Stt = T2.Stt  ";
			//dtCtCCDCStatus = DataTool.SQLGetDataTable("vw_CtCCDCSTATUS", null, strKey, "Ma_CCDC, Ngay_Ps");
			dtCtCCDCStatus = SQLExec.ExecuteReturnDt(strSQLExec);
			bdsCtCCDCStatus.DataSource = dtCtCCDCStatus;
			dgvCtCCDCStatus.DataSource = bdsCtCCDCStatus;

			bdsSearch = bdsCtCCDC;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == String.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtCtCCDC.Rows.Count - 1; i++)
				if (((string)dtCtCCDC.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsCtCCDC.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			//Nguyên giá TS
			if (dgvCtCCDCNGia.Focused)
			{
				this.Edit_CtCCDCNGia(enuNew_Edit);
				return;
			}
			//Hao mòn TS
			if (dgvCtCCDCHMon.Focused)
			{
				this.Edit_CtCCDCHMon(enuNew_Edit);
				return;
			}
			//Trạng thái TS
			if (dgvCtCCDCStatus.Focused)
			{
				this.Edit_CtCCDCStatus(enuNew_Edit);
				return;
			}

			//Thông tin tài sản
			this.Edit_CtCCDC(enuNew_Edit);

		}

		public void Edit_CtCCDC(enuEdit enuNew_Edit)
		{
			if (bdsCtCCDC.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsCtCCDC.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCtCCDC.Current).Row, ref drCurrent);
			else
				drCurrent = dtCtCCDC.NewRow();

			drCurrent["Ma_DvCs"] = Element.sysMa_DvCs;

			if (enuNew_Edit == enuEdit.New)
				drCurrent["Ma_Nh_Ts"] = strMa_Nh_Ts;

			frmCtCCDC_Edit frmEdit = new frmCtCCDC_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
					if (bdsCtCCDC.Position >= 0)
						dtCtCCDC.ImportRow(drCurrent);
					else
						dtCtCCDC.Rows.Add(drCurrent);
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtCCDC.Current).Row);

					string strMa_CCDC = (string)drCurrent["Ma_CCDC"];
					string strMa_CCDC_Old = (string)drCurrent["Ma_CCDC", DataRowVersion.Original];
					if (strMa_CCDC != strMa_CCDC_Old)
					{
						DataRow[] drArr = dtCtCCDCNGia.Select("Ma_CCDC = '" + strMa_CCDC_Old + "'");
						for (int i = 0; i < drArr.Length; i++)
						{
							drArr[i]["Ma_CCDC"] = strMa_CCDC;
						}

						drArr = dtCtCCDCHMon.Select("Ma_CCDC = '" + strMa_CCDC_Old + "'");
						for (int i = 0; i < drArr.Length; i++)
						{
							drArr[i]["Ma_CCDC"] = strMa_CCDC;
							drArr[i].AcceptChanges();
						}

						drArr = dtCtCCDCStatus.Select("Ma_CCDC = '" + strMa_CCDC_Old + "'");
						for (int i = 0; i < drArr.Length; i++)
						{
							drArr[i]["Ma_CCDC"] = strMa_CCDC;
							drArr[i].AcceptChanges();
						}

						bdsCtCCDCNGia.Filter = "(Ma_CCDC = '" + strMa_CCDC + "')";
						bdsCtCCDCHMon.Filter = "(Ma_CCDC = '" + strMa_CCDC + "')";
						bdsCtCCDCStatus.Filter = "(Ma_CCDC = '" + strMa_CCDC + "')";
					}
				}

				dtCtCCDC.AcceptChanges();
			}
			else
				dtCtCCDC.RejectChanges();
		}

		private void Edit_CtCCDCNGia(enuEdit enuNew_Edit)
		{
			if (bdsCtCCDC.Count == 0)
				return;

			if (bdsCtCCDCNGia.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsCtCCDCNGia.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCtCCDCNGia.Current).Row, ref drCurrent);
			else
				drCurrent = dtCtCCDCNGia.NewRow();

			if (enuNew_Edit == enuEdit.New)
			{
				string strMa_CCDC = (string)((DataRowView)bdsCtCCDC.Current).Row["Ma_CCDC"];
				if (!DataTool.SQLCheckExist("ASCCDC", "Ma_CCDC", strMa_CCDC))
				{
					Common.MsgCancel(strMa_CCDC + " " + Languages.GetLanguage("Not_Exist"));
					return;
				}

				drCurrent["Ma_CCDC"] = strMa_CCDC;
			}

			frmCtCCDCNGia_Edit frmEdit = new frmCtCCDCNGia_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
                    if (bdsCtCCDCNGia.Position >= 0)
                    {
                        //drCurrent["DIEU_CHINH_TS"] = "Tăng giảm Ts";
                        dtCtCCDCNGia.ImportRow(drCurrent);
                    }
                    else
                    {
                        //drCurrent["DIEU_CHINH_TS"] = "Tăng giảm Ts";
                        dtCtCCDCNGia.Rows.Add(drCurrent);
                    }
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtCCDCNGia.Current).Row);
				}

				dtCtCCDCNGia.AcceptChanges();

				#region Cập nhật vao các bảng Hao mòn, Trạng thái

				//string strStt = (string)drCurrent["Stt"];

				////Cập nhật phần hao mòn
				//DataRow[] drArr;
				//DataRow dr;

				//drArr = dtCtCCDCHMon.Select("Stt = '" + strStt + "'");
				//if (drArr.Length == 0)
				//    dr = dtCtCCDCHMon.NewRow();
				//else
				//    dr = drArr[0];

				//Common.CopyDataRow(drCurrent, dr);
				//dr["Is_Auto_Insert"] = true;

				//DataTool.SQLUpdate(enuNew_Edit, "ASCCDCHM", ref drCurrent);

				////Cập nhật phần trạng thái
				//drArr = dtCtCCDCStatus.Select("Stt = '" + strStt + "'");
				//if (drArr.Length == 0)
				//    dr = dtCtCCDCHMon.NewRow();
				//else
				//    dr = drArr[0];

				//Common.CopyDataRow(drCurrent, dr);
				//dr["Is_Auto_Insert"] = true;

				//DataTool.SQLUpdate(enuNew_Edit, "ASCCDCLC", ref drCurrent);

				#endregion
			}
			else
				dtCtCCDCNGia.RejectChanges();
		}

		private void Edit_CtCCDCHMon(enuEdit enuNew_Edit)
		{
			if (bdsCtCCDC.Count == 0)
				return;

			if (bdsCtCCDCHMon.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsCtCCDCHMon.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCtCCDCHMon.Current).Row, ref drCurrent);
			else
				drCurrent = dtCtCCDCHMon.NewRow();

			if (enuNew_Edit == enuEdit.New)
			{
				string strMa_CCDC = (string)((DataRowView)bdsCtCCDC.Current).Row["Ma_CCDC"];
				if (!DataTool.SQLCheckExist("ASCCDC", "Ma_CCDC", strMa_CCDC))
				{
					Common.MsgCancel(strMa_CCDC + " " + Languages.GetLanguage("Not_Exist"));
					return;
				}

				drCurrent["Ma_CCDC"] = ((DataRowView)bdsCtCCDC.Current).Row["Ma_CCDC"];
			}

			frmCtCCDCHMon_Edit frmEdit = new frmCtCCDCHMon_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
					if (bdsCtCCDCHMon.Position >= 0)
						dtCtCCDCHMon.ImportRow(drCurrent);
					else
						dtCtCCDCHMon.Rows.Add(drCurrent);
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtCCDCHMon.Current).Row);
				}

				dtCtCCDCHMon.AcceptChanges();
			}
			else
				dtCtCCDCHMon.RejectChanges();
		}

		private void Edit_CtCCDCStatus(enuEdit enuNew_Edit)
		{
			if (bdsCtCCDC.Count == 0)
				return;

			if (bdsCtCCDCStatus.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsCtCCDCStatus.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCtCCDCStatus.Current).Row, ref drCurrent);
			else
				drCurrent = dtCtCCDCStatus.NewRow();

			if (enuNew_Edit == enuEdit.New)
			{
				string strMa_CCDC = (string)((DataRowView)bdsCtCCDC.Current).Row["Ma_CCDC"];
				if (!DataTool.SQLCheckExist("ASCCDC", "Ma_CCDC", strMa_CCDC))
				{
					Common.MsgCancel(strMa_CCDC + " " + Languages.GetLanguage("Not_Exist"));
					return;
				}

				drCurrent["Ma_CCDC"] = ((DataRowView)bdsCtCCDC.Current).Row["Ma_CCDC"];
			}

			frmCtCCDCStatus_Edit frmEdit = new frmCtCCDCStatus_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
					if (bdsCtCCDCStatus.Position >= 0)
						dtCtCCDCStatus.ImportRow(drCurrent);
					else
						dtCtCCDCStatus.Rows.Add(drCurrent);
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtCCDCStatus.Current).Row);
				}

				dtCtCCDCStatus.AcceptChanges();
			}
			else
				dtCtCCDCStatus.RejectChanges();
		}

		public override void Delete()
		{
			//Nguyên giá TS
			if (dgvCtCCDCNGia.Focused)
			{
				this.Delete_CtCCDCNGia();
				return;
			}
			//Hao mòn TS
			if (dgvCtCCDCHMon.Focused)
			{
				this.Delete_CtCCDCHMon();
				return;
			}
			//Trạng thái TS
			if (dgvCtCCDCStatus.Focused)
			{
				this.Delete_CtCCDCStatus();
				return;
			}

			if (bdsCtCCDC.Position < 0)
				return;

			if (bdsCtCCDCNGia.Count != 0 || bdsCtCCDCHMon.Count != 0 || bdsCtCCDCStatus.Count != 0)
			{
				Common.MsgCancel("Không xóa được khi có dữ liệu chi tiết!!!");
				return;
			}

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("ASCCDC", drCurrent))
			{
				bdsCtCCDC.RemoveAt(bdsCtCCDC.Position);
				dtCtCCDC.AcceptChanges();
			}
		}

		private void Delete_CtCCDCNGia()
		{
			if (bdsCtCCDCNGia.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCtCCDCNGia.Current).Row;

			//if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
			if (!Common.MsgYes_No("Dữ liệu của chi tiết nguyên giá này cũng bị xoá trên bảng phân bổ và luân chuyển Ts \n Bạn có chắc xoá không ? "))
				return;

			string _Stt_del = drCurrent["Stt"].ToString().Trim();
			string _Ma_CCDC_del = drCurrent["Ma_CCDC"].ToString().Trim();

			Hashtable ht = new Hashtable();
			ht.Add("STT", _Stt_del);
			ht.Add("MA_CCDC", _Ma_CCDC_del);

			SQLExec.Execute("Sp_Delete_CtCCDCNGIA", ht, CommandType.StoredProcedure);

			bdsCtCCDCNGia.RemoveAt(bdsCtCCDCNGia.Position);
			dtCtCCDCNGia.AcceptChanges();

			for (int i = 0; i < dtCtCCDCHMon.Rows.Count; i++)
			{
				Row = dtCtCCDCHMon.Rows[i];
				if (Row["Stt"].ToString().Trim() == _Stt_del && Row["Ma_CCDC"].ToString().Trim() == _Ma_CCDC_del)
					dtCtCCDCHMon.Rows.Remove(Row);
			}

			for (int i = 0; i < dtCtCCDCStatus.Rows.Count; i++)
			{
				Row = dtCtCCDCStatus.Rows[i];
				if (Row["Stt"].ToString().Trim() == _Stt_del && Row["Ma_CCDC"].ToString().Trim() == _Ma_CCDC_del)
					dtCtCCDCStatus.Rows.Remove(Row);
			}

			//if (DataTool.SQLDelete("ASCCDCNG", drCurrent))
			//{
			//    bdsCtCCDCNGia.RemoveAt(bdsCtCCDCNGia.Position);
			//    dtCtCCDCNGia.AcceptChanges();
			//}
		}

		private void Delete_CtCCDCHMon()
		{
			if (bdsCtCCDCHMon.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCtCCDCHMon.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("ASCCDCHM", drCurrent))
			{
				bdsCtCCDCHMon.RemoveAt(bdsCtCCDCHMon.Position);
				dtCtCCDCHMon.AcceptChanges();
			}
		}

		private void Delete_CtCCDCStatus()
		{
			if (bdsCtCCDCStatus.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCtCCDCStatus.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("ASCCDCLC", drCurrent))
			{
				bdsCtCCDCStatus.RemoveAt(bdsCtCCDCStatus.Position);
				dtCtCCDCStatus.AcceptChanges();
			}
		}

		#endregion
        #region Import Excel
        public virtual void Import_Excel()
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
                    string selectCommandText = "SELECT * FROM [Sheet1$] Where Ma_CCDC IS NOT NULL AND Ten_CCDC IS NOT NULL";
                    string strMsg = (Element.sysLanguage == enuLanguageType.Vietnamese) ? "Bạn có muốn ghi đè dữ liệu đã tồn tại không ? " : "Do you want to override exists data?";
                    bool flag = Common.MsgYes_No(strMsg);
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommandText, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        DataTable tableASTS = DataTool.SQLGetDataTable("ASCCDC", "TOP 0 * ", " 0 = 1", null);
                        DataRow row = tableASTS.NewRow();
                        tableASTS.Rows.Add(row);
                        DataTable tableTSNGIA = DataTool.SQLGetDataTable("ASCCDCNG", "TOP 0 * ", " 0 = 1", null);
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
                            if (flag && DataTool.SQLCheckExist("ASCCDC", "Ma_CCDC", (string)row3["Ma_CCDC"]))
                            {
                                DataTool.SQLUpdate(enuEdit.Edit, "ASCCDC", ref row);
                                SQLExec.Execute("DELETE FROM ASCCDCNG WHERE Ma_CCDC = '" + ((string)row3["Ma_CCDC"]) + "'");
                                row2["Stt"] = Common.GetNewStt("06", true);
                                DataTool.SQLUpdate(enuEdit.New, "ASCCDCNG", ref row2);
                            }
                            else if (!DataTool.SQLCheckExist("ASCCDC", "Ma_CCDC", (string)row3["Ma_CCDC"]))
                            {
                                DataTool.SQLUpdate(enuEdit.New, "ASCCDC", ref row);
                                row2["Stt"] = Common.GetNewStt("06", true);
                                DataTool.SQLUpdate(enuEdit.New, "ASCCDCNG", ref row2);
                            }
                        }
                    }
                    base.GetType().InvokeMember("FillData", BindingFlags.InvokeMethod, null, this, null);
                }
                Common.MsgOk(Languages.GetLanguage("End_Process"));
            }
        }





        #endregion

		#region Su kien

		void bdsCtCCDC_PositionChanged(object sender, EventArgs e)
		{
            string strFilter = "";
            if (bdsCtCCDC.Count != 0)
            {
                drCurrent = ((DataRowView)bdsCtCCDC.Current).Row;
                strFilter = "(Ma_CCDC = '" + (string)drCurrent["Ma_CCDC"] + "')";

            }

			bdsCtCCDCNGia.Filter = strFilter;
			bdsCtCCDCHMon.Filter = strFilter;
			bdsCtCCDCStatus.Filter = strFilter;
		}

		void btNew_Click(object sender, EventArgs e)
		{
			if (this.tabControl1.SelectedTab == tpCtCCDCNGia)
				Edit_CtCCDCNGia(enuEdit.New);

			else if (this.tabControl1.SelectedTab == tpCtCCDCHMon)
				Edit_CtCCDCHMon(enuEdit.New);

			else if (this.tabControl1.SelectedTab == tpCtCCDCStatus)
				Edit_CtCCDCStatus(enuEdit.New);
		}

		void btEdit_Click(object sender, EventArgs e)
		{
			if (this.tabControl1.SelectedTab == tpCtCCDCNGia)
				Edit_CtCCDCNGia(enuEdit.Edit);

			else if (this.tabControl1.SelectedTab == tpCtCCDCHMon)
				Edit_CtCCDCHMon(enuEdit.Edit);

			else if (this.tabControl1.SelectedTab == tpCtCCDCStatus)
				Edit_CtCCDCStatus(enuEdit.Edit);
		}

		void btDelete_Click(object sender, EventArgs e)
		{
			if (this.tabControl1.SelectedTab == tpCtCCDCNGia)
				Delete_CtCCDCNGia();

			else if (this.tabControl1.SelectedTab == tpCtCCDCHMon)
				Delete_CtCCDCHMon();

			else if (this.tabControl1.SelectedTab == tpCtCCDCStatus)
				Delete_CtCCDCStatus();
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

		void dgvCtCCDCStatus_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
		}

		void dgvCtCCDCNGia_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
		}

		void dgvCtCCDCNGia_CellClick(object sender, DataGridViewCellEventArgs e)
		{

			if (dgvCtCCDCNGia.CurrentCell.OwningColumn.DataPropertyName == "IS_GIAM_TS")
			{
				drCurrent = ((DataRowView)bdsCtCCDCNGia.Current).Row;

				if ((bool)drCurrent["IS_GIAM_TS"] == true)
				{
					if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
						return;

					drCurrent["NGAY_GIAM_TS"] = new DateTime(1900, 1, 1);
					drCurrent["MA_GIAM_TS"] = "";
					drCurrent["IS_GIAM_TS"] = false;

					DataTool.SQLUpdate(enuEdit.Edit, "ASCCDCNG", ref drCurrent);
				}
				else
				{
					frmGiam_Ts_Edit Giam_Ts_Edit = new frmGiam_Ts_Edit();
					Giam_Ts_Edit.Load(enuEdit.Edit, drCurrent);
				}
			}
            //else if (dgvCtCCDCNGia.CurrentCell.OwningColumn.DataPropertyName == "DIEU_CHINH_TS")
            //{
            //    if (bdsCtCCDCNGia.Count < 0)
            //        return;

            //    drCurrent = ((DataRowView)bdsCtCCDCNGia.Current).Row;

            //    frmCtCCDCDChinh frm = new frmCtCCDCDChinh();
            //    frm.MdiParent = this.MdiParent;
            //    frm.Load(drCurrent);

            //    frm.Show();                
            //    Common.AddFormOnCurentTab(frm);
            //}
		}

		void dgvCtCCDCHMon_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
		}

		void dgvCtCCDC_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
		}

        void btImport_Click(object sender, EventArgs e)
        {

            if ((Common.CheckPermission(base.Object_ID, enuPermission_Type.Allow_New)) && Common.CheckPermission(base.Object_ID, enuPermission_Type.Allow_Edit))
            {
                this.Import_Excel();
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (((e.KeyCode == Keys.F10) && Common.CheckPermission(base.Object_ID, enuPermission_Type.Allow_New)) && Common.CheckPermission(base.Object_ID, enuPermission_Type.Allow_Edit))
            {
                if (e.Shift)
                    this.Import_Excel();
            }
            
            else
            {
                base.OnKeyDown(e);
            }
        }

		#endregion
	}
}