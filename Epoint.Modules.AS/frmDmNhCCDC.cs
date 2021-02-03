using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Elements;

namespace Epoint.Modules.AS
{
    public partial class frmDmNhCCDC : Epoint.Systems.Customizes.frmView
    {
        #region Khai bao bien
        private DataTable dtDmNhCCDC;
        private DataRow drCurrent;
        private BindingSource bdsDmNhCCDC = new BindingSource();
        private tlControl tlDmNhCCDC = new tlControl();

        public bool bEnterFinish = true;

        #endregion

        #region Contructor
        public frmDmNhCCDC()
        {
            InitializeComponent();
        }

        public override void Load()
        {
            Build();
            FillData();
            BindingLanguage();

            if (this.isLookup)
                this.ShowDialog();
            else
                this.Show();
        }

        public override void LoadLookup()
        {
            this.isLookup = true;
            this.Load();
        }

        #endregion

        #region Build, FillData
        void Build()
        {
            tlDmNhCCDC.KeyFieldName = "MA_NH_TS";
            tlDmNhCCDC.ParentFieldName = "MA_NH_TS_CHA";
            tlDmNhCCDC.Dock = DockStyle.Fill;

            this.Controls.Add(tlDmNhCCDC);

            tlDmNhCCDC.strZone = "DMNHCCDC";
            tlDmNhCCDC.BuildTreeList(this.isLookup);
        }

		void FillData()
		{
            dtDmNhCCDC = DataTool.SQLGetDataTable("ASTSNH", null, this.strLookupKeyFilter, null);

			bdsDmNhCCDC.DataSource = dtDmNhCCDC;
            bdsDmNhCCDC.Position = 0;
            bdsDmNhCCDC.Filter = "Loai_Nh IN ('2')";

			tlDmNhCCDC.DataSource = bdsDmNhCCDC;

			//Uy quyen cho lop co so tim kiem
			bdsSearch = bdsDmNhCCDC;
			ExportControl = tlDmNhCCDC;

			tlDmNhCCDC.ExpandAll();

			if (bdsDmNhCCDC.Count >= 0)
				bdsDmNhCCDC.Position = 0;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

        private void MoveToLookupValue()
        {
            if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
                return;

            for (int i = 0; i <= dtDmNhCCDC.Rows.Count - 1; i++)
                if (((string)dtDmNhCCDC.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
                {
                    bdsDmNhCCDC.Position = i;
                    break;
                }
        }
        #endregion

        #region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmNhCCDC.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai
			if (bdsDmNhCCDC.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmNhCCDC.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmNhCCDC.NewRow();

			frmDmNhCCDC_Edit frmEdit = new frmDmNhCCDC_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
					if (bdsDmNhCCDC.Position >= 0)
						dtDmNhCCDC.ImportRow(drCurrent);
					else
						dtDmNhCCDC.Rows.Add(drCurrent);
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmNhCCDC.Current).Row);

					string strMa_Nh_Ts = (string)drCurrent["Ma_Nh_Ts"];
					string strMa_Nh_Ts_Old = (string)drCurrent["Ma_Nh_Ts", DataRowVersion.Original];
					if (strMa_Nh_Ts != strMa_Nh_Ts_Old)
					{
						DataRow[] drArr = dtDmNhCCDC.Select("Ma_Nh_Ts_Cha = '" + strMa_Nh_Ts_Old + "'");
						for (int i = 0; i < drArr.Length; i++)
						{
							drArr[i]["Ma_Nh_Ts_Cha"] = strMa_Nh_Ts;
						}
					}
				}

				dtDmNhCCDC.AcceptChanges();
			}
			else
				dtDmNhCCDC.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmNhCCDC.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmNhCCDC.Current).Row;

			if (DataTool.SQLCheckExist("ASTSNH", "Ma_Nh_Ts_Cha", drCurrent["Ma_Nh_Ts"]))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
					"Nhóm CCDC: {" + drCurrent["Ten_Nh_Ts"].ToString() + "}  đang có nhóm con" :
					"Asset group: {" + drCurrent["Ten_Nh_Ts"].ToString() + "}  have child group";

				Common.MsgCancel(strMsg);
				return;
			}

			if (DataTool.SQLCheckExist("ASTS", "Ma_Nh_Ts", drCurrent["Ma_Nh_Ts"]) || DataTool.SQLCheckExist("ASCCDC", "Ma_Nh_Ts", drCurrent["Ma_Nh_Ts"]))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
					"Nhóm CCDC: {" + drCurrent["Ten_Nh_Ts"].ToString() + "}  đang có CCDC" :
					"Asset group : {" + drCurrent["Ten_Nh_Ts"].ToString() + "}  have asset";

				Common.MsgCancel(strMsg);
				return;
			}

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("ASTSNH", drCurrent))
			{
				bdsDmNhCCDC.RemoveAt(bdsDmNhCCDC.Position);
				dtDmNhCCDC.AcceptChanges();
			}
		}

        #endregion

        #region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmNhCCDC == null || bdsDmNhCCDC.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmNhCCDC.Current).Row;
			DataTable dtTemp = dtDmNhCCDC.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

		public override void  EnterProcess()
		{
			if (bdsDmNhCCDC.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				if (bEnterFinish)
				{
					this.drLookup = ((DataRowView)bdsDmNhCCDC.Current).Row;
					this.Close();
				}
				else
				{
					drCurrent = ((DataRowView)bdsDmNhCCDC.Current).Row;

					string strValue = this.strLookupValue;
					bool bRequire = this.bLookupRequire;
					string strKeyFilter = "Ma_Nh_Ts ='" + ((string)(drCurrent["Ma_Nh_Ts"])).Trim() + "'";

					//Hien thi lookup danh muc doi tuong
                    frmCtCCDC frm = new frmCtCCDC();
					frm.bLastLookupProcess = true;
					frm.MdiParent = this.MdiParent;

					Lookup.ShowLookup(frm, "ASCCDC", "Ma_CCDC", strValue, bRequire, strKeyFilter);

					if (!frm.bIsEnter)
						return;

					this.drLookup = frm.drLookup;
					this.Close();
				}
			}
			else
			{
				//Hien thi danh muc CCDC binh thuong khi nhan Enter				   
				drCurrent = ((DataRowView)bdsDmNhCCDC.Current).Row;
				if ((string)(drCurrent["Nh_Cuoi"]) == "1")
				{
                    frmCtCCDC frmEdit = new frmCtCCDC();

					frmEdit.MdiParent = this.MdiParent;
					frmEdit.Load(((string)(drCurrent["Ma_Nh_Ts"])).Trim());

                    frmEdit.Show();
                    Common.AddFormOnCurentTab(frmEdit);
				}
			}
		}

        #endregion

        #region Su kien

		private void frmDmNhCCDC_Resize(object sender, EventArgs e)
		{
			tlDmNhCCDC.ResizeTreeList();
		}

        #endregion
    }
}