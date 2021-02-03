using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.Printing;
//using DevExpress.Printing.Core;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;
using System.Data.SqlClient;

namespace Epoint.Modules.IN
{
    public partial class frmThuHoiVC : Epoint.Systems.Customizes.frmView
    {
        //DataTable dtThanhToan;
        DataTable dtCtHanTt;

        //BindingSource bdsThanhToan = new BindingSource();
        BindingSource bdsHanTt = new BindingSource();

        frmVoucher_Edit frmEditCt;
        frmHanTt_Filter frmFilter = new frmHanTt_Filter();
        string strStt = string.Empty;
        string strStt_Pt = string.Empty;
        string strSo_Ct_New = string.Empty;


        DateTime dtNgay_Ct = DateTime.MinValue;
        DateTime dtNgay_Ct_Hd = DateTime.Now;

        DataRow drCurrent;

        #region Contructor

        public frmThuHoiVC()
        {
            InitializeComponent();


            this.dgvHanTt0.dgvGridView.RowCellClick +=  new RowCellClickEventHandler(dgvHanTt0_CellMouseClick);
            this.dgvHanTt0.dgvGridView.CellValueChanged += new CellValueChangedEventHandler(dgvGridView_CellValueChanged);

            //this.dgvHanTt0.dgvGridView.Click += new EventHandler(dgvHanTt0_CellMouseClick);
            //this.dgvHanTt0.dgvGridView.CellBeginEdit += new DataGridViewCellCancelEventHandler(dgvHanTt0_CellBeginEdit);
            //this.dgvHanTt0.CellEndEdit += new DataGridViewCellEventHandler(dgvHanTt0_CellEndEdit);
            this.dgvHanTt0.GotFocus += new EventHandler(dgvHanTt0_GotFocus);

            this.cboTK_List.TextChanged += new EventHandler(cboTK_List_SelectedValueChanged);

            this.btFillterData.Click += new EventHandler(btFillHanTt_Click);
            this.btThanhtoan.Click += new EventHandler(btThanhtoan_Click);


            this.btCheckAll.Click += new EventHandler(btThanhToanALL_Click);
            this.txtMa_Dt.Enter += new EventHandler(txtMa_Dt_Enter);
            this.txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
        }

        



        

        new public void Load()
        {
            Build();

            BindingLanguage();
            LoadDicName();
            if (this.frmEditCt == null)
                this.Show();
            else
                this.ShowDialog();
        }

        public void Load(DateTime dtNgay_Ct, string strTk, string strMa_Dt, string strStt, string strMa_Ct)
        {
            this.strStt = strStt;
            this.txtTk.Text = strTk;
            this.txtMa_Dt.Text = strMa_Dt;
            this.Load();
        }

        #endregion

        #region Method

        private void Build()
        {
            this.dgvHanTt0.Dock = DockStyle.Fill;
            //dgvHanTt0.ReadOnly = false;
            //dgvHanTt0.dgvGridView.Editable = true;
            dgvHanTt0.AllowEdit = true;
            dgvHanTt0.strZone = "VCRECEIP";
            dgvHanTt0.BuildGridView();

            foreach (GridColumn dgvc in dgvHanTt0.dgvGridView.Columns)
            {
                if (dgvc.Name == "TSL_THU_HOI")
                {
                    dgvc.OptionsColumn.ReadOnly = false;
                    dgvc.OptionsColumn.AllowEdit = true; 
                }
                else
                {
                    dgvc.OptionsColumn.ReadOnly = true;
                    dgvc.OptionsColumn.AllowEdit = false;
                                      
                }
            }

            dteNgay_Ct_TT.Text = Library.DateToStr(DateTime.Now);
            dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
            dteNgay_Ct2.Text = Library.DateToStr(DateTime.Now);



            
            string strSQL = "SELECT * FROM vw_TkTien";
            DataTable dtTkList = SQLExec.ExecuteReturnDt(strSQL);

            cboTK_List.lstItem.BuildListView("Tk:80,Ten_Tk:200");
            cboTK_List.lstItem.DataSource = dtTkList;
            cboTK_List.lstItem.Size = new Size(300, cboTK_List.lstItem.Items.Count * 30);
            cboTK_List.lstItem.GridLines = true;
            //cboTK_List.ValueMember = "Tk";

            cboTK_List.Text = dtTkList.Rows[0][0].ToString();
            txtTk_Tt.Text = dtTkList.Rows[0][0].ToString(); 


        }
        private void LoadDicName()
        {
            //Ma_Nh_Vt
            if (txtTk.Text.Trim() != string.Empty)
            {
                lbtTen_Tk.Text = DataTool.SQLGetNameByCode("LITAIKHOAN", "Tk", "Ten_Tk", txtTk.Text.Trim());
                //dicName.Add(lbtTen_Tk.Name, lbtTen_Tk.Text);
            }
            else
                lbtTen_Tk.Text = string.Empty;

            if (txtMa_Dt.Text.Trim() != string.Empty)
            {
                lbtTen_Dt.Text = DataTool.SQLGetNameByCode("LIDOITUONG", "MA_DT", "Ten_DT", txtMa_Dt.Text.Trim());
                //dicName.Add(lbtTen_Tk.Name, lbtTen_Tk.Text);
            }
            else
                lbtTen_Dt.Text = string.Empty;
        }
        private void FillCongNoVC()
        {
            Hashtable htSQLPara = new Hashtable();
            htSQLPara.Add("NGAY_CT1", Library.StrToDate(dteNgay_Ct1.Text));
            htSQLPara.Add("NGAY_CT2", Library.StrToDate(dteNgay_Ct2.Text));
            htSQLPara.Add("MA_TUYEN", txtMa_Tuyen.Text);
            htSQLPara.Add("MA_NH_DT", txtMa_Nh_Dt.Text);
            //htSQLPara.Add("TK", "1311");
            htSQLPara.Add("MA_DT", txtMa_Dt.Text);
            //htSQLPara.Add("MA_CBNV_BH", txtMa_CbNV_BH.Text);
            //htSQLPara.Add("MA_CBNV_GH", txtMa_CbNV_GH.Text);
            //htSQLPara.Add("STT_PT", "");
            htSQLPara.Add("MA_DVCS", Element.sysMa_DvCs);
            this.dtCtHanTt = SQLExec.ExecuteReturnDt("[sp_VC_GetTkDt]", htSQLPara, CommandType.StoredProcedure);
            if (!this.dtCtHanTt.Columns.Contains("Modify"))
            {
                this.dtCtHanTt.Columns.Add(new DataColumn("Modify", typeof(bool)));
                this.dtCtHanTt.Columns["Modify"].DefaultValue = false;
            }
            this.bdsHanTt.DataSource = this.dtCtHanTt;
            this.dgvHanTt0.DataSource = this.bdsHanTt;

            this.Tinh_Tong();

        }


        private void Auto_Ticked(DataRow row)
        {
            //DataRow row = ((DataRowView)this.bdsHanTt.Current).Row;
            //DataGridViewCell currentCell = this.dgvHanTt0.dgvGridView.CurrentCell;
            string strExpr = dgvHanTt0.dgvGridView.FocusedColumn.Name;// currentCell.OwningColumn.Name.ToUpper();
            if (Common.Inlist(strExpr, "THANH_TOAN"))
            {

                //bool  = !((bool)currentCell.EditedFormattedValue);
                 
                drCurrent = ((DataRowView)bdsHanTt.Current).Row;
                bool bThanhToan = !Convert.ToBoolean(drCurrent["THANH_TOAN"]);
                if (bThanhToan)
                {

                    double dbSl_Thu_Hoi, dbTonNo;
                    double dbTSl_Thu_Hoi;

                    //dbSl_Thu_Hoi = Convert.ToDouble(row["SL_THU_HOI"]);
                    dbTonNo = Convert.ToDouble(row["Ton_Cuoi"]);
                    dbTSl_Thu_Hoi = Common.SumDCValue(this.dtCtHanTt, "SL_THU_HOI", "");
                    dbSl_Thu_Hoi = dbTonNo;

                    if (!((Math.Abs(dbSl_Thu_Hoi) + Math.Abs(dbTonNo)) == 0.0))
                    {
                        row["TSL_THU_HOI"] = row["TTON_CUOI"];
                        row["SL_THU_HOI"] = dbSl_Thu_Hoi;
                        row["LastModify_Log"] = Common.GetCurrent_Log();
                        row["Thanh_Toan"] = bThanhToan;
                        row["Modify"] = true;
                        this.btSave.Enabled = true;
                    }
                }
                else
                {
                    row["TSL_THU_HOI"] = "";
                    row["SL_THU_HOI"] = 0;                    
                    row["LastModify_Log"] = string.Empty;
                    row["Thanh_Toan"] = bThanhToan;
                    row["Modify"] = true;
                    this.btSave.Enabled = true;
                }

                row.AcceptChanges();
                //this.dgvHanTt0.dgvGridView.();
                this.Tinh_Tong();
            }
        }
        private void Auto_Ticked(DataRow row, bool bThanhToan)
        {
            
            //bool bThanhToan = !((bool)currentCell.EditedFormattedValue);
            row["THANH_TOAN"] = true;
            if (bThanhToan)
            {

                double dbSl_Thu_Hoi, dbTonNo;
                double dbTSl_Thu_Hoi;

                //dbSl_Thu_Hoi = Convert.ToDouble(row["SL_THU_HOI"]);
                dbTonNo = Convert.ToDouble(row["Ton_Cuoi"]);
                dbTSl_Thu_Hoi = Common.SumDCValue(this.dtCtHanTt, "SL_THU_HOI", "");
                dbSl_Thu_Hoi = dbTonNo;

                if (!((Math.Abs(dbSl_Thu_Hoi) + Math.Abs(dbTonNo)) == 0.0))
                {
                    row["SL_THU_HOI"] = dbSl_Thu_Hoi;
                    row["LastModify_Log"] = Common.GetCurrent_Log();
                    row["Thanh_Toan"] = bThanhToan;
                    row["Modify"] = true;
                    this.btSave.Enabled = true;
                }
            }
            else
            {
                row["SL_THU_HOI"] = 0;
                row["LastModify_Log"] = string.Empty;
                row["Thanh_Toan"] = bThanhToan;
                row["Modify"] = true;
                this.btSave.Enabled = true;
            }

            row.AcceptChanges();
            //this.dgvHanTt0.EndEdit();
            this.Tinh_Tong();

        }

        private void Tinh_Tong()
        {
            this.numTSo_Luong.Value = Common.SumDCValue(dtCtHanTt, "SL_THU_HOI", "");
        }
        public override void EpointRelease()
        {
            
            string strSttPNVC = Tao_PNVC();
            if (strSttPNVC != string.Empty)
            {
                EpointProcessBox.AddMessage("Kết thúc");
            }
          
        }
        #endregion

        #region Event

        void dgvHanTt0_GotFocus(object sender, EventArgs e)
        {
            this.ExportControl = dgvHanTt0;
            this.bdsSearch = bdsHanTt;
        }

        void dgvHanTt_GotFocus(object sender, EventArgs e)
        {

        }

        
        void dgvHanTt0_CellMouseClick(object sender, EventArgs e)
        {
            DataRow row = ((DataRowView)this.bdsHanTt.Current).Row;
            this.Auto_Ticked(row);
        }
        
        void dgvHanTt0_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //DataGridViewCell dgvCell;// = dgvHanTt0.CurrentCell;
            string strColumnName = dgvHanTt0.dgvGridView.FocusedColumn.Name; // = dgvCell.OwningColumn.Name.ToUpper();

            if (Common.Inlist(strColumnName, "SL_THU_HOI"))
            {
                DataRow drHanTt0 = ((DataRowView)bdsHanTt.Current).Row;

                //Không cho người này được sửa thanh toán của người khác
                if (!Element.sysIs_Admin)
                {
                    string strUser = (string)drHanTt0["LastModify_Log"];
                    if (strUser.Length > 0)
                        strUser = strUser.Substring(14);

                    if (strUser != string.Empty && strUser != Element.sysUser_Id)
                    {
                        Common.MsgCancel("Không được sửa dữ liệu do " + strUser + " đã thanh toán!");
                        this.btSave.Enabled = false;
                        e.Cancel = true;

                        return;
                    }
                }

                this.btSave.Enabled = true;
            }
        }

        void dgvHanTt0_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewCell dgvCell = dgvHanTt0.dgvGridView.CurrentCell;
            string strColumnName = dgvHanTt0.dgvGridView.FocusedColumn.Name; 
            if (Common.Inlist(strColumnName, "SL_THU_HOI"))
            {
                DataRow drHanTt0 = ((DataRowView)bdsHanTt.Current).Row;


                double dbSL_THU_HOI = Convert.ToDouble(drHanTt0["SL_THU_HOI"]);
                double dbTON_CUOI = Convert.ToDouble(drHanTt0["TON_CUOI"]);
                //double dbTy_Gia_Hd = Convert.ToDouble(drHanTt0["Ty_Gia_HD"]);
                if (dbSL_THU_HOI > 0)
                {
                    if(dbSL_THU_HOI >= dbTON_CUOI)
                    {
                        dbSL_THU_HOI =  dbTON_CUOI;

                        drHanTt0["SL_THU_HOI"] = dbSL_THU_HOI;
                    }
                   
                    drHanTt0["Modify"] = true;
                    drHanTt0["Thanh_Toan"] = true;
                    drHanTt0["LastModify_Log"] = Common.GetCurrent_Log();                      
                    this.btSave.Enabled = true;
                 }
                else
                {
                    drHanTt0["Modify"] = false;
                    drHanTt0["Thanh_Toan"] = false;
                    drHanTt0["LastModify_Log"] = "";
                 
                }


                  this.Tinh_Tong();
                
            }
        }

        private string Tao_PNVC()
        {
            int Stt0 = 0;
            string strSo_Ct = string.Empty;
            string strSo_Ct_New = string.Empty;
            string strCreate_Log = string.Empty;
            string strCt_Di_Kem = string.Empty;
            string strQueryPh = string.Empty;
            string strQueryCthd = string.Empty;
            string iStt = string.Empty;

            try
            {

                #region GetNew_SoCt


                DataRow drDmct = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", "PNVC");
                DataRow dr = SQLExec.ExecuteReturnDt("SELECT Ma_DvCs FROM SYSDMDVCS WHERE Ma_DvCs = '" + Element.sysMa_DvCs + "' ").Rows[0];
                DateTime dteNgay_Ct_tt = Library.StrToDate(dteNgay_Ct_TT.Text);
                string strSQLExec = "SELECT So_Ct FROM GLVOUCHER  (NOLOCK) WHERE Ma_DvCs = '" + Element.sysMa_DvCs
                    + "' AND Ma_Ct = 'PTT' AND MONTH(Ngay_Ct) =" + dteNgay_Ct_tt.Month.ToString()
                    + " AND Ngay_Ct ='" + Library.DateToStr(dteNgay_Ct_tt) + "' AND So_Ct <> '' ";
                //+ " AND DAY(Ngay_Ct) =" + dteNgay_Ct1.Day.ToString() 

                DataTable dt = SQLExec.ExecuteReturnDt(strSQLExec);
                if (dt.Rows.Count > 0)
                {
                    string strSQL = "SELECT ISNULL(MAX(So_Ct),'') FROM GLVOUCHER  (NOLOCK) WHERE Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Ma_Ct = 'PNVC' AND MONTH(Ngay_Ct) =" + dteNgay_Ct_tt.Month.ToString() + " AND YEAR(Ngay_Ct) =" + dteNgay_Ct_tt.Year.ToString() + "";
                    strSo_Ct = SQLExec.ExecuteReturnValue(strSQL).ToString();
                    Hashtable htPara = new Hashtable();
                    htPara.Add("TABLENAME", "GLVOUCHER");
                    htPara.Add("COLUMNNAME", "So_Ct");
                    htPara.Add("CURRENTID", strSo_Ct);
                    htPara.Add("KEY", "Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Ma_Ct = 'PNVC' AND Ngay_Ct ='" + Library.DateToStr(dteNgay_Ct_tt) + "' AND YEAR(Ngay_Ct) = " + dteNgay_Ct_tt.Year + "");
                    htPara.Add("PREFIXLEN", Convert.ToInt32(drDmct["PrefixLen"]));
                    htPara.Add("SUFFIXLEN", Convert.ToInt32(drDmct["SubfixLen"]));

                    strSo_Ct_New = (string)SQLExec.ExecuteReturnValue("sp_GetNewID", htPara, CommandType.StoredProcedure);
                    //strSo_Ct_New = drDmct["Prefix"].ToString() + dteNgay_Ct_tt.Month.ToString("00") + dteNgay_Ct_tt.Day.ToString("00") + strSo_Ct_New.Substring(strSo_Ct_New.Length - 4, 4);
                }
                else
                    strSo_Ct_New = "PNVC" + dteNgay_Ct_tt.Month.ToString("00") + dteNgay_Ct_tt.Day.ToString("00") + "0001";


                #endregion

                strCreate_Log = Common.GetCurrent_Log();



                bool bSttValid = false;

                while (!bSttValid)
                {
                    iStt = Common.GetNewStt("08", true);
                    string strPH = @"SELECT * FROM GLVOUCHER  (NOLOCK) WHERE Stt= '" + iStt + "'";
                    DataTable dtCtph = SQLExec.ExecuteReturnDt(strPH);
                    if (dtCtph.Rows.Count > 0)
                    {
                        bSttValid = false;
                    }
                    else
                        bSttValid = true;

                }

                double dbTien0 = 0;
                double dbTien3 = 0;
                foreach (DataRow drvc in dtCtHanTt.Rows)
                {

                    if ((bool)drvc["Thanh_Toan"])
                    {
                        Stt0 += 1;
                        DataRow drDt = DataTool.SQLGetDataRowByID("LIDOITUONG", "Ma_Dt", drvc["Ma_Dt"].ToString());

                        strQueryCthd += @"INSERT INTO INVOCHAI (Stt, Stt0, Ma_Ct, Ngay_Ct, So_Ct, Dien_Giai, Ong_Ba, Ma_Dt,Ma_Kho,Ma_Vt,Dvt,So_Luong,So_Luong9,Ma_Dvcs)
                        							VALUES('" + iStt + "', '" + Stt0 + "', 'PNVC', '" + dteNgay_Ct_TT.Text + "','" + strSo_Ct_New + "', N'"
                                              + txtDien_Giai.Text + "',  N'" + drDt["Ong_Ba"] + "', '" + drvc["Ma_Dt"] + "','VC','" + drvc["Ma_Vt"] + "','" + drvc["Dvt"] + "'," + drvc["SL_Thu_Hoi"] + "," + drvc["SL_Thu_Hoi"] + ",'" + Element.sysMa_DvCs + "')\n";

                       
                    }
                }

                strQueryPh = @"
            						INSERT INTO	GLVOUCHER (Stt, Ma_Ct, Ngay_Ct, So_Ct, Ma_Dt, Dien_giai, TTien0, TTien_Nt0, TTien3, TTien_Nt3, Create_Log, Ct_Di_Kem,Is_ThanhToan,Ma_Nvu, Ma_Dvcs)
            							VALUES('" + iStt + "', 'PNVC', '" + Library.DateToStr(dteNgay_Ct_tt) + "', '" + strSo_Ct_New + "', '"
                                     + txtMa_Dt.Text + "', N'" + txtDien_Giai.Text + "', " + dbTien0 + ", " + dbTien0 + ", " + dbTien3 + ", " + dbTien3 + ", '"
                                      + strCreate_Log + "', '" + strCt_Di_Kem + "',1,'PNVC', '" + Element.sysMa_DvCs + "')";


                if (numTSo_Luong.Value > 0)
                {
                    SQLExec.Execute(strQueryPh);
                    SQLExec.Execute(strQueryCthd);

                    EpointProcessBox.AddMessage("Chứng từ đã tạo xong Số chứng từ : " + strSo_Ct_New);
                    this.strStt_Pt = iStt;
                    this.strSo_Ct_New = strSo_Ct_New;
                    return iStt;
                }

                return strSo_Ct_New;
            }
            catch (Exception ex)
            {
                EpointProcessBox.AddMessage(ex.ToString());
                return string.Empty;
                // throw;
            }

        }
        private string Tao_Pt_TheoKH()
        {
            int Stt0 = 0;
            string strSo_Ct = string.Empty;
            string strSo_Ct_New = string.Empty;
            string strCreate_Log = string.Empty;
          
            string iStt = string.Empty;

            try
            {
                foreach (DataRow drhd in dtCtHanTt.Rows)
                {

                    DataRow drDt = DataTool.SQLGetDataRowByID("LIDOITUONG", "Ma_Dt", drhd["Ma_Dt"].ToString());

                    if (drDt != null)
                    {

                        string strQueryPh = string.Empty;
                        string strQueryCthd = string.Empty;

                        if ((bool)drhd["Thanh_Toan"])
                        {
                            #region GetNew_SoCt


                            DataRow drDmct = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", "PTT");
                            DataRow dr = SQLExec.ExecuteReturnDt("SELECT Ma_DvCs FROM SYSDMDVCS WHERE Ma_DvCs = '" + Element.sysMa_DvCs + "' ").Rows[0];
                            DateTime dteNgay_Ct_tt = Library.StrToDate(dteNgay_Ct_TT.Text);
                            string strSQLExec = "SELECT So_Ct FROM GLVOUCHER  (NOLOCK) WHERE Ma_DvCs = '" + Element.sysMa_DvCs
                                + "' AND Ma_Ct = 'PTT' AND MONTH(Ngay_Ct) =" + dteNgay_Ct_tt.Month.ToString()
                                + " AND YEAR(Ngay_Ct) =" + dteNgay_Ct_tt.Year.ToString() + " AND So_Ct <> '' ";
                            //+ " AND DAY(Ngay_Ct) =" + dteNgay_Ct1.Day.ToString() 

                            DataTable dt = SQLExec.ExecuteReturnDt(strSQLExec);
                            if (dt.Rows.Count > 0)
                            {
                                string strSQL = "SELECT ISNULL(MAX(So_Ct),'') FROM GLVOUCHER   (NOLOCK) WHERE Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Ma_Ct = 'PTT' AND MONTH(Ngay_Ct) =" + dteNgay_Ct_tt.Month.ToString() + " AND YEAR(Ngay_Ct) =" + dteNgay_Ct_tt.Year.ToString() + "";
                                strSo_Ct = SQLExec.ExecuteReturnValue(strSQL).ToString();
                                Hashtable htPara = new Hashtable();
                                htPara.Add("TABLENAME", "GLVOUCHER");
                                htPara.Add("COLUMNNAME", "So_Ct");
                                htPara.Add("CURRENTID", strSo_Ct);
                                htPara.Add("KEY", "Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Ma_Ct = 'PTT' AND MONTH(Ngay_Ct) = " + dteNgay_Ct_tt.Month + " AND YEAR(Ngay_Ct) = " + dteNgay_Ct_tt.Year + "");
                                htPara.Add("PREFIXLEN", Convert.ToInt32(drDmct["PrefixLen"]));
                                htPara.Add("SUFFIXLEN", Convert.ToInt32(drDmct["SubfixLen"]));

                                strSo_Ct_New = (string)SQLExec.ExecuteReturnValue("sp_GetNewID", htPara, CommandType.StoredProcedure);
                                //strSo_Ct_New = drDmct["Prefix"].ToString() + dteNgay_Ct_tt.Month.ToString("00") + dteNgay_Ct_tt.Day.ToString("00") + strSo_Ct_New.Substring(strSo_Ct_New.Length - 4, 4);
                            }
                            else
                                strSo_Ct_New = drDmct["Prefix"].ToString() + dteNgay_Ct_tt.Month.ToString("00") + dteNgay_Ct_tt.Day.ToString("00") + "0001";


                            #endregion

                            strCreate_Log = Common.GetCurrent_Log();



                            bool bSttValid = false;

                            while (!bSttValid)
                            {
                                iStt = Common.GetNewStt("01", true);
                                string strPH = @"SELECT * FROM GLVOUCHER (NOLOCK) WHERE Stt= '" + iStt + "'";
                                DataTable dtCtph = SQLExec.ExecuteReturnDt(strPH);
                                if (dtCtph.Rows.Count > 0)
                                {
                                    bSttValid = false;
                                }
                                else
                                    bSttValid = true;

                            }
                            #region Tạo Phiếu thu
                            double dbTien3 = 0;

                            // Tạo header

                            strQueryPh += @"
            						INSERT INTO	GLVOUCHER (Stt, Ma_Ct, Ngay_Ct, So_Ct, Ma_Dt, Dien_giai, TTien0, TTien_Nt0, TTien3, TTien_Nt3, Create_Log, Ct_Di_Kem,Is_ThanhToan, Ma_Dvcs)
            							VALUES('" + iStt + "', 'PTT', '" + Library.DateToStr(dteNgay_Ct_tt) + "', '" + strSo_Ct_New + "', '"
                                         + drhd["Ma_Dt"] + "', N'" + txtDien_Giai.Text + " - Số Ct : " + drhd["So_Ct_Hd"] + "', " + drhd["Tien_Tt1"] + ", " + drhd["Tien_Tt1"] + ", " + dbTien3 + ", " + dbTien3 + ", '"
                                          + strCreate_Log + "', '" + drhd["So_Ct_Hd"] + "',1, '" + Element.sysMa_DvCs + "')";


                            // Tạo Chi tiết
                            Stt0 += 1;


                            strQueryCthd += @"INSERT INTO	CATIEN (Stt, Stt0, Ma_Ct, Ngay_Ct, So_Ct, Dien_Giai, Ong_Ba, Ma_Dt,Dia_Chi,Ten_Dt,
                        											Tk_No, Tk_Co, Tien_Nt9, Tien, Tien_Nt, 
                                                                    Ma_Thue, Thue_GtGt, Tien3, Tien_Nt3, Tk_No3, Tk_Co3, Ngay_Ct0, So_Ct0, So_Seri0, Ma_So_Thue, Ten_DtGtGt,
            														Ma_Dvcs, Ma_Tte, Ty_Gia)
                        							VALUES('" + iStt + "', '" + Stt0 + "', 'PTT', '" + dteNgay_Ct_TT.Text + "','" + strSo_Ct_New + "', N'"
                                                  + txtDien_Giai.Text + " - Số Ct : " + drhd["So_Ct_Hd"]
                                                  + "',  N'" + drDt["Ong_Ba"] + "', '" + drhd["Ma_Dt"] + "',N'" + drDt["Dia_Chi"] + "',  N'" + drDt["Ten_Dt"] + "','"
                                                  + txtTk_Tt.Text + "','" + drhd["Tk"] + "', " + drhd["Tien_Tt1"] + ",  " + drhd["Tien_Tt1"] + ",  " + drhd["Tien_Tt1"]
                                                  + ", '', 0, 0, 0, '', '', '', '', '', '', N'', '" + Element.sysMa_DvCs + "','VND', 1)\n";


                            if (numTSo_Luong.Value > 0)
                            {
                                SQLExec.Execute(strQueryPh);
                                SQLExec.Execute(strQueryCthd);

                                //Common.MsgOk("Chứng từ đã tạo xong Số chứng từ : " + strSo_Ct_New);
                                this.strStt_Pt = iStt;
                                this.strSo_Ct_New = strSo_Ct_New;
                                //return iStt;
                            }
                            #endregion


                            //Tao thanh toán mới
                            DataRow rowCtThanhtoan;
                            DataRow row2 = drhd;
                            DataTable dtTableSource = SQLExec.ExecuteReturnDt("SELECT *, CAST(0 AS BIT) AS Thanh_Toan FROM GLTHANHTOANCT WHERE 0 = 1");

                            rowCtThanhtoan = dtTableSource.NewRow();
                            Common.CopyDataRow(row2, rowCtThanhtoan);

                            if ((rowCtThanhtoan["Ngay_Ct_TT"] == DBNull.Value) && (((DateTime)rowCtThanhtoan["Ngay_Ct_TT"]) == Element.sysNgay_Min))
                            {
                                rowCtThanhtoan["Ngay_Ct_TT"] = Library.StrToDate(this.dteNgay_Ct_TT.Text);
                            }
                            rowCtThanhtoan["Stt_PT"] = iStt;
                            rowCtThanhtoan["Tk"] = row2["Tk"];
                            rowCtThanhtoan["Ma_Dt"] = row2["Ma_Dt"];
                            rowCtThanhtoan["Stt_HD"] = row2["Stt_HD"];
                            rowCtThanhtoan["Tien_Tt"] = row2["Tien_Tt1"];
                            rowCtThanhtoan["Tien_Tt_Nt"] = row2["Tien_Tt_Nt1"];
                            rowCtThanhtoan["Tien_CLTG"] = row2["Tien_CLTG"];
                            rowCtThanhtoan["LastModify_Log"] = row2["LastModify_Log"];
                            dtTableSource.Rows.Add(rowCtThanhtoan);

                            dtTableSource.AcceptChanges();
                            
                            // tạo thanh toán cũ phục vụ cái chưa update.
                            try
                            {
                                bool a = SQLExec.Execute(@"INSERT INTO GLTHANHTOAN( Stt, Ma_Ct, Ngay_Ct, So_Ct, Dien_Giai, Ma_Tte, Ty_Gia, Tk, Ma_Dt, Tien_Tt, Tien_Tt_Nt, Stt_Hd, Is_SoDuDau, Ma_DvCs, 
			                        Tien_CLTG, Dau_ClTg, Tk_No_ClTg, Tk_Co_ClTg, Tk_No_ClTg2, Tk_Co_ClTg2, LastModify_Log, Is_CLTG, User_Crtd, User_Edit, Ngay_Crtd, Ngay_Edit)

		                            select  Stt = Stt_PT, Ma_Ct = 'PTT', Ngay_Ct  = Ngay_Ct_TT, So_Ct = So_Ct_TT, Dien_Giai = Dien_Giai_TT, Ma_Tte = 'VND', Ty_Gia = 1, Tk , Ma_Dt, Tien_Tt, Tien_Tt_Nt, Stt_Hd, Is_SoDuDau = 0, Ma_DvCs, 
				                        Tien_CLTG, Dau_ClTg, Tk_No_ClTg, Tk_Co_ClTg, Tk_No_ClTg2, Tk_Co_ClTg2, LastModify_Log, Is_CLTG = Dau_ClTg, User_Crtd = '', User_Edit = '', Ngay_Crtd = GETDATE(), Ngay_Edit = GETDATE()
		                            from GLTHANHTOANCT
		                            WHERE Stt_Pt = '" + iStt + "'");
                            }
                            catch  (Exception e1)
                            {
                                EpointProcessBox.AddMessage(e1.ToString());
                            }
                            EpointProcessBox.AddMessage("Thanh toán công nợ khách hàng " + drhd["Ma_Dt"].ToString() + " Số Ct : " + strSo_Ct_New);
                        }
                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                Common.MsgOk(ex.ToString());
                return string.Empty;
                // throw;
            }

        }

        private string VC_Get_TL(int He_So,int TSo_Luong)
        {
            string strTSl = string.Empty;
            int iT, iL;
            if(TSo_Luong != 0)
            {
                if(He_So == 0 || He_So == 1)
                    strTSl = "0/"+TSo_Luong.ToString();
                else
                {
                    iL = TSo_Luong % He_So;
                    iT = (TSo_Luong-iL)/He_So;
                    strTSl = iT.ToString() + "/" + iL.ToString();
                }
            }

            return strTSl;
        }
        void btThanhToanALL_Click(object sender, EventArgs e)
        {
            foreach (DataRow drhd in dtCtHanTt.Rows)
            {
                this.Auto_Ticked(drhd,true);
            }

        }
       
        void btThanhtoan_Click(object sender, EventArgs e)
        {
            if (numTSo_Luong.Value == 0)
            {
                EpointMessage.MsgOk("Chưa chọn các chứng từ thanh toán");
                return;
            }

            if (txtDien_Giai.Text == string.Empty)
            {
                EpointMessage.MsgOk("Nhập diễn giải cho chứng từ thanh toán");
                return;
            }


            //DataTable dtTableSource = SQLExec.ExecuteReturnDt("SELECT *, CAST(0 AS BIT) AS Thanh_Toan FROM GLTHANHTOANCT WHERE 0 = 1");
            foreach (DataRow row2 in this.dtCtHanTt.Select(this.bdsHanTt.Filter))
            {
                if (!(bool)row2["Thanh_Toan"])
                    continue;
               if(Convert.ToDouble(row2["SL_Thu_Hoi"]) <= 0)
               {
                   EpointMessage.MsgOk("Tồn tại dòng thanh toán tiền âm!");
                   return;
               }
            }


            //DataTable dtEditCtDisc = new DataTable("VC_THUHOI");
            //DataColumn dcMa_Dt = new DataColumn("Ma_Dt", typeof(string));
            //dcMa_Dt.DefaultValue = "";
            //dtEditCtDisc.Columns.Add(dcMa_Dt);

            //DataColumn dcMa_Vt = new DataColumn("Ma_Vt", typeof(string));
            //dcMa_Vt.DefaultValue = "";
            //dtEditCtDisc.Columns.Add(dcMa_Vt);

            //DataColumn dcSo_Luong = new DataColumn("So_Luong", typeof(double));
            //dcSo_Luong.DefaultValue = 0;
            //dtEditCtDisc.Columns.Add(dcSo_Luong);


            EpointProcessBox.Show(this);           
           
            this.FillCongNoVC();
        }
        void btFillHanTt_Click(object sender, EventArgs e)
        {
            this.FillCongNoVC();
        }
        void cboTK_List_SelectedValueChanged(object sender, EventArgs e)
        {
            txtTk_Tt.Text = cboTK_List.Text;
            LoadDicName();
        }
        void txtMa_Dt_Enter(object sender, EventArgs e)
        { }
        private void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
           
            string strValue = txtMa_Dt.Text.Trim();
           
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt.Text = string.Empty;
                lbtTen_Dt.Text = string.Empty;
                //return;
            }
            else
            {
                txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
                lbtTen_Dt.Text = drLookup["Ten_Dt"].ToString();

            }


            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }
        void dgvGridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            string strColumnName = dgvHanTt0.dgvGridView.FocusedColumn.Name; // = dgvCell.OwningColumn.Name.ToUpper();

            if (Common.Inlist(strColumnName, "TSL_THU_HOI"))
            {
                DataRow drHanTt0 = ((DataRowView)bdsHanTt.Current).Row;

                //Không cho người này được sửa thanh toán của người khác
                if (!Element.sysIs_Admin)
                {
                    string strUser = (string)drHanTt0["LastModify_Log"];
                    if (strUser.Length > 0)
                        strUser = strUser.Substring(14);

                    if (strUser != string.Empty && strUser != Element.sysUser_Id)
                    {
                        Common.MsgCancel("Không được sửa dữ liệu do " + strUser + " đã thanh toán!");
                        this.btSave.Enabled = false;
                        return;
                    }
                }
                else
                {

                    if (Common.Inlist(strColumnName, "SL_THU_HOI"))
                    {
                        double dbSL_THU_HOI = Convert.ToDouble(drHanTt0["SL_THU_HOI"]);
                        double dbTON_CUOI = Convert.ToDouble(drHanTt0["TON_CUOI"]);
                        if (dbSL_THU_HOI > 0)
                        {
                            if (dbSL_THU_HOI >= dbTON_CUOI)
                            {
                                dbSL_THU_HOI = dbTON_CUOI;

                                drHanTt0["SL_THU_HOI"] = dbSL_THU_HOI;
                            }

                            drHanTt0["TSL_THU_HOI"] = VC_Get_TL(Convert.ToInt32(drHanTt0["HE_SO"]), Convert.ToInt32(dbSL_THU_HOI));

                            drHanTt0["Modify"] = true;
                            drHanTt0["Thanh_Toan"] = true;
                            drHanTt0["LastModify_Log"] = Common.GetCurrent_Log();
                            this.btSave.Enabled = true;
                        }
                        else
                        {
                            drHanTt0["TSL_THU_HOI"] = "";
                            drHanTt0["Modify"] = false;
                            drHanTt0["Thanh_Toan"] = false;
                            drHanTt0["LastModify_Log"] = "";

                        }

                        drHanTt0.AcceptChanges();
                        this.Tinh_Tong();

                    }

                    if (Common.Inlist(strColumnName, "TSL_THU_HOI"))
                    {
                        string strSL_TL = drHanTt0["TSL_THU_HOI"].ToString();
                         double dbTON_CUOI = Convert.ToDouble(drHanTt0["TON_CUOI"]);
                        int iHe_So = Convert.ToInt32( drHanTt0["HE_SO"]);
                        int iT = 0, iL = 0;

                        if(strSL_TL.Contains("/"))
                        {
                            string[] ArrTL = strSL_TL.Split('/');
                            if (!int.TryParse(ArrTL[0].ToString(), out iT))
                                iT = 0;

                            if (!int.TryParse(ArrTL[1].ToString(), out iL))
                                iL = 0;

                            iL = iT * iHe_So + iL;

                            
                            //if (iL > dbTON_CUOI)
                            //    iL = Convert.ToInt32(dbTON_CUOI);
                            //drHanTt0["SL_THU_HOI"] = iL.ToString();
                            //drHanTt0["TSL_THU_HOI"] = VC_Get_TL(iHe_So, iL);
                        }
                        else
                        {
                            if (!int.TryParse(strSL_TL, out iL))
                                iL = 0;
                        }

                        if(iL>0)
                        {
                            if (iL > dbTON_CUOI)
                                iL = Convert.ToInt32(dbTON_CUOI);
                            
                            drHanTt0["SL_THU_HOI"] = iL.ToString();
                            drHanTt0["TSL_THU_HOI"] = VC_Get_TL(iHe_So, iL);
                            drHanTt0["Modify"] = true;
                            drHanTt0["Thanh_Toan"] = true;
                            drHanTt0["LastModify_Log"] = Common.GetCurrent_Log();
                            this.btSave.Enabled = true;

                           
                        }
                        else
                        {
                            drHanTt0["SL_THU_HOI"] = 0;
                            drHanTt0["TSL_THU_HOI"] = "";
                            drHanTt0["Modify"] = false;
                            drHanTt0["Thanh_Toan"] = false;
                            drHanTt0["LastModify_Log"] = "";
                        }

                    }

                    this.btSave.Enabled = true;
                }
            }
        }

        void dgvGridView_CustomRowCellEdit(object sender, CellValueChangedEventArgs e)
        {

        }
        #endregion
    }
}
