using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Customizes;
using Epoint.Systems;
using Epoint.Systems.Commons;
using Epoint.Systems.Controls;

namespace Epoint.Modules.AS
{
	public partial class frmCtTsDChinh : Epoint.Systems.Customizes.frmView
	{
		private DataTable dtCtTsDChinh;
		private BindingSource bdsCtTsDChinh = new BindingSource();
		private dgvControl dgvCtTsDChinh = new dgvControl();
		private DataRow drCurrent;
		private DataRow drCtTsNGia;

		public frmCtTsDChinh()
		{
			InitializeComponent();
		}

		new public void Load(DataRow drCtTsNGia)
		{
			this.drCtTsNGia = drCtTsNGia;
			
			this.Build();
			this.FillData();

			this.Show();
		}

		private void Build()
		{
			dgvCtTsDChinh.ReadOnly = true;
			dgvCtTsDChinh.strZone = "CTTSDCHINH";
			dgvCtTsDChinh.Dock = DockStyle.Fill;

			this.Controls.Add(dgvCtTsDChinh);

			dgvCtTsDChinh.BuildGridView();
		}

		private void FillData()
		{
			string strKey = "Ma_Ts = '" + drCtTsNGia["Ma_Ts"] + "' AND Stt = '" + drCtTsNGia["Stt"] + "'";

			dtCtTsDChinh = DataTool.SQLGetDataTable("ASTSDC", null, strKey, "Ngay_Ps");

			bdsCtTsDChinh.DataSource = dtCtTsDChinh;
			dgvCtTsDChinh.DataSource = bdsCtTsDChinh;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsCtTsDChinh.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (bdsCtTsDChinh.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCtTsDChinh.Current).Row, ref drCurrent);
			else
				drCurrent = dtCtTsDChinh.NewRow();

			if (enuNew_Edit == enuEdit.New)
			{
				drCurrent["Ma_Ts"] = drCtTsNGia["Ma_Ts"];
				drCurrent["Stt"] = drCtTsNGia["Stt"];
			}

			

			frmCtTsDChinh_Edit frmEdit = new frmCtTsDChinh_Edit();
			frmEdit.drCtTsNGia = this.drCtTsNGia;
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsCtTsDChinh.Position >= 0)
						dtCtTsDChinh.ImportRow(drCurrent);
					else
						dtCtTsDChinh.Rows.Add(drCurrent);

					bdsCtTsDChinh.Position = bdsCtTsDChinh.Find("Ident00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtTsDChinh.Current).Row);
				}

				dtCtTsDChinh.AcceptChanges();
			}
			else
				dtCtTsDChinh.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsCtTsDChinh.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCtTsDChinh.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("ASTSDC", drCurrent))
			{
				bdsCtTsDChinh.RemoveAt(bdsCtTsDChinh.Position);
				dtCtTsDChinh.AcceptChanges();
			}
		}
	}
}
