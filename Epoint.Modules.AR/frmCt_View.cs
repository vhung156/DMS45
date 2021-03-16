﻿//System
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

namespace Epoint.Modules.AR
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

            if (Common.Inlist(strMa_Ct_List, "SO"))
            {
                frmCtSO_Edit frmEdit = new frmCtSO_Edit();
                frmEdit.Load(enuNew_Edit, drCurrent, dsVoucher);

                if (frmEdit.isAccept && (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Edit))
                {
                    bdsViewPh.Position = bdsViewPh.Find("Stt", frmEdit.strStt);
                }
            }
            else
            {
                frmCtHD_Edit frmEdit = new frmCtHD_Edit();
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

            if (!Common.CheckDataLocked((DateTime)drCurrent["Ngay_Ct"]))
            {

                return;
            }

            if (Voucher.CheckDataLockedCtHanTtHD((string)drCurrent["Stt"]))
            {
                Common.MsgCancel("Chứng từ đã được thanh toán không được xóa !");
                return;

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
                            Common.MsgCancel("Không được xóa chứng từ do " + strCreate_User.Substring(14) + " lập, liên hệ với Admin!");
                            return;
                        }
                    }
                }
            }

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE"), "N"))
                return;

            string strMa_Ct = ((string)drCurrent["Ma_Ct"]).Trim();
            string strStt = ((string)drCurrent["Stt"]).Trim();

            if(dgvViewPh.dgvGridView.IsMultiSelect)// Chọn nhiều đơn hàng để xóa
            {
                int ivoucher = dgvViewPh.dgvGridView.SelectedRowsCount;

                if (ivoucher == 1)
                    if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE"), "N"))
                        return;

                if (ivoucher > 1)
                    if (!Common.MsgYes_No("Bạn có chắc chắn xóa " + ivoucher.ToString() + " hóa đơn?", "N"))
                        return;

                int[] a = dgvViewPh.dgvGridView.GetSelectedRows();
                for (int i = (a.Length - 1); i >= 0; i--)
                {
                    int istt = a[i];
                    string stt = dgvViewPh.dgvGridView.GetRowCellValue(istt, "STT").ToString();
                    if (Voucher.SQLDeleteCt(stt, strMa_Ct))
                    {
                        bdsViewPh.RemoveAt(bdsViewPh.Position);
                        dtViewPh.AcceptChanges();
                    }
                }

                this.FillDataNew();

            }
            else // Chỉ xóa 1 đơn hàng
            {
                if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE"), "N"))
                    return;
                //--------------------------------------------------------------------

                if (Voucher.SQLDeleteCt(strStt, strMa_Ct))
                {
                    bdsViewPh.RemoveAt(bdsViewPh.Position);
                    dtViewPh.AcceptChanges();
                }
            }
        }

        public override void EditHanTt()
        {
            if (bdsViewPh.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsViewPh.Current).Row;
            string strStt = (string)drCurrent["Stt"];

            if (DataTool.SQLCheckExist("vw_CongNo", "Stt", strStt))
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