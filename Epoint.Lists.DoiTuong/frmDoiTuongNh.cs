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
using Epoint.Systems.Elements;
using Epoint.Systems;

namespace Epoint.Lists
{
    public partial class frmDoiTuongNh : Epoint.Lists.frmView
    {
        #region Khai bao bien
        private DataTable dtDoiTuongNh;
		private DataRow drCurrent;
		private BindingSource bdsDoiTuongNh = new BindingSource();
		private tlControl tlDoiTuongNh = new tlControl();

		public bool bEnterFinish = true;
		
        #endregion         

		#region Contructor
		public frmDoiTuongNh()
        {
			InitializeComponent();

			this.tlDoiTuongNh.MouseDoubleClick += new MouseEventHandler(tlDoiTuongNh_MouseDoubleClick);
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

		public override void LoadLookup()
		{
			this.isLookup = true;
			this.Load();
		}

        private void Init()
        {
            htHistory["DIEN_GIAI"] = "Danh mục nhóm đối tượng";
            strTableName = "LIDOITUONGNH";
            strCode = "MA_NH_DT";
            strName = "TEN_NH_DT";
        }
		#endregion

		#region Build, FillData
		void Build()
        {
			tlDoiTuongNh.KeyFieldName = "MA_NH_DT";
			tlDoiTuongNh.ParentFieldName = "MA_NH_DT_CHA";
            tlDoiTuongNh.Dock = DockStyle.Fill;
            if (isLookup)
            {
                this.splitContainer.Panel2.Controls.Add(splControl1);
                this.splControl1.Panel1.Controls.Add(tlDoiTuongNh);
            }
            else
            {
                this.splControl1.Panel1.Controls.Add(tlDoiTuongNh);
            }

            //dgvDoiTuong.strZone = "DoiTuong";
            //dgvDoiTuong.BuildGridView(this.isLookup);

            //ExportControl = dgvDoiTuong;


			

            //this.Controls.Add(tlDoiTuongNh);

			tlDoiTuongNh.strZone = "DoiTuongNh";
			tlDoiTuongNh.BuildTreeList(this.isLookup);
            ExportControl = tlDoiTuongNh;
            tlDoiTuongNh.Focus();
        }

		void FillData()
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

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
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
            if (bdsDoiTuongNh.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;            

            //Copy hang hien tai
			if (bdsDoiTuongNh.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDoiTuongNh.Current).Row, ref drCurrent);
			else
				drCurrent = dtDoiTuongNh.NewRow();
            
            frmDoiTuongNh_Edit frmEdit = new frmDoiTuongNh_Edit();
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
						dtDoiTuongNh.ImportRow(drCurrent);
					else
						dtDoiTuongNh.Rows.Add(drCurrent);

					bdsDoiTuongNh.Position = bdsDoiTuongNh.Find("Ma_Nh_Dt", drCurrent["Ma_Nh_Dt"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDoiTuongNh.Current).Row);					

				dtDoiTuongNh.AcceptChanges();
			}
			else
				dtDoiTuongNh.RejectChanges();
        }

        public override void Delete()
        {
            if(bdsDoiTuongNh.Position < 0)
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
                //Cập nhật History
                htHistory["CODE"] = drCurrent[strCode];
                htHistory["NAME"] = drCurrent[strName];
                htHistory["UPDATE_TYPE"] = "D";
                UpdateHistory();
                
                bdsDoiTuongNh.RemoveAt(bdsDoiTuongNh.Position);
				dtDoiTuongNh.AcceptChanges();
            }
		}

		public override void MergeID()
		{
			if (bdsDoiTuongNh.Count <= 0)
				return;

			drCurrent = ((DataRowView)bdsDoiTuongNh.Current).Row;
			string strOldValue = (string)drCurrent["Ma_Nh_Dt"];

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
					bdsDoiTuongNh.RemoveCurrent();
					bdsDoiTuongNh.Position = bdsDoiTuongNh.Find("Ma_Nh_Dt", strNewValue);
				}
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if(bdsDoiTuongNh == null || bdsDoiTuongNh.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDoiTuongNh.Current).Row;
			DataTable dtTemp = dtDoiTuongNh.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}
		
		public override void EnterProcess()
		{
			if (bdsDoiTuongNh.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				if (bEnterFinish)
				{
					this.drLookup = ((DataRowView)bdsDoiTuongNh.Current).Row;
					this.Close();
				}
				else
				{
					drCurrent = ((DataRowView)bdsDoiTuongNh.Current).Row;

					string strValue = this.strLookupValue;
					bool bRequire = this.bLookupRequire;
					string strKeyFilter = "Ma_Nh_Dt ='" + ((string)(drCurrent["Ma_Nh_Dt"])).Trim() + "'";

					//Hien thi lookup danh muc doi tuong
                    frmDoiTuong frm = new frmDoiTuong();
					frm.bLastLookupProcess = true;
					frm.MdiParent = this.MdiParent;
					frm.strMa_Nh_Dt = ((string)(drCurrent["Ma_Nh_Dt"])).Trim();

					Lookup.ShowLookup(frm, "LIDOITUONG", "Ma_Dt", strValue, bRequire, strKeyFilter);

					if (!frm.bIsEnter)
						return;

					this.drLookup = frm.drLookup;
					this.Close();
				}
			}
			else
			{
				//Hien thi danh muc doi tuong binh thuong khi nhan Enter				   
				drCurrent = ((DataRowView)bdsDoiTuongNh.Current).Row;
				if ((Boolean)(drCurrent["Nh_Cuoi"]) == true)
				{
                    frmDoiTuong frmEdit = new frmDoiTuong();

					frmEdit.MdiParent = this.MdiParent;
					frmEdit.Load(((string)(drCurrent["Ma_Nh_Dt"])).Trim());
                    
                    frmEdit.Show();
                    Common.AddFormOnCurentTab(frmEdit);
				}
			}
		}

        #endregion 

        #region Su kien 
        
		void tlDoiTuongNh_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.EnterProcess();
		}    
       
        #endregion 		
    }
}