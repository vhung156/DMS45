using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Controls;
using Epoint.Systems.Elements;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Lists;

namespace Epoint.Modules.IN
{
	public partial class frmGiaVon : Epoint.Systems.Customizes.frmView
	{
		public frmGiaVon()
		{
			InitializeComponent();

			txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
			txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);
			btOk.Click += new EventHandler(btOk_Click);
			btCancel.Click += new EventHandler(btCancel_Click);
		}

		new public void Load()
		{
			this.txtNgay_Ct1.Text = Element.sysNgay_Ct1.ToString();
			this.txtNgay_Ct2.Text = Element.sysNgay_Ct2.ToString();

			switch ((string)Parameters.GetParaValue("PP_GIAVON"))
			{
				case "BQTH":
					rdbGiaBQTH.Checked = true;
					break;
				case "BQTT":
					rdbGiaBQTT.Checked = true;
					break;
				default:
					rdbGiaNTXT.Checked = true;
					break;
			}

            this.BindingLanguage();
			this.Show();
		}

		void txtMa_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt.Text;
			bool bRequire = false;

            //frmVatTu frmLookup = new frmVatTu();
			DataRow drLookup = Lookup.ShowLookup( "Ma_Vt" ,strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt.Text = string.Empty;
				lbtTen_Vt.Text = string.Empty;
			}
			else
			{
				txtMa_Vt.Text = drLookup["Ma_Vt"].ToString();
				lbtTen_Vt.Text = drLookup["Ten_Vt"].ToString();
			}

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

		void txtMa_Kho_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Kho.Text;
			bool bRequire = false;

            //frmKho frmLookup = new frmKho();
			DataRow drLookup = Lookup.ShowLookup( "Ma_Kho", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Kho.Text = string.Empty;
				lbtTen_Kho.Text = string.Empty;
			}
			else
			{
				txtMa_Kho.Text = drLookup["Ma_Kho"].ToString();
				lbtTen_Kho.Text = drLookup["Ten_Kho"].ToString();
			}

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

		void btOk_Click(object sender, EventArgs e)
		{
            EpointProcessBox.Show(this);
			

            //Common.CloseCurrentFormOnMain();
		}

		void btCancel_Click(object sender, EventArgs e)
		{
            Common.CloseCurrentFormOnMain();
		}

        public override void EpointRelease()
        {
            string strMa_Vt = txtMa_Vt.Text.Trim();
            string strMa_Kho = txtMa_Kho.Text.Trim();
            DateTime dteNgay_Ct1 = Library.StrToDate(this.txtNgay_Ct1.Text);
            DateTime dteNgay_Ct2 = Library.StrToDate(this.txtNgay_Ct2.Text);

            if (Common.GetPartitionCurrent() != 0 && Common.GetPartitionCurrent() != dteNgay_Ct1.Year && Common.GetPartitionCurrent() != dteNgay_Ct2.Year)
            {
                //Common.MsgCancel("Phải chuyển về phân vùng dữ liệu " + dteNgay_Ct1.Year.ToString() + "!");
                EpointProcessBox.AddMessage("Phải chuyển về phân vùng dữ liệu " + dteNgay_Ct1.Year.ToString() + "!");
                return;
            }

            if (!Common.CheckDataLocked(dteNgay_Ct1) || !Common.CheckDataLocked(dteNgay_Ct2))
            {
                EpointProcessBox.AddMessage(EpointMessage.GetMessage("DATALOCK"));
                //Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
                return;
            }

            string[] strArrParaName = new string[] { "@Ngay_Ct1", "@Ngay_Ct2", "@Ma_Vt", "@Ma_Kho", "@Ma_DvCs" };
            object[] objArrParaValue = new object[] { dteNgay_Ct1, dteNgay_Ct2, strMa_Vt, strMa_Kho, Element.sysMa_DvCs };

            //Common.ShowStatus(Languages.GetLanguage("In_Process"));
            EpointProcessBox.AddMessage(Languages.GetLanguage("In_Process"));
            lock (this)
            {
                if (rdbGiaBQTH.Checked)
                {
                    SQLExec.Execute("sp_GiaBQTH", strArrParaName, objArrParaValue, CommandType.StoredProcedure);
                }
                else if (rdbGiaBQTT.Checked)
                {
                    SQLExec.Execute("sp_GiaBQTT", strArrParaName, objArrParaValue, CommandType.StoredProcedure);
                }
                else if (rdbGiaNTXT.Checked)
                    return;
            }

            Element.sysNgay_Ct1 = Library.StrToDate(this.txtNgay_Ct1.Text);
            Element.sysNgay_Ct2 = Library.StrToDate(this.txtNgay_Ct2.Text);

            EpointProcessBox.AddMessage(Languages.GetLanguage("End_Process"));
            //Common.EndShowStatus();
        }
      
	}
}
