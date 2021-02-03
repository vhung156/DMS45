using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Data;
using Epoint.Systems.Librarys;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;

namespace Epoint.Lists
{
    public partial class frmVatTu_Edit : Epoint.Lists.frmEdit
	{
		#region Phuong thuc

		public frmVatTu_Edit()
		{
			InitializeComponent();

			txtMa_Nh_Vt.Validating += new CancelEventHandler(txtMa_Nh_Vt_Validating);
            txtMa_Vc.Validating += new CancelEventHandler(txtMa_Vc_Validating);
			txtTk_Vt.Validating += new CancelEventHandler(txtTk_Vt_Validating);
			txtTk_Dt.Validating += new CancelEventHandler(txtTk_Dt_Validating);
			txtTk_Gv.Validating += new CancelEventHandler(txtTk_Gv_Validating);
			txtTk_Hbtl.Validating += new CancelEventHandler(txtTk_Hbtl_Validating);
			txtMa_Sp.Validating += new CancelEventHandler(txtMa_Sp_Validating);

			enuLoai_Vt.Validated += new EventHandler(txtLoai_Vt_Validated);
			txtMa_Vt.TextChanged += new EventHandler(txtMa_Vt_TextChanged);
			txtMa_Sp.Enter += new EventHandler(txtMa_Sp_Enter);
            chkIs_VoChai.CheckedChanged += new EventHandler(chkIs_VoChai_CheckedChanged);
		}

        void chkIs_VoChai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIs_VoChai.Checked)
            {
                txtMa_Vc.Enabled = true;
            }
            else
            {
                txtMa_Vc.Enabled = false;
            }
        }

		void txtMa_Sp_Enter(object sender, EventArgs e)
		{
			if (enuLoai_Vt.Text != "1")
				txtMa_Sp.Text = "";
		}

		void txtMa_Vt_TextChanged(object sender, EventArgs e)
		{
			if (enuNew_Edit == enuEdit.New)
			{
				txtMa_Sp.Text = txtMa_Vt.Text;
			}
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();
			this.Loai_Vt_Valid();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			//Ma_Nh_Vt
			if (txtMa_Nh_Vt.Text.Trim() != string.Empty)
			{
				lbtTen_Nh_Vt.Text = DataTool.SQLGetNameByCode("LIVATTUNH", "Ma_Nh_Vt", "Ten_Nh_Vt", txtMa_Nh_Vt.Text.Trim());
				dicName.Add(lbtTen_Nh_Vt.Name, lbtTen_Nh_Vt.Text);
			}
			else
				lbtTen_Nh_Vt.Text = string.Empty;

			//Tk_Vt
			if (txtTk_Vt.Text.Trim() != string.Empty)
			{
				lbtTen_Tk_Vt.Text = DataTool.SQLGetNameByCode("LITAIKHOAN", "Tk", "Ten_Tk", txtTk_Vt.Text.Trim());
				dicName.Add(lbtTen_Tk_Vt.Name, lbtTen_Tk_Vt.Text);
			}
			else
				lbtTen_Tk_Vt.Text = string.Empty;

			//Tk_Gv
			if (txtTk_Gv.Text.Trim() != string.Empty)
			{
				lbtTen_Tk_Gv.Text = DataTool.SQLGetNameByCode("LITAIKHOAN", "Tk", "Ten_Tk", txtTk_Gv.Text.Trim());
				dicName.Add(lbtTen_Tk_Gv.Name, lbtTen_Tk_Gv.Text);
			}
			else
				lbtTen_Tk_Gv.Text = string.Empty;

			//Tk_Dt
			if (txtTk_Dt.Text.Trim() != string.Empty)
			{
				lbtTen_Tk_Dt.Text = DataTool.SQLGetNameByCode("LITAIKHOAN", "Tk", "Ten_Tk", txtTk_Dt.Text.Trim());
				dicName.Add(lbtTen_Tk_Dt.Name, lbtTen_Tk_Dt.Text);
			}
			else
				lbtTen_Tk_Dt.Text = string.Empty;

			//Tk_HbTl
			if (txtTk_Hbtl.Text.Trim() != string.Empty)
			{
				lbtTen_Tk_Hbtl.Text = DataTool.SQLGetNameByCode("LITAIKHOAN", "Tk", "Ten_Tk", txtTk_Hbtl.Text.Trim());
				dicName.Add(lbtTen_Tk_Hbtl.Name, lbtTen_Tk_Hbtl.Text);
			}
			else
				lbtTen_Tk_Hbtl.Text = string.Empty;

			//Ma_Sp
			if (txtMa_Sp.Text.Trim() != string.Empty)
			{
				lbtTen_Sp.Text = DataTool.SQLGetNameByCode("LISANPHAM", "Ma_Sp", "Ten_Sp", txtMa_Sp.Text.Trim());
				dicName.Add(lbtTen_Sp.Name, lbtTen_Sp.Text);
			}
			else
				lbtTen_Sp.Text = string.Empty;
            //Thue
			if (txtMa_Thue_Out.Text.Trim() != string.Empty)
			{
                lbtTen_thue_Out.Text = DataTool.SQLGetNameByCode("LiThue", "Ma_thue", "Ten_Thue", txtMa_Thue_Out.Text.Trim());
                dicName.Add(lbtTen_thue_Out.Name, lbtTen_thue_Out.Text);
			}
			else
                lbtTen_thue_Out.Text = string.Empty;

            if(chkIs_VoChai.Checked)
            {
                txtMa_Vc.Enabled = true;
            }
            else
            {
                txtMa_Vc.Enabled = false;
            }
			////Ma_Vt_Gt
			//if (txtMa_Vt_Gt.Text.Trim() != string.Empty)
			//{
			//    lbtTen_Vt_Gt.Text = DataTool.SQLGetNameByCode("LIVATTU", "Ma_Vt", "Ten_Vt", txtMa_Vt_Gt.Text.Trim());
			//    dicName.Add(lbtTen_Vt_Gt.Name, lbtTen_Vt_Gt.Text);
			//}
			//else
			//    lbtTen_Vt_Gt.Text = string.Empty;
		}

		private void Loai_Vt_Valid()
		{
			switch (enuLoai_Vt.Text)
			{
				case "0":
					txtTk_Vt.Enabled = false;
					txtTk_Gv.Enabled = false;
					txtMa_Sp.Enabled = false;
					break;

				case "1":
					txtTk_Vt.Enabled = true;
					txtTk_Gv.Enabled = true;
					txtMa_Sp.Enabled = true;
					break;

				case "2":
					txtTk_Vt.Enabled = true;
					txtTk_Gv.Enabled = true;
					txtMa_Sp.Enabled = false;
					break;

				default:
					break;
			}
		}

		public override bool FormCheckValid()
		{
			if (txtMa_Vt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Vt") + " " + Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtTen_Vt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Vt") + " " + Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtMa_Nh_Vt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Nh_Vt") + " " + Languages.GetLanguage("Not_Null"));
				return false;
			}

            if (chkIs_VoChai.Checked &&  txtMa_Vc.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ma_VC") + " " + Languages.GetLanguage("Not_Null"));
                return false;
            }

            if (txtDvt_MD.Text != txtDvt.Text || txtDvt_MD.Text != txtDvt1.Text)
                txtDvt_MD.Text = txtDvt.Text;


			switch (enuLoai_Vt.Text)
			{
				case "0":
					txtTk_Vt.Text = string.Empty;
					txtTk_Gv.Text = string.Empty;
					txtMa_Sp.Text = string.Empty;
					break;

				case "1":
					if (txtMa_Sp.Text == string.Empty)
					{
						Common.MsgCancel(Languages.GetLanguage("Ma_Sp") + " " + Languages.GetLanguage("Not_Empty"));
						return false;
					}
					break;

				case "3":
					txtMa_Sp.Text = string.Empty;
					break;

				default:
					break;
			}

			return true;
		}

		public override bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "LIVATTU", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_VT", drEdit);

			return true;
		}

		#endregion

		#region Su kien

		private void txtMa_Nh_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nh_Vt.Text.Trim();
			bool bRequire = true;

			frmVatTuNh frmLookup = new frmVatTuNh();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIVATTUNH", "Ma_Nh_Vt", strValue, bRequire, "Loai_Nh <> '2'", "Nh_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nh_Vt.Text = string.Empty;
				lbtTen_Nh_Vt.Text = string.Empty;
			}
			else
			{
				txtMa_Nh_Vt.Text = ((string)drLookup["Ma_Nh_Vt"]).Trim();
				lbtTen_Nh_Vt.Text = ((string)drLookup["Ten_Nh_Vt"]).Trim();


                if(drLookup.Table.Columns.Contains("Tk_Vt"))
                {
                    txtTk_Vt.Text = ((string)drLookup["Tk_Vt"]).Trim();
                    txtTk_Gv.Text = ((string)drLookup["Tk_Gv"]).Trim();
                    txtTk_Dt.Text = ((string)drLookup["Tk_Dt"]).Trim();
                    txtTk_Hbtl.Text = ((string)drLookup["Tk_Hbtl"]).Trim();
                }


			}

			dicName.SetValue(lbtTen_Nh_Vt.Name, lbtTen_Nh_Vt.Text);
		}
		private void txtTk_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk_Vt.Text.Trim();
			bool bRequire = false;

            //frmTaiKhoan frmLookup = new frmTaiKhoan();
			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk_Vt.Text = string.Empty;
				lbtTen_Tk_Vt.Text = string.Empty;
			}
			else
			{
				txtTk_Vt.Text = ((string)drLookup["Tk"]).Trim();
				lbtTen_Tk_Vt.Text = ((string)drLookup["Ten_Tk"]).Trim();
			}

			dicName.SetValue(lbtTen_Tk_Vt.Name, lbtTen_Tk_Vt.Text);
		}
		private void txtTk_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk_Dt.Text.Trim();
			bool bRequire = false;

            //frmTaiKhoan frmLookup = new frmTaiKhoan();
			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk_Dt.Text = string.Empty;
				lbtTen_Tk_Dt.Text = string.Empty;
			}
			else
			{
				txtTk_Dt.Text = ((string)drLookup["Tk"]).Trim();
				lbtTen_Tk_Dt.Text = ((string)drLookup["Ten_Tk"]).Trim();
			}

			dicName.SetValue(lbtTen_Tk_Dt.Name, lbtTen_Tk_Dt.Text);
		}
		private void txtTk_Gv_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk_Gv.Text.Trim();
			bool bRequire = false;

            //frmTaiKhoan frmLookup = new frmTaiKhoan();
			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk_Gv.Text = string.Empty;
				lbtTen_Tk_Gv.Text = string.Empty;
			}
			else
			{
				txtTk_Gv.Text = ((string)drLookup["Tk"]).Trim();
				lbtTen_Tk_Gv.Text = ((string)drLookup["Ten_Tk"]).Trim();
			}

			dicName.SetValue(lbtTen_Tk_Gv.Name, lbtTen_Tk_Gv.Text);
		}
		private void txtTk_Hbtl_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk_Hbtl.Text.Trim();
			bool bRequire = false;

            //frmTaiKhoan frmLookup = new frmTaiKhoan();
			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk_Hbtl.Text = string.Empty;
				lbtTen_Tk_Hbtl.Text = string.Empty;
			}
			else
			{
				txtTk_Hbtl.Text = ((string)drLookup["Tk"]).Trim();
				lbtTen_Tk_Hbtl.Text = ((string)drLookup["Ten_Tk"]).Trim();
			}

			dicName.SetValue(lbtTen_Tk_Hbtl.Name, lbtTen_Tk_Hbtl.Text);
		}
		private void txtMa_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Sp.Text.Trim();
			bool bRequire = enuLoai_Vt.Text == "1" ? true : false;

			if (bRequire && txtMa_Sp.Text != string.Empty) //enuNew_Edit == enuEdit.New && 
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (!DataTool.SQLCheckExist("LISANPHAM", "Ma_Sp", txtMa_Sp.Text))
					{
						string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Sản phẩm {" + txtMa_Sp.Text + "} chưa có, thêm sản phẩm này vào danh mục sản phẩm" : "Do you want to add this product in list of product";
						if (Common.MsgYes_No(strMsg))
						{
							DataTable dtDmSp = DataTool.SQLGetDataTable("LISANPHAM", "*", "0 = 1", "");
							DataRow drEditSp = dtDmSp.NewRow();

							drEditSp["Ma_Nh_Vt"] = txtMa_Nh_Vt.Text;
							drEditSp["Ma_Sp"] = txtMa_Sp.Text;
							drEditSp["Ten_Sp"] = txtTen_Vt.Text;
							drEditSp["Dvt"] = txtDvt.Text;

							DataTable dt = SQLExec.ExecuteReturnDt("SELECT * FROM LIVATTUNH WHERE Ma_Nh_Vt = '" + txtMa_Nh_Vt.Text + "' AND Loai_Nh IN ('2', '3')");
							if (dt != null && dt.Rows.Count >= 1)
							{
								DataTool.SQLUpdate(enuEdit.New, "LISANPHAM", ref drEditSp);
							}
							else
							{
                                //frmSanPham_Edit frmEdit = new frmSanPham_Edit();
                                //frmEdit.Load(enuEdit.New, drEditSp);
							}
						}
					}
				}
				else
				{
					string strMa_Sp_Old = (string)drEdit["Ma_Sp"];

					if (txtMa_Sp.Text != strMa_Sp_Old && DataTool.SQLCheckExist("LISANPHAM", "Ma_Sp", strMa_Sp_Old)) //Đã tồn tại
					{
						string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Có chắc chắn đổi mã {" + strMa_Sp_Old + "} sang mã mới {" + txtMa_Sp.Text + "}" : "Are you sure to change product code?";
						if (Common.MsgYes_No(strMsg))
						{
							DataRow drEditSp = DataTool.SQLGetDataRowByID("LISANPHAM", "Ma_Sp", strMa_Sp_Old);

							drEditSp["Ma_Nh_Vt"] = txtMa_Nh_Vt.Text;
							drEditSp["Ma_Sp"] = txtMa_Sp.Text;
							drEditSp["Ten_Sp"] = txtTen_Vt.Text;
							drEditSp["Dvt"] = txtDvt.Text;

							if (DataTool.SQLSave(enuEdit.Edit, "LISANPHAM", ref drEditSp))
							{
								DataTool.SQLChangeID("MA_SP", drEditSp);
								drEdit["Ma_Sp"] = txtMa_Sp.Text;
							}
						}
					}
				}
			}

            //frmSanPham frmLookup = new frmSanPham();
			DataRow drLookup = Lookup.ShowLookup("Ma_Sp", strValue, bRequire, null);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Sp.Text = string.Empty;
				lbtTen_Sp.Text = string.Empty;
			}
			else
			{
				txtMa_Sp.Text = ((string)drLookup["Ma_Sp"]).Trim();
				lbtTen_Sp.Text = ((string)drLookup["Ten_Sp"]).Trim();
			}

			dicName.SetValue(lbtTen_Sp.Name, lbtTen_Sp.Text);
		}

		private void txtLoai_Vt_Validated(object sender, EventArgs e)
		{
			this.Loai_Vt_Valid();
		}
        private void txtMa_Vc_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vc.Text.Trim();
            bool bRequire = chkIs_VoChai.Checked;

            //frmTaiKhoan frmLookup = new frmTaiKhoan();
            DataRow drLookup = Lookup.ShowQuickLookup("MA_VC", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Vc.Text = string.Empty;
                lbtTen_Vc.Text = string.Empty;
            }
            else
            {
                txtMa_Vc.Text = ((string)drLookup["MA_VC"]).Trim();
                lbtTen_Vc.Text = ((string)drLookup["Ten_VC"]).Trim();
            }

            dicName.SetValue(lbtTen_Vc.Name, lbtTen_Vc.Text);
        }
		#endregion
	}
}