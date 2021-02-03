using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Elements;

namespace Epoint.Modules.GL
{
	public partial class frmDuDauGLCt_View : Epoint.Modules.frmOpening_View
	{
		#region Fields

		public DataTable dtDuDauGL;
		private DataRow drCurrent;
		private BindingSource bdsDuDauGL = new BindingSource();
		private dgvControl dgvDuDauGL = new dgvControl();
		private string strTk = string.Empty;

		#endregion

		#region Methods

		public frmDuDauGLCt_View()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(frmViewDuDauGL_KeyDown);
		}

		public override void Load()
		{
			this.Build();
			this.FillData();
			this.BindingLanguage();

			this.ShowDialog();
		}

		public void Load(string strTk)
		{
			this.strTk = strTk;

			this.Load();
		}

		private void Build()
		{
            this.dgvDuDauGL.strZone = "GLDUDAU_VIEWCT";
			this.dgvDuDauGL.Dock = DockStyle.Fill;

			this.Controls.Add(dgvDuDauGL);

			this.dgvDuDauGL.BuildGridView();
		}

		private void FillData()
		{
			string[] strArrName = { "Tk", "Nam", "Child", "Ma_DvCs" };
			object[] objArrValue = { this.strTk, Element.sysWorkingYear, true, Element.sysMa_DvCs };

			dtDuDauGL = SQLExec.ExecuteReturnDt("Sp_GetDuDauGL", strArrName, objArrValue, CommandType.StoredProcedure);

			bdsDuDauGL.DataSource = dtDuDauGL;
			bdsDuDauGL.Position = 0;
			//bdsDuDauGL.Filter = "Tk = '" + this.strTk + "' AND Have_Child <> 1";

			dgvDuDauGL.DataSource = bdsDuDauGL;

			this.bdsSearch = bdsDuDauGL;
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDuDauGL.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDuDauGL.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDuDauGL.Current).Row, ref drCurrent);
			else
				drCurrent = dtDuDauGL.NewRow();

			frmDuDauGL_Edit frmEdit = new frmDuDauGL_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDuDauGL.Position >= 0)
						dtDuDauGL.ImportRow(drCurrent);
					else
						dtDuDauGL.Rows.Add(drCurrent);

					bdsDuDauGL.Position = bdsDuDauGL.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDuDauGL.Current).Row);

				dtDuDauGL.AcceptChanges();
			}
			else
				dtDuDauGL.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDuDauGL.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDuDauGL.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("GLDUDAU", drCurrent))
			{
				bdsDuDauGL.RemoveAt(bdsDuDauGL.Position);
				dtDuDauGL.AcceptChanges();
			}
		}

		#endregion

		#region Events

		void frmViewDuDauGL_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F2:
					this.Edit(enuEdit.New);
					return;

				case Keys.F3:
					this.Edit(enuEdit.Edit);
					return;

				case Keys.F8:
					this.Delete();
					return;
			}
		}

		#endregion
	}
}
