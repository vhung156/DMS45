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

namespace Epoint.Modules.AP
{
	public partial class frmGiaMua : Epoint.Systems.Customizes.frmView
	{
		DataTable dtGiaMua;
		BindingSource bdsGiaMua = new BindingSource();
		DataRow drCurrent;
		dgvControl dgvGiaMua = new dgvControl();

		public frmGiaMua()
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
			dgvGiaMua.Dock = DockStyle.Fill;
			dgvGiaMua.strZone = "GiaMua";
			dgvGiaMua.BuildGridView();

			this.Controls.Add(dgvGiaMua);
		}

		private void FillData()
		{
			string strSQLExec = "SELECT GiaMua.*, DmVt.Ten_Vt, DmDt.Ten_Dt FROM APGIAMUA GiaMua " +
				" LEFT JOIN LIVATTU DmVt ON GiaMua.Ma_Vt = DmVt.Ma_Vt " +
				" LEFT JOIN LIDOITUONG DmDt ON GiaMua.Ma_Dt = DmDt.Ma_Dt";

			dtGiaMua = SQLExec.ExecuteReturnDt(strSQLExec);

			bdsGiaMua.DataSource = dtGiaMua;
			dgvGiaMua.DataSource = bdsGiaMua;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsGiaMua.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsGiaMua.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsGiaMua.Current).Row, ref drCurrent);
			else
				drCurrent = dtGiaMua.NewRow();

			frmGiaMua_Edit frmEdit = new frmGiaMua_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsGiaMua.Position >= 0)
						dtGiaMua.ImportRow(drCurrent);
					else
						dtGiaMua.Rows.Add(drCurrent);

					bdsGiaMua.Position = bdsGiaMua.Find("Ident00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsGiaMua.Current).Row);
				}

				dtGiaMua.AcceptChanges();
			}
			else
				dtGiaMua.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsGiaMua.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsGiaMua.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("APGIAMUA", drCurrent))
			{
				bdsGiaMua.RemoveAt(bdsGiaMua.Position);
				dtGiaMua.AcceptChanges();
			}
		}
	}
}
