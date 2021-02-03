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
	public partial class frmIn_Ct_HD : Epoint.Systems.Customizes.frmEdit
	{
        public string strMa_Ct = "";
        public bool Is_Design = false;
        public string strMa_Mau = string.Empty;
        public int iSo_Lien = 1;
        
        public frmIn_Ct_HD()
		{
			InitializeComponent();
			btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);			
		}

		public void Load(DataRow drViewPh)
		{
			this.drEdit = drViewPh;

			Common.ScaterMemvar(this, ref drViewPh);
			
			BindingLanguage();
			LoadDicName();

			if (txtTk_Nh_B.Text == string.Empty)
			{
				DataRow drDmDt = DataTool.SQLGetDataRowByID("LIDOITUONG", "Ma_Dt", (string)drViewPh["Ma_Dt"]);

				if (drDmDt != null)
				{
					txtTk_Nh_B.Text = (string)drDmDt["So_Tk_NH"];
					txtTen_NH_B.Text = (string)drDmDt["Ten_NH"];
				}
			}

			//string strChon_Hoa_Don = Common.GetBufferValue("CHON_HOA_DON_IN");
            
            string strKey = "Is_SuDung = 1 AND Ma_Ct = '" + strMa_Ct + "'";
            DataTable dtDmMauIn = DataTool.SQLGetDataTable("SYSDMMAUCT", "*", strKey, "Ten_Mau");

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
            Common.GatherMemvar(this, ref drEdit);

            string strTable_Ph = DataTool.SQLGetNameByCode("SYSDMCT", "Ma_Ct", "Table_Ph", (string)drEdit["Ma_Ct"]);
			//Cập nhật thông tin xuống GLVOUCHER
			string strSQLUpdate = "UPDATE " + strTable_Ph + " SET " +
                    @"Tk_Nh_B = @Tk_Nh_B, Ten_Nh_B = @Ten_Nh_B, Pt_Tt = @Pt_Tt,Dia_Chi_Gh = @Dia_Chi_Gh,Dia_Chi_Nh = @Dia_Chi_Nh,
                    So_Van_Don =@So_Van_Don , So_Container =@So_Container,Ten_Dv_Vc = @Ten_Dv_Vc" +
					" WHERE Stt = @Stt";

			Hashtable ht = new Hashtable();
			ht["TK_NH_B"] = txtTk_Nh_B.Text;
			ht["TEN_NH_B"] = txtTen_NH_B.Text;
			ht["PT_TT"] = txtPt_Tt.Text;
            ht["DIA_CHI_GH"] = txtDia_Chi_Gh.Text;
            ht["DIA_CHI_NH"] = txtDia_Chi_Nh.Text;
            ht["SO_VAN_DON"] = txtSo_Van_Don.Text;
            ht["SO_CONTAINER"] = txtSo_Container.Text;
            ht["TEN_DV_VC"] = txtTen_Dv_Vc.Text;

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
