using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;

namespace Epoint.Modules
{
	public partial class frmDesign_Mau_Ct : Epoint.Systems.Customizes.frmEdit
	{        
        public bool Is_Design = false;
        public string strMa_Ct = "";
        public string strList_Report = "";
        public string strMa_Mau = string.Empty;
        public int iSo_Lien = 1;

        public frmDesign_Mau_Ct()
		{
			InitializeComponent();

            this.KeyDown += new KeyEventHandler(frmChonmau_CT_UNC_KeyDown);	
			btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);			
		}

		public void Load()
		{
			BindingLanguage();
			LoadDicName();

            BindingLanguage();
            LoadDicName();

            DataTable dtDmMauIn = DataTool.SQLGetDataTable("SYSDMMAUCT", "*", "Is_SuDung = 1 AND Ma_Ct = '" + strMa_Ct + "'", "Ma_Mau");

            cboMau_In.DataSource = dtDmMauIn;
            cboMau_In.DisplayMember = "Ten_Mau";
            cboMau_In.ValueMember = "Ma_Mau";           

            this.ShowDialog();
		}

		private void LoadDicName()
		{
			
		}

		private bool Save()
		{
            return true;
		}

		private void btAccept_Click(object sender, EventArgs e)
		{			
            if (this.Save())
            {
                if (cboMau_In.SelectedItem != null)
                {
                    strMa_Mau = (string)((DataRowView)cboMau_In.SelectedItem)["Ma_Mau"];
                    iSo_Lien = Convert.ToInt16(((DataRowView)cboMau_In.SelectedItem)["So_Lien"]);
                }

                Is_Design = true;
                this.Close();
            }
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
            Is_Design = false;
            this.Close();
		}
        void frmChonmau_CT_UNC_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Escape:
                    {
                        Is_Design = false;
                        this.Close();
                    }
                    break;
            }

        }

	}
}
