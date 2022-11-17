using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;
using Epoint.Lists;
using System.Data.SqlClient;

namespace Epoint.Modules.IN
{
    public partial class frmCtKiemKe_Edit : frmVoucher_Edit, IEditCtLR
    {
        private string strTk_NoTmp = string.Empty;
        private string strTk_CoTmp = string.Empty;
        private string strModule = "05";

        DataTable dtEdiCt_KiemKe;

        #region Contructor

        public frmCtKiemKe_Edit()
        {
            InitializeComponent();

            this.btGetDataStock.Click += new EventHandler(BtGetDataStock_Click);
            this.btUpdateStock.Click += new EventHandler(btUpdateStock_Click);
            this.KeyDown += new KeyEventHandler(frmEditCtTien_KeyDown);
            this.chkIsStock.CheckedChanged += new EventHandler(ChkIs_Stock_CheckedChanged);

            tabVoucher.SelectedIndexChanged += new EventHandler(tabVoucher_SelectedIndexChanged);
            tabVoucher.Enter += new EventHandler(tabVoucher_Enter);

            //txtMa_Dt.Enter += new EventHandler(txtMa_Dt_Enter);
            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);

            txtMa_Hd.Enter += new EventHandler(txtMa_Hd_Enter);
            txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);

            txtMa_Kho.Enter += new EventHandler(txtMa_KhoN_Enter);
            txtMa_Kho.Validating += new CancelEventHandler(txtMa_KhoN_Validating);

            txtMa_Ct.Enter += new EventHandler(txtMa_Ct_Enter);
            txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
            txtMa_Ct.TextChanged += new EventHandler(txtMa_Ct_TextChanged);

            txtSo_Ct.Validating += new CancelEventHandler(txtSo_Ct_Validating);
            linkHelp.LinkClicked += new LinkLabelLinkClickedEventHandler(linkHelp_LinkClicked);

            dteNgay_Ct.Validating += new CancelEventHandler(dteNgay_Ct_Validating);
            txtMa_Tte.Validating += new CancelEventHandler(txtMa_Tte_Validating);
            numTy_Gia.Leave += new EventHandler(numTy_Gia_Leave);

            //txtTk_No.Validating += new CancelEventHandler(txtTk_No_Validating);

            dgvEditCt1.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt_CellValidating);
            dgvEditCt1.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
            dgvEditCt1.CellEnter += new DataGridViewCellEventHandler(dgvEditCt_CellEnter);
            dgvEditCt1.KeyDown += new KeyEventHandler(dgvEditCt_KeyDown);

            //dgvEditCt2.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt2_CellValidating);
            //dgvEditCt2.CellValidated += new DataGridViewCellEventHandler(dgvEditCt2_CellValidated);
            //dgvEditCt2.CellEnter += new DataGridViewCellEventHandler(dgvEditCt2_CellEnter);

        }

        private void ChkIs_Stock_CheckedChanged(object sender, EventArgs e)
        {
            this.BdsFilter();

        }

        private void BtGetDataStock_Click(object sender, EventArgs e)
        {
            if (txtMa_Kho.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ma_Kho") + " " +
                              Languages.GetLanguage("Not_Null"));

                return;
            }

            Hashtable ht = new Hashtable();

            ht["MA_KHO"] = txtMa_Kho.Text;
            ht["MA_NH_VT"] = txtMa_Nh_Vt.Text;
            ht["NGAY_CT1"] = Library.StrToDate(dteNgay_Ct.Text);
            ht["NGAY_CT2"] = Library.StrToDate(dteNgay_Ct.Text);
            ht["MA_DVCS"] = Element.sysMa_DvCs;

            DataTable dtStock = SQLExec.ExecuteReturnDt("sp_GetDataKiemkeStock", ht, CommandType.StoredProcedure);


            if (this.enuNew_Edit == enuEdit.New)
            {
                //DataRow drEditCt = dtEdiCt_KiemKe.NewRow();
                dtEditCt.Rows.Clear();

                foreach (DataRow drViewCt in dtStock.Rows)
                {
                    DataRow drEditCtNew = dtEditCt.NewRow();
                    //Common.CopyDataRow(drEditCt, drEditCtNew);
                    Common.CopyDataRow(drViewCt, drEditCtNew);


                    drEditCtNew["Stt"] = strStt;
                    drEditCtNew["Ma_Kho"] = txtMa_Kho.Text;
                    //drEditCtNew["Tk_No"] = drViewCt["Tk_Co"];
                    //drEditCtNew["Tk_Co"] = drViewCt["Tk_No"];
                    //drEditCtNew["Tk_No2"] = drViewCt["Tk_Co2"];
                    //drEditCtNew["Tk_Co2"] = drViewCt["Tk_No2"];
                    ////Stt_Org
                    //if (drEditCtNew.Table.Columns.Contains("Stt_Org"))
                    //	drEditCtNew["Stt_Org"] = drViewCt["Stt"];
                    dtEditCt.Rows.Add(drEditCtNew);
                }
            }
            else
            {
                //string strMsg = "Bạn có muốn cập nhật lại tồn kho?";
                //if (EpointMessage.MsgYes_No(strMsg))
                //{

                //}
            }
            dtEditCt.AcceptChanges();
            this.BdsFilter();

        }
        private void btUpdateStock_Click(object sender, EventArgs e)
        {
            string strFileName = string.Empty;

            OpenFileDialog ofdlg = new OpenFileDialog();
            ofdlg.Filter = "xls files (*.xls;*.xlsx)|*.xls;*.xlsx";
            ofdlg.RestoreDirectory = true;
            if (ofdlg.ShowDialog() != DialogResult.OK)
                return;
            strFileName = ofdlg.FileName;
            DataTable dtImport = Common.ReadExcel(strFileName);
            foreach (DataRow dr in dtImport.Rows)
            {

                int dbTonKK = -1, dbTonThungKK = -1, dbTonLeKk = -1;

                if (dtImport.Columns.Contains("So_Luong_Kk"))
                    if (int.TryParse(dr["So_Luong_Kk"].ToString(), out dbTonKK))
                    {
                        dr["So_Luong_Kk"] = dbTonKK;
                    }
                if (dtImport.Columns.Contains("So_Luong_Thung_Kk"))
                    if (int.TryParse(dr["So_Luong_Thung_Kk"].ToString(), out dbTonThungKK))
                    {
                        dr["So_Luong_Thung_Kk"] = dbTonThungKK;
                    }
                if (dtImport.Columns.Contains("So_Luong_Le_Kk"))
                    if (int.TryParse(dr["So_Luong_Le_Kk"].ToString(), out dbTonLeKk))
                    {
                        dr["So_Luong_Le_Kk"] = dbTonLeKk;
                    }
                dr.AcceptChanges();
            }

            if (dtImport.Columns.Contains("SO_LUONG_KK"))
                foreach (DataRow drCurrent in dtEditCt.Rows)
                {

                    double dbKk = this.getValue(drCurrent["Ma_vt"].ToString(), dtImport);
                    if (dbKk != -1)
                    {
                        drCurrent["SO_LUONG_KK"] = this.getValue(drCurrent["Ma_vt"].ToString(), dtImport);
                        drCurrent["Sua_Kk"] = true;
                        int IHe_So = Convert.ToInt32(drCurrent["He_So"]);
                        drCurrent["SO_LUONGTL_KK"] = getSlThungLe(Convert.ToInt32(drCurrent["SO_LUONG_KK"]), IHe_So);
                        drCurrent["TIEN_KK"] = Convert.ToInt32(drCurrent["SO_LUONG_KK"]) * Convert.ToInt32(drCurrent["GIA"]);
                        if (Convert.ToInt32(drCurrent["SO_LUONG_KK"]) == Convert.ToInt32(drCurrent["SO_LUONG"]))
                        {
                            drCurrent["SO_LUONG_CL"] = 0;
                            drCurrent["TIEN_CL"] = 0;
                        }
                        else
                        {
                            drCurrent["SO_LUONG_CL"] = Convert.ToInt32(drCurrent["SO_LUONG_KK"]) - Convert.ToInt32(drCurrent["SO_LUONG"]);
                            drCurrent["TIEN_CL"] = Convert.ToInt32(drCurrent["TIEN_KK"]) - Convert.ToInt32(drCurrent["TIEN"]);
                        }
                    }
                }
            else
            {
                foreach (DataRow drCurrent in dtEditCt.Rows)
                {

                    double dbThungKk = this.getValueThung(drCurrent["Ma_vt"].ToString(), dtImport);
                    double dbleKk = this.getValueLe(drCurrent["Ma_vt"].ToString(), dtImport);
                    if (dbleKk != -1)
                    {
                        //drCurrent["So_Luong_Kk"] = this.getValue(drCurrent["Ma_vt"].ToString(), dtImport);
                        drCurrent["Sua_Kk"] = true;
                        int IHe_So = Convert.ToInt32(drCurrent["He_So"]);
                        drCurrent["SO_LUONG_THUNG_KK"] = dbThungKk;
                        drCurrent["SO_LUONG_LE_KK"] = dbleKk;
                        drCurrent["SO_LUONG_KK"] = dbThungKk * IHe_So + dbleKk;
                        drCurrent["SO_LUONGTL_KK"] = getSlThungLe(Convert.ToInt32(drCurrent["SO_LUONG_KK"]), IHe_So);
                        drCurrent["TIEN_KK"] = Convert.ToInt32(drCurrent["SO_LUONG_KK"]) * Convert.ToInt32(drCurrent["GIA"]);
                        if (Convert.ToInt32(drCurrent["SO_LUONG_KK"]) == Convert.ToInt32(drCurrent["SO_LUONG"]))
                        {
                            drCurrent["SO_LUONG_CL"] = 0;
                            drCurrent["TIEN_CL"] = 0;
                        }
                        else
                        {
                            drCurrent["SO_LUONG_CL"] = Convert.ToInt32(drCurrent["SO_LUONG_KK"]) - Convert.ToInt32(drCurrent["SO_LUONG"]);
                            drCurrent["TIEN_CL"] = Convert.ToInt32(drCurrent["TIEN_KK"]) - Convert.ToInt32(drCurrent["TIEN"]);
                        }
                    }
                }
            }
        }

        private double getValue(string Ma_Vt, DataTable dtStock)
        {
            double ivalue = -1;
            foreach (DataRow dr in dtStock.Rows)
            {
                if (dr["Ma_Vt"].ToString() == Ma_Vt)
                {
                    if (dtStock.Columns.Contains("SO_LUONG_KK"))
                        return Convert.ToDouble(dr["SO_LUONG_KK"]);
                }
            }
            return ivalue;
        }
        private double getValueThung(string Ma_Vt, DataTable dtStock)
        {
            double ivalue = -1;
            foreach (DataRow dr in dtStock.Rows)
            {
                if (dr["Ma_Vt"].ToString() == Ma_Vt)
                {
                    if (dtStock.Columns.Contains("SO_LUONG_THUNG_KK"))
                        return Convert.ToDouble(dr["SO_LUONG_THUNG_KK"]);
                }
            }
            return ivalue;
        }
        private double getValueLe(string Ma_Vt, DataTable dtStock)
        {
            double ivalue = -1;
            foreach (DataRow dr in dtStock.Rows)
            {
                if (dr["Ma_Vt"].ToString() == Ma_Vt)
                {
                    if (dtStock.Columns.Contains("SO_LUONG_LE_KK"))
                        return Convert.ToDouble(dr["SO_LUONG_LE_KK"]);
                }
            }
            return ivalue;
        }
        public override void Load(enuEdit enuNew_Edit, DataRow drEdit, DataSet dsVoucher)
        {
            this.drEdit = drEdit;
            this.dsVoucher = dsVoucher;

            this.enuNew_Edit = enuNew_Edit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;

            this.strMa_Ct = ((string)drEdit["Ma_Ct"]).Trim();
            this.drDmCt = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", this.strMa_Ct);
            this.Object_ID = strMa_Ct;

            if (enuNew_Edit == enuEdit.New)
                this.strStt = Common.GetNewStt(strModule, true);
            else
                this.strStt = drEdit["Stt"].ToString();

            this.Build();
            this.FillData();
            this.Init_Ct();

            Common.ScaterMemvar(this, ref drEditPh);

            txtMa_Tte.bTextChange = false;
            numTy_Gia.bTextChange = false;

            this.Ma_Tte_Valid();
            this.BindingLanguage();
            this.LoadDicName();

            if (!isAccept)
                this.ShowDialog();
            else
                this.ActiveControl = txtMa_Ct;
        }
        public void Load(enuEdit enuNew_Edit, DataRow drEdit)
        {
            this.drEditPh = drEdit;

            this.enuNew_Edit = enuNew_Edit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;

            this.strMa_Ct = ((string)drEdit["Ma_Ct"]).Trim();
            this.drDmCt = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", this.strMa_Ct);
            this.Object_ID = strMa_Ct;

            if (enuNew_Edit == enuEdit.New)
                this.strStt = Common.GetNewStt(strModule, true);
            else
                this.strStt = drEdit["Stt"].ToString();

            this.Build();
            this.FillDataKK();
            this.Init_Ct();

            Common.ScaterMemvar(this, ref drEditPh);

            txtMa_Tte.bTextChange = false;
            numTy_Gia.bTextChange = false;

            this.Ma_Tte_Valid();
            this.BindingLanguage();
            this.LoadDicName();

            if (!isAccept)
                this.ShowDialog();
            else
                this.ActiveControl = txtMa_Ct;
        }
        #endregion

        #region Phuong thuc

        private void Build()
        {
            dgvEditCt1.bSortMode = false;
            //dgvEditCt1.strZone = "";
            dgvEditCt1.strZone = (string)drDmCt["Zone_EditCt1"];
            dgvEditCt1.BuildGridView();

            //dgvEditCt2.bSortMode = false;
            //dgvEditCt2.strZone = (string)drDmCt["Zone_EditCt2"];
            //dgvEditCt2.BuildGridView();

            //dgvEditCt2.Height = dgvEditCt1.Height;
            //dgvEditCt2.Width = dgvEditCt1.Width;
            //dgvEditCt2.Location = dgvEditCt1.Location;
            //dgvEditCt2.Anchor = dgvEditCt1.Anchor;
            //dgvEditCt2.Visible = false;
        }

        private void FillData()
        {
            string strKeyFillterCt = " Stt = '" + ((string)drEdit["Stt"]).Trim() + "' ";

            string strSelectPh = " *, 0 AS TTien, 0 AS TTien_KK ";
            string strSelectCt = enuNew_Edit == enuEdit.New ? " TOP 1 * " : "*";// enuNew_Edit == enuEdit.New lấy hàng đầu tiên

            dtEditPh = DataTool.SQLGetDataTable((string)drDmCt["Table_Ph"], strSelectPh, strKeyFillterCt, null);
            dtEditCt = DataTool.SQLGetDataTable((string)drDmCt["Table_Ct"], strSelectCt, strKeyFillterCt, null);

            //ThongLH: History
            dtEditCtOrg = dtEditCt.Copy();
            drEditPhOrg = drEdit;

            DataColumn dc = new DataColumn("Deleted", typeof(bool));
            dc.DefaultValue = false;
            dtEditCt.Columns.Add(dc);

            bdsEditCt.DataSource = dtEditCt;

            dgvEditCt1.DataSource = bdsEditCt;
            dgvEditCt1.ClearSelection();

            //dgvEditCt2.DataSource = bdsEditCt;
            //dgvEditCt2.ClearSelection();

            //dtEdiCt_LR
            string strSelectCtLR = enuNew_Edit == enuEdit.New ? " TOP 0 * " : " TOP 1 * ";// 
            dtEdiCt_KiemKe = DataTool.SQLGetDataTable("INLAPRAP", strSelectCtLR, strKeyFillterCt, null);
            if (dtEdiCt_KiemKe.Rows.Count == 0)
                dtEdiCt_KiemKe.Rows.Add(dtEdiCt_KiemKe.NewRow());

        }
        private void FillDataKK()
        {

            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            {
                Hashtable ht = new Hashtable();
                ht.Add("STT", drEditPh["Stt"].ToString());
                ht.Add("ISNEW", true);
                ht.Add("MA_DVCS", Element.sysMa_DvCs);
                //dtEditCt = SQLExec.ExecuteReturnDt("sp_IN_GetDataKiemKeByStt", ht, CommandType.StoredProcedure);
                dsVoucher = SQLExec.ExecuteReturnDs("sp_IN_GetDataKiemKeByStt", ht, CommandType.StoredProcedure);
                if (dsVoucher.Tables.Count == 2)
                {

                    dtEditPh = dsVoucher.Tables[0];
                    dtEditCt = dsVoucher.Tables[1];
                }

                if (!dtEditCt.Columns.Contains("Deleted"))
                {
                    DataColumn dc = new DataColumn("Deleted", typeof(bool));
                    dc.DefaultValue = false;
                    dtEditCt.Columns.Add(dc);
                }

                bdsEditCt.DataSource = dtEditCt;
                dgvEditCt1.DataSource = bdsEditCt;

                drEditPh["TTien"] = Common.SumDCValue(dtEditCt, "Tien", "");
                numTTien.Value = Common.SumDCValue(dtEditCt, "Tien", "");

            }
            else
            {

                Hashtable ht = new Hashtable();
                ht.Add("STT", drEditPh["Stt"].ToString());
                ht.Add("MA_DVCS", Element.sysMa_DvCs);
                dsVoucher = SQLExec.ExecuteReturnDs("sp_IN_GetDataKiemKeByStt", ht, CommandType.StoredProcedure);
                if (dsVoucher.Tables.Count == 2)
                {

                    dtEditPh = dsVoucher.Tables[0];
                    dtEditCt = dsVoucher.Tables[1];
                }
                if (!dtEditCt.Columns.Contains("Deleted"))
                {
                    DataColumn dc = new DataColumn("Deleted", typeof(bool));
                    dc.DefaultValue = false;
                    dtEditCt.Columns.Add(dc);
                }

                bdsEditCt.DataSource = dtEditCt;
                dgvEditCt1.DataSource = bdsEditCt;

                drEditPh["TTien"] = Common.SumDCValue(dtEditCt, "Tien", "");
                numTTien.Value = Common.SumDCValue(dtEditCt, "Tien", "");
            }

            this.BdsFilter();


        }
        private void Init_Ct()
        {
            txtMa_Tte.InputMask = (string)Systems.Librarys.Parameters.GetParaValue("MA_TTE_LIST");

            if (dtEditPh.Rows.Count == 0)
            {
                DataRow drCurrent = dtEditPh.NewRow();
                drCurrent["Ma_Ct"] = "KK";
                drCurrent["Ngay_Ct"] = Library.DateToStr(DateTime.Now);
                drCurrent["Stt"] = "0";
                drCurrent["Ma_Tte"] = Element.sysMa_Tte;
                drCurrent["Ty_Gia"] = 1;
                dtEditPh.Rows.Add(drCurrent);

            }
            if (dtEditCt.Rows.Count == 0)
                dtEditCt.Rows.Add(dtEditCt.NewRow());

            drEditPh = dtEditPh.Rows[0];
            drCurrent = dtEditCt.Rows[0];

            if (this.enuNew_Edit == enuEdit.New)
            {
                //Clear Content in drCurrent
                foreach (DataColumn dcEditCt in dtEditCt.Columns)
                    drCurrent[dcEditCt] = DBNull.Value;

                Common.SetDefaultDataRow(ref drEditPh);
                Common.SetDefaultDataRow(ref drCurrent);


                this.dteNgay_Ct.Text = Library.DateToStr(DateTime.Now);
                this.txtMa_Ct.Text = "KK";
                this.txtMa_Tte.Text = "VND";
                this.numTy_Gia.Value = 1;
            }

            //Voucher.Update_Header(this);
            //Voucher.Update_Stt(this, strModule);

            //BindingTTien                      
            if (isAccept)
            {
                numTTien.DataBindings.Clear();
                numTTien_Nt.DataBindings.Clear();
                numTSo_Luong.DataBindings.Clear();
            }

            numTTien.DataBindings.Add("Value", dtEditPh, "TTien");
            numTTien_Nt.DataBindings.Add("Value", dtEditPh, "TTien_KK");
            numTSo_Luong.DataBindings.Add("Value", dtEditPh, "TSo_Luong");


        }

        private void LoadDicName()
        {
            if (txtMa_Ct.Text.Trim() != string.Empty && drDmCt != null)
            {
                dicName.SetValue("Ten_Ct", (string)drDmCt["Ten_Ct"]);
            }
            //txtMa_Hd
            if (txtMa_Kho.Text.Trim() != string.Empty)
            {
                lbtMa_Kho.Text = DataTool.SQLGetNameByCode("LIKHO", "Ma_Kho", "Ten_Kho", txtMa_Kho.Text.Trim());
                dicName.SetValue(lbtMa_Kho.Name, lbtMa_Kho.Text);
            }
            else
                lbtMa_Kho.Text = string.Empty;

        }

        private bool FormCheckValid()
        {

            if (txtMa_Kho.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ma_KhoN") + " " +
                              Languages.GetLanguage("Not_Null"));

                return false;
            }


            return true;
        }
        private void TinhSoCtPXK()
        {
            if (this.enuNew_Edit != enuEdit.New)
                return;

            DateTime Ngay_Ct = Library.StrToDate(dteNgay_Ct.Text);
            string strStt = Common.GetNewStt("05", true);
            string strSo_Ct = txtMa_Ct.Text + "/" + txtMa_Kho.Text + "/" + dteNgay_Ct.Text.Replace("/", "");

            txtSo_Ct.Text = strSo_Ct;


            this.drEditPh["STT"] = strStt;
            this.drEditPh["Ngay_Ct"] = dteNgay_Ct.Text;
            this.drEditPh["Ma_Ct"] = txtMa_Ct.Text;
            this.drEditPh["Ma_Kho"] = txtMa_Kho.Text;
            this.drEditPh["So_Ct"] = txtMa_Ct.Text;
            if (dtEditCt == null)
                return;

            foreach (DataRow dr in dtEditCt.Rows)
            {
                dr["Stt"] = strStt;
                dr.AcceptChanges();
            }


            //drEdit.AcceptChanges();

        }
        public override bool Save()
        {
            //Common.GatherMemvar(this, ref this.drEditPh);
            //Voucher.Update_Detail(this);

            if (!FormCheckValid())
                return false;

            if (this.enuNew_Edit == enuEdit.New)
            {
                drEditPh["Create_Log"] = Common.GetCurrent_Log();
                drEditPh["LastModify_Log"] = string.Empty;
            }
            else
            {
                drEditPh["LastModify_Log"] = Common.GetCurrent_Log();
                if ((string)drEditPh["Create_Log"] == string.Empty)
                    drEditPh["Create_Log"] = drEditPh["LastModify_Log"];
            }

            //Voucher.Update_TTien(this);
            //Voucher.Update_Stt(this, strModule);

            //if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            //{
            //    if (dtEditCt.Rows.Count > 0) //Cập nhật lại dữ liệu từ chi tiết lên Header
            //        Common.CopyDataRow(dtEditCt.Rows[0], drEditPh, (string)drDmCt["Update_Header"]);

            //    drEdit = drEditPh;
            //}

            return this.Save_PKKDetail();
        }
        private bool Save_PKKDetail()
        {
            //Common.GatherMemvar(this, ref this.drEditPh);

            DataTable dtImport = SQLExec.ExecuteReturnDt("DECLARE @TVP_PXKDETAIL AS TVP_KIEMKEDETAIL SELECT * FROM @TVP_PXKDETAIL");

            foreach (DataRow drEdit in dtEditCt.Rows)
            {
                DataRow drNew = dtImport.NewRow();
                Common.CopyDataRow(drEdit, drNew);
                dtImport.Rows.Add(drNew);
            }


            if (!FormCheckValid())
                return false;

            if (enuNew_Edit == enuEdit.New)
                TinhSoCtPXK();

            //Luu xuong CSDL
            //if (!DataTool.SQLUpdate(enuNew_Edit, "OM_PXK", ref drEdit))
            //    return false;


            SqlCommand command = SQLExec.GetNewSQLConnection().CreateCommand();
            command.CommandText = "Sp_Update_KiemKeDetail";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Stt", this.strStt);
            command.Parameters.AddWithValue("@Ma_Kho", txtMa_Kho.Text);
            command.Parameters.AddWithValue("@Ma_Ct", txtMa_Ct.Text);
            command.Parameters.AddWithValue("@Create_Log", drEditPh["Create_Log"].ToString());
            command.Parameters.AddWithValue("@LastModify_Log", drEditPh["LastModify_Log"].ToString());
            command.Parameters.AddWithValue("@Ngay_Ct", Library.StrToDate(dteNgay_Ct.Text));
            command.Parameters.AddWithValue("@So_Ct", txtSo_Ct.Text);
            command.Parameters.AddWithValue("@IsStock", chkIsStock.Checked);
            command.Parameters.AddWithValue("@IS_UPDATE", enuNew_Edit == enuEdit.New ? "1" : "0");
            command.Parameters.AddWithValue("@UserId", Element.sysUser_Id);
            command.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);
            SqlParameter parameter = new SqlParameter
            {
                SqlDbType = SqlDbType.Structured,
                ParameterName = "@TVP_KKDETAIL",
                TypeName = "TVP_KIEMKEDETAIL",
                Value = dtImport,
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
                return false;
            }
            return true;
        }
        public DataTable dtEdiCtLR
        {
            get
            {
                //Lưu vào R05CTNLR đối với phiếu lắp ráp, R05CTXLR đối với phiếu tháo ráp							
                DataRow drEditCtLR = dtEdiCt_KiemKe.Rows[0];
                Common.CopyDataRow(this.dtEditCt.Rows[0], drEditCtLR);

                return dtEdiCt_KiemKe;
            }

        }

        private void Ma_Tte_Valid()
        {

        }
        private void BdsFilter()
        {
            bool Is_Stock = this.chkIsStock.Checked;

            if (Is_Stock)
                bdsEditCt.Filter = "So_Luong <> 0 OR Tien <> 0 ";
            else
                bdsEditCt.Filter = null;
        }
        private bool CellKeyEnter()
        {//Ham thuc hien phim Enter: true: thuc hien thanh cong, false: khong thuc hien duoc

            if (dgvEditCt1.CurrentCell == null)
                return false;

            DataGridViewCell dgvCell = dgvEditCt1.CurrentCell;
            string strCurrentColumn = dgvCell.OwningColumn.Name.ToUpper();

            DataGridViewColumn dgvcCurrent = dgvCell.OwningColumn;
            DataGridViewRow dgvrCurrent = dgvCell.OwningRow;

            int iCurrentColumn = dgvcCurrent.DisplayIndex;
            int iCurrentRow = dgvrCurrent.Index;
            int iNextColumn = 0;
            int iNextRow = iCurrentRow;

            if (Common.Inlist(strCurrentColumn, "SO_LUONG_LE_KK"))
            {
                bool bIsCurrentLastRow = dgvEditCt1.bIsCurrentLastRow;
                if (bIsCurrentLastRow)
                {
                    return false;
                }
                else
                {
                    //dgvEditCt1.MultiSelect = false;
                    //dgvEditCt1.FocusNextFirstCell();
                    dgvEditCt1.ClearSelection();
                    dgvEditCt1.Rows[iCurrentRow + 1].Cells["SO_LUONG_THUNG_KK"].Selected = true;
                    dgvEditCt1.BeginEdit(true);
                    return true;
                }
            }



            #region Enter tai Ten_Vt
            if (Common.Inlist(strCurrentColumn, "TEN_VT"))
            {
                drCurrent = ((DataRowView)bdsEditCt.Current).Row;

                if (drCurrent["Ma_Vt"] == DBNull.Value || (string)drCurrent["Ma_Vt"] == string.Empty)
                {
                    bool bIsCurrentLastRow = dgvEditCt1.bIsCurrentLastRow;

                    bdsEditCt.RemoveCurrent();
                    dtEditCt.AcceptChanges();

                    if (bIsCurrentLastRow)
                        this.SelectNextControl(dgvEditCt1, true, true, true, true);

                    return true;
                }

                return false;
            }
            #endregion

            #region Enter tai TIEN_NT9
            if (Common.Inlist(strCurrentColumn, "TIEN_NT9"))
            {
                if (txtMa_Tte.Text.Trim() == Element.sysMa_Tte)
                {
                    // Cap nhat tien TIEN_NT9 truoc khi xuong dong
                    double dbTien_Nt9 = 0;
                    if (double.TryParse(dgvEditCt1.CurrentCell.FormattedValue.ToString().Trim(), out dbTien_Nt9))
                    {
                        dgvEditCt1.CancelEdit();
                        drCurrent = ((DataRowView)bdsEditCt.Current).Row;
                        drCurrent["TIEN_NT9"] = dbTien_Nt9;
                        Voucher.Calc_So_Luong(drCurrent);
                        Voucher.Update_TTien(this);
                    }

                    if (dgvEditCt1.bIsCurrentLastRow)
                    {
                        if (!Voucher.AddRow(this))
                            this.SelectNextControl(dgvEditCt1, true, true, true, true);
                        else
                        {
                            dgvEditCt1.FocusNextFirstCell();
                            return true;
                        }
                    }
                    else
                        dgvEditCt1.FocusNextFirstCell();
                }
                return false;
            }

            #endregion

            #region Enter TIEN
            if (Common.Inlist(strCurrentColumn, "TIEN"))
            {
                // Cap nhat tien TIEN truoc khi xuong dong
                double dbTien = 0;
                if (double.TryParse(dgvEditCt1.CurrentCell.FormattedValue.ToString().Trim(), out dbTien))
                {
                    dgvEditCt1.CancelEdit();
                    drCurrent = ((DataRowView)bdsEditCt.Current).Row;
                    drCurrent["TIEN"] = dbTien;
                    Voucher.Calc_So_Luong(drCurrent);
                    Voucher.Update_TTien(this);
                }

                if (dgvEditCt1.bIsCurrentLastRow)
                {
                    if (!Voucher.AddRow(this))
                        return false;
                    else
                        dgvEditCt1.FocusNextFirstCell();

                    return true;
                }

                return false;
            }
            #endregion

            return false;
        }

        #endregion

        #region Su kien

        #region FormEvent

        void txtMa_Ct_Enter(object sender, EventArgs e)
        {
            string strCreate_Log = Common.Show_Log((string)drEditPh["Create_Log"]);
            string strLastModify_Log = Common.Show_Log((string)drEditPh["LastModify_Log"]);
            string strLog = string.Empty;
            strLog += strCreate_Log != string.Empty ? "; Create: " + strCreate_Log : "";
            strLog += strLastModify_Log != string.Empty ? "; Last Modify: " + strLastModify_Log : "";

            this.ucNotice.SetText(txtMa_Ct.Text, dicName.GetValue("Ten_Ct") + strLog);
        }
        void txtMa_Ct_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Ct.Text.Trim();
            bool bRequire = true;
            string strKey = "(Table_Ct = '" + (string)drDmCt["Table_Ct"] + "')";

            frmQuickLookup frmLookup = new frmQuickLookup("SYSDMCT", "DMCT");
            DataRow drLookup = Lookup.ShowLookup(frmLookup, "SYSDMCT", "Ma_Ct", strValue, bRequire, strKey);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
                txtMa_Ct.Text = string.Empty;
            else
            {
                txtMa_Ct.Text = drLookup["Ma_Ct"].ToString();

                dicName.SetValue("Ten_Ct", drLookup["Ten_Ct"].ToString());
            }
        }
        void txtMa_Ct_TextChanged(object sender, EventArgs e)
        {
            this.drDmCt = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", this.strMa_Ct);
        }

        void linkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string currentDir = Environment.CurrentDirectory;
            System.Diagnostics.Process.Start(currentDir + @"\Help\" + drDmCt["Help_File"]);
        }

        void txtSo_Ct_Validating(object sender, CancelEventArgs e)
        {
            if (txtSo_Ct.Text == string.Empty)
                return;

            string strTablePh = (string)drDmCt["Table_Ph"];
            string strMa_Ct = txtMa_Ct.Text;
            string strSo_Ct = txtSo_Ct.Text;

            DateTime dNgay_Ct = Library.StrToDate(dteNgay_Ct.Text);

            string strSQLExec = "SELECT COUNT(Stt) FROM " + strTablePh + " WHERE Stt <> @Stt AND So_Ct = @So_Ct AND MONTH(Ngay_Ct) = MONTH(@Ngay_Ct) AND YEAR(Ngay_Ct) = @Nam AND Ma_Ct = @Ma_Ct AND Ma_DvCs = @Ma_DvCs";

            Hashtable ht = new Hashtable();
            ht.Add("MA_CT", strMa_Ct);
            ht.Add("SO_CT", strSo_Ct);
            ht.Add("NGAY_CT", dNgay_Ct);
            ht.Add("NAM", dNgay_Ct.Year);
            ht.Add("STT", drEditPh["Stt"]);
            ht.Add("MA_DVCS", Element.sysMa_DvCs);

            if (Convert.ToInt32(SQLExec.ExecuteReturnValue(strSQLExec, ht, CommandType.Text)) > 0)
            {
                if (!Common.MsgYes_No("Chứng từ số: " + txtSo_Ct.Text + " Ngày: " + dteNgay_Ct.Text + " đã tồn tại.\n Bạn có muốn tiếp tục không ?"))
                    e.Cancel = true;
            }
        }

        void dteNgay_Ct_Validating(object sender, CancelEventArgs e)
        {
            Common.GatherMemvar(this, ref drEditPh);
        }
        void txtMa_Tte_Validating(object sender, CancelEventArgs e)
        {
            this.Ma_Tte_Valid();
        }
        void numTy_Gia_Leave(object sender, EventArgs e)
        {
            this.Ma_Tte_Valid();
        }

        //void txtMa_Dt_Enter(object sender, EventArgs e)
        //{
        //    txtTen_Dt.Text = dicName.GetValue(txtTen_Dt.Name);
        //}
        void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
            Common.ResetTextChange(this);

            string strValue = txtMa_Dt.Text.Trim();
            bool bRequire = true;

            //frmDoiTuong frmLookup = new frmDoiTuong();
            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt.Text = string.Empty;
                txtTen_Dt.Text = string.Empty;
            }
            else
            {
                txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
                //txtTen_Dt.Text = drLookup["Ten_Dt"].ToString();

                if (txtMa_Dt.bTextChange)
                {
                    txtTen_Dt.Text = drLookup["Ten_Dt"].ToString();
                    txtOng_Ba.Text = drLookup["Ong_Ba"].ToString() == string.Empty ? drLookup["Ten_Dt"].ToString() : drLookup["Ong_Ba"].ToString();
                    txtDia_Chi.Text = drLookup["Dia_Chi"].ToString();
                }
            }

            //dicName[txtTen_Dt.Name] = txtTen_Dt.Text;

            Voucher.Update_Detail(this, "Ma_Dt");

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        void txtMa_Hd_Enter(object sender, EventArgs e)
        {
            txtTen_Hd.Text = dicName.GetValue(txtTen_Hd.Name);
        }
        void txtMa_Hd_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Hd.Text.Trim();
            bool bRequire = false;

            //frmHopDong frmLookup = new frmHopDong();
            DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Hd.Text = string.Empty;
                txtTen_Hd.Text = string.Empty;
            }
            else
            {
                txtMa_Hd.Text = drLookup["Ma_Hd"].ToString();
                txtTen_Hd.Text = drLookup["Ten_Hd"].ToString();

                if (txtMa_Hd.bTextChange)
                {
                    txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
                    DataRow drDmDt = DataTool.SQLGetDataRowByID("LIDOITUONG", "Ma_Dt", (string)drLookup["Ma_Dt"]);
                    if (drDmDt != null)
                    {
                        txtTen_Dt.Text = (string)drDmDt["Ten_Dt"];
                        if ((string)drDmDt["Ong_Ba"] != string.Empty)
                            txtOng_Ba.Text = (string)drDmDt["Ong_Ba"];
                        else
                            txtOng_Ba.Text = (string)drDmDt["Ten_Dt"];
                        txtDia_Chi.Text = (string)drDmDt["Dia_Chi"];
                    }
                }
            }

            dicName.SetValue(txtTen_Hd.Name, txtTen_Hd.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }


        void txtMa_KhoN_Enter(object sender, EventArgs e)
        {
            ucNotice.SetText(txtMa_Kho.Text, dicName.GetValue("Ten_KhoN"));
        }
        void txtMa_KhoN_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Kho.Text.Trim();
            bool bRequire = false;

            //frmKho frmLookup = new frmKho();
            DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Kho.Text = string.Empty;
                dicName.SetValue("Ten_KhoN", string.Empty);
            }
            else
            {
                txtMa_Kho.Text = drLookup["Ma_Kho"].ToString();
                dicName.SetValue("Ten_KhoN", drLookup["Ten_Kho"].ToString());
            }

            ucNotice.SetText(txtMa_Kho.Text, dicName.GetValue("Ten_Kho"));

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        void frmEditCtTien_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F8:
                    Voucher.DeleteRow(this, dgvEditCt1);
                    break;

                case Keys.F4:

                    //if (tabVoucher.SelectedTab == tpChiTiet1)
                    //                   tabVoucher.SelectedTab = tpChiTiet2;
                    //else
                    //                   tabVoucher.SelectedTab = tpChiTiet1;
                    break;

                case Keys.Up:
                    if (this.dgvEditCt1.Focused && this.dgvEditCt1.bIsCurrentFirstRow)
                        this.SelectNextControl(dgvEditCt1, false, true, true, true);
                    break;
            }

            if (!this.dgvEditCt1.Focused)
                this.dgvEditCt1.ClearSelection();
        }


        void tabVoucher_Enter(object sender, EventArgs e)
        {

            if (bDgvEditCtFocusing)
                this.dgvEditCt1.Focus();
            //if (tabVoucher.SelectedTab == tpChiTiet1)
            //         {
            //             if (bDgvEditCtFocusing)
            //                 this.dgvEditCt1.Focus();
            //         }
            //         else if (tabVoucher.SelectedTab == tpChiTiet2)
            //         {
            //             if (bDgvEditCtFocusing)
            //                 this.dgvEditCt2.Focus();
            //         }
        }

        void tabVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectNextControl(tabVoucher, true, true, true, true);
        }

        #endregion

        #region DataGridViewEvent

        void dgvEditCt_CellEnter(object sender, DataGridViewCellEventArgs e)
        {//Xu ly hien Notice

            dgvVoucher dgvEditCt = (dgvVoucher)sender;

            if (dgvEditCt.CurrentCell == null)
                return;

            if (this.ActiveControl != dgvEditCt)
                return;

            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();


            if (!Common.Inlist(strColumnName, "SO_LUONG_KK,SO_LUONG_THUNG_KK,SO_LUONG_LE_KK,SUA_KK"))
            {
                dgvCell.ReadOnly = true;
            }


            if (strColumnName == "TK_NO")
                this.strTk_NoTmp = dgvCell.FormattedValue.ToString();

            else if (strColumnName == "TK_CO")
                this.strTk_CoTmp = dgvCell.FormattedValue.ToString();

            if (Common.Inlist(strColumnName, "MA_VT,MA_KHO"))
            {
                if ((string)drCurrent["Ma_Vt"] != string.Empty)
                    ucNotice.Text = Voucher.GetTonCuoi(drCurrent);

                dicName.SetValue("TON_CUOI", ucNotice.Text);
            }
            else if (Common.Inlist(strColumnName, "TEN_VT,DVT"))
            {
                ucNotice.Text = dicName.GetValue("TON_CUOI");
            }
            else if (dgvCell.Tag != null)
                ucNotice.Text = (string)dgvCell.Tag;
        }

        void dgvEditCt_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {//Cai dat Lookup

            dgvVoucher dgvEditCt = (dgvVoucher)sender;
            //Xu ly phim Enter
            if (dgvEditCt.kLastKey == Keys.Enter)
            {
                dgvEditCt.kLastKey = Keys.None;

                if (this.CellKeyEnter())
                    e.Cancel = true;
            }

            //Xu ly Lookup
            if (this.ActiveControl == null)
                return;

            if (this.ActiveControl == dgvEditCt || this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
            {
                drCurrent = ((DataRowView)bdsEditCt.Current).Row;
                DataGridViewCell dgvCell = dgvEditCt.CurrentCell;
                string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

                bool bLookup = true;

                if (Common.Inlist(strColumnName, "TK_NO,TK_CO"))
                    bLookup = dgvLookupTk(ref dgvCell, strColumnName);

                //else if (strColumnName == "MA_DT")
                //    bLookup = dgvLookupMa_Dt(ref dgvCell);

                //else if (strColumnName == "MA_BP")
                //    bLookup = dgvLookupMa_Bp(ref dgvCell);

                //else if (strColumnName == "MA_KM")
                //    bLookup = dgvLookupMa_Km(ref dgvCell);

                //else if (strColumnName == "MA_SP")
                //    bLookup = dgvLookupMa_Sp(ref dgvCell);

                //else if (strColumnName == "MA_JOB")
                //    bLookup = dgvLookupMa_Job(ref dgvCell);

                //else if (strColumnName == "MA_VT")
                //bLookup = dgvLookupMa_Vt(ref dgvCell);

                //else if (strColumnName == "MA_KHO")
                //bLookup = dgvLookupMa_Kho(ref dgvCell);

                if (bLookup == false)
                    e.Cancel = true;
            }
            else
                dgvEditCt.CancelEdit();
        }

        void dgvEditCt_CellValidated(object sender, DataGridViewCellEventArgs e)
        {//Cai dat cac ham tinh toan

            dgvVoucher dgvEditCt = (dgvVoucher)sender;
            if (this.ActiveControl != dgvEditCt && this.ActiveControl != null && this.ActiveControl.GetType().Name != "DataGridViewTextBoxEditingControl")
                return;

            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (Common.Inlist(strColumnName, "SO_LUONG_THUNG_KK,SO_LUONG_LE_KK"))
            {
                //Kiểm tra tồn kho
                int IHe_So = Convert.ToInt32(drCurrent["He_So"]);
                drCurrent["SO_LUONG_KK"] = Convert.ToInt32(drCurrent["SO_LUONG_THUNG_KK"]) * IHe_So + Convert.ToInt32(drCurrent["SO_LUONG_LE_KK"]);
                drCurrent["SO_LUONGTL_KK"] = getSlThungLe(Convert.ToInt32(drCurrent["SO_LUONG_KK"]), IHe_So);
                drCurrent["TIEN_KK"] = Convert.ToInt32(drCurrent["SO_LUONG_KK"]) * Convert.ToInt32(drCurrent["GIA"]);
                if (Convert.ToInt32(drCurrent["SO_LUONG_KK"]) == Convert.ToInt32(drCurrent["SO_LUONG"]))
                {
                    drCurrent["SO_LUONG_CL"] = 0;
                    drCurrent["TIEN_CL"] = 0;
                }
                else
                {
                    drCurrent["SO_LUONG_CL"] = Convert.ToInt32(drCurrent["SO_LUONG_KK"]) - Convert.ToInt32(drCurrent["SO_LUONG"]);
                    drCurrent["TIEN_CL"] = Convert.ToInt32(drCurrent["TIEN_KK"]) - Convert.ToInt32(drCurrent["TIEN"]);
                }
            }
            else if (Common.Inlist(strColumnName, "SUA_KK"))
            {
                //Kiểm tra tồn kho
                //drCurrent["SUA_KK"] = !Convert.ToBoolean(drCurrent["SUA_KK"]);
                drCurrent.AcceptChanges();
            }

            bdsEditCt.EndEdit();//Cap nhat lai DataSource
        }

        private string getSlThungLe(int Soluong, int he_so)
        {


            if (he_so == 0)
            {
                return "0/" + Soluong.ToString();
            }
            else
            {
                return ((Soluong - (Soluong % he_so)) / he_so).ToString() + "/" + (Soluong % he_so).ToString();

            }
            return string.Empty;
        }

        void dgvEditCt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                if (dgvEditCt1.CurrentCell.OwningColumn.DataPropertyName == "DVT")
                {
                    drCurrent = ((DataRowView)bdsEditCt.Current).Row;
                    string strMa_Vt = (string)drCurrent["Ma_Vt"];
                    string strDvt_Old = (string)drCurrent["Dvt"];
                    string strDvt_Chuan = string.Empty;

                    DataRow drDmVt = DataTool.SQLGetDataRowByID("LIVATTU", "Ma_Vt", strMa_Vt);
                    strDvt_Chuan = (string)drDmVt["Dvt"];

                    string inputMask = (string)drDmVt["Dvt"];

                    for (int i = 1; i <= 3; i++)
                        inputMask += (string)drDmVt["Dvt" + i] == string.Empty ? string.Empty : "," + (string)drDmVt["Dvt" + i];

                    if (inputMask != string.Empty)
                        inputMask += "," + inputMask;
                    if (inputMask == null || inputMask == string.Empty)
                        return;

                    string[] strArrInputMask = inputMask.Split(',');
                    for (int i = 0; i <= strArrInputMask.Length - 1; i++)
                        if (strArrInputMask[i] == strDvt_Old)
                        {
                            drCurrent["Dvt"] = strArrInputMask[i + 1];
                            break;
                        }

                    if ((string)drCurrent["Dvt"] == strDvt_Chuan)
                        drCurrent["He_So9"] = 1;
                    else
                        for (int i = 1; i <= 3; i++)
                            if ((string)drDmVt["Dvt" + i] == (string)drCurrent["Dvt"])
                                drCurrent["He_So9"] = drDmVt["He_So" + i];

                    Voucher.Calc_So_Luong(drCurrent);
                }
        }

        void dgvEditCt2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {// Hien notice khi Gotfocus

        }

        void dgvEditCt2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        { //Xu ly phim Enter, Lookup danh muc

        }

        void dgvEditCt2_CellValidated(object sender, DataGridViewCellEventArgs e)
        {// Tinh toan cac Gia tri, cong thuc

        }

        #endregion

        #region DataGridViewLookup
        private bool dgvLookupTk(ref DataGridViewCell dgvCell, string strColumnName)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = true;

            if (strColumnName == "TK_NO5" || strColumnName == "TK_CO5")
            {
                if (drCurrent["TIEN5"] == DBNull.Value || Convert.ToDouble(drCurrent["TIEN5"]) == 0)
                    bRequire = false;
            }
            else
            {
                if (strColumnName == "TK_NO6" || strColumnName == "TK_CO6")
                    if (drCurrent["TIEN6"] == DBNull.Value || Convert.ToDouble(drCurrent["TIEN6"]) == 0)
                        bRequire = false;
            }

            //frmTaiKhoan frmLookup = new frmTaiKhoan();
            DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvEditCt1.CancelEdit();
                dgvCell.Value = drLookup["Tk"].ToString();
                dgvCell.Tag = drLookup["Ten_Tk"].ToString();
            }

            return true;
        }

        private bool dgvLookupMa_Dt(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = true;

            //frmDoiTuong frmLookup = new frmDoiTuong();
            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvEditCt1.CancelEdit();
                dgvCell.Value = drLookup["Ma_Dt"].ToString();
                dgvCell.Tag = drLookup["Ten_Dt"].ToString();
            }
            return true;
        }

        private bool dgvLookupMa_Bp(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;

            //frmBoPhan frmLookup = new frmBoPhan();
            DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvEditCt1.CancelEdit();
                dgvCell.Value = drLookup["Ma_Bp"].ToString();
                dgvCell.Tag = drLookup["Ten_Bp"].ToString();
            }

            return true;
        }

        private bool dgvLookupMa_Km(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;
            object objReturn = null;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            string strTk_No = (string)drCurrent["Tk_No"];
            string strTk_Co = (string)drCurrent["Tk_Co"];

            objReturn = SQLExec.ExecuteReturnValue("SELECT Tk_Km FROM LITAIKHOAN WHERE Tk = '" + strTk_No + "'");
            if (objReturn != null && objReturn != DBNull.Value && (bool)objReturn)
                bRequire = true;
            else
            {
                objReturn = SQLExec.ExecuteReturnValue("SELECT Tk_Km FROM LITAIKHOAN WHERE Tk = '" + strTk_Co + "'");
                if (objReturn != null && objReturn != DBNull.Value && (bool)objReturn)
                    bRequire = true;
            }

            //frmKhoanMuc frmLookup = new frmKhoanMuc();
            DataRow drLookup = Lookup.ShowLookup("Ma_Km", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvEditCt1.CancelEdit();
                dgvCell.Value = drLookup["Ma_Km"].ToString();
                dgvCell.Tag = drLookup["Ten_Km"].ToString();
            }
            return true;
        }

        private bool dgvLookupMa_Sp(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;
            object objReturn = null;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            string strTk_No = (string)drCurrent["Tk_No"];
            string strTk_Co = (string)drCurrent["Tk_Co"];

            objReturn = SQLExec.ExecuteReturnValue("SELECT Tk_Sp FROM LITAIKHOAN WHERE Tk = '" + strTk_No + "'");
            if (objReturn != null && objReturn != DBNull.Value && (bool)objReturn)
                bRequire = true;
            else
            {
                objReturn = SQLExec.ExecuteReturnValue("SELECT Tk_Sp FROM LITAIKHOAN WHERE Tk = '" + strTk_Co + "'");
                if (objReturn != null && objReturn != DBNull.Value && (bool)objReturn)
                    bRequire = true;
            }


            //frmSanPham frmLookup = new frmSanPham();
            DataRow drLookup = Lookup.ShowLookup("Ma_Sp", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvEditCt1.CancelEdit();
                dgvCell.Value = drLookup["Ma_Sp"].ToString();
                dgvCell.Tag = drLookup["Ten_Sp"].ToString();
            }
            return true;
        }

        private bool dgvLookupMa_Job(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = true;

            //frmTacVu frmLookup = new frmTacVu();
            DataRow drLookup = Lookup.ShowLookup("Ma_Job", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvEditCt1.CancelEdit();
                dgvCell.Value = drLookup["Ma_Job"].ToString();
                dgvCell.Tag = drLookup["Ten_Job"].ToString();
            }
            return true;
        }

        private bool dgvLookupMa_Vt(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;

            //frmVatTu frmLookup = new frmVatTu();
            DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                drCurrent = ((DataRowView)bdsEditCt.Current).Row;

                string strMa_Vt_Old = string.Empty;

                if (drCurrent.HasVersion(DataRowVersion.Original))
                    strMa_Vt_Old = drCurrent["Ma_Vt", DataRowVersion.Original] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt", DataRowVersion.Original];
                else
                    strMa_Vt_Old = drCurrent["Ma_Vt"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt"];

                string strMa_Vt = (string)drLookup["Ma_Vt"];

                dgvEditCt1.CancelEdit();
                dgvCell.Value = drLookup["Ma_Vt"].ToString();
                dgvCell.Tag = drLookup["Ten_Vt"].ToString();

                //La vat tu dich vu                
                if ((string)drLookup["Loai_Vt"] == "0")
                {
                    drCurrent["Dvt"] = drLookup["Dvt"];
                }
                else
                {
                    drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];

                    if (strMa_Vt != strMa_Vt_Old)
                    {
                        drCurrent["Dvt"] = drLookup["Dvt"];
                        drCurrent["He_So9"] = 1;
                        Voucher.Calc_So_Luong(drCurrent);

                        if (strMa_Ct == "LR")// Phieu lap rap
                            drCurrent["Tk_Co"] = drLookup["Tk_Vt"];
                        else// Phieu thao rap
                            drCurrent["Tk_No"] = drLookup["Tk_Vt"];

                    }
                    else
                    {
                        if (drCurrent["Dvt"] == DBNull.Value || (string)drCurrent["Dvt"] == string.Empty)
                            drCurrent["Dvt"] = drLookup["Dvt"];
                        if (strMa_Ct == "LR")//LR						
                        {
                            if (drCurrent["Tk_Co"] == DBNull.Value || (string)drCurrent["Tk_Co"] == string.Empty)
                                drCurrent["Tk_Co"] = drLookup["Tk_Vt"];
                        }
                        else//TR
                        {
                            if (drCurrent["Tk_No"] == DBNull.Value || (string)drCurrent["Tk_No"] == string.Empty)
                                drCurrent["Tk_No"] = drLookup["Tk_Vt"];
                        }

                    }
                }
            }
            return true;
        }

        private bool dgvLookupMa_Kho(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;

            //frmKho frmLookup = new frmKho();
            DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvEditCt1.CancelEdit();
                dgvCell.Value = drLookup["Ma_Kho"].ToString();
                dgvCell.Tag = drLookup["Ten_Kho"].ToString();
            }
            return true;
        }

        #endregion

        #endregion

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.dgvEditCt1.ClearSelection(); //Chi co tac dung sau khi show form

            if (Convert.ToBoolean(drEditPh["XU_LY"]))
            {
                btGetDataStock.Enabled = false;
            }


            if (this.enuNew_Edit == enuEdit.Edit)
            {
                if (!Common.CheckDataLocked((DateTime)drEditPh["Ngay_Ct"]))
                {
                    this.dteNgay_Ct.Enabled = false;
                    this.btgAccept.btAccept.Enabled = false;
                }

                if (!Element.sysIs_Admin)
                {
                    string strCreate_User = (string)drEditPh["Create_Log"];

                    if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
                    {
                        string strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM SYSMEMBER WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";

                        if (!strUser_Allow.Contains("*,")) //Được phép sửa tất cả
                        {
                            if (!strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
                            {
                                this.btgAccept.btAccept.Enabled = false;
                                return;
                            }
                        }
                    }
                }
            }
        }

    }
}