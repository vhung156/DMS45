using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//Epoint
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;
using Epoint.Lists;
using System.Data.Odbc;

namespace Epoint.Modules.AR
{
    public partial class frmCtHD_Edit : frmVoucher_Edit
    {
        #region Declare
        private string strTk_NoTmp = string.Empty;
        private string strTk_CoTmp = string.Empty;
        private string strModule = "04";
        private bool bMa_Vt_Changed = false;
        private bool bMa_Thue_Changed = false;
        private string strMa_Vt_List;
        private DataTable dtImportZ;
        #endregion

        #region Contructor

        public frmCtHD_Edit()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(frmEditCtTien_KeyDown);

            this.btHanTt.Click += new EventHandler(btHanTt_Click);

            btInherit.Click += new EventHandler(btInherit_Click);
            linkHelp.LinkClicked += new LinkLabelLinkClickedEventHandler(linkHelp_LinkClicked);

            this.btImportExcel.Click += new EventHandler(btnImportExcel_Click);

            tabVoucher.SelectedIndexChanged += new EventHandler(tabVoucher_SelectedIndexChanged);
            tabVoucher.Enter += new EventHandler(tabVoucher_Enter);

            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);

            txtMa_Hd.Enter += new EventHandler(txtMa_Hd_Enter);
            txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);

            txtMa_Ct.Enter += new EventHandler(txtMa_Ct_Enter);
            txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
            txtMa_Ct.TextChanged += new EventHandler(txtMa_Ct_TextChanged);
            txtMa_CbNV.Validating += new CancelEventHandler(txtMa_CbNV_BH_Validating);
            txtSo_Ct.Validating += new CancelEventHandler(txtSo_Ct_Validating);            

            dteNgay_Ct.Validating += new CancelEventHandler(dteNgay_Ct_Validating);

            txtMa_Tte.Validating += new CancelEventHandler(txtMa_Tte_Validating);
            numTy_Gia.Leave += new EventHandler(numTy_Gia_Leave);

            txtMa_Thue.Enter += new EventHandler(txtMa_Thue_Enter);
            txtMa_Thue.Validating += new CancelEventHandler(txtMa_Thue_Validating);

            txtMa_So_Thue.Validating += new CancelEventHandler(txtMa_So_Thue_Validating);

            txtTk_No3.Enter += new EventHandler(txtTk_No3_Enter);
            txtTk_No3.Validating += new CancelEventHandler(txtTk_No3_Validating);

            txtTk_Co3.Enter += new EventHandler(txtTk_Co3_Enter);
            txtTk_Co3.Validating += new CancelEventHandler(txtTk_Co3_Validating);
                        
            numChiet_Khau.Validating += new CancelEventHandler(numChiet_Khau_Validating);

            numTTien.Validated += new EventHandler(numTTien_Validated);
            numTTien_Nt.Validated += new EventHandler(numTTien_Nt_Validated);
            numTTien3.Validated += new EventHandler(numTTien3_Validated);
            numTTien_Nt3.Validated += new EventHandler(numTTien_Nt3_Validated);
            numTTien4.Validated += new EventHandler(numTTien4_Validated);
            numTTien_Nt4.Validated += new EventHandler(numTTien_Nt4_Validated);            

            dgvEditCt1.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt_CellValidating);
            dgvEditCt1.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
            dgvEditCt1.CellEnter += new DataGridViewCellEventHandler(dgvEditCt_CellEnter);
            dgvEditCt1.CellValueChanged += new DataGridViewCellEventHandler(dgvEditCt1_CellValueChanged);
            dgvEditCt1.KeyDown += new KeyEventHandler(dgvEditCt_KeyDown);

            dgvEditCt2.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt2_CellValidating);
            dgvEditCt2.CellValidated += new DataGridViewCellEventHandler(dgvEditCt2_CellValidated);
            dgvEditCt2.CellEnter += new DataGridViewCellEventHandler(dgvEditCt_CellEnter);
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

            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
                this.strStt = Common.GetNewStt(strModule, true);
            else
                this.strStt = drEdit["Stt"].ToString();
                        
            this.Build();
            this.FillData();
            this.Init_Ct();

            Common.ScaterMemvar(this, ref drEditPh);

            txtMa_Tte.bTextChange = false;
            numTy_Gia.bTextChange = false;
            txtMa_So_Thue.bTextChange = false;

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
            dgvEditCt1.strZone = (string)drDmCt["Zone_EditCt1"];
            dgvEditCt1.BuildGridView();

            dgvEditCt2.bSortMode = false;
            dgvEditCt2.strZone = (string)drDmCt["Zone_EditCt2"];
            dgvEditCt2.BuildGridView();

            dgvEditCt2.Size = dgvEditCt1.Size;
            dgvEditCt2.Location = dgvEditCt1.Location;
            dgvEditCt2.Anchor = dgvEditCt1.Anchor;
            //dgvEditCt2.Visible = false;
            dgvEditCt2.TabIndex = dgvEditCt1.TabIndex;

            if (dgvEditCt2.Columns.Contains("So_Luong"))
                dgvEditCt2.Columns["So_Luong"].ReadOnly = true;
            //string strMa_Ct_Access = SQLExec.ExecuteReturnValue("SELECT Ma_Ct_Access FROM SYSMEMBER WHERE Member_ID = '" + Element.sysUser_Id + "' AND MEMBER_TYPE = 'U'").ToString();
            //if (!Element.sysIs_Admin)
            //    if (Common.Inlist(strMa_Ct, strMa_Ct_Access))
            //    {
            //        if (!Common.CheckPermission("ACCESS_PRICE", enuPermission_Type.Allow_Access))
            //        {
            //            if (dgvEditCt1.Columns.Contains("TIEN"))
            //                dgvEditCt1.Columns["TIEN"].Visible = false;

            //            dgvEditCt1.Columns["GIA_NT9"].Visible = false;
            //            dgvEditCt1.Columns["TIEN_NT9"].Visible = false;
            //        }
            //    }
        }

        private void FillData()
        {
            string strKeyFillterCt = " Stt = '" + ((string)drEdit["Stt"]).Trim() + "' ";

            string strSelectPh = " *, TTien0 + TTien3 AS TTien, TTien_Nt0 + TTien_Nt3 AS TTien_Nt ";
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

            dgvEditCt2.DataSource = bdsEditCt;
            dgvEditCt2.ClearSelection();
        }

        private void Init_Ct()
        {            
            txtMa_Tte.InputMask = (string)Systems.Librarys.Parameters.GetParaValue("MA_TTE_LIST");

            if (dtEditPh.Rows.Count == 0)
                dtEditPh.Rows.Add(dtEditPh.NewRow());

            if (dtEditCt.Rows.Count == 0)
                dtEditCt.Rows.Add(dtEditCt.NewRow());

            drEditPh = dtEditPh.Rows[0];
            drCurrent = dtEditCt.Rows[0];

            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    //Clear Content in drCurrent
                    foreach (DataColumn dcEditCt in dtEditCt.Columns)
                        drCurrent[dcEditCt] = DBNull.Value;

                    Common.SetDefaultDataRow(ref drEditPh);
                    Common.SetDefaultDataRow(ref drCurrent);

                    //Ngầm định 1 số thông tin từ chứng từ cũ
                    if (drEdit != null)
                        Common.CopyDataRow(drEdit, drCurrent, (string)drDmCt["Carry_Header"]);

                    drCurrent["Ma_DvCs"] = Element.sysMa_DvCs;
                    drCurrent["Stt"] = strStt;
                    drCurrent["Stt0"] = 1;
                    drCurrent["Ma_Ct"] = strMa_Ct;
                    drCurrent["Ngay_Ct"] = ((string)Epoint.Systems.Librarys.Parameters.GetParaValue("NGAY_CT") == "0" && drEdit["Ngay_Ct"] != DBNull.Value) ? drEdit["Ngay_Ct"] : DateTime.Now;

                    drCurrent["Tk_No2"] = (string)drDmCt["Tk_No"];
                    drCurrent["Tk_Co2"] = (string)drDmCt["Tk_Co"];
                    drCurrent["Ma_Tte"] = Element.sysMa_Tte;
                    drCurrent["Ty_Gia"] = 1;
                    //drCurrent["Auto_Cost"] = 1;

                    if (dtEditCt.Columns.Contains("Auto_Cost") && (string)drDmCt["Nh_Ct"] == "2")
                        drCurrent["Auto_Cost"] = true;

                    drCurrent["Deleted"] = false;

                    //Clear Content in drEditPh
                    foreach (DataColumn dcEditPh in dtEditPh.Columns)
                        drEditPh[dcEditPh] = DBNull.Value;

                    drEditPh["Ma_DvCs"] = drCurrent["Ma_DvCs"];
                    drEditPh["Stt"] = drCurrent["Stt"];
                    drEditPh["Ma_Ct"] = drCurrent["Ma_Ct"];
                    drEditPh["Ngay_Ct"] = drCurrent["Ngay_Ct"];
                }

                if (drEditPh.Table.Columns.Contains("Duyet"))
                    drEditPh["Duyet"] = (bool)drDmCt["Default_Duyet"];
                if (drEditPh.Table.Columns.Contains("Is_Thue_Vat"))
                    drEditPh["Is_Thue_Vat"] = (bool)drDmCt["Default_VAT"];

                //Tinh so chung tu
                string strLoai_Ma_Ct = ((DateTime)drCurrent["Ngay_Ct"]).Month.ToString().Trim();
                string strSQLExec = "EXEC Sp_Cong_So_Ct '" + strMa_Ct + "', '" + strLoai_Ma_Ct + "'";

                DataTable dtSo_Ct = SQLExec.ExecuteReturnDt(strSQLExec);

                if (dtSo_Ct.Rows.Count > 0)
                    drEditPh["So_Ct"] = drCurrent["So_Ct"] = (string)dtSo_Ct.Rows[0][0];
            }

            Voucher.Update_Header(this);
            Voucher.Update_Stt(this, strModule);
                        
            //if ((string)drDmCt["Nh_Ct"] == "1")
            //{
            //    lblTk_No2.Name = "lblTk_Co2";
            //    lblTk_No2.Tag = "Tk_Co2";
            //    txtTk_No2.Name = "txtTk_Co2";
            //}
            //else//HĐ
            //{
            //    //Số hóa đơn
            //    drEditPh["So_Ct0"] = drCurrent["So_Ct"];
            //}

            if (dgvEditCt1.Columns.Contains("DVT"))
                dgvEditCt1.Columns["Dvt"].ReadOnly = true;                       

            //BindingTTien            
            if (isAccept)
            {
                numTTien0.DataBindings.Clear();
                numTTien_Nt0.DataBindings.Clear();

                numTTien_Nt3.DataBindings.Clear();
                numTTien3.DataBindings.Clear();

                numTTien.DataBindings.Clear();
                numTTien_Nt.DataBindings.Clear();

                numTTien4.DataBindings.Clear();
                numTTien_Nt4.DataBindings.Clear();

                numTSo_Luong.DataBindings.Clear();
            }

            numTTien0.DataBindings.Add("Value", dtEditPh, "TTien0");
            numTTien_Nt0.DataBindings.Add("Value", dtEditPh, "TTien_Nt0");

            numTTien_Nt3.DataBindings.Add("Value", dtEditPh, "TTien_Nt3");
            numTTien3.DataBindings.Add("Value", dtEditPh, "TTien3");

            numTTien.DataBindings.Add("Value", dtEditPh, "TTien");
            numTTien_Nt.DataBindings.Add("Value", dtEditPh, "TTien_Nt");

            numTTien4.DataBindings.Add("Value", dtEditPh, "TTien4");
            numTTien_Nt4.DataBindings.Add("Value", dtEditPh, "TTien_Nt4");

            numTSo_Luong.DataBindings.Add("Value", dtEditPh, "TSo_Luong");

            //Quyen so
            string strSQL = "SELECT Quyen_So FROM LIQUYENSO WHERE Month(Ngay_Begin) <= Month('" + Convert.ToDateTime(drCurrent["Ngay_Ct"]).ToShortDateString() + "') AND Month(Ngay_End) >= Month('"
                         + Convert.ToDateTime(drCurrent["Ngay_Ct"]).ToShortDateString() + "') AND Year(Ngay_End) = Year ('" + Convert.ToDateTime(drCurrent["Ngay_Ct"]).ToShortDateString() + "')";
            DataTable dtQuyen_So = SQLExec.ExecuteReturnDt(strSQL);

            cboQuyen_So.lstItem.BuildListView("Quyen_So:80");
            cboQuyen_So.lstItem.DataSource = dtQuyen_So;
            cboQuyen_So.lstItem.Size = new Size(80, cboQuyen_So.lstItem.Items.Count * 60);
            cboQuyen_So.lstItem.GridLines = true;
        }

        private void LoadDicName()
        {
            if (txtMa_Ct.Text.Trim() != string.Empty && drDmCt != null)
            {
                dicName.SetValue("Ten_Ct", (string)drDmCt["Ten_Ct"]);
            }

            //txtMa_Dt
            if (txtMa_Dt.Text.Trim() != string.Empty)
            {
                txtTen_Dt.Text = DataTool.SQLGetNameByCode("LIDOITUONG", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
                dicName.SetValue(txtTen_Dt.Name, txtTen_Dt.Text);
            }
            else
                txtTen_Dt.Text = string.Empty;

            //txtMa_Hd
            if (txtMa_Hd.Text.Trim() != string.Empty)
            {
                txtTen_Hd.Text = DataTool.SQLGetNameByCode("LIHOPDONG", "Ma_Hd", "Ten_Hd", txtMa_Hd.Text.Trim());
                dicName.SetValue(txtTen_Hd.Name, txtTen_Hd.Text);
            }
            else
                txtTen_Hd.Text = string.Empty;

            //txtMa_CBNV
            if (txtMa_CbNV.Text.Trim() != string.Empty)
            {
                txtTen_NVBH.Text = DataTool.SQLGetNameByCode("LINHANVIEN", "Ma_CBNV", "Ten_CBNV", txtMa_CbNV.Text.Trim());
                dicName.SetValue(txtMa_CbNV.Name, txtMa_CbNV.Text);
            }
            else
                txtMa_CbNV.Text = string.Empty;
        }

        private bool FormCheckValid()
        {
            if (!Common.CheckDataLocked(Library.StrToDate(this.dteNgay_Ct.Text)))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Dữ liệu đã bị khóa" : "Data have been locked";
                Common.MsgCancel(strMsg);
                return false;
            }

            if (Common.GetPartitionCurrent() != 0 && this.enuNew_Edit == enuEdit.Edit && this.drEditPh["Ngay_Ct", DataRowVersion.Original] != DBNull.Value)
            {
                if (((DateTime)this.drEditPh["Ngay_Ct"]).Year != ((DateTime)this.drEditPh["Ngay_Ct", DataRowVersion.Original]).Year)
                {
                    Common.MsgCancel("Dữ liệu đã phân vùng, không cho phép sửa chứng từ từ năm này sang năm khác");
                    return false;
                }
            }
            
            if (chkIs_UngTruoc.Checked && numHan_Tt.Value != 0)
            {
                Common.MsgCancel("Chứng từ khai báo trùng vừa là Ứng trước vừa là Ghi nhận nợ!");
                return false;
            }

            //Kiểm tra nghiệp vụ hợp lệ
            foreach (DataRow dr in dtEditCt.Rows)
            {
                if ((bool)dr["Deleted"])
                    continue;

                //if (dtEditCt.Columns.Contains("Tien") && Convert.ToDouble(dr["So_Luong"]) != 0 && ((string)dr["Tk_No"] == string.Empty || (string)dr["Tk_Co"] == string.Empty))
                //{
                //    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Hạch toán giá vốn không hợp lệ" : "Transaction cost of good sold invalid";
                //    Common.MsgCancel(strMsg);
                //    return false;
                //}
                if (dtEditCt.Columns.Contains("Tien2") && Convert.ToDouble(dr["Tien2"]) != 0 && ((string)dr["Tk_No2"] == string.Empty || (string)dr["Tk_Co2"] == string.Empty))
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Hạch toán doanh thu không hợp lệ" : "Transaction turnover invalid";
                    Common.MsgCancel(strMsg);
                    return false;
                }
                if (dtEditCt.Columns.Contains("Ma_Thue") && (string)dr["Ma_Thue"] != string.Empty && ((string)dr["Tk_No3"] == string.Empty || (string)dr["Tk_Co3"] == string.Empty))
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Hạch toán thuế không hợp lệ" : "Transaction VAT invalid";
                    Common.MsgCancel(strMsg);
                    return false;
                }
            }

            if (!Voucher.CheckDuplicateInvoice(this))
                return false;

            return true;
        }

        public override bool Save()
        {
            Common.GatherMemvar(this, ref this.drEditPh);
            Voucher.Update_Detail(this);

            if (!FormCheckValid())
                return false;

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
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

            Voucher.Update_TTien(this);
            Voucher.Update_Stt(this, strModule);

            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            {
                if (dtEditCt.Rows.Count > 0) //Cập nhật lại dữ liệu từ chi tiết lên Header
                    Common.CopyDataRow(dtEditCt.Rows[0], drEditPh, (string)drDmCt["Update_Header"]);

                drEdit = drEditPh;
            }

            return Voucher.SQLUpdateCt(this);
        }

        private void Ma_Tte_Valid()
        {
            string strMa_Tte = txtMa_Tte.Text.Trim();

            if (Common.Inlist(this.strMa_Ct, (string)Epoint.Systems.Librarys.Parameters.GetParaValue("CT_LOCKED_EXCHANGE")))
                numTy_Gia.Enabled = false;
            else
                numTy_Gia.Enabled = true;

            if (Element.sysMa_Tte == strMa_Tte)
            {
                numTy_Gia.Value = 1;
                numTy_Gia.bReadOnly = true;

                this.pnlTTien.Visible = false;
                this.pnlTTien_Nt.Left = this.pnlTTien.Right - this.pnlTTien_Nt.Width;

                if (dgvEditCt1.Columns.Contains("TIEN2"))
                    dgvEditCt1.Columns["TIEN2"].Visible = false;

                if (dgvEditCt2.Columns.Contains("TIEN"))
                    dgvEditCt2.Columns["TIEN"].Visible = false;

                if (dgvEditCt2.Columns.Contains("GIA"))
                    dgvEditCt2.Columns["GIA"].Visible = false;
            }
            else
            {
                numTy_Gia.bReadOnly = false;

                if (dteNgay_Ct.Text != Library.DateToStr((DateTime)drEditPh["Ngay_Ct"]) || txtMa_Tte.bTextChange)
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("NGAY_CT", Library.StrToDate(dteNgay_Ct.Text));
                    ht.Add("MA_TTE", strMa_Tte);

                    numTy_Gia.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("sp_GetTyGia", ht, CommandType.StoredProcedure));
                }

                this.pnlTTien.Visible = true;
                this.pnlTTien_Nt.Left = this.pnlTTien.Left - this.pnlTTien_Nt.Width;

                if (dgvEditCt1.Columns.Contains("TIEN2"))
                    dgvEditCt1.Columns["TIEN2"].Visible = true;

                if (dgvEditCt2.Columns.Contains("TIEN"))
                    dgvEditCt2.Columns["TIEN"].Visible = true;

                if (dgvEditCt2.Columns.Contains("GIA"))
                    dgvEditCt2.Columns["GIA"].Visible = true;
            }

            if (dteNgay_Ct.Text != Library.DateToStr((DateTime)drEditPh["Ngay_Ct"]) || txtMa_Tte.bTextChange || numTy_Gia.bTextChange)
            {
                Voucher.Update_Detail(this);
                Voucher.Calc_Tien_All(this);
                Voucher.Adjust_TThue_Vat(this, true);

                if (txtMa_Tte.bTextChange)
                    txtMa_Tte.bTextChange = false;
            }

            numTTien_Nt.Scale = numTTien_Nt0.Scale = numTTien_Nt3.Scale = numTTien_Nt4.Scale = strMa_Tte == Element.sysMa_Tte ? 0 : 2;

            Voucher.FormatTien_Nt(dgvEditCt1, strMa_Tte);
            Voucher.FormatTien_Nt(dgvEditCt2, strMa_Tte);

            dgvEditCt1.ResizeGridView();
            dgvEditCt2.ResizeGridView();
        }

        private void Ma_Thue_Valid()
        {
            DataRow drEditCt = dtEditCt.Rows[0];

            string strMa_Thue = txtMa_Thue.Text;

            if (strMa_Thue == string.Empty)
            {
                txtTk_No3.Text = string.Empty;
                txtTk_Co3.Text = string.Empty;
                txtTen_DtGtgt.Text = string.Empty;
                txtMa_So_Thue.Text = string.Empty;

                txtTk_No3.Enabled = false;
                txtTk_Co3.Enabled = false;
                txtTen_DtGtgt.Enabled = false;
                txtMa_So_Thue.Enabled = false;
                numTTien_Nt3.Enabled = false;
                numTTien3.Enabled = false;

                return;
            }
            else
            {
                txtTk_No3.Enabled = true;
                txtTk_Co3.Enabled = true;
                txtTen_DtGtgt.Enabled = true;
                txtMa_So_Thue.Enabled = true;
                numTTien_Nt3.Enabled = true;
                numTTien3.Enabled = true;
            }

            DataRow drDmThue = DataTool.SQLGetDataRowByID("LITHUE", "Ma_Thue", strMa_Thue);

            if (drDmThue != null)
            {
                if (txtMa_Thue.bTextChange)
                {
                    if ((string)drDmCt["Nh_Ct"] == "1") // Phieu tra lai
                    {
                        txtTk_No3.Text = (string)drDmThue["Tk"];                        
                        txtTk_Co3.Text = (string)drEditCt["Tk_No2"];
                    }
                    else // Hoa don ban hang
                    {                        
                        txtTk_No3.Text = (string)drEditCt["Tk_No2"];
                        txtTk_Co3.Text = (string)drDmThue["Tk"];
                    }
                }
                else
                {
                    if ((string)drDmCt["Nh_Ct"] == "1") // Phieu tra lai
                    {
                        if (txtTk_No3.Text.Trim() == string.Empty)
                            txtTk_No3.Text = (string)drDmThue["Tk"];

                        if (txtTk_Co3.Text.Trim() == string.Empty)
                            txtTk_Co3.Text = (string)drEditCt["Tk_No2"];
                    }
                    else // Hoa don ban hang
                    {
                        if (txtTk_No3.Text.Trim() == string.Empty)
                            txtTk_Co3.Text = (string)drEditCt["Tk_No2"];

                        if (txtTk_Co3.Text.Trim() == string.Empty)
                            txtTk_Co3.Text = (string)drDmThue["Tk"];
                    }
                }
            }

            string strMa_Dt = txtMa_Dt.Text;
            DataRow drDmDt = DataTool.SQLGetDataRowByID("LIDOITUONG", "Ma_Dt", drCurrent["Ma_Dt"].ToString());

            if (drDmDt != null)
            {
                if (txtMa_Thue.bTextChange)
                {
                    txtTen_DtGtgt.Text = drDmDt["Ten_Dt"].ToString();
                    txtMa_So_Thue.Text = drDmDt["Ma_So_Thue"].ToString();
                }
                else
                {
                    if (txtTen_DtGtgt.Text.Trim() == string.Empty)
                        txtTen_DtGtgt.Text = (string)drDmDt["Ten_Dt"];

                    if (txtMa_So_Thue.Text.Trim() == string.Empty)
                        txtMa_So_Thue.Text = (string)drDmDt["Ma_So_Thue"];
                }
            }

            return;
        }

        private bool CellKeyEnter()
        {//Ham thuc hien phim Enter: true: thuc hien thanh cong, false: khong thuc hien duoc			

            if (dgvEditCt1.CurrentCell == null)
                return false;

            DataGridViewCell dgvCell = dgvEditCt1.CurrentCell;
            string strCurrentColumn = dgvCell.OwningColumn.Name.ToUpper();

            #region Enter tai Tk_Co2
            if (Common.Inlist(strCurrentColumn, "TEN_VT"))
            {
                drCurrent = ((DataRowView)bdsEditCt.Current).Row;

                if (drCurrent["Ma_Vt"] == DBNull.Value || (string)drCurrent["Ma_Vt"] == string.Empty)
                {
                    bool bIsCurrentLastRow = dgvEditCt1.bIsCurrentLastRow;

                    if (bdsEditCt.Count > 1)
                    {
                        bdsEditCt.RemoveCurrent();
                        dtEditCt.AcceptChanges();
                    }

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

            #region Enter TIEN2
            if (Common.Inlist(strCurrentColumn, "TIEN2"))
            {
                if (dgvEditCt1.bIsCurrentLastRow)
                {
                    // Cap nhat Tien2 truoc khi xuống dòng
                    double dbTien2 = 0;
                    if (double.TryParse(dgvEditCt1.CurrentCell.FormattedValue.ToString().Trim(), out dbTien2))
                    {
                        dgvEditCt1.CancelEdit();
                        drCurrent = ((DataRowView)bdsEditCt.Current).Row;
                        drCurrent["TIEN2"] = dbTien2;
                        Voucher.Calc_So_Luong(drCurrent);
                        Voucher.Update_TTien(this);
                    }

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

        private void Auto_Cost_Change(DataGridViewRow dgvRow, bool bAuto_Cost)
        {
            if (bAuto_Cost)
            {
                dgvRow.Cells["TIEN_NT"].Value = 0;
                dgvRow.Cells["TIEN"].Value = 0;
                dgvRow.Cells["GIA_NT"].Value = 0;
                dgvRow.Cells["GIA"].Value = 0;

                dgvRow.Cells["TIEN_NT"].ReadOnly = true;
                dgvRow.Cells["TIEN"].ReadOnly = true;
                dgvRow.Cells["GIA_NT"].ReadOnly = true;
                dgvRow.Cells["GIA"].ReadOnly = true;
            }
            else
            {
                dgvRow.Cells["TIEN_NT"].ReadOnly = false;
                dgvRow.Cells["TIEN"].ReadOnly = false;
                dgvRow.Cells["GIA_NT"].ReadOnly = false;
                dgvRow.Cells["GIA"].ReadOnly = false;
            }
        }

        private void TTien_Valid()
        {
            numTTien0.Value = numTTien_Nt0.Value * numTy_Gia.Value;

            if (numTTien3.Value == 0)
                numTTien3.Value = numTTien_Nt3.Value * numTy_Gia.Value;
            else if (numTTien_Nt3.Value == 0 && numTy_Gia.Value != 0)
                numTTien_Nt3.Value = numTTien3.Value / numTy_Gia.Value;

            if (numTTien4.Value == 0)
                numTTien4.Value = numTTien_Nt4.Value * numTy_Gia.Value;
            else if (numTTien_Nt4.Value == 0 && numTy_Gia.Value != 0)
                numTTien_Nt4.Value = numTTien4.Value / numTy_Gia.Value;

            this.drEditPh["TTien0"] = numTTien0.Value;
            this.drEditPh["TTien_Nt0"] = numTTien_Nt0.Value;
            this.drEditPh["TTien3"] = numTTien3.Value;
            this.drEditPh["TTien_Nt3"] = numTTien_Nt3.Value;
            

            this.drEditPh["TTien"] = Convert.ToDouble(this.drEditPh["TTien0"]) + Convert.ToDouble(this.drEditPh["TTien3"]);
            this.drEditPh["TTien_Nt"] = Convert.ToDouble(this.drEditPh["TTien_Nt0"]) + Convert.ToDouble(this.drEditPh["TTien_Nt3"]);

            //if (numTTien_Nt3.bTextChange || numTTien3.bTextChange)
            //    Voucher.Adjust_TThue_Vat(this, false);

           
            this.drEditPh["TTien4"] = numTTien4.Value;
            this.drEditPh["TTien_Nt4"] = numTTien_Nt4.Value;
            
            if (chkIs_Sua_ChietKhau.Checked)
            {
                double dbTTien_Nt9 = Common.SumDCValue(dtEditCt, "Tien_Nt9", "");
                if (dbTTien_Nt9 != 0)
                    numChiet_Khau.Value = Math.Round(numTTien_Nt4.Value * 100 / dbTTien_Nt9, 4, MidpointRounding.AwayFromZero);

                Voucher.Update_Detail(this, "Chiet_Khau");
                Voucher.Calc_Chiet_Khau_All(this);
            }
            else
            {
                Voucher.Adjust_Chiet_Khau(this);
            }
            

            if (Common.SumDCValue(this.dtEditCt, "Tien3", "Deleted <> true") != numTTien3.Value || Common.SumDCValue(this.dtEditCt, "Tien_Nt3", "Deleted <> true") != numTTien_Nt3.Value)
            {
                this.drEditPh["TTien3"] = numTTien3.Value;
                this.drEditPh["TTien_Nt3"] = numTTien_Nt3.Value;

                Voucher.Adjust_TThue_Vat(this, false);
            }
        }

        public void Update_Gia_Vt(DataRow drEditCt)
        {
            //Thong: Lay giá gần nhất từ chứng từ, chỉ lấy ra giá khi có số lượng   
            if ((bool)drDmCt["Is_Gia"])
            {
                //Chi cap nhật gia vat tu khi co so luong
                if (drEditCt["Ma_Vt"] == DBNull.Value || (string)drEditCt["Ma_Vt"] == string.Empty)
                    return;

                if (drEditCt["So_Luong9"] == DBNull.Value || Convert.ToDouble(drEditCt["So_Luong9"]) == 0)
                    return;

                if (drEditCt["Gia_Nt9"] != DBNull.Value && Convert.ToDouble(drEditCt["Gia_Nt9"]) != 0)
                    return;

                Hashtable htParameter = new Hashtable();
                htParameter.Add("MA_VT", (string)drEditCt["Ma_Vt"]);
                htParameter.Add("MA_DT", (string)drEditCt["Ma_Dt"]);
                htParameter.Add("MA_CT", strMa_Ct);
                htParameter.Add("NGAY_CT", this.dteNgay_Ct.Text);

                drEditCt["Gia_Nt9"] = SQLExec.ExecuteReturnValue("sp_GetGiaMax", htParameter, CommandType.StoredProcedure);               

            }
            else if (!(bool)drDmCt["Is_Gia"])//Lay gia trong chinh sach gia
            {
                //Chi cap nhật gia vat tu khi co so luong
                if (drEditCt["Ma_Vt"] == DBNull.Value || (string)drEditCt["Ma_Vt"] == string.Empty)
                    return;

                if (drEditCt["So_Luong9"] == DBNull.Value || Convert.ToDouble(drEditCt["So_Luong9"]) == 0)
                    return;

                //if (drEditCt["Gia_Nt9"] != DBNull.Value && Convert.ToDouble(drEditCt["Gia_Nt9"]) != 0)
                //    return;
                
                Hashtable htParameter = new Hashtable();
                htParameter.Add("MA_VT", (string)drEditCt["Ma_Vt"]);
                htParameter.Add("MA_DT", (string)drEditCt["Ma_Dt"]);
                htParameter.Add("DVT", (string)drEditCt["Dvt"]);
                htParameter.Add("NGAY_CT", this.dteNgay_Ct.Text);
                double dbgia = Convert.ToDouble( SQLExec.ExecuteReturnValue("sp_GetGiaBan", htParameter, CommandType.StoredProcedure));
                if (dbgia == 0)
                    return;
                drEditCt["Gia_Nt9"] = dbgia;
            }
        }


        private void HanTt()
        {
            frmHanTt_View frmHanTt = new frmHanTt_View();
            frmHanTt.Load(this);

            //Khóa không cho người dùng sửa lại dữ liệu sau khi đã tick thanh toán
            if (dtHanTt0 != null && dtHanTt0.Select("Thanh_Toan = true").Length > 0)
            {
                this.dgvEditCt1.ReadOnly = true;
                this.dteNgay_Ct.Enabled = false;
                this.txtMa_Tte.Enabled = false;
                this.numTy_Gia.Enabled = false;
                this.txtMa_Dt.Enabled = false;
                this.numHan_Tt.Enabled = false;
            }
            else
            {
                this.dgvEditCt1.ReadOnly = false;
                this.dteNgay_Ct.Enabled = true;
                this.txtMa_Tte.Enabled = true;
                this.numTy_Gia.Enabled = true;
                this.txtMa_Dt.Enabled = true;
                this.numHan_Tt.Enabled = true;
            }
        }

        //Tính số chứng từ khi chọn lại Mã chứng từ
        private void TinhSoCt()
        {
            //Tinh so chung tu
            string strLoai_Ma_Ct = (Convert.ToDateTime(this.dteNgay_Ct.Text)).Month.ToString().Trim();
            string strSQLExec = "EXEC Sp_Cong_So_Ct '" + this.txtMa_Ct.Text + "', '" + strLoai_Ma_Ct + "'";

            DataTable dtSo_Ct = SQLExec.ExecuteReturnDt(strSQLExec);

            if (dtSo_Ct.Rows.Count > 0)
            {
                txtSo_Ct.Text = (string)dtSo_Ct.Rows[0][0];

                Voucher.Update_Detail(this, "So_Ct");
            }
        }
        private void TinhSoCt0()
        {
            string strSQLExec = "SELECT DISTINCT So_Ct0 FROM ARBAN WHERE Ma_DvCs = '" + Element.sysMa_DvCs + "' AND So_Seri0 ='" + txtSo_Seri0.Text + "' ";//"AND YEAR(Ngay_Ct) = "+ Element.sysWorkingYear;
            DataTable dt = SQLExec.ExecuteReturnDt(strSQLExec);
            if (dt.Rows.Count > 0)
            {
                txtSo_Ct0.Text = Voucher.Cong_So_Ct0(this);

            }
            else
                txtSo_Ct0.Text = "00001";


            Voucher.Update_Detail(this, "So_Ct0");
        }
        private bool CheckSo_Ct0()
        {

            if (txtSo_Ct0.Text == string.Empty && txtSo_Seri0.Text == string.Empty)
                return true;
            if ((string)drDmCt["Nh_Ct"] == "1")
                return true;
            string strTableCt = (string)drDmCt["Table_Ct"];
            string strSo_Seri0 = txtSo_Seri0.Text;
            string strSo_Ct0 = txtSo_Ct0.Text;

            string strSQLExec = "SELECT Stt,So_Ct,Ngay_Ct FROM " + strTableCt + " WHERE Stt <> @Stt AND So_Ct0 = @So_Ct0 AND So_Seri0 = @So_Seri0";

            Hashtable ht = new Hashtable();
            ht.Add("SO_SERI0", strSo_Seri0);
            ht.Add("SO_CT0", strSo_Ct0);
            ht.Add("STT", drEditPh["Stt"]);
            DataTable dtCheck = SQLExec.ExecuteReturnDt(strSQLExec, ht, CommandType.Text);

            if (dtCheck.Rows.Count > 0)
            {
                Common.MsgYes_No("Số hóa đơn : " + txtSo_Ct0.Text + " Số Seri: " + txtSo_Seri0.Text + " đã tồn tại. Số chứng từ: " + dtCheck.Rows[0]["So_Ct"].ToString() + ", Ngày ct : " + dtCheck.Rows[0]["Ngay_Ct"].ToString() + "");
                return false;
            }
            return true;
        }
        private void InheritVoucher() //Kế thừa chứng từ từ phiếu khác
        {
            Voucher.Update_Header(this);
            Voucher.Update_Detail(this);

            frmInheritVoucher_Filter frm = new frmInheritVoucher_Filter();
            frm.Load(this);
                        
            Voucher.Update_Detail(this);
            Voucher.Calc_So_Luong_All(this);
            Voucher.Update_TTien(this);            
        }

        #endregion

        #region Su kien

        #region FormEvent

        void btnImportExcel_Click(object sender, EventArgs e)
        {
            Voucher.ImportCtExcel(this);
        }

        void btHanTt_Click(object sender, EventArgs e)
        {
            this.HanTt();
        }

        void btChon_HD_Click(object sender, EventArgs e)
        {
            frmChonHD_Filter frm = new frmChonHD_Filter();
            frm.Load(this);

            Voucher.Calc_So_Luong_All(this);
            Voucher.Update_TTien(this);
        }
        void btInherit_Click(object sender, EventArgs e)
        {
            this.InheritVoucher();
        }

        void linkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string currentDir = Environment.CurrentDirectory;
            System.Diagnostics.Process.Start(currentDir + @"\Help\" + drDmCt["Help_File"]);
        }

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

            //Tính lại Số chứng từ trong truờng hợp chọn lại Ma_Ct khác
            if (this.enuNew_Edit != enuEdit.Edit && txtMa_Ct.bTextChange)
            {
                this.TinhSoCt();
            }
        }
        void txtMa_Ct_TextChanged(object sender, EventArgs e)
        {
            this.drDmCt = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", this.strMa_Ct);
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
            
            //Cap nhat So hoa don            
            //txtSo_Ct0.Text = txtSo_Ct.Text;
        }
        void dteNgay_Ct_Validating(object sender, CancelEventArgs e)
        {
            //Quyen so
            string strSQL = "SELECT Quyen_So FROM LIQUYENSO WHERE Month(Ngay_Begin) <= Month('" + dteNgay_Ct.Text + "') AND Month(Ngay_End) >= Month('"
                                    + dteNgay_Ct.Text + "') AND Year(Ngay_End) = Year ('" + dteNgay_Ct.Text + "')";
            DataTable dtQuyen_So = SQLExec.ExecuteReturnDt(strSQL);

            cboQuyen_So.lstItem.BuildListView("Quyen_So:80");
            cboQuyen_So.lstItem.DataSource = dtQuyen_So;
            cboQuyen_So.lstItem.Size = new Size(80, cboQuyen_So.lstItem.Items.Count * 60);
            cboQuyen_So.lstItem.GridLines = true;

            this.Ma_Tte_Valid();
            Common.GatherMemvar(this, ref drEditPh);

            //Cap nhat Ngay hoa don            
            //dteNgay_Ct0.Text = dteNgay_Ct.Text;
        }        
        void txtMa_Tte_Validating(object sender, CancelEventArgs e)
        {
            this.Ma_Tte_Valid();
        }
        void numTy_Gia_Leave(object sender, EventArgs e)
        {
            this.Ma_Tte_Valid();
        }       
        
        private void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt.Text.Trim();
            bool bRequire = true;

            //frmDoiTuong frmLookup = new frmDoiTuong();
            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

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

                if (txtMa_Dt.Text != (string)drEditPh["Ma_Dt"])
                {
                    txtTen_Dt.Text = drLookup["Ten_Dt"].ToString();
                    txtOng_Ba.Text = drLookup["Ong_Ba"].ToString() == string.Empty ? drLookup["Ten_Dt"].ToString() : drLookup["Ong_Ba"].ToString();

                    if (drLookup["Dia_Chi"].ToString() != string.Empty)
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
            string strKeyValid = "";

            //frmHopDong frmLookup = new frmHopDong();
            DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, "", strKeyValid);

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
        
        void txtMa_Thue_Enter(object sender, EventArgs e)
        {
            this.ucNotice.Text = dicName.GetValue("Ten_Thue");
        }
        void txtMa_Thue_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Thue.Text;
            bool bRequire = false;

            string strMa_Thue_Old = drEditPh["Ma_Thue"] == DBNull.Value ? string.Empty : (string)drEditPh["Ma_Thue"];

            //frmThue frmLookup = new frmThue();
            DataRow drLookup = Lookup.ShowLookup("Ma_Thue", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup != null)
            {
                txtMa_Thue.Text = (string)drLookup["Ma_Thue"];
                dicName.SetValue("Ten_Thue", drLookup["Ten_Thue"].ToString());
                txtMa_HoaDon.Text = (string)drLookup["Ma_HoaDon"];
                txtKh_HoaDon.Text = (string)drLookup["Kh_HoaDon"];

                this.drEditPh["Thue_Gtgt"] = drLookup["Thue_Suat"];
            }

            this.Ma_Thue_Valid();

            Voucher.Update_Detail(this, "Ma_Thue, Thue_Gtgt");

            if (txtMa_Thue.bTextChange)
                Voucher.Adjust_TThue_Vat(this, true);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        void txtMa_So_Thue_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_So_Thue.Text.Trim();

            bool bRequire = false;
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;

            if (strValue == "/" || strValue == @"\")
            {
                //frmDoiTuong frmLookup = new frmDoiTuong();
                DataRow drLookup = Lookup.ShowLookup("Ma_So_Thue", strValue, bRequire, "");

                if (bRequire && drLookup == null)
                    e.Cancel = true;

                if (drLookup == null)
                {
                    txtMa_So_Thue.Text = string.Empty;
                }
                else
                {
                    txtMa_So_Thue.Text = drLookup["Ma_So_Thue"].ToString();
                    txtTen_DtGtgt.Text = drLookup["Ten_Dt"].ToString();
                }
            }
            else if (strValue != string.Empty && txtMa_So_Thue.bTextChange)
            {
                DataTable dtLookup = SQLExec.ExecuteReturnDt("SELECT * FROM LIDOITUONG WHERE Ma_So_Thue = '" + strValue + "'");

                if (dtLookup != null)
                {
                    if (dtLookup.Rows.Count == 1)
                    {
                        txtMa_So_Thue.Text = dtLookup.Rows[0]["Ma_So_Thue"].ToString();
                        txtTen_DtGtgt.Text = dtLookup.Rows[0]["Ten_Dt"].ToString();
                    }
                    else
                    {
                        dtLookup = SQLExec.ExecuteReturnDt("SELECT * FROM LIDOITUONG WHERE Ma_So_Thue LIKE '" + strValue + "%'");

                        if (dtLookup.Rows.Count >= 1)
                        {
                            frmDoiTuong frmLookup = new frmDoiTuong();
                            DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIDOITUONG", "Ma_So_Thue", strValue, bRequire, "");

                            if (bRequire && drLookup == null)
                                e.Cancel = true;

                            if (drLookup == null)
                            {
                                txtMa_So_Thue.Text = string.Empty;
                                txtTen_DtGtgt.Text = string.Empty;
                            }
                            else
                            {
                                txtMa_So_Thue.Text = drLookup["Ma_So_Thue"].ToString();
                                txtTen_DtGtgt.Text = drLookup["Ten_Dt"].ToString();
                            }
                        }
                        else
                        {
                            if (Common.MsgYes_No("Bạn có chắc chắn thêm mới Đối tượng - Mã số thuế?"))
                            {
                                DataRow drNew = dtLookup.NewRow();
                                drNew["Ma_Dt"] = drNew["Ma_So_Thue"] = strValue;
                                drNew["Ma_Nh_Dt"] = "MA_SO_THUE";

                                frmDoiTuong_Edit frmEdit = new frmDoiTuong_Edit();
                                frmEdit.Load(enuEdit.New, drNew);

                                if (frmEdit.isAccept)
                                {
                                    txtMa_So_Thue.Text = (string)drNew["Ma_So_Thue"];
                                    txtTen_DtGtgt.Text = (string)drNew["Ten_Dt"];
                                }
                            }
                        }
                    }
                }
            }
            //this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }

        void txtTk_No3_Enter(object sender, EventArgs e)
        {
            if (bdsEditCt.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsEditCt.Current).Row;

            //this.ucNotice.Text = dicName.GetValue("Ten_Tk_No3");
            if ((string)drCurrent["Ma_Thue"] != string.Empty)
                this.ucNotice.Text = Voucher.GetDuCuoi(drCurrent, txtTk_No3.Text);
        }
        void txtTk_No3_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtTk_No3.Text.Trim();
            bool bRequire = txtMa_Thue.Text.Trim() == string.Empty ? false : true;

            //frmTaiKhoan frmLookup = new frmTaiKhoan();
            DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtTk_No3.Text = string.Empty;
                ucNotice.Text = string.Empty;
            }
            else
            {
                txtTk_No3.Text = drLookup["Tk"].ToString();
                dicName.SetValue("Ten_Tk_No3", drLookup["Ten_Tk"].ToString());
            }

            Voucher.Update_Detail(this, "Tk_No3");

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        void txtTk_No2_Enter(object sender, EventArgs e)
        {
            if (bdsEditCt.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsEditCt.Current).Row;

            //this.ucNotice.Text = dicName.GetValue("Ten_Tk_No3");
            //this.ucNotice.Text = Voucher.GetDuCuoi(drCurrent, txtTk_No2.Text);            
        }
        //void txtTk_No2_Validating(object sender, CancelEventArgs e)
        //{
        //    string strValue = txtTk_No2.Text.Trim();
        //    bool bRequire = txtMa_Thue.Text.Trim() == string.Empty ? false : true;

        //    frmTaiKhoan frmLookup = new frmTaiKhoan();
        //    DataRow drLookup = Lookup.ShowLookup(frmLookup, "LITAIKHOAN", "Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

        //    if (bRequire && drLookup == null)
        //        e.Cancel = true;

        //    if (drLookup == null)
        //    {
        //        txtTk_No2.Text = string.Empty;
        //        ucNotice.Text = string.Empty;
        //    }
        //    else
        //    {
        //        txtTk_No2.Text = drLookup["Tk"].ToString();
        //        lbtTen_Tk_No2.Text = drLookup["Ten_Tk"].ToString();
        //    }

        //    if ((string)drDmCt["Nh_Ct"] == "1")
        //        Voucher.Update_Detail(this, "Tk_Co2");
        //    else
        //        Voucher.Update_Detail(this, "Tk_No2");

        //    //Neu thanh toan bang tien mat thi khoa Hantt
        //    string str = txtTk_No2.Text.Substring(0, 3);
        //    if (str == "111")
        //        numHan_Tt.Enabled = false;
        //    else
        //        numHan_Tt.Enabled = true;

        //    if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
        //    {
        //        ((txtTextLookup)sender).AutoFilter.Visible = false;
        //        this.SelectNextControl(this.ActiveControl, true, true, true, true);
        //    }    
        //}

        void txtTk_Co3_Enter(object sender, EventArgs e)
        {
            if (bdsEditCt.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsEditCt.Current).Row;

            //ucNotice.Text = dicName.GetValue("Ten_Tk_Co3");
            if ((string)drCurrent["Ma_Thue"] != string.Empty)
                this.ucNotice.Text = Voucher.GetDuCuoi(drCurrent, txtTk_Co3.Text);
        }
        void txtTk_Co3_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtTk_Co3.Text.Trim();
            bool bRequire = txtMa_Thue.Text.Trim() == string.Empty ? false : true;

            //frmTaiKhoan frmLookup = new frmTaiKhoan();
            DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtTk_Co3.Text = string.Empty;
                ucNotice.Text = string.Empty;
            }
            else
            {
                txtTk_Co3.Text = drLookup["Tk"].ToString();
                dicName.SetValue("Ten_Tk_Co3", drLookup["Ten_Tk"].ToString());
            }

            Voucher.Update_Detail(this, "Tk_Co3");

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }
        void txtMa_CbNV_BH_Validating(object sender, CancelEventArgs e)
        {
            string strValue = string.Empty;

            strValue = txtMa_CbNV.Text;

            bool bRequire = false;


            DataRow drLookup = Lookup.ShowLookup("Ma_CbNv", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return;

            if (drLookup == null)
            {
                txtMa_CbNV.Text = string.Empty;
                txtTen_NVBH.Text = string.Empty;
            }
            else
            {
                txtMa_CbNV.Text = drLookup["Ma_CbNv"].ToString();
                txtTen_NVBH.Text = drLookup["Ten_CbNv"].ToString();
            }

            return;
        }
        void numChiet_Khau_Validating(object sender, CancelEventArgs e)
        {
            if (!chkIs_Sua_ChietKhau.Checked)
            {
                Voucher.Update_Detail(this, "Chiet_Khau");
                Voucher.Calc_Chiet_Khau_All(this);
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

                    if (tabVoucher.SelectedTab == tpChiTiet1)
                        tabVoucher.SelectedTab = tpChiTiet2;
					else
                        tabVoucher.SelectedTab = tpChiTiet1;
					break;

                case Keys.Up:

                    if (this.dgvEditCt1.Focused && this.dgvEditCt1.bIsCurrentFirstRow)
                        this.SelectNextControl(dgvEditCt1, false, true, true, true);

                    else if (this.dgvEditCt2.Focused && this.dgvEditCt2.bIsCurrentFirstRow)
                        this.SelectNextControl(dgvEditCt2, false, true, true, true);

                    break;

                case Keys.F10:
                    this.InheritVoucher();
                    break;

                case Keys.F11:
                    this.HanTt();
                    break;

            }

            if (!this.dgvEditCt1.Focused)
                this.dgvEditCt1.ClearSelection();

            if (!this.dgvEditCt2.Focused)
                this.dgvEditCt2.ClearSelection();
        }

        void numTTien_Validated(object sender, EventArgs e)
        {
            TTien_Valid();
        }
        void numTTien_Nt_Validated(object sender, EventArgs e)
        {
            TTien_Valid();
        }
        void numTTien3_Validated(object sender, EventArgs e)
        {
            TTien_Valid();
        }
        void numTTien_Nt3_Validated(object sender, EventArgs e)
        {
            TTien_Valid();
        }
        void numTTien4_Validated(object sender, EventArgs e)
        {
            TTien_Valid();
        }
        void numTTien_Nt4_Validated(object sender, EventArgs e)
        {
            chkIs_Sua_ChietKhau.Checked = true;
            TTien_Valid();            
        }

        void tabVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabVoucher.SelectedTab == tpChiTiet1)
            {
                if (bDgvEditCtFocusing)
                    this.dgvEditCt1.Focus();
            }
            else if (tabVoucher.SelectedTab == tpChiTiet2)
            {
                if (bDgvEditCtFocusing)
                    this.dgvEditCt2.Focus();
            }
        }
        void tabVoucher_Enter(object sender, EventArgs e)
        {
            this.SelectNextControl(tabVoucher, true, true, true, true);
        }
        #endregion

        #region DataGridViewEvent

        void dgvEditCt_CellEnter(object sender, DataGridViewCellEventArgs e)
        {//Xu ly Notice

            dgvVoucher dgvEditCt = (dgvVoucher)sender;

            if (dgvEditCt.CurrentCell == null)
                return;

            if (this.ActiveControl != dgvEditCt)
                return;

            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (Common.Inlist(strColumnName, "GIA_NT, GIA, TIEN_NT, TIEN"))
            {
                //if ((bool)dgvEditCt1.CurrentRow.Cells["AUTO_COST"].Value == true)
                //{
                //    dgvCell.ReadOnly = true;
                //    //dgvCell.Value = 0;
                //}
                //else
                //    dgvCell.ReadOnly = false;
            }

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
            else if (Common.Inlist(strColumnName, "TK_NO, TK_CO, TK_NO3, TK_CO3,TK_NO2, TK_CO2, TK_NO4, TK_CO4"))
            {
                if ((string)drCurrent[strColumnName] != string.Empty)
                    this.ucNotice.SetText(string.Empty, Voucher.GetDuCuoi(drCurrent, (string)drCurrent[strColumnName]));
            }
            else if (dgvCell.Tag != null)
                this.ucNotice.SetText(dgvCell.Value.ToString(), (string)dgvCell.Tag);
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

            //e.Cancel = true;

            if (this.ActiveControl == dgvEditCt || this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
            {
                drCurrent = ((DataRowView)bdsEditCt.Current).Row;
                DataGridViewCell dgvCell = dgvEditCt.CurrentCell;
                string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

                bool bLookup = true;

                if (Common.Inlist(strColumnName, "TK_NO,TK_CO,TK_NO2,TK_CO2"))
                    bLookup = dgvLookupTk(ref dgvCell, strColumnName);

                else if (strColumnName == "MA_DT")
                    bLookup = dgvLookupMa_Dt(ref dgvCell);

                else if (strColumnName == "MA_BP")
                    bLookup = dgvLookupMa_Bp(ref dgvCell);

                else if (strColumnName == "MA_KM")
                    bLookup = dgvLookupMa_Km(ref dgvCell);

                else if (strColumnName == "MA_SP")
                    bLookup = dgvLookupMa_Sp(ref dgvCell);

                else if (strColumnName == "MA_JOB")
                    bLookup = dgvLookupMa_Job(ref dgvCell);

                else if (strColumnName == "MA_THUE")
                    bLookup = dgvLookupMa_Thue(ref dgvCell);

                else if (strColumnName == "MA_VT")
                    bLookup = dgvLookupMa_Vt(ref dgvCell);

                else if (strColumnName == "MA_KHO")
                    bLookup = dgvLookupMa_Kho(ref dgvCell);

                else if (strColumnName == "MA_KV")
                    bLookup = dgvLookupMa_Kv(ref dgvCell);

                else if (strColumnName == "MA_CBNV")
                    bLookup = dgvLookupMa_CbNv(ref dgvCell);

                else if (strColumnName == "MA_SO")
                    bLookup = dgvLookupMa_So(ref dgvCell);

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

            //if (drCurrent[strColumnName].GetType() == typeof(decimal) && drCurrent[strColumnName, DataRowVersion.Original] == DBNull.Value)
            //    drCurrent.AcceptChanges();

            //Nếu Tk_No2 trong Hoa don ban hang là tien mat thì ẩn HanTT
            if (strMa_Ct == "HD")
            {
                DataRow drEditCt = dtEditCt.Rows[0];
                string str = (string)drEditCt["Tk_No2"].ToString().Substring(0, 3);
                if (str == "111")
                {
                    numHan_Tt.Enabled = false;
                    btHanTt.Enabled = false;
                }
                else
                {
                    numHan_Tt.Enabled = true;
                    btHanTt.Enabled = true;
                }
            }

            //Cập nhật giá từ chính sách giá
            if (Common.Inlist(strColumnName, "SO_LUONG9"))
            {
                Update_Gia_Vt(drCurrent);

                if (!(bool)drCurrent["Auto_Cost"])
                    Voucher.Calc_Tien_Von(drCurrent);
            }
            if (Common.Inlist(strColumnName, "DVT"))
            {
                Update_Gia_Vt(drCurrent);

                if (!(bool)drCurrent["Auto_Cost"])
                    Voucher.Calc_Tien_Von(drCurrent);
            }
            if (Common.Inlist(strColumnName, "SO_LUONG9,GIA_NT9,TIEN_NT9,TIEN2"))
            {
                if (drCurrent.RowState == DataRowState.Added || Convert.ToDouble(drCurrent[strColumnName]) != Convert.ToDouble(drCurrent[strColumnName, DataRowVersion.Original]))
                {
                    Voucher.Calc_So_Luong(drCurrent);
                    Voucher.Update_TTien(this);
                    Voucher.Adjust_TThue_Vat(this, true);
                }

                //Kiểm tra tồn kho
                if ((string)drCurrent["Ma_Vt"] != string.Empty && (string)drCurrent["Ma_Kho"] != string.Empty &&
                    (string)drDmCt["Nh_Ct"] == "2" && strColumnName == "SO_LUONG9")
                {
                    double dbSo_Luong = Convert.ToDouble(drCurrent["So_Luong"]);
                    double dbTon_Cuoi = 0;
                    Voucher.GetTonCuoi(drCurrent, ref dbTon_Cuoi);

                    if (dbSo_Luong > dbTon_Cuoi)
                    {
                        string strMsg = string.Empty;

                        if (Element.sysLanguage == enuLanguageType.Vietnamese)
                            strMsg = "Số lượng xuất: " + dbSo_Luong.ToString("N2") + " > số lượng tồn: " + dbTon_Cuoi.ToString("N2");
                        else
                            strMsg = "Out quantity: " + dbSo_Luong.ToString("N2") + " > closing inventory quantity: " + dbTon_Cuoi.ToString("N2");

                        Common.MsgCancel(strMsg);
                    }
                }

                //Tính giá vốn tức thời cho người dùng tham khảo
                if (enuNew_Edit != enuEdit.Edit && Collection.Parameters.ContainsKey("AUTO_GIA_BQTT") && Collection.Parameters["AUTO_GIA_BQTT"].ToString() == "1")
                {
                    if (drCurrent["Ma_Vt"].ToString() != "" && drCurrent["Ma_Kho"].ToString() != "" && Convert.ToDouble(drCurrent["So_Luong"]) != 0)
                    {
                        Hashtable htPara = new Hashtable();
                        htPara.Add("NGAY_CT", dteNgay_Ct.Text);
                        htPara.Add("MA_KHO", drCurrent["Ma_Kho"]);
                        htPara.Add("MA_VT", drCurrent["Ma_Vt"]);
                        htPara.Add("STT", drCurrent["Stt"]);
                        htPara.Add("MA_DVCS", Element.sysMa_DvCs);

                        double dbTien_TT = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetTien_TT(@Ngay_Ct, @Ma_Kho, @Ma_Vt, @Stt, @Ma_DvCs)", htPara, CommandType.Text));
                        double dbSL_TT = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetSL_TT(@Ngay_Ct, @Ma_Kho, @Ma_Vt, @Stt, @Ma_DvCs)", htPara, CommandType.Text));
                        double dbGia_TT = dbSL_TT != 0 ? Math.Round(dbTien_TT / dbSL_TT, 4) : 0;

                        if (txtMa_Tte.Text == "VND")
                            drCurrent["Gia_Nt9"] = dbGia_TT;
                        else
                            drCurrent["Gia_Nt9"] = Math.Round(dbGia_TT / numTy_Gia.Value, 4);
                    }
                }
            }

            else if (Common.Inlist(strColumnName, "TIEN2"))
            {
                Voucher.Calc_Tien(drCurrent);
                Voucher.Update_TTien(this);
            }

            if (Common.Inlist(strColumnName, "SO_LUONG9,GIA_NT9,TIEN_NT9,TIEN2"))
                drCurrent.AcceptChanges();

            bdsEditCt.EndEdit();//Cap nhat lai DataSource                   
        }

        void dgvEditCt1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dgvVoucher dgvEditCt = (dgvVoucher)sender;

            if (dgvEditCt.CurrentCell == null)
                return;

            if (this.ActiveControl != dgvEditCt)
                return;

            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (strColumnName == "MA_VT")
                this.bMa_Vt_Changed = true;

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

            if (this.ActiveControl != dgvEditCt2)
                return;

            //Xu ly phim Enter
            if (dgvEditCt2.kLastKey == Keys.Enter)
            {
                dgvEditCt2.kLastKey = Keys.None;

                if (dgvEditCt2.bIsCurrentLastRow && dgvEditCt2.bIsCurrentLastColumn)
                {
                    this.SelectNextControl(dgvEditCt2, true, true, true, true);
                }
            }

            if (this.ActiveControl == dgvEditCt2 || this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
            {
                drCurrent = ((DataRowView)bdsEditCt.Current).Row;
                DataGridViewCell dgvCell = dgvEditCt2.CurrentCell;
                string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

                bool bLookup = true;

                if (Common.Inlist(strColumnName, "TK_NO,TK_CO,TK_NO2,TK_CO2"))
                    bLookup = dgvLookupTk(ref dgvCell, strColumnName);
            }

        }

        void dgvEditCt2_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            // Tinh toan cac Gia tri, cong thuc
            dgvVoucher dgvEditCt = (dgvVoucher)sender;
            if (this.ActiveControl != dgvEditCt && this.ActiveControl != null && this.ActiveControl.GetType().Name != "DataGridViewTextBoxEditingControl")
                return;

            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (Common.Inlist(strColumnName, "GIA_NT, GIA ,TIEN_NT, TIEN"))
            {
                if (!(bool)drCurrent["Auto_Cost"])
                    Voucher.Calc_Tien_Von(drCurrent);
            }

            bdsEditCt.EndEdit();
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
                //dgvCell.Tag = drLookup["Ten_Tk"].ToString();                
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
        private bool dgvLookupMa_Kv(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;

            //frmKhuVuc frmLookup = new frmKhuVuc();
            DataRow drLookup = Lookup.ShowLookup("Ma_Kv", strValue, bRequire, "", "");

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
                dgvCell.Value = drLookup["Ma_Kv"].ToString();
                dgvCell.Tag = drLookup["Ten_Kv"].ToString();
            }

            return true;
        }

        private bool dgvLookupMa_CbNv(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;

            //frmNhanVien frmLookup = new frmNhanVien();
            DataRow drLookup = Lookup.ShowLookup("Ma_CbNv", strValue, bRequire, "", "");

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
                dgvCell.Value = drLookup["Ma_CbNv"].ToString();
                dgvCell.Tag = drLookup["Ten_CbNv"].ToString();
            }

            return true;
        }

        private bool dgvLookupMa_So(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;

            //frmSo frmLookup = new frmSo();
            DataRow drLookup = Lookup.ShowLookup("Ma_SO", strValue, bRequire, "", "");

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
                dgvCell.Value = drLookup["Ma_So"].ToString();
                dgvCell.Tag = drLookup["Ten_So"].ToString();
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

        private bool dgvLookupMa_Thue(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;

            //frmThue frmLookup = new frmThue();
            DataRow drLookup = Lookup.ShowLookup("Ma_Thue", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
                drCurrent["Thue_GtGt"] = 0;
            }
            else
            {
                dgvEditCt1.CancelEdit();
                dgvCell.Value = drLookup["Ma_Thue"].ToString();
                dgvCell.Tag = drLookup["Ten_Thue"].ToString();
                drCurrent["Thue_GtGt"] = Convert.ToInt32(drLookup["Thue_Suat"]);
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

                if (strMa_Vt != strMa_Vt_Old)
                {
                    drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];
                    drCurrent["Dvt"] = drLookup["Dvt"];
                    drCurrent["He_So9"] = 1;

                    Voucher.Calc_So_Luong(drCurrent);

                    //if (strMa_Ct == "TL")//TL
                    if ((string)drDmCt["Nh_Ct"] == "1")
                    {
                        drCurrent["Tk_No"] = drLookup["Tk_Vt"];
                        drCurrent["Tk_Co"] = drLookup["Tk_Gv"];
                        drCurrent["Tk_No2"] = drLookup["Tk_Hbtl"];
                    }
                    else//HD
                    {
                        drCurrent["Tk_No"] = drLookup["Tk_Gv"];
                        drCurrent["Tk_Co"] = drLookup["Tk_Vt"];
                        drCurrent["Tk_Co2"] = drLookup["Tk_Dt"];
                    }
                }
                else
                {
                    if (drCurrent["Ten_Vt"] == DBNull.Value || (string)drCurrent["Ten_Vt"] == string.Empty)
                        drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];

                    if (drCurrent["Dvt"] == DBNull.Value || (string)drCurrent["Dvt"] == string.Empty)
                        drCurrent["Dvt"] = drLookup["Dvt"];

                    //if (strMa_Ct == "TL")//TL
                    if ((string)drDmCt["Nh_Ct"] == "1")
                    {
                        if (drCurrent["Tk_No"] == DBNull.Value || (string)drCurrent["Tk_No"] == string.Empty)
                            drCurrent["Tk_No"] = drLookup["Tk_Vt"];

                        if (drCurrent["Tk_Co"] == DBNull.Value || (string)drCurrent["Tk_Co"] == string.Empty)
                            drCurrent["Tk_Co"] = drLookup["Tk_Gv"];

                        if (drCurrent["Tk_No2"] == DBNull.Value || (string)drCurrent["Tk_No2"] == string.Empty)
                            drCurrent["Tk_No2"] = drLookup["Tk_HBTL"];
                    }
                    else//HD
                    {
                        if (drCurrent["Tk_No"] == DBNull.Value || (string)drCurrent["Tk_No"] == string.Empty)
                            drCurrent["Tk_No"] = drLookup["Tk_Gv"];

                        if (drCurrent["Tk_Co"] == DBNull.Value || (string)drCurrent["Tk_Co"] == string.Empty)
                            drCurrent["Tk_Co"] = drLookup["Tk_Vt"];

                        if (drCurrent["Tk_Co2"] == DBNull.Value || (string)drCurrent["Tk_Co2"] == string.Empty)
                            drCurrent["Tk_Co2"] = drLookup["Tk_Dt"];
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

            if (this.enuNew_Edit == enuEdit.Edit)
            {
                if (!Common.CheckDataLocked((DateTime)drEdit["Ngay_Ct"]))
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
