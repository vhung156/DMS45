using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Lists;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;
using Epoint.Systems.Data;

namespace Epoint.Modules.AR
{
	public partial class frmQueryDoiTuong : Epoint.Lists.frmView
	{
		#region Khai bao bien

		DataTable dtNhanVien;
		DataTable dtDoiTuongNh;
		DataTable dtKhuVuc;
		DataTable dtDoiTuong;

		BindingSource bdsNhanVien = new BindingSource();
		BindingSource bdsDoiTuongNh = new BindingSource();
		BindingSource bdsKhuVuc = new BindingSource();
		BindingSource bdsDoiTuong = new BindingSource();

		private DataRow drCurrent;

		#endregion

		#region Contructor

		public frmQueryDoiTuong()
		{
			InitializeComponent();

			this.cboMa_CbNv.TextChanged += new EventHandler(cboMa_CbNv_TextChanged);
			this.cboMa_Kv.TextChanged += new EventHandler(cboMa_Kv_TextChanged);
			this.cboMa_Nh_Dt.TextChanged += new EventHandler(cboMa_Nh_Dt_TextChanged);

		}

		public override void Load()
		{
			this.Build();
			this.FillData();

			this.BindingLanguage();

			this.Show();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			dgvDoiTuong.strZone = "DoiTuong";
			dgvDoiTuong.BuildGridView();

			cboMa_CbNv.lstItem.BuildListView("MA_CBNV:100,TEN_CBNV:200");
			cboMa_CbNv.lstItem.Width = 400;

			cboMa_Kv.lstItem.Width = 400;
			cboMa_Kv.lstItem.BuildListView("MA_KV:100,TEN_KV:200");

			cboMa_Nh_Dt.lstItem.Width = 400;
			cboMa_Nh_Dt.lstItem.BuildListView("MA_NH_DT:100,TEN_NH_DT:200");
		}

		private void FillData()
		{			
			dtNhanVien = DataTool.SQLGetDataTable("LINHANVIEN", "", "", "Ma_CbNv");
			bdsNhanVien.DataSource = dtNhanVien;
			cboMa_CbNv.lstItem.DataSource = bdsNhanVien;

			dtKhuVuc = DataTool.SQLGetDataTable("LIKHUVUC", "", "", "Ma_Kv");
			bdsKhuVuc.DataSource = dtKhuVuc;
			cboMa_Kv.lstItem.DataSource = bdsKhuVuc;

			dtDoiTuongNh = DataTool.SQLGetDataTable("LIDOITUONGNH", "", "Nh_Cuoi = 1", "Ma_Nh_Dt");
			bdsDoiTuongNh.DataSource = dtDoiTuongNh;
			cboMa_Nh_Dt.lstItem.DataSource = bdsDoiTuongNh;

			dtDoiTuong = DataTool.SQLGetDataTable("LIDOITUONG", "", "", "Ma_Dt");
			bdsDoiTuong.DataSource = dtDoiTuong;
			dgvDoiTuong.DataSource = bdsDoiTuong;

			ExportControl = dgvDoiTuong;
			this.bdsSearch = bdsDoiTuong;
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDoiTuong.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDoiTuong.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDoiTuong.Current).Row, ref drCurrent);
			else
			{
				drCurrent = dtDoiTuong.NewRow();				
			}

			frmDoiTuong_Edit frmEdit = new frmDoiTuong_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDoiTuong.Position >= 0)
						dtDoiTuong.ImportRow(drCurrent);
					else
						dtDoiTuong.Rows.Add(drCurrent);

					bdsDoiTuong.Position = bdsDoiTuong.Find("MA_DT", drCurrent["MA_DT"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDoiTuong.Current).Row);
				}

				dtDoiTuong.AcceptChanges();
			}
			else
				dtDoiTuong.RejectChanges();
		}

		public void Filter()
		{
			string strKey = "(1 = 1) ";

			if (cboMa_CbNv.Text != string.Empty)
				strKey = strKey + " AND (Ma_CbNv = '" + cboMa_CbNv.Text + "')";

			if (cboMa_Kv.Text != string.Empty)
				strKey = strKey + " AND (Ma_Kv = '" + cboMa_Kv.Text + "')";

			if (cboMa_Nh_Dt.Text != string.Empty)
				strKey = strKey + " AND (Ma_Nh_Dt = '" + cboMa_Nh_Dt.Text + "')";

			this.bdsDoiTuong.Filter = strKey;
		}

		public override void Delete()
		{
			if (bdsDoiTuong.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDoiTuong.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("LIDOITUONG", drCurrent))
			{
				bdsDoiTuong.RemoveAt(bdsDoiTuong.Position);
				dtDoiTuong.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			if (bdsDoiTuong.Count <= 0)
				return;

			drCurrent = ((DataRowView)bdsDoiTuong.Current).Row;
			string strOldValue = (string)drCurrent["Ma_Dt"];

			frmMergeID frm = new frmMergeID();

			frm.Load("LIDOITUONG", "Ma_Dt", "Ten_Dt", strOldValue, "DoiTuong");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Are you sure to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Ma_Dt", "LIDOITUONG", strOldValue, strNewValue))
				{
					bdsDoiTuong.RemoveCurrent();
					bdsDoiTuong.Position = bdsDoiTuong.Find("MA_DT", strNewValue);
				}
			}
		}

		#endregion

		void cboMa_CbNv_TextChanged(object sender, EventArgs e)
		{
			this.Filter();
		}

		void cboMa_Kv_TextChanged(object sender, EventArgs e)
		{
			this.Filter();
		}

		void cboMa_Nh_Dt_TextChanged(object sender, EventArgs e)
		{
			this.Filter();
		}		
	}
}
