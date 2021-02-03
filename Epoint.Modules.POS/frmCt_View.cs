using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;
using Epoint.Lists;

namespace Epoint.Modules.POS
{
	public partial class frmCt_View: Epoint.Systems.Customizes.frmView
	{
		#region Fields

		public DataSet dsVoucher = new DataSet("dsVoucher");

		public DataTable dtViewPh;
		public DataTable dtViewCt;

		public BindingSource bdsViewPh = new BindingSource();
		public BindingSource bdsViewCt = new BindingSource();

		public dgvControl dgvViewPh = new dgvControl();
		public dgvControl dgvViewCt = new dgvControl();

		public string strMa_Ct_List = string.Empty;
        string strFilterKey_Old = string.Empty;
		public DataRow drCurrent;
		public DataRow drDmCt;

		#endregion

		#region Contructor

		public frmCt_View()
		{
			InitializeComponent();

			this.Resize += new EventHandler(frmViewPh_Resize);
			this.KeyDown += new KeyEventHandler(KeyDownEvent);

			bdsViewPh.PositionChanged += new EventHandler(bdsViewPh_PositionChanged);
			
			btPreview.Click += new EventHandler(btPreview_Click);
			btPrint.Click += new EventHandler(btPrint_Click);
			btFilter.Click += new EventHandler(btFilter_Click);
            btBack.Click += new EventHandler(btBack_Click);
			dgvViewPh.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvViewPh_CellMouseClick);
			dgvViewPh.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvViewPh_CellFormatting);
			dgvViewPh.Enter += new EventHandler(dgvViewPh_Enter);
			dgvViewCt.Enter += new EventHandler(dgvViewCt_Enter);
		}

		public void Load(string strMa_Ct_List)
		{
			this.strMa_Ct_List = strMa_Ct_List;
			this.Object_ID = strMa_Ct_List;

			this.Build();

			object objNgay_CtMax = SQLExec.ExecuteReturnValue("SELECT MAX(Ngay_Ct) FROM " + (string)drDmCt["Table_Ph"] + " WHERE Ma_Ct LIKE '" + this.strMa_Ct_List.Split(',')[0] + "' AND Ma_DvCs = '" + Element.sysMa_DvCs + "'");
			int iInterval = Convert.ToInt32(Parameters.GetParaValue("DAY_FILTER"));

			DateTime dteNgay_Ct2 = objNgay_CtMax != DBNull.Value ? (DateTime)objNgay_CtMax : DateTime.Now;
			DateTime dteNgay_Ct1 = dteNgay_Ct2.Subtract(new TimeSpan(iInterval, 0, 0, 0));

			string strFilterKey = string.Empty;
			strFilterKey += "(Ma_Ct IN ('" + strMa_Ct_List.Replace(",", "','") + "'))";
			strFilterKey += " AND (Ngay_Ct BETWEEN  '" + Library.DateToStr(dteNgay_Ct1) + "' AND '" + Library.DateToStr(dteNgay_Ct2) + "')";
			strFilterKey += " AND (Ma_DvCs = '" + Element.sysMa_DvCs + "')";

            strFilterKey_Old = strFilterKey;

			this.FillData(strFilterKey, strFilterKey);
			this.BindingLanguage();
			this.BindingTong_Tien();

			this.FormLayout();

			this.Show();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			string strMa_Ct = strMa_Ct_List.Split(',')[0];

			drDmCt = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", strMa_Ct);

			//dgvViewPh 
			dgvViewPh.ReadOnly = true;
			dgvViewPh.strZone = (string)drDmCt["Zone_ViewPh"];

			dgvViewPh.BuildGridView(false);

			if (!dgvViewPh.Columns.Contains("Ma_Tte"))
			{
				dgvViewPh.Columns.Add("Ma_Tte", "Ma_Tte"); //Thêm cột để phân biệt chứng từ Nte, VND
				dgvViewPh.Columns["Ma_Tte"].DataPropertyName = "MA_TTE";
				dgvViewPh.Columns["Ma_Tte"].ValueType = typeof(string);
				dgvViewPh.Columns["Ma_Tte"].Visible = false;
			}

			dgvViewPh.Columns.Add("Mark", "Mark"); //Đánh dấu dòng
			dgvViewPh.Columns["Mark"].DataPropertyName = "MARK";
			dgvViewPh.Columns["Mark"].ValueType = typeof(string);
			dgvViewPh.Columns["Mark"].Visible = false;

			//dgvViewCt
			dgvViewCt.ReadOnly = true;
			dgvViewCt.strZone = (string)drDmCt["Zone_ViewCt"];

			dgvViewCt.BuildGridView(false);

			//Position
			this.Controls.Add(dgvViewPh);
			this.Controls.Add(dgvViewCt);
			dgvViewPh.TabIndex = 0;
			dgvViewCt.TabIndex = 1;

		}

		private void FillData(string strKey_Ph, string strKey_Ct)
		{
			string strTable_Ph = (string)drDmCt["Table_Ph"];
			string strTable_Ct = (string)drDmCt["Table_Ct"];

			//Lọc dữ liệu của người đăng nhập
			if (!Element.sysIs_Admin && !Common.CheckPermission("CTBL", enuPermission_Type.Allow_Access))
			{
				strKey_Ph = " Stt IN (SELECT Stt FROM POSBANLE WHERE (" + strKey_Ph + ") AND (Ma_CbNv IN (SELECT Ma_CbNv FROM SYSMEMBER WHERE Member_ID = '" + Element.sysUser_Id + "')))";
				strKey_Ct = " Stt IN (SELECT Stt FROM POSBANLE WHERE (" + strKey_Ph + ") AND (Ma_CbNv IN (SELECT Ma_CbNv FROM SYSMEMBER WHERE Member_ID = '" + Element.sysUser_Id + "')))";
			}

            string strSelectPh = " *, TTien0 + TTien3 AS TTien, TTien_Nt0 + TTien_Nt3 AS TTien_Nt, CAST(0 AS BIT) AS Mark ";
			dtViewPh = DataTool.SQLGetDataTable(strTable_Ph, strSelectPh, strKey_Ph, "Ngay_Ct, So_Ct");
			dtViewPh.TableName = strTable_Ph;

			bdsViewPh.DataSource = dtViewPh;
			dgvViewPh.DataSource = bdsViewPh;

			dtViewCt = DataTool.SQLGetDataTable(strTable_Ct, "*", strKey_Ct, "Ngay_Ct");
			dtViewCt.TableName = strTable_Ct;

			//Thêm tổng tiền ở phía dưới
			if (dtViewCt.Columns.Contains("TTien_Nt") && dtViewCt.Columns.Contains("TTien_Nt3"))
			{
				DataColumn dcNew = new DataColumn("TTIEN", typeof(double));
				dcNew.Expression = "Tien + Tien3";
				dtViewCt.Columns.Add(dcNew);

				dcNew = new DataColumn("TTIEN_NT", typeof(double));
				dcNew.Expression = "Tien_Nt + Tien_Nt3";
				dtViewCt.Columns.Add(dcNew);
			}

			bdsViewCt.DataSource = dtViewCt;
			dgvViewCt.DataSource = bdsViewCt;

			dsVoucher.Tables.Clear();
			dsVoucher.Tables.Add(dtViewPh);
			dsVoucher.Tables.Add(dtViewCt);

			//Lay du lieu tu Ct len Ph theo danh sach Carry_Header
			Common.CopyDataColumn(dtViewCt, dtViewPh, (string)drDmCt["Update_Header"]);

			DataRow[] arrdrViewCt;
			DataRow drViewCt;
			foreach (DataRow drViewPh in dtViewPh.Rows)
			{
				string strStt = (string)drViewPh["Stt"];
				arrdrViewCt = dtViewCt.Select("Stt = '" + strStt + "'");

				if (arrdrViewCt.Length > 0)
					drViewCt = arrdrViewCt[0];
				else
					continue;

				Common.CopyDataRow(drViewCt, drViewPh, (string)drDmCt["Update_Header"]);
			}

			bdsViewPh.MoveLast();

			this.bdsSearch = bdsViewPh;
			this.ExportControl = dgvViewPh;
		}

		private void Filter()
		{
			DataTable dtFilter = new DataTable();

			dtFilter.Columns.Add(new DataColumn("Ma_Ct", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Ct1", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Ct2", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("So_Ct1", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("So_Ct2", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Tien1", typeof(double)));
			dtFilter.Columns.Add(new DataColumn("Tien2", typeof(double)));
			dtFilter.Columns.Add(new DataColumn("Dien_Giai", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Tte", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Tk", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("No_Co", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Tk_Du", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Thue", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Hd", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Dt", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Km", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Bp", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Sp", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Nx", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Kho", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Vt", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_CbNv", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Job", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Tc", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Kv", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Table", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_DvCs", typeof(string)));

			DataRow drFilter = dtFilter.NewRow();

			//Set Default 
			drFilter["Ma_Ct"] = strMa_Ct_List;
			drFilter["Ngay_Ct1"] = Element.sysNgay_Ct1;
			drFilter["Ngay_Ct2"] = Element.sysNgay_Ct2;

			string strTable_Ph = (string)drDmCt["Table_Ph"];
			string strTable_Ct = (string)drDmCt["Table_Ct"];

			drFilter["Table"] = strTable_Ct;
			drFilter["Ma_DvCs"] = Element.sysMa_DvCs;

			if (!this.Filter_ShowForm(drFilter))
				return;

			string strKey = (string)SQLExec.ExecuteReturnValue("sp_GetVoucherFilterKey", drFilter, CommandType.StoredProcedure);

			string strKey_Ph = "Stt IN (" + strKey + ")";
			string strKey_Ct = "Stt IN (" + strKey + ")";

			this.FillData(strKey_Ph, strKey_Ct);

			Element.sysNgay_Ct1 = Convert.ToDateTime(drFilter["Ngay_Ct1"]);
			Element.sysNgay_Ct2 = Convert.ToDateTime(drFilter["Ngay_Ct2"]);
		}

		public virtual bool Filter_ShowForm(DataRow drFilter)
		{
			frmFilter frm = new frmFilter();
			frm.Load(drFilter);

			return frm.isAccept;
		}

		private void Print(bool bPreview)
		{
			if (bdsViewPh.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsViewPh.Current).Row;

			DataRow[] drArrPrint = dtViewPh.Select("Mark = true");
			bool bAcceptShowDialog = true;
			bool bInVisibleNextPrint = false;
            string strReport_File_First = string.Empty;

			if (drArrPrint.Length > 1)
			{
				for (int i = 0; i < drArrPrint.Length; i++)
				{
					drCurrent = drArrPrint[i];

					if (i == 0)
					{
                        bAcceptShowDialog = PrintVoucher.Print(drCurrent, bPreview, true, ref bInVisibleNextPrint, ref strReport_File_First);
					}
					else
					{
						if (bAcceptShowDialog)
                            bAcceptShowDialog = PrintVoucher.Print(drCurrent, bPreview, false, ref bInVisibleNextPrint, ref strReport_File_First);
						else
							break;
					}

					if (bAcceptShowDialog)
					{
						drCurrent["Mark"] = false;
					}
				}
			}
			else
                PrintVoucher.Print(drCurrent, bPreview, true, ref bInVisibleNextPrint, ref strReport_File_First);
		}

		private void Design()
		{
			string strMa_Ct = strMa_Ct_List.Split(',')[0];

			DataRow drDmCt = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", strMa_Ct);
			string strReport_File = (string)drDmCt["Report_File"];

			Epoint.Reports.frmReportDesign frm = new Epoint.Reports.frmReportDesign();
			frm.Load(strReport_File);
		}

		private void BindingTong_Tien()
		{
			numTTien0.DataBindings.Add("Value", bdsViewPh, "TTien0");
			numTTien_Nt0.DataBindings.Add("Value", bdsViewPh, "TTien_Nt0");

			numTTien3.DataBindings.Add("Value", bdsViewPh, "TTien3");
			numTTien_Nt3.DataBindings.Add("Value", bdsViewPh, "TTien_Nt3");

			numTSo_Luong.DataBindings.Add("Value", bdsViewPh, "TSo_Luong");
			
		}

		private void FormLayout()
		{
			dgvViewPh.Location = new Point(3, 3);
			dgvViewPh.Width = this.Width - 12;
			dgvViewPh.Height = (int)(0.5 * this.Height);

			dgvViewCt.Location = new Point(dgvViewPh.Left, dgvViewPh.Bottom);
			dgvViewCt.Width = this.Width - 12;
			dgvViewCt.Height = this.Height - dgvViewPh.Height - pnlTTien.Height - 45;

			dgvViewPh.ResizeGridView();
			dgvViewCt.ResizeGridView();
		}

		private void Mark()
		{
			if (bdsViewPh.Position < 0)
				return;

			if (dgvViewPh.Columns[dgvViewPh.CurrentCell.ColumnIndex].Name != "LOCKED")
			{
				if (dgvViewPh.Columns.Contains("Mark"))
				{
					drCurrent = ((DataRowView)bdsViewPh.Current).Row;

					drCurrent["Mark"] = !(bool)drCurrent["Mark"];
					dgvViewPh.Refresh();
				}
			}
		}

		private void DanhSoCt()
		{
			if (bdsViewPh.Count <= 0)
				return;

			drCurrent = ((DataRowView)bdsViewPh.Current).Row;

			string strMa_Ct = (string)drCurrent["Ma_Ct"];
			int iThang = ((DateTime)drCurrent["Ngay_Ct"]).Month;
			string strFormat_Text = string.Empty;
			string strFix_Text = string.Empty;
			string strStt = string.Empty;
			string strSo_Ct = string.Empty;

			DataTable dtDmSoCt = DataTool.SQLGetDataTable("SYSDMSOCT", "", "Ma_Ct = '" + strMa_Ct + "' AND Loai_Ma_Ct = " + iThang.ToString().Trim(), "");

			if (dtDmSoCt != null && dtDmSoCt.Rows.Count > 0)
			{
				strFormat_Text = (string)dtDmSoCt.Rows[0]["Format_Text"];
				strFix_Text = (string)dtDmSoCt.Rows[0]["Fix_Text"];
			}

			frmDanhSo_Ct frm = new frmDanhSo_Ct();
			frm.txtFormat_Text.Text = strFormat_Text;
			frm.txtFix_Text.Text = strFix_Text;
			frm.Load();

			if (frm.isAccept)
			{
				int iSo_Ct = Convert.ToInt32(frm.numSo_Ct.Value);
				strFormat_Text = frm.txtFormat_Text.Text;
				strFix_Text = frm.txtFix_Text.Text;

				for (int i = 0; i < bdsViewPh.Count; i++)
				{
					bdsViewPh.Position = i;

					string strSo_Ct_New = iSo_Ct.ToString().PadLeft(strFormat_Text.Length, '0');
					if (strFix_Text.Contains(","))
						strSo_Ct_New = strFix_Text.Replace(",", strSo_Ct_New);
					else
						strSo_Ct_New = strFix_Text + strSo_Ct_New;

					drCurrent = ((DataRowView)bdsViewPh.Current).Row;
					strStt = (string)drCurrent["Stt"];
					strSo_Ct = (string)drCurrent["So_Ct"];

					string strSQLExec =
						"UPDATE GLCVOUCHER SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "'" +
						"UPDATE CATIEN SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "'" +
						"UPDATE APMUA SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "'" +
						"UPDATE ARBAN SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "'" +
						"UPDATE INNHAPXUAT SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "'" +
						"UPDATE GLKETOAN SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "'" +

						"UPDATE vw_ThuChi SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "'" +
						"UPDATE vw_DoanhThu SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "'" +
						"UPDATE vw_ChiPhi SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "'" +
						"UPDATE vw_CongNo SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "'" +
						"UPDATE vw_TheKho SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "'" +
						"UPDATE vw_SoCai SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "'" +
						"UPDATE vw_ThueVAT SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "'" +
						"UPDATE vw_HanTt SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "' AND So_Ct = '" + strSo_Ct + "'" +
						"UPDATE GLTHANHTOAN SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "' AND So_Ct = '" + strSo_Ct + "'";

					if (SQLExec.Execute(strSQLExec))
					{
						drCurrent["So_Ct"] = strSo_Ct_New;
					}

					iSo_Ct++;
				}
			}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsViewPh.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (bdsViewPh.Position >= 0)
				drCurrent = ((DataRowView)bdsViewPh.Current).Row;
			else
			{
				drCurrent = dtViewPh.NewRow();
				drCurrent["Ma_Ct"] = strMa_Ct_List.Split(',')[0];
				drCurrent["Stt"] = "0";
				drCurrent["Ma_Tte"] = Element.sysMa_Tte;
				drCurrent["Ty_Gia"] = 1;
			}

			frmCtBL_Edit frmEdit = new frmCtBL_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent, dsVoucher);

			if (frmEdit.isAccept && (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Edit))
			{
				bdsViewPh.Position = bdsViewPh.Find("Stt", frmEdit.strStt);
			}
		}

		public override void Delete()
		{
			if (bdsViewPh.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsViewPh.Current).Row;

			if (!Common.CheckDataLocked((DateTime)drCurrent["Ngay_Ct"]))
				return;

			if (!Element.sysIs_Admin)
			{
				string strCreate_User = (string)drCurrent["Create_Log"];

				if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
				{
					string strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM SYSMEMBER WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";

					if (!strUser_Allow.Contains("*,")) //Được phép sửa tất cả
					{
						if (!strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
						{
							Common.MsgCancel("Không được xóa chứng từ do " + strCreate_User.Substring(14) + " lập, liên hệ với Admin!");
							return;
						}
					}
				}
			}

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE"), "N"))
				return;

			string strMa_Ct = ((string)drCurrent["Ma_Ct"]).Trim();
			string strStt = ((string)drCurrent["Stt"]).Trim();

            if (Voucher.SQLDeleteCt(strStt, strMa_Ct))
            {
                bdsViewPh.RemoveAt(bdsViewPh.Position);
                dtViewPh.AcceptChanges();
            }
		}

		#endregion

		#region Event

		void frmViewPh_Resize(object sender, EventArgs e)
		{
			this.FormLayout();
		}

		void KeyDownEvent(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F9:
					this.Filter();
					break;

				case Keys.F7:
					switch (e.Modifiers)
					{
						case Keys.Shift:
							Design();
							break;

						case Keys.Control:
							Print(true);
							break;

						case Keys.None:
							Print(false);
							break;
					}
					break;

				case Keys.Space: //Nhan them
					Mark();

					break;

				case Keys.A:
					if (dgvViewPh.Columns.Contains("Mark"))
						if (e.Modifiers == Keys.Control)
						{
							for (int i = 0; i < dgvViewPh.RowCount; i++)
							{
								dgvViewPh.Rows[i].Cells["Mark"].Value = true;
							}

							dgvViewPh.Refresh();
						}

					break;

				case Keys.U:
					if (dgvViewPh.Columns.Contains("Mark"))
						if (e.Modifiers == Keys.Control)
						{
							for (int i = 0; i < dgvViewPh.RowCount; i++)
							{
								dgvViewPh.Rows[i].Cells["Mark"].Value = false;
							}

							dgvViewPh.Refresh();
						}

					break;
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F3 && e.Shift)
			{
				//this.DanhSoCt();
				return;
			}
			else

				base.OnKeyDown(e);
		}

		void bdsViewPh_PositionChanged(object sender, EventArgs e)
		{
			if (bdsViewPh.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsViewPh.Current).Row;
			string strStt = (string)drCurrent["Stt"];

			bdsViewCt.Filter = "(Stt = '" + strStt + "')";
		}

		void btNew_Click(object sender, EventArgs e)
		{
			Edit(enuEdit.New);
		}

		void btEdit_Click(object sender, EventArgs e)
		{
			Edit(enuEdit.Edit);
		}

		void btDelete_Click(object sender, EventArgs e)
		{
			Delete();
		}

		void btFilter_Click(object sender, EventArgs e)
		{
			Filter();
		}

        void btBack_Click(object sender, EventArgs e)
        {
            this.FillData(strFilterKey_Old, strFilterKey_Old);
        }
		void btPreview_Click(object sender, EventArgs e)
		{
			this.Print(true);
		}

		void btPrint_Click(object sender, EventArgs e)
		{
			this.Print(false);
		}

		void btExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		void dgvViewCt_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
		}

		void dgvViewPh_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
		}

		void dgvViewPh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.Value == null || e.Value == DBNull.Value)
				return;

			if (dgvViewPh.Columns.Contains("Ma_Tte"))
			{
				if (dgvViewPh.Rows[e.RowIndex].Cells["Ma_Tte"].Value != null)
				{
					if (dgvViewPh.Rows[e.RowIndex].Cells["Ma_Tte"].Value.ToString() != Element.sysMa_Tte)
						e.CellStyle.ForeColor = Color.FromArgb(255, 49, 106, 197);
					else
						e.CellStyle.ForeColor = dgvViewPh.DefaultCellStyle.ForeColor;
				}
			}
			if (dgvViewPh.Columns.Contains("Mark"))
			{
				if (dgvViewPh.Rows[e.RowIndex].Cells["Mark"].Value != null)
				{
					if ((bool)dgvViewPh.Rows[e.RowIndex].Cells["Mark"].Value == true)
					{
						e.CellStyle.BackColor = Color.FromArgb(255, 0, 0, 255);
					}
				}
			}
		}

		void dgvViewPh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.ColumnIndex < 0)
				return;

			string strColumnName = dgvViewPh.Columns[e.ColumnIndex].Name;
			drCurrent = ((DataRowView)bdsViewPh.Current).Row;

			if (strColumnName == "DUYET")
			{
				frmDuyet frm = new frmDuyet();
				frm.Load(drCurrent);
			}
		}

		#endregion
	}
}
