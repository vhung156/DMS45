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

namespace Epoint.Modules.GL
{
	public partial class frmDuDauXdCb_View : Epoint.Systems.Customizes.frmView
	{

		#region Khai bao bien
		DataTable dtDuDauXdCb;
		DataRow drCurrent;
		BindingSource bdsDuDauXdCb = new BindingSource();
		dgvControl dgvDuDauXdCb = new dgvControl();

		#endregion

		#region Contructor

		public frmDuDauXdCb_View()
		{
			InitializeComponent();

			this.Resize += new EventHandler(ResizeEvent);
		}

		public override void Load()
		{
			Build();
			FillData();
			BindingLanguage();
					
			this.Show();
		}		
		
		#endregion

		#region Build, FillData
		private void Build()
		{		
			dgvDuDauXdCb.Dock = DockStyle.Fill;

			this.Controls.Add(dgvDuDauXdCb);

            dgvDuDauXdCb.strZone = "GLDUDAUXDCB_VIEW";
			dgvDuDauXdCb.BuildGridView(false);
		}

		private void FillData()
		{
			dtDuDauXdCb = DataTool.SQLGetDataTable("GLDUDAUXDCB", null, null, null);

			bdsDuDauXdCb.DataSource = dtDuDauXdCb;
			dgvDuDauXdCb.DataSource = bdsDuDauXdCb;
			bdsDuDauXdCb.Position = 0;

			//Uy quyen cho lop co so tim kiem
			bdsSearch = bdsDuDauXdCb;
			ExportControl = dgvDuDauXdCb;			
		}
		
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDuDauXdCb.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDuDauXdCb.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDuDauXdCb.Current).Row, ref drCurrent);
			else
				drCurrent = dtDuDauXdCb.NewRow();

			frmDuDauXdCb_Edit frmEdit = new frmDuDauXdCb_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDuDauXdCb.Position >= 0)
						dtDuDauXdCb.ImportRow(drCurrent);
					else
						dtDuDauXdCb.Rows.Add(drCurrent);

					bdsDuDauXdCb.Position = bdsDuDauXdCb.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDuDauXdCb.Current).Row);

				dtDuDauXdCb.AcceptChanges();
			}
			else
				dtDuDauXdCb.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDuDauXdCb.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDuDauXdCb.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("GLDUDAUXDCB", drCurrent))
			{
				bdsDuDauXdCb.RemoveAt(bdsDuDauXdCb.Position);
				dtDuDauXdCb.AcceptChanges();
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDuDauXdCb == null || bdsDuDauXdCb.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDuDauXdCb.Current).Row;
			DataTable dtTemp = dtDuDauXdCb.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}	

		#endregion 

		#region Su kien

		private void ResizeEvent(object sender, EventArgs e)
		{
			dgvDuDauXdCb.ResizeGridView();
		}

		#endregion 
	}
}