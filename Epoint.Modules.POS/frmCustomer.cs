using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;

namespace Epoint.Modules.POS
{
	public partial class frmCustomer : Epoint.Systems.Customizes.frmView
	{
		DataTable dtCustomer;
		DataTable dtSaleHistosy;

		BindingSource bdsCustomer = new BindingSource();
		BindingSource bdsSaleHistory = new BindingSource();

		tlControl tlCustomer = new tlControl();

		DataRow drCurrent;
		string strMa_CbNv = string.Empty;

		public frmCustomer()
		{
			InitializeComponent();

			bdsCustomer.PositionChanged += new EventHandler(bdsCustomer_PositionChanged);
			cboKieu_Nhom.SelectedValueChanged += new EventHandler(cboKieu_Nhom_SelectedValueChanged);

			btNew.Click += new EventHandler(btNew_Click);
			btEdit.Click += new EventHandler(btEdit_Click);
			btDelete.Click += new EventHandler(btDelete_Click);
			btFilter.Click += new EventHandler(btFilter_Click);
		}

		public override void Load()
		{
			strMa_CbNv = (string)SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Ma_CbNv), '') FROM SYSMEMBER WHERE Member_ID = '" + Element.sysUser_Id + "'");
			int iIndex = 0;

			cboKieu_Nhom.SelectedIndex = 0;

			this.Build();
			this.FillData("");
			this.BindingData();

			this.Show();
		}

		#region Method

		void Build()
		{
			tlCustomer.strZone = "CUSTOMER";
			tlCustomer.Dock = DockStyle.Fill;
			tlCustomer.KeyFieldName = "MA_DT";
			tlCustomer.ParentFieldName = "PARENTFIELD";
			tlCustomer.BuildTreeList();
			pageCustomer.Controls.Add(tlCustomer);

			dgvSaleHistosy.strZone = "SALEHISTORY";
			dgvSaleHistosy.BuildGridView();
		}

		void FillData(string strKey)
		{
			string strSQLExec;
			string strKeyCustomer;

			strKeyCustomer = "(Deleted <> 1)";

			if (strKey != string.Empty)
				strKeyCustomer += " AND " + strKey;

			//Customer
			Hashtable htPara = new Hashtable();
			htPara.Add("KIEU_NHOM", cboKieu_Nhom.Text.Substring(0, 1));
			htPara.Add("KEY", strKeyCustomer);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			dtCustomer = SQLExec.ExecuteReturnDt("sp_CRM_GetCustomer", htPara, CommandType.StoredProcedure);
			bdsCustomer.DataSource = dtCustomer;
			tlCustomer.DataSource = bdsCustomer;

			pageCustomer.Text = "Danh sách khách hàng (" + tlCustomer.Nodes.Count.ToString().Trim() + "/" + bdsCustomer.Count.ToString().Trim() + ")";

			//SaleHistory
			strSQLExec = @"
					SELECT Stt, Ma_Ct, Ngay_Ct, So_Ct, Ong_Ba, Dia_Chi, So_Phone, TTien0 + TTien3 AS TTien, TTien_Nt0 + TTien_Nt3 AS TTien_Nt, (SELECT MAX(Ma_Dt) FROM POSBANLE WHERE Stt = T1.Stt) AS Ma_Dt
						FROM POSVOUCHER T1";
			dtSaleHistosy = SQLExec.ExecuteReturnDt(strSQLExec);

			bdsSaleHistory.DataSource = dtSaleHistosy;
			dgvSaleHistosy.DataSource = bdsSaleHistory;

			this.ExportControl = tlCustomer;
			this.bdsSearch = bdsCustomer;
		}

		private void BindingData()
		{
			foreach (Control ctrl in panel1.Controls)
			{
				if (ctrl.GetType() == typeof(txtTextBox) || ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(txtDateTime) || ctrl.GetType() == typeof(cboControl) || ctrl.GetType() == typeof(ComboBox) || ctrl.GetType() == typeof(RichTextBox))
				{
					string strFieldName = ctrl.Name.Substring(3);

					if (((DataTable)bdsCustomer.DataSource).Columns.Contains(strFieldName))
						ctrl.DataBindings.Add("Text", bdsCustomer, strFieldName);
				}
			}

			//picHinh.DataBindings.Add("Image", bdsEmployee, "Hinh");
		}

		void FilterData()
		{
			DataTable dtFilter = new DataTable();

			dtFilter.Columns.Add(new DataColumn("Ngay_Gd1", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Gd2", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("Tinh_Trang", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ten_Dt", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Dia_Chi", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("So_Phone", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("So_Fax", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Email", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Website", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Kv", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("SP_Used", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Nam_Used", typeof(int)));
			dtFilter.Columns.Add(new DataColumn("Von_CSH", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Nganh_Nghe", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Quy_Mo", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Note", typeof(string)));

			DataRow drFilter = dtFilter.NewRow();
			Common.SetDefaultDataRow(ref drFilter);

			//Set Default 
			drFilter["Ngay_Gd1"] = Element.sysNgay_Ct1;
			drFilter["Ngay_Gd2"] = Element.sysNgay_Ct2;
			drFilter["Tinh_Trang"] = "*";
			dtFilter.Rows.Add(drFilter);

			//frmCustomer_Dkl frmFilter = new frmCustomer_Dkl();
			//frmFilter.Load(drFilter);

			//if (frmFilter.isAccept)
			//{
			//    string strNgay_Gd1 = Library.DateToStr((DateTime)drFilter["Ngay_Gd1"]);
			//    string strNgay_Gd2 = Library.DateToStr((DateTime)drFilter["Ngay_Gd2"]);

			//    string strFilterKey = "(1=1)";

			//    if (strNgay_Gd1.Replace(" ", "") != "//" && strNgay_Gd2.Replace(" ", "") != "//")
			//        strFilterKey +=
			//            " AND (Ngay_Gd BETWEEN '" + strNgay_Gd1 + "' AND '" + strNgay_Gd2 + "' OR " +
			//                " Ma_Dt IN (SELECT DISTINCT Parent_ID FROM R08Task WHERE Parent_Type = 'CUSTOMER' AND Ngay_Gd BETWEEN '" + strNgay_Gd1 + "' AND '" + strNgay_Gd2 + "'))";

			//    if ((string)drFilter["Tinh_Trang"] != "*" && (string)drFilter["Tinh_Trang"] != "")
			//    {
			//        strFilterKey +=
			//            " AND (Tinh_Trang = '" + (string)drFilter["Tinh_Trang"] + "')";
			//    }

			//    if ((string)drFilter["Ten_Dt"] != "")
			//        strFilterKey += " AND (Ten_Dt LIKE N'%" + (string)drFilter["Ten_Dt"] + "%') ";

			//    if ((string)drFilter["So_Phone"] != "")
			//        strFilterKey += " AND (So_Phone LIKE N'%" + (string)drFilter["So_Phone"] + "%') ";

			//    if ((string)drFilter["So_Fax"] != "")
			//        strFilterKey += " AND (So_Fax LIKE N'%" + (string)drFilter["So_Fax"] + "%') ";

			//    if ((string)drFilter["Email"] != "")
			//        strFilterKey += " AND (Email LIKE N'%" + (string)drFilter["Email"] + "%') ";

			//    if ((string)drFilter["Website"] != "")
			//        strFilterKey += " AND (Website LIKE N'%" + (string)drFilter["Website"] + "%') ";

			//    if ((string)drFilter["Ma_Kv"] != "")
			//        strFilterKey += " AND (Ma_Kv = '" + (string)drFilter["Ma_Kv"] + "') ";

			//    if ((string)drFilter["SP_Used"] != "")
			//        strFilterKey += " AND (SP_Used LIKE N'%" + (string)drFilter["SP_Used"] + "%') ";

			//    if ((int)drFilter["Nam_Used"] != 0)
			//        strFilterKey += " AND (Nam_Used = " + ((int)drFilter["Nam_Used"]).ToString() + ") ";

			//    if ((string)drFilter["Von_CSH"] != "")
			//        strFilterKey += " AND (Von_CSH LIKE N'%" + (string)drFilter["Von_CSH"] + "%') ";

			//    if ((string)drFilter["Nganh_Nghe"] != "")
			//        strFilterKey += " AND (Nganh_Nghe LIKE N'%" + (string)drFilter["Nganh_Nghe"] + "%') ";

			//    if ((string)drFilter["Quy_Mo"] != "")
			//        strFilterKey += " AND (Quy_Mo LIKE N'%" + (string)drFilter["Quy_Mo"] + "%') ";

			//    if ((string)drFilter["Note"] != "")
			//        strFilterKey += " AND (Note LIKE N'%" + (string)drFilter["Note"] + "%') ";

			//    this.FillData(strFilterKey);
			//}
		}

		void EditCustomer(enuEdit enuNew_Edit)
		{
			if (bdsCustomer.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (strMa_CbNv == string.Empty)
			{
				Common.MsgCancel("Tài khoản đăng nhập " + Element.sysUser_Id + " chưa đăng ký với danh sách nhân viên!");
				return;
			}

			//Copy hang hien tai            
			if (bdsCustomer.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCustomer.Current).Row, ref drCurrent);
			else
				drCurrent = dtCustomer.NewRow();

			////Tính Stt Max
			//if (enuNew_Edit == enuEdit.New)
			//{
			//    CRMLib.GetNewMa_Dt(drCurrent);
			//    drCurrent["Type"] = '3';
			//    drCurrent["Ma_CbNv"] = strMa_CbNv;
			//    drCurrent["Ngay_Gd"] = DateTime.Now;
			//}

			frmCustomer_Edit frmEdit = new frmCustomer_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// Người dùng chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsCustomer.Position >= 0)
						dtCustomer.ImportRow(drCurrent);
					else
						dtCustomer.Rows.Add(drCurrent);

					bdsCustomer.Position = bdsCustomer.Find("MA_DT", drCurrent["MA_DT"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCustomer.Current).Row);

				dtCustomer.AcceptChanges();
			}
			//else
			//    dtDmBp.RejectChanges();

		}

		void DeleteCustomer()
		{
			if (bdsCustomer.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCustomer.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			string strSQLExec = "UPDATE LIDOITUONG SET Deleted = 1 WHERE Ma_Dt = '" + (string)drCurrent["Ma_Dt"] + "'";
			if (SQLExec.Execute(strSQLExec))
			{
				bdsCustomer.RemoveAt(bdsCustomer.Position);
				dtCustomer.AcceptChanges();
			}
		}

		#endregion

		#region Events

		void bdsCustomer_PositionChanged(object sender, EventArgs e)
		{
			if (bdsCustomer.Current == null)
				return;

			drCurrent = ((DataRowView)bdsCustomer.Current).Row;

			bdsSaleHistory.Filter = "Ma_Dt = '" + (string)drCurrent["Ma_Dt"] + "'";
		}

		void cboMa_CbNv_SelectedValueChanged(object sender, EventArgs e)
		{
			//if (cboMa_CbNv.Text == "*")
			//    bdsCustomer.RemoveFilter();
			//else
			//    bdsCustomer.Filter = "Ma_CbNv = '" + cboMa_CbNv.Text + "'";
			this.FillData("");
		}

		void cboKieu_Nhom_SelectedValueChanged(object sender, EventArgs e)
		{
			this.FillData("");
		}

		void btNew_Click(object sender, EventArgs e)
		{
			this.EditCustomer(enuEdit.New);
		}

		void btEdit_Click(object sender, EventArgs e)
		{
			this.EditCustomer(enuEdit.Edit);
		}

		void btDelete_Click(object sender, EventArgs e)
		{
			DeleteCustomer();
		}

		void btFilter_Click(object sender, EventArgs e)
		{
			this.FilterData();
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F2:
					if (pageCustomer.Focused || tlCustomer.Focused)
						this.EditCustomer(enuEdit.New);
					return;
				case Keys.F3:
					if (pageCustomer.Focused || tlCustomer.Focused)
						this.EditCustomer(enuEdit.Edit);
					return;
				case Keys.F9:
					this.FilterData();
					return;
				case Keys.F8:
					if (pageCustomer.Focused || tlCustomer.Focused)
						this.DeleteCustomer();
					return;

			}

			base.OnKeyDown(e);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
		}

		#endregion

	}
}
