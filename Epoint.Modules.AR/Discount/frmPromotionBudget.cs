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

        DataRow drCurrentBudgetDetail;
        DataTable dtBudgetDetail;
        BindingSource bdsBudgetDetail = new BindingSource();
        DataRow drCurrentDetail;

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
            ExportControl = dtBudgetDetail;

            dteNgay_BD.Text = Library.DateToStr(Epoint.Systems.Elements.Element.sysNgay_Ct1);
            dteNgay_Kt.Text = Library.DateToStr(Epoint.Systems.Elements.Element.sysNgay_Ct2);


        }

        private void FillData()
        {

            Hashtable htDisc = new Hashtable();
            htDisc["NGAY_CT1"] = Library.StrToDate(dteNgay_BD.Text);
            htDisc["NGAY_CT2"] = Library.StrToDate(dteNgay_Kt.Text);
            htDisc.Add("MA_DVCS", Element.sysMa_DvCs);
            dsPromotionBudget = SQLExec.ExecuteReturnDs("sp_GetBudget", htDisc, CommandType.StoredProcedure);

            dtBudgetHeader = dsPromotionBudget.Tables[0];
            bdsBudgetHeader.DataSource = dtBudgetHeader;
            dgvBudget.DataSource = bdsBudgetHeader;

            //Uy quyen cho lop co so tim kiem
            bdsSearch = bdsBudgetHeader;
            ExportControl = dgvBudget;

            if (bdsBudgetHeader.Count >= 0)
                bdsBudgetHeader.Position = 0;

            //Detail

            dtBudgetDetail = dsPromotionBudget.Tables[1];
            bdsBudgetDetail.DataSource = dtBudgetDetail;
            dgvBudgetDetail.DataSource = bdsBudgetDetail;



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
            if (bdsBudgetHeader.Position < 0)
                return;

            string strFilter = "Ma_Dt NOT IN (SELECT DISTINCT Ma_Dt FROM OM_PJPDETAIL)";

            //Copy hang hien tai
            if (bdsBudgetDetail.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsBudgetDetail.Current).Row, ref drCurrentDetail);
            else
                drCurrentDetail = dtBudgetDetail.NewRow();

            Common.CopyDataRow(((DataRowView)bdsBudgetHeader.Current).Row, ref drCurrentBudgetHeader);

            this.strMa_NS = drCurrentBudgetHeader["MA_PJP"].ToString();
            bool bRequire = true; bool bIs_Overide = true;
            string[] KeyAr = new string[2] { "Ma_PJP", "Ma_Dt" };
            string[] ValueAr;

            DataRow drLookup = Lookup.ShowMultiLookupNew("Ma_Dt", "", bRequire, strFilter, "", "");


            if (bRequire && drLookup == null)
            {
                dtBudgetDetail.RejectChanges();
                return;
            }
            string strValueList = drLookup["MuiltiSelectValue"].ToString();

            if (drLookup != null && strValueList != string.Empty)
            {
                foreach (string strMa_Dt in strValueList.Split(','))
                {
                    drCurrentDetail["Ma_PJP"] = strMa_NS;
                    drCurrentDetail["Ma_Dt"] = strMa_Dt;

                    drCurrentDetail["Tan_Suat"] = strTanSuat;
                    ValueAr = new string[2] { drCurrentDetail["Ma_PJP"].ToString(), strMa_Dt };


                    if (!DataTool.SQLCheckExist("OM_PJPDetail", KeyAr, ValueAr))
                    {
                        if (DataTool.SQLUpdate(enuEdit.New, "OM_PJPDetail", ref drCurrentDetail))
                        {
                            if (bdsBudgetDetail.Position >= 0)
                                dtBudgetDetail.ImportRow(drCurrentDetail);
                            else
                                dtBudgetDetail.Rows.Add(drCurrentDetail);
                            dtBudgetDetail.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (bIs_Overide)
                        {
                            if (DataTool.SQLUpdate(enuEdit.Edit, "OM_PJPDetail", ref drCurrentDetail))
                            {
                                dtBudgetDetail.AcceptChanges();
                            }

                        }
                    }

                }
            }
        }
        private void EditPromotionBudgetDetail(enuEdit enuNew_Edit)
        {
            if (bdsBudgetDetail.Position < 0)
                return;

            if (enuNew_Edit != enuEdit.Edit)
                return;

            if (bdsBudgetDetail.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsBudgetDetail.Current).Row, ref drCurrentBudgetDetail);


            frmPJPConfigDetail_Edit frmEdit = new frmPJPConfigDetail_Edit();
            frmEdit.Load(enuNew_Edit, drCurrentBudgetDetail);

            //Accept
            if (frmEdit.isAccept)
            {
                Common.CopyDataRow(drCurrentBudgetDetail, ((DataRowView)bdsBudgetDetail.Current).Row);

                dtBudgetDetail.AcceptChanges();
            }
            else
                dtBudgetDetail.RejectChanges();
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
            htPara["MA_PJP"] = drCurrent["MA_PJP"].ToString();
            bool isCheck = Convert.ToBoolean(SQLExec.ExecuteReturnValue("sp_DELETE_PJP", htPara, CommandType.StoredProcedure));
            if (isCheck)
            {
                bdsBudgetHeader.RemoveAt(bdsBudgetHeader.Position);
                dtBudgetHeader.AcceptChanges();
            }
            else
            {
                EpointMessage.MsgOk("Khong xoa duoc");
            }
        }
        private void DeletePromotionBudgetDetail()
        {
            if (bdsBudgetDetail.Position < 0)
                return;

            drCurrentDetail = ((DataRowView)bdsBudgetDetail.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (SQLExec.Execute("DELETE OM_PJPDetail WHERE Ma_PJP = '" + (string)drCurrentDetail["Ma_PJP"] + "' AND Ma_Dt = '" + (string)drCurrentDetail["Ma_Dt"] + "'", CommandType.Text))
            {
                bdsBudgetDetail.RemoveAt(bdsBudgetDetail.Position);
            }
        }

        #region Sự kiện

        void bdsDiscountProg_PositionChanged(object sender, EventArgs e)
        {
            if (bdsBudgetHeader.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsBudgetHeader.Current).Row, ref drCurrentBudgetHeader);

            this.strMa_NS = drCurrentBudgetHeader["Ma_NS"].ToString();
            bdsBudgetDetail.Filter = "Ma_NS = '" + strMa_NS + "'";

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
            if (bdsBudgetDetail.Position < 0)
                return;

            EditPromotionBudgetDetail(enuEdit.Edit);

        }
        void dgvDetail_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            string strColumnName = dgvBudgetDetail.dgvGridView.FocusedColumn.Name.ToUpper();
            //GridHitInfo hinfo = dgvBudgetDetail.dgvGridView.CalcHitInfo(e.Location);

            if (strColumnName == "QTYALLOC" || strColumnName == "AMTALLOC")
            {
                //GridView view = sender as GridView;
                GridHitInfo hitInfo = dgvBudgetDetail.dgvGridView.CalcHitInfo(e.Location);
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
