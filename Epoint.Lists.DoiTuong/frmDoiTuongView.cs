using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems;
using Epoint.Systems.Elements;

namespace Epoint.Lists
{
    public partial class frmDoiTuongView : Epoint.Lists.frmView
    {

        #region Khai bao bien
        private DataTable dtDoiTuongNh;
        private DataRow drCurrentDtNh; 
        private BindingSource bdsDoiTuongNh = new BindingSource();
        private tlControl tlDoiTuongNh = new tlControl();

        public bool bEnterFinish = true;


        private DataTable dtDoiTuong;
        private DataRow drCurrent;
        private BindingSource bdsDoiTuong = new BindingSource();
        private dgvGridControl dgvDoiTuong = new dgvGridControl();

        public string strMa_Nh_Dt = string.Empty;
        public bool bLookupByGroup = false;
        public bool bLastLookupProcess = false;
        public bool bFind = false;


        #endregion

        #region Contructor
        public frmDoiTuongView()
        {
            InitializeComponent();

            this.tlDoiTuongNh.MouseDoubleClick += new MouseEventHandler(tlVatTuNh_MouseDoubleClick);
            this.bdsDoiTuongNh.PositionChanged += new EventHandler(bdsDoiTuongNh_PositionChanged);

            tlDoiTuongNh.Click += new EventHandler(tlDoiTuongNh_Click);
            dgvDoiTuong.Click += new EventHandler(dgvDoiTuong_Click);

            btExport.Click += new EventHandler(btExport_Click);
            btRefresh.Click += new EventHandler(btRefresh_Click);
        }

        void dgvDoiTuong_Click(object sender, EventArgs e)
        {
            strTableName = "LIDOITUONG";
            strCode = "MA_DT";
            strName = "TEN_DT";
        }

        void tlDoiTuongNh_Click(object sender, EventArgs e)
        {
            strTableName = "LIDOITUONGNH";
            strCode = "MA_Nh_DT";
            strName = "TEN_Nh_DT";
        }

        void bdsDoiTuongNh_PositionChanged(object sender, EventArgs e)
        {
            if (bdsDoiTuongNh.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsDoiTuongNh.Current).Row, ref drCurrentDtNh);
            if ((bool)drCurrentDtNh["Nh_Cuoi"])
                this.strMa_Nh_Dt = drCurrentDtNh["Ma_Nh_Dt"].ToString();
            else
                strMa_Nh_Dt = string.Empty;
            bdsDoiTuong.Filter = "MA_NH_DT = '" + strMa_Nh_Dt + "'";

        }
        public override void Load()
        {
            this.Init();
            this.Build(); 
            this.FillDataDt();
            this.FillData();
           
            this.BindingLanguage();

            if (this.isLookup)
                this.ShowDialog();
            else
                this.Show();
        }

        public override void LoadLookup()
        {
            this.Load();
        }
        private void Init()
        {

        }

        #endregion

        #region Build, FillData
        private void Build()
        {
            tlDoiTuongNh.KeyFieldName = "MA_NH_DT";
            tlDoiTuongNh.ParentFieldName = "MA_NH_DT_CHA";
            tlDoiTuongNh.Dock = DockStyle.Fill;
                       
            tlDoiTuongNh.strZone = "DoiTuongNh";
            tlDoiTuongNh.BuildTreeList(this.isLookup);        

            //this.pnlMa_Nh_Vt.Controls.Add(tlVatTuNh);
            //this.pnlMa_Vt.Controls.Add(dgvVatTu);

            dgvDoiTuong.Dock = DockStyle.Fill;
            dgvDoiTuong.strZone = "DoiTuong";
            dgvDoiTuong.BuildGridView(this.isLookup);
            ExportControl = dgvDoiTuong;

            this.splitDoiTuong.Panel1.Controls.Add(tlDoiTuongNh);
            this.splitDoiTuong.Panel2.Controls.Add(dgvDoiTuong);

            if (isLookup)
            {
                this.splitContainer.Panel2.Controls.Add(splControl1);
                this.splControl1.Panel1.Controls.Add(splitDoiTuong);
            }
            else
            {
                this.splControl1.Panel1.Controls.Add(splitDoiTuong);
            }
        }

        public void FillData()
        {
            dtDoiTuongNh = DataTool.SQLGetDataTable("LIDOITUONGNH", null, this.strLookupKeyFilter, null);

            bdsDoiTuongNh.DataSource = dtDoiTuongNh;
            tlDoiTuongNh.DataSource = bdsDoiTuongNh;

            //Uy quyen cho lop co so tim kiem
            bdsSearch = bdsDoiTuongNh;
            ExportControl = tlDoiTuongNh;

            if (bdsDoiTuongNh.Count >= 0)
                bdsDoiTuongNh.Position = 0;

            if (this.isLookup)
                this.MoveToLookupValue();

            tlDoiTuongNh.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM SYSZONE WHERE ZONE = '" + tlDoiTuongNh.strZone + "'");
        }
        public void FillDataDt()
        {
            string strKey = string.Empty;
            if (this.isLookup)
                strKey = (this.strLookupKeyFilter == null ? string.Empty : this.strLookupKeyFilter);
            else
                strKey = (strMa_Nh_Dt == string.Empty ? string.Empty : "Ma_Nh_Dt = '" + strMa_Nh_Dt + "'");

            //Hùng kiểm tra đối tượng: dùng chung danh mục với CRM
            DataTable dtDoiTuongCheck = SQLExec.ExecuteReturnDt("SELECT TOP 0 * FROM LIDOITUONG WHERE 0 = 1");
            if (dtDoiTuongCheck.Columns.Contains("Deleted"))
                strKey += (strKey == string.Empty ? string.Empty : " AND ") + "(Deleted <> 1)";

            //Chỉ show những dữ liệu cần thiết có khai báo trong Zone, Column
            string strSQLExec = @"
				DECLARE @_ColumnList NVARCHAR(1000) 
				SET @_ColumnList = ''
				SELECT @_ColumnList = @_ColumnList + ',' + Column_ID FROM SYSCOLUMN WHERE Zone = '" + dgvDoiTuong.strZone + @"'
				SELECT CASE WHEN LEN(@_ColumnList) > 0 THEN RIGHT(@_ColumnList, LEN(@_ColumnList)-1) ELSE '' END ";
            string strFieldList = SQLExec.ExecuteReturnValue(strSQLExec).ToString();

            if (strFieldList != string.Empty)
                dtDoiTuong = DataTool.SQLGetDataTable("LIDOITUONG", strFieldList, strKey, "Ma_Dt");
            else
                dtDoiTuong = DataTool.SQLGetDataTable("LIDOITUONG", null, strKey, "Ma_Dt");

            bdsDoiTuong.DataSource = dtDoiTuong;
            dgvDoiTuong.DataSource = bdsDoiTuong;

            if (bdsDoiTuong.Count >= 0)
                bdsDoiTuong.Position = 0;//Vi tri mac dinh

            //Uy quyen cho lop co so tim kiem           
            bdsSearch = bdsDoiTuong;

            if (this.isLookup)
                this.MoveToLookupValue();
        }
        private void MoveToLookupValue()
        {
            if (strLookupColumn == string.Empty || strLookupValue == string.Empty)
                return;

            for (int i = 0; i <= dtDoiTuongNh.Rows.Count - 1; i++)
                if (((string)dtDoiTuongNh.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
                {
                    bdsDoiTuongNh.Position = i;
                    break;
                }
        }
        #endregion

        #region Update

        public override void Edit(enuEdit enuNew_Edit)
        {
            if (tlDoiTuongNh.Focused)
                EditDtNh(enuNew_Edit);
            else if (dgvDoiTuong.Focused)
                EditDt(enuNew_Edit);

        }

        void EditDtNh(enuEdit enuNew_Edit)
        {
            if (bdsDoiTuongNh.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai
            if (bdsDoiTuongNh.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsDoiTuongNh.Current).Row, ref drCurrentDtNh);
            else
                drCurrentDtNh = dtDoiTuongNh.NewRow();

            frmDoiTuongNh_Edit frmEdit = new frmDoiTuongNh_Edit();
            frmEdit.Load(enuNew_Edit, drCurrentDtNh);

            //Accept
            if (frmEdit.isAccept)
            {
                htHistory["DIEN_GIAI"] = "Danh mục nhóm đối tượng";
                strTableName = "LIDOITUONGNH";
                strCode = "MA_NH_DT";
                strName = "TEN_NH_DT";
                //Cập nhật History
                DataRow drHistory = drCurrentDtNh;
                htHistory["CODE"] = drHistory[strCode];
                htHistory["NAME"] = drHistory[strName];

                if (enuNew_Edit == enuEdit.New)
                {
                    htHistory["UPDATE_TYPE"] = "N";
                    UpdateHistory();
                }
                else if (enuNew_Edit == enuEdit.Edit && ((string)drHistory[strCode] != (string)((DataRowView)bdsDoiTuongNh.Current)[strCode] || (string)drHistory[strName] != (string)((DataRowView)bdsDoiTuongNh.Current)[strName]))
                {
                    htHistory["UPDATE_TYPE"] = "E";
                    htHistory["CODE_OLD"] = ((DataRowView)bdsDoiTuongNh.Current)[strCode];
                    htHistory["NAME_OLD"] = ((DataRowView)bdsDoiTuongNh.Current)[strName];
                    UpdateHistory();
                }
                //Cập nhật dữ liệu chứng từ
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsDoiTuongNh.Position >= 0)
                        dtDoiTuongNh.ImportRow(drCurrentDtNh);
                    else
                        dtDoiTuongNh.Rows.Add(drCurrentDtNh);

                    bdsDoiTuongNh.Position = bdsDoiTuongNh.Find("Ma_Nh_Dt", drCurrentDtNh["Ma_Nh_Dt"]);
                }
                else
                    Common.CopyDataRow(drCurrentDtNh, ((DataRowView)bdsDoiTuongNh.Current).Row);

                dtDoiTuongNh.AcceptChanges();
            }
            else
                dtDoiTuongNh.RejectChanges();
        }
        void EditDt(enuEdit enuNew_Edit)
        {
            if (bdsDoiTuong.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai
            if (bdsDoiTuong.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsDoiTuong.Current).Row, ref drCurrent);
            else
            {
                drCurrent = dtDoiTuong.NewRow();
                drCurrent["Ma_Nh_Dt"] = strMa_Nh_Dt;
            }

            frmDoiTuong_Edit frmEdit = new frmDoiTuong_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            //Accept
            if (frmEdit.isAccept)
            {
                htHistory["DIEN_GIAI"] = "Danh mục đối tượng";
                strTableName = "LIDOITUONG";
                strCode = "MA_DT";
                strName = "TEN_DT";
                //Cập nhật History
                DataRow drHistory = drCurrent;
                htHistory["CODE"] = drHistory[strCode];
                htHistory["NAME"] = drHistory[strName];

                if (enuNew_Edit == enuEdit.New)
                {
                    htHistory["UPDATE_TYPE"] = "N";
                    UpdateHistory();
                }
                else if (enuNew_Edit == enuEdit.Edit && ((string)drHistory[strCode] != (string)((DataRowView)bdsDoiTuong.Current)[strCode] || (string)drHistory[strName] != (string)((DataRowView)bdsDoiTuong.Current)[strName]))
                {
                    htHistory["UPDATE_TYPE"] = "E";
                    htHistory["CODE_OLD"] = ((DataRowView)bdsDoiTuong.Current)[strCode];
                    htHistory["NAME_OLD"] = ((DataRowView)bdsDoiTuong.Current)[strName];
                    UpdateHistory();
                }
                //Cập nhật dữ liệu danh mục
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsDoiTuong.Position >= 0)
                        dtDoiTuong.ImportRow(drCurrent);
                    else
                        dtDoiTuong.Rows.Add(drCurrent);

                    bdsDoiTuong.Position = bdsDoiTuong.Find("MA_DT", drCurrent["MA_DT"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsDoiTuong.Current).Row);
                }

                //dtDoiTuong.AcceptChanges();
                drCurrent.AcceptChanges();
            }
            else
                //dtDoiTuong.RejectChanges();
                drCurrent.RejectChanges();
        }
        public override void Delete()
        {
            if (tlDoiTuongNh.Focused)
                DeleteDtNh();
            else if (dgvDoiTuong.Focused)
                DeleteDt();

        }

        void DeleteDtNh()
        {
            if (bdsDoiTuongNh.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsDoiTuongNh.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLCheckExist("LIDOITUONGNH", "Ma_Nh_Dt_Cha", drCurrent["Ma_Nh_Dt"]))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
                    "Nhóm đối tượng: {" + drCurrent["Ten_Nh_Dt"].ToString() + "}  đang có nhóm con" :
                    "Object group: {" + drCurrent["Ten_Nh_Dt"].ToString() + "}  have child object group";

                Common.MsgCancel(strMsg);
                return;
            }

            if (DataTool.SQLCheckExist("LIDOITUONG", "Ma_Nh_Dt", drCurrent["Ma_Nh_Dt"]))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
                    "Nhóm đối tượng: {" + drCurrent["Ten_Nh_Dt"].ToString() + "}  đang có đối tượng" :
                    "Object group : {" + drCurrent["Ten_Nh_Dt"].ToString() + "}  have object";

                Common.MsgCancel(strMsg);
                return;
            }

            if (DataTool.SQLDelete("LIDOITUONGNH", drCurrent))
            {
                htHistory["DIEN_GIAI"] = "Danh mục nhóm đối tượng";
                strTableName = "LIDOITUONGNH";
                strCode = "MA_NH_DT";
                strName = "TEN_NH_DT";

                ////Sync Delete----------
                //string Is_Sync = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM SYSPARAMETER WHERE Parameter_ID = 'SYNC_BEGIN'"));
                //if (Is_Sync == "1")
                //{
                //    SqlConnection sqlCon = SQLExecSync1.GetNewSQLConnectionSync1();
                //    if (sqlCon.State != ConnectionState.Open)
                //    {
                //        SQLExec.Execute("UPDATE SYSPARAMETER SET Parameter_Value = 0 WHERE Parameter_ID = 'SYNC_BEGIN'");
                //        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Quá trình đồng bộ đang bị gián đoạn. Vui lòng chờ trong ít phút !" : "The synchronization process is interrupted. Please wait a few minutes !";
                //        Common.MsgCancel(strMsg);
                //    }
                //    else
                //    {
                //        DataToolSync1.SQLDelete("LIDOITUONGNH", drCurrent);
                //    }
                //}

                //Cập nhật History
                htHistory["CODE"] = drCurrent[strCode];
                htHistory["NAME"] = drCurrent[strName];
                htHistory["UPDATE_TYPE"] = "D";
                UpdateHistory();

                bdsDoiTuongNh.RemoveAt(bdsDoiTuongNh.Position);
                dtDoiTuongNh.AcceptChanges();
            }
        }
        void DeleteDt()
        {
           
            if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
            {
                Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
                return;
            }

            if (bdsDoiTuong.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsDoiTuong.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            htHistory["DIEN_GIAI"] = "Danh mục đối tượng";
            strTableName = "LIDOITUONG";
            strCode = "MA_DT";
            strName = "TEN_DT";

            if (DataTool.SQLCheckExist("vw_SoCai", strCode, drCurrent[strCode]))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
                    "Đối tượng: {" + drCurrent[strName].ToString() + "}  đã được sử dụng trong chứng từ" :
                    "Object: {" + drCurrent[strName].ToString() + "}  used in voucher";

                Common.MsgCancel(strMsg);
                return;
            }

            if (DataTool.SQLCheckExist("GLDUDAU", strCode, drCurrent[strCode]))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
                    "Đối tượng: {" + drCurrent[strName].ToString() + "}  đã được sử dụng trong số dư đầu kỳ" :
                    "Object: {" + drCurrent[strName].ToString() + "}  used in opening balance";

                Common.MsgCancel(strMsg);
                return;
            }

            if (DataTool.SQLDelete("LIDOITUONG", drCurrent))
            {
                htHistory["DIEN_GIAI"] = "Danh mục đối tượng";
                strTableName = "LIDOITUONG";
                strCode = "MA_DT";
                strName = "TEN_DT";

                ////Sync Delete----------
                //string Is_Sync = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM SYSPARAMETER WHERE Parameter_ID = 'SYNC_BEGIN'"));
                //if (Is_Sync == "1")
                //{
                //    SqlConnection sqlCon = SQLExecSync1.GetNewSQLConnectionSync1();
                //    if (sqlCon.State != ConnectionState.Open)
                //    {
                //        SQLExec.Execute("UPDATE SYSPARAMETER SET Parameter_Value = 0 WHERE Parameter_ID = 'SYNC_BEGIN'");
                //        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Quá trình đồng bộ đang bị gián đoạn. Vui lòng chờ trong ít phút !" : "The synchronization process is interrupted. Please wait a few minutes !";
                //        Common.MsgCancel(strMsg);
                //    }
                //    else
                //    {
                //        DataToolSync1.SQLDelete("LIDOITUONG", drCurrent);
                //    }
                //}
                ////-----------------------

                //Cập nhật History
                htHistory["CODE"] = drCurrent[strCode];
                htHistory["NAME"] = drCurrent[strName];
                htHistory["UPDATE_TYPE"] = "D";
                UpdateHistory();

                bdsDoiTuong.RemoveAt(bdsDoiTuong.Position);
                dtDoiTuong.AcceptChanges();
            }
  
        }
        public override void MergeID()
        {
            if (tlDoiTuongNh.Focused)
                MergeIDDtNh();
            else if (dgvDoiTuong.Focused)
                MergeIDDt();
        }
        void MergeIDDtNh()
        {
            if (bdsDoiTuongNh.Count <= 0)
                return;

            drCurrentDtNh = ((DataRowView)bdsDoiTuongNh.Current).Row;
            string strOldValue = (string)drCurrentDtNh["Ma_Nh_Dt"];

            frmMergeID frm = new frmMergeID();

            frm.Load("LIDOITUONGNH", "Ma_Nh_Dt", "Ten_Nh_Dt", strOldValue, "DoiTuongNh");

            if (frm.isAccept)
            {
                string strNewValue = frm.strNewValue;
                string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
                if (!Common.MsgYes_No(strMsg))
                    return;

                if (DataTool.SQLMergeID("Ma_Nh_Dt", "LIDOITUONGNH", strOldValue, strNewValue))
                {
                    ////Sync data-------------
                    //string Is_Sync = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM SYSPARAMETER WHERE Parameter_ID = 'SYNC_BEGIN'"));
                    //if (Is_Sync == "1")
                    //{
                    //    SqlConnection sqlCon = SQLExecSync1.GetNewSQLConnectionSync1();
                    //    if (sqlCon.State != ConnectionState.Open)
                    //    {
                    //        SQLExec.Execute("UPDATE SYSPARAMETER SET Parameter_Value = 0 WHERE Parameter_ID = 'SYNC_BEGIN'");
                    //        string strMsg1 = Element.sysLanguage == enuLanguageType.Vietnamese ? "Quá trình đồng bộ đang bị gián đoạn. Vui lòng chờ trong ít phút !" : "The synchronization process is interrupted. Please wait a few minutes !";
                    //        Common.MsgCancel(strMsg1);
                    //    }
                    //    else
                    //    {
                    //        DataToolSync1.SQLMergeID("Ma_Nh_Dt", "LIDOITUONGNH", strOldValue, strNewValue);
                    //    }
                    //}
                    ////----------------------

                    //Cập nhật History
                    htHistory["CODE"] = drCurrentDtNh["MA_NH_DT"];
                    htHistory["NAME"] = drCurrentDtNh["TEN_NH_DT"];
                    htHistory["UPDATE_TYPE"] = "D";
                    UpdateHistory();

                    bdsDoiTuongNh.RemoveCurrent();
                    bdsDoiTuongNh.Position = bdsDoiTuongNh.Find("Ma_Nh_Dt", strNewValue);
                }
            }
        }
        void MergeIDDt()
        {
            if (bdsDoiTuong.Count <= 0)
                return;

            drCurrent = ((DataRowView)bdsDoiTuong.Current).Row;
            string strOldValue = (string)drCurrent["Ma_Dt"];

            frmMergeID frm = new frmMergeID();

            frm.Load("LIDOITUONG", "Ma_Dt", "Ten_Dt", strOldValue, "DoiTuong");

            if (frm.isAccept)
            {
                string strNewValue = frm.strNewValue;
                string strMsg = Element.sysLanguage == enuLanguageType.English ? "Are you sure to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
                if (!Common.MsgYes_No(strMsg))
                    return;

                if (DataTool.SQLMergeID("Ma_Dt", "LIDOITUONG", strOldValue, strNewValue))
                {
                    ////Sync data-------------
                    //string Is_Sync = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM SYSPARAMETER WHERE Parameter_ID = 'SYNC_BEGIN'"));
                    //if (Is_Sync == "1")
                    //{
                    //    SqlConnection sqlCon = SQLExecSync1.GetNewSQLConnectionSync1();
                    //    if (sqlCon.State != ConnectionState.Open)
                    //    {
                    //        SQLExec.Execute("UPDATE SYSPARAMETER SET Parameter_Value = 0 WHERE Parameter_ID = 'SYNC_BEGIN'");
                    //        string strMsg1 = Element.sysLanguage == enuLanguageType.Vietnamese ? "Quá trình đồng bộ đang bị gián đoạn. Vui lòng chờ trong ít phút !" : "The synchronization process is interrupted. Please wait a few minutes !";
                    //        Common.MsgCancel(strMsg1);
                    //    }
                    //    else
                    //    {
                    //        DataToolSync1.SQLMergeID("Ma_Dt", "LIDOITUONG", strOldValue, strNewValue);
                    //    }
                    //}
                    ////----------------------

                    //Cập nhật History
                    htHistory["CODE"] = drCurrent["MA_DT"];
                    htHistory["NAME"] = drCurrent["TEN_DT"];
                    htHistory["UPDATE_TYPE"] = "D";
                    UpdateHistory();

                    bdsDoiTuong.RemoveCurrent();
                    bdsDoiTuong.Position = bdsDoiTuong.Find("MA_DT", strNewValue);
                }
            }
        }
        #endregion

        #region EnterProcess

        bool EnterValid()
        {

            return true;

        }


        #endregion

        #region Su kien

        void tlVatTuNh_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //this.EnterProcess();
        }

        void btExport_Click(object sender, EventArgs e)
        {
            dgvExport.bSortMode = false;
            dgvExport.strZone = "DoiTuongNh";
            dgvExport.BuildGridView();
            dgvExport.DataSource = bdsDoiTuongNh;

            string strTitle = ((Control)ExportControl).FindForm().Text;
            if (strTitle.Contains(","))
                strTitle = strTitle.Split(',')[0];

            ExportList(dgvExport, strTitle);
        }

        void btRefresh_Click(object sender, EventArgs e)
        {
            FillData();
        }

        #endregion
    }
}