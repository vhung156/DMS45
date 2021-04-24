using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Data;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;
using Epoint.Lists;

namespace Epoint.Modules.AP
{
	public partial class frmCreate_TSCD_Edit : Epoint.Systems.Customizes.frmEdit
	{
        public string strStt = string.Empty;
        public int iStt0 = 0;
        
		#region Contructor

		public frmCreate_TSCD_Edit()
		{
			InitializeComponent();

			txtMa_Tte.TextChanged += new EventHandler(txtMa_Tte_TextChanged);

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtTk_No.Validating += new CancelEventHandler(txtTk_No_Validating);
			txtTk_Co.Validating += new CancelEventHandler(txtTk_Co_Validating);
            txtTk_Ts.Validating += new CancelEventHandler(txtTk_Ts_Validating);

            txtMa_Nh_Ts.Validating += new CancelEventHandler(txtMa_Nh_Ts_Validating);
            txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
			txtMa_Km.Validating += new CancelEventHandler(txtMa_Km_Validating);
			txtMa_Sp.Validating += new CancelEventHandler(txtMa_Sp_Validating);

			chkTinh_Kh.CheckedChanged += new EventHandler(chkTinh_Kh_CheckedChanged);

			numTien_NG_Nt.Validating += new CancelEventHandler(numTien_NG_Nt_Validating);
			numTien_HM_Nt.Validating += new CancelEventHandler(numTien_Hao_Mon_Validating);
			numTien_CL_Nt.Validating += new CancelEventHandler(numTien_Con_Lai_Validating);
		}

		new public void Load()
		{	
			this.BindingLanguage();
			this.ShowDialog();
		}

		#endregion

		#region Phuong thuc

		private void Init()
		{
			this.Ma_Tte_Show();            
		}

		private void Ma_Tte_Show()
		{
			if (this.txtMa_Tte.Text.Trim() == Element.sysMa_Tte)
			{
				this.numTien_HM.Visible = false;
				this.numTien_NG.Visible = false;
				this.numTien_CL.Visible = false;
			}
			else
			{
				this.numTien_HM.Visible = true;
				this.numTien_NG.Visible = true;
				this.numTien_CL.Visible = true;
			}
		}

		private void LoadDicName()
		{
			
		}

		private void Tinh_Tien()
		{
			if (numTy_Gia.Value == 0)
				numTy_Gia.Value = 1;

			this.numTien_NG.Value = Math.Round(this.numTien_NG_Nt.Value * this.numTy_Gia.Value, 0, MidpointRounding.AwayFromZero);
			this.numTien_HM.Value = Math.Round(this.numTien_HM_Nt.Value * this.numTy_Gia.Value, 0, MidpointRounding.AwayFromZero);
			this.numTien_CL.Value = Math.Round(this.numTien_CL_Nt.Value * this.numTy_Gia.Value, 0, MidpointRounding.AwayFromZero);
		}

		private bool FormCheckValid()
		{
			if (dteNgay_Ps.Text.Replace(" ", "") == "//")
			{
				Common.MsgOk(Languages.GetLanguage("Ngay_Ps") + " " +
							 Languages.GetLanguage("Cannot_Empty"));
				return false;
			}		

			if (chkTinh_Kh.Checked)
			{
				if (txtNgay_Bd_Kh.IsNull)
				{
					Common.MsgOk(Languages.GetLanguage("Ngay_Bd_Kh") + " " + Languages.GetLanguage("Cannot_Empty"));
					return false;
				}

				//if (numSo_Thang_Kh.Value == 0)
				//{
				//    Common.MsgOk(Languages.GetLanguage("So_Thang_Kh") + " " + Languages.GetLanguage("Cannot_Empty"));
				//    return false;
				//}

				if (txtTk_No.Text == string.Empty)
				{
					Common.MsgOk(Languages.GetLanguage("Tk_No") + " " + Languages.GetLanguage("Cannot_Empty"));
					return false;
				}
				
                if (txtTk_Co.Text == string.Empty)
				{
					Common.MsgOk(Languages.GetLanguage("Tk_Co") + " " + Languages.GetLanguage("Cannot_Empty"));
					return false;
				}

                if (txtMa_Nh_Ts.Text == string.Empty)
                {
                    Common.MsgOk("Mã nhóm " + Languages.GetLanguage("Cannot_Empty"));
                    return false;
                }

                if (txtTk_Ts.Text == string.Empty)
                {
                    Common.MsgOk("Tài khoản " + Languages.GetLanguage("Cannot_Empty"));
                    return false;
                }
			}

			if (txtDien_Giai.Text == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Dien_Giai") + " " + Languages.GetLanguage("Cannot_Empty"));

				return false;
			}

			return true;
		}

		private bool Save()
		{
			if (!Common.CheckDataLocked(Library.StrToDate(dteNgay_Ps.Text)))
			{
				Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
				return false;
			}

            //Kiem tra Valid tren Form
            if (!FormCheckValid())
                return false;

            //Luu vao CSDL
            if (rdbIs_TaiSan.Checked)
            {
                Hashtable ht = new Hashtable();
                ht.Add("STT", strStt);
                ht.Add("STT0", iStt0);
                ht.Add("MA_TS", txtMa_Ts.Text);
                ht.Add("TEN_TS", txtTen_Ts.Text);
                ht.Add("MA_NH_TS", txtMa_Nh_Ts.Text);
                ht.Add("TK_TS", txtTk_Ts.Text);
                ht.Add("DVT", txtDvt.Text);
                ht.Add("NGAY_CT", Library.StrToDate(dteNgay_Ps.Text));
                ht.Add("SO_CT", txtSo_Ct.Text);
                ht.Add("MA_TTE", txtMa_Tte.Text);
                ht.Add("TY_GIA", 1);
                ht.Add("DIEN_GIAI", txtDien_Giai.Text);
                ht.Add("MA_BP", txtMa_Bp.Text);
                ht.Add("MA_KM", txtMa_Km.Text);
                ht.Add("MA_SP", txtMa_Sp.Text);
                ht.Add("SO_LUONG", numSo_Luong.Value);
                ht.Add("TIEN_NG", numTien_NG.Value);
                ht.Add("TK_NO", txtTk_No.Text);
                ht.Add("TK_CO", txtTk_Co.Text);
                ht.Add("TINH_KH", chkTinh_Kh.Checked);
                ht.Add("NGAY_BD_KH", Library.StrToDate(txtNgay_Bd_Kh.Text));
                ht.Add("SO_THANG_KH", numSo_Thang_Kh.Value);
                ht.Add("MA_DVCS", Element.sysMa_DvCs.ToString());

                //Check Ma_Ts exist
                string strMa_Ts = (string)SQLExec.ExecuteReturnValue("SELECT Ma_Ts FROM ASTS WHERE Ma_Ts ='" + txtMa_Ts.Text.Trim() + "'", CommandType.Text);
                if (strMa_Ts != null)
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Mã này đã tồn tại trong danh mục tài sản." : "The code already exists in the asset list.";
                    Common.MsgCancel(strMsg);
                    return false;
                }
                else
                {
                    SQLExec.Execute("sp_Create_TSCD", ht, CommandType.StoredProcedure);
                }
            }
            if (rdbIs_CCDC.Checked)
            {
                Hashtable ht = new Hashtable();
                ht.Add("STT", strStt);
                ht.Add("STT0", iStt0);
                ht.Add("MA_CCDC", txtMa_Ts.Text);
                ht.Add("TEN_CCDC", txtTen_Ts.Text);
                ht.Add("MA_NH_TS", txtMa_Nh_Ts.Text);
                ht.Add("TK_CCDC", txtTk_Ts.Text);
                ht.Add("DVT", txtDvt.Text);
                ht.Add("NGAY_CT", Library.StrToDate(dteNgay_Ps.Text));
                ht.Add("SO_CT", txtSo_Ct.Text);
                ht.Add("MA_TTE", txtMa_Tte.Text);
                ht.Add("TY_GIA", 1);
                ht.Add("DIEN_GIAI", txtDien_Giai.Text);
                ht.Add("MA_BP", txtMa_Bp.Text);
                ht.Add("MA_KM", txtMa_Km.Text);
                ht.Add("MA_SP", txtMa_Sp.Text);
                ht.Add("SO_LUONG", numSo_Luong.Value);
                ht.Add("TIEN_NG", numTien_NG.Value);
                ht.Add("TK_NO", txtTk_No.Text);
                ht.Add("TK_CO", txtTk_Co.Text);
                ht.Add("TINH_KH", chkTinh_Kh.Checked);
                ht.Add("NGAY_BD_KH", Library.StrToDate(txtNgay_Bd_Kh.Text));
                ht.Add("SO_THANG_KH", numSo_Thang_Kh.Value);
                ht.Add("MA_DVCS", Element.sysMa_DvCs.ToString());

                //Check Ma_CCDC exist
                string strMa_CCDC = (string)SQLExec.ExecuteReturnValue("SELECT Ma_CCDC FROM ASCCDC WHERE Ma_CCDC ='" + txtMa_Ts.Text.Trim() + "'", CommandType.Text);
                if (strMa_CCDC != null)
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Mã này đã tồn tại trong danh mục CCDC." : "The code already exists in the tool list.";
                    Common.MsgCancel(strMsg);
                    return false;
                }
                else
                {
                    SQLExec.Execute("sp_Create_CCDC", ht, CommandType.StoredProcedure);
                }                
            }
            ///////////
            
			////Xac dinh Stt
            //if (this.enuNew_Edit == enuEdit.New)
            //    drEdit["Stt"] = Common.GetNewStt("TS", true);

			//Kiem tra Valid CSDL
            //if (!DataTool.SQLUpdate(enuNew_Edit, "ASTSNG", ref drEdit))
            //    return false;

			return true;
		}

		#endregion

		#region Su kien

		void txtMa_Tte_TextChanged(object sender, EventArgs e)
		{
			this.Ma_Tte_Show();
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				isAccept = true;                
				this.Close();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}


		#region Ma_Ts
		//void txtMa_Ts_Enter(object sender, EventArgs e)
		//{
		//    lbtTen_Ts.Text = dicName.GetValue(lbtTen_Ts.Name);
		//}

		//void txtMa_Ts_Validating(object sender, CancelEventArgs e)
		//{
		//    string strValue = txtMa_Ts.Text.Trim();
		//    bool bRequire = true;

		//    frmCtTs frmLookup = new frmCtTs();
		//    DataRow drLookup = Lookup.ShowLookup(frmLookup, "ASTS", "Ma_Ts", strValue, bRequire, "");

		//    if (bRequire && drLookup == null)
		//        e.Cancel = true;

		//    if (drLookup == null)
		//    {
		//        lbtTen_Ts.Text = string.Empty;
		//        lbtTen_Ts.Text = string.Empty;
		//    }
		//    else
		//    {
		//        txtMa_Ts.Text = ((string)drLookup["Ma_Ts"]).Trim();
		//        lbtTen_Ts.Text = ((string)drLookup["Ten_Ts"]).Trim();
		//    }

		//    dicName.SetValue(lbtTen_Ts.Name, lbtTen_Ts.Text);
		//}
		#endregion
        
        void txtMa_Nh_Ts_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Nh_Ts.Text.Trim();
            bool bRequire = true;            

            //Tai San
            if (rdbIs_TaiSan.Checked)
            {
                Epoint.Modules.AS.frmDmNhTs frmLookup = new Epoint.Modules.AS.frmDmNhTs();
                DataRow drLookup = Lookup.ShowLookup(frmLookup, "ASTSNH", "Ma_Nh_Ts", strValue, bRequire, "", "Nh_Cuoi = 1");

                if (bRequire && drLookup == null)
                    e.Cancel = true;

                if (drLookup == null)
                {
                    lbtTen_Nh_Ts.Text = string.Empty;
                    lbtTen_Nh_Ts.Text = string.Empty;
                }
                else
                {
                    txtMa_Nh_Ts.Text = ((string)drLookup["Ma_Nh_Ts"]).Trim();
                    lbtTen_Nh_Ts.Text = ((string)drLookup["Ten_Nh_Ts"]).Trim();
                }
            }
            
            //CCDC
            if (rdbIs_CCDC.Checked)
            {
                Epoint.Modules.AS.frmDmNhCCDC frmLookup = new Epoint.Modules.AS.frmDmNhCCDC();
                DataRow drLookup = Lookup.ShowLookup(frmLookup, "ASTSNH", "Ma_Nh_Ts", strValue, bRequire, "", "Nh_Cuoi = 1");

                if (bRequire && drLookup == null)
                    e.Cancel = true;

                if (drLookup == null)
                {
                    lbtTen_Nh_Ts.Text = string.Empty;
                    lbtTen_Nh_Ts.Text = string.Empty;
                }
                else
                {
                    txtMa_Nh_Ts.Text = ((string)drLookup["Ma_Nh_Ts"]).Trim();
                    lbtTen_Nh_Ts.Text = ((string)drLookup["Ten_Nh_Ts"]).Trim();
                }
            }

            dicName.SetValue(lbtTen_Nh_Ts.Name, lbtTen_Nh_Ts.Text);
        }

		void txtMa_Bp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Bp.Text.Trim();
			bool bRequire = false;

			//
			DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "Nh_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				lbtTen_Bp.Text = string.Empty;
				lbtTen_Bp.Text = string.Empty;
			}
			else
			{
				txtMa_Bp.Text = ((string)drLookup["Ma_Bp"]).Trim();
				lbtTen_Bp.Text = ((string)drLookup["Ten_Bp"]).Trim();
			}

			dicName.SetValue(lbtTen_Bp.Name, lbtTen_Bp.Text);
		}

		void txtTk_No_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk_No.Text.Trim();
			bool bRequire = true;

			//
			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				lbtTen_Tk_No.Text = string.Empty;
				lbtTen_Tk_No.Text = string.Empty;
			}
			else
			{
				txtTk_No.Text = ((string)drLookup["Tk"]).Trim();
				lbtTen_Tk_No.Text = ((string)drLookup["Ten_Tk"]).Trim();
			}

			dicName.SetValue(lbtTen_Tk_No.Name, lbtTen_Tk_No.Text);
		}

		void txtTk_Co_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk_Co.Text.Trim();
			bool bRequire = true;

			//
			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				lbtTen_Tk_Co.Text = string.Empty;
				lbtTen_Tk_Co.Text = string.Empty;
			}
			else
			{
				txtTk_Co.Text = ((string)drLookup["Tk"]).Trim();
				lbtTen_Tk_Co.Text = ((string)drLookup["Ten_Tk"]).Trim();
			}

			dicName.SetValue(lbtTen_Tk_Co.Name, lbtTen_Tk_Co.Text);
		}

        void txtTk_Ts_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtTk_Ts.Text.Trim();
            bool bRequire = true;

            //
            DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                lbtTen_Tk_Ts.Text = string.Empty;
                lbtTen_Tk_Ts.Text = string.Empty;
            }
            else
            {
                txtTk_Ts.Text = ((string)drLookup["Tk"]).Trim();
                lbtTen_Tk_Ts.Text = ((string)drLookup["Ten_Tk"]).Trim();
            }

            dicName.SetValue(lbtTen_Tk_Ts.Name, lbtTen_Tk_Ts.Text);
        }

		void txtMa_Km_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Km.Text.Trim();
			bool bRequire = false;

			//
			DataRow drLookup = Lookup.ShowLookup("Ma_Km", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				lbtTen_Km.Text = string.Empty;
				lbtTen_Km.Text = string.Empty;
			}
			else
			{
				txtMa_Km.Text = ((string)drLookup["Ma_Km"]).Trim();
				lbtTen_Km.Text = ((string)drLookup["Ten_Km"]).Trim();
			}

			dicName.SetValue(lbtTen_Km.Name, lbtTen_Km.Text);
		}

		void txtMa_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Sp.Text.Trim();
			bool bRequire = false;

			//
			DataRow drLookup = Lookup.ShowLookup("Ma_Sp", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				lbtTen_Sp.Text = string.Empty;
				lbtTen_Sp.Text = string.Empty;
			}
			else
			{
				txtMa_Sp.Text = ((string)drLookup["Ma_Sp"]).Trim();
				lbtTen_Sp.Text = ((string)drLookup["Ten_Sp"]).Trim();
			}

			dicName.SetValue(lbtTen_Sp.Name, lbtTen_Sp.Text);
		}

		void chkTinh_Kh_CheckedChanged(object sender, EventArgs e)
		{
            lblSo_Thang.Enabled = chkTinh_Kh.Checked;
            numSo_Thang_Kh.Enabled = chkTinh_Kh.Checked;
            lblNgay_Tinh_Kh.Enabled = chkTinh_Kh.Checked;
            txtNgay_Bd_Kh.Enabled = chkTinh_Kh.Checked;
            lblTk_No.Enabled = chkTinh_Kh.Checked;
            txtTk_No.Enabled = chkTinh_Kh.Checked;
            lblTk_Co.Enabled = chkTinh_Kh.Checked;
            txtTk_Co.Enabled = chkTinh_Kh.Checked;
		}

		void numTien_NG_Nt_Validating(object sender, CancelEventArgs e)
		{
			//numTien_CL_Nt.Value = numTien_NG_Nt.Value - numTien_HM_Nt.Value;

			this.Tinh_Tien();
		}

		void numTien_Con_Lai_Validating(object sender, CancelEventArgs e)
		{
			if (numTien_NG_Nt.Value < numTien_CL_Nt.Value)
			{
				Common.MsgCancel("Tiền nguyên giá nhỏ hơn tiền còn lại");
				e.Cancel = true;
				return;
			}
			else
			{
				numTien_HM_Nt.Value = numTien_NG_Nt.Value - numTien_CL_Nt.Value;
			}

			this.Tinh_Tien();
		}

		void numTien_Hao_Mon_Validating(object sender, CancelEventArgs e)
		{
			if (numTien_NG_Nt.Value < numTien_HM_Nt.Value)
			{
				Common.MsgCancel("Tiền nguyên giá nhỏ hơn tiền còn lại");
				e.Cancel = true;
				return;
			}
			else
			{
				numTien_CL_Nt.Value = numTien_NG_Nt.Value - numTien_HM_Nt.Value;
			}

			this.Tinh_Tien();            
		}

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (this.enuNew_Edit == enuEdit.Edit)
			{
				if (!Common.CheckDataLocked((DateTime)drEdit["Ngay_Ps"]))
				{
					this.dteNgay_Ps.Enabled = false;
					this.btgAccept.btAccept.Enabled = false;

					return;
				}
			}
		}        
    }
}