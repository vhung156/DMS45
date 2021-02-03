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
    public partial class frmTuyen : Epoint.Lists.frmView
	{		

		#region Khai bao bien
		DataTable dtTuyen;
		DataRow drCurrent;
		BindingSource bdsTuyen = new BindingSource();
		tlControl tlTuyen = new tlControl();

		#endregion 				

		#region Contructor
		
		public frmTuyen()
		{
			InitializeComponent();

			tlTuyen.MouseDoubleClick += new MouseEventHandler(tlTuyen_MouseDoubleClick);            
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
			this.Load();
		}
        private void Init()
        {
            htHistory["DIEN_GIAI"] = "Danh mục tuyến bán hàng";
            strTableName = "LITUYEN";
            strCode = "MA_Tuyen";
            strName = "TEN_TUYEN";
        }

		#endregion

		#region Build, FillData

		private void Build()
		{



			tlTuyen.KeyFieldName = "MA_TUYEN";
			tlTuyen.ParentFieldName = "MA_TUYEN_CHA";
			tlTuyen.Dock = DockStyle.Fill;

			tlTuyen.strZone = "TUYENBH";
			tlTuyen.BuildTreeList(this.isLookup);

            if (isLookup)
            {
                this.splitContainer.Panel2.Controls.Add(splControl1);
                this.splControl1.Panel1.Controls.Add(tlTuyen);
            }
            else
            {
                this.splControl1.Panel1.Controls.Add(tlTuyen);
            }



            ExportControl = tlTuyen;
            //this.Controls.Add(tlTuyen);
		}

		public void FillData()
		{
            dtTuyen = DataTool.SQLGetDataTable("LITUYEN", null, this.strLookupKeyFilter, null);
			bdsTuyen.DataSource = dtTuyen;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsTuyen;
			ExportControl = tlTuyen;

			tlTuyen.DataSource = bdsTuyen;
			bdsTuyen.Position = 0;

			if (this.isLookup)
				this.MoveToLookupValue();

			tlTuyen.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM SYSZONE WHERE ZONE = '" + tlTuyen.strZone + "'");
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtTuyen.Rows.Count - 1; i++)
				if (((string)dtTuyen.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsTuyen.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsTuyen.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsTuyen.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsTuyen.Current).Row, ref drCurrent);
			else
				drCurrent = dtTuyen.NewRow();

			frmTuyen_Edit frmEdit = new frmTuyen_Edit();
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
                else if (enuNew_Edit == enuEdit.Edit && ((string)drHistory[strCode] != (string)((DataRowView)bdsTuyen.Current)[strCode] || (string)drHistory[strName] != (string)((DataRowView)bdsTuyen.Current)[strName]))
                {
                    htHistory["UPDATE_TYPE"] = "E";
                    htHistory["CODE_OLD"] = ((DataRowView)bdsTuyen.Current)[strCode];
                    htHistory["NAME_OLD"] = ((DataRowView)bdsTuyen.Current)[strName];
                    UpdateHistory();
                }
                //Cập nhật dữ liệu danh mục
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsTuyen.Position >= 0)
						dtTuyen.ImportRow(drCurrent);
					else
						dtTuyen.Rows.Add(drCurrent);

                    bdsTuyen.Position = bdsTuyen.Find("MA_TUYEN", drCurrent["MA_TUYEN"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsTuyen.Current).Row);
				
				dtTuyen.AcceptChanges();
			}
			//else
			//    dtBoPhan.RejectChanges();
		}
		
		public override void Delete()
		{
			if (bdsTuyen.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsTuyen.Current).Row;
				
			if( !Common.MsgYes_No( Languages.GetLanguage("SURE_DELETE")))
				return;


            if (DataTool.SQLCheckExist("LITUYEN", "Ma_Tuyen_Cha", drCurrent["MA_TUYEN"]))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
                    "Tuyến: {" + drCurrent["Ten_Tuyen"].ToString() + "}  đang có tuyến con" :
                    "Deparment: {" + drCurrent["Ten_Tuyen"].ToString() + "}  have child deparment";

				Common.MsgCancel(strMsg);
				return;
			}

            //if (DataTool.SQLCheckExist("vw_SoCai", strCode, drCurrent[strCode]))
            //{
            //    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
            //        "Bộ phận: {" + drCurrent[strName].ToString() + "}  đã được sử dụng trong chứng từ" :
            //        "Deparment: {" + drCurrent[strName].ToString() + "}  used in voucher";

            //    Common.MsgCancel(strMsg);
            //    return;
            //}

            if (DataTool.SQLDelete("LITUYEN", drCurrent))
			{
                //Cập nhật History
                htHistory["CODE"] = drCurrent[strCode];
                htHistory["NAME"] = drCurrent[strName];
                htHistory["UPDATE_TYPE"] = "D";
                UpdateHistory();

				bdsTuyen.RemoveAt(bdsTuyen.Position);
				dtTuyen.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			if (bdsTuyen.Count <= 0)
				return;

			drCurrent = ((DataRowView)bdsTuyen.Current).Row;
            string strOldValue = (string)drCurrent["Ma_Tuyen"];

			frmMergeID frm = new frmMergeID();

            frm.Load("LITUYEN", "Ma_Tuyen", "Ten_Tuyen", strOldValue, "TUYENBH");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge {" + strOldValue + "} to {" + strNewValue + "}?" : "Bạn có muốn gộp mã {" + strOldValue + "} sang {" + strNewValue + "} không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

                if (DataTool.SQLMergeID("Ma_Tuyen", "LITUYEN", strOldValue, strNewValue))
				{
					bdsTuyen.RemoveCurrent();
                    bdsTuyen.Position = bdsTuyen.Find("Ma_Tuyen", strNewValue);
				}
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsTuyen == null || bdsTuyen.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsTuyen.Current).Row;
			DataTable dtTemp = dtTuyen.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

		public override void EnterProcess()
		{
			if (bdsTuyen.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsTuyen.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void tlTuyen_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}    

		#endregion 
	}
}