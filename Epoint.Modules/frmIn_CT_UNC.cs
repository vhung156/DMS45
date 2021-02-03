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
	public partial class frmIn_CT_UNC : Epoint.Systems.Customizes.frmEdit
	{
        public int iSo_Lien = 1;

        public frmIn_CT_UNC()
		{
			InitializeComponent();
			btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);			
		}

		public void Load(DataRow drEdit)
		{
			this.drEdit = drEdit;

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

            DataTable dtDmMauIn = DataTool.SQLGetDataTable("SYSDMMAUCT", "*", "Is_SuDung = 1 AND Ma_Ct = 'BN'", "Ten_Mau");
            cboMau_In.DataSource = dtDmMauIn;

            cboMau_In.DisplayMember = "Ten_Mau";
            cboMau_In.ValueMember = "Ma_Mau";

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			string strTk_Nh = (string)drEdit["Tk_Nh"];
			string strMa_Dt = (string)drEdit["Ma_Dt"];

			if (txtTk_NH_A.Text == string.Empty)
			{
				DataRow drDmTk = DataTool.SQLGetDataRowByID("LITAIKHOAN", "Tk", strTk_Nh);

				if (drDmTk != null)
				{
					txtTk_NH_A.Text = (string)drDmTk["So_Tk_Nh"];
					txtTen_Dv_A.Text = Element.sysTen_Dvi;
					txtTen_NH_A.Text = (string)drDmTk["Ten_Tk_Nh"];
					txtTen_TP_A.Text = (string)drDmTk["Ten_Tp_Nh"];
				}
			}

			if (txtTk_NH_B.Text == string.Empty)
			{
				DataRow drDmDt = DataTool.SQLGetDataRowByID("LIDOITUONG", "Ma_Dt", strMa_Dt);

				if (drDmDt != null)
				{
					txtTk_NH_B.Text = (string)drDmDt["So_Tk_NH"];
					txtTen_Dv_B.Text = (string)drDmDt["Ten_Dt"];
					txtTen_NH_B.Text = (string)drDmDt["Ten_NH"];
					txtTen_TP_B.Text = (string)drDmDt["Ten_TP"];
				}
			}
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			string strTable_Ph = DataTool.SQLGetNameByCode("SYSDMCT", "Ma_Ct", "Table_Ph", (string)drEdit["Ma_Ct"]);

			//Cập nhật thông tin xuống GLVOUCHER
			string strSQLUpdate = "UPDATE " + strTable_Ph + " SET " +
					" Ten_Dv_A = @Ten_Dv_A, Ten_Nh_A = @Ten_Nh_A, Tk_Nh_A = @Tk_Nh_A, Ten_Tp_A = @Ten_Tp_A, So_CMND_A = @So_CMND_A, Ngay_Cap_A = @Ngay_Cap_A, Noi_Cap_A = @Noi_Cap_A, " +
					" Ten_Dv_B = @Ten_Dv_B, Ten_Nh_B = @Ten_Nh_B, Tk_Nh_B = @Tk_Nh_B, Ten_Tp_B = @Ten_Tp_B, So_CMND_B = @So_CMND_B, Ngay_Cap_B = @Ngay_Cap_B, Noi_Cap_B = @Noi_Cap_B " +
				" WHERE Stt = @Stt";

			Hashtable ht = new Hashtable();
			ht["TEN_DV_A"] = txtTen_Dv_A.Text;
			ht["TEN_NH_A"] = txtTen_NH_A.Text;
			ht["TK_NH_A"] = txtTk_NH_A.Text;
			ht["TEN_TP_A"] = txtTen_TP_A.Text;
			ht["SO_CMND_A"] = txtSo_CMND_A.Text;
			ht["NGAY_CAP_A"] = Library.StrToDate(dteNgay_Cap_A.Text);
			ht["NOI_CAP_A"] = txtNoi_Cap_A.Text;

			ht["TEN_DV_B"] = txtTen_Dv_B.Text;
			ht["TEN_NH_B"] = txtTen_NH_B.Text;
			ht["TK_NH_B"] = txtTk_NH_B.Text;
			ht["TEN_TP_B"] = txtTen_TP_B.Text;
			ht["SO_CMND_B"] = txtSo_CMND_B.Text;
			ht["NGAY_CAP_B"] = Library.StrToDate(dteNgay_Cap_B.Text);
			ht["NOI_CAP_B"] = txtNoi_Cap_B.Text;
			ht["STT"] = drEdit["Stt"];

			return SQLExec.Execute(strSQLUpdate, ht, CommandType.Text);
		}

		private void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				isAccept = true;
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
