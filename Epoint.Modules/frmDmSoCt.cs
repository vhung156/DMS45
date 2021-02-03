using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;

namespace Epoint.Modules
{
	public partial class frmDmSoCt : Epoint.Systems.Customizes.frmView
	{

		#region Khai bao bien

		private DataTable dtDmSoCt;
		private DataRow drCurrent;
		private BindingSource bdsDmSoCt = new BindingSource();
		private dgvControl dgvDmSoCt = new dgvControl();
		private string strMa_Ct = string.Empty;

		#endregion 						

		#region Contructor

		public frmDmSoCt()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(KeyDownEvent);
			this.Resize += new EventHandler(ResizeEvent);            
		}
        
        public override void Load()
		{
			Build();
			FillData();
			BindingLanguage();

			this.Show();
		}

		public void Load(string strMa_Ct)
		{
			this.strMa_Ct = strMa_Ct;

			this.Load();
		}

		#endregion

		#region Build
		void Build()
		{
			dgvDmSoCt.Dock = DockStyle.Fill;
			dgvDmSoCt.strZone = "DMSOCT";

			dgvDmSoCt.BuildGridView(this.isLookup);

			this.Controls.Add(dgvDmSoCt);            
		}

		#endregion

		#region FillData
		void FillData()
		{
			dtDmSoCt = DataTool.SQLGetDataTable("SYSDMSOCT", null, null, null);

			bdsDmSoCt.DataSource = dtDmSoCt;
			dgvDmSoCt.DataSource = bdsDmSoCt;

			if (this.strMa_Ct != string.Empty)
				bdsDmSoCt.Filter = "Ma_Ct = '" + strMa_Ct + "'";

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmSoCt;

			bdsDmSoCt.Position = 0;

		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{

			if (bdsDmSoCt.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmSoCt.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmSoCt.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmSoCt.NewRow();

			frmDmSoCt_Edit frmEdit = new frmDmSoCt_Edit();
			frmEdit.Load(enuNew_Edit, ref drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmSoCt.Position >= 0)
						dtDmSoCt.ImportRow(drCurrent);
					else
						dtDmSoCt.Rows.Add(drCurrent);

					bdsDmSoCt.Position = bdsDmSoCt.Find("IDENT00", drCurrent["IDENT00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmSoCt.Current).Row);

				dtDmSoCt.AcceptChanges();
			}
			else
				dtDmSoCt.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmSoCt.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmSoCt.Current).Row;

			if (!EpointMessage.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("SYSDMSOCT", drCurrent))
			{
				bdsDmSoCt.RemoveAt(bdsDmSoCt.Position);
				dtDmSoCt.AcceptChanges();
			}
		}

		#endregion 

		#region Su kien

		private void KeyDownEvent(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F8:
					Delete();
					break;	
			}
		}

		private void ResizeEvent(object sender, EventArgs e)
		{
			dgvDmSoCt.ResizeGridView();
		}
        
        #endregion
    }
}	