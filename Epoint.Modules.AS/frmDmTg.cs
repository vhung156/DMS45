using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems;

namespace Epoint.Modules.AS
{
	public partial class frmDmTg : Epoint.Systems.Customizes.frmView
	{

		#region Khai bao bien
		DataTable dtDmTg;
		DataRow drCurrent;
		BindingSource bdsDmTg = new BindingSource();
		dgvControl dgvDmTg = new dgvControl();

		#endregion

		#region Contructor

		public frmDmTg()
		{
			InitializeComponent();

			this.Resize += new EventHandler(ResizeEvent);
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

		public override void LoadLookup()
		{
			this.Load();
		}
		
		#endregion

		#region Build, FillData
		private void Build()
		{		
			dgvDmTg.Dock = DockStyle.Fill;

			this.Controls.Add(dgvDmTg);

			dgvDmTg.strZone = "DMTG";
			dgvDmTg.BuildGridView(this.isLookup);
		}

		private void FillData()
		{
			dtDmTg = DataTool.SQLGetDataTable("ASTG", null, this.strLookupKeyFilter, null);

			bdsDmTg.DataSource = dtDmTg;
			dgvDmTg.DataSource = bdsDmTg;
			bdsDmTg.Position = 0;

			//Uy quyen cho lop co so tim kiem
			bdsSearch = bdsDmTg;
			ExportControl = dgvDmTg;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmTg.Rows.Count - 1; i++)
				if (((string)dtDmTg.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmTg.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmTg.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmTg.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmTg.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmTg.NewRow();

			frmDmTg_Edit frmEdit = new frmDmTg_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
					if (bdsDmTg.Position >= 0)
						dtDmTg.ImportRow(drCurrent);
					else
						dtDmTg.Rows.Add(drCurrent);
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmTg.Current).Row);

				dtDmTg.AcceptChanges();
			}
			else
				dtDmTg.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmTg.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmTg.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("ASTG", drCurrent))
			{
				bdsDmTg.RemoveAt(bdsDmTg.Position);
				dtDmTg.AcceptChanges();
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmTg == null || bdsDmTg.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmTg.Current).Row;
			DataTable dtTemp = dtDmTg.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmTg.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmTg.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		private void ResizeEvent(object sender, EventArgs e)
		{
			dgvDmTg.ResizeGridView();
		}

		#endregion 
	}
}