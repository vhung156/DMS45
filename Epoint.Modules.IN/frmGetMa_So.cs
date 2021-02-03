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
using Epoint.Systems.Elements;

namespace Epoint.Modules.IN
{
	public partial class frmGetMa_So: Epoint.Systems.Customizes.frmView
	{

		#region Khai bao bien
		public DataTable dtViewCt;
		BindingSource bdsViewCt = new BindingSource();
		
		string strMa_Ct = string.Empty;
		string strKey = string.Empty;
        public string strMa_So = string.Empty;

		#endregion 						

		#region Contructor

		public frmGetMa_So()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public void Load()
		{			
			Build();
			FillData();
			BindingLanguage();
            			
			ShowDialog();		  
		}	
		
		#endregion

		#region Build, FillData
		private void Build()
		{			
			dgvViewCt.strZone = "INHERIT_VOUCHER";
			dgvViewCt.BuildGridView(this.isLookup);

			this.Controls.Add(dgvViewCt);
			dgvViewCt.ReadOnly = false;
		}

		private void FillData()
		{
			bdsViewCt = new BindingSource();
			
            string strSelect = @"SELECT *, CAST(0 AS BIT) AS Chon FROM GLVOUCHER WHERE Ma_Ct = 'SO'";

            dtViewCt = SQLExec.ExecuteReturnDt(strSelect);
            
            bdsViewCt.DataSource = dtViewCt;
			dgvViewCt.DataSource = bdsViewCt;

			bdsViewCt.Position = 0;

			foreach (DataGridViewColumn dgvc in dgvViewCt.Columns)
				dgvc.ReadOnly = true;

			dgvViewCt.Columns["Chon"].ReadOnly = false;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsViewCt;
		}    

		#endregion		

		#region Su kien	

		protected override void OnKeyDown(KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Space:
					DataRow drCurrent = ((DataRowView)bdsViewCt.Current).Row;
					drCurrent["Chon"] = !(bool)drCurrent["Chon"];
					break;
			}

			if (e.Control)
			{
				switch (e.KeyCode)
				{
					case Keys.A:
						foreach (DataRow dr in dtViewCt.Rows)
							dr["Chon"] = true;
						break;
					case Keys.U:
						foreach (DataRow dr in dtViewCt.Rows)
							dr["Chon"] = false;
						break;
				}
			}

			base.OnKeyDown(e);
		}

		void btAccept_Click(object sender, EventArgs e)
		{
            DataRow[] drChonCt = dtViewCt.Select("Chon = true");

            foreach (DataRow drViewCt in drChonCt)
            {
                strMa_So = drViewCt["So_Ct"].ToString();
            }

            this.Close();
		}
		void btCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		#endregion 
	}
}