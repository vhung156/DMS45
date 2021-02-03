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
    public partial class frmVatTuNh : Epoint.Lists.frmView
    {

        #region Khai bao bien
        private DataTable dtVatTuNh;
		private DataRow drCurrent;
		private BindingSource bdsVatTuNh = new BindingSource();
		private tlControl tlVatTuNh = new tlControl();
		
        public bool bEnterFinish = true;

        #endregion         

		#region Contructor
		public frmVatTuNh()
        {
			InitializeComponent();

			this.tlVatTuNh.MouseDoubleClick += new MouseEventHandler(tlVatTuNh_MouseDoubleClick);
        }

		public override void Load()
		{
            this.Init();
            this.Build();
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
            htHistory["DIEN_GIAI"] = "Danh mục nhóm vật tư";
            strTableName = "LIVATTUNH";
            strCode = "MA_NH_VT";
            strName = "TEN_NH_VT";
        }
		
		#endregion

		#region Build, FillData
		private void Build()
        {
			tlVatTuNh.KeyFieldName = "MA_NH_VT";
			tlVatTuNh.ParentFieldName = "MA_NH_VT_CHA";
			tlVatTuNh.Dock = DockStyle.Fill;

            if (isLookup)
            {
                this.splitContainer.Panel2.Controls.Add(splControl1);
                this.splControl1.Panel1.Controls.Add(tlVatTuNh);
            }
            else
            {
                this.splControl1.Panel1.Controls.Add(tlVatTuNh);
            }
			tlVatTuNh.strZone = "VatTuNh";
			tlVatTuNh.BuildTreeList(this.isLookup);			

            //this.Controls.Add(tlVatTuNh);
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
			if (bdsVatTuNh.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsVatTuNh.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsVatTuNh.Current).Row, ref drCurrent);
			else
				drCurrent = dtVatTuNh.NewRow();

			frmVatTuNh_Edit frmEdit = new frmVatTuNh_Edit();
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
						dtVatTuNh.ImportRow(drCurrent);
					else
						dtVatTuNh.Rows.Add(drCurrent);

					bdsVatTuNh.Position = bdsVatTuNh.Find("Ma_Nh_Vt", drCurrent["Ma_Nh_Vt"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsVatTuNh.Current).Row);

				dtVatTuNh.AcceptChanges();
			}
			//else
			//    dtVatTuNh.RejectChanges();
		}

        public override void Delete()
        {
            if(bdsVatTuNh.Position < 0)
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
                //Cập nhật History
                htHistory["CODE"] = drCurrent[strCode];
                htHistory["NAME"] = drCurrent[strName];
                htHistory["UPDATE_TYPE"] = "D";
                UpdateHistory();

                bdsVatTuNh.RemoveAt(bdsVatTuNh.Position);
                dtVatTuNh.AcceptChanges();
            }
		}

		public override void MergeID()
		{
			if (bdsVatTuNh.Count <= 0)
				return;

			drCurrent = ((DataRowView)bdsVatTuNh.Current).Row;
			string strOldValue = (string)drCurrent["Ma_Nh_Vt"];

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
					bdsVatTuNh.RemoveCurrent();
					bdsVatTuNh.Position = bdsVatTuNh.Find("Ma_Nh_Vt", strNewValue);
				}
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if(bdsVatTuNh == null || bdsVatTuNh.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsVatTuNh.Current).Row;
			DataTable dtTemp = dtVatTuNh.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsVatTuNh.Position < 0)
				return;

			if (isLookup && EnterValid())
			{

				if (bEnterFinish)
				{
					drLookup = ((DataRowView)bdsVatTuNh.Current).Row;
					this.Close();
				}
				else
				{
					//Hien thi lookup danh muc vat tu
					drCurrent = ((DataRowView)bdsVatTuNh.Current).Row;

					string strValue = this.strLookupValue;
					bool bRequire = this.bLookupRequire;
					string strKeyFilter = "Ma_Nh_Vt ='" + ((string)(drCurrent["Ma_Nh_Vt"])).Trim() + "'";

                    frmVatTu frmLookup = new frmVatTu();
					frmLookup.bLastLookupProcess = true;
					frmLookup.MdiParent = this.MdiParent;
					frmLookup.strMa_Nh_Vt = ((string)(drCurrent["Ma_Nh_Vt"])).Trim();

					Lookup.ShowLookup(frmLookup, "LIVATTU", "Ma_Vt", strValue, bRequire, strKeyFilter);

					if (!frmLookup.bIsEnter)
						return;

					this.drLookup = frmLookup.drLookup;
					this.Close();
				}
			}
			else
			{
				//Hien thi danh muc vat tu binh thuong khi nhan Enter				   
				drCurrent = ((DataRowView)bdsVatTuNh.Current).Row;
				if ((Boolean)(drCurrent["Nh_Cuoi"]) == true)
				{
                    frmVatTu frmEdit = new frmVatTu();

                    frmEdit.MdiParent = this.MdiParent;
                    frmEdit.Load(((string)(drCurrent["Ma_Nh_Vt"])).Trim());

                    frmEdit.Show();
                    Common.AddFormOnCurentTab(frmEdit);
				}
			}
		}		

        #endregion 

        #region Su kien 
        
		void tlVatTuNh_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.EnterProcess();
		}
       
        #endregion 
    }
}