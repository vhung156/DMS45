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

namespace Epoint.Modules.POS
{
	public partial class frmCa : Epoint.Systems.Customizes.frmView
	{
		private DataTable dtCa;
		private BindingSource bdsCa = new BindingSource();
		private dgvControl dgvCa = new dgvControl();
		private DataRow drCurrent;

		public frmCa()
		{
			InitializeComponent();
		}

		public override void Load()
		{
			this.Build();
			this.FillData();

			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}

		public override void LoadLookup()
		{
			this.Load();
		}

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsCa == null || bdsCa.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsCa.Current).Row;
			DataTable dtTemp = dtCa.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

		public override void EnterProcess()
		{
			if (bdsCa.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsCa.Current).Row;
				this.Close();
			}
		}

		#endregion 

		private void Build()
		{
			dgvCa.ReadOnly = true;
			dgvCa.strZone = "CA";
			dgvCa.Dock = DockStyle.Fill;

			this.Controls.Add(dgvCa);

			dgvCa.BuildGridView();
		}

		private void FillData()
		{
			dtCa = DataTool.SQLGetDataTable("LICA", null, "", "Ma_Ca");

			bdsCa.DataSource = dtCa;
			dgvCa.DataSource = bdsCa;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsCa.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (bdsCa.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCa.Current).Row, ref drCurrent);
			else
				drCurrent = dtCa.NewRow();

			frmCa_Edit frmEdit = new frmCa_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsCa.Position >= 0)
						dtCa.ImportRow(drCurrent);
					else
						dtCa.Rows.Add(drCurrent);

					bdsCa.Position = bdsCa.Find("MA_CA", drCurrent["MA_CA"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCa.Current).Row);
				}

				dtCa.AcceptChanges();
			}
			else
				dtCa.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsCa.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCa.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("LICA", drCurrent))
			{
				bdsCa.RemoveAt(bdsCa.Position);
				dtCa.AcceptChanges();
			}
		}
	}
}
