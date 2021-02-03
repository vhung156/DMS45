using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;

namespace Epoint.Lists
{
	public partial class frmNhanVien : Epoint.Lists.frmView
	{
		#region Khai bao bien

		private DataTable dtNhanVien;
		private DataRow drCurrent;
		private BindingSource bdsNhanVien = new BindingSource();
		private dgvControl dgvNhanVien = new dgvControl();
		public bool bLookupByGroup = false;

		#endregion 

		#region Contructor
		public frmNhanVien()
		{
			InitializeComponent();

			this.dgvNhanVien.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvNhanVien_CellMouseDoubleClick);
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
            htHistory["DIEN_GIAI"] = "Danh mục nhân viên";
            strTableName = "LINHANVIEN";
            strCode = "MA_CBNV";
            strName = "TEN_CBNV";
        }
		#endregion

		#region Build, FillData
		private void Build()
		{
			dgvNhanVien.Dock = DockStyle.Fill;
          
            if (isLookup)
            {
                this.splitContainer.Panel2.Controls.Add(splControl1);
                this.splControl1.Panel1.Controls.Add(dgvNhanVien);
            }
            else
            {
                this.splControl1.Panel1.Controls.Add(dgvNhanVien);
            }

            dgvNhanVien.strZone = "NhanVien";
            dgvNhanVien.BuildGridView(this.isLookup);

            ExportControl = dgvNhanVien;
		}

		public void FillData()	
		{
			dtNhanVien = DataTool.SQLGetDataTable("LINHANVIEN", null, this.strLookupKeyFilter, null);

            //Khong Luu field Hinh anh
            if (dtNhanVien.Columns.Contains("Hinh"))
                dtNhanVien.Columns.Remove("Hinh");

			bdsNhanVien.DataSource = dtNhanVien;
			dgvNhanVien.DataSource = bdsNhanVien;

			if (bdsNhanVien.Count >= 0)
				bdsNhanVien.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsNhanVien;
			ExportControl = dgvNhanVien;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{//Tim den mau tin tim kiem

			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtNhanVien.Rows.Count - 1; i++)
				if (((string)dtNhanVien.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsNhanVien.Position = i;
					break;
				}
		}

		#endregion 

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsNhanVien.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsNhanVien.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsNhanVien.Current).Row, ref drCurrent);
			else
				drCurrent = dtNhanVien.NewRow();

			frmNhanVien_Edit frmEdit = new frmNhanVien_Edit();
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
                else if (enuNew_Edit == enuEdit.Edit && ((string)drHistory[strCode] != (string)((DataRowView)bdsNhanVien.Current)[strCode] || (string)drHistory[strName] != (string)((DataRowView)bdsNhanVien.Current)[strName]))
                {
                    htHistory["UPDATE_TYPE"] = "E";
                    htHistory["CODE_OLD"] = ((DataRowView)bdsNhanVien.Current)[strCode];
                    htHistory["NAME_OLD"] = ((DataRowView)bdsNhanVien.Current)[strName];
                    UpdateHistory();
                }
                //Cập nhật dữ liệu danh mục
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsNhanVien.Position >= 0)
						dtNhanVien.ImportRow(drCurrent);
					else
						dtNhanVien.Rows.Add(drCurrent);

					bdsNhanVien.Position = bdsNhanVien.Find("MA_CBNV", drCurrent["MA_CBNV"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsNhanVien.Current).Row);
				}

				dtNhanVien.AcceptChanges();
			}
			//else
			//    dtNhanVien.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsNhanVien.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsNhanVien.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

            if (DataTool.SQLCheckExist("vw_DoanhThu", strCode, drCurrent[strCode]))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
                    "Nhân viên: {" + drCurrent[strName].ToString() + "}  đã được sử dụng trong chứng từ" :
                    "Employee: {" + drCurrent[strName].ToString() + "}  used in voucher";

                Common.MsgCancel(strMsg);
                return;
            }

			if (DataTool.SQLDelete("LINHANVIEN", drCurrent))
			{
                //Cập nhật History
                htHistory["CODE"] = drCurrent[strCode];
                htHistory["NAME"] = drCurrent[strName];
                htHistory["UPDATE_TYPE"] = "D";
                UpdateHistory();
                
                bdsNhanVien.RemoveAt(bdsNhanVien.Position);
				dtNhanVien.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			if(bdsNhanVien.Count <= 0)
				return;
				
			drCurrent = ((DataRowView)bdsNhanVien.Current).Row;
			string strOldValue = (string)drCurrent["Ma_CbNv"];

			frmMergeID frm = new frmMergeID();

			frm.Load("LINHANVIEN", "Ma_CbNv", "Ten_CbNv", strOldValue, "NhanVien");			

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Ma_CbNv", "LINHANVIEN", strOldValue, strNewValue))
				{					
					bdsNhanVien.RemoveCurrent();
					bdsNhanVien.Position = bdsNhanVien.Find("Ma_CbNv", strNewValue);
				}
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsNhanVien == null || bdsNhanVien.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsNhanVien.Current).Row;
			DataTable dtTemp = dtNhanVien.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsNhanVien.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsNhanVien.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvNhanVien_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		#endregion 
	}
	
}