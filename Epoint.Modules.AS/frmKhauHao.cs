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

namespace Epoint.Modules.AS
{
	public partial class frmKhauHao : Epoint.Systems.Customizes.frmView
	{
		DataTable dtKhauHao;
		BindingSource bdsKhauHao = new BindingSource();

		public frmKhauHao()
		{
			InitializeComponent();

			this.numThang.Validated += new EventHandler(numThang_Validated);

			this.btThuc_Hien.Click += new EventHandler(btThuc_Hien_Click);			
			this.btPosted.Click += new EventHandler(btPosted_Click);
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
			dgvKhauHao.strZone = "KHAUHAO";
			dgvKhauHao.BuildGridView();
		}

		private void FillData()
		{

			string strSQLExec =
				" SELECT T_KhauHao.*, CtTs.Ten_Ts " +
					" FROM ASTSHM T_KhauHao, ASTS CtTs " +
					" WHERE T_KhauHao.Ma_Ts = CtTs.Ma_Ts AND YEAR(Ngay_Ps) = " + Element.sysWorkingYear.ToString() +
							" AND MONTH(Ngay_Ps) = " + this.numThang.Value.ToString() +
							" AND T_KhauHao.Ma_DvCs = '" + Element.sysMa_DvCs + "'";

			dtKhauHao = SQLExec.ExecuteReturnDt(strSQLExec);
			bdsKhauHao.DataSource = dtKhauHao;

			dgvKhauHao.DataSource = bdsKhauHao;

			this.bdsSearch = bdsKhauHao;
			this.ExportControl = dgvKhauHao;
		}

		private void Calc_KhauHao()
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
				htParameter.Add("MA_TS", this.txtMa_Ts.Text.Trim());
				htParameter.Add("MA_NH_TS", this.txtMa_Nh_Ts.Text.Trim());
				htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

				dtKhauHao = SQLExec.ExecuteReturnDt("sp_KhauHao", htParameter, CommandType.StoredProcedure);

				bdsKhauHao.DataSource = dtKhauHao;
			}
		}

		private bool FormCheckValid()
		{

			return true;
		}

		void numThang_Validated(object sender, EventArgs e)
		{
			this.FillData();
		}

		void btPosted_Click(object sender, EventArgs e)
		{		
			frmKhauHao_Posted frm = new frmKhauHao_Posted();
			frm.Load(Convert.ToInt16(this.numThang.Value), "TS");

            if (frm.isAccept)
            {
                Common.MsgOk(Languages.GetLanguage("End_Process"));
                Common.EndShowStatus();
            }
		}

		void btThuc_Hien_Click(object sender, EventArgs e)
		{
			this.Calc_KhauHao();

            Common.MsgOk(Languages.GetLanguage("End_Process"));
            Common.EndShowStatus();
		}
	}
}
