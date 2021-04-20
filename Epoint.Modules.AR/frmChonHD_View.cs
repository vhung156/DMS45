using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;
using Epoint.Systems;
using Epoint.Systems.Elements;
using System.Data.SqlClient;
using System.Collections;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Columns;

namespace Epoint.Modules.AR
{
    public partial class frmChonHD_View : Epoint.Systems.Customizes.frmView
    {

        #region Khai bao bien
        public DataTable dtViewCur;
        public DataTable dtViewHD;

        public bool is_Accept = false;
        private DataRow drDmCt;
        private dgvGridControl dgvViewHD = new dgvGridControl();
        public string strMa_Px = string.Empty;
        public string strMa_CbNv_GH = string.Empty;
        BindingSource bdsViewHD = new BindingSource();
        public DataTable dtVoucherSelect;
        //dgvControl dgvViewHD = new dgvControl();

        string strMa_Ct = string.Empty;
        string strKey = string.Empty;
        frmVoucher_Edit frmEditCtHD;
        enuEdit enuNew_Edit;

        #endregion

        #region Contructor

        public frmChonHD_View()
        {
            InitializeComponent();

            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            //txtSo_Ct.TextChanged += new EventHandler(txtSo_Ct_TextChanged);
            dgvViewHD.dgvGridView.Click += new EventHandler(dgvViewHD_CellMouseClick);
        }





        public void Load(frmVoucher_Edit frmEditCtHD, string strMa_Ct, string strKey)
        {
            this.frmEditCtHD = frmEditCtHD;
            this.strMa_Ct = strMa_Ct;
            this.strKey = strKey;

            Build();
            FillData();
            BindingLanguage();

            ShowDialog();
        }
        public void LoadCheckPXK(enuEdit enuNew_Edit, string Ma_Px, string strMa_CbNv_GH)
        {
            //this.frmEditCtHD = frmEditCtHD;

            this.strMa_Px = Ma_Px;
            this.strMa_CbNv_GH = strMa_CbNv_GH;
            this.enuNew_Edit = enuNew_Edit;

            BuildCheckPXK();
            FillDataPXK();
            BindingLanguage();

            ShowDialog();
        }
        public void LoadCheckPXK(enuEdit enuNew_Edit, string Ma_Px, string strMa_CbNv_GH, string Ma_Ct)
        {
            //this.frmEditCtHD = frmEditCtHD;
            this.drDmCt = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", Ma_Ct);
            this.strMa_Px = Ma_Px;
            this.strMa_CbNv_GH = strMa_CbNv_GH;
            this.enuNew_Edit = enuNew_Edit;
            this.strMa_Ct = Ma_Ct;


            BuildCheckPXK();
            FillDataPXK();
            BindingLanguage();

            ShowDialog();
        }
        #endregion

        #region Build, FillData

        private void Build()
        {
            dgvViewHD.strZone = "TL_ViewHD";
            dgvViewHD.ReadOnly = false;
            dgvViewHD.BuildGridView(this.isLookup);
            dgvViewHD.Dock = DockStyle.Fill;
            //this.ListOrder.Controls.Add(dgvViewHD);
        }
        private void BuildCheckPXK()
        {
            dgvViewHD.strZone = "OM_PXKDETAIL_EDIT";
            dgvViewHD.ReadOnly = false;
            dgvViewHD.BuildGridView(this.isLookup);
            dgvViewHD.Dock = DockStyle.Fill;


            GridColumn col = new GridColumn();
            col.Name = col.FieldName = "CHON";
            col.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            col.Visible = true;
            col.Caption = "Chọn";
            col.Width = 40;
            dgvViewHD.dgvGridView.Columns.Add(col);

            //dgvCheckBoxColumn dgvcChkb = new dgvCheckBoxColumn();
            //dgvcChkb.Name = "CHON";
            //dgvcChkb.DataPropertyName = "CHON";
            //dgvViewHD.dgvAdvBandedGridView.Columns.Add(dgvcChkb);

            this.ListOrder.Controls.Add(dgvViewHD);

        }
        private void FillData()
        {
            bdsViewHD = new BindingSource();

            DataRow drDmCt = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", strMa_Ct);
            string strTable_Ct = (string)drDmCt["Table_Ct"];

            string strSelect = " Stt , Ma_Ct, Ngay_Ct, So_Ct, Dien_Giai, Ma_Nx, Ma_Kho, Ma_Vt, Ten_Vt, Dvt, So_Luong9, Gia_Nt9, Tien_Nt9, Ma_TTe,Tk_No, Tk_Co, Gia_Nt, Gia, Tien_Nt, Tien, CAST(0 AS BIT) AS Chon ";

            dtViewHD = DataTool.SQLGetDataTable(strTable_Ct, strSelect, strKey, "Ngay_Ct, So_Ct");

            bdsViewHD.DataSource = dtViewHD;
            dgvViewHD.DataSource = bdsViewHD;

            bdsViewHD.Position = 0;

            //Uy quyen cho lop co so tim kiem           
            bdsSearch = bdsViewHD;

            //foreach (BandedGridColumn dgvc in dgvViewHD.dgvAdvBandedGridView.Columns)
            //    dgvc.ReadOnly = true;

            //dgvViewHD.Columns["CHON"].ReadOnly = false;
        }
        private void FillDataPXK()
        {
            bdsViewHD = new BindingSource();

            Hashtable ht = new Hashtable();
            ht.Add("MA_PX", strMa_Px);
            ht.Add("LOAI_PX", this.strMa_Ct);
            ht.Add("MA_DVCS", Element.sysMa_DvCs);
            DataTable dtHD = new DataTable();
            // Điêu kiện khuyến mãi
            //            dtHD = SQLExec.ExecuteReturnDt(@"SELECT ph.stt, ph.TTien0 + ph.TTien3 AS TTien,Ph.So_Ct,Ph.Ma_Dt,dt.Ten_Dt,Ma_Px  = '" + strMa_Px + @"' ,
            //                                                        Ma_Dvcs = '" + Element.sysMa_DvCs + @"',
            //                                                        CAST(0 AS BIT) AS Chon 						                           
            //						                            FROM GLVOUCHER ph
            //						                            INNER JOIN LIDOITUONG dt ON ph.Ma_Dt =  dt.Ma_Dt
            //                                                    WHERE ph.Duyet =0 AND So_Ct_Lap = ''  AND ph.Ma_Ct IN ('" + this.strMa_Ct + "') ", "", "", CommandType.Text);

            dtHD = SQLExec.ExecuteReturnDt("Sp_OM_GetVoucher", ht, CommandType.StoredProcedure);
            dtViewHD = dtHD.Clone();

            if (dtViewCur != null && dtViewCur.Rows.Count > 0)
                foreach (DataRow dr in dtHD.Rows)
                {
                    if (dtViewCur.Select("Stt  = '" + dr["Stt"].ToString() + "'").Length == 0)
                    {
                        dtViewHD.ImportRow(dr);
                    }
                }
            else
            {
                dtViewHD = dtHD;
            }

            bdsViewHD.DataSource = dtViewHD;
            dgvViewHD.DataSource = bdsViewHD;
            bdsViewHD.Position = 0;

            //Uy quyen cho lop co so tim kiem           
            bdsSearch = bdsViewHD;

            //foreach (DataGridViewColumn dgvc in dgvViewHD.Columns)
            //    dgvc.ReadOnly = true;

            //dgvViewHD.Columns["Chon"].ReadOnly = false;
        }
        private void UpdatefrmEditCtHD()
        {
            DataTable dtEditCt = frmEditCtHD.dtEditCt;

            DataRow drEditCt = dtEditCt.Rows[0];

            //dtEditCt.Clear();
            DataRow[] drChonHD = dtViewHD.Select("Chon = true");

            foreach (DataRow drViewHD in drChonHD)
            {
                //if ((bool)drViewHD["DELETED"])
                //    continue;

                DataRow drEditCtNew = dtEditCt.NewRow();
                Common.CopyDataRow(drEditCt, drEditCtNew);

                drEditCtNew["Ma_Vt"] = drViewHD["Ma_Vt"];
                drEditCtNew["Ten_Vt"] = drViewHD["Ten_Vt"];
                drEditCtNew["Ma_Kho"] = drViewHD["Ma_Kho"];
                drEditCtNew["Dvt"] = drViewHD["Dvt"];

                drEditCtNew["So_Luong9"] = drViewHD["So_Luong9"];
                drEditCtNew["Gia_Nt9"] = drViewHD["Gia_Nt9"];
                drEditCtNew["Tien_Nt9"] = drViewHD["Tien_Nt9"];

                drEditCtNew["Tk_No"] = drViewHD["Tk_Co"];
                drEditCtNew["Tk_Co"] = drViewHD["Tk_No"];
                drEditCtNew["Gia_Nt"] = drViewHD["Gia_Nt"];
                drEditCtNew["Gia"] = drViewHD["Gia"];
                drEditCtNew["Tien_Nt"] = drViewHD["Tien_Nt"];
                drEditCtNew["Tien"] = drViewHD["Tien"];

                drEditCtNew["Stt_Org"] = drViewHD["Stt"];
                drEditCtNew["Stt0"] = Common.MaxDCValue(dtEditCt, "Stt0") + 1;

                dtEditCt.Rows.Add(drEditCtNew);
            }

            if (dtEditCt.Rows.Count > 1)
                dtEditCt.Rows.Remove(drEditCt);

            //Cập nhật Tk_No2 = Tk hàng bán trả lại	
            foreach (DataRow dr in dtEditCt.Rows)
            {
                string strMa_Vt = (string)dr["Ma_Vt"];
                dr["Tk_No2"] = DataTool.SQLGetNameByCode("LIVATTU", "Ma_Vt", "Tk_Hbtl", strMa_Vt);
            }
        }
        public bool UpdateCt(DataTable dtEditCt)
        {
            #region UpdateCt: Cap nhat tung dong trong dtEditCt


            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            SqlTransaction sqlTran = sqlCom.Connection.BeginTransaction("Update_Voucher_Tran");

            sqlCom.Transaction = sqlTran;



            int iSave_Ct_Success = 0;


            sqlCom.Parameters.Clear();

            //Xoa du lieu cu trong Chung tu
            //if (this.enuNew_Edit == enuEdit.Edit)
            //{
            //    sqlCom.CommandType = CommandType.Text;
            //    sqlCom.CommandText = "DELETE FROM OM_PXKDetail WHERE MA_PX = @MA_PX";
            //    sqlCom.Parameters.AddWithValue("@MA_PX", (string)drEdit["MA_PX"]);
            //    try
            //    {
            //        sqlCom.ExecuteNonQuery();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
            //        sqlCom.Transaction.Rollback();
            //        return false;
            //    }
            //}

            //Luu du lieu vao Ct
            sqlCom.CommandText = "sp_UpdatePXK";
            sqlCom.CommandType = CommandType.StoredProcedure;

            string strKey = "Object_id = Object_id('sp_UpdatePXK')";
            DataTable dtUpdateCt_Para = DataTool.SQLGetDataTable("Sys.Parameters", "Name", strKey, null);
            DataRow[] drArrPrint = dtEditCt.Select("CHON = true");


            foreach (DataRow dr in drArrPrint)
            {
                //Khong luu nhung dong danh dau xoa
                if (dr.Table.Columns.Contains("Deleted") && (bool)dr["Deleted"])
                    continue;

                sqlCom.Parameters.Clear();

                DataRow drEditCt = dr;
                Common.SetDefaultDataRow(ref drEditCt);

                foreach (DataRow drPara in dtUpdateCt_Para.Rows)
                {
                    string strColumnName = ((string)drPara["Name"]).Replace("@", "");

                    if (!drEditCt.Table.Columns.Contains(strColumnName))
                        continue;

                    sqlCom.Parameters.AddWithValue("@" + strColumnName, drEditCt[strColumnName]);
                }

                try
                {
                    int iSuc = sqlCom.ExecuteNonQuery();
                    if (iSuc > 0)
                    {
                        SQLExec.Execute("Update GLVoucher SET So_Ct_Lap = '" + strMa_Px + "'" +
                                                "WHERE Stt  = '" + dr["Stt"].ToString() + "'");

                        //SQLExec.Execute("Update ARBan SET Ma_CBNV_GH = '" + txtMa_CBNV_GH.Text + "' " +
                        //                      "WHERE Stt  = '" + dr["Stt"].ToString() + "'");
                        iSave_Ct_Success += 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
                    sqlCom.Transaction.Rollback();
                    return false;
                }
            }

            #endregion

            sqlTran.Commit();
            return true;
        }

        private void Save_PXKDetail(DataTable dtEditCt)
        {
            if (true)
            {
                SqlCommand command = SQLExec.GetNewSQLConnection().CreateCommand();
                command.CommandText = "Sp_Update_PXKDetail";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Ma_PX", strMa_Px);
                command.Parameters.AddWithValue("@Ma_CBNV_GH", strMa_CbNv_GH);
                command.Parameters.AddWithValue("@IS_UPDATE", "1");
                command.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);
                SqlParameter parameter = new SqlParameter
                {
                    SqlDbType = SqlDbType.Structured,
                    ParameterName = "@TVP_PXKDETAIL",
                    TypeName = "TVP_PXKDETAIL",
                    Value = dtEditCt,
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
            }
        }
        #endregion

        #region Su kien

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    DataRow drCurrent = ((DataRowView)bdsViewHD.Current).Row;
                    //    drCurrent["Chon"] = !(bool)drCurrent["Chon"];
                    break;
            }

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        foreach (DataRow dr in dtViewHD.Rows)
                            dr["Chon"] = true;
                        break;
                    case Keys.U:
                        foreach (DataRow dr in dtViewHD.Rows)
                            dr["Chon"] = false;
                        break;
                }
            }

            base.OnKeyDown(e);
        }
        void dgvViewHD_CellMouseClick(object sender, EventArgs e)
        {
            //if (e.ColumnIndex < 0 || e.RowIndex < 0)
            //    return;

            //string strColumnName = dgvViewHD.Columns[e.ColumnIndex].Name;
            //DataRow drCurrent = ((DataRowView)bdsViewHD.Current).Row;


            //if (strColumnName == "CHON")
            //{

            //    drCurrent["CHON"] = !Convert.ToBoolean(drCurrent["CHON"]);
            //    drCurrent.AcceptChanges();
            //}

            if (bdsViewHD.Position < 0)
                return;

            string strColumnName = dgvViewHD.dgvGridView.FocusedColumn.Name;
            DataRow drCurrent = ((DataRowView)bdsViewHD.Current).Row;

            if (strColumnName == "DUYET")
            {
                frmDuyet frm = new frmDuyet();
                frm.Load(drCurrent);
            }

            if (strColumnName == "CHON")
            {
                drCurrent["CHON"] = !Convert.ToBoolean(drCurrent["CHON"]);
                drCurrent.AcceptChanges();
            }
        }

        void txtSo_Ct_TextChanged(object sender, EventArgs e)
        {
            // string strKey = "(1 = 1) ";

            //if(txtSo_Ct.Text == "")
            //{
            //    this.bdsViewHD.RemoveFilter();
            //}
            // else
            //{
            //    strKey = strKey + " AND (So_Ct LIKE '%" + txtSo_Ct.Text + "%')";
            //    this.bdsViewHD.Filter = strKey;
            //}
        }
        void btAccept_Click(object sender, EventArgs e)
        {
            if (strMa_Px == string.Empty)
                this.UpdatefrmEditCtHD();
            else // Thêm trong trường hợp phiếu xuất kho
            {
                DataRow[] drArrPrint = dtViewHD.Select("CHON = true");
                DataRow drCurrent;

                dtVoucherSelect = new DataTable();

                DataColumn drSTT = new DataColumn("Stt", typeof(string));
                DataColumn drMa_PX = new DataColumn("Ma_PX", typeof(string));
                DataColumn drSo_Ct = new DataColumn("So_Ct", typeof(string));
                DataColumn drMa_Dt = new DataColumn("Ma_Dt", typeof(string));
                DataColumn drTen_Dt = new DataColumn("Ten_Dt", typeof(string));
                DataColumn drTTien = new DataColumn("TTien", typeof(double));
                DataColumn drMa_DvCs = new DataColumn("Ma_DvCs", typeof(string));
                DataColumn drDelete = new DataColumn("Deleted", typeof(bool));
                dtVoucherSelect.Columns.Add(drSTT);
                dtVoucherSelect.Columns.Add(drMa_PX);
                dtVoucherSelect.Columns.Add(drSo_Ct);
                dtVoucherSelect.Columns.Add(drMa_Dt);
                dtVoucherSelect.Columns.Add(drTen_Dt);
                dtVoucherSelect.Columns.Add(drTTien);
                dtVoucherSelect.Columns.Add(drMa_DvCs);
                dtVoucherSelect.Columns.Add(drDelete);
                if (drArrPrint.Length > 0)
                {
                    for (int i = 0; i < drArrPrint.Length; i++)
                    {

                        drCurrent = drArrPrint[i];

                        DataRow drtemp = dtVoucherSelect.NewRow();
                        drtemp["Stt"] = drCurrent["Stt"];
                        drtemp["So_Ct"] = drCurrent["So_Ct"];
                        drtemp["Ma_PX"] = strMa_Px;
                        drtemp["Ma_Dt"] = drCurrent["Ma_Dt"];
                        drtemp["Ten_Dt"] = drCurrent["Ten_Dt"];
                        drtemp["TTien"] = drCurrent["TTien"];
                        drtemp["Deleted"] = false;
                        drtemp["Ma_Dvcs"] = Element.sysMa_DvCs;


                        dtVoucherSelect.Rows.Add(drtemp);


                    }
                }

                if (this.enuNew_Edit == enuEdit.Edit)
                {
                    this.Save_PXKDetail(dtVoucherSelect);
                    //                    this.UpdateCt(dtViewHD);

                    //                    string strSQL = @"UPDATE  OM_PXK SET TTien = ISNULL( px.TTien0,0)
                    //						            FROM OM_PXK xk
                    //						            INNER JOIN (
                    //						
                    //										SELECT px.Ma_PX , TTien0 = SUM(ph.TTien0) FROM OM_PXKDetail px 					
                    //										INNER JOIN GLVOUCHER ph ON Px.Stt = Ph.Stt 
                    //										WHERE px.Ma_Px = '" + strMa_Px + @"'
                    //										GROUP BY px.Ma_PX)px     	on Px.Ma_PX = xk.Ma_PX";
                    //                    //if (DataTool.SQLDelete("OM_PXKDetail", drCurrent))
                    //                        if (SQLExec.Execute(strSQL))
                    //                        { }
                }
                else if (this.enuNew_Edit == enuEdit.New)
                {

                }

                this.is_Accept = true;
            }
            this.Close();
        }

        void btCancel_Click(object sender, EventArgs e)
        {
            this.is_Accept = false;
            this.Close();
        }

        #endregion
    }
}