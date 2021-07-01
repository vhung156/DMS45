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

namespace Epoint.Modules.AR
{
    public partial class frmPJPConfig : Epoint.Systems.Customizes.frmView
    {

        string strMa_PJP = String.Empty;
        string strStt = String.Empty;
        DataTable dtImport;
        string strError = string.Empty;
        string strTanSuat = string.Empty;

        DataSet dsPJP;

        DataTable dtPJP;
        BindingSource bdsPJP = new BindingSource();
        DataRow drCurrentPJP;
        DataRow drCurrentPJPDetail;


        DataTable dtPJPDetail;
        BindingSource bdsPJPDetail = new BindingSource();
        DataRow drCurrentDetail;

        public frmPJPConfig()
        {
            InitializeComponent();
            cbxTan_Suat.SelectedIndex = 0;
            bdsPJP.PositionChanged += new EventHandler(bdsDiscountProg_PositionChanged);
            this.btFillterData.Click += new EventHandler(btFillData_Click);
            //this.btImport.Click += new EventHandler(btImport_Click);
            this.btAddCust.Click += new EventHandler(btAddCust_Click);
            this.btPJPDetail.Click +=new EventHandler(btPJPDetail_Click);
            this.btImport.Click += new EventHandler(btImport_Click);
            this.KeyDown += new KeyEventHandler(KeyDownEvent);
            this.dgvPJPDetail.dgvGridView.DoubleClick += new EventHandler(dgvPJPDetail_CellMouseDoubleClick);
        }


       


        public override void Load()
        {
            this.Build();
            this.FillData();
            cbxTan_Suat.SelectedIndex = 1;
            this.Show();
        }

        private void Build()
        {
            dgvPJP.strZone = "OM_PJP";
            dgvPJP.BuildGridView(this.isLookup);
            ExportControl = dtPJP;

            dgvPJPDetail.strZone = "OM_PJPDetail";
            dgvPJPDetail.BuildGridView(this.isLookup);
            ExportControl = dtPJPDetail;



            dteNgay_BD.Text =Library.DateToStr( Epoint.Systems.Elements.Element.sysNgay_Ct1);
            dteNgay_Kt.Text = Library.DateToStr(Epoint.Systems.Elements.Element.sysNgay_Ct2);


        }

        private void FillData()
        {

            Hashtable htDisc = new Hashtable();
            htDisc["NGAY_CT1"] = Library.StrToDate(dteNgay_BD.Text);
            htDisc["NGAY_CT2"] = Library.StrToDate(dteNgay_Kt.Text);
            //htDisc["NGAY_CT1"] = dteNgay_BD.Text;
            //htDisc["NGAY_CT2"] = dteNgay_Kt.Text;
            htDisc.Add("MA_DVCS", Element.sysMa_DvCs);
            dsPJP = SQLExec.ExecuteReturnDs("sp_GetPJP", htDisc, CommandType.StoredProcedure);

            dtPJP = dsPJP.Tables[0];
            bdsPJP.DataSource = dtPJP;
            dgvPJP.DataSource = bdsPJP;

            //Uy quyen cho lop co so tim kiem
            bdsSearch = bdsPJP;
            ExportControl = dgvPJP;

            if (bdsPJP.Count >= 0)
                bdsPJP.Position = 0;

            //Detail
          
            dtPJPDetail = dsPJP.Tables[1];
            bdsPJPDetail.DataSource = dtPJPDetail;
            dgvPJPDetail.DataSource = bdsPJPDetail;


            
        }

        public override void Edit(enuEdit enuNew_Edit)
        {
            if (dgvPJP.Focused)
                EditPJP(enuNew_Edit);
            else if (dgvPJPDetail.Focused)
                EditPJPDetail(enuNew_Edit);
          
        }
        private void EditPJP(enuEdit enuNew_Edit)
        {
            if (bdsPJP.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai
            if (bdsPJP.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsPJP.Current).Row, ref drCurrentPJP);
            else
                drCurrentPJP = dtPJP.NewRow();

            frmPJPConfig_Edit frmEdit = new frmPJPConfig_Edit();
            frmEdit.Load(enuNew_Edit, drCurrentPJP);

            //Accept
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
                {
                    if (bdsPJP.Position >= 0)
                        dtPJP.ImportRow(drCurrentPJP);
                    else
                        dtPJP.Rows.Add(drCurrentPJP);

                    bdsPJP.Position = bdsPJP.Find("Ma_PJP", drCurrentPJP["Ma_PJP"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrentPJP, ((DataRowView)bdsPJP.Current).Row);
                }

                dtPJP.AcceptChanges();
            }
            else
                dtPJP.RejectChanges();

        }
        private void EditPJPDetailAddNew(enuEdit enuNew_Edit)
        {
            if (bdsPJP.Position < 0)
                return;

            string strFilter = "Ma_Dt NOT IN (SELECT DISTINCT Ma_Dt FROM OM_PJPDETAIL)";

            if (!chkCustomAvail.Checked)
            {
                strFilter = string.Empty;
            }
            //Copy hang hien tai
            if (bdsPJPDetail.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsPJPDetail.Current).Row, ref drCurrentDetail);
            else
                drCurrentDetail = dtPJPDetail.NewRow();

            Common.CopyDataRow(((DataRowView)bdsPJP.Current).Row,ref drCurrentPJP);

            this.strMa_PJP = drCurrentPJP["MA_PJP"].ToString();
            bool bRequire = true; bool bIs_Overide = true;
             string[] KeyAr = new string[2] { "Ma_PJP", "Ma_Dt" };
             string[] ValueAr;

             DataRow drLookup = Lookup.ShowMultiLookupNew("Ma_Dt", "", bRequire, strFilter, "", "");
            

            if (bRequire && drLookup == null)
            {
                dtPJPDetail.RejectChanges();
                return;
            }
            string strValueList = drLookup["MuiltiSelectValue"].ToString();
            //string strMsg = (Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn có muốn ghi đè lên mẫu tin đã tồn tại không ?" : "Do you want to override exists data ?");
            //bool bIs_Overide = Common.MsgYes_No(strMsg);
            
            if (drLookup != null && strValueList != string.Empty)
            {
                foreach (string strMa_Dt in strValueList.Split(','))
                {
                    drCurrentDetail["Ma_PJP"] = strMa_PJP;
                    drCurrentDetail["Ma_Dt"] = strMa_Dt;
                    
                    Common.GatherMemvar(this.grbVisitOp, ref drCurrentDetail);
                    drCurrentDetail["Tan_Suat"] = strTanSuat;
                    ValueAr = new string[2] { drCurrentDetail["Ma_PJP"].ToString(), strMa_Dt };


                    if(!DataTool.SQLCheckExist("OM_PJPDetail",KeyAr,ValueAr))
                    {
                         if (DataTool.SQLUpdate(enuEdit.New, "OM_PJPDetail", ref drCurrentDetail))
                        {
                            if (bdsPJPDetail.Position >= 0)
                                dtPJPDetail.ImportRow(drCurrentDetail);
                            else
                                dtPJPDetail.Rows.Add(drCurrentDetail);
                            dtPJPDetail.AcceptChanges();
                        }
                    }
                    else
                    {
                        if(bIs_Overide)
                        {
                            //DataTool.SQLDelete("OM_PJPDetail", KeyAr, ValueAr);
                            if (DataTool.SQLUpdate(enuEdit.Edit, "OM_PJPDetail", ref drCurrentDetail))
                            {
                                dtPJPDetail.AcceptChanges();
                            }

                        }
                    }

                }
            }
        }
        private void EditPJPDetail(enuEdit enuNew_Edit)
        {
            if (bdsPJPDetail.Position < 0)
                return;

            if (enuNew_Edit != enuEdit.Edit)
                return;

            if (bdsPJPDetail.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsPJPDetail.Current).Row, ref drCurrentPJPDetail);


            frmPJPConfigDetail_Edit frmEdit = new frmPJPConfigDetail_Edit();
            frmEdit.Load(enuNew_Edit, drCurrentPJPDetail);

            //Accept
            if (frmEdit.isAccept)
            {
                Common.CopyDataRow(drCurrentPJPDetail, ((DataRowView)bdsPJPDetail.Current).Row);
               
                dtPJPDetail.AcceptChanges();
            }
            else
                dtPJPDetail.RejectChanges();
        }
        public override void Delete()
        {
            if (dgvPJP.Focused)
                DeletePJP();
            else if (dgvPJPDetail.Focused)
                DeletePJPDetail();
          
        }


        private void DeletePJP()
        {
            if (bdsPJP.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsPJP.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;


            Hashtable htPara = new Hashtable();
            htPara["MA_PJP"] = drCurrent["MA_PJP"].ToString();
            bool isCheck = Convert.ToBoolean(SQLExec.ExecuteReturnValue("sp_DELETE_PJP", htPara, CommandType.StoredProcedure));
            if (isCheck)
            {
                bdsPJP.RemoveAt(bdsPJP.Position);
                dtPJP.AcceptChanges();
            }
            else
            {
                EpointMessage.MsgOk("Khong xoa duoc");
            }
        }
        private void DeletePJPDetail()
        {
            if (bdsPJPDetail.Position < 0)
                return;

            drCurrentDetail = ((DataRowView)bdsPJPDetail.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (SQLExec.Execute("DELETE OM_PJPDetail WHERE Ma_PJP = '" + (string)drCurrentDetail["Ma_PJP"] + "' AND Ma_Dt = '" + (string)drCurrentDetail["Ma_Dt"] + "'", CommandType.Text))
            {
                bdsPJPDetail.RemoveAt(bdsPJPDetail.Position);               
            }
        }
      
        #region Sự kiện

        void bdsDiscountProg_PositionChanged(object sender, EventArgs e)
        {           
            if (bdsPJP.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsPJP.Current).Row, ref drCurrentPJP);

            this.strMa_PJP = drCurrentPJP["Ma_PJP"].ToString();
            //string strLoai_Km = drCurrentPJP["Loai_KM"].ToString();
            //string strLoai_Ap_KM = drCurrentPJP["Loai_Ap_KM"].ToString();
            bdsPJPDetail.Filter = "Ma_PJP = '" + strMa_PJP + "'";
       

        }
        void btPJPDetail_Click(object sender, EventArgs e)
        {
            if (bdsPJP.Position < 0)
                return;

            DataRow drCurrentPJP = ((DataRowView)bdsPJP.Current).Row;
            this.strMa_PJP = drCurrentPJP["MA_PJP"].ToString();            
            frmPJPDetail frm = new frmPJPDetail();
            frm.Load(strMa_PJP);
            if(frm.isAccept)
            {
                Hashtable htPJP = new Hashtable();
                htPJP.Add("MA_PJP", strMa_PJP);
                htPJP["NGAY_CT1"] = frm.dtNgay1;
                htPJP["NGAY_CT2"] = frm.dtNgay2;
                htPJP.Add("USERID", Element.sysUser_Id);
                SQLExec.Execute("sp_CreatePJPDetail", htPJP, CommandType.StoredProcedure);
                EpointMessage.MsgOk("Tạo lịch viếng thăm chi tiết thành công.");
            }

        }
        void btAddCust_Click(object sender, EventArgs e)
        {
            if (bdsPJP.Position < 0)
                return;
            strTanSuat = cbxTan_Suat.SelectedItem.ToString();
            int iCount = 0;
            if (strTanSuat == string.Empty)
            {
                EpointMessage.MsgOk("Chọn tần suất viếng thăm.");
                return;
            }

            foreach (Control ctrl in grbVisitOp.Controls)
            {
                if(ctrl.Name.StartsWith("chk"))
                {
                    CheckBox chk = (CheckBox)(ctrl);
                    if (chk.CheckState == CheckState.Checked)
                        iCount++;
                }
            }

            if (strTanSuat == "F2" || strTanSuat == "F4")
            {
                if(iCount != 1)
                {
                    EpointMessage.MsgOk("Chọn 1 ngày viếng thăm trong tuần.");
                    return;
                }
            }
            else
            {
                if (iCount != 2)
                {
                    EpointMessage.MsgOk("Chọn 2 ngày viếng thăm trong tuần.");
                    return;
                }
            }


            EditPJPDetailAddNew(enuEdit.New);
        }
        void btFillData_Click(object sender, EventArgs e)
        {
            FillData();
        }
        void Setdefault(ref DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                int intStt = 0, dbToTien = 0, dbTien_Ck = 0, dbCk = 0;
                if (int.TryParse(dr["Stt"].ToString(), out intStt))
                {
                    dr["Stt"] = 0;
                }
                dr.AcceptChanges();
             }
        }
        void btImport_Click(object sender, EventArgs e)
        {
            frmPJP_Import frmImp = new frmPJP_Import();
            frmImp.Load();
            //frmImp.ShowDialog();

            strError = string.Empty;

            //OpenFileDialog ofdlg = new OpenFileDialog();
            //ofdlg.Filter = "xls files (*.xls;*.xlsx)|*.xls;*.xlsx";
            //ofdlg.RestoreDirectory = true;
            //if (ofdlg.ShowDialog() != DialogResult.OK)
            //    return;

            //dtImport = Common.ReadExcel(ofdlg.FileName);
            //Setdefault(ref dtImport);
            //EpointProcessBox.Show(this);    
        }
        public virtual void Import_Excel(bool CheckAPI)
        {
            //string strMsg = (Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn có muốn ghi đè lên mẫu tin đã tồn tại không ?" : "Do you want to override exists data ?");
            bool bIsImport = DataTool.SQLCheckExist("sys.procedures", "Name", "OM_Import_PJP");
            if (bIsImport)
            {            
                
                SqlCommand command = SQLExec.GetNewSQLConnection().CreateCommand();
                command.CommandText = "OM_Import_PJP";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);
                command.Parameters.AddWithValue("@UserId", Element.sysUser_Id);
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

        void dgvPJPDetail_CellMouseDoubleClick(object sender, EventArgs e)
        {
            if (bdsPJPDetail.Position < 0)
                return;

            EditPJPDetail(enuEdit.Edit);

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
                                Setdefault(ref dtImport);
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
