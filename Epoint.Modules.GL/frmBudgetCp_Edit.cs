using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;

namespace Epoint.Modules.GL
{
	public partial class frmBudgetCp_Edit : Epoint.Modules.frmOpening_Edit
	{
		#region Methods

		public frmBudgetCp_Edit()
		{
			InitializeComponent();

			this.txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			this.txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);
			this.txtMa_Km.Validating += new CancelEventHandler(txtMa_Km_Validating);
			this.txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
			this.txtMa_CbNv.Validating += new CancelEventHandler(txtMa_CbNv_Validating);
			this.txtMa_Sp.Validating += new CancelEventHandler(txtMa_Sp_Validating);

			this.btKH01.Click += new EventHandler(btKH_Click);
			this.btKH02.Click += new EventHandler(btKH_Click);
			this.btKH03.Click += new EventHandler(btKH_Click);
			this.btKH04.Click += new EventHandler(btKH_Click);
			this.btKH05.Click += new EventHandler(btKH_Click);
			this.btKH06.Click += new EventHandler(btKH_Click);
			this.btKH07.Click += new EventHandler(btKH_Click);
			this.btKH08.Click += new EventHandler(btKH_Click);
			this.btKH09.Click += new EventHandler(btKH_Click);
			this.btKH10.Click += new EventHandler(btKH_Click);
			this.btKH11.Click += new EventHandler(btKH_Click);
			this.btKH12.Click += new EventHandler(btKH_Click);
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			if (enuNew_Edit == enuEdit.New)
			{
				//drEdit["Tien_Kh"] = 0;
				//drEdit["Tien_Kh_Nt"] = 0;
			}

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();
			this.ShowDialog();
		}

		private void LoadDicName()
		{
			if (txtTk.Text.Trim() != string.Empty)
				lbtTen_Tk.Text = DataTool.SQLGetNameByCode("LITAIKHOAN", "Tk", "Ten_Tk", txtTk.Text.Trim());
			else
				lbtTen_Tk.Text = string.Empty;

			if (txtMa_Dt.Text.Trim() != string.Empty)
				lbtTen_Dt.Text = DataTool.SQLGetNameByCode("LIDOITUONG", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			else
				lbtTen_Dt.Text = string.Empty;

			if (txtMa_Hd.Text.Trim() != string.Empty)
				lbtTen_Hd.Text = DataTool.SQLGetNameByCode("LIHOPDONG", "Ma_Hd", "Ten_Hd", txtMa_Hd.Text.Trim());
			else
				lbtTen_Hd.Text = string.Empty;

			if (txtMa_Km.Text.Trim() != string.Empty)
				lbtTen_Km.Text = DataTool.SQLGetNameByCode("LIKHOANMUC", "Ma_Km", "Ten_Km", txtMa_Km.Text.Trim());
			else
				lbtTen_Km.Text = string.Empty;

			if (txtMa_Bp.Text.Trim() != string.Empty)
				lbtTen_Bp.Text = DataTool.SQLGetNameByCode("LIBOPHAN", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
			else
				lbtTen_Bp.Text = string.Empty;

			if (txtMa_CbNv.Text.Trim() != string.Empty)
				lbtTen_CbNv.Text = DataTool.SQLGetNameByCode("LINHANVIEN", "Ma_CbNv", "Ten_CbNv", txtMa_CbNv.Text.Trim());
			else
				lbtTen_CbNv.Text = string.Empty;
		}

		public override bool FormCheckValid()
		{
			if (txtTk.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Tk") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			//bool Is_Check = false;

			//if (enuNew_Edit == enuEdit.Edit)
			//{
			//    if ((string)drEdit["Tk"] == (string)drEdit["Tk", DataRowVersion.Original] &&
			//        (string)drEdit["Ma_Dt"] == (string)drEdit["Ma_Dt", DataRowVersion.Original] &&
			//        (string)drEdit["Ma_Sp"] == (string)drEdit["Ma_Sp", DataRowVersion.Original])
			//        Is_Check = false;
			//    else
			//        Is_Check = true;
			//}

			//if (enuNew_Edit == enuEdit.New || Is_Check)
			//{
			//    if (DataTool.SQLCheckExist("R80CDK", new string[] { "Nam", "Tk", "Ma_Dt", "Ma_Sp", "Ma_DvCs" }, new object[] { Element.sysWorkingYear, txtTk.Text, txtMa_Dt.Text, txtMa_Sp.Text, Element.sysMa_DvCs }))
			//    {
			//        string strMsg = "Nam = {" + Element.sysWorkingYear + "}, Tk = {" + txtTk.Text + "}, Ma_Dt = {" + txtMa_Dt.Text + "}, Ma_Sp = {" + txtMa_Sp.Text + "}, Ma_DvCs = {" + Element.sysMa_DvCs + "}";
			//        strMsg += Element.sysLanguage == enuLanguageType.English ? " must be unique" : " phải duy nhất";

			//        Common.MsgCancel(strMsg);
			//        return false;
			//    }
			//}

			return true;
		}

		public override bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			if (drEdit.Table.Columns.Contains("Ten_Dt"))
				drEdit["Ten_Dt"] = lbtTen_Dt.Text;

			if (drEdit.Table.Columns.Contains("Thang"))
				drEdit["Thang"] = ((DateTime)drEdit["Ngay_Ct"]).Month;

			if (!DataTool.SQLUpdate(this.enuNew_Edit, "GLKEHOACH", ref drEdit))
				return false;

			return true;
		}

		//private void Tinh_Tien()
		//{
		//    if (txtMa_Tte.Text == Element.sysMa_Tte)
		//    {
		//        numTien_No.Value = numTien_No0.Value - numTien_Tt0.Value;
		//    }
		//    else
		//    {
		//        double dbTron_Tien = Convert.ToDouble(Parameters.GetParaValue("Tron_Ty_Gia"));

		//        if (Math.Abs(numTy_Gia.Value * numTien_No_Nt0.Value - numTien_No0.Value) > dbTron_Tien)
		//            numTien_No0.Value = Math.Round(numTien_No_Nt0.Value * numTy_Gia.Value, 0, MidpointRounding.AwayFromZero);

		//        if (Math.Abs(numTy_Gia.Value * numTien_Tt_Nt0.Value - numTien_Tt0.Value) > dbTron_Tien)
		//            numTien_Tt0.Value = Math.Round(numTien_Tt_Nt0.Value * numTy_Gia.Value, 0, MidpointRounding.AwayFromZero);

		//        numTien_No_Nt.Value = numTien_No_Nt0.Value - numTien_Tt_Nt0.Value;
		//        numTien_No.Value = numTien_No0.Value - numTien_Tt0.Value;
		//    }
		//}

		#endregion

		#region Events

		void txtMa_Hd_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Hd.Text.Trim();
			bool bRequire = false;

			Lists.frmHopDong frmLookup = new Epoint.Lists.frmHopDong();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIHOPDONG", "Ma_Hd", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Hd.Text = string.Empty;
				lbtTen_Hd.Text = string.Empty;
			}
			else
			{
				txtMa_Hd.Text = drLookup["Ma_Hd"].ToString();
				lbtTen_Hd.Text = drLookup["Ten_Hd"].ToString();

				if (txtMa_Hd.bTextChange)
				{
					txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
					lbtTen_Dt.Text = DataTool.SQLGetNameByCode("LIDOITUONG", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text);
				}
			}

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = false;

			Lists.frmDoiTuong frmLookup = new Epoint.Lists.frmDoiTuong();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIDOITUONG", "Ma_Dt", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt.Text = string.Empty;
				lbtTen_Dt.Text = string.Empty;
			}
			else
			{
				txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt.Text = drLookup["Ten_Dt"].ToString();
			}

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

		void txtMa_Km_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Km.Text.Trim();
			bool bRequire = false;

			Lists.frmKhoanMuc frmLookup = new Epoint.Lists.frmKhoanMuc();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIKHOANMUC", "Ma_Km", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Km.Text = string.Empty;
				lbtTen_Km.Text = string.Empty;
			}
			else
			{
				txtMa_Km.Text = drLookup["Ma_Km"].ToString();
				lbtTen_Km.Text = drLookup["Ten_Km"].ToString();
			}

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

		void txtMa_Bp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Bp.Text.Trim();
			bool bRequire = false;

			Lists.frmBoPhan frmLookup = new Epoint.Lists.frmBoPhan();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIBOPHAN", "Ma_Bp", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Bp.Text = string.Empty;
				lbtTen_Bp.Text = string.Empty;
			}
			else
			{
				txtMa_Bp.Text = drLookup["Ma_Bp"].ToString();
				lbtTen_Bp.Text = drLookup["Ten_Bp"].ToString();
			}

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

		void txtMa_CbNv_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_CbNv.Text.Trim();
			bool bRequire = false;

			Lists.frmNhanVien frmLookup = new Epoint.Lists.frmNhanVien();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LINHANVIEN", "Ma_CbNv", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_CbNv.Text = string.Empty;
				lbtTen_CbNv.Text = string.Empty;
			}
			else
			{
				txtMa_CbNv.Text = drLookup["Ma_CbNv"].ToString();
				lbtTen_CbNv.Text = drLookup["Ten_CbNv"].ToString();
			}

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

		void txtMa_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Sp.Text.Trim();
			bool bRequire = false;

			Lists.frmSanPham frmLookup = new Epoint.Lists.frmSanPham();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LISANPHAM", "Ma_Sp", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Sp.Text = string.Empty;
				lbtTen_Sp.Text = string.Empty;
			}
			else
			{
				txtMa_Sp.Text = drLookup["Ma_Sp"].ToString();
				lbtTen_Sp.Text = drLookup["Ten_Sp"].ToString();
			}

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

		void btKH_Click(object sender, EventArgs e)
		{
			if (((Button)sender).Name.Substring(2) == "KH01")
				numTien_Kh12.Value = numTien_Kh11.Value = numTien_Kh10.Value = numTien_Kh09.Value = numTien_Kh08.Value = numTien_Kh07.Value = numTien_Kh06.Value = numTien_Kh05.Value = numTien_Kh04.Value = numTien_Kh03.Value = numTien_Kh02.Value = numTien_Kh01.Value;
			else if (((Button)sender).Name.Substring(2) == "KH02")
				numTien_Kh12.Value = numTien_Kh11.Value = numTien_Kh10.Value = numTien_Kh09.Value = numTien_Kh08.Value = numTien_Kh07.Value = numTien_Kh06.Value = numTien_Kh05.Value = numTien_Kh04.Value = numTien_Kh03.Value = numTien_Kh02.Value;
			else if (((Button)sender).Name.Substring(2) == "KH03")
				numTien_Kh12.Value = numTien_Kh11.Value = numTien_Kh10.Value = numTien_Kh09.Value = numTien_Kh08.Value = numTien_Kh07.Value = numTien_Kh06.Value = numTien_Kh05.Value = numTien_Kh04.Value = numTien_Kh03.Value;
			else if (((Button)sender).Name.Substring(2) == "KH04")
				numTien_Kh12.Value = numTien_Kh11.Value = numTien_Kh10.Value = numTien_Kh09.Value = numTien_Kh08.Value = numTien_Kh07.Value = numTien_Kh06.Value = numTien_Kh05.Value = numTien_Kh04.Value;
			else if (((Button)sender).Name.Substring(2) == "KH05")
				numTien_Kh12.Value = numTien_Kh11.Value = numTien_Kh10.Value = numTien_Kh09.Value = numTien_Kh08.Value = numTien_Kh07.Value = numTien_Kh06.Value = numTien_Kh05.Value;
			else if (((Button)sender).Name.Substring(2) == "KH06")
				numTien_Kh12.Value = numTien_Kh11.Value = numTien_Kh10.Value = numTien_Kh09.Value = numTien_Kh08.Value = numTien_Kh07.Value = numTien_Kh06.Value;
			else if (((Button)sender).Name.Substring(2) == "KH07")
				numTien_Kh12.Value = numTien_Kh11.Value = numTien_Kh10.Value = numTien_Kh09.Value = numTien_Kh08.Value = numTien_Kh07.Value;
			else if (((Button)sender).Name.Substring(2) == "KH08")
				numTien_Kh12.Value = numTien_Kh11.Value = numTien_Kh10.Value = numTien_Kh09.Value = numTien_Kh08.Value;
			else if (((Button)sender).Name.Substring(2) == "KH09")
				numTien_Kh12.Value = numTien_Kh11.Value = numTien_Kh10.Value = numTien_Kh09.Value;
			else if (((Button)sender).Name.Substring(2) == "KH10")
				numTien_Kh12.Value = numTien_Kh11.Value = numTien_Kh10.Value;
			else if (((Button)sender).Name.Substring(2) == "KH11")
				numTien_Kh12.Value = numTien_Kh11.Value;
		}

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			//if (this.enuNew_Edit == enuEdit.Edit)
			//{
			//    if (!Common.CheckDataLocked((DateTime)drEdit["Ngay_Ct"]))
			//    {
			//        this.dteNgay_Ct.Enabled = false;
			//        this.btgAccept.btAccept.Enabled = false;
			//    }
			//}
		}
	}
}
