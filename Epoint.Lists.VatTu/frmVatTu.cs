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
using Epoint.Systems;
using Epoint.Systems.Elements;

namespace Epoint.Lists
{
    public partial class frmVatTu : Epoint.Lists.frmView
    {
        #region Khai bao bien

        private DataTable dtVatTu;
        private DataRow drCurrent;
        private BindingSource bdsVatTu = new BindingSource();
        //private dgvControl dgvVatTu = new dgvControl();
        private dgvGridControl dgvVatTu = new dgvGridControl();
        public string strMa_Nh_Vt = string.Empty;
        public bool bLastLookupProcess = false;
        public bool bFind = false;

        #endregion

        #region Contructor
        public frmVatTu()
        {
            InitializeComponent();

            this.dgvVatTu.dgvGridView.DoubleClick += new EventHandler(dgvVatTu_CellMouseDoubleClick);
        }

        public override void Load()
        {
            Init();
            Build();
            FillData();
            BindingLanguage();

            if (this.isLookup)
                this.ShowDialog();
            else
                this.Show();
        }

        public void Load(string strMa_Nh_Vt)
        {
            this.strMa_Nh_Vt = strMa_Nh_Vt;

            this.Load();
        }

        public override void LoadLookup()
        {
            if (!bLastLookupProcess && ((string)Parameters.GetParaValue("ACCESS_VT")).Trim() == "1")
            {
                string strWhere = this.strLookupColumn + " LIKE '" + this.strLookupValue + "%'";

                if (this.strLookupKeyFilter != string.Empty && this.strLookupKeyFilter != null)
                {
                    if (this.strLookupValue == "/" || this.strLookupValue == @"\")
                        strWhere = strLookupKeyFilter;
                    else
                        strWhere = "(" + strLookupKeyFilter + ") AND (" + strWhere + ")";
                }

                DataTable dtFind = DataTool.SQLGetDataTable("LIVATTU", null, strWhere, null);

                if (dtFind.Rows.Count > 0)
                {
                    strLookupKeyFilter = strWhere;
                    bFind = true;
                    this.Load();
                }
                else
                    this.LoadLookupByGroup();
            }
            else
                this.Load();
        }

        private void LoadLookupByGroup()
        {//Lookup theo nhom

            string strValue = string.Empty;
            bool bRequire = this.bLookupRequire;
            string strKeyFilter = this.strLookupKeyFilter;

            frmVatTuNh frmLookup = new frmVatTuNh();
            frmLookup.bEnterFinish = false;

            Lookup.ShowLookup(frmLookup, "LIVATTUNH", "Ma_Nh_Vt", strValue, bRequire, "", "Nh_Cuoi = 1");

            this.bIsEnter = frmLookup.bIsEnter;
            this.drLookup = frmLookup.drLookup;
            this.Close();
        }
        private void Init()
        {
            htHistory["DIEN_GIAI"] = "Danh mục vật tư";
            strTableName = "LIVATTU";
            strCode = "MA_VT";
            strName = "TEN_VT";
        }
        #endregion

        #region Build, FillData
        private void Build()
        {
            dgvVatTu.Dock = DockStyle.Fill;
            dgvVatTu.strZone = "VatTu";
           
            if (isLookup)
            {
                this.splitContainer.Panel2.Controls.Add(splControl1);
                this.splControl1.Panel1.Controls.Add(dgvVatTu);
            }
            else
            {
                this.splControl1.Panel1.Controls.Add(dgvVatTu);
            }

            dgvVatTu.strZone = "VatTu";
            dgvVatTu.BuildGridView(this.isLookup);

            ExportControl = dgvVatTu;
        }

        public void FillData()
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
            if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
                return;

            for (int i = 0; i <= dtVatTu.Rows.Count - 1; i++)
                if (((string)dtVatTu.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
                {
                    bdsVatTu.Position = i;
                    break;
                }
        }
        #endregion

        #region Update

        public override void Edit(enuEdit enuNew_Edit)
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

            if (DataTool.SQLDelete("LIVATTU", drCurrent))
            {
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
                    bdsVatTu.RemoveCurrent();
                    bdsVatTu.Position = bdsVatTu.Find("Ma_Vt", strNewValue);
                }
            }
        }

        #endregion

        #region EnterProcess

        bool EnterValid()
        {
            if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
                return true;

            if (bdsVatTu == null || bdsVatTu.Position < 0)
                return false;

            drCurrent = ((DataRowView)bdsVatTu.Current).Row;
            DataTable dtTemp = dtVatTu.Clone();
            dtTemp.ImportRow(drCurrent);

            if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
                return true;
            else
                return false;

        }

        public override void EnterProcess()
        {
            if (bdsVatTu.Position < 0)
                return;

            if (isLookup && EnterValid())
            {
                drLookup = ((DataRowView)bdsVatTu.Current).Row;
                this.Close();
            }
        }

        #endregion

        #region Su kien

        void dgvVatTu_CellMouseDoubleClick(object sender, EventArgs e)
        {
            if (this.isLookup)
                this.EnterProcess();
            else
                this.Edit(enuEdit.Edit);
        }

        protected override void OnClosed(EventArgs e)
        {
            if (bFind && !this.bIsEnter)
                LoadLookupByGroup();

            base.OnClosed(e);
        }

        #endregion
    }

}