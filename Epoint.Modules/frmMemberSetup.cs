using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Elements;

namespace Epoint.Modules
{
	public partial class frmMemberSetup : Epoint.Systems.Customizes.frmView
	{
		#region Khai bao bien

        private DataTable dtMember;
		private DataRow drCurrent;
		private BindingSource bdsDmDvCs = new BindingSource();
		private lvControl lvDmDvCs = new lvControl();

		#endregion 						

		#region Contructor

        public frmMemberSetup()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(KeyDownEvent);

			this.lvDmDvCs.Resize += new EventHandler(lvDmDvCs_Resize);
			//this.lvDmDvCs.MouseDoubleClick += new MouseEventHandler(lvDmDvCs_MouseDoubleClick);
		}

		public override void Load()
		{
			Build();
			FillData();
			BindingLanguage();

			if (this.lvDmDvCs.Items.ContainsKey(Element.sysMa_DvCs))
			{
				this.lvDmDvCs.Items[Element.sysMa_DvCs].Focused = true;
				this.lvDmDvCs.Items[Element.sysMa_DvCs].Selected = true;
			}

			this.Show();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			lvDmDvCs.Location = new Point(3, 3);
			lvDmDvCs.Size = new Size(this.Size.Width - 12, this.Size.Height - 12);
			lvDmDvCs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lvDmDvCs.FullRowSelect = true;
			lvDmDvCs.GridLines = true;
			lvDmDvCs.HideSelection = false;

			lvDmDvCs.strZone = "SETUPMEMBER";
			lvDmDvCs.BuildListView(this.isLookup);

			this.Controls.Add(lvDmDvCs);
		}		

		private void FillData()
		{
            dtMember = SQLExec.ExecuteReturnDt("SELECT Member_ID,Member_Name,ma_kho_access,ma_ct_access,Ma_Cbnv_Access,Ma_Kho_Ban FROM SYSMEMBER WHERE Member_Type = 'U' ORDER BY Member_ID");

            bdsDmDvCs.DataSource = dtMember;
			lvDmDvCs.DataSource = bdsDmDvCs;
			bdsDmDvCs.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmDvCs;
		}
		
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (!lvDmDvCs.MoveDataSourceToCurrentRow())
				return;

			if (bdsDmDvCs.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmDvCs.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmDvCs.Current).Row, ref drCurrent);
			else
                drCurrent = dtMember.NewRow();

			frmMemberSetup_Edit frmEdit = new frmMemberSetup_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New && bdsDmDvCs.Position < 0)
				{
					if (bdsDmDvCs.Position >= 0)
                        dtMember.ImportRow(drCurrent);
					else
                        dtMember.Rows.Add(drCurrent);

					bdsDmDvCs.Position = bdsDmDvCs.Find("MA_DVCS", drCurrent["MA_DVCS"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmDvCs.Current).Row);

                dtMember.AcceptChanges();

				//Cap nhat vao ListView
				lvDmDvCs.UpdateRowToListViewItem(enuNew_Edit, drCurrent);
			}
			else
                dtMember.RejectChanges();
		}

        

		#endregion 
	

		#region Su kien

		void KeyDownEvent(object sender, KeyEventArgs e)
		{
			
		}

		void lvDmDvCs_Resize(object sender, EventArgs e)
		{
			this.lvDmDvCs.ResizeListView();
		}

		#endregion 
	}
}
