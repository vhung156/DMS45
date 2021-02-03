using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;
using Epoint.Systems.Commons;
using Epoint.Lists;

namespace Epoint.Modules.POS
{
	public partial class frmCustomer_Edit : Epoint.Systems.Customizes.frmEdit
	{
		public frmCustomer_Edit()
		{
			InitializeComponent();

			txtMa_CbNv.Validating += new CancelEventHandler(txtMa_CbNv_Validating);
			txtMa_Kv.Validating += new CancelEventHandler(txtMa_Kv_Validating);
			txtMa_Nh_Dt.Validating += new CancelEventHandler(txtMa_Nh_Dt_Validating);

			txtSP_Used.Validating += new CancelEventHandler(txtSP_Used_Validating);
			txtVon_CSH.Validating += new CancelEventHandler(txtVon_CSH_Validating);
			txtNganh_Nghe.Validating += new CancelEventHandler(txtNganh_Nghe_Validating);
			txtQuy_Mo.Validating += new CancelEventHandler(txtQuy_Mo_Validating);

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		void FillComboBox()
		{
			//cboSP_Used.DataSource = bdsType;
			//cboSP_Used.DisplayMember = "Type_Name";
			//cboSP_Used.ValueMember
		}

		void LoadDicName()
		{
			//Khu vực
			if (txtMa_Kv.Text.Trim() != string.Empty)
			{
				lbtTen_Kv.Text = (string)SQLExec.ExecuteReturnValue("SELECT Ten_Kv FROM LIKHUVUC WHERE Ma_Kv = '" + txtMa_Kv.Text + "'");
			}
			else
				lbtTen_Kv.Text = string.Empty;

			//SP_Used
			if (txtSP_Used.Text.Trim() != string.Empty)
			{
				lbtSP_Used.Text = (string)SQLExec.ExecuteReturnValue("SELECT Type_Name FROM LIKHAC WHERE Type = 'SP_USED' AND Type_ID = '" + txtSP_Used.Text + "'");				
			}
			else
				lbtSP_Used.Text = string.Empty;

			//Von_CSH
			if (txtVon_CSH.Text.Trim() != string.Empty)
			{
				lbtVon_CSH.Text = (string)SQLExec.ExecuteReturnValue("SELECT Type_Name FROM LIKHAC WHERE Type = 'VON_CSH' AND Type_ID = '" + txtVon_CSH.Text + "'");
			}
			else
				lbtVon_CSH.Text = string.Empty;

			//Nganh_Nghe
			if (txtNganh_Nghe.Text.Trim() != string.Empty)
			{
				lbtNganh_Nghe.Text = (string)SQLExec.ExecuteReturnValue("SELECT Type_Name FROM LIKHAC WHERE Type = 'NGANH_NGHE' AND Type_ID = '" + txtNganh_Nghe.Text + "'");
			}
			else
				lbtNganh_Nghe.Text = string.Empty;

			//Quy_Mo
			if (txtQuy_Mo.Text.Trim() != string.Empty)
			{
				lbtQuy_Mo.Text = (string)SQLExec.ExecuteReturnValue("SELECT Type_Name FROM LIKHAC WHERE Type = 'QUY_MO' AND Type_ID = '" + txtQuy_Mo.Text + "'");
			}
			else
				lbtQuy_Mo.Text = string.Empty;
		}

		bool FormCheckValid()
		{
			return true;
		}

		bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			////Tính Stt Max
			//if (enuNew_Edit == enuEdit.New)
			//    CRMLib.GetNewMa_Dt(drEdit);

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "LIDOITUONG", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_DT", drEdit);

			return true;
		}

		void txtMa_CbNv_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_CbNv.Text.Trim();
			bool bRequire = false;

			frmNhanVien frmLookup = new frmNhanVien();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LINHANVIEN", "Ma_CbNv", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_CbNv.Text = string.Empty;
				lbtTen_Cbnv.Text = string.Empty;
			}
			else
			{
				txtMa_CbNv.Text = drLookup["Ma_CbNv"].ToString();
				lbtTen_Cbnv.Text = drLookup["Ten_CbNv"].ToString();
			}

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}
		void txtMa_Kv_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Kv.Text.Trim();
			bool bRequire = false;

			frmKhuVuc frmLookup = new frmKhuVuc();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIKHUVUC", "Ma_Kv", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Kv.Text = string.Empty;
				lbtTen_Kv.Text = string.Empty;
			}
			else
			{
				txtMa_Kv.Text = drLookup["Ma_Kv"].ToString();
				lbtTen_Kv.Text = drLookup["Ten_Kv"].ToString();
			}

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}
		void txtMa_Nh_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nh_Dt.Text.Trim();
			bool bRequire = false;

			frmDoiTuongNh frmLookup = new frmDoiTuongNh();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIDOITUONGNH", "Ma_Nh_Dt", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nh_Dt.Text = string.Empty;
				lbtTen_Nh_Dt.Text = string.Empty;
			}
			else
			{
				txtMa_Nh_Dt.Text = drLookup["Ma_Nh_Dt"].ToString();
				lbtTen_Nh_Dt.Text = drLookup["Ten_Nh_Dt"].ToString();
			}

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}		

		void txtSP_Used_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtSP_Used.Text.Trim();
			bool bRequire = false;

			frmKhac frmLookup = new frmKhac();
			frmLookup.strType = "SP_USED";
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIKHAC", "Type_ID", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtSP_Used.Text = string.Empty;
				lbtSP_Used.Text = string.Empty;
			}
			else
			{
				txtSP_Used.Text = drLookup["Type_ID"].ToString();
				lbtSP_Used.Text = drLookup["Type_Name"].ToString();
			}

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

		void txtQuy_Mo_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtQuy_Mo.Text.Trim();
			bool bRequire = false;

			frmKhac frmLookup = new frmKhac();
			frmLookup.strType = "QUY_MO";
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIKHAC", "Type_ID", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtQuy_Mo.Text = string.Empty;
				lbtQuy_Mo.Text = string.Empty;
			}
			else
			{
				txtQuy_Mo.Text = drLookup["Type_ID"].ToString();
				lbtQuy_Mo.Text = drLookup["Type_Name"].ToString();
			}
		}

		void txtNganh_Nghe_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtNganh_Nghe.Text.Trim();
			bool bRequire = false;

			frmKhac frmLookup = new frmKhac();
			frmLookup.strType = "NGANH_NGHE";
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIKHAC", "Type_ID", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtNganh_Nghe.Text = string.Empty;
				lbtNganh_Nghe.Text = string.Empty;
			}
			else
			{
				txtNganh_Nghe.Text = drLookup["Type_ID"].ToString();
				lbtNganh_Nghe.Text = drLookup["Type_Name"].ToString();
			}
		}

		void txtVon_CSH_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtVon_CSH.Text.Trim();
			bool bRequire = false;

			frmKhac frmLookup = new frmKhac();
			frmLookup.strType = "VON_CSH";
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIKHAC", "Type_ID", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtVon_CSH.Text = string.Empty;
				lbtVon_CSH.Text = string.Empty;
			}
			else
			{
				txtVon_CSH.Text = drLookup["Type_ID"].ToString();
				lbtVon_CSH.Text = drLookup["Type_Name"].ToString();
			}
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				this.isAccept = true;
				this.Close();
			}
		}
		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}
	}
}
