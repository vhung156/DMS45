//System
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//Epoint
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Epoint.Lists;
using Epoint.Systems.Commons;

namespace Epoint.Modules.AP
{
    public partial class frmCt_View : frmVoucher_View
    {
        #region Contructor

        public frmCt_View()
        {
            InitializeComponent();
        }

        #endregion

        #region Update

        public override void Edit(enuEdit enuNew_Edit)
        {
            //Khi khóa dữ liệu thì không cho phép Thêm, sửa, xóa chứng từ
            if (enuNew_Edit == enuEdit.New)
            {
                if (!Common.CheckDataLocked(DateTime.Now))
                {
                    if (Parameters.GetParaValue("IS_ALLOW_ADD").ToString().Trim() == "0")
                    {
                        Common.MsgOk(Languages.GetLanguage("IS_ALLOW_ADD"));
                        return;
                    }
                }
            }
            else
            {
                if (drCurrent != null && this.dgvViewPh.dgvGridView.RowCount > 0)
                {
                    if (!Common.CheckDataLocked((DateTime)drCurrent["Ngay_Ct"]))
                    {
                        if (Parameters.GetParaValue("IS_ALLOW_ADD").ToString().Trim() == "0")
                        {
                            Common.MsgOk(Languages.GetLanguage("IS_ALLOW_ADD"));
                            return;
                        }
                    }
                }
            }
            if (bdsViewPh.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            if (bdsViewPh.Position >= 0)
                drCurrent = ((DataRowView)bdsViewPh.Current).Row;
            else
            {
                drCurrent = dtViewPh.NewRow();
                drCurrent["Ma_Ct"] = strMa_Ct_List.Split(',')[0];
                drCurrent["Stt"] = "0";
                drCurrent["Ma_Tte"] = Element.sysMa_Tte;
                drCurrent["Ty_Gia"] = 1;
            }

            ////Khi chung da Duyet -> khong duoc Edit
            //if (dgvViewPh.Columns.Contains("Duyet") && enuNew_Edit == enuEdit.Edit)
            //{
            //    if ((bool)drCurrent["Duyet"] == true)
            //    {
            //        Common.MsgOk(Languages.GetLanguage("NOT_EDIT"));
            //        return;
            //    }
            //}

            if (Common.Inlist(strMa_Ct_List, "PO,VTD"))
            {
                frmCtPO_Edit frmEdit = new frmCtPO_Edit();
                frmEdit.Load(enuNew_Edit, drCurrent, dsVoucher);

                if (frmEdit.isAccept && (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Edit))
                {
                    bdsViewPh.Position = bdsViewPh.Find("Stt", frmEdit.strStt);
                }
            }
            else
            {
                frmCtNM_Edit frmEdit = new frmCtNM_Edit();
                frmEdit.Load(enuNew_Edit, drCurrent, dsVoucher);

                if (frmEdit.isAccept && (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Edit))
                {
                    bdsViewPh.Position = bdsViewPh.Find("Stt", frmEdit.strStt);
                }
            }
        }

        public override void Delete()
        {
            if (bdsViewPh.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsViewPh.Current).Row;

            //Khi khóa dữ liệu thì không cho phép Thêm, sửa, xóa chứng từ
            if (drCurrent != null && this.dgvViewPh.dgvGridView.RowCount > 0)
            {
                if (!Common.CheckDataLocked((DateTime)drCurrent["Ngay_Ct"]))
                {
                    if (Parameters.GetParaValue("IS_ALLOW_ADD").ToString().Trim() == "0")
                    {
                        Common.MsgOk(Languages.GetLanguage("IS_ALLOW_ADD"));
                        return;
                    }
                }
            }

            if (!Element.sysIs_Admin)
            {
                string strCreate_User = (string)drCurrent["Create_Log"];

                if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
                {
                    string strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM SYSMEMBER WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";

                    if (!strUser_Allow.Contains("*,")) //Được phép sửa tất cả
                    {
                        if (!strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
                        {
                            string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Không xóa được chứng từ do " + strCreate_User +
                                        " lập, liên hệ với người quản trị !" : "Do not delete vouchers from " + strCreate_User + " create, contact the administrator !";

                            Common.MsgCancel(strMsg);
                            return;
                        }
                    }
                }
            }

            //Chứng từ đã duyệt: không được xóa
            if (!Element.sysIs_Admin) //Nếu không phải là Admin
            {
                if ((bool)drCurrent["Duyet"] == true && Parameters.GetParaValue("NOT_DELETE_DUYET").ToString().Trim() == "1")
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chứng từ đã duyệt. Không được xóa chứng từ !" : "Approved vouchers. Do not delete the voucher!";

                    Common.MsgCancel(strMsg);
                    return;
                }
            }

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE"), "N"))
                return;

            string strMa_Ct = ((string)drCurrent["Ma_Ct"]).Trim();
            string strStt = ((string)drCurrent["Stt"]).Trim();

            //Luu vao History nhung dong delete-----------------------------------            
            string strTable_Ct = (string)drDmCt["Table_Ct"];
            string strSQL = string.Empty;
            //if (strTable_Ct == "APPO")//Don hang ko co Dinh khoan va Thue nhap khau
            //{
            //    strSQL = "INSERT INTO SYSHISTORYVOUCHER (Member_ID, Update_Type, Ngay_Update, Stt, Stt0, Ma_Ct, Ngay_Ct, So_Ct, Dien_Giai, Ma_TTe, Ty_Gia, Ma_Dt," +
            //                    "Ma_Kho, Ma_KhoN, Ma_Vt, Dvt, So_Luong, Gia, Gia_Nt, Tien, Tien_Nt, Tien2, Tien_Nt2, Tien3, Tien_Nt3, Tien4, Tien_Nt4, Tien5, Tien_Nt5," +
            //                    "Tien6, Tien_Nt6, Tk_No, Tk_Co, Tk_No2, Tk_Co2, Tk_No3, Tk_Co3, Tk_No4, Tk_Co4, Tk_No5, Tk_Co5, Tk_No6, Tk_Co6, Ma_Bp, Ma_Thue, Ma_Sp," +
            //                    "Ma_Km, Ma_Hd, Ma_DvCs) " +
            //                    "SELECT '" + Element.sysUser_Id + "', 'D', '" + DateTime.Now.ToShortDateString() + "', Stt, Stt0, Ma_Ct, Ngay_Ct, So_Ct, Dien_Giai, Ma_TTe, " +
            //                    "Ty_Gia, Ma_Dt, Ma_Kho, '', Ma_Vt, Dvt, So_Luong, Gia, Gia_Nt, Tien, Tien_Nt, 0, 0, Tien3, Tien_Nt3, 0, 0, 0, 0, 0, 0, '', ''," +
            //                    "'', '', '', '', '', '', '', '', '', '', '', Ma_Thue, Ma_Sp, '', '', Ma_DvCs" +
            //                    " FROM " + strTable_Ct + " WHERE Ma_Ct = '" + strMa_Ct + "' AND Stt ='" + strStt + "'";
            //}
            //else
            //{
            //    strSQL = "INSERT INTO SYSHISTORYVOUCHER (Member_ID, Update_Type, Ngay_Update, Stt, Stt0, Ma_Ct, Ngay_Ct, So_Ct, Dien_Giai, Ma_TTe, Ty_Gia, Ma_Dt," +
            //                "Ma_Kho, Ma_KhoN, Ma_Vt, Dvt, So_Luong, Gia, Gia_Nt, Tien, Tien_Nt, Tien2, Tien_Nt2, Tien3, Tien_Nt3, Tien4, Tien_Nt4, Tien5, Tien_Nt5," +
            //                "Tien6, Tien_Nt6, Tk_No, Tk_Co, Tk_No2, Tk_Co2, Tk_No3, Tk_Co3, Tk_No4, Tk_Co4, Tk_No5, Tk_Co5, Tk_No6, Tk_Co6, Ma_Bp, Ma_Thue, Ma_Sp," +
            //                "Ma_Km, Ma_Hd, Ma_DvCs) " +
            //                "SELECT '" + Element.sysUser_Id + "', 'D', '" + DateTime.Now.ToShortDateString() + "', Stt, Stt0, Ma_Ct, Ngay_Ct, So_Ct, Dien_Giai, Ma_TTe, " +
            //                "Ty_Gia, Ma_Dt, Ma_Kho, '', Ma_Vt, Dvt, So_Luong, Gia, Gia_Nt, Tien, Tien_Nt, 0, 0, Tien3, Tien_Nt3, 0, 0, Tien5, Tien_Nt5, Tien6, Tien_Nt6, Tk_No, Tk_Co," +
            //                "'', '', Tk_No3, Tk_Co3, '', '', Tk_No5, Tk_Co5, Tk_No6, Tk_Co6, Ma_Bp, Ma_Thue, Ma_Sp, Ma_Km, Ma_Hd, Ma_DvCs" +
            //                " FROM " + strTable_Ct + " WHERE Ma_Ct = '" + strMa_Ct + "' AND Stt ='" + strStt + "'";
            //}

            //SQLExec.Execute(strSQL);
            //--------------------------------------------------------------------

            if (Voucher.SQLDeleteCt(strStt, strMa_Ct))
            {
                bdsViewPh.RemoveAt(bdsViewPh.Position);
                dtViewPh.AcceptChanges();

                //////Sync Delete----------                
                //string Is_Sync = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM SYSPARAMETER WHERE Parameter_ID = 'SYNC_BEGIN'"));
                //if (Is_Sync == "1")
                //{
                //    SqlConnection sqlCon = SQLExecSync1.GetNewSQLConnectionSync1();
                //    if (sqlCon.State != ConnectionState.Open)
                //    {
                //        SQLExec.Execute("UPDATE SYSPARAMETER SET Parameter_Value = 0 WHERE Parameter_ID = 'SYNC_BEGIN'");
                //    }
                //    else
                //    {
                //        VoucherSync1.SQLDeleteCt(strStt, strMa_Ct);
                //    }
                //}
                //-----------------------

            }
        }

        public override void EditHanTt()
        {
            if (bdsViewPh.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsViewPh.Current).Row;
            string strStt = (string)drCurrent["Stt"];

            if (DataTool.SQLCheckExist("vw_CONGNO", "Stt", strStt))
            {
                DateTime dtNgay_Ct = (DateTime)drCurrent["Ngay_Ct"];
                string strMa_Ct = (string)drCurrent["Ma_Ct"];

                frmHanTt_View frm = new frmHanTt_View();

                frm.Load(dtNgay_Ct, "", "", strStt, strMa_Ct);
            }
        }

        #endregion
    }
}