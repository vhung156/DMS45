using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Epoint.Systems.Data;
using Epoint.Systems.Librarys;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;

namespace Epoint.Modules.AS
{
	public partial class frmPhanBoCCDC : Epoint.Systems.Customizes.frmView
	{
		DataTable dtPhanBo;
		BindingSource bdsPhanBo = new BindingSource();

		public frmPhanBoCCDC()
		{
			InitializeComponent();

			this.numThang.Validated += new EventHandler(numThang_Validated);

			this.btThuc_Hien.Click += new EventHandler(btThuc_Hien_Click);			
			this.btPosted.Click += new EventHandler(btPosted_Click);

			this.txtMa_Nh_Ts.Validating += new CancelEventHandler(txtMa_Nh_Ts_Validating);
		}

		new public void Load()
		{
			this.numThang.Value = Element.sysNgay_Ct2.Month;
			this.Build();
			this.FillData();

			this.Show();
		}

		private void Build()
		{
			dgvPhanBo.strZone = "PhanBo";
			dgvPhanBo.BuildGridView();
		}

		private void FillData()
		{

			string strSQLExec =
				" SELECT T_PhanBo.*, CtCCDC.Ten_CCDC " +
					" FROM ASCCDCHM T_PhanBo, ASCCDC CtCCDC " +
					" WHERE T_PhanBo.Ma_CCDC = CtCCDC.Ma_CCDC AND YEAR(T_PhanBo.Ngay_Ps) = " + Element.sysWorkingYear.ToString() +
							" AND MONTH(T_PhanBo.Ngay_Ps) = " + this.numThang.Value.ToString() +
							" AND T_PhanBo.Ma_DvCs = '" + Element.sysMa_DvCs + "'";

			dtPhanBo = SQLExec.ExecuteReturnDt(strSQLExec);
			bdsPhanBo.DataSource = dtPhanBo;

			dgvPhanBo.DataSource = bdsPhanBo;

			this.bdsSearch = bdsPhanBo;
			this.ExportControl = dgvPhanBo;
		}

		private void Calc_PhanBo()
		{
			if (Common.GetPartitionCurrent() != 0 && Common.GetPartitionCurrent() != Element.sysWorkingYear)
			{
				Common.MsgCancel("Phải chuyển về phân vùng dữ liệu " + Element.sysWorkingYear.ToString() + "!");
				return;
			}

			DateTime dteNgay_Kh1 = Common.GetDate(Element.sysWorkingYear, Convert.ToInt16(numThang.Value), 1);

			if (!Common.CheckDataLocked(dteNgay_Kh1))
			{
				Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
				return;
			}

			if (this.FormCheckValid())
			{
				Hashtable htParameter = new Hashtable();

				htParameter.Add("THANG", this.numThang.Value);
				htParameter.Add("NAM", Element.sysWorkingYear);
				htParameter.Add("Ma_CCDC", this.txtMa_CCDC.Text.Trim());
				htParameter.Add("MA_NH_TS", this.txtMa_Nh_Ts.Text.Trim());
				htParameter.Add("TY_GIA", this.numTy_Gia.Value);
				htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

				dtPhanBo = SQLExec.ExecuteReturnDt("sp_PhanBoCCDC", htParameter, CommandType.StoredProcedure);

				bdsPhanBo.DataSource = dtPhanBo;
			}
		}

		private bool FormCheckValid()
		{

			return true;
		}

		void txtMa_Nh_Ts_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nh_Ts.Text.Trim();
			bool bRequire = false;

			frmQuickLookup frmLookup = new frmQuickLookup("ASTSNH", "DMNHTS");

			DataRow drLookup = Lookup.ShowLookup(frmLookup, "ASTSNH", "Ma_Nh_Ts", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nh_Ts.Text = string.Empty;
				lblMa_Nh_Ts.Text = string.Empty;
			}
			else
			{
				txtMa_Nh_Ts.Text = drLookup["Ma_Nh_Ts"].ToString();
				lblMa_Nh_Ts.Text = drLookup["Ten_Nh_Ts"].ToString();
			}
		}

		void numThang_Validated(object sender, EventArgs e)
		{
			Hashtable ht = new Hashtable();
			int iThang = 0, iNam = 0;
			if (numThang.Value == 12)
			{
				iThang = 1;
				iNam = Element.sysWorkingYear + 1;
			}
			else
			{
				iThang = Convert.ToInt16(numThang.Value) + 1;
				iNam = Element.sysWorkingYear;
			}

			DateTime dteNgay_Ct = new DateTime(iNam, iThang, 1).AddDays(-1);

			ht.Add("NGAY_CT", dteNgay_Ct);
			ht.Add("MA_TTE", "VND");

			numTy_Gia.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("sp_GetTyGia", ht, CommandType.StoredProcedure));

			this.FillData();
		}

		void btPosted_Click(object sender, EventArgs e)
		{
			frmKhauHao_Posted frm = new frmKhauHao_Posted();
			frm.Load(Convert.ToInt16(this.numThang.Value), "CCDC");

            Common.MsgOk(Languages.GetLanguage("End_Process"));
            Common.EndShowStatus();
		}

		void btThuc_Hien_Click(object sender, EventArgs e)
		{
			this.Calc_PhanBo();

            Common.MsgOk(Languages.GetLanguage("End_Process"));
            Common.EndShowStatus();
		}
	}
}
