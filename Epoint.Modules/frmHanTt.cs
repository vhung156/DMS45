using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;
using System.Data.SqlClient;

namespace Epoint.Modules
{
    public partial class frmHanTt : Epoint.Systems.Customizes.frmView
    {
        DataTable dtThanhToan;
        DataTable dtHanTt0;

        BindingSource bdsThanhToan = new BindingSource();
        BindingSource bdsHanTt = new BindingSource();

        frmVoucher_Edit frmEditCt;
        frmHanTt_Filter frmFilter = new frmHanTt_Filter();
        string strStt = string.Empty;

        DateTime dtNgay_Ct = DateTime.MinValue;

        #region Contructor

        public frmHanTt()
        {
            InitializeComponent();

            this.bdsThanhToan.PositionChanged += new EventHandler(bdsThanhToan_PositionChanged);
            this.dgvThanhToan.RowValidated += new DataGridViewCellEventHandler(dgvThanhToan_RowValidated);
            this.dgvHanTt0.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvHanTt0_CellMouseClick);
            this.dgvHanTt0.CellBeginEdit += new DataGridViewCellCancelEventHandler(dgvHanTt0_CellBeginEdit);
            this.dgvHanTt0.CellEndEdit += new DataGridViewCellEventHandler(dgvHanTt0_CellEndEdit);

            this.dgvThanhToan.GotFocus += new EventHandler(dgvHanTt_GotFocus);
            this.dgvHanTt0.GotFocus += new EventHandler(dgvHanTt0_GotFocus);

            this.dgvThanhToan.CellDoubleClick += new DataGridViewCellEventHandler(dgvThanhToan_CellDoubleClick);
            
            this.btSave.Click += new EventHandler(btSave_Click);
            this.btPreview.Click += new EventHandler(btPreview_Click);
        }

        void dgvThanhToan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((this.bdsThanhToan != null) && (this.bdsThanhToan.Position >= 0))
            {
                DataRow row = ((DataRowView)this.bdsThanhToan.Current).Row;
                this.txtTk.Text = row["Tk"].ToString();
                this.txtMa_Dt.Text = row["Ma_Dt"].ToString();
            }

        }

        void btPreview_Click(object sender, EventArgs e)
        {
            if (this.frmEditCt != null)
            {
                this.FillThanhToanFromEditCt();
            }
            else
            {
                this.FillHanTtFromCongNo();

            }
        }

        new public void Load()
        {
            Build();

            if (this.frmEditCt != null) //Điền dữ liệu thanh toán từ EditCt
                FillThanhToanFromEditCt();
            else
                FillHanTtFromCongNo();


            txtTk.Text = "1311";
            this.dteNgay_Ct.Text = Library.DateToStr(Element.sysNgay_Ct);

            BindingLanguage();
            dgvThanhToan.Focus();
            if (this.frmEditCt != null)
            {
                this.txtMa_Tte.Text = this.frmEditCt.drEditPh["Ma_Tte"].ToString();
                this.numTy_Gia.Value = Convert.ToDouble(this.frmEditCt.drEditPh["Ty_Gia"]);
            }
            else if (this.strStt != "")
            {
                DataRow row = DataTool.SQLGetDataRowByID("vw_ThanhToan", "Stt_PT", this.strStt);
                if (row != null)
                {
                    this.txtMa_Tte.Text = row["Ma_Tte_PT"].ToString();
                    this.numTy_Gia.Value = Convert.ToDouble(row["Ty_Gia_PT"]);
                }
            }
            if ((this.frmEditCt != null) && this.frmEditCt.Controls.ContainsKey("dteNgay_Ct"))
            {
                this.dteNgay_Ct.Text = this.frmEditCt.Controls["dteNgay_Ct"].Text;
            }
            this.txtTk.Enabled = this.txtTk.Enabled = this.chkDu_Cuoi_Only.Enabled = this.btPreview.Enabled = (this.frmEditCt == null) && (this.strStt == "");
            this.chkDu_Cuoi_Only.Checked = (this.frmEditCt == null) && (this.strStt == "");
           

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

        public void Load(frmVoucher_Edit frmEditCt)
        {
            this.frmEditCt = frmEditCt;
            this.dtNgay_Ct = (DateTime)frmEditCt.dtEditPh.Rows[0]["Ngay_Ct"];

            this.strStt = (string)frmEditCt.dtEditPh.Rows[0]["Stt"];

            this.Load();
        }

        #endregion

        #region Method

        public void Init()
        {
            frmFilter = new frmHanTt_Filter();
            frmFilter.Load();

            if (!frmFilter.isAccept)
            {
                this.Close();
                this.isView = false;
            }
            else
                Load();
        }

        private void Build()
        {
            dgvThanhToan.strZone = "THANHTOAN";
            dgvThanhToan.BuildGridView();

            dgvHanTt0.ReadOnly = false;
            dgvHanTt0.strZone = "HANTT00";
            dgvHanTt0.BuildGridView();

            ////Thêm cột để đánh dấu có modify hay không
            //DataGridViewColumn dgvc1 = new DataGridViewColumn();
            //dgvc1.DataPropertyName = "Modify";
            //dgvc1.
            //dgvc1.Visible = false;
            //dgvHanTt0.Columns.Add(dgvc1);

            foreach (DataGridViewColumn dgvc in dgvHanTt0.Columns)
            {
                if (dgvc.Name == "TIEN_TT1" || dgvc.Name == "TIEN_TT_NT1" || dgvc.Name == "THANH_TOAN")
                    dgvc.ReadOnly = false;
                else
                    dgvc.ReadOnly = true;
            }
        }
        private void FillHanTt()
        {
            if ((this.bdsThanhToan != null) && (this.bdsThanhToan.Position >= 0))
            {
                DataRow drHanTt = ((DataRowView)this.bdsThanhToan.Current).Row;
                DateTime time = this.btPreview.Enabled ? Library.StrToDate(this.dteNgay_Ct.Text) : ((DateTime)drHanTt["Ngay_Ct_PT"]);
                string strTk = (string)drHanTt["Tk"];
                string strMa_Dt = (string)drHanTt["Ma_Dt"];
                string strStt_Pt = (string)drHanTt["Stt_PT"];
                if (((this.frmEditCt != null) && (this.frmEditCt.dtHanTt0 != null)) && (this.frmEditCt.dtHanTt0.Select("Tk = '" + strTk + "' AND Ma_Dt = '" + strMa_Dt + "'").Length > 0))
                {
                    this.dtHanTt0 = this.frmEditCt.dtHanTt0.Clone();
                    foreach (DataRow row2 in this.frmEditCt.dtHanTt0.Select("Tk = '" + strTk + "' AND Ma_Dt = '" + strMa_Dt + "'"))
                    {
                        DataRow drDest = this.dtThanhToan.NewRow();
                        Common.CopyDataRow(row2, drDest);
                        this.dtHanTt0.Rows.Add(drDest);
                    }
                    this.bdsHanTt.DataSource = this.dtHanTt0;
                    this.dgvHanTt0.DataSource = this.bdsHanTt;
                }
                else
                {
                    Hashtable htSQLPara = new Hashtable();
                    htSQLPara.Add("NGAY_CT1", time);
                    htSQLPara.Add("NGAY_CT2", time);
                    htSQLPara.Add("TK", strTk);
                    htSQLPara.Add("MA_DT", strMa_Dt);
                    htSQLPara.Add("STT_PT", strStt_Pt);
                    htSQLPara.Add("IS_UNGTRUOC", drHanTt["Is_UngTruoc"]);
                    htSQLPara.Add("MA_DVCS", Element.sysMa_DvCs);
                    this.dtHanTt0 = SQLExec.ExecuteReturnDt("sp_GetHanTt00", htSQLPara, CommandType.StoredProcedure);
                    if (!this.dtHanTt0.Columns.Contains("Modify"))
                    {
                        this.dtHanTt0.Columns.Add(new DataColumn("Modify", typeof(bool)));
                        this.dtHanTt0.Columns["Modify"].DefaultValue = false;
                    }
                    this.bdsHanTt.DataSource = this.dtHanTt0;
                    this.dgvHanTt0.DataSource = this.bdsHanTt;
                }
                this.Tinh_Tong();
            }
        }

        private void FillHanTtFromCongNo()
        {
            if ((!this.dteNgay_Ct.IsNull && (this.txtTk.Text != "")) || (this.strStt != ""))
            {
                Hashtable hashtable;
                if (this.strStt != "")
                {
                    hashtable = new Hashtable();
                    hashtable.Add("NGAY_CT2", Library.StrToDate(this.dteNgay_Ct.Text));
                    hashtable.Add("TK", this.txtTk.Text);
                    hashtable.Add("MA_DT", "");
                    hashtable.Add("DU_CUOI_ONLY", this.chkDu_Cuoi_Only.Checked);
                    hashtable.Add("STT", this.strStt);
                    hashtable.Add("MA_DVCS", Element.sysMa_DvCs);
                    this.dtThanhToan = SQLExec.ExecuteReturnDt("Sp_GetThanhToanCt", hashtable, CommandType.StoredProcedure);
                    this.bdsThanhToan.DataSource = this.dtThanhToan;
                    this.dgvThanhToan.DataSource = this.bdsThanhToan;
                    if (this.txtMa_Dt.Text != "")
                    {
                        this.bdsThanhToan.Position = this.bdsThanhToan.Find("Ma_Dt", this.txtMa_Dt.Text);
                    }
                }
                else
                {
                    hashtable = new Hashtable();
                    hashtable.Add("NGAY_CT2", Library.StrToDate(this.dteNgay_Ct.Text));
                    hashtable.Add("TK", this.txtTk.Text);
                    hashtable.Add("MA_DT", this.txtMa_Dt.Text);
                    hashtable.Add("DU_CUOI_ONLY", this.chkDu_Cuoi_Only.Checked);
                    hashtable.Add("STT", this.strStt);
                    hashtable.Add("MA_DVCS", Element.sysMa_DvCs);
                    this.dtThanhToan = SQLExec.ExecuteReturnDt("Sp_DMS_Hantt", hashtable, CommandType.StoredProcedure); 
                    //this.dtThanhToan = SQLExec.ExecuteReturnDt("Sp_GetThanhToanCt", hashtable, CommandType.StoredProcedure);
                    this.dgvThanhToan.DataSource = this.bdsThanhToan;
                    this.bdsThanhToan.DataSource = this.dtThanhToan;
                }
            }


        }

        private void FillThanhToanFromEditCt()
        {
            double dbTien;
            double dbTien_Nt;
            Voucher.Update_Detail(this.frmEditCt);
            string strSQLExec = "\r\n\t\t\t\t\tSELECT TOP 0 Stt_PT, Ma_Ct_PT, Ngay_Ct_PT, So_Ct_PT, Tk, Ma_Dt, Ma_Tte_PT, Ty_Gia_PT, Tien_PT, Tien_PT_Nt, Dien_Giai_PT, CAST(0 AS BIT) AS Is_UngTruoc \r\n\t\t\t\t\t    FROM vw_ThanhToan \r\n\t\t\t\t\t\tWHERE 0 = 1";
            this.dtThanhToan = SQLExec.ExecuteReturnDt(strSQLExec);
            string strTkHanTt = "," + ((string)Parameters.GetParaValue("TK_HANTT_LIST"));
            DataRow[] rowArray = this.frmEditCt.dtEditCt.Select("Deleted = false");
            bool bIs_UngTruoc = false;
            foreach (DataRow row in rowArray)
            {
                string strTk_No;
                string strTk_Co;
                string strMa_Dt;
                string strMa_Dt_Co;
                if (row.Table.Columns.Contains("TIEN"))
                {
                    strTk_No = ((string)row["Tk_No"]).Trim();
                    strTk_Co = ((string)row["Tk_Co"]).Trim();
                    strMa_Dt = ((string)row["Ma_Dt"]).Trim();
                    string strMa_Ct = ((string)row["Ma_Ct"]).Trim();
                    dbTien = Convert.ToDouble(row["Tien"]);
                    dbTien_Nt = Convert.ToDouble(row["Tien_Nt"]);
                    if (row.Table.Columns.Contains("Is_UngTruoc"))
                    {
                        bIs_UngTruoc = (bool)row["Is_UngTruoc"];
                    }
                    if (row.Table.Columns.Contains("Ma_Dt_Co") && (((string)row["Ma_Dt_Co"]) != string.Empty))
                    {
                        strMa_Dt_Co = (string)row["Ma_Dt_Co"];
                    }
                    else
                    {
                        strMa_Dt_Co = strMa_Dt;
                    }
                    if ((strTk_No != string.Empty) && (strTk_Co != string.Empty))
                    {
                        if (strTkHanTt.Contains("," + strTk_No.Substring(0, 3)) && (this.frmEditCt.dtEditCt.Select("Tk_No LIKE '" + strTk_No + "%' AND Han_Tt = 0").Length > 0))
                        {
                            this.SaveToHanTt(strTk_No, strMa_Dt, dbTien, dbTien_Nt, "N", bIs_UngTruoc);
                        }
                        if (strTkHanTt.Contains("," + strTk_Co.Substring(0, 3)))
                        {
                            if ((strMa_Ct == "BT") && this.frmEditCt.dtEditCt.Columns.Contains("Han_Tt_Co"))
                            {
                                if (this.frmEditCt.dtEditCt.Select("Tk_Co LIKE '" + strTk_Co + "%' AND Han_Tt_Co = 0").Length > 0)
                                {
                                    this.SaveToHanTt(strTk_Co, strMa_Dt_Co, dbTien, dbTien_Nt, "C", bIs_UngTruoc);
                                }
                            }
                            else if (this.frmEditCt.dtEditCt.Select("Tk_Co LIKE '" + strTk_Co + "%' AND Han_Tt = 0").Length > 0)
                            {
                                this.SaveToHanTt(strTk_Co, strMa_Dt_Co, dbTien, dbTien_Nt, "C", bIs_UngTruoc);
                            }
                        }
                    }
                }
                if (row.Table.Columns.Contains("TIEN3"))
                {
                    strTk_No = ((string)row["Tk_No3"]).Trim();
                    strTk_Co = ((string)row["Tk_Co3"]).Trim();
                    strMa_Dt = ((string)row["Ma_Dt"]).Trim();
                    dbTien = Convert.ToDouble(row["Tien3"]);
                    dbTien_Nt = Convert.ToDouble(row["Tien_Nt3"]);
                    if (row.Table.Columns.Contains("Ma_Dt_Co") && (((string)row["Ma_Dt_Co"]) != string.Empty))
                    {
                        strMa_Dt_Co = (string)row["Ma_Dt_Co"];
                    }
                    else
                    {
                        strMa_Dt_Co = strMa_Dt;
                    }
                    if ((strTk_No != string.Empty) && (strTk_Co != string.Empty))
                    {
                        if (strTkHanTt.Contains("," + strTk_No.Substring(0, 3)) && (this.frmEditCt.dtEditCt.Select("Tk_No LIKE '" + strTk_No + "%' AND Han_Tt = 0").Length > 0))
                        {
                            this.SaveToHanTt(strTk_No, strMa_Dt, dbTien, dbTien_Nt, "N", bIs_UngTruoc);
                        }
                        if (strTkHanTt.Contains("," + strTk_Co.Substring(0, 3)) && (this.frmEditCt.dtEditCt.Select("Tk_Co LIKE '" + strTk_Co + "%' AND Han_Tt = 0").Length > 0))
                        {
                            this.SaveToHanTt(strTk_Co, strMa_Dt_Co, dbTien, dbTien_Nt, "C", bIs_UngTruoc);
                        }
                    }
                }
            }
            foreach (DataRow row in this.dtThanhToan.Rows)
            {
                dbTien = Convert.ToDouble(row["Tien_PT"]);
                dbTien_Nt = Convert.ToDouble(row["Tien_PT_Nt"]);
                if ((dbTien != dbTien_Nt) && (dbTien_Nt != 0.0))
                {
                    row["Ty_Gia_PT"] = Math.Round((double)(dbTien / dbTien_Nt), 0, MidpointRounding.AwayFromZero);
                }
            }
            this.dgvThanhToan.DataSource = this.bdsThanhToan;
            this.bdsThanhToan.DataSource = this.dtThanhToan;
        }

        private void SaveToHanTt(string strTk, string strMa_Dt, double dbTien_Tt, double dbTien_Tt_Nt, string strNo_Co, bool bIs_UngTruoc)
        {
            DataRow[] drArrHanTt = dtThanhToan.Select("Tk = '" + strTk + "' AND Ma_Dt = '" + strMa_Dt + "'");
            DataRow drAdd;

            if (drArrHanTt.Length == 0)
            {
                drAdd = dtThanhToan.NewRow();
                Common.SetDefaultDataRow(ref drAdd);

                dtThanhToan.Rows.Add(drAdd);
            }
            else
                drAdd = drArrHanTt[0];

            Common.CopyDataRow(frmEditCt.dtEditCt.Rows[0], drAdd, "Stt,Ma_Ct,Ngay_Ct,So_Ct,Dien_Giai,Ma_Tte,Ty_Gia");

            string strTk_No_Giam_CongNo = "," + (string)Parameters.GetParaValue("TK_NO_GIAM_CONGNO");
            if (strNo_Co == "N" && !strTk_No_Giam_CongNo.Contains("," + strTk.Substring(0, 3)))
            {
                dbTien_Tt = -dbTien_Tt;
                dbTien_Tt_Nt = -dbTien_Tt_Nt;
            }
            else if (strNo_Co == "C" && strTk_No_Giam_CongNo.Contains("," + strTk.Substring(0, 3)))
            {
                dbTien_Tt = -dbTien_Tt;
                dbTien_Tt_Nt = -dbTien_Tt_Nt;
            }

            drAdd["Tk"] = strTk;
            drAdd["Ma_Dt"] = strMa_Dt;
            drAdd["Tien"] = Convert.ToDouble(drAdd["Tien"]) + dbTien_Tt;
            drAdd["Tien_Nt"] = Convert.ToDouble(drAdd["Tien_Nt"]) + dbTien_Tt_Nt;
            drAdd["Is_UngTruoc"] = bIs_UngTruoc;

            dtThanhToan.AcceptChanges();
        }

        private void Auto_Ticked()
        {
            DataRow row = ((DataRowView)this.bdsHanTt.Current).Row;
            DataGridViewCell currentCell = this.dgvHanTt0.CurrentCell;
            string strExpr = currentCell.OwningColumn.Name.ToUpper();
            if (!currentCell.ReadOnly && Common.Inlist(strExpr, "THANH_TOAN"))
            {
                if (!Element.sysIs_Admin)
                {
                    string str2 = (string)row["LastModify_Log"];
                    if (str2.Length > 0)
                    {
                        str2 = str2.Substring(14);
                    }
                    if ((str2 != string.Empty) && (str2 != Element.sysUser_Id))
                    {
                        Common.MsgCancel("Kh\x00f4ng được sửa dữ liệu do " + str2 + " đ\x00e3 thanh to\x00e1n!");
                        return;
                    }
                }
                bool bThanhToan = !((bool)currentCell.EditedFormattedValue);
                if (bThanhToan)
                {
                    double dbTien_Tt_Allow;
                    double dbTien_Tt_Nt_Allow;
                    double dbTien_Tt1;
                    double dbTien_Tt_Nt1;

                    DataRow row2 = ((DataRowView)this.bdsThanhToan.Current).Row;
                    string strStt_Pt = row2["Stt_PT"].ToString();
                    DateTime dteNgay_Ct_Pt = (DateTime)row2["Ngay_Ct_PT"];
                    string strTk = (string)row2["Tk"];
                    string strMa_Dt = (string)row2["Ma_Dt"];
                    double dbTien_PT = Convert.ToDouble(row2["Tien_PT"]);
                    double dbTien_PT_Nt = Convert.ToDouble(row2["Tien_PT_Nt"]);
                    double dbTy_Gia_PT = Math.Round((double)(dbTien_PT / dbTien_PT_Nt), 2, MidpointRounding.AwayFromZero);
                    DateTime dtNgay_Ct_Hd = (dteNgay_Ct_Pt > ((DateTime)row["Ngay_Ct_HD"])) ? dteNgay_Ct_Pt : ((DateTime)row["Ngay_Ct_HD"]);
                    if (((row["Ngay_Ct_TT"] != DBNull.Value) && (((DateTime)row["Ngay_Ct_TT"]) != Element.sysNgay_Min)) && (DateTime.Compare((DateTime)row["Ngay_Ct_TT"], dtNgay_Ct_Hd) > 0))
                    {
                        dtNgay_Ct_Hd = (DateTime)row["Ngay_Ct_TT"];
                    }
                    if (!Common.CheckDataLocked(dtNgay_Ct_Hd))
                    {
                        Common.MsgCancel("Dữ liệu ng\x00e0y [" + Library.DateToStr(dtNgay_Ct_Hd) + "] đ\x00e3 kh\x00f3a!");
                        return;
                    }
                    double dbTien_No1 = Convert.ToDouble(row["Tien_No1"]);
                    double dbTien_No_Nt1 = Convert.ToDouble(row["Tien_No_Nt1"]);
                    double dbTy_Gia_Hd = Convert.ToDouble(row["Ty_Gia_HD"]);
                    double dbTTien_Tt1 = Common.SumDCValue(this.dtHanTt0, "Tien_Tt1", "Stt_PT = '" + strStt_Pt + "' AND Tk = '" + strTk + "' AND Ma_Dt = '" + strMa_Dt + "'");
                    double dbTTien_Tt_Nt1 = Common.SumDCValue(this.dtHanTt0, "Tien_Tt_Nt1", "Stt_PT = '" + strStt_Pt + "' AND Tk = '" + strTk + "' AND Ma_Dt = '" + strMa_Dt + "'");
                    double TTien_ClTg = Common.SumDCValue(this.dtHanTt0, "Tien_ClTg", "Stt_PT = '" + strStt_Pt + "' AND Tk = '" + strTk + "' AND Ma_Dt = '" + strMa_Dt + "'");
                    if (dbTien_PT >= 0.0)
                    {
                        dbTien_Tt_Allow = Math.Max((double)0.0, (double)(dbTien_PT - dbTTien_Tt1));
                        dbTien_Tt_Nt_Allow = Math.Max((double)0.0, (double)(dbTien_PT_Nt - dbTTien_Tt_Nt1));
                       
                        dbTien_Tt1 = Math.Min(dbTien_No1, dbTien_Tt_Allow);
                        dbTien_Tt_Nt1 = Math.Min(dbTien_No_Nt1, dbTien_Tt_Nt_Allow);
                    }
                    else
                    {
                        dbTien_Tt_Allow = Math.Min((double)0.0, (double)(dbTien_PT - dbTTien_Tt1));
                        dbTien_Tt_Nt_Allow = Math.Min((double)0.0, (double)(dbTien_PT_Nt - dbTTien_Tt_Nt1));
                        
                        dbTien_Tt1 = Math.Max(dbTien_No1, dbTien_Tt_Allow);
                        dbTien_Tt_Nt1 = Math.Max(dbTien_No_Nt1, dbTien_Tt_Nt_Allow);
                    }
                    if (dbTien_Tt_Nt1 > 0.0)
                    {
                        if (dbTy_Gia_PT != dbTy_Gia_Hd)
                        {
                            if (dbTien_Tt_Nt1 == dbTien_Tt_Nt_Allow)
                            {
                                dbTien_Tt1 = dbTien_Tt_Allow;
                            }
                            else
                            {
                                dbTien_Tt1 = Math.Round((double)(dbTien_Tt_Nt1 * dbTy_Gia_PT), 0, MidpointRounding.AwayFromZero);
                            }
                        }
                        if (dbTien_PT >= 0.0)
                        {
                            dbTien_Tt1 = Math.Min(dbTien_Tt1, dbTien_Tt_Allow);
                        }
                        else
                        {
                            dbTien_Tt1 = Math.Max(dbTien_Tt1, dbTien_Tt_Allow);
                        }
                    }
                    if (!((Math.Abs(dbTien_Tt1) + Math.Abs(dbTien_Tt_Nt1)) == 0.0))
                    {
                        row["Tien_Tt1"] = dbTien_Tt1;
                        row["Tien_Tt_Nt1"] = dbTien_Tt_Nt1;
                        row["Ngay_Ct_TT"] = dtNgay_Ct_Hd;
                        row["Stt_PT"] = strStt_Pt;
                        row["LastModify_Log"] = Common.GetCurrent_Log();
                        row["Thanh_Toan"] = bThanhToan;
                        row["Modify"] = true;
                        this.btSave.Enabled = true;
                    }
                }
                else
                {
                    row["Tien_Tt1"] = 0;
                    row["Tien_Tt_Nt1"] = 0;
                    row["Ngay_Ct_TT"] = Element.sysNgay_Min;
                    row["LastModify_Log"] = string.Empty;
                    row["Thanh_Toan"] = bThanhToan;
                    row["Modify"] = true;
                    this.btSave.Enabled = true;
                }
                this.Calc_CLTG();
                row.AcceptChanges();
                this.dgvHanTt0.EndEdit();
                this.Tinh_Tong();
            }
        }

        private void Calc_CLTG()
        {
            DataRow drHanTt = ((DataRowView)bdsThanhToan.Current).Row;

            if (Convert.ToBoolean(drHanTt["Is_UngTruoc"]))
                return;

            DataRow drHanTt0 = ((DataRowView)bdsHanTt.Current).Row;
            DataGridViewCell dgvCell = dgvHanTt0.CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (btSave.Enabled)
            {
                string strTk = (string)drHanTt0["Tk"];

                double dbTien_No1 = Convert.ToDouble(drHanTt0["Tien_No1"]);
                double dbTien_No_Nt1 = Convert.ToDouble(drHanTt0["Tien_No_Nt1"]);

                double dbTien_Tt1 = Convert.ToDouble(drHanTt0["Tien_Tt1"]);
                double dbTien_Tt_Nt1 = Convert.ToDouble(drHanTt0["Tien_Tt_Nt1"]);

                double dbTy_Gia_Tt = 0;
                double dbTy_Gia_CL = 0;
                double dbTien_ClTg = 0;

                if (dbTien_Tt_Nt1 == 0 || dbTien_No_Nt1 == 0 || dbTien_Tt1 == dbTien_No1)
                {
                    drHanTt0["Tien_CLTG"] = 0;
                    return;
                }

                if (dbTien_Tt_Nt1 == dbTien_No_Nt1) //Thanh toán hết tiền Nt
                {
                    if (((string)drHanTt0["Tk"]).StartsWith("1") || ((string)drHanTt0["Tk"]).StartsWith("2"))
                        dbTien_ClTg = dbTien_Tt1 - dbTien_No1;
                    else
                        dbTien_ClTg = dbTien_No1 - dbTien_Tt1;
                }
                else
                {
                    dbTy_Gia_Tt = Math.Round(dbTien_Tt1 / dbTien_Tt_Nt1, 2, MidpointRounding.AwayFromZero); //Convert.ToDouble(drHanTt["Ty_Gia"])

                    if (((string)drHanTt0["Tk"]).StartsWith("1") || ((string)drHanTt0["Tk"]).StartsWith("2"))
                        dbTy_Gia_CL = dbTy_Gia_Tt - Convert.ToDouble(drHanTt0["Ty_Gia_HD"]);
                    else
                        dbTy_Gia_CL = -dbTy_Gia_Tt + Convert.ToDouble(drHanTt0["Ty_Gia_HD"]);

                    dbTien_ClTg = Math.Round(dbTy_Gia_CL * dbTien_Tt_Nt1, MidpointRounding.AwayFromZero);
                }

                drHanTt0["Tien_CLTG"] = dbTien_ClTg;

            }
        }
        private void Save_HanTt0()
        {
            DataRow row3;
            DataRow CurrRow = ((DataRowView)this.bdsThanhToan.Current).Row;
            double dbTien_PT = Convert.ToDouble(CurrRow["Tien_PT"]);
            double dbTien_Pt_Nt = Convert.ToDouble(CurrRow["Tien_PT_Nt"]);
            if (dbTien_PT != this.numTTien_Tt.Value)
            {
                if (!Common.MsgYes_No("Giá trị trên chứng từ thanh toán khác với tổng giá trị thanh toán. Bạn có muốn tiếp tục hay không?"))
                {
                    return;
                }
            }
            else if (!(dbTien_Pt_Nt == this.numTTien_Tt_Nt.Value) && !Common.MsgYes_No("Giá trị Nt trên chứng từ thanh toán khác với tổng giá trị Nt thanh toán. Bạn có muốn tiếp tục hay không?"))
            {
                return;
            }
            if (this.frmEditCt != null)
            {
                string strTk = CurrRow["Tk"].ToString();
                string strMa_Dt = CurrRow["Ma_Dt"].ToString();
                if (this.frmEditCt.dtHanTt0 != null)
                {
                    foreach (DataRow row2 in this.frmEditCt.dtHanTt0.Select("Tk = '" + strTk + "' AND Ma_Dt = '" + strMa_Dt + "'"))
                    {
                        this.frmEditCt.dtHanTt0.Rows.Remove(row2);
                    }
                }
                else
                {
                    this.frmEditCt.dtHanTt0 = this.dtHanTt0.Clone();
                }
                foreach (DataRow row2 in this.dtHanTt0.Select("Tk = '" + strTk + "' AND Ma_Dt = '" + strMa_Dt + "'"))
                {
                    row3 = this.frmEditCt.dtHanTt0.NewRow();
                    Common.CopyDataRow(row2, row3);
                    this.frmEditCt.dtHanTt0.Rows.Add(row3);
                }
                this.frmEditCt.dtHanTt0.AcceptChanges();
                this.btSave.Enabled = false;
            }
            else
            {
                DataTable dtTableSource = SQLExec.ExecuteReturnDt("SELECT *, CAST(0 AS BIT) AS Thanh_Toan FROM GLTHANHTOANCT WHERE 0 = 1");
                foreach (DataRow row2 in this.dtHanTt0.Select(this.bdsHanTt.Filter))
                {
                    row3 = dtTableSource.NewRow();
                    Common.CopyDataRow(row2, row3);
                    if ((row3["Ngay_Ct_TT"] == DBNull.Value) && (((DateTime)row3["Ngay_Ct_TT"]) == Element.sysNgay_Min))
                    {
                        row3["Ngay_Ct_TT"] = Library.StrToDate(this.dteNgay_Ct.Text);
                    }
                    row3["Stt_PT"] = CurrRow["Stt_PT"];
                    row3["Tk"] = row2["Tk"];
                    row3["Ma_Dt"] = row2["Ma_Dt"];
                    row3["Stt_HD"] = row2["Stt_HD"];
                    row3["Tien_Tt"] = row2["Tien_Tt1"];
                    row3["Tien_Tt_Nt"] = row2["Tien_Tt_Nt1"];
                    row3["Tien_CLTG"] = row2["Tien_CLTG"];
                    row3["LastModify_Log"] = row2["LastModify_Log"];
                    dtTableSource.Rows.Add(row3);
                }
                dtTableSource.AcceptChanges();
                SqlCommand command = SQLExec.GetNewSQLConnection().CreateCommand();
                command.CommandText = "Sp_Update_CtHanTt";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Stt", "");
                command.Parameters.AddWithValue("@Ma_Ct", CurrRow["Ma_Ct_PT"]);
                command.Parameters.AddWithValue("@Tk", CurrRow["Tk"]);
                command.Parameters.AddWithValue("@Ma_Dt", CurrRow["Ma_Dt"]);
                command.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);
                SqlParameter parameter = new SqlParameter
                {
                    SqlDbType = SqlDbType.Structured,
                    ParameterName = "@CtHanTt",
                    TypeName = "TVP_CtHanTt",
                    Value = Voucher.GetTVPValue("GLTHANHTOANCT", "TVP_CtHanTt", dtTableSource)
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
                    MessageBox.Show("Có lỗi xảy ra :" + exception.Message);
                }
                this.btSave.Enabled = false;
            }
        }

 
        private void Tinh_Tong()
        {
            this.numTTien_Tt.Value = Common.SumDCValue(dtHanTt0, "Tien_Tt1", "");
            this.numTTien_Tt_Nt.Value = Common.SumDCValue(dtHanTt0, "Tien_Tt_Nt1", "");
            this.numTTien_CLTG.Value = Common.SumDCValue(dtHanTt0, "Tien_CLTG", "");
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
            this.ExportControl = dgvThanhToan;
            this.bdsSearch = bdsThanhToan;
        }

        void bdsThanhToan_PositionChanged(object sender, EventArgs e)
        {
            FillHanTt();
        }

        void dgvThanhToan_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (this.btSave.Enabled == true)
            {
                if (Common.MsgYes_No(Languages.GetLanguage("Do_You_Want_To_Save")))
                    this.Save_HanTt0();
                else
                    this.btSave.Enabled = false;
            }
        }

        void dgvHanTt0_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Auto_Ticked();
        }

        void dgvHanTt0_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewCell dgvCell = dgvHanTt0.CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (Common.Inlist(strColumnName, "TIEN_TT1,TIEN_TT_NT1"))
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
            DataGridViewCell dgvCell = dgvHanTt0.CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (Common.Inlist(strColumnName, "TIEN_TT1,TIEN_TT_NT1"))
            {
                DataRow drHanTt0 = ((DataRowView)bdsHanTt.Current).Row;
                drHanTt0["Modify"] = true;

                this.Calc_CLTG();

                this.Tinh_Tong();
            }
        }

        void btSave_Click(object sender, EventArgs e)
        {
            this.Save_HanTt0();
            if (((this.frmEditCt != null)) && ((this.frmEditCt != null) && this.frmEditCt.Controls.ContainsKey("dteNgay_Ct")))
            {
                this.frmEditCt.Controls["dteNgay_Ct"].Text = this.dteNgay_Ct.Text;
            }
            if ((this.dtThanhToan.Rows.Count == 1) && (this.frmEditCt != null))
            {
                base.Close();
            }

        }

        #endregion
    }
}
