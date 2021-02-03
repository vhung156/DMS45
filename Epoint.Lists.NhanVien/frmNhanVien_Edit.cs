using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Data;
using Epoint.Systems.Librarys;
using Epoint.Lists;
using Epoint.Systems;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;

namespace Epoint.Lists
{
	public partial class frmNhanVien_Edit : Epoint.Lists.frmEdit
	{	

		#region Phuong thuc

		public frmNhanVien_Edit()
		{
			InitializeComponent();

			txtMa_Bp.Enter += new EventHandler(txtMa_Bp_Enter);
			txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
            txtMa_Dt_Tu.Validating += new CancelEventHandler(txtMa_Dt_Tu_Validating);
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);
			
			LoadDicName();
			BindingLanguage();

			this.ShowDialog();
		}

		public void LoadDicName()
		{
			if (txtMa_Bp.Text.Trim() != string.Empty)
			{
				lbtTen_Bp.Text = DataTool.SQLGetNameByCode("LIBOPHAN", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
				dicName.Add(lbtTen_Bp.Name, lbtTen_Bp.Text);
			}
			else
				lbtTen_Bp.Text = string.Empty;

            if (txtMa_CbNv_Lead.Text.Trim() != string.Empty)
            {
                lbtTen_Bp.Text = DataTool.SQLGetNameByCode("LINhanvien", "Ma_CbNv", "Ten_Cbnv", txtMa_CbNv_Lead.Text.Trim());
                dicName.Add(lbtTen_CbNv_Lead.Name, lbtTen_CbNv_Lead.Text);
            }
            else
                lbtTen_CbNv_Lead.Text = string.Empty;
		}

		public override bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtMa_CbNv.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_CbNv") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}			

			if (txtTen_CbNv.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_CbNv") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			return bvalid;
		}

		public override bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Kiem tra Valid CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "LINHANVIEN", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_CBNV", drEdit);

			return true;
		}

		#endregion 

		#region Su kien

		private void txtMa_Bp_Enter(object sender, EventArgs e)
		{
			lbtTen_Bp.Text = dicName.GetValue(lbtTen_Bp.Name);
		}

		void txtMa_Bp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Bp.Text.Trim();
			bool bRequire = false;

            frmBoPhan frmLookup = new frmBoPhan();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIBOPHAN", "Ma_Bp", strValue, bRequire, "", "Nh_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{				
				lbtTen_Bp.Text = string.Empty;
			}
			else
			{
				txtMa_Bp.Text = ((string)drLookup["Ma_Bp"]).Trim();
				lbtTen_Bp.Text = ((string)drLookup["Ten_Bp"]).Trim();
			}

			dicName.SetValue(lbtTen_Bp.Name, lbtTen_Bp.Text);
		}

        void txtMa_Dt_Tu_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_Tu.Text.Trim();
            bool bRequire = false;

            frmDoiTuong frmLookup = new frmDoiTuong();
            DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIDOITUONG", "Ma_Dt", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                lbtMa_Dt_Tu.Text = string.Empty;                
            }
            else
            {
                txtMa_Dt_Tu.Text = ((string)drLookup["Ma_Dt"]).Trim();
                lbtMa_Dt_Tu.Text = ((string)drLookup["Ten_Dt"]).Trim();
            }

            dicName.SetValue(lbtMa_Dt_Tu.Name, lbtMa_Dt_Tu.Text);
        }

		#endregion
	}
}