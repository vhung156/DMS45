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
using Epoint.Lists;

namespace Epoint.Modules.AR
{
	public partial class frmDiscountProg_Edit : Epoint.Systems.Customizes.frmEdit
	{
        public frmDiscountProg_Edit()
		{
			InitializeComponent();

            this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            this.cbxHinh_Thuc_Km.SelectedValueChanged += new EventHandler(cbxHinh_Thuc_Km_SelectedValueChanged);
		}

        void cbxHinh_Thuc_Km_SelectedValueChanged(object sender, EventArgs e)
        {
            string strHinh_Thuc_Km = cbxHinh_Thuc_Km.SelectedValue.ToString();
            if (strHinh_Thuc_Km == "IN")
            {
                numTSo_Luong.Enabled = true;
                numTTien.Enabled = false;
            }
            else
            {
                numTSo_Luong.Enabled = false;
                numTTien.Enabled = true;
            }

        }

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
            BindingCombobox();
			Common.ScaterMemvar(this, ref drEdit);


			BindingLanguage();
			LoadDicName();
            //BindingCombobox();

			this.ShowDialog();
		}
        private void BindingCombobox()
        {
            cbxLoai_KM.DataSource = SQLExec.ExecuteReturnDt(" sp_OM_GetCombovalue @Key = 'DiscountType'", CommandType.Text);
            cbxLoai_KM.ValueMember = "ID";
            cbxLoai_KM.DisplayMember = "Value";

            cbxLoai_Ap_Km.DataSource = SQLExec.ExecuteReturnDt(" sp_OM_GetCombovalue @Key = 'DiscountAply'", CommandType.Text);
            cbxLoai_Ap_Km.ValueMember = "ID";
            cbxLoai_Ap_Km.DisplayMember = "Value";


            cbxBreakBy.DataSource = SQLExec.ExecuteReturnDt(" sp_OM_GetCombovalue @Key = 'DiscountBreakBy'", CommandType.Text);
            cbxBreakBy.ValueMember = "ID";
            cbxBreakBy.DisplayMember = "Value";


            cbxHinh_Thuc_Km.DataSource = SQLExec.ExecuteReturnDt(" sp_OM_GetCombovalue @Key = 'DiscountFor'", CommandType.Text);
            cbxHinh_Thuc_Km.ValueMember = "ID";
            cbxHinh_Thuc_Km.DisplayMember = "Value";

        }
		private void LoadDicName()
		{

		}

		private bool FormCheckValid()
		{
			if (txtMa_CTKM.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_CTKM") + " " +
						Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtTen_CTKM.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_CTKM") + " " +
						Languages.GetLanguage("Not_Null"));
				return false;
			}			

			return true;
		}

		private bool Save()
		{
            if (cbxHinh_Thuc_Km.SelectedValue.ToString() == "IN")
                numTTien.Value = 0;
            else
                numTSo_Luong.Value = 0;

			Common.GatherMemvar(this, ref drEdit);

            drEdit["Ten_Loai_Km"] = cbxLoai_KM.Text;
            drEdit["Ten_BreakBy"] = cbxBreakBy.Text;
            drEdit["Ten_Hinh_Thuc_KM"] = cbxHinh_Thuc_Km.Text;
            drEdit["Ten_Loai_Ap_Km"] = cbxLoai_Ap_Km.Text;


			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;
            


			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "OM_Discount", ref drEdit))
				return false;

			return true;
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
