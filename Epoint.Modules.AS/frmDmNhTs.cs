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
    public partial class frmDmNhTs : Epoint.Systems.Customizes.frmView
    {
        #region Khai bao bien
        private DataTable dtDmNhTs;
        private DataRow drCurrent;
        private BindingSource bdsDmNhTs = new BindingSource();
        private tlControl tlDmNhTs = new tlControl();

        public bool bEnterFinish = true;

        #endregion

        #region Contructor
        public frmDmNhTs()
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
            tlDmNhTs.KeyFieldName = "MA_NH_TS";
            tlDmNhTs.ParentFieldName = "MA_NH_TS_CHA";
            tlDmNhTs.Dock = DockStyle.Fill;

            this.Controls.Add(tlDmNhTs);

            tlDmNhTs.strZone = "DMNHTS";
            tlDmNhTs.BuildTreeList(this.isLookup);
        }

		void FillData()
		{
			dtDmNhTs = DataTool.SQLGetDataTable("ASTSNH", null, this.strLookupKeyFilter, null);

			bdsDmNhTs.DataSource = dtDmNhTs;
			tlDmNhTs.DataSource = bdsDmNhTs;

			bdsDmNhTs.Filter = "Loai_Nh IN ('1')";

			//Uy quyen cho lop co so tim kiem
			bdsSearch = bdsDmNhTs;
			ExportControl = tlDmNhTs;

			tlDmNhTs.ExpandAll();

			if (bdsDmNhTs.Count >= 0)
				bdsDmNhTs.Position = 0;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

        private void MoveToLookupValue()
        {
            if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
                return;

            for (int i = 0; i <= dtDmNhTs.Rows.Count - 1; i++)
                if (((string)dtDmNhTs.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
                {
                    bdsDmNhTs.Position = i;
                    break;
                }
        }
        #endregion

        #region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmNhTs.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai
			if (bdsDmNhTs.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmNhTs.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmNhTs.NewRow();

			frmDmNhTs_Edit frmEdit = new frmDmNhTs_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
					if (bdsDmNhTs.Position >= 0)
						dtDmNhTs.ImportRow(drCurrent);
					else
						dtDmNhTs.Rows.Add(drCurrent);
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmNhTs.Current).Row);

					string strMa_Nh_Ts = (string)drCurrent["Ma_Nh_Ts"];
					string strMa_Nh_Ts_Old = (string)drCurrent["Ma_Nh_Ts", DataRowVersion.Original];
					if (strMa_Nh_Ts != strMa_Nh_Ts_Old)
					{
						DataRow[] drArr = dtDmNhTs.Select("Ma_Nh_Ts_Cha = '" + strMa_Nh_Ts_Old + "'");
						for (int i = 0; i < drArr.Length; i++)
						{
							drArr[i]["Ma_Nh_Ts_Cha"] = strMa_Nh_Ts;
						}
					}
				}

				dtDmNhTs.AcceptChanges();
			}
			else
				dtDmNhTs.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmNhTs.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmNhTs.Current).Row;

			if (DataTool.SQLCheckExist("ASTSNH", "Ma_Nh_Ts_Cha", drCurrent["Ma_Nh_Ts"]))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
					"Nhóm tài sản: {" + drCurrent["Ten_Nh_Ts"].ToString() + "}  đang có nhóm con" :
					"Asset group: {" + drCurrent["Ten_Nh_Ts"].ToString() + "}  have child group";

				Common.MsgCancel(strMsg);
				return;
			}

			if (DataTool.SQLCheckExist("ASTS", "Ma_Nh_Ts", drCurrent["Ma_Nh_Ts"]))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
					"Nhóm tài sản: {" + drCurrent["Ten_Nh_Ts"].ToString() + "}  đang có tài sản" :
					"Asset group : {" + drCurrent["Ten_Nh_Ts"].ToString() + "}  have asset";

				Common.MsgCancel(strMsg);
				return;
			}

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("ASTSNH", drCurrent))
			{
				bdsDmNhTs.RemoveAt(bdsDmNhTs.Position);
				dtDmNhTs.AcceptChanges();
			}
		}

        #endregion

        #region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmNhTs == null || bdsDmNhTs.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmNhTs.Current).Row;
			DataTable dtTemp = dtDmNhTs.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

		public override void  EnterProcess()
		{
			if (bdsDmNhTs.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				if (bEnterFinish)
				{
					this.drLookup = ((DataRowView)bdsDmNhTs.Current).Row;
					this.Close();
				}
				else
				{
					drCurrent = ((DataRowView)bdsDmNhTs.Current).Row;

					string strValue = this.strLookupValue;
					bool bRequire = this.bLookupRequire;
					string strKeyFilter = "Ma_Nh_Ts ='" + ((string)(drCurrent["Ma_Nh_Ts"])).Trim() + "'";

					//Hien thi Danh muc tai san
					frmCtTs frm = new frmCtTs();
					frm.bLastLookupProcess = true;
					//frm.MdiParent = this.MdiParent;

					Lookup.ShowLookup(frm, "ASTS", "Ma_Ts", strValue, bRequire, strKeyFilter);

					if (!frm.bIsEnter)
						return;

					this.drLookup = frm.drLookup;
					this.Close();
				}
			}
			else
			{
				//Hien thi danh muc TS binh thuong khi nhan Enter				   
				drCurrent = ((DataRowView)bdsDmNhTs.Current).Row;
				if ((string)(drCurrent["Nh_Cuoi"]) == "1")
				{
					frmCtTs frmEdit = new frmCtTs();

					frmEdit.MdiParent = this.MdiParent;
					frmEdit.Load(((string)(drCurrent["Ma_Nh_Ts"])).Trim());

                    frmEdit.Show();
                    Common.AddFormOnCurentTab(frmEdit);
				}
			}
		}

        #endregion

        #region Su kien

		private void frmDmNhTs_Resize(object sender, EventArgs e)
		{
			tlDmNhTs.ResizeTreeList();
		}

        #endregion
    }
}