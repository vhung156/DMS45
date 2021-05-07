using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Elements;
using Epoint.Systems.Data;
using System.Collections;

namespace Epoint.Modules.AR
{
    public partial class frmPXK : Epoint.Systems.Customizes.frmView
    {

        string strMa_PX = String.Empty;
        DateTime dte_Ngay;
        string strMa_Ct = "PXK";
        bool Is_Load = false;

        DataTable dtPXK;
        BindingSource bdsPXK = new BindingSource();
        DataRow drCurrentPXK;


        DataTable dtPXKDetail;
        BindingSource bdsPXKDetail = new BindingSource();

        string strOptionMsg = string.Empty;


        public frmPXK()
        {
            InitializeComponent();

            bdsPXK.PositionChanged += new EventHandler(bdsPXK_PositionChanged);
            //bdsDiscBreak.PositionChanged += new EventHandler(bdsDiscBreak_PositionChanged);
            //dgvPXK.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvPXK_CellMouseClick);

            dgvPXK.dgvGridView.Click += new EventHandler(dgvPXK_CellMouseClick);
            dgvPXDetail.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvPXDetail_CellMouseDoubleClick);//; += new EventHandler(dgvPXDetail_CellMouseDoubleClick);
            this.KeyDown += new KeyEventHandler(KeyDownEvent);
            this.cboMa_Ct.SelectedIndexChanged += new EventHandler(cboMa_Ct_SelectedIndexChanged);
            this.btFillterData.Click += new EventHandler(btFillData_Click);
            this.btPrint000.Click += new EventHandler(btPrintClick);
            this.btPrintReport.Click += new EventHandler(btPrintReport_Click);
        }

        public override void Load()
        {
            BindingCombobox();
            this.Object_ID = "PXKLIST";
            this.Build();
            this.FillData();
            this.txtMau_In.Text = "rptPXK";
            this.strOptionMsg = Parameters.GetParaValue("CHECKTHANHTOAN") == null ? "N" : Convert.ToString(Parameters.GetParaValue("CHECKTHANHTOAN"));
            Is_Load = true;
            this.Show();
        }
        private void Init()
        {

        }
        private void Build()
        {
            dgvPXK.strZone = "OM_PXK";
            dgvPXK.BuildGridView(this.isLookup);
            ExportControl = dtPXK;



            dgvPXDetail.strZone = "OM_PXDETAIL";
            dgvPXDetail.BuildGridView(this.isLookup);
            ExportControl = dtPXKDetail;

            int iInterval = Convert.ToInt32(Parameters.GetParaValue("DAY_FILTER"));
            DateTime dNgay_Ct1 = Element.sysNgay_Ct2.Subtract(new TimeSpan(iInterval, 0, 0, 0));

            dteNgay_Ct1.Text = Library.DateToStr(dNgay_Ct1);
            dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);
        }
        private void BindingCombobox()
        {
            string strSQL = @" sp_OM_GetCombovalue @Key = 'PXK'";
            cbxReport_List.DataSource = SQLExec.ExecuteReturnDt(strSQL, CommandType.Text);
            cbxReport_List.ValueMember = "ID";
            cbxReport_List.DisplayMember = "Value";

            strSQL = @" sp_OM_GetCombovalue @Key = 'MA_CT'";
            cboMa_Ct.DataSource = SQLExec.ExecuteReturnDt(strSQL, CommandType.Text);
            cboMa_Ct.ValueMember = "ID";
            cboMa_Ct.DisplayMember = "Value";
        }
        private void FillData()
        {


            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            ht.Add("LOAI_PX", cboMa_Ct.SelectedValue.ToString());
            ht.Add("SO_CT", txtSo_Ct.Text);
            ht.Add("USERID", Element.sysUser_Id);
            ht.Add("MA_DVCS", Element.sysMa_DvCs);

            DataSet dsPXK = SQLExec.ExecuteReturnDs("sp_GetPhieuXuatKho", ht, CommandType.StoredProcedure);

            dtPXK = dsPXK.Tables[0];

            DataColumn dc = new DataColumn("Selected", typeof(bool));
            dc.DefaultValue = false;
            dtPXK.Columns.Add(dc);


            bdsPXK.DataSource = dtPXK;
            dgvPXK.DataSource = bdsPXK;
            //Uy quyen cho lop co so tim kiem
            bdsSearch = bdsPXK;
            ExportControl = dgvPXK;



            dtPXKDetail = dsPXK.Tables.Count > 1 ? dsPXK.Tables[1] : SQLExec.ExecuteReturnDt("sp_GetPhieuXuatKhoDetail", ht, CommandType.StoredProcedure);

            bdsPXKDetail.DataSource = dtPXKDetail;
            dgvPXDetail.DataSource = bdsPXKDetail;

            if (bdsPXK.Count >= 0)
                bdsPXK.Position = bdsPXK.Count - 1;


        }

        public override void Edit(enuEdit enuNew_Edit)
        {
            if (dgvPXK.Focused)
                EditPXK(enuNew_Edit);
            else if (dgvPXDetail.Focused)
                EditPXK(enuNew_Edit);

        }
        private void EditPXK(enuEdit enuNew_Edit)
        {
            if (bdsPXK.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai
            if (bdsPXK.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsPXK.Current).Row, ref drCurrentPXK);
            else
                drCurrentPXK = dtPXK.NewRow();

            frmGopPXK_Edit frmEdit = new frmGopPXK_Edit();
            frmEdit.strMa_Ct = this.strMa_Ct;
            frmEdit.Load(enuNew_Edit, drCurrentPXK);

            //Accept
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsPXK.Position >= 0)
                        dtPXK.ImportRow(drCurrentPXK);
                    else
                        dtPXK.Rows.Add(drCurrentPXK);

                    bdsPXK.Position = bdsPXK.Find("Ma_PX", drCurrentPXK["Ma_PX"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrentPXK, ((DataRowView)bdsPXK.Current).Row);
                }

                dtPXK.AcceptChanges();

                Hashtable ht = new Hashtable();
                ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
                ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
                ht.Add("MA_DVCS", Element.sysMa_DvCs);

                dtPXKDetail = SQLExec.ExecuteReturnDt("sp_GetPhieuXuatKhoDetail", ht, CommandType.StoredProcedure);
                bdsPXKDetail.DataSource = dtPXKDetail;
                dgvPXDetail.DataSource = bdsPXKDetail;
            }
            else
                dtPXK.RejectChanges();

        }

        private bool CheckThanhToan(DataRow drCurrent)
        {
            DataRow[] drDetail = dtPXKDetail.Select("Ma_PX = '" + drCurrent["Ma_Px"].ToString() + "'");
            foreach (DataRow dr in drDetail)
            {
                if (Voucher.CheckDataLockedCtHanTtHD((string)dr["Stt"]))
                {
                    if (strOptionMsg == "Y")
                    {
                        EpointMessage.MsgOk(dr["So_Ct"].ToString() + ": Chứng từ đã được thanh toán. không thể xóa PXK!");
                        return true;
                    }
                    else
                    {
                        if (!Common.MsgYes_No("Các chứng từ thanh toán thuộc phiếu xuất kho sẽ bị hủy !" + Languages.GetLanguage("SURE_DELETE")))
                            return true;
                    }
                }
            }
            return false;
        }
        public override void Delete()
        {

            DataRow drCurrent = ((DataRowView)bdsPXK.Current).Row;

            if (!Common.CheckDataLocked(dte_Ngay))
            {
                EpointMessage.MsgOk("Ngày dữ liệu đã bị khóa !");
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


            if (dgvPXK.Focused)
                DeletePXK();
            else if (dgvPXDetail.Focused)
                DeletePXKDetail();

        }


        private void DeletePXK()
        {
            if (bdsPXK.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsPXK.Current).Row;

            if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
            {
                EpointMessage.MsgOk("Không có quyền xóa được PXK");
                return;
            }


            if (!CheckThanhToan(drCurrent))
            {
                if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                    return;

                Hashtable htPara = new Hashtable();
                htPara["MA_PX"] = drCurrent["MA_PX"].ToString();
                htPara["USERID"] = Element.sysUser_Id;
                htPara["MA_DVCS"] = Element.sysMa_DvCs;

                if (SQLExec.Execute("sp_Delete_PXK", htPara, CommandType.StoredProcedure))
                {
                    bdsPXK.RemoveAt(bdsPXK.Position);
                    dtPXK.AcceptChanges();
                }
                else
                {
                    EpointMessage.MsgOk("Không xóa được PXK");
                }
            }
        }
        private void DeletePXKDetail()
        {
            if (bdsPXK.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsPXKDetail.Current).Row;

            if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit))
            {
                EpointMessage.MsgOk("Không có quyền sửa Phiếu xuất");
                return;
            }


            if (Voucher.CheckDataLockedCtHanTtHD((string)drCurrent["Stt"]))
            {
                //if (!Common.MsgYes_No("Chứng từ đã được thanh toán . Bạn có muốn xóa thanh toán của chứng từ này !"))
                //    return;
                if (strOptionMsg == "Y")
                {
                    EpointMessage.MsgOk(" Chứng từ đã được thanh toán. không thể xóa!");
                    return;
                }
                else
                {
                    if (!Common.MsgYes_No("Các chứng từ thanh toán thuộc phiếu xuất kho sẽ bị hủy !" + Languages.GetLanguage("SURE_DELETE")))
                        return;
                }
            }
            else if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE") + " Chi tiết phiếu xuất"))
                return;



            Hashtable htPara = new Hashtable();
            htPara["MA_PX"] = drCurrent["MA_PX"].ToString();
            htPara["STT"] = drCurrent["STT"].ToString();
            htPara["USERID"] = Element.sysUser_Id;
            htPara["MA_DVCS"] = Element.sysMa_DvCs;
            //if (DataTool.SQLDelete("OM_PXKDetail",drCurrent))
            if (SQLExec.Execute("sp_Delete_PXKDetail", htPara, CommandType.StoredProcedure))
            {
                bdsPXKDetail.RemoveAt(bdsPXKDetail.Position);
                dtPXKDetail.AcceptChanges();


                FillData();
                //bdsPXK.Position = bdsPXK.Find("Ma_PX", this.strMa_PX);
            }
            else
            {
                EpointMessage.MsgOk("Không xóa được chi tiết");
            }
        }

        #region Sự kiện

        void bdsPXK_PositionChanged(object sender, EventArgs e)
        {
            if (bdsPXK.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsPXK.Current).Row, ref drCurrentPXK);

            this.strMa_PX = drCurrentPXK["Ma_PX"].ToString();
            this.dte_Ngay = Convert.ToDateTime(drCurrentPXK["Ngay_Ct"]);
            bdsPXKDetail.Filter = "Ma_PX = '" + strMa_PX + "'";




        }

        void cboMa_Ct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Is_Load)
                FillData();
        }
        void dgvPXK_CellMouseClick(object sender, EventArgs e)
        {
            //if (e.ColumnIndex < 0 || e.RowIndex < 0)
            //    return;

            //string strColumnName = dgvPXK.Columns[e.ColumnIndex].Name.ToUpper();

            if (bdsPXK.Position < 0)
                return;
            string strColumnName = dgvPXK.dgvGridView.FocusedColumn.Name;

            DataRow drCurrent = ((DataRowView)bdsPXK.Current).Row;

            if (strColumnName == "SELECTED")
            {
                drCurrent[strColumnName] = !Convert.ToBoolean(drCurrent[strColumnName]);
                drCurrent.AcceptChanges();
            }
        }
        void dgvPXDetail_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (bdsPXKDetail.Position < 0)
                return;
            string strColumnName = dgvPXDetail.Columns[e.ColumnIndex].Name.ToUpper();

            DataRow drCurrentDetail = ((DataRowView)bdsPXKDetail.Current).Row;

            string stt = drCurrentDetail["Stt"].ToString();

            frmSaleOrder_Edit frmEdit = new frmSaleOrder_Edit();
            frmEdit.Load(enuEdit.Edit, drCurrentDetail, null);

        }
        void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if (bdsPXK.Position < 0)
                return;
            DataRow drCurrent = ((DataRowView)bdsPXK.Current).Row;
            switch (e.KeyCode)
            {
                case Keys.F9:
                    //this.Filter();
                    break;

                case Keys.F7:
                    switch (e.Modifiers)
                    {
                        case Keys.Shift:
                            Design();
                            break;
                        case Keys.Control:
                            PrintVoucher.PrintInvoices(drCurrent["Ma_Px"].ToString());
                            break;
                    }
                    break;



            }
        }
        private void Print(bool bPreview)
        {
            if (bdsPXK.Position < 0)
                return;


            bool bAcceptShowDialog = true;
            bool bInVisibleNextPrint = false;
            string strReport_File_First = string.Empty;
            string strMa_PX_List = "";


            DataRow drCurrent = ((DataRowView)bdsPXK.Current).Row;


            DataRow[] drArrPrint = dtPXK.Select("Selected = true");

            if (drArrPrint.Length > 1)
            {
                for (int i = 0; i < drArrPrint.Length; i++)
                {
                    strMa_PX_List += drArrPrint[i]["Ma_Px"].ToString() + ",";
                }
                PrintVoucher.PrintPXK(strMa_PX_List, bPreview, true, ref bInVisibleNextPrint, ref strReport_File_First, drCurrent);
            }
            else
            {
                PrintVoucher.PrintPXK(this.strMa_PX, bPreview, true, ref bInVisibleNextPrint, ref strReport_File_First, drCurrent);
            }
        }

        private void PrintListOrder(bool bPreview)
        {
            if (bdsPXK.Position < 0)
                return;


            bool bAcceptShowDialog = true;
            bool bInVisibleNextPrint = false;
            string strReport_File_First = "rptPXKList";
            string strMa_PX_List = "";


            DataRow drCurrent = ((DataRowView)bdsPXK.Current).Row;
            DataRow[] drArrPrint = dtPXK.Select("Selected = true");

            if (drArrPrint.Length > 1)
            {
                for (int i = 0; i < drArrPrint.Length; i++)
                {
                    strMa_PX_List += drArrPrint[i]["Ma_Px"].ToString() + ",";
                }
                PrintVoucher.PrintListOrder(strMa_PX_List, bPreview, true, ref bInVisibleNextPrint, ref strReport_File_First);
            }
            else
            {
                PrintVoucher.PrintListOrder(this.strMa_PX, bPreview, true, ref bInVisibleNextPrint, ref strReport_File_First);
            }
        }

        public void PrintDTT05()
        {

            if (bdsPXK.Position < 0)
                return;

            string strReport_ID = "DTT06";

            DataRow drCurrent = ((DataRowView)bdsPXK.Current).Row;

            DataRow drReport = DataTool.SQLGetDataRowByID("SYSREPORT", "Report_Id", strReport_ID);
            DataRow drFilter = Epoint.Reports.Report.GetdrFilter(drReport);
            drFilter["Ngay_Ct1"] = drCurrent["Ngay_Ct"];
            drFilter["Ngay_Ct2"] = drCurrent["Ngay_Ct"];
            drFilter["MA_PX"] = drCurrent["Ma_PX"];
            //drFilter["Kieu_Th"] = "9";
            //drFilter["Kieu_Nh"] = "3";

            Epoint.Reports.Report.RunReport(drFilter, drReport);

        }
        public void PrintDTT02()
        {

            if (bdsPXK.Position < 0)
                return;


            string strReport_ID = "DTT02_1";
            DataRow drCurrent = ((DataRowView)bdsPXK.Current).Row;

            DataRow drReport = DataTool.SQLGetDataRowByID("SYSREPORT", "Report_Id", strReport_ID);
            DataRow drFilter = Epoint.Reports.Report.GetdrFilter(drReport);
            drFilter["Ngay_Ct1"] = drCurrent["Ngay_Ct"];
            drFilter["Ngay_Ct2"] = drCurrent["Ngay_Ct"];
            drFilter["MA_PX"] = drCurrent["Ma_PX"];
            //drFilter["Kieu_Th"] = "9";
            //drFilter["Kieu_Nh"] = "3";

            Epoint.Reports.Report.RunReport(drFilter, drReport);

        }
        public void PrintDTT05_1()
        {

            if (bdsPXK.Position < 0)
                return;

            string strReport_ID = "DTT05";
            DataRow drCurrent = ((DataRowView)bdsPXK.Current).Row;

            DataRow drReport = DataTool.SQLGetDataRowByID("SYSREPORT", "Report_Id", strReport_ID);
            DataRow drFilter = Epoint.Reports.Report.GetdrFilter(drReport);
            drFilter["Ngay_Ct1"] = drCurrent["Ngay_Ct"];
            drFilter["Ngay_Ct2"] = drCurrent["Ngay_Ct"];
            drFilter["MA_PX"] = drCurrent["Ma_PX"];
            //drFilter["Kieu_Th"] = "9";
            //drFilter["Kieu_Nh"] = "9";

            Epoint.Reports.Report.RunReport(drFilter, drReport);

        }
        private void Design()
        {
            //txtMau_In.Visible = true;

            Epoint.Reports.frmReportDesign frm = new Epoint.Reports.frmReportDesign();
            frm.Load("rpt" + cbxReport_List.SelectedValue.ToString());

        }
        void btFillData_Click(object sender, EventArgs e)
        {
            FillData();
        }

        void btPrintClick(object sender, EventArgs e)
        {
            Print(true);
        }

        void btPrintReport_Click(object sender, EventArgs e)
        {
            string strRPT = cbxReport_List.SelectedValue.ToString();

            if (strRPT == "PXK")
                Print(true);
            else if (strRPT == "PXKLIST")
                PrintListOrder(true);
            else if (strRPT == "INVOICE")
            {
                if (bdsPXK.Position < 0)
                    return;
                DataRow drCurrent = ((DataRowView)bdsPXK.Current).Row;

                PrintVoucher.PrintInvoices(drCurrent["Ma_Px"].ToString());
            }
            else if (strRPT == "DTT02")
                PrintDTT02();
            else if (strRPT == "DTT05")
                PrintDTT05();
            else if (strRPT == "DTT05_1")
                PrintDTT05_1();


        }

        #endregion
    }
}
