using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;

namespace Epoint.Modules
{
	public partial class frmQuyenSo : Epoint.Systems.Customizes.frmView
	{
		DataTable dtQuyenSo;
		BindingSource bdsQuyenSo = new BindingSource();
		DataRow drCurrent;
		dgvControl dgvQuyenSo = new dgvControl();

		public frmQuyenSo()
		{			
			InitializeComponent();
		}

		public override void Load()
		{
			this.Build();
			this.FillData();

			this.Show();
		}

		private void Build()
		{
			dgvQuyenSo.Dock = DockStyle.Fill;
			dgvQuyenSo.strZone = "QuyenSo";
			dgvQuyenSo.BuildGridView();

			this.Controls.Add(dgvQuyenSo);
		}

		private void FillData()
		{
            string strSQLExec = "SELECT * FROM LIQUYENSO ";

			dtQuyenSo = SQLExec.ExecuteReturnDt(strSQLExec);

			bdsQuyenSo.DataSource = dtQuyenSo;
			dgvQuyenSo.DataSource = bdsQuyenSo;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsQuyenSo.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsQuyenSo.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsQuyenSo.Current).Row, ref drCurrent);
			else
				drCurrent = dtQuyenSo.NewRow();

			frmQuyenSo_Edit frmEdit = new frmQuyenSo_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsQuyenSo.Position >= 0)
						dtQuyenSo.ImportRow(drCurrent);
					else
						dtQuyenSo.Rows.Add(drCurrent);

                    bdsQuyenSo.Position = bdsQuyenSo.Find("Ident00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsQuyenSo.Current).Row);
				}

				dtQuyenSo.AcceptChanges();
			}
			else
				dtQuyenSo.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsQuyenSo.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsQuyenSo.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("LIQUYENSO", drCurrent))
			{
				bdsQuyenSo.RemoveAt(bdsQuyenSo.Position);
				dtQuyenSo.AcceptChanges();
			}
		}
	}
}
