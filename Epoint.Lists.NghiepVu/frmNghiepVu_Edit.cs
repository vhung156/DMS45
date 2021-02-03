using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;

namespace Epoint.Lists
{
	public partial class frmNghiepVu_Edit : Epoint.Lists.frmEdit
	{		

        #region Phuong thuc

		public frmNghiepVu_Edit()
		{
			InitializeComponent();

            btMa_Ct_List.Click += new EventHandler(btMa_Ct_List_Click);
            txtTk_No.Validating += new CancelEventHandler(txtTk_No_Validating);
            txtTk_Co.Validating += new CancelEventHandler(txtTk_Co_Validating);
        }

        public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

            //New: khi them moi thi khong can ke thua
            if (enuNew_Edit != enuEdit.New)
                Common.ScaterMemvar(this, ref drEdit);

            //Edit: Disable Ma_Kho
            if (enuNew_Edit == enuEdit.Edit)
                txtMa_Nvu.Enabled = false;

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
            //Tk_No
            if (txtTk_No.Text.Trim() != string.Empty)
            {
                lbtTen_Tk_No.Text = DataTool.SQLGetNameByCode("LITAIKHOAN", "Tk", "Ten_Tk", txtTk_No.Text.Trim());
                dicName.Add(lbtTen_Tk_No.Name, lbtTen_Tk_No.Text);
            }
            else
                lbtTen_Tk_No.Text = string.Empty;

            //Tk_Co
            if (txtTk_Co.Text.Trim() != string.Empty)
            {
                lbtTen_Tk_Co.Text = DataTool.SQLGetNameByCode("LITAIKHOAN", "Tk", "Ten_Tk", txtTk_Co.Text.Trim());
                dicName.Add(lbtTen_Tk_Co.Name, lbtTen_Tk_Co.Text);
            }
            else
                lbtTen_Tk_Co.Text = string.Empty;
        }

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_Nvu.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Kho") + " " +
							  Languages.GetLanguage("Not_Null"));
                return false;
            }			

			if (txtTen_Nvu.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Kho") + " " +
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

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "LINGHIEPVU", ref drEdit))
				return false;

            ////Sync data-------------
            //string Is_Sync = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM SYSPARAMETER WHERE Parameter_ID = 'SYNC_BEGIN'"));
            //if (Is_Sync == "1")
            //{
            //    SqlConnection sqlCon = SQLExecSync1.GetNewSQLConnectionSync1();
            //    if (sqlCon.State != ConnectionState.Open)
            //    {
            //        SQLExec.Execute("UPDATE SYSPARAMETER SET Parameter_Value = 0 WHERE Parameter_ID = 'SYNC_BEGIN'");
            //        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Quá trình đồng bộ đang bị gián đoạn. Vui lòng chờ trong ít phút !" : "The synchronization process is interrupted. Please wait a few minutes !";
            //        Common.MsgCancel(strMsg);
            //    }
            //    else
            //    {
            //        DataToolSync1.SQLUpdate(enuNew_Edit, "LINGHIEPVU", ref drEdit);
            //    }
            //}
            ////----------------------

            ////Doi ma
            //if (this.enuNew_Edit == enuEdit.Edit)
            //    DataTool.SQLChangeID("MA_KHO", drEdit);

            ////Sync data-------------            
            //if (Is_Sync == "1")
            //{
            //    SqlConnection sqlCon = SQLExecSync1.GetNewSQLConnectionSync1();
            //    if (sqlCon.State != ConnectionState.Open)
            //    {
            //        SQLExec.Execute("UPDATE SYSPARAMETER SET Parameter_Value = 0 WHERE Parameter_ID = 'SYNC_BEGIN'");
            //        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Quá trình đồng bộ đang bị gián đoạn. Vui lòng chờ trong ít phút !" : "The synchronization process is interrupted. Please wait a few minutes !";
            //        Common.MsgCancel(strMsg);
            //    }
            //    else
            //    {
            //        DataToolSync1.SQLChangeID("MA_KHO", drEdit);
            //    }
            //}
            ////----------------------

			return true;
		}
        #endregion

        #region Su kien
        void btMa_Ct_List_Click(object sender, EventArgs e)
        {
            string strValue = txtMa_Ct_List.Text.Trim();

            DataRow drLookup = Lookup.ShowMultiLookup("Ma_Ct", "", true, "", "");
            if (drLookup == null)
                txtMa_Ct_List.Text = string.Empty;
            else
            {
                txtMa_Ct_List.Text = drLookup["MuiltiSelectValue"].ToString();
            }
        }

        private void txtTk_No_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtTk_No.Text.Trim();
            bool bRequire = false;

            //frmTaiKhoan frmLookup = new frmTaiKhoan();
            DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtTk_No.Text = string.Empty;
                lbtTen_Tk_No.Text = string.Empty;
            }
            else
            {
                txtTk_No.Text = ((string)drLookup["Tk"]).Trim();
                lbtTen_Tk_No.Text = ((string)drLookup["Ten_Tk"]).Trim();
            }

            dicName.SetValue(lbtTen_Tk_No.Name, lbtTen_Tk_No.Text);
        }

        private void txtTk_Co_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtTk_Co.Text.Trim();
            bool bRequire = false;

            frmTaiKhoan frmLookup = new frmTaiKhoan();
            DataRow drLookup = Lookup.ShowLookup(frmLookup, "LITAIKHOAN", "Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtTk_Co.Text = string.Empty;
                lbtTen_Tk_Co.Text = string.Empty;
            }
            else
            {
                txtTk_Co.Text = ((string)drLookup["Tk"]).Trim();
                lbtTen_Tk_Co.Text = ((string)drLookup["Ten_Tk"]).Trim();
            }

            dicName.SetValue(lbtTen_Tk_Co.Name, lbtTen_Tk_Co.Text);
        }

        #endregion
    }
}