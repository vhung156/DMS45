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
	public partial class frmCtCCDCDChinh : Epoint.Systems.Customizes.frmView
	{
		private DataTable dtCtCCDCDChinh;
		private BindingSource bdsCtCCDCDChinh = new BindingSource();
		private dgvControl dgvCtCCDCDChinh = new dgvControl();
		private DataRow drCurrent;
		private DataRow drCtCCDCNGia;

		public frmCtCCDCDChinh()
		{
			InitializeComponent();
		}

		new public void Load(DataRow drCtCCDCNGia)
		{
			this.drCtCCDCNGia = drCtCCDCNGia;
			
			this.Build();
			this.FillData();

			this.Show();
		}

		private void Build()
		{
			dgvCtCCDCDChinh.ReadOnly = true;
			dgvCtCCDCDChinh.strZone = "CtCCDCDChinh";
			dgvCtCCDCDChinh.Dock = DockStyle.Fill;

			this.Controls.Add(dgvCtCCDCDChinh);

			dgvCtCCDCDChinh.BuildGridView();
		}

		private void FillData()
		{
			string strKey = "Ma_CCDC = '" + drCtCCDCNGia["Ma_CCDC"] + "' AND Stt = '" + drCtCCDCNGia["Stt"] + "'";

			dtCtCCDCDChinh = DataTool.SQLGetDataTable("ASCCDCDC", null, strKey, "Ngay_Ps");

			bdsCtCCDCDChinh.DataSource = dtCtCCDCDChinh;
			dgvCtCCDCDChinh.DataSource = bdsCtCCDCDChinh;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsCtCCDCDChinh.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (bdsCtCCDCDChinh.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCtCCDCDChinh.Current).Row, ref drCurrent);
			else
				drCurrent = dtCtCCDCDChinh.NewRow();

			if (enuNew_Edit == enuEdit.New)
			{
				drCurrent["Ma_CCDC"] = drCtCCDCNGia["Ma_CCDC"];
				drCurrent["Stt"] = drCtCCDCNGia["Stt"];
			}

			

			frmCtCCDCDChinh_Edit frmEdit = new frmCtCCDCDChinh_Edit();
			frmEdit.drCtCCDCNGia = this.drCtCCDCNGia;
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsCtCCDCDChinh.Position >= 0)
						dtCtCCDCDChinh.ImportRow(drCurrent);
					else
						dtCtCCDCDChinh.Rows.Add(drCurrent);

					bdsCtCCDCDChinh.Position = bdsCtCCDCDChinh.Find("Ident00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtCCDCDChinh.Current).Row);
				}

				dtCtCCDCDChinh.AcceptChanges();
			}
			else
				dtCtCCDCDChinh.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsCtCCDCDChinh.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCtCCDCDChinh.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("ASCCDCDC", drCurrent))
			{
				bdsCtCCDCDChinh.RemoveAt(bdsCtCCDCDChinh.Position);
				dtCtCCDCDChinh.AcceptChanges();
			}
		}
	}
}
