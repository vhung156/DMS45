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
    public partial class frmGopHD_Edit : frmVoucher_Edit
    {
        #region Declare
        private string strTk_NoTmp = string.Empty;
        private string strTk_CoTmp = string.Empty;
        private string strModule = "04";
        private bool bMa_Vt_Changed = false;
        private bool bMa_Thue_Changed = false;
        private string strMa_Vt_List;
        private DataTable dtImportZ;
        private DataTable dtDiscCount;
        private DataTable dtDiscFreeItemAddNew = new DataTable();
        #endregion

        #region Contructor

        public frmGopHD_Edit()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(frmEditCtTien_KeyDown);

         
            linkHelp.LinkClicked += new LinkLabelLinkClickedEventHandler(linkHelp_LinkClicked);
          
            tabVoucher.Enter += new EventHandler(tabVoucher_Enter);

            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);

            txtMa_Ct.Enter += new EventHandler(txtMa_Ct_Enter);
            txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
            txtMa_Ct.TextChanged += new EventHandler(txtMa_Ct_TextChanged);

            txtSo_Ct.Validating += new CancelEventHandler(txtSo_Ct_Validating);

            dteNgay_Ct.Validating += new CancelEventHandler(dteNgay_Ct_Validating);

            txtMa_So_Thue.Validating += new CancelEventHandler(txtMa_So_Thue_Validating);

         
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
            txtMa_So_Thue.bTextChange = false;
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

            if (dgvEditCt1.Columns.Contains("DVT"))
                dgvEditCt1.Columns["Dvt"].ReadOnly = true;

            //BindingTTien            
            if (isAccept)
            {
               
                numTTien_Nt0.DataBindings.Clear();
                numTTien_Nt3.DataBindings.Clear();
                numTTien_Nt.DataBindings.Clear();
                numTTien_Nt4.DataBindings.Clear();

                numTSo_Luong.DataBindings.Clear();
            }

           
            numTTien_Nt0.DataBindings.Add("Value", dtEditPh, "TTien_Nt0");

            numTTien_Nt3.DataBindings.Add("Value", dtEditPh, "TTien_Nt3");
         
            numTTien_Nt.DataBindings.Add("Value", dtEditPh, "TTien_Nt");
         
            numTTien_Nt4.DataBindings.Add("Value", dtEditPh, "TTien_Nt4");

            numTSo_Luong.DataBindings.Add("Value", dtEditPh, "TSo_Luong");

            //Quyen so
            string strSQL = "SELECT Quyen_So FROM LIQUYENSO WHERE Month(Ngay_Begin) <= Month('" + Convert.ToDateTime(drCurrent["Ngay_Ct"]).ToShortDateString() + "') AND Month(Ngay_End) >= Month('"
                         + Convert.ToDateTime(drCurrent["Ngay_Ct"]).ToShortDateString() + "') AND Year(Ngay_End) = Year ('" + Convert.ToDateTime(drCurrent["Ngay_Ct"]).ToShortDateString() + "')";
            DataTable dtQuyen_So = SQLExec.ExecuteReturnDt(strSQL);


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


            if (txtMa_Dt.Text == string.Empty)
            {
                EpointMessage.MsgOk("Mã khách hàng không được rỗng ");
                txtMa_Dt.Focus();
                return false;
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


        #endregion

        #region Su kien

        #region FormEvent

        void btChon_HD_Click(object sender, EventArgs e)
        {
            frmChonHD_Filter frm = new frmChonHD_Filter();
            frm.Load(this);

            Voucher.Calc_So_Luong_All(this);
            Voucher.Update_TTien(this);
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


           
            Common.GatherMemvar(this, ref drEditPh);

            //Cap nhat Ngay hoa don            
            //dteNgay_Ct0.Text = dteNgay_Ct.Text;
        }
       
        private void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt.Text.Trim();
            bool bRequire = true;

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
                    if (drLookup.Table.Columns.Contains("Ma_Cbnv_Bh"))
                    {
                        
                    }
                    if (drLookup.Table.Columns.Contains("Ma_Cbnv_Gh"))
                    {
                       
                    }

                    if (drLookup.Table.Columns.Contains("Han_Tt"))
                    {
                       
                    }
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

        void txtMa_Thue_Enter(object sender, EventArgs e)
        {
            this.ucNotice.Text = dicName.GetValue("Ten_Thue");
        }
       
        void txtMa_So_Thue_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_So_Thue.Text.Trim();

            bool bRequire = false;
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;

            if (strValue == "/" || strValue == @"\")
            {
                frmDoiTuong frmLookup = new frmDoiTuong();
                DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIDOITUONG", "Ma_So_Thue", strValue, bRequire, "");

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
                    //this.InheritVoucher();
                    break;

                case Keys.F11:
                    //this.HanTt();
                    break;

            }

            if (!this.dgvEditCt1.Focused)
                this.dgvEditCt1.ClearSelection();

            if (!this.dgvEditCt2.Focused)
                this.dgvEditCt2.ClearSelection();
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

        public string strDiscItem { get; set; }


    }
}
