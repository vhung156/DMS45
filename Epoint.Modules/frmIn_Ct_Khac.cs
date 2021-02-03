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
	public partial class frmIn_Ct_Khac : Epoint.Systems.Customizes.frmEdit
	{
        public string strMa_Ct = "";
        public bool Is_Design = false;
        public string strMa_Mau = string.Empty;
        public int iSo_Lien = 1;
        
        public frmIn_Ct_Khac()
		{
			InitializeComponent();
			btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);			
		}

		public void Load(DataRow drViewPh)
		{
            this.drEdit = drViewPh;
            strMa_Ct = drViewPh["Ma_Ct"].ToString();

			Common.ScaterMemvar(this, ref drViewPh);
			
			BindingLanguage();			
            
            string strKey = "Is_SuDung = 1 AND Ma_Ct = '" + strMa_Ct + "'";
            DataTable dtDmMauIn = DataTool.SQLGetDataTable("SYSDMMAUCT", "*", strKey, "Ma_Mau");            

            cboMau_In.DataSource = dtDmMauIn;
            cboMau_In.DisplayMember = "Ten_Mau";
            cboMau_In.ValueMember = "Ma_Mau";            

			this.ShowDialog();
		}
        private bool Save()
        {
            Common.GatherMemvar(this, ref drEdit);
            
            string strTable_Ph = DataTool.SQLGetNameByCode("SYSDMCT", "Ma_Ct", "Table_Ph", (string)drEdit["Ma_Ct"]);
            string strKey = "Ma_Dvcs = '" + Element.sysMa_DvCs + "'" + " AND Ma_Ct = '" + strMa_Ct + "'";

            //In thông tin chữ ký
            string strName1 = string.Empty;
            string strName2 = string.Empty;
            string strName3 = string.Empty;
            string strName4 = string.Empty;
            string strName5 = string.Empty;
            
            DataTable dtDmCk = DataTool.SQLGetDataTable("SYSDMCK", "*", strKey, "Ma_Ct");
            if (dtDmCk != null)
            {
                foreach (DataRow drDmCk in dtDmCk.Rows)
                {
                    strName1 = drDmCk["Name1"].ToString();
                    strName2 = drDmCk["Name2"].ToString();
                    strName3 = drDmCk["Name3"].ToString();
                    strName4 = drDmCk["Name4"].ToString();
                    strName5 = drDmCk["Name5"].ToString();
                }
            }
            
            //Cập nhật thông tin chữ ký xuống GLVOUCHER
            string strSQLUpdate = "UPDATE " + strTable_Ph + " SET " +
                    @"Chu_Ky_1 = @Chu_Ky_1, Chu_Ky_2 = @Chu_Ky_2, Chu_Ky_3 = @Chu_Ky_3, Chu_Ky_4 = @Chu_Ky_4, Chu_Ky_5 = @Chu_Ky_5" +
                    " WHERE Stt = @Stt";

            Hashtable ht = new Hashtable();
            ht["CHU_KY_1"] = strName1;
            ht["CHU_KY_2"] = strName2;
            ht["CHU_KY_3"] = strName3;
            ht["CHU_KY_4"] = strName4;
            ht["CHU_KY_5"] = strName5;
            ht["STT"] = drEdit["Stt"];

            return SQLExec.Execute(strSQLUpdate, ht, CommandType.Text);
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
			isAccept = false;
			this.Close();
		}
      
	}
}
