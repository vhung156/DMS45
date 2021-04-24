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
using Epoint.Systems.Data;
using System.Collections;
using System.Data.SqlClient;
using Epoint.Systems.Elements;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;

namespace Epoint.Modules.AR
{
    public partial class frmPromotionBudget : Epoint.Systems.Customizes.frmView
    {

        string strMa_NS = String.Empty;
        string strStt = String.Empty;
        DataTable dtImport;
        string strError = string.Empty;
        string strTanSuat = string.Empty;

        DataSet dsPromotionBudget;
        DataTable dtBudgetHeader;
        BindingSource bdsBudgetHeader = new BindingSource();
        DataRow drCurrentBudgetHeader;

        DataRow drBudgetDetailAllocate;
        DataTable dtBudgetDetailAllocate;
        BindingSource bdsBudgetDetailAllocate = new BindingSource();

        public frmPromotionBudget()
        {
            InitializeComponent();
            bdsBudgetHeader.PositionChanged += new EventHandler(bdsDiscountProg_PositionChanged);
            this.btFillterData.Click += new EventHandler(btFillData_Click);
            this.btAddCust.Click += new EventHandler(btAddCust_Click);
            this.btPJPDetail.Click += new EventHandler(btPJPDetail_Click);
            this.btImport.Click += new EventHandler(btImport_Click);
            this.KeyDown += new KeyEventHandler(KeyDownEvent);
            this.dgvBudgetDetail.dgvGridView.DoubleClick += new EventHandler(dgvDetail_CellMouseDoubleClick);
            //this.dgvBudgetDetail.dgvGridView.MouseDown += new MouseEventHandler(dgvDetail_MouseDoubleClick);
        //    this.dgvBudgetDetail.dgvGridView.RowCellClick += new RowCellClickEventHandler(DgvGridView_RowCellClick);
        //    this.dgvBudgetDetail.dgvGridView.EditFormShowing += DgvGridView_EditFormShowing;
        }

       

        public override void Load()
        {
            this.Build();
            this.FillData();
            this.Show();
        }

        private void Build()
        {
            dgvBudget.strZone = "OM_BUDGET";
            dgvBudget.BuildGridView(this.isLookup);
            ExportControl = dtBudgetHeader;

            dgvBudgetDetail.strZone = "OM_BUDGETDetail";
            dgvBudgetDetail.BuildGridView(this.isLookup);
            ExportControl = dtBudgetDetailAllocate;

            dteNgay_BD.Text = Library.DateToStr(Epoint.Systems.Elements.Element.sysNgay_Ct1);
            dteNgay_Kt.Text = Library.DateToStr(Epoint.Systems.Elements.Element.sysNgay_Ct2);


        }

        private void FillData()
        {

            Hashtable htDisc = new Hashtable();
            htDisc["NGAY_CT1"] = Library.StrToDate(dteNgay_BD.Text);
            htDisc["NGAY_CT2"] = Library.StrToDate(dteNgay_Kt.Text);
            htDisc.Add("MA_DVCS", Element.sysMa_DvCs);
            dsPromotionBudget = SQLExec.ExecuteReturnDs("sp_OM_GetBudget", htDisc, CommandType.StoredProcedure);

            dtBudgetHeader = dsPromotionBudget.Tables[0];
            bdsBudgetHeader.DataSource = dtBudgetHeader;
            dgvBudget.DataSource = bdsBudgetHeader;

            //Uy quyen cho lop co so tim kiem
            bdsSearch = bdsBudgetHeader;
            ExportControl = dgvBudget;

            if (bdsBudgetHeader.Count >= 0)
                bdsBudgetHeader.Position = 0;

            //Detail

            dtBudgetDetailAllocate = dsPromotionBudget.Tables[1];
            bdsBudgetDetailAllocate.DataSource = dtBudgetDetailAllocate;
            dgvBudgetDetail.DataSource = bdsBudgetDetailAllocate;



        }

        public override void Edit(enuEdit enuNew_Edit)
        {
            if (dgvBudget.Focused)
                EditPromotionBudget(enuNew_Edit);
            else if (dgvBudgetDetail.Focused)
                EditPromotionBudgetDetail(enuNew_Edit);

        }
        private void EditPromotionBudget(enuEdit enuNew_Edit)
        {
            if (bdsBudgetHeader.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai
            if (bdsBudgetHeader.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsBudgetHeader.Current).Row, ref drCurrentBudgetHeader);
            else
                drCurrentBudgetHeader = dtBudgetHeader.NewRow();

            frmPromotionBudget_Edit frmEdit = new frmPromotionBudget_Edit();
            frmEdit.Load(enuNew_Edit, drCurrentBudgetHeader);

            //Accept
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
                {
                    if (bdsBudgetHeader.Position >= 0)
                        dtBudgetHeader.ImportRow(drCurrentBudgetHeader);
                    else
                        dtBudgetHeader.Rows.Add(drCurrentBudgetHeader);

                    bdsBudgetHeader.Position = bdsBudgetHeader.Find("Ma_NS", drCurrentBudgetHeader["Ma_NS"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrentBudgetHeader, ((DataRowView)bdsBudgetHeader.Current).Row);
                }

                dtBudgetHeader.AcceptChanges();
            }
            else
                dtBudgetHeader.RejectChanges();

        }
        private void EditBudgetDetailAddNew(enuEdit enuNew_Edit)
        {

        }
        private void EditPromotionBudgetDetail(enuEdit enuNew_Edit)
        {
            if (bdsBudgetHeader.Position < 0)
                return;

            //if (bdsBudgetDetailAllocate.Position < 0)
            //    return;


            if (bdsBudgetDetailAllocate.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            if (bdsBudgetHeader.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsBudgetHeader.Current).Row, ref drCurrentBudgetHeader);

            if (bdsBudgetDetailAllocate.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsBudgetDetailAllocate.Current).Row, ref drBudgetDetailAllocate);
            else
            {
                drBudgetDetailAllocate = dtBudgetDetailAllocate.NewRow();
                drBudgetDetailAllocate["Ma_Ns"] = drCurrentBudgetHeader["Ma_Ns"];
                drBudgetDetailAllocate["AmtAlloc"] = drCurrentBudgetHeader["AmtAlloc"];
                drBudgetDetailAllocate["QtyAlloc"] = drCurrentBudgetHeader["QtyAlloc"];
            }
            frmPromotionBudgetAlloc_Edit frmEdit = new frmPromotionBudgetAlloc_Edit();
            frmEdit.Load(enuNew_Edit, drBudgetDetailAllocate);

            //Accept
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
                {
                    if (bdsBudgetDetailAllocate.Position >= 0)
                        dtBudgetDetailAllocate.ImportRow(drBudgetDetailAllocate);
                    else
                        dtBudgetDetailAllocate.Rows.Add(drBudgetDetailAllocate);
                    bdsBudgetDetailAllocate.Position = bdsBudgetDetailAllocate.Find("Ident00", drBudgetDetailAllocate["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drBudgetDetailAllocate, ((DataRowView)bdsBudgetDetailAllocate.Current).Row);
                    dtBudgetDetailAllocate.AcceptChanges();
                }

            }
            else
                dtBudgetDetailAllocate.RejectChanges();
        }
        public override void Delete()
        {
            if (dgvBudget.Focused)
                DeletePromotionBudget();
            else if (dgvBudgetDetail.Focused)
                DeletePromotionBudgetDetail();

        }


        private void DeletePromotionBudget()
        {
            if (bdsBudgetHeader.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsBudgetHeader.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;


            Hashtable htPara = new Hashtable();
            htPara["Ma_Ns"] = drCurrent["Ma_Ns"].ToString();
            bool isCheck = Convert.ToBoolean(SQLExec.ExecuteReturnValue("sp_OM_DeleteBugdet", htPara, CommandType.StoredProcedure));
            if (isCheck)
            {
                bdsBudgetHeader.RemoveAt(bdsBudgetHeader.Position);
                dtBudgetHeader.AcceptChanges();
            }
            else
            {
                EpointMessage.MsgOk("Ngân sách đã dử dụng, không xóa được.");
            }
        }
        private void DeletePromotionBudgetDetail()
        {
            if (bdsBudgetDetailAllocate.Position < 0)
                return;

            drBudgetDetailAllocate = ((DataRowView)bdsBudgetDetailAllocate.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;
            Hashtable htPara = new Hashtable();
            htPara["IDENT00"] = drBudgetDetailAllocate["Ident00"].ToString();
            //htPara["Ma_CbNv"] = drBudgetDetailAllocate["Ma_CbNv"].ToString();
            bool isCheck = Convert.ToBoolean(SQLExec.ExecuteReturnValue("sp_OM_DeleteBugdetDetail", htPara, CommandType.StoredProcedure));
            if (isCheck)
            {
                bdsBudgetDetailAllocate.RemoveAt(bdsBudgetDetailAllocate.Position);
                dtBudgetDetailAllocate.AcceptChanges();
            }
            else
            {
                EpointMessage.MsgOk("Ngân sách đã dử dụng, không xóa được.");
            }
        }

        #region Sự kiện

        void bdsDiscountProg_PositionChanged(object sender, EventArgs e)
        {
            if (bdsBudgetHeader.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsBudgetHeader.Current).Row, ref drCurrentBudgetHeader);

            this.strMa_NS = drCurrentBudgetHeader["Ma_NS"].ToString();
            bdsBudgetDetailAllocate.Filter = "Ma_NS = '" + strMa_NS + "'";

        }
        void btPJPDetail_Click(object sender, EventArgs e)
        {
            if (bdsBudgetHeader.Position < 0)
                return;

        }
        void btAddCust_Click(object sender, EventArgs e)
        {
            if (bdsBudgetHeader.Position < 0)
                return;

            EditBudgetDetailAddNew(enuEdit.New);
        }
        void btFillData_Click(object sender, EventArgs e)
        {
            FillData();
        }

        void btImport_Click(object sender, EventArgs e)
        {
            strError = string.Empty;

            OpenFileDialog ofdlg = new OpenFileDialog();
            ofdlg.Filter = "xls files (*.xls;*.xlsx)|*.xls;*.xlsx";
            ofdlg.RestoreDirectory = true;
            if (ofdlg.ShowDialog() != DialogResult.OK)
                return;

            dtImport = Common.ReadExcel(ofdlg.FileName);
            EpointProcessBox.Show(this);
        }
        public virtual void Import_Excel(bool CheckAPI)
        {
            bool bIsImport = DataTool.SQLCheckExist("sys.procedures", "Name", "OM_Import_PromotionBudget");
            if (bIsImport)
            {

                SqlCommand command = SQLExec.GetNewSQLConnection().CreateCommand();
                command.CommandText = "OM_Import_PJP";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);
                SqlParameter parameter = new SqlParameter
                {
                    SqlDbType = SqlDbType.Structured,
                    ParameterName = "@TablePJP",
                    TypeName = "TVP_OMPJP",
                    Value = dtImport
                };
                command.Parameters.Add(parameter);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    command.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();
                    command.ExecuteNonQuery();
                    EpointProcessBox.AddMessage("Có lỗi xảy ra :" + exception.Message);
                }

            }

            EpointProcessBox.AddMessage("Kết thúc");
        }

        void dgvDetail_CellMouseDoubleClick(object sender, EventArgs e)
        {

            string strColumnName = dgvBudgetDetail.dgvGridView.FocusedColumn.Name.ToUpper();
            if (bdsBudgetDetailAllocate.Position < 0)
                return;

            EditPromotionBudgetDetail(enuEdit.Edit);

        }
        void dgvDetail_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            string strColumnName = dgvBudgetDetail.dgvGridView.FocusedColumn.Name.ToUpper();
            GridHitInfo hitInfo = dgvBudgetDetail.dgvGridView.CalcHitInfo(e.Location);
            if (strColumnName == "QTYALLOC" || strColumnName == "AMTALLOC")
            {

                if (hitInfo.InRowCell)
                {
                    dgvBudgetDetail.dgvGridView.FocusedRowHandle = hitInfo.RowHandle;
                    dgvBudgetDetail.dgvGridView.FocusedColumn = hitInfo.Column;
                    DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                    if (e.Clicks == 2 && e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        dgvBudgetDetail.AllowEdit = true;
                        dgvBudgetDetail.dgvGridView.ShowEditor();
                    }
                }
                return;
            }
        }
        private void DgvGridView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            string strColumnName = dgvBudgetDetail.dgvGridView.FocusedColumn.Name.ToUpper();
            GridHitInfo hitInfo = dgvBudgetDetail.dgvGridView.CalcHitInfo(e.Location);
            if (strColumnName == "QTYALLOC" || strColumnName == "AMTALLOC")
            {              
                if (hitInfo.InRowCell)
                {
                    dgvBudgetDetail.dgvGridView.FocusedRowHandle = hitInfo.RowHandle;
                    dgvBudgetDetail.dgvGridView.FocusedColumn = hitInfo.Column;
                    DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                    if (e.Clicks == 1 && e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        dgvBudgetDetail.AllowEdit = true;
                        dgvBudgetDetail.dgvGridView.ShowEditor();
                    }
                }
                return;
            }

        }
        private void DgvGridView_EditFormShowing(object sender, EditFormShowingEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            if (Convert.ToDouble(view.GetRowCellValue(e.RowHandle, "QTYALLOC")) > 0)
                e.Allow = false;

            if (Convert.ToDouble(view.GetRowCellValue(e.RowHandle, "AMTALLOC")) > 0)
                e.Allow = false;
        }
        public override void EpointRelease()
        {

            Import_Excel(true);

        }
        void KeyDownEvent(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {

                case Keys.F10:
                    switch (e.Modifiers)
                    {
                        case Keys.None:
                            if (((e.KeyCode == Keys.F10) && Common.CheckPermission(base.Object_ID, enuPermission_Type.Allow_New)) && Common.CheckPermission(base.Object_ID, enuPermission_Type.Allow_Edit))
                            {
                                strError = string.Empty;

                                OpenFileDialog ofdlg = new OpenFileDialog();
                                ofdlg.Filter = "xls files (*.xls;*.xlsx)|*.xls;*.xlsx";
                                ofdlg.RestoreDirectory = true;
                                if (ofdlg.ShowDialog() != DialogResult.OK)
                                    return;

                                dtImport = Common.ReadExcel(ofdlg.FileName);
                                EpointProcessBox.Show(this);
                            }
                            return;

                        case Keys.Control:
                            //this.Export_Excel();
                            break;
                    }
                    break;

            }
        }
        #endregion
    }
}
