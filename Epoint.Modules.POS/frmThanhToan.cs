using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Customizes;
using Epoint.Systems.Commons;
using Epoint.Systems.Controls;
using System.Globalization;

namespace Epoint.Modules.POS
{
    public partial class frmThanhToan : Epoint.Systems.Customizes.frmEdit
    {
        public DataRow drEditPh1;
        public DataRow drDmCt1;
        public string strStt1 = string.Empty;
        public string strMa_CbNv = string.Empty;
        bool bSave = false;
        public frmThanhToan()
        {
            InitializeComponent();

            this.numTTien_Dua.Validated += new EventHandler(numTTien_Dua_Validated);
            this.numTTien_Dua.KeyPress += new KeyPressEventHandler(numTTien_Dua_KeyPress);
            this.numTTien_Dua.KeyUp += new KeyEventHandler(numTTien_Dua_KeyUp);


            //this.btInTam.Click += new EventHandler(btInTam_Click);
            this.btPrint.Click += new EventHandler(btPrint_Click);
            this.btExit.Click += new EventHandler(btExit_Click);

            this.KeyDown += new KeyEventHandler(frmThanhToan_KeyDown);
        }

        void numTTien_Dua_KeyUp(object sender, KeyEventArgs e)
        {
            //if (!(e.KeyCode == Keys.Back))
            //{
            //    string text = numTTien_Dua.Text.Replace(".", "");
            //    if (text.Length % 3 == 0)
            //    {
            //        numTTien_Dua.Text += ".";
            //        numTTien_Dua.SelectionStart = numTTien_Dua.Text.Length;
            //    }
            //}
            //numTTien_Dua.Text = String.Format("{0:0,0}", numTTien_Dua.Value.ToString());

            //numTTien_Dua.SelectionStart = numTTien_Dua.Text.Length;
            int num = (int)numTTien_Dua.Value;

            //string snum = SQLExec.ExecuteReturnValue("SELECT  dbo.fn_FormatNumber(" + num.ToString() + ",0,'.')").ToString();
            //numTTien_Dua.Text = snum;
            //numTTien_Dua.SelectionStart = numTTien_Dua.Text.Length;
        }

        void numTTien_Dua_KeyPress(object sender, KeyPressEventArgs e)
        {
            //numTTien_Dua.Text = numTTien_Dua.Text.Replace("..", ".");
            //decimal value;
            //if (decimal.TryParse(
            //    numTTien_Dua.Text,
            //    NumberStyles.Any,
            //    CultureInfo.CurrentCulture,
            //    out value))
            //{
            //    numTTien_Dua.Text = value.ToString(
            //        "### ### ##0",
            //        CultureInfo.InvariantCulture).TrimStart().Replace(".", ",");
            //}

            //if (!string.IsNullOrEmpty(numTTien_Dua.Text))
            //{
            //    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            //    string strValue = numTTien_Dua.Text.Trim().Replace(".", "");
            //    strValue = strValue.Trim().Replace(",", "");
            //    if (strValue == "")
            //        strValue = "0";
            //    int valueBefore = Int32.Parse(strValue, System.Globalization.NumberStyles.AllowThousands);
            //    numTTien_Dua.Text = String.Format(culture, "{0:0,0}", valueBefore);
            //    numTTien_Dua.Select(numTTien_Dua.Text.Length, 0);
            //}

        }
        public void Load()
        {
            txtMa_Tte.Text = "VND";
            numTy_Gia.Value = 1;
            numTTien_Dua.Value = numTTien_Nt.Value;

            this.ShowDialog();
        }
        //void btInTam_Click(object sender, EventArgs e)
        //{
        //    Save3();         
        //    string strReport_File_First = string.Empty;
        //    bool bInVisibleNextPrint = false;
        //    PrintVoucher.Print(drEditPh1, true, true, ref bInVisibleNextPrint, ref strReport_File_First);
        //    enuNew_Edit = enuEdit.Edit;
        //}
        void btPrint_Click(object sender, EventArgs e)
        {
            Save3();
            string strReport_File_First = string.Empty;
            bool bInVisibleNextPrint = false;
            enuNew_Edit = enuEdit.Edit;
            PrintVoucher.Print(drEditPh1, false, true, ref bInVisibleNextPrint, ref strReport_File_First);
            //this.Close();
        }
        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool Save3()
        {

           
            //Cập nhật thông tin xống POSVOUCHER
            string strSQLUpdate = "UPDATE POSVOUCHER SET " +
                    @"Ma_CbNv = @Ma_CbNv, TTien_Dua = @TTien_Dua, TTien_Thoi = @TTien_Thoi" +
                    " WHERE Stt = @Stt";

            Hashtable ht = new Hashtable();
            ht["MA_CBNV"] = strMa_CbNv;
            ht["TTIEN_DUA"] = numTTien_Dua.Value;
            ht["TTIEN_THOI"] = numTTien_Thoi.Value;
            ht["STT"] = strStt1;

            return SQLExec.Execute(strSQLUpdate, ht, CommandType.Text);
            
        }
        void numTTien_Dua_Validated(object sender, EventArgs e)
        {
            if (numTTien_Dua.Value < numTTien_Nt.Value)
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Số tiền khách hàng đưa > Số tiền thanh toán !" : "Amount customers make > Payment amount!";
                Common.MsgCancel(strMsg);
                numTTien_Dua.Focus();
            }
            else
                numTTien_Thoi.Value = Math.Abs(numTTien_Nt.Value - numTTien_Dua.Value);
        }

        void frmThanhToan_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F6)
            //{
            //    if (numTTien_Dua.Value == 0)
            //    {
            //        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Vui lòng nhập số tiền khách hàng đưa !" : "Please enter the amount to the customer";
            //        Common.MsgCancel(strMsg);
            //        numTTien_Dua.Focus();
            //    }
            //    else if (numTTien_Dua.Value < numTTien_Nt.Value)
            //    {
            //        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Số tiền khách hàng đưa > Số tiền thanh toán !" : "Amount customers make > Payment amount!";
            //        Common.MsgCancel(strMsg);
            //        numTTien_Dua.Focus();
            //    }
            //    else
            //    {
            //        Save3();
            //        string strReport_File_First = string.Empty;
            //        bool bInVisibleNextPrint = false;
            //        enuNew_Edit = enuEdit.Edit;
            //        PrintVoucher.Print(drEditPh1, false, false, ref bInVisibleNextPrint, ref strReport_File_First);
            //    }
            //}
            if (e.KeyCode == Keys.F6)
            {
                if (numTTien_Dua.Value == 0)
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Vui lòng nhập số tiền khách hàng đưa !" : "Please enter the amount to the customer";
                    Common.MsgCancel(strMsg);
                    numTTien_Dua.Focus();
                }
                else if (numTTien_Dua.Value < numTTien_Nt.Value)
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Số tiền khách hàng đưa > Số tiền thanh toán !" : "Amount customers make > Payment amount!";
                    Common.MsgCancel(strMsg);
                    numTTien_Dua.Focus();
                }
                else
                {
                    Save3();

                    //Tự động tạo phiếu thu tiền
                    Hashtable ht = new Hashtable();
                    ht["STT"] = strStt1;
                    ht["NGAY_CT"] = drEditPh1["Ngay_Ct"];
                    ht["SO_CT"] = drEditPh1["So_Ct"];
                    ht["MA_DT"] = drEditPh1["Ma_Dt"];
                    ht["TIEN"] = drEditPh1["TTien0"];
                    ht["TIEN_NT"] = drEditPh1["TTien_Nt0"];
                    ht["TK_NO"] = drDmCt1["TK_No"];
                    ht["TK_CO"] = drDmCt1["TK_Co"];
                    ht["MA_DVCS"] = drEditPh1["Ma_DvCs"];

                    SQLExec.Execute("sp_UpdatePOS_InsertPT", ht, CommandType.StoredProcedure);

                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Đã lưu !" : " Save successful !";
                    Common.MsgCancel(strMsg);
                }
            }

            if (e.KeyCode == Keys.F7)
            {
                if (numTTien_Dua.Value == 0)
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Vui lòng nhập số tiền khách hàng đưa !" : "Please enter the amount to the customer";
                    Common.MsgCancel(strMsg);
                    numTTien_Dua.Focus();
                }
                else if (numTTien_Dua.Value < numTTien_Nt.Value)
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Số tiền khách hàng đưa > Số tiền thanh toán !" : "Amount customers make > Payment amount!";
                    Common.MsgCancel(strMsg);
                    numTTien_Dua.Focus();
                }
                else
                {
                    Save3();

                    //Tự động tạo phiếu thu tiền
                    Hashtable ht = new Hashtable();
                    ht["STT"] = strStt1;
                    ht["NGAY_CT"] = drEditPh1["Ngay_Ct"];
                    ht["SO_CT"] = drEditPh1["So_Ct"];
                    ht["MA_DT"] = drEditPh1["Ma_Dt"];
                    ht["TIEN"] = drEditPh1["TTien0"];
                    ht["TIEN_NT"] = drEditPh1["TTien_Nt0"];
                    ht["TK_NO"] = drDmCt1["TK_No"];
                    ht["TK_CO"] = drDmCt1["TK_Co"];
                    ht["MA_DVCS"] = drEditPh1["Ma_DvCs"];

                    SQLExec.Execute("sp_UpdatePOS_InsertPT", ht, CommandType.StoredProcedure);

                    string strReport_File_First = string.Empty;
                    bool bInVisibleNextPrint = false;
                    enuNew_Edit = enuEdit.Edit;
                    PrintVoucher.Print(drEditPh1, false, false, ref bInVisibleNextPrint, ref strReport_File_First);
                    this.Close();
                }
            }

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            else if (keyData == Keys.Enter)
            {
                if (numTTien_Dua.Value < numTTien_Nt.Value)
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Số tiền khách hàng đưa > Số tiền thanh toán !" : "Amount customers make > Payment amount!";
                    Common.MsgCancel(strMsg);
                    numTTien_Dua.Focus();
                }
                else
                    numTTien_Thoi.Value = Math.Abs(numTTien_Nt.Value - numTTien_Dua.Value);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
