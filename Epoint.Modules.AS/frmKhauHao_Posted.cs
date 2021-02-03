using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;

namespace Epoint.Modules.AS
{
	public partial class frmKhauHao_Posted : Epoint.Systems.Customizes.frmEdit
	{
		string strLoai_Khau_Hao = "TS";
		public frmKhauHao_Posted()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			this.numThang.TextChanged += new EventHandler(numThang_TextChanged);
			this.numThang.Validating += new CancelEventHandler(numThang_Validating);
		}		
		new public void Load(int iThang, string strLoai_Khau_Hao)
		{
			this.strLoai_Khau_Hao = strLoai_Khau_Hao;
			this.numThang.Value = iThang;
			this.txtMa_Ct.Text = "TD";
            this.numTy_Gia.Value = 1;
            
            this.Init();
			this.ShowDialog();
		}

		private bool FormCheckValid()
		{
			if (txtMa_Ct.Text == string.Empty)
				return false;

			if (numThang.Value < 1 || numThang.Value > 12)
				return false;

			return true;
		}
        private void Init()
        {
            txtMa_Tte.Text = Element.sysMa_Tte;
            txtMa_Tte.InputMask = (string)Systems.Librarys.Parameters.GetParaValue("MA_TTE_LIST");
        }
		void numThang_TextChanged(object sender, EventArgs e)
		{
			if (strLoai_Khau_Hao == "TS")
				this.txtDien_Giai.Text = "Khấu hao tài sản tháng " + this.numThang.Text + "/" + Element.sysWorkingYear.ToString();
			else if (strLoai_Khau_Hao == "CCDC")
				this.txtDien_Giai.Text = "Phân bổ chi phí tháng " + this.numThang.Text + "/" + Element.sysWorkingYear.ToString();
		}

		void numThang_Validating(object sender, CancelEventArgs e)
		{
			if (numThang.Value < 0 || numThang.Value > 12)
				e.Cancel = false;
		}

		void btAccept_Click(object sender, EventArgs e)
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
				htParameter.Add("THANG", numThang.Value);
				htParameter.Add("NAM", Element.sysWorkingYear);
				htParameter.Add("MA_CT", this.txtMa_Ct.Text);
				htParameter.Add("SO_CT", this.txtSo_Ct.Text);
                htParameter.Add("MA_TTE", this.txtMa_Tte.Text);
                htParameter.Add("TY_GIA", this.numTy_Gia.Text);
				htParameter.Add("DIEN_GIAI", this.txtDien_Giai.Text);
                htParameter.Add("CREATE_LOG", "30"+ Element.sysWorkingYear + ":120000:"+ Element.sysUser_Id);
                htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

				if (strLoai_Khau_Hao == "TS")
					SQLExec.Execute("sp_KhauHao_Update_Ct", htParameter, CommandType.StoredProcedure);
				else if (strLoai_Khau_Hao == "CCDC")
					SQLExec.Execute("sp_PhanBoCCDC_Update_Ct", htParameter, CommandType.StoredProcedure);

                isAccept = true;
                this.Close();

			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
            isAccept = false;
            this.Close();
		}
	}
}
