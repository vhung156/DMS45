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
    public partial class frmDiscountManual : Epoint.Systems.Customizes.frmView
    {

        string strMa_CTKM = String.Empty;
        string strStt = String.Empty;
        DataTable dtImport;
        string strError = string.Empty;


        DataSet dsDiscountProg;

        DataTable dtDiscountProg;
        BindingSource bdsDiscountProg = new BindingSource();
        DataRow drCurrentDicsProg;


        

        public frmDiscountManual()
        {
            InitializeComponent();

            bdsDiscountProg.PositionChanged += new EventHandler(bdsDiscountProg_PositionChanged);
            this.dgvDiscountProg.dgvGridView.DoubleClick += new EventHandler(dgvDiscountProg_CellMouseDoubleClick);
            this.btFillterData.Click += new EventHandler(btFillData_Click);
        }



        public override void Load()
        {
            this.Build();
            this.FillData();

            if (this.isLookup)
                this.ShowDialog();
            else
                this.Show();
        }
        public override void LoadLookup()
        {
            this.Load();
        }
        private void Build()
        {
            dgvDiscountProg.strZone = "OM_DISCOUNT";
            dgvDiscountProg.BuildGridView(this.isLookup);
            ExportControl = dtDiscountProg;
            dteNgay_BD.Text =Library.DateToStr( Epoint.Systems.Elements.Element.sysNgay_Ct1);
            dteNgay_Kt.Text = Library.DateToStr(Epoint.Systems.Elements.Element.sysNgay_Ct2);

       
           
        }

        private void FillData()
        {
            dsDiscountProg = Discount.GetDiscoutProgManual(dteNgay_BD.Text, dteNgay_Kt.Text);

            dtDiscountProg = dsDiscountProg.Tables[0];
            bdsDiscountProg.DataSource = dtDiscountProg;
            dgvDiscountProg.DataSource = bdsDiscountProg;

            //Uy quyen cho lop co so tim kiem
            bdsSearch = bdsDiscountProg;
            ExportControl = dgvDiscountProg;

            if (bdsDiscountProg.Count >= 0)
                bdsDiscountProg.Position = 0;

           
        }

        public override void Edit(enuEdit enuNew_Edit)
        {
            if (dgvDiscountProg.Focused)
                EditDiscountProg(enuNew_Edit);
           
        }
        private void EditDiscountProg(enuEdit enuNew_Edit)
        {
            if (bdsDiscountProg.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai
            if (bdsDiscountProg.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsDiscountProg.Current).Row, ref drCurrentDicsProg);
            else
                drCurrentDicsProg = dtDiscountProg.NewRow();

            frmDiscountConfig_Edit frmEdit = new frmDiscountConfig_Edit();
            frmEdit.Load(enuNew_Edit, drCurrentDicsProg);

            //Accept
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
                {
                    if (bdsDiscountProg.Position >= 0)
                        dtDiscountProg.ImportRow(drCurrentDicsProg);
                    else
                        dtDiscountProg.Rows.Add(drCurrentDicsProg);

                    bdsDiscountProg.Position = bdsDiscountProg.Find("Ma_CTKM", drCurrentDicsProg["Ma_CTKM"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrentDicsProg, ((DataRowView)bdsDiscountProg.Current).Row);
                }

                dtDiscountProg.AcceptChanges();
            }
            else
                dtDiscountProg.RejectChanges();

        }
        void dgvDiscountProg_CellMouseDoubleClick(object sender, EventArgs e)
        {
            if (this.isLookup)
                this.EnterProcess();
            else
                this.Edit(enuEdit.Edit);
        }

        public override void EnterProcess()
        {
            if (bdsDiscountProg.Position < 0)
                return;

            if (isLookup && EnterValid())
            {
                drLookup = ((DataRowView)bdsDiscountProg.Current).Row;
                this.Close();
            }
        }
        bool EnterValid()
        {
            if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
                return true;

            if (bdsDiscountProg == null || bdsDiscountProg.Position < 0)
                return false;

            return true;
        }
        public override void Delete()
        {
            if (dgvDiscountProg.Focused)
                DeleteDiscountProg();           
        }


        private void DeleteDiscountProg()
        {
            if (bdsDiscountProg.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsDiscountProg.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;


            Hashtable htPara = new Hashtable();
            htPara["MA_CTKM"] = drCurrent["MA_CTKM"].ToString();
            bool isCheck = Convert.ToBoolean(SQLExec.ExecuteReturnValue("sp_DELETE_DISCOUNT", htPara, CommandType.StoredProcedure));
            if (isCheck)
            {
                bdsDiscountProg.RemoveAt(bdsDiscountProg.Position);
                dtDiscountProg.AcceptChanges();
            }
            else
            {
                EpointMessage.MsgOk("Chương trình khuyến mãi/ Chiết khấu đã được sử dụng");
            }
        }
        #region Sự kiện

        void bdsDiscountProg_PositionChanged(object sender, EventArgs e)
        {           
            if (bdsDiscountProg.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsDiscountProg.Current).Row, ref drCurrentDicsProg);

            this.strMa_CTKM = drCurrentDicsProg["Ma_CTKM"].ToString();
            string strLoai_Km = drCurrentDicsProg["Loai_KM"].ToString();
            string strLoai_Ap_KM = drCurrentDicsProg["Loai_Ap_KM"].ToString();           


        }
        void btFillData_Click(object sender, EventArgs e)
        {
            FillData();
        }
        

        #endregion
    }
}
