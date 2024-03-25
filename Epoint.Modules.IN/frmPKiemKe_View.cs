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

namespace Epoint.Modules.IN
{
    public partial class frmPKiemKe_View : Epoint.Systems.Customizes.frmView
    {

        string strStt = String.Empty;
        DateTime dte_Ngay;
        string strMa_Ct = "KK";
        bool Is_Load = false;

        DataTable dtPKK;
        BindingSource bdsPKK = new BindingSource();
        DataRow drCurrent;


        DataTable dtPKKDetail;
        BindingSource bdsPKKDetail = new BindingSource();

        string strOptionMsg = string.Empty;


        public frmPKiemKe_View()
        {
            InitializeComponent();

            bdsPKK.PositionChanged += new EventHandler(bdsPXK_PositionChanged);

            //bdsDiscBreak.PositionChanged += new EventHandler(bdsDiscBreak_PositionChanged);
            //dgvPXK.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvPXK_CellMouseClick);

            dgvKK_PH.dgvGridView.Click += new EventHandler(dgvPXK_CellMouseClick);
            dgvKKDetail.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvPXDetail_CellMouseDoubleClick);//; += new EventHandler(dgvPXDetail_CellMouseDoubleClick);
            this.KeyDown += new KeyEventHandler(KeyDownEvent);
            this.btFillterData.Click += new EventHandler(btFillData_Click);
            this.btPrint000.Click += new EventHandler(btPrintClick);
            this.btPrintReport.Click += new EventHandler(btPrintReport_Click);
        }

        public override void Load()
        {
            BindingCombobox();
            this.Object_ID = "PXK";
            this.Build();
            this.FillData();
            this.txtMau_In.Text = "rptPXK";
            //this.strOptionMsg = Parameters.GetParaValue("CHECKTHANHTOAN") == null ? "N" : Convert.ToString(Parameters.GetParaValue("CHECKTHANHTOAN"));
            Is_Load = true;
            this.Show();
        }
        private void Init()
        {

        }
        private void Build()
        {
            dgvKK_PH.strZone = "KK_VIEWPH";
            dgvKK_PH.BuildGridView(this.isLookup);
            ExportControl = dtPKK;



            dgvKKDetail.strZone = "KK_VIEWCT";
            dgvKKDetail.BuildGridView(this.isLookup);
            ExportControl = dtPKKDetail;

            int iInterval = Convert.ToInt32(Parameters.GetParaValue("DAY_FILTER"));
            DateTime dNgay_Ct1 = Element.sysNgay_Ct2.Subtract(new TimeSpan(iInterval, 0, 0, 0));

            dteNgay_Ct1.Text = Library.DateToStr(dNgay_Ct1);
            dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);
        }
        private void BindingCombobox()
        {
            string strSQL = @" sp_OM_GetCombovalue @Key = 'PKK'";
            cbxReport_List.DataSource = SQLExec.ExecuteReturnDt(strSQL, CommandType.Text);
            cbxReport_List.ValueMember = "ID";
            cbxReport_List.DisplayMember = "Value";

        }
        private void FillData()
        {


            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            //ht.Add("LOAI_PX", cboMa_Ct.SelectedValue.ToString());
            ht.Add("MA_KHO", txtMa_KhoKK.Text);
            ht.Add("USERID", Element.sysUser_Id);
            ht.Add("MA_DVCS", Element.sysMa_DvCs);

            DataSet dsPKiemKe = SQLExec.ExecuteReturnDs("sp_IN_GetDataBeginKiemKe", ht, CommandType.StoredProcedure);

            dtPKK = dsPKiemKe.Tables[0];

            DataColumn dc = new DataColumn("Selected", typeof(bool));
            dc.DefaultValue = false;
            dtPKK.Columns.Add(dc);


            bdsPKK.DataSource = dtPKK;
            dgvKK_PH.DataSource = bdsPKK;
            //Uy quyen cho lop co so tim kiem
            bdsSearch = bdsPKK;
            ExportControl = dgvKK_PH;



            dtPKKDetail = dsPKiemKe.Tables[1];
            bdsPKKDetail.DataSource = dtPKKDetail;
            dgvKKDetail.DataSource = bdsPKKDetail;

            if (bdsPKK.Count >= 0)
                bdsPKK.Position = bdsPKK.Count - 1;


        }

        public override void Edit(enuEdit enuNew_Edit)
        {
            if (dgvKK_PH.Focused)
                EditPKK(enuNew_Edit);
            else if (dgvKKDetail.Focused)
                EditPKK(enuNew_Edit);

        }
        private void EditPKK(enuEdit enuNew_Edit)
        {
            if (bdsPKK.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai
            if (bdsPKK.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsPKK.Current).Row, ref drCurrent);
            else
            {
                drCurrent = dtPKK.NewRow();
                drCurrent["Ma_Ct"] = "KK";
                drCurrent["Stt"] = "0";
                drCurrent["Ma_Tte"] = Element.sysMa_Tte;
                drCurrent["Ty_Gia"] = 1;
            }

            frmCtKiemKe_Edit frmEdit = new frmCtKiemKe_Edit();
            frmEdit.strMa_Ct = this.strMa_Ct;
            frmEdit.Load(enuNew_Edit, drCurrent);

            //Accept
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsPKK.Position >= 0)
                        dtPKK.ImportRow(drCurrent);
                    else
                        dtPKK.Rows.Add(drCurrent);

                    bdsPKK.Position = bdsPKK.Find("Stt", drCurrent["Stt"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsPKK.Current).Row);
                }

                dtPKK.AcceptChanges();

            }
            else
                dtPKK.RejectChanges();

        }


        public override void Delete()
        {

            DataRow drCurrent = ((DataRowView)bdsPKK.Current).Row;

            if (Convert.ToBoolean(drCurrent["Xu_Ly"]))
            {
                EpointMessage.MsgOk("Phiếu xuât kho đã dược xử lý!");
                return;
            }

            if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
            {
                EpointMessage.MsgOk("Không có quyền xóa được phiếu xuất kho!");
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


            if (dgvKK_PH.Focused)
                DeletePhieuKiemKe();
        }


        private void DeletePhieuKiemKe()
        {
            if (bdsPKK.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsPKK.Current).Row;


            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            Hashtable htPara = new Hashtable();
            htPara["STT"] = drCurrent["STT"].ToString();
            htPara["USERID"] = Element.sysUser_Id;
            htPara["MA_DVCS"] = Element.sysMa_DvCs;

            if (SQLExec.Execute("sp_Delete_PKiemKe", htPara, CommandType.StoredProcedure))
            {
                bdsPKK.RemoveAt(bdsPKK.Position);
                dtPKK.AcceptChanges();
            }
            else
            {
                EpointMessage.MsgOk("Không xóa được phiếu kiểm kê");
            }

        }

        #region Sự kiện

        void bdsPXK_PositionChanged(object sender, EventArgs e)
        {
            if (bdsPKK.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsPKK.Current).Row, ref drCurrent);

            this.strStt = drCurrent["Stt"].ToString();
            //this.dte_Ngay = Convert.ToDateTime(drCurrent["Ngay_Ct"]);
            bdsPKKDetail.Filter = "Stt = '" + strStt + "'";




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

            if (bdsPKK.Position < 0)
                return;
            string strColumnName = dgvKK_PH.dgvGridView.FocusedColumn.Name;

            DataRow drCurrent = ((DataRowView)bdsPKK.Current).Row;

            if (strColumnName == "CHON")
            {
                drCurrent[strColumnName] = !Convert.ToBoolean(drCurrent[strColumnName]);
                drCurrent.AcceptChanges();
            }
        }
        void dgvPXDetail_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (bdsPKKDetail.Position < 0)
                return;
            string strColumnName = dgvKKDetail.Columns[e.ColumnIndex].Name.ToUpper();

            DataRow drCurrentDetail = ((DataRowView)bdsPKKDetail.Current).Row;

            string stt = drCurrentDetail["Stt"].ToString();

            //frmSaleOrder_Edit frmEdit = new frmSaleOrder_Edit();
            //frmEdit.Load(enuEdit.Edit, drCurrentDetail, null);

        }
        void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if (bdsPKK.Position < 0)
                return;
            DataRow drCurrent = ((DataRowView)bdsPKK.Current).Row;
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
            if (bdsPKK.Position < 0)
                return;


            bool bAcceptShowDialog = true;
            bool bInVisibleNextPrint = false;
            string strReport_File_First = string.Empty;
            string strMa_PX_List = "";


            DataRow drCurrent = ((DataRowView)bdsPKK.Current).Row;
            PrintVoucher.PrintPhieuKiemKe(this.strStt, bPreview);

        }

        public void PrintKK01(string strReport_ID)
        {

            //string strReport_ID = "KK01";
            DataRow drCurrent = ((DataRowView)bdsPKK.Current).Row;

            DataRow drReport = DataTool.SQLGetDataRowByID("SYSREPORT", "Report_Id", strReport_ID);
            DataRow drFilter = Epoint.Reports.Report.GetdrFilter(drReport);
            drFilter["Ngay_Ct1"] = drCurrent["Ngay_Ct"];
            drFilter["Ngay_Ct2"] = drCurrent["Ngay_Ct"];
            drFilter["STT"] = drCurrent["STT"];

            Epoint.Reports.Report.RunReport(drFilter, drReport, true);

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
            if (bdsPKK.Position < 0)
                return;
            string strRPT = cbxReport_List.SelectedValue.ToString();
            this.PrintKK01(strRPT);
            //if (strRPT == "KK01")
            //    this.PrintKK01();
            //else if (strRPT == "KK02")
            //    this.PrintKK01();


        }

        #endregion
    }
}
