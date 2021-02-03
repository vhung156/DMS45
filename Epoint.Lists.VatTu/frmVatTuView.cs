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
    public partial class frmVatTuView : Epoint.Lists.frmView
    {

        #region Khai bao bien
        private DataTable dtVatTuNh;
        private DataRow drCurrentVtNh;
        private BindingSource bdsVatTuNh = new BindingSource();
        private tlControl tlVatTuNh = new tlControl();

        public bool bEnterFinish = true;


        private DataTable dtVatTu;
        private DataRow drCurrent;
        private BindingSource bdsVatTu = new BindingSource();
        private dgvGridControl dgvVatTu = new dgvGridControl();

        public string strMa_Nh_Vt = string.Empty;
        public bool bLastLookupProcess = false;
        public bool bFind = false;


        #endregion

        #region Contructor
        public frmVatTuView()
        {
            InitializeComponent();

            this.tlVatTuNh.MouseDoubleClick += new MouseEventHandler(tlVatTuNh_MouseDoubleClick);
            this.bdsVatTuNh.PositionChanged += new EventHandler(bdsVatTuNh_PositionChanged);

            this.tlVatTuNh.Click += new EventHandler(tlVatTuNh_Click);
            this.dgvVatTu.Click += new EventHandler(dgvVatTu_Click);

            btExport.Click += new EventHandler(btExport_Click);
            btRefresh.Click += new EventHandler(btRefresh_Click);
        }

        void dgvVatTu_Click(object sender, EventArgs e)
        {
            strTableName = "LIVATTU";
            strCode = "MA_VT";
            strName = "TEN_VT";
        }

        void tlVatTuNh_Click(object sender, EventArgs e)
        {
            strTableName = "LIVATTUNH";
            strCode = "MA_Nh_VT";
            strName = "TEN_Nh_VT";
        }

        void bdsVatTuNh_PositionChanged(object sender, EventArgs e)
        {
            if (bdsVatTuNh.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsVatTuNh.Current).Row, ref drCurrentVtNh);
            if ((bool)drCurrentVtNh["Nh_Cuoi"])
                this.strMa_Nh_Vt = drCurrentVtNh["Ma_Nh_Vt"].ToString();
            else
                strMa_Nh_Vt = string.Empty;
            bdsVatTu.Filter = "MA_NH_VT = '" + strMa_Nh_Vt + "'";

        }

        public override void Load()
        {
            this.Init();
            this.Build();
            this.FillDataVt();
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
            tlVatTuNh.KeyFieldName = "MA_NH_VT";
            tlVatTuNh.ParentFieldName = "MA_NH_VT_CHA";
            tlVatTuNh.Dock = DockStyle.Fill;
            tlVatTuNh.strZone = "VatTuNh";
            tlVatTuNh.BuildTreeList(this.isLookup);

            //this.pnlMa_Nh_Vt.Controls.Add(tlVatTuNh);
            //this.pnlMa_Vt.Controls.Add(dgvVatTu);

            dgvVatTu.Dock = DockStyle.Fill;
            dgvVatTu.strZone = "VatTu";
            dgvVatTu.BuildGridView(this.isLookup);


            this.splitVatTu.Panel1.Controls.Add(tlVatTuNh);
            this.splitVatTu.Panel2.Controls.Add(dgvVatTu);

            if (isLookup)
            {
                this.splitContainer.Panel2.Controls.Add(splControl1);
                this.splControl1.Panel1.Controls.Add(splitVatTu);
            }
            else
            {
                this.splControl1.Panel1.Controls.Add(splitVatTu);
            }
        }

        public void FillData()
        {
            dtVatTuNh = DataTool.SQLGetDataTable("LIVATTUNH", null, strLookupKeyFilter, null);

            bdsVatTuNh.DataSource = dtVatTuNh;
            bdsVatTuNh.Position = 0;
            bdsVatTuNh.Filter = "Loai_Nh IN ('1', '3')";

            tlVatTuNh.DataSource = bdsVatTuNh;

            //Uy quyen cho lop co so tim kiem           
            bdsSearch = bdsVatTuNh;
            ExportControl = tlVatTuNh;

            if (this.isLookup)
                this.MoveToLookupValue();

            tlVatTuNh.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM SYSZONE WHERE ZONE = '" + tlVatTuNh.strZone + "'");
        }
        public void FillDataVt()
        {
            string strKey = string.Empty;
            if (this.isLookup)
                strKey = (this.strLookupKeyFilter == null ? string.Empty : this.strLookupKeyFilter);
            else
                strKey = (strMa_Nh_Vt == string.Empty ? string.Empty : "Ma_Nh_Vt = '" + strMa_Nh_Vt + "'");

            dtVatTu = DataTool.SQLGetDataTable("LIVATTU", null, strKey, "Ma_Vt");

            bdsVatTu.DataSource = dtVatTu;
            dgvVatTu.DataSource = bdsVatTu;
            bdsVatTu.Position = 0;

            //Uy quyen cho lop co so tim kiem           
            bdsSearch = bdsVatTu;
            ExportControl = dgvVatTu;

            if (this.isLookup)
                this.MoveToLookupValue();
        }
        private void MoveToLookupValue()
        {
            if (strLookupColumn == string.Empty || strLookupValue == string.Empty)
                return;

            for (int i = 0; i <= dtVatTuNh.Rows.Count - 1; i++)
                if (((string)dtVatTuNh.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
                {
                    bdsVatTuNh.Position = i;
                    break;
                }
        }
        #endregion

        #region Update

        public override void Edit(enuEdit enuNew_Edit)
        {
            if (tlVatTuNh.Focused)
                EditVtNh(enuNew_Edit);
            else if (dgvVatTu.Focused)
                EditVt(enuNew_Edit);

        }

        void EditVtNh(enuEdit enuNew_Edit)
        {
            if (bdsVatTuNh.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai            
            if (bdsVatTuNh.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsVatTuNh.Current).Row, ref drCurrentVtNh);
            else
                drCurrentVtNh = dtVatTuNh.NewRow();

            frmVatTuNh_Edit frmEdit = new frmVatTuNh_Edit();
            frmEdit.Load(enuNew_Edit, drCurrentVtNh);

            //Accept
            if (frmEdit.isAccept)
            {
                htHistory["DIEN_GIAI"] = "Danh mục nhóm vật tư";
                strTableName = "LIVATTUNH";
                strCode = "MA_NH_VT";
                strName = "TEN_NH_VT";
                //Cập nhật History
                DataRow drHistory = drCurrentVtNh;
                htHistory["CODE"] = drHistory[strCode];
                htHistory["NAME"] = drHistory[strName];

                if (enuNew_Edit == enuEdit.New)
                {
                    htHistory["UPDATE_TYPE"] = "N";
                    UpdateHistory();
                }
                else if (enuNew_Edit == enuEdit.Edit && ((string)drHistory[strCode] != (string)((DataRowView)bdsVatTuNh.Current)[strCode] || (string)drHistory[strName] != (string)((DataRowView)bdsVatTuNh.Current)[strName]))
                {
                    htHistory["UPDATE_TYPE"] = "E";
                    htHistory["CODE_OLD"] = ((DataRowView)bdsVatTuNh.Current)[strCode];
                    htHistory["NAME_OLD"] = ((DataRowView)bdsVatTuNh.Current)[strName];
                    UpdateHistory();
                }
                //Cập nhật dữ liệu danh mục
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsVatTuNh.Position >= 0)
                        dtVatTuNh.ImportRow(drCurrentVtNh);
                    else
                        dtVatTuNh.Rows.Add(drCurrentVtNh);

                    bdsVatTuNh.Position = bdsVatTuNh.Find("Ma_Nh_Vt", drCurrentVtNh["Ma_Nh_Vt"]);
                }
                else
                    Common.CopyDataRow(drCurrentVtNh, ((DataRowView)bdsVatTuNh.Current).Row);

                dtVatTuNh.AcceptChanges();
            }
            //else
            //    dtVatTuNh.RejectChanges();
        }
        void EditVt(enuEdit enuNew_Edit)
        {
            if (bdsVatTu.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai            
            if (bdsVatTu.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsVatTu.Current).Row, ref drCurrent);
            else
            {
                drCurrent = dtVatTu.NewRow();
                drCurrent["Ma_Nh_Vt"] = strMa_Nh_Vt;
            }

            frmVatTu_Edit frmEdit = new frmVatTu_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            //Accept
            if (frmEdit.isAccept)
            {
                htHistory["DIEN_GIAI"] = "Danh mục vật tư";
                strTableName = "LIVATTU";
                strCode = "MA_VT";
                strName = "TEN_VT";
                //Cập nhật History
                DataRow drHistory = drCurrent;
                htHistory["CODE"] = drHistory[strCode];
                htHistory["NAME"] = drHistory[strName];

                if (enuNew_Edit == enuEdit.New)
                {
                    htHistory["UPDATE_TYPE"] = "N";
                    UpdateHistory();
                }
                else if (enuNew_Edit == enuEdit.Edit && ((string)drHistory[strCode] != (string)((DataRowView)bdsVatTu.Current)[strCode] || (string)drHistory[strName] != (string)((DataRowView)bdsVatTu.Current)[strName]))
                {
                    htHistory["UPDATE_TYPE"] = "E";
                    htHistory["CODE_OLD"] = ((DataRowView)bdsVatTu.Current)[strCode];
                    htHistory["NAME_OLD"] = ((DataRowView)bdsVatTu.Current)[strName];
                    UpdateHistory();
                }
                //Cập nhật dữ liệu danh mục
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsVatTu.Position >= 0)
                        dtVatTu.ImportRow(drCurrent);
                    else
                        dtVatTu.Rows.Add(drCurrent);

                    bdsVatTu.Position = bdsVatTu.Find("MA_VT", drCurrent["MA_VT"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsVatTu.Current).Row);

                dtVatTu.AcceptChanges();
            }
            else
                dtVatTu.RejectChanges();
        }
        public override void Delete()
        {
            if (tlVatTuNh.Focused)
                DeleteVtNh();
            else if (dgvVatTu.Focused)
                DeleteVt();

        }

        void DeleteVtNh()
        {
            if (bdsVatTuNh.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsVatTuNh.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLCheckExist("LIVATTUNH", "Ma_Nh_Vt_Cha", drCurrent["Ma_Nh_Vt"]))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
                    "Nhóm vật tư : {" + drCurrent["Ten_Nh_Vt"].ToString() + "}  đang có nhóm con" :
                    "Item group: {" + drCurrent["Ten_Nh_Vt"].ToString() + "}  have child group";

                Common.MsgOk(strMsg);
                return;
            }

            if (DataTool.SQLCheckExist("LIVATTU", "Ma_Nh_Vt", drCurrent["Ma_Nh_Vt"]))
            {

                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
                    "Nhóm vật tư : {" + drCurrent["Ten_Nh_Vt"].ToString() + "}  đang có vật tư" :
                    "Item group: {" + drCurrent["Ten_Nh_Vt"].ToString() + "}  have item";

                Common.MsgOk(strMsg);
                return;
            }

            if (DataTool.SQLDelete("LIVATTUNH", drCurrent))
            {
                htHistory["DIEN_GIAI"] = "Danh mục nhóm vật tư";
                strTableName = "LIVATTUNH";
                strCode = "MA_NH_VT";
                strName = "TEN_NH_VT";

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
                //        DataToolSync1.SQLDelete("LIVATTUNH", drCurrent);
                //    }
                //}
                ////-----------------------

                //Cập nhật History
                htHistory["CODE"] = drCurrent[strCode];
                htHistory["NAME"] = drCurrent[strName];
                htHistory["UPDATE_TYPE"] = "D";
                UpdateHistory();

                bdsVatTuNh.RemoveAt(bdsVatTuNh.Position);
                dtVatTuNh.AcceptChanges();
            }
        }
        void DeleteVt()
        {
            if (bdsVatTu.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsVatTu.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLCheckExist("ARGIABAN", "Ma_Vt", drCurrent["Ma_Vt"]))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
                    "Vật tư : {" + drCurrent["Ten_Vt"].ToString() + "}  đang sử dụng ở bảng giá vật tư" :
                    "Item : {" + drCurrent["Ten_Vt"].ToString() + "}  is using in item cost table";

                Common.MsgOk(strMsg);
                return;
            }

            if (DataTool.SQLCheckExist("vw_TheKho", strCode, drCurrent[strCode]))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
                    "Vật tư: {" + drCurrent[strName].ToString() + "}  đã được sử dụng trong chứng từ" :
                    "Item: {" + drCurrent[strName].ToString() + "}  used in voucher";

                Common.MsgCancel(strMsg);
                return;
            }

            if (DataTool.SQLCheckExist("INDUDAU", strCode, drCurrent[strCode]))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
                    "Vật tư: {" + drCurrent[strName].ToString() + "}  đã được sử dụng trong tồn kho đầu kỳ" :
                    "Item: {" + drCurrent[strName].ToString() + "}  used in opening balance";

                Common.MsgCancel(strMsg);
                return;
            }

            if (DataTool.SQLDelete("LIVATTU", drCurrent))
            {
                htHistory["DIEN_GIAI"] = "Danh mục vật tư";
                strTableName = "LIVATTU";
                strCode = "MA_VT";
                strName = "TEN_VT";

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
                //        DataToolSync1.SQLDelete("LIVATTU", drCurrent);
                //    }
                //}
                ////-----------------------

                //Cập nhật History
                htHistory["CODE"] = drCurrent[strCode];
                htHistory["NAME"] = drCurrent[strName];
                htHistory["UPDATE_TYPE"] = "D";
                UpdateHistory();

                bdsVatTu.RemoveAt(bdsVatTu.Position);
                dtVatTu.AcceptChanges();
            }
        }
        public override void MergeID()
        {
            if (tlVatTuNh.Focused)
                MergeIDVtNh();
            else if (dgvVatTu.Focused)
                MergeIDVt();
        }
        void MergeIDVtNh()
        {
            if (bdsVatTuNh.Count <= 0)
                return;

            drCurrentVtNh = ((DataRowView)bdsVatTuNh.Current).Row;
            string strOldValue = (string)drCurrentVtNh["Ma_Nh_Vt"];

            frmMergeID frm = new frmMergeID();

            frm.Load("LIVATTUNH", "Ma_Nh_Vt", "Ten_Nh_Vt", strOldValue, "VatTuNh");

            if (frm.isAccept)
            {
                string strNewValue = frm.strNewValue;
                string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
                if (!Common.MsgYes_No(strMsg))
                    return;

                if (DataTool.SQLMergeID("Ma_Nh_Vt", "LIVATTUNH", strOldValue, strNewValue))
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
                    //        DataToolSync1.SQLMergeID("Ma_Nh_Vt", "LIVATTUNH", strOldValue, strNewValue);
                    //    }
                    //}
                    ////----------------------

                    //Cập nhật History
                    htHistory["CODE"] = drCurrentVtNh["Ma_Nh_Vt"];
                    htHistory["NAME"] = drCurrentVtNh["Ten_Nh_Vt"];
                    htHistory["UPDATE_TYPE"] = "D";
                    UpdateHistory();

                    bdsVatTuNh.RemoveCurrent();
                    bdsVatTuNh.Position = bdsVatTuNh.Find("Ma_Nh_Vt", strNewValue);
                }
            }
        }
        void MergeIDVt()
        {
            if (bdsVatTu.Count <= 0)
                return;

            drCurrent = ((DataRowView)bdsVatTu.Current).Row;
            string strOldValue = (string)drCurrent["Ma_Vt"];

            frmMergeID frm = new frmMergeID();

            frm.Load("LIVATTU", "Ma_Vt", "Ten_Vt", strOldValue, "VatTu");

            if (frm.isAccept)
            {
                string strNewValue = frm.strNewValue;
                string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
                if (!Common.MsgYes_No(strMsg))
                    return;

                if (DataTool.SQLMergeID("Ma_Vt", "LIVATTU", strOldValue, strNewValue))
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
                    //        DataToolSync1.SQLMergeID("Ma_Vt", "LIVATTU", strOldValue, strNewValue);
                    //    }
                    //}
                    ////----------------------

                    //Cập nhật History
                    htHistory["CODE"] = drCurrent["Ma_Vt"];
                    htHistory["NAME"] = drCurrent["Ten_Vt"];
                    htHistory["UPDATE_TYPE"] = "D";
                    UpdateHistory();

                    bdsVatTu.RemoveCurrent();
                    bdsVatTu.Position = bdsVatTu.Find("Ma_Vt", strNewValue);
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
            dgvExport.strZone = "VatTuNh";
            dgvExport.BuildGridView();
            dgvExport.DataSource = bdsVatTuNh;

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