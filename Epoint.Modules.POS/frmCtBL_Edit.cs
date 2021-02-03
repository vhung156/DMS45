using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;

using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;
using Epoint.Lists;

namespace Epoint.Modules.POS
{
	public partial class frmCtBL_Edit: Modules.frmVoucher_Edit
	{
		private string strModule = "12";
		private bool bMa_Vt_Changed = false;
        

		public frmCtBL_Edit()
		{
            
			InitializeComponent();            

			txtMa_Vach.Validating += new CancelEventHandler(txtMa_Vach_Validating);

			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);

            txtMa_CbNv.Validating += new CancelEventHandler(txtMa_CbNv_Validating);

            btAdd.Click += new EventHandler(btAdd_Click);
            //btSave.Click += new EventHandler(btSave_Click);
            btExit.Click += new EventHandler(btExit_Click);            
			btCalc.Click += new EventHandler(btCalc_Click);
			btCustomer.Click += new EventHandler(btCustomer_Click);            

            numChiet_Khau.Validating += new CancelEventHandler(numChiet_Khau_Validating);
            numGiam_Gia.Validating += new CancelEventHandler(numGiam_Gia_Validating);
            NumGia.Validating+= new CancelEventHandler(NumGia_validating);

            dgvEditCt1.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt_CellValidating);
            dgvEditCt1.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);

			this.KeyDown += new KeyEventHandler(frmCtBL_Edit_KeyDown);
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit, DataSet dsVoucher)
		{            
            this.drEdit = drEdit;
			this.dsVoucher = dsVoucher;

			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			this.strMa_Ct = ((string)drEdit["Ma_Ct"]).Trim();
			this.drDmCt = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", this.strMa_Ct);
			this.Object_ID = strMa_Ct;

			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
				this.strStt = Common.GetNewStt(strModule, true);
			else
				this.strStt = drEdit["Stt"].ToString();

			this.Build();
			this.FillData();
			this.Init_Ct();

			if (enuNew_Edit == enuEdit.New)
			{
				string strMa_CbNv = (string)SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Ma_CbNv), '') FROM SYSMEMBER WHERE Member_ID = '" + Element.sysUser_Id + "'");

				drEditPh["Ma_CbNv"] = strMa_CbNv;
				drEditPh["Ma_Bp"] = (string)SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Ma_Bp), '') FROM LINHANVIEN WHERE Ma_CbNv = '" + strMa_CbNv + "'");
				drEditPh["Ma_Ca"] = (string)SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Ma_Ca), '') FROM LICA WHERE Gio1 < " + DateTime.Now.Hour.ToString().Trim() + " AND Gio2 >= " + DateTime.Now.Hour.ToString().Trim());
			}

			Common.ScaterMemvar(this, ref drEditPh);

			txtMa_Tte.bTextChange = false;
			numTy_Gia.bTextChange = false;

			this.Ma_Tte_Valid();
			this.BindingLanguage();
			this.LoadDicName();

			if (!isAccept)
				this.ShowDialog();
			else
				this.ActiveControl = txtMa_Vach ;
		}

		private void Build()
		{
			dgvEditCt1.bSortMode = false;
			dgvEditCt1.strZone = (string)drDmCt["Zone_EditCt1"];
			dgvEditCt1.BuildGridView();
		}

		private void FillData()
		{
			string strKeyFillterCt = " Stt = '" + ((string)drEdit["Stt"]).Trim() + "' ";

            string strSelectPh = " *, TTien0 + TTien3 - Giam_Gia AS TTien, TTien_Nt0 + TTien_Nt3 - Giam_Gia AS TTien_Nt ";
			string strSelectCt = enuNew_Edit == enuEdit.New ? " TOP 0 * " : "*";// enuNew_Edit == enuEdit.New lấy hàng đầu tiên

			dtEditPh = DataTool.SQLGetDataTable((string)drDmCt["Table_Ph"], strSelectPh, strKeyFillterCt, null);
			dtEditCt = DataTool.SQLGetDataTable((string)drDmCt["Table_Ct"], strSelectCt, strKeyFillterCt, null);

            //ThongLH: History
            dtEditCtOrg = dtEditCt.Copy();
            drEditPhOrg = drEdit;

            DataColumn dc = new DataColumn("Deleted", typeof(bool));
			dc.DefaultValue = false;
			dtEditCt.Columns.Add(dc);

			bdsEditCt.DataSource = dtEditCt;


			dgvEditCt1.DataSource = bdsEditCt;
			dgvEditCt1.ClearSelection();
		}

		private void Init_Ct()
		{
            //An
            btgAccept.Visible = false;
            ucNotice.Visible = false;

            txtMa_Tte.InputMask = (string)Systems.Librarys.Parameters.GetParaValue("MA_TTE_LIST");

			if (dtEditPh.Rows.Count == 0)
				dtEditPh.Rows.Add(dtEditPh.NewRow());

			if (dtEditCt.Rows.Count == 0)
				dtEditCt.Rows.Add(dtEditCt.NewRow());

			drEditPh = dtEditPh.Rows[0];
			drCurrent = dtEditCt.Rows[0];

			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					//Clear Content in drCurrent
					foreach (DataColumn dcEditCt in dtEditCt.Columns)
						drCurrent[dcEditCt] = DBNull.Value;

					Common.SetDefaultDataRow(ref drEditPh);
					Common.SetDefaultDataRow(ref drCurrent);

					//Ngầm định 1 số thông tin từ chứng từ cũ
					if (drEdit != null)
						Common.CopyDataRow(drEdit, drCurrent, (string)drDmCt["Carry_Header"]);

					drCurrent["Ma_DvCs"] = Element.sysMa_DvCs;
					drCurrent["Stt"] = strStt;
					drCurrent["Stt0"] = 1;
					drCurrent["Ma_Ct"] = strMa_Ct;
                    drCurrent["Ngay_Ct"] = ((string)Epoint.Systems.Librarys.Parameters.GetParaValue("NGAY_CT") == "0" && drEdit["Ngay_Ct"] != DBNull.Value) ? drEdit["Ngay_Ct"] : DateTime.Now;

					drCurrent["Ma_Tte"] = Element.sysMa_Tte;
					drCurrent["Ty_Gia"] = 1;
					drCurrent["Deleted"] = false;

					//Clear Content in drEditPh
					foreach (DataColumn dcEditPh in dtEditPh.Columns)
						drEditPh[dcEditPh] = DBNull.Value;

					drEditPh["Ma_DvCs"] = drCurrent["Ma_DvCs"];
					drEditPh["Stt"] = drCurrent["Stt"];
					drEditPh["Ma_Ct"] = drCurrent["Ma_Ct"];
					drEditPh["Ngay_Ct"] = drCurrent["Ngay_Ct"];
				}

				if (drEditPh.Table.Columns.Contains("Duyet"))
					drEditPh["Duyet"] = (bool)drDmCt["Default_Duyet"];

				//Tinh so chung tu
				string strLoai_Ma_Ct = ((DateTime)drCurrent["Ngay_Ct"]).Month.ToString().Trim();
				string strSQLExec = "EXEC Sp_Cong_So_Ct '" + strMa_Ct + "', '" + strLoai_Ma_Ct + "'";

				DataTable dtSo_Ct = SQLExec.ExecuteReturnDt(strSQLExec);

				if (dtSo_Ct.Rows.Count > 0)
					drEditPh["So_Ct"] = drCurrent["So_Ct"] = (string)dtSo_Ct.Rows[0][0];
			}

			Voucher.Update_Header(this);
			Voucher.Update_Stt(this, strModule);

            if (dgvEditCt1.Columns.Contains("MA_VT"))
                dgvEditCt1.Columns["Ma_Vt"].ReadOnly = true;

            if (dgvEditCt1.Columns.Contains("TEN_VT"))
                dgvEditCt1.Columns["Ten_Vt"].ReadOnly = true;
           
            if (dgvEditCt1.Columns.Contains("TIEN_NT2"))
                dgvEditCt1.Columns["Tien_Nt2"].ReadOnly = true;

            if (dgvEditCt1.Columns.Contains("TIEN2"))
                dgvEditCt1.Columns["Tien2"].ReadOnly = true;

            if (dgvEditCt1.Columns.Contains("DVT"))
				dgvEditCt1.Columns["Dvt"].ReadOnly = true;


			//BindingTTien            
			if (isAccept)
			{
				numTTien0.DataBindings.Clear();
				numTTien_Nt0.DataBindings.Clear();

				numTTien_Nt3.DataBindings.Clear();
				numTTien3.DataBindings.Clear();

				numTTien.DataBindings.Clear();
				numTTien_Nt.DataBindings.Clear();

				numTTien4.DataBindings.Clear();
				numTTien_Nt4.DataBindings.Clear();

				//numTSo_Luong.DataBindings.Clear();
			}

			numTTien0.DataBindings.Add("Value", dtEditPh, "TTien0");
			numTTien_Nt0.DataBindings.Add("Value", dtEditPh, "TTien_Nt0");

			numTTien_Nt3.DataBindings.Add("Value", dtEditPh, "TTien_Nt3");
			numTTien3.DataBindings.Add("Value", dtEditPh, "TTien3");

			numTTien.DataBindings.Add("Value", dtEditPh, "TTien");
			numTTien_Nt.DataBindings.Add("Value", dtEditPh, "TTien_Nt");

            numTTien4.DataBindings.Add("Value", dtEditPh, "TTien4");
            numTTien_Nt4.DataBindings.Add("Value", dtEditPh, "TTien_Nt4");

			//numTSo_Luong.DataBindings.Add("Value", dtEditPh, "TSo_Luong");
		}

		private void LoadDicName()
		{
			//txtMa_Dt
			if (txtMa_Dt.Text.Trim() != string.Empty)
			{
                if (this.enuNew_Edit == enuEdit.New)
				    txtOng_Ba.Text = DataTool.SQLGetNameByCode("LIDOITUONG", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			}
			else
				txtOng_Ba.Text = string.Empty;
		}

		private void Ma_Tte_Valid()
		{
			string strMa_Tte = txtMa_Tte.Text.Trim();

			if (Common.Inlist(this.strMa_Ct, (string)Epoint.Systems.Librarys.Parameters.GetParaValue("CT_LOCKED_EXCHANGE")))
				numTy_Gia.Enabled = false;
			else
				numTy_Gia.Enabled = true;

			if (Element.sysMa_Tte == strMa_Tte)
			{
				numTy_Gia.Value = 1;
				numTy_Gia.bReadOnly = true;

				this.pnlTTien.Visible = false;
				this.pnlTTien_Nt.Left = this.pnlTTien.Right - this.pnlTTien_Nt.Width;

				if (dgvEditCt1.Columns.Contains("TIEN2"))
					dgvEditCt1.Columns["TIEN2"].Visible = false;

			}
			else
			{
				numTy_Gia.bReadOnly = false;

				if (dteNgay_Ct.Text != Library.DateToStr((DateTime)drEditPh["Ngay_Ct"]) || txtMa_Tte.bTextChange)
				{
					Hashtable ht = new Hashtable();
					ht.Add("NGAY_CT", Library.StrToDate(dteNgay_Ct.Text));
					ht.Add("MA_TTE", strMa_Tte);

					numTy_Gia.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("sp_GetTyGia", ht, CommandType.StoredProcedure));
				}

				this.pnlTTien.Visible = true;
				this.pnlTTien_Nt.Left = this.pnlTTien.Left - this.pnlTTien_Nt.Width;

				if (dgvEditCt1.Columns.Contains("TIEN2"))
					dgvEditCt1.Columns["TIEN2"].Visible = true;
			}

			if (dteNgay_Ct.Text != Library.DateToStr((DateTime)drEditPh["Ngay_Ct"]) || txtMa_Tte.bTextChange || numTy_Gia.bTextChange)
			{
				Voucher.Update_Detail(this);
				Voucher.Calc_Tien_All(this);
				Voucher.Adjust_TThue_Vat(this, true);

				if (txtMa_Tte.bTextChange)
					txtMa_Tte.bTextChange = false;
			}

            numGiam_Gia.Scale = numTTien_Nt.Scale = numTTien_Nt0.Scale = numTTien_Nt3.Scale = numTTien_Nt4.Scale = strMa_Tte == Element.sysMa_Tte ? 0 : 2;

			Voucher.FormatTien_Nt(dgvEditCt1, strMa_Tte);

			dgvEditCt1.ResizeGridView();
		}		
		private bool FormCheckValid()
		{
			if (!Common.CheckDataLocked(Library.StrToDate(this.dteNgay_Ct.Text)))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Dữ liệu đã bị khóa" : "Data have been locked";
				Common.MsgCancel(strMsg);
				return false;
			}

			if (txtMa_Dt.Text == string.Empty)
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chưa khai báo mã khách hàng" : "Do not register customer";
				Common.MsgCancel(strMsg);
				return false;
			}

			if (dtEditCt.Select("Ma_Vt <> ''").Length == 0)
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chưa khai báo mặt hàng" : "Do not register item";
				Common.MsgCancel(strMsg);
				return false;
			}

			//Kiểm tra nghiệp vụ hợp lệ
			foreach (DataRow dr in dtEditCt.Rows)
			{
				if ((bool)dr["Deleted"])
					continue;
			}

			return true;
		}

		public override bool Save()
		{
			Common.GatherMemvar(this, ref this.drEditPh);
			Voucher.Update_Detail(this);

			if (!FormCheckValid())
				return false;

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
			{
				drEditPh["Create_Log"] = Common.GetCurrent_Log();
				drEditPh["LastModify_Log"] = string.Empty;
			}
			else
			{
				drEditPh["LastModify_Log"] = Common.GetCurrent_Log();
				if ((string)drEditPh["Create_Log"] == string.Empty)
					drEditPh["Create_Log"] = drEditPh["LastModify_Log"];
			}

			Voucher.Update_TTien(this);
			Voucher.Update_Stt(this, strModule);

			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
				if (dtEditCt.Rows.Count > 0) //Cập nhật lại dữ liệu từ chi tiết lên Header
					Common.CopyDataRow(dtEditCt.Rows[0], drEditPh, (string)drDmCt["Update_Header"]);

				drEdit = drEditPh;
			}

			return this.SQLUpdateCt(this);
		}        
		#region Lưu dữ liệu vào SQL
		//SQLUpdateCt
		private bool SQLUpdateCt(frmVoucher_Edit frmEditCt)
		{
			SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
			SqlCommand sqlCom = sqlCon.CreateCommand();

			SqlTransaction sqlTran = sqlCom.Connection.BeginTransaction("Update_Voucher_Tran");

			sqlCom.Transaction = sqlTran;

			string strKey = string.Empty;
			string strTable_Ph = (string)frmEditCt.drDmCt["Table_Ph"];
			string sp_UpdatePh = (string)frmEditCt.drDmCt["sp_UpdatePh"];
			string strStt = (string)frmEditCt.drEditPh["Stt"];
			string strMa_Ct = (string)frmEditCt.drEditPh["Ma_Ct"];


			#region UpdatePh
			if (frmEditCt.drEditPh != null)
			{//Có nhiều trường hợp cập nhật CT mà không cần cập nhật PH(VD: frmEditLR)

				sqlCom.CommandText = sp_UpdatePh;
				sqlCom.CommandType = CommandType.StoredProcedure;
				sqlCom.Parameters.Clear();

				strKey = "Object_id = Object_id('" + sp_UpdatePh + "')";
				DataTable dtUpdatePh_Para = DataTool.SQLGetDataTable("Sys.Parameters", "Name", strKey, null);

				sqlCom.Parameters.AddWithValue("@strNew_Edit", (char)frmEditCt.enuNew_Edit);
				Common.SetDefaultDataRow(ref frmEditCt.drEditPh);

				foreach (DataRow drPara in dtUpdatePh_Para.Rows)
				{
					string strColumnName = ((string)drPara["Name"]).Replace("@", "");

					if (!frmEditCt.drEditPh.Table.Columns.Contains(strColumnName))
						continue;

					sqlCom.Parameters.AddWithValue("@" + strColumnName, frmEditCt.drEditPh[strColumnName]);
				}

				try
				{
					sqlCom.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
					sqlTran.Rollback();
					return false;
				}
			}
			#endregion

			#region UpdateCt
			if (!UpdateCt(frmEditCt, sqlCom, frmEditCt.dtEditCt))
				return false;

			#endregion

			//Luu So_Ct
			string strLoai_Ma_Ct = ((DateTime)frmEditCt.drEditPh["Ngay_Ct"]).Month.ToString().Trim();
			string[] strParaName = new string[] { "Ma_Ct", "Loai_Ma_Ct", "Ngay_Ct", "So_Ct" };
			object[] objParaValue = new object[] { frmEditCt.strMa_Ct, strLoai_Ma_Ct, frmEditCt.drEditPh["Ngay_Ct"], frmEditCt.drEditPh["So_Ct"] };
			SQLExec.Execute("Sp_Luu_So_Ct", strParaName, objParaValue, CommandType.StoredProcedure);

			Voucher.Update_dsVoucher(frmEditCt);
			sqlTran.Commit();

			return true;
		}

		private bool UpdateCt(frmVoucher_Edit frmEditCt, SqlCommand sqlCom, DataTable dtEditCt)
		{
			string sp_UpdateCt = (string)frmEditCt.drDmCt["sp_UpdateCt"];
			string strTable_Ct = (string)frmEditCt.drDmCt["Table_Ct"];

			return UpdateCt(frmEditCt, sqlCom, dtEditCt, sp_UpdateCt, strTable_Ct);
		}

		private bool UpdateCt(frmVoucher_Edit frmEditCt, SqlCommand sqlCom, DataTable dtEditCt, string sp_UpdateCt, string strTable_Ct)
		{
			#region UpdateCt: Cap nhat tung dong trong dtEditCt

			int iSave_Ct_Success = 0;


			sqlCom.Parameters.Clear();

			//Xoa du lieu cu trong Chung tu
			if (frmEditCt.enuNew_Edit == enuEdit.Edit)
			{
				sqlCom.CommandType = CommandType.Text;
				sqlCom.CommandText = "DELETE FROM " + strTable_Ct + " WHERE Stt = @Stt";
				sqlCom.Parameters.AddWithValue("@Stt", (string)frmEditCt.drEditPh["Stt"]);
				try
				{
					sqlCom.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
					sqlCom.Transaction.Rollback();
					return false;
				}
			}

			//Luu du lieu vao Ct
			sqlCom.CommandText = sp_UpdateCt;
			sqlCom.CommandType = CommandType.StoredProcedure;

			string strKey = "Object_id = Object_id('" + sp_UpdateCt + "')";
			DataTable dtUpdateCt_Para = DataTool.SQLGetDataTable("Sys.Parameters", "Name", strKey, null);

			foreach (DataRow dr in dtEditCt.Rows)
			{
				//Khong luu nhung dong danh dau xoa
				if (dr.Table.Columns.Contains("Deleted") && (bool)dr["Deleted"])
					continue;

				sqlCom.Parameters.Clear();

				DataRow drEditCt = dr;
				Common.SetDefaultDataRow(ref drEditCt);

				foreach (DataRow drPara in dtUpdateCt_Para.Rows)
				{
					string strColumnName = ((string)drPara["Name"]).Replace("@", "");

					if (!drEditCt.Table.Columns.Contains(strColumnName))
						continue;

					sqlCom.Parameters.AddWithValue("@" + strColumnName, drEditCt[strColumnName]);
				}

				try
				{
					sqlCom.ExecuteNonQuery();
					iSave_Ct_Success += 1;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
					sqlCom.Transaction.Rollback();
					return false;
				}
			}

			#endregion

			#region UpdateCt: khong thuc hien duoc dong nao -> xoa han chung tu nay
			if (iSave_Ct_Success == 0)
			{
				if (Common.MsgYes_No("Chứng từ không có dữ liệu, có tiếp tục lưu hay không?"))
				{//Neu van tiep tuc luu thi xem nhu xoa chung tu nay

					sqlCom.Transaction.Rollback();
					SQLDeleteCt(frmEditCt.strStt, frmEditCt.strMa_Ct);
					return true;
				}
				else
				{
					sqlCom.Transaction.Rollback();
					return false;
				}
			}

			return true;
			#endregion
		}

		private bool SQLDeleteCt(string strStt, string strMa_Ct)
		{
			DataRow drDmCt = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", strMa_Ct);

			if (drDmCt == null)
				return false;

			//Kiem tra Permission
			if (!Common.CheckPermission((string)drDmCt["Object_ID"], enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return false;
			}

			if (!Element.sysIs_Admin)
			{
				string strCreate_User = (string)SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Create_Log), '') FROM POSVOUCHER WHERE Stt = '" + strStt + "'");

				if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
				{
					string strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM SYSMEMBER WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";

					if (!strUser_Allow.Contains("*,")) //Được phép sửa tất cả
					{
						if (!strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
						{
							Common.MsgCancel("Không xóa được chứng từ do " + strCreate_User + " lập, liên hệ với Admin!");
							return false;
						}
					}
				}
			}

			SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
			SqlCommand sqlCom = sqlCon.CreateCommand();

			SqlTransaction sqlTran = sqlCom.Connection.BeginTransaction("Deleting_Voucher_Tran");

			sqlCom.Transaction = sqlTran;

			string strTable_Ph = (string)drDmCt["Table_Ph"];
			string strTable_Ct = (string)drDmCt["Table_Ct"];

			#region Delete Ct

			sqlCom.Parameters.Clear();
			sqlCom.CommandText = "DELETE FROM " + strTable_Ct + " WHERE Stt = @Stt";
			sqlCom.CommandType = CommandType.Text;
			sqlCom.Parameters.AddWithValue("@Stt", strStt);

			try
			{
				sqlCom.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
				sqlTran.Rollback();
				return false;
			}
			#endregion

			#region Delete Ph

			sqlCom.CommandText = "DELETE FROM " + strTable_Ph + " WHERE Stt = @Stt";

			try
			{
				sqlCom.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
				sqlTran.Rollback();
				return false;
			}

			#endregion

			sqlTran.Commit();
			return true;
		}

		#endregion

		#region Event
		
        void numChiet_Khau_Validating(object sender, CancelEventArgs e)
        {
            Voucher.Update_Detail(this, "Chiet_Khau");
            Voucher.Calc_Chiet_Khau_All(this);

            this.txtMa_Vach.Focus();
        }
        void numGiam_Gia_Validating(object sender, CancelEventArgs e)
        {           
            this.drEditPh["Giam_Gia"] = numGiam_Gia.Value;           
            Voucher.Update_TTien(this);
          
            this.txtMa_Vach.Focus();
        }
        void NumGia_validating(object sender, CancelEventArgs e)
        {
            drCurrent["Gia_Nt2"] = drCurrent["Gia2"] = NumGia.Value;
            drCurrent["Tien_Nt2"] = drCurrent["Tien2"] = Convert.ToDouble(drCurrent["So_Luong"]) * Convert.ToDouble(drCurrent["Gia_Nt2"]);
            dtEditCt.AcceptChanges();
            Voucher.Update_TTien(this);

            NumGia.Value = 0;
            this.txtMa_Vach.Focus();
        }
        void txtMa_Vach_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vach.Text.Trim();
            bool bRequire = true;
            bool bAllowAddCur = false;

            //Neu khong co ma vach
            if (strValue == @"/" || strValue == @"\")
            {
                //frmVatTu frmLookup = new frmVatTu();
                DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

                if (bRequire && drLookup == null)
                    e.Cancel = true;

                if (drLookup == null)
                {
                    txtMa_Vach.Text = string.Empty;
                }
                else
                {
                    txtMa_Vach.Text = ((string)drLookup["Ma_Vt"]).Trim();
                }

                if (drLookup != null)
                {
                    if (dtEditCt.Select("Ma_Vt = '" + txtMa_Vach.Text + "'").Length > 0 && bAllowAddCur) //Đã tồn tại 1 dòng mặt hàng đó rồi và cho phép nhập hàng mới
                    {
                        drCurrent = dtEditCt.Select("Ma_Vt = '" + txtMa_Vach.Text + "'")[0];

                        drCurrent["Ten_Vt"] = drLookup["Ten_Vt"].ToString();
                        drCurrent["Dvt"] = drLookup["Dvt"].ToString();
                        drCurrent["So_Luong"] = Convert.ToDouble(drCurrent["So_Luong"]) + numSo_Luong.Value;
                    }
                    else //Chưa có mặt hàng lưới nhập liệu
                    {
                        if (dtEditCt.Select("Ma_Vt = ''").Length == 1) //Có 1 dòng ngầm định không có dữ liệu: đưa vào dòng này luôn
                        {
                            drCurrent = dtEditCt.Select("Ma_Vt = ''")[0];
                        }
                        else //Chưa có mặt hàng này trong dữ liệu, thêm mới hoàn toàn
                        {
                            drCurrent = dtEditCt.NewRow();
                            drCurrent["Stt"] = this.strStt;
                            drCurrent["Stt0"] = Convert.ToInt32(Common.MaxDCValue(dtEditCt, "Stt0")) + 1;

                            Common.SetDefaultDataRow(ref drCurrent);
                            dtEditCt.Rows.Add(drCurrent);
                        }

                        drCurrent["Ma_Vt"] = txtMa_Vach.Text;
                        drCurrent["Ten_Vt"] = drLookup["Ten_Vt"].ToString();
                        drCurrent["Dvt"] = drLookup["Dvt"].ToString();
                        drCurrent["So_Luong"] = numSo_Luong.Value;
                    }

                    //Lấy giá từ chính sách giá
                    string strSQLExec = @"
						WITH GiaMax AS
						(
							SELECT Ma_Vt, Ma_Dt, MAX(Ngay_Ap) AS Ngay_Ap_Max
								FROM ARGIABAN
								WHERE Ngay_Ap <= '" + dteNgay_Ct.Text + @"' AND Ma_Vt = '" + txtMa_Vach.Text + @"' --AND Ma_Dt = 'aaa'
								GROUP BY Ma_Vt, Ma_Dt
						)
						SELECT ISNULL(MAX(T1.Gia), 0)
							FROM ARGIABAN T1 JOIN GiaMax T2
								ON	T1.Ma_Vt = T2.Ma_Vt AND
									T1.Ma_Dt = T2.Ma_Dt AND
									T1.Ngay_Ap = T2.Ngay_Ap_Max";


                    NumGia.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strSQLExec));

                    if (drLookup.Table.Columns.Contains("Gia_Out"))
                        NumGia.Value = Convert.ToDouble(drLookup["Gia_Out"]);

                    drCurrent["Gia_Nt2"] = drCurrent["Gia2"] = NumGia.Value;
                    drCurrent["Tien_Nt2"] = drCurrent["Tien2"] = Convert.ToDouble(drCurrent["So_Luong"]) * Convert.ToDouble(drCurrent["Gia_Nt2"]);

                    numSo_Luong.Value = Convert.ToDouble(drCurrent["So_Luong"]);


                    
                    //numGia_Nt2.Value = Convert.ToDouble(drCurrent["Gia_Nt2"]);

                    //Voucher.Calc_So_Luong(drCurrent);
                    Voucher.Update_TTien(this);

                    dtEditCt.AcceptChanges();
                    numSo_Luong.Value = 1;
                    txtMa_Vach.Text = string.Empty;
                    //bdsEditCt.MoveLast();                    
                    if (NumGia.Value == 0)
                        NumGia.Focus();
                    else
                    {
                        e.Cancel = true;
                        bdsEditCt.MoveLast();
                    }
                    //Ghi nhan thong tin khi quet barcode
                    txtNote1.Text = drCurrent["Ten_Vt"].ToString() + "       SL: " + drCurrent["So_Luong"] + "       ĐG: " + drCurrent["Gia_Nt2"] + "       TT: " + drCurrent["Tien_Nt2"];
                }
            }

            //Neu co ma vach
            if (txtMa_Vach.Text != string.Empty)
            {
                frmVatTu frmLookup = new frmVatTu();
                DataRow drLookup = DataTool.SQLGetDataRowByID("LIVATTU", "Ma_Vt", txtMa_Vach.Text.Trim());

                if (drLookup == null)
                {
                    //Neu chua co mat hang, thi tu dong them mat hang
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Mặt hàng chưa được khai báo. Nhấn Yes đề thêm mới mặt hàng !" : "Undeclared goods. Click Yes to add new items !";                    
                    if (MessageBox.Show(strMsg, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        drLookup = Lookup.ShowLookup(frmLookup, "LIVATTU", "Ma_Vt", strValue, bRequire, "", "");
                    }
                    else
                    {
                        txtMa_Vach.Text = String.Empty;
                        txtMa_Vach.Focus();
                    }

                }
                if (drLookup != null)
                {
                    if (dtEditCt.Select("Ma_Vt = '" + txtMa_Vach.Text + "'").Length > 0 &&  bAllowAddCur) //Đã tồn tại 1 dòng mặt hàng đó rồi
                    {
                        drCurrent = dtEditCt.Select("Ma_Vt = '" + txtMa_Vach.Text + "'")[0];

                        drCurrent["Ten_Vt"] = drLookup["Ten_Vt"].ToString();
                        drCurrent["Dvt"] = drLookup["Dvt"].ToString();
                        drCurrent["So_Luong"] = Convert.ToDouble(drCurrent["So_Luong"]) + numSo_Luong.Value;
                    }
                    else //Chưa có mặt hàng lưới nhập liệu
                    {
                        if (dtEditCt.Select("Ma_Vt = ''").Length == 1) //Có 1 dòng ngầm định không có dữ liệu: đưa vào dòng này luôn
                        {
                            drCurrent = dtEditCt.Select("Ma_Vt = ''")[0];
                        }
                        else //Chưa có mặt hàng này trong dữ liệu, thêm mới hoàn toàn
                        {
                            drCurrent = dtEditCt.NewRow();
                            drCurrent["Stt"] = this.strStt;
                            drCurrent["Stt0"] = Convert.ToInt32(Common.MaxDCValue(dtEditCt, "Stt0")) + 1;

                            Common.SetDefaultDataRow(ref drCurrent);
                            dtEditCt.Rows.Add(drCurrent);
                        }

                        drCurrent["Ma_Vt"] = txtMa_Vach.Text;
                        drCurrent["Ten_Vt"] = drLookup["Ten_Vt"].ToString();
                        drCurrent["Dvt"] = drLookup["Dvt"].ToString();
                        drCurrent["So_Luong"] = numSo_Luong.Value;
                    }

                    //Lấy giá từ chính sách giá
                    string strSQLExec = @"
						WITH GiaMax AS
						(
							SELECT Ma_Vt, Ma_Dt, MAX(Ngay_Ap) AS Ngay_Ap_Max
								FROM ARGIABAN
								WHERE Ngay_Ap <= '" + dteNgay_Ct.Text + @"' AND Ma_Vt = '" + txtMa_Vach.Text + @"' --AND Ma_Dt = 'aaa'
								GROUP BY Ma_Vt, Ma_Dt
						)
						SELECT ISNULL(MAX(T1.Gia), 0)
							FROM ARGIABAN T1 JOIN GiaMax T2
								ON	T1.Ma_Vt = T2.Ma_Vt AND
									T1.Ma_Dt = T2.Ma_Dt AND
									T1.Ngay_Ap = T2.Ngay_Ap_Max";

                    NumGia.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strSQLExec));

                    if (drLookup.Table.Columns.Contains("Gia_Out"))
                        NumGia.Value = Convert.ToDouble(drLookup["Gia_Out"]);

                    drCurrent["Gia_Nt2"] = drCurrent["Gia2"] = NumGia.Value;
                    drCurrent["Tien_Nt2"] = drCurrent["Tien2"] = Convert.ToDouble(drCurrent["So_Luong"]) * Convert.ToDouble(drCurrent["Gia_Nt2"]);

                    numSo_Luong.Value = Convert.ToDouble(drCurrent["So_Luong"]);
                    //numGia_Nt2.Value = Convert.ToDouble(drCurrent["Gia_Nt2"]);

                    //Voucher.Calc_So_Luong(drCurrent);
                    Voucher.Update_TTien(this);

                    dtEditCt.AcceptChanges();
                    numSo_Luong.Value = 1;
                    txtMa_Vach.Text = string.Empty;
                    //e.Cancel = true;
                    //bdsEditCt.MoveLast();
                    if (NumGia.Value == 0)
                        NumGia.Focus();
                    else
                    {
                        e.Cancel = true;
                        bdsEditCt.MoveLast(); 
                    }
                    //Ghi nhan thong tin khi quat Barcode
                    txtNote1.Text = drCurrent["Ten_Vt"].ToString() + "       SL: " + drCurrent["So_Luong"] + "       ĐG: " + drCurrent["Gia_Nt2"] + "       TT: " + drCurrent["Tien_Nt2"];
                }
            }
            
        }
        //void txtMa_Vach_TextChanged(object sender, EventArgs e)
        //{
            
        //}

		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = false;

			frmDoiTuong frmLookup = new frmDoiTuong();
			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt.Text = string.Empty;
				txtOng_Ba.Text = string.Empty;
			}
			else
			{
				txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
				txtOng_Ba.Text = drLookup["Ten_Dt"].ToString();

				if (txtMa_Dt.Text != (string)drEditPh["Ma_Dt"])
				{
					//txtOng_Ba.Text = drLookup["Ong_Ba"].ToString() == string.Empty ? drLookup["Ten_Dt"].ToString() : drLookup["Ong_Ba"].ToString();

					if (drLookup["Dia_Chi"].ToString() != string.Empty)
						txtDia_Chi.Text = drLookup["Dia_Chi"].ToString();

                    if (drLookup["Ma_The"].ToString() != string.Empty)
                        txtMa_The.Text = drLookup["Ma_The"].ToString();
				}
			}

			Voucher.Update_Detail(this, "Ma_Dt");

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

        void txtMa_CbNv_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_CbNv.Text.Trim();
            bool bRequire = true;

            frmNhanVien frmLookup = new frmNhanVien();
            DataRow drLookup = Lookup.ShowLookup(frmLookup, "LINHANVIEN", "Ma_CbNv", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_CbNv.Text = string.Empty;
                //lbtTen_Kho.Text = string.Empty;
            }
            else
            {
                txtMa_CbNv.Text = drLookup["Ma_CbNv"].ToString();
                //lbtTen_Kho.Text = drLookup["Ten_Kho"].ToString();
            }

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

		void txtMa_Kho_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Kho.Text.Trim();
			bool bRequire = true;

			frmKho frmLookup = new frmKho();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIKHO", "Ma_Kho", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Kho.Text = string.Empty;
				//lbtTen_Kho.Text = string.Empty;
			}
			else
			{
				txtMa_Kho.Text = drLookup["Ma_Kho"].ToString();
				//lbtTen_Kho.Text = drLookup["Ten_Kho"].ToString();
			}

            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}
        void New()
        {            
            Save();
            isAccept = true;
            this.Load(enuEdit.New, drEditPh, dsVoucher);
        }
        void Save2()
        {
            Save();
            enuNew_Edit = enuEdit.Edit;
        }        
        private void btAdd_Click(object sender, EventArgs e)
        {
            New();
        }
        //void btSave_Click(object sender, EventArgs e)
        //{
        //    Save2();
        //    this.Close();
        //}
        void btExit_Click(object sender, EventArgs e)
        {            
            this.Close();
        }                
        void btCalc_Click(object sender, EventArgs e)
		{
            Save();
            this.enuNew_Edit = enuEdit.Edit;
            frmThanhToan frm = new frmThanhToan();
            frm.drEditPh1 = drEditPh;
            frm.drDmCt1 = drDmCt;
            frm.strStt1 = strStt;
            frm.strMa_CbNv = txtMa_CbNv.Text.Trim();
            frm.numTTien_Nt.Value = numTTien_Nt.Value;
            frm.Load();
            isAccept = true;
            this.Load(enuEdit.New, drEditPh, dsVoucher);
		}
        void btCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer frmCus = new frmCustomer();
            frmCus.Load();
        }       
                
		void frmCtBL_Edit_KeyDown(object sender, KeyEventArgs e)
		{
            switch (e.KeyCode)
            {
                case Keys.F6:
                    Voucher.DeleteRow(this, dgvEditCt1);
                    break;
            }
            if (e.KeyCode == Keys.F10)
            {
                Save();
                this.enuNew_Edit = enuEdit.Edit;
                frmThanhToan frm = new frmThanhToan();
                frm.drEditPh1 = drEditPh;
                frm.drDmCt1 = drDmCt;
                frm.strStt1 = strStt;
                frm.strMa_CbNv = txtMa_CbNv.Text.Trim();
                frm.numTTien_Nt.Value = numTTien_Nt.Value;
                frm.Load();
                this.isAccept = true;
                this.Load(enuEdit.New, drEditPh, dsVoucher);

            }

            if (e.KeyCode == Keys.F2)
            {
                this.Save2();
                this.New();

                //frmThanhToan frm = new frmThanhToan();
                //frm.drEditPh1 = drEditPh;
                //frm.drDmCt1 = drDmCt;
                //frm.strStt1 = strStt;
                //frm.strMa_CbNv = txtMa_CbNv.Text.Trim();
                //frm.numTTien_Nt.Value = numTTien_Nt.Value;
                //frm.Load();
                
            }

            //if (e.KeyCode == Keys.F4)
            //{                   
            //    Save();                
            //    this.Close();
                //frmThanhToan frm = new frmThanhToan();
                //frm.drEditPh1 = drEditPh;
                //frm.drDmCt1 = drDmCt;
                //frm.strStt1 = strStt;
                //frm.strMa_CbNv = txtMa_CbNv.Text.Trim();
                //frm.numTTien_Nt.Value = numTTien_Nt.Value;
                //frm.Load();                
            //}
            if (e.KeyCode == Keys.Escape)
            {
                if (Common.MsgYes_No(Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn có muốn lưu những thay đổi không" : "Do you want save change"))
                    this.Save();
                this.Close();
                //Save();
                //frmThanhToan frm = new frmThanhToan();
                //frm.drEditPh1 = drEditPh;
                //frm.drDmCt1 = drDmCt;
                //frm.strStt1 = strStt;
                //frm.strMa_CbNv = txtMa_CbNv.Text.Trim();
                //frm.numTTien_Nt.Value = numTTien_Nt.Value;
                //frm.Load();
            }                   

            if (e.KeyCode == Keys.F8)
            {
                frmCustomer frmCus = new frmCustomer();
                frmCus.Load();
            }

            if (e.KeyCode == Keys.F11)
            {
                txtMa_Vach.Focus();
            }

            if (e.KeyCode == Keys.F12)
            {
                numSo_Luong.Focus();
            }
		}

		#endregion
        void dgvEditCt_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {//Cai dat Lookup

            dgvVoucher dgvEditCt = (dgvVoucher)sender;
            //Xu ly phim Enter
            if (dgvEditCt.kLastKey == Keys.Enter)
            {
                dgvEditCt.kLastKey = Keys.None;

                if (this.CellKeyEnter())
                    e.Cancel = true;
            }

            //Xu ly Lookup
            if (this.ActiveControl == null)
                return;

            //e.Cancel = true;

            if (this.ActiveControl == dgvEditCt || this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
            {
                drCurrent = ((DataRowView)bdsEditCt.Current).Row;
                DataGridViewCell dgvCell = dgvEditCt.CurrentCell;
                string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

                bool bLookup = true;                

                if (bLookup == false)
                    e.Cancel = true;
            }
            else
                dgvEditCt.CancelEdit();            
        }

        void dgvEditCt_CellValidated(object sender, DataGridViewCellEventArgs e)
        {//Cai dat cac ham tinh toan

            dgvVoucher dgvEditCt = (dgvVoucher)sender;
            if (this.ActiveControl != dgvEditCt)
                return;

            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();            

            if (Common.Inlist(strColumnName, "SO_LUONG,GIA_NT2,TIEN_NT2,TIEN2"))
            {
                drCurrent["Tien_Nt2"] = drCurrent["Tien2"] = Convert.ToDouble(drCurrent["So_Luong"]) * Convert.ToDouble(drCurrent["Gia_Nt2"]);             
                Voucher.Update_TTien(this);
            }

            bdsEditCt.EndEdit();//Cap nhat lai DataSource            
        }
        
        private bool CellKeyEnter()
        {//Ham thuc hien phim Enter: true: thuc hien thanh cong, false: khong thuc hien duoc			

            if (dgvEditCt1.CurrentCell == null)
                return false;

            DataGridViewCell dgvCell = dgvEditCt1.CurrentCell;
            string strCurrentColumn = dgvCell.OwningColumn.Name.ToUpper();

            #region Enter tai TEN_VT
            if (Common.Inlist(strCurrentColumn, "TEN_VT"))
            {
                drCurrent = ((DataRowView)bdsEditCt.Current).Row;

                if (drCurrent["Ma_Vt"] == DBNull.Value || (string)drCurrent["Ma_Vt"] == string.Empty)
                {
                    bool bIsCurrentLastRow = dgvEditCt1.bIsCurrentLastRow;

                    bdsEditCt.RemoveCurrent();
                    dtEditCt.AcceptChanges();

                    if (bIsCurrentLastRow)
                        this.SelectNextControl(dgvEditCt1, true, true, true, true);

                    return true;
                }

                return false;
            }
            #endregion

            #region Enter tai TIEN_NT2
            if (Common.Inlist(strCurrentColumn, "TIEN_NT2"))
            {
                if (txtMa_Tte.Text.Trim() == Element.sysMa_Tte)
                {
                    // Cap nhat tien TIEN_NT2 truoc khi xuong dong
                    double dbTien_Nt2 = 0;
                    if (double.TryParse(dgvEditCt1.CurrentCell.FormattedValue.ToString().Trim(), out dbTien_Nt2))
                    {
                        dgvEditCt1.CancelEdit();
                        drCurrent = ((DataRowView)bdsEditCt.Current).Row;
                        drCurrent["TIEN_NT2"] = dbTien_Nt2;                        
                        Voucher.Update_TTien(this);
                    }

                    if (dgvEditCt1.bIsCurrentLastRow)
                    {
                        if (!Voucher.AddRow(this))
                            this.SelectNextControl(dgvEditCt1, true, true, true, true);
                        else
                        {
                            dgvEditCt1.FocusNextFirstCell();
                            return true;
                        }
                    }
                    else
                        dgvEditCt1.FocusNextFirstCell();

                }
                return false;
            }

            #endregion

            #region Enter TIEN
            if (Common.Inlist(strCurrentColumn, "TIEN2"))
            {
                if (dgvEditCt1.bIsCurrentLastRow)
                {
                    // Cap nhat Tien truoc khi xuống dòng
                    double dbTien = 0;
                    if (double.TryParse(dgvEditCt1.CurrentCell.FormattedValue.ToString().Trim(), out dbTien))
                    {
                        dgvEditCt1.CancelEdit();
                        drCurrent = ((DataRowView)bdsEditCt.Current).Row;
                        drCurrent["TIEN2"] = dbTien;                        
                        Voucher.Update_TTien(this);
                    }

                    if (!Voucher.AddRow(this))
                        return false;
                    else
                        dgvEditCt1.FocusNextFirstCell();


                    return true;
                }

                return false;
            }
            #endregion

            return false;
        }

        private void TTien_Valid()
        {
            numTTien0.Value = numTTien_Nt0.Value * numTy_Gia.Value;

            if (numTTien3.Value == 0)
                numTTien3.Value = numTTien_Nt3.Value * numTy_Gia.Value;
            else if (numTTien_Nt3.Value == 0 && numTy_Gia.Value != 0)
                numTTien_Nt3.Value = numTTien3.Value / numTy_Gia.Value;

            this.drEditPh["TTien0"] = numTTien0.Value;
            this.drEditPh["TTien_Nt0"] = numTTien_Nt0.Value;
            this.drEditPh["TTien3"] = numTTien3.Value;
            this.drEditPh["TTien_Nt3"] = numTTien_Nt3.Value;            

            this.drEditPh["TTien"] = Convert.ToDouble(this.drEditPh["TTien0"]) + Convert.ToDouble(this.drEditPh["TTien3"]);
            this.drEditPh["TTien_Nt"] = Convert.ToDouble(this.drEditPh["TTien_Nt0"]) + Convert.ToDouble(this.drEditPh["TTien_Nt3"]);

            Voucher.Adjust_TThue_Vat(this);
        }
        void dgvEditCt1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dgvVoucher dgvEditCt = (dgvVoucher)sender;

            if (dgvEditCt.CurrentCell == null)
                return;

            if (this.ActiveControl != dgvEditCt)
                return;

            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (strColumnName == "MA_VT")
                this.bMa_Vt_Changed = true;

        }
        public void Update_Gia_Vt(DataRow drEditCt)
        {
            //Chi cap nhật gia vat tu khi co so luong
            if (drEditCt["Ma_Vt"] == DBNull.Value || (string)drEditCt["Ma_Vt"] == string.Empty)
                return;

            if (drEditCt["So_Luong"] == DBNull.Value || Convert.ToDouble(drEditCt["So_Luong"]) == 0)
                return;

            if (drEditCt["Gia_Nt2"] != DBNull.Value && Convert.ToDouble(drEditCt["Gia_Nt2"]) != 0)
                return;

            Hashtable htParameter = new Hashtable();
            htParameter.Add("MA_VT", (string)drEditCt["Ma_Vt"]);
            htParameter.Add("MA_DT", (string)drEditCt["Ma_Dt"]);
            htParameter.Add("NGAY_CT", this.dteNgay_Ct.Text);

            drEditCt["Gia_Nt2"] = SQLExec.ExecuteReturnValue("sp_GetGiaBan", htParameter, CommandType.StoredProcedure);
        }
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			this.dgvEditCt1.ClearSelection(); //Chi co tac dung sau khi show form
		}       
        
	}
}
