using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;
using Epoint.Lists;

namespace Epoint.Modules.AP
{
	public partial class frmCtPO_Edit : frmVoucher_Edit
	{
		private string strModule = "04";
		private bool bMa_Vt_Changed = false;
		private bool bMa_Thue_Changed = false;

		#region Contructor

		public frmCtPO_Edit()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(frmEditCtTien_KeyDown);

            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
            
			txtMa_Ct.Enter += new EventHandler(txtMa_Ct_Enter);
			txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
			txtMa_Ct.TextChanged += new EventHandler(txtMa_Ct_TextChanged);

			txtMa_Tte.Leave += new EventHandler(txtMa_Tte_Leave);
			numTy_Gia.Leave += new EventHandler(numTy_Gia_Leave);

			txtMa_Thue.Enter += new EventHandler(txtMa_Thue_Enter);
			txtMa_Thue.Validating += new CancelEventHandler(txtMa_Thue_Validating);

            linkHelp.LinkClicked += new LinkLabelLinkClickedEventHandler(linkHelp_LinkClicked);

            dteNgay_Ct.Validating += DteNgay_Ct_Validating;
            dteNgay_Gh.Validating += new CancelEventHandler(dteNgay_Gh_Validating);
            dteNgay_DkHt.Validating += new CancelEventHandler(dteNgay_DkHt_Validating);

			numTTien.Validated += new EventHandler(numTTien_Validated);
			numTTien_Nt.Validated += new EventHandler(numTTien_Nt_Validated);
			numTTien3.Validated += new EventHandler(numTTien3_Validated);
			numTTien_Nt3.Validated += new EventHandler(numTTien_Nt3_Validated);

			dgvEditCt1.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt_CellValidating);
			dgvEditCt1.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
			dgvEditCt1.CellEnter += new DataGridViewCellEventHandler(dgvEditCt_CellEnter);
			dgvEditCt1.CellValueChanged += new DataGridViewCellEventHandler(dgvEditCt1_CellValueChanged);
			dgvEditCt1.KeyDown += new KeyEventHandler(dgvEditCt_KeyDown);			
		}
        
        new public void Load(enuEdit enuNew_Edit, DataRow drEdit, DataSet dsVoucher)
		{
			this.drEdit = drEdit;
			this.dsVoucher = dsVoucher;

			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			this.strMa_Ct = ((string)drEdit["Ma_Ct"]).Trim();
			this.drDmCt = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", this.strMa_Ct);
            this.Object_ID = (string)SQLExec.ExecuteReturnValue("SELECT MAX(Object_ID) FROM SYSDMCT WHERE Ma_Ct LIKE '" + this.strMa_Ct + "'");

			if (enuNew_Edit == enuEdit.New)
				this.strStt = Common.GetNewStt(strModule, true);
			else
				this.strStt = drEdit["Stt"].ToString();

			this.Build();
			this.FillData();
			this.Init_Ct();

			Common.ScaterMemvar(this, ref drEditPh);

			this.Ma_Tte_Valid();
			this.BindingLanguage();
			this.LoadDicName();

			this.ShowDialog();
		}

		#endregion

		#region Phuong thuc

		private void Build()
		{
			dgvEditCt1.bSortMode = false;
			dgvEditCt1.strZone = (string)drDmCt["Zone_EditCt1"];
			dgvEditCt1.BuildGridView();			
		}

		private void FillData()
		{
			string strKeyFillterCt = " Stt = '" + ((string)drEdit["Stt"]).Trim() + "' ";

			string strSelectPh = " *, TTien0 + TTien3 AS TTien, TTien_Nt0 + TTien_Nt3 AS TTien_Nt ";
			string strSelectCt = enuNew_Edit == enuEdit.New ? " TOP 1 * " : "*";// enuNew_Edit == enuEdit.New lấy hàng đầu tiên

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
			if (dtEditPh.Rows.Count == 0)
				dtEditPh.Rows.Add(dtEditPh.NewRow());

			if (dtEditCt.Rows.Count == 0)
				dtEditCt.Rows.Add(dtEditCt.NewRow());

			drEditPh = dtEditPh.Rows[0];
			drCurrent = dtEditCt.Rows[0];

			if (this.enuNew_Edit == enuEdit.New)
			{
				//Clear Content in drCurrent
				foreach (DataColumn dcEditCt in dtEditCt.Columns)
					drCurrent[dcEditCt] = DBNull.Value;

				Common.SetDefaultDataRow(ref drEditPh);
				Common.SetDefaultDataRow(ref drCurrent);

				drCurrent["Ma_DvCs"] = Element.sysMa_DvCs;
				drCurrent["Stt"] = strStt;
				
				drCurrent["Ma_Ct"] = strMa_Ct;
                drCurrent["Ngay_Ct"] = ((string)Epoint.Systems.Librarys.Parameters.GetParaValue("NGAY_CT") == "0" && drEdit["Ngay_Ct"] != DBNull.Value) ? drEdit["Ngay_Ct"] : DateTime.Now;

				drCurrent["Ma_Tte"] = Element.sysMa_Tte;
				drCurrent["Ty_Gia"] = 1;

				drCurrent["Stt0"] = 1;

				drCurrent["Deleted"] = false;

                if (drEditPh.Table.Columns.Contains("Duyet"))
                    drEditPh["Duyet"] = (bool)drDmCt["Default_Duyet"];
                if (drEditPh.Table.Columns.Contains("Is_Thue_Vat"))
                    drEditPh["Is_Thue_Vat"] = (bool)drDmCt["Default_VAT"];

                //Tinh so chung tu
                if ((bool)SQLExec.ExecuteReturnValue("SELECT Is_So_Ct FROM SYSDMCT WHERE Ma_Ct = '" + strMa_Ct + "'") == true)//1: Tính tự động, 0-Tính theo thủ công từng tháng
                    Cong_So_Ct_Auto();
                else
                {
                    string strLoai_Ma_Ct = ((DateTime)drCurrent["Ngay_Ct"]).Month.ToString().Trim();
                    string strSQLExec = "EXEC Sp_Cong_So_Ct '" + strMa_Ct + "', '" + strLoai_Ma_Ct + "'";

                    DataTable dtSo_Ct = SQLExec.ExecuteReturnDt(strSQLExec);

                    if (dtSo_Ct.Rows.Count > 0)
                        drEditPh["So_Ct"] = drCurrent["So_Ct"] = (string)dtSo_Ct.Rows[0][0];
                }

                drEditPh["Ma_DvCs"] = drCurrent["Ma_DvCs"];
				drEditPh["Stt"] = drCurrent["Stt"];
				drEditPh["Ma_Ct"] = drCurrent["Ma_Ct"];
				drEditPh["Ngay_Ct"] = drCurrent["Ngay_Ct"];
				//drEditPh["So_Ct"] = drCurrent["So_Ct"];
			}

			Voucher.Update_Header(this);
			Voucher.Update_Stt(this, strModule);
			
			dgvEditCt1.Columns["Dvt"].ReadOnly = true;
			//BindingTTien            
			numTTien0.DataBindings.Add("Value", dtEditPh, "TTien0");
			numTTien_Nt0.DataBindings.Add("Value", dtEditPh, "TTien_Nt0");

			numTTien_Nt3.DataBindings.Add("Value", dtEditPh, "TTien_Nt3");
			numTTien3.DataBindings.Add("Value", dtEditPh, "TTien3");

			numTTien.DataBindings.Add("Value", dtEditPh, "TTien");
			numTTien_Nt.DataBindings.Add("Value", dtEditPh, "TTien_Nt");

			numTSo_Luong.DataBindings.Add("Value", dtEditPh, "TSo_Luong");
		}

        private void Cong_So_Ct_Auto()
        {
            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            {
                Hashtable htSo_Ct = new Hashtable();
                htSo_Ct.Add("MA_CT", strMa_Ct);
                htSo_Ct.Add("NGAY_CT", Convert.ToDateTime(drCurrent["Ngay_Ct"]).ToShortDateString());
                htSo_Ct.Add("MA_TTE", drCurrent["Ma_TTe"].ToString());
                htSo_Ct.Add("MA_DVCS", Element.sysMa_DvCs);
                drEditPh["So_Ct"] = drCurrent["So_Ct"] = Convert.ToString(SQLExec.ExecuteReturnValue("sp_Cong_So_Ct_Auto", htSo_Ct, CommandType.StoredProcedure));
                txtSo_Ct.Text = drCurrent["So_Ct"].ToString();
            }
        }

        private void LoadDicName()
		{
			if (txtMa_Ct.Text.Trim() != string.Empty && drDmCt != null)
			{
				dicName.SetValue("Ten_Ct", (string)drDmCt["Ten_Ct"]);
			}					
		}

		private bool FormCheckValid()
		{
            if (!Common.CheckDataLocked(Library.StrToDate(this.dteNgay_Ct.Text)))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Dữ liệu đã bị khóa" : "Data have been locked";
                Common.MsgCancel(strMsg);
                return false;
            }

			return true;
		}

		public override bool Save()
		{
            //Nếu các dòng bị xóa hết thì ko cho lưu --> do là chứng từ rỗng
            if (dtEditCt.Select("Deleted = false").Length == 0)
                return false;

            if (!FormCheckValid())
				return false;

			Common.GatherMemvar(this, ref this.drEditPh);

			if (this.enuNew_Edit == enuEdit.New)
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

			Voucher.Update_Detail(this);
			Voucher.Update_TTien(this);
			Voucher.Update_Stt(this, strModule);
            Voucher.UpdateSo_Ct(this);

            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            {
                if (dtEditCt.Rows.Count > 0) //Cập nhật lại dữ liệu từ chi tiết lên Header
                    Common.CopyDataRow(dtEditCt.Rows[0], drEditPh, (string)drDmCt["Update_Header"]);

                drEdit = drEditPh;
            }

            ////Sync data-------------
            //string Is_Sync = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM SYSPARAMETER WHERE Parameter_ID = 'SYNC_BEGIN'"));
            //if (Is_Sync == "1")
            //{                
            //    SqlConnection sqlCon = SQLExecSync1.GetNewSQLConnectionSync1();
            //    if (sqlCon.State != ConnectionState.Open)
            //    {
            //        SQLExec.Execute("UPDATE SYSPARAMETER SET Parameter_Value = 0 WHERE Parameter_ID = 'SYNC_BEGIN'");
            //    }
            //    else
            //    {
            //        VoucherSync1.Update_Header(this);
            //        VoucherSync1.SQLUpdateCt(this);
            //    }                    
            //}
            ////Update lai Ma_Dvcs
            //this.drEditPh["Ma_Dvcs"] = Element.sysMa_DvCs;
            //foreach (DataRow drEditCt in dtEditCt.Rows)
            //{
            //    drEditCt["Ma_DvCs"] = Element.sysMa_DvCs;
            //}

            //dtEditCt.AcceptChanges();
            ////----------------------

            return Voucher.SQLUpdateCt(this);

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

                if (dgvEditCt1.Columns.Contains("TIEN"))
                    dgvEditCt1.Columns["TIEN"].Visible = false;

                //if (dgvEditCt2.Columns.Contains("TIEN3"))
                //    dgvEditCt2.Columns["TIEN3"].Visible = false;

                if (dgvEditCt1.Columns.Contains("TIEN5"))
                    dgvEditCt1.Columns["TIEN5"].Visible = false;                
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

                if (dgvEditCt1.Columns.Contains("TIEN"))
                    dgvEditCt1.Columns["TIEN"].Visible = true;

                //if (dgvEditCt2.Columns.Contains("TIEN3"))
                //    dgvEditCt2.Columns["TIEN3"].Visible = true;

                if (dgvEditCt1.Columns.Contains("TIEN5"))
                    dgvEditCt1.Columns["TIEN5"].Visible = true;
                
            }

            if (dteNgay_Ct.Text != Library.DateToStr((DateTime)drEditPh["Ngay_Ct"]) || txtMa_Tte.bTextChange || numTy_Gia.bTextChange)
            {
                Voucher.Update_Detail(this);
                Voucher.Calc_Tien_All(this);
                Voucher.Adjust_TThue_Vat(this, true);

                if (txtMa_Tte.bTextChange)
                    txtMa_Tte.bTextChange = false;
            }

            numTTien_Nt.Scale = numTTien_Nt0.Scale = numTTien_Nt3.Scale = strMa_Tte == Element.sysMa_Tte ? 0 : 2;

            Voucher.FormatTien_Nt(dgvEditCt1, strMa_Tte);            

            dgvEditCt1.ResizeGridView();            
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

			#region Enter tai TIEN_NT9
			if (Common.Inlist(strCurrentColumn, "TIEN_NT9"))
			{
				if (txtMa_Tte.Text.Trim() == Element.sysMa_Tte)
				{
					// Cap nhat tien TIEN_NT9 truoc khi xuong dong
					double dbTien_Nt9 = 0;
					if (double.TryParse(dgvEditCt1.CurrentCell.FormattedValue.ToString().Trim(), out dbTien_Nt9))
					{
						dgvEditCt1.CancelEdit();
						drCurrent = ((DataRowView)bdsEditCt.Current).Row;
						drCurrent["TIEN_NT9"] = dbTien_Nt9;
						Voucher.Calc_So_Luong(drCurrent);
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
			if (Common.Inlist(strCurrentColumn, "TIEN"))
			{
				if (dgvEditCt1.bIsCurrentLastRow)
				{
					// Cap nhat Tien truoc khi xuống dòng
					double dbTien = 0;
					if (double.TryParse(dgvEditCt1.CurrentCell.FormattedValue.ToString().Trim(), out dbTien))
					{
						dgvEditCt1.CancelEdit();
						drCurrent = ((DataRowView)bdsEditCt.Current).Row;
						drCurrent["TIEN"] = dbTien;
						Voucher.Calc_So_Luong(drCurrent);
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

		public void Update_Gia_Vt(DataRow drEditCt)
		{
			//Chi cap nhật gia vat tu khi co so luong
			if (drEditCt["Ma_Vt"] == DBNull.Value || (string)drEditCt["Ma_Vt"] == string.Empty)
				return;

			if (drEditCt["So_Luong9"] == DBNull.Value || Convert.ToDouble(drEditCt["So_Luong9"]) == 0)
				return;

			if (drEditCt["Gia_Nt9"] != DBNull.Value && Convert.ToDouble(drEditCt["Gia_Nt9"]) != 0)
				return;

			Hashtable htParameter = new Hashtable();
			htParameter.Add("MA_VT", (string)drEditCt["Ma_Vt"]);
			htParameter.Add("MA_DT", (string)drEditCt["Ma_Dt"]);
			htParameter.Add("NGAY_CT", this.dteNgay_Ct.Text);

			drEditCt["Gia_Nt9"] = SQLExec.ExecuteReturnValue("sp_GetGiaBan", htParameter, CommandType.StoredProcedure);
		}

		#endregion
			
		#region Su kien

		#region FormEvent				

		void txtMa_Ct_Enter(object sender, EventArgs e)
		{
			string strCreate_Log = Common.Show_Log((string)drEditPh["Create_Log"]);
			string strLastModify_Log = Common.Show_Log((string)drEditPh["LastModify_Log"]);
			string strLog = string.Empty;
			strLog += strCreate_Log != string.Empty ? "; Create: " + strCreate_Log : "";
			strLog += strLastModify_Log != string.Empty ? "; Last Modify: " + strLastModify_Log : "";

			this.ucNotice.SetText(txtMa_Ct.Text, dicName.GetValue("Ten_Ct") + strLog);
		}
		void txtMa_Ct_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Ct.Text.Trim();
			bool bRequire = true;
			string strKey = "(Table_Ct = '" + (string)drDmCt["Table_Ct"] + "')";

			frmQuickLookup frmLookup = new frmQuickLookup("SYSDMCT", "DMCT");
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "SYSDMCT", "Ma_Ct", strValue, bRequire, strKey);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
				txtMa_Ct.Text = string.Empty;
			else
			{
				txtMa_Ct.Text = drLookup["Ma_Ct"].ToString();

				dicName.SetValue("Ten_Ct", drLookup["Ten_Ct"].ToString());
			}
		}
		void txtMa_Ct_TextChanged(object sender, EventArgs e)
		{
			this.drDmCt = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", this.strMa_Ct);
		}		

		void txtMa_Tte_Leave(object sender, EventArgs e)
		{
			this.Ma_Tte_Valid();
			Voucher.Update_Detail(this);
			Voucher.Calc_Tien_All(this);			
		}
		void numTy_Gia_Leave(object sender, EventArgs e)
		{
			if (this.txtMa_Tte.Text.Trim() == Element.sysMa_Tte && this.numTy_Gia.Value == 0)
				this.numTy_Gia.Value = 1;

			Voucher.Update_Detail(this);
			Voucher.Calc_Tien_All(this);
			Voucher.Calc_Tien_Von_All(this);
		}		
		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
            Common.ResetTextChange(this);

            string strValue = txtMa_Dt.Text.Trim();
            bool bRequire = true;

            //
            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt.Text = string.Empty;
                txtTen_Dt.Text = string.Empty;
            }
            else
            {
                txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
                txtTen_Dt.Text = drLookup["Ten_Dt"].ToString();

                if (txtMa_Dt.bTextChange && this.enuNew_Edit == enuEdit.New)//Khi them moi thi cap nhat Ong_Ba, Dia_Chi theo Ma_Dt
                {
                    txtOng_Ba.Text = drLookup["Ong_Ba"].ToString() == string.Empty ? drLookup["Ten_Dt"].ToString() : drLookup["Ong_Ba"].ToString();
                    txtDia_Chi.Text = drLookup["Dia_Chi"].ToString();
                }
                if (txtMa_Dt.bTextChange && this.enuNew_Edit == enuEdit.Edit)//Khi sua chung tu
                {
                    if (txtOng_Ba.Text == "")
                        txtOng_Ba.Text = drLookup["Ong_Ba"].ToString() == string.Empty ? drLookup["Ten_Dt"].ToString() : drLookup["Ong_Ba"].ToString();
                    if (txtDia_Chi.Text == "")
                        txtDia_Chi.Text = drLookup["Dia_Chi"].ToString();
                }

                //Cap nhat xuong chi tiet
                if (txtMa_Dt.Text != (string)drEditPh["Ma_Dt"])
                {
                    foreach (DataRow dr in dtEditCt.Rows)
                    {
                        if ((string)dr["Ma_Dt"] == (string)drEditPh["Ma_Dt"])
                            dr["Ma_Dt"] = txtMa_Dt.Text;
                    }
                }
            }

            //dicName[txtTen_Dt.Name] = txtTen_Dt.Text;

            Common.GatherMemvar(this, ref drEditPh);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}		
		void txtMa_Thue_Enter(object sender, EventArgs e)
		{
			this.ucNotice.Text = dicName.GetValue("Ten_Thue");            
		}

        void linkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string currentDir = Environment.CurrentDirectory;
            System.Diagnostics.Process.Start(currentDir + @"\Help\" + drDmCt["Help_File"]);
        }

        void dteNgay_DkHt_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToDateTime(dteNgay_DkHt.Text) < Convert.ToDateTime(dteNgay_Ct.Text))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Ngày dự kiến giao hàng >= Ngày chứng từ !" : "Date of expected delivery >= Date of the vouchers";
                Common.MsgCancel(strMsg);
                dteNgay_DkHt.Focus();
            }
        }

        private void DteNgay_Ct_Validating(object sender, CancelEventArgs e)
        {
            //Tu dong tao so chung tu
            if ((bool)SQLExec.ExecuteReturnValue("SELECT Is_So_Ct FROM SYSDMCT WHERE Ma_Ct = '" + strMa_Ct + "'") == true)//1: Tính tự động, 0-Tính theo thủ công từng tháng
                Cong_So_Ct_Auto();

            this.Ma_Tte_Valid();
            Common.GatherMemvar(this, ref drEditPh);
        }
        void dteNgay_Gh_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToDateTime(dteNgay_Gh.Text) < Convert.ToDateTime(dteNgay_Ct.Text))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Ngày giao hàng >= Ngày chứng từ" : "Delivery date >= Date of the vouchers";
                Common.MsgCancel(strMsg);
                dteNgay_Gh.Focus();
            }
        }
		void txtMa_Thue_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Thue.Text;
			bool bRequire = false;

			string strMa_Thue_Old = drEditPh["Ma_Thue"] == DBNull.Value ? string.Empty : (string)drEditPh["Ma_Thue"];

			//
			DataRow drLookup = Lookup.ShowLookup("Ma_Thue", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
		
				numTTien_Nt3.bReadOnly = true;
				numTTien3.bReadOnly = true;
		
				numTTien_Nt3.TabStop = false;
				numTTien3.TabStop = false;		

				txtMa_Thue.Text = string.Empty;	

			}
			else
			{			
				numTTien_Nt3.bReadOnly = false;
				numTTien3.bReadOnly = false;
				
				numTTien_Nt3.TabStop = true;
				numTTien3.TabStop = true;				

				string strMa_Thue = (string)drLookup["Ma_Thue"];
				txtMa_Thue.Text = strMa_Thue;

				if (strMa_Thue != strMa_Thue_Old)
				{
					//Đưa Thue_Gtgt vào drEditPh vào để cập nhật xuống Detail
					this.drEditPh["Thue_Gtgt"] = drLookup["Thue_Suat"];
				}

				string strMa_Dt = txtMa_Dt.Text;
				DataRow drDmDt = DataTool.SQLGetDataRowByID("LIDOITUONG", "Ma_Dt", strMa_Dt);				

				dicName.SetValue("Ten_Thue", drLookup["Ten_Thue"].ToString());
			}
            
			Voucher.Update_Detail(this, "Ma_Thue, Thue_Gtgt");
            Voucher.Adjust_TThue_Vat(this, true);
			Voucher.Calc_Thue_Vat_All(this);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}        
		void frmEditCtTien_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F8:
					Voucher.DeleteRow(this, dgvEditCt1);
					break;

				case Keys.Up:
					if (this.dgvEditCt1.Focused && this.dgvEditCt1.bIsCurrentFirstRow)
						this.SelectNextControl(dgvEditCt1, false, true, true, true);
					break;                
         
			}

			if (!this.dgvEditCt1.Focused)
				this.dgvEditCt1.ClearSelection();		
		}
        
		void numTTien_Validated(object sender, EventArgs e)
		{
			TTien_Valid();
		}
		void numTTien_Nt_Validated(object sender, EventArgs e)
		{
			TTien_Valid();
		}
		void numTTien3_Validated(object sender, EventArgs e)
		{
			TTien_Valid();
		}
		void numTTien_Nt3_Validated(object sender, EventArgs e)
		{
			TTien_Valid();
		}

		#endregion

		#region DataGridViewEvent

		void dgvEditCt_CellEnter(object sender, DataGridViewCellEventArgs e)
		{//Xu ly Notice

			dgvVoucher dgvEditCt = (dgvVoucher)sender;

			if (dgvEditCt.CurrentCell == null)
				return;

			if (this.ActiveControl != dgvEditCt)
				return;

			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (Common.Inlist(strColumnName, "GIA_NT, GIA, TIEN_NT, TIEN"))
			{
				if ((bool)dgvEditCt1.CurrentRow.Cells["AUTO_COST"].Value == true)
				{
					dgvCell.ReadOnly = true;
					dgvCell.Value = 0;
				}
				else
					dgvCell.ReadOnly = false;
			}			
		}

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
				
				if (strColumnName == "MA_VT")
					bLookup = dgvLookupMa_Vt(ref dgvCell);

                else if (strColumnName == "MA_KHO")
                    bLookup = dgvLookupMa_Kho(ref dgvCell);
                
                else if (strColumnName == "MA_CBNV")
                    bLookup = dgvLookupMa_CbNv(ref dgvCell);
                
                else if (strColumnName == "MA_PO")
                    bLookup = dgvLookupMa_Po(ref dgvCell);

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

			if (Common.Inlist(strColumnName, "SO_LUONG9"))
			{
				Update_Gia_Vt(drCurrent);				
			}

			if (Common.Inlist(strColumnName, "SO_LUONG9,GIA_NT9,TIEN_NT9,TIEN"))
			{
				Voucher.Calc_So_Luong(drCurrent);
				Voucher.Update_TTien(this);		
			}

			else if (Common.Inlist(strColumnName, "TIEN"))
			{
				Voucher.Calc_Tien(drCurrent);
				Voucher.Update_TTien(this);
			}

			bdsEditCt.EndEdit();//Cap nhat lai DataSource                   
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

		void dgvEditCt_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
				if (dgvEditCt1.CurrentCell.OwningColumn.DataPropertyName == "DVT")
				{
					drCurrent = ((DataRowView)bdsEditCt.Current).Row;
					string strMa_Vt = (string)drCurrent["Ma_Vt"];
					string strDvt_Old = (string)drCurrent["Dvt"];
					string strDvt_Chuan = string.Empty;

					DataRow drDmVt = DataTool.SQLGetDataRowByID("LIVATTU", "Ma_Vt", strMa_Vt);
					strDvt_Chuan = (string)drDmVt["Dvt"];

					string inputMask = (string)drDmVt["Dvt"];

					for (int i = 1; i <= 3; i++)
						inputMask += (string)drDmVt["Dvt" + i] == string.Empty ? string.Empty : "," + (string)drDmVt["Dvt" + i];

					if (inputMask != string.Empty)
						inputMask += "," + inputMask;
					if (inputMask == null || inputMask == string.Empty)
						return;

					string[] strArrInputMask = inputMask.Split(',');
					for (int i = 0; i <= strArrInputMask.Length - 1; i++)
						if (strArrInputMask[i] == strDvt_Old)
						{
							drCurrent["Dvt"] = strArrInputMask[i + 1];
							break;
						}

					if ((string)drCurrent["Dvt"] == strDvt_Chuan)
						drCurrent["He_So9"] = 1;
					else
						for (int i = 1; i <= 3; i++)
							if ((string)drDmVt["Dvt" + i] == (string)drCurrent["Dvt"])
								drCurrent["He_So9"] = drDmVt["He_So" + i];

					Voucher.Calc_So_Luong(drCurrent);
				}
		}

		#endregion

		#region DataGridViewLookup		
		private bool dgvLookupMa_Vt(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

			//frmVatTu frmLookup = new frmVatTu();
			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				drCurrent = ((DataRowView)bdsEditCt.Current).Row;

				string strMa_Vt_Old = drCurrent["Ma_Vt"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt"];

                if (drCurrent.HasVersion(DataRowVersion.Original))
                    strMa_Vt_Old = drCurrent["Ma_Vt", DataRowVersion.Original] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt", DataRowVersion.Original];
                else
                    strMa_Vt_Old = drCurrent["Ma_Vt"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt"];

				string strMa_Vt = (string)drLookup["Ma_Vt"];

				dgvEditCt1.CancelEdit();
				dgvCell.Value = drLookup["Ma_Vt"].ToString();
				dgvCell.Tag = drLookup["Ten_Vt"].ToString();

                if (strMa_Vt != strMa_Vt_Old)
                {
                    drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];
                    drCurrent["Dvt"] = drLookup["Dvt"];
                    drCurrent["He_So9"] = 1;

                    Voucher.Calc_So_Luong(drCurrent);
                }
                else
                {
                    if (drCurrent["Ten_Vt"] == DBNull.Value || (string)drCurrent["Ten_Vt"] == string.Empty)
                        drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];

                    if (drCurrent["Dvt"] == DBNull.Value || (string)drCurrent["Dvt"] == string.Empty)
                        drCurrent["Dvt"] = drLookup["Dvt"];
                }
			}
			return true;
		}
        private bool dgvLookupMa_Kho(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;

            //
            DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvEditCt1.CancelEdit();
                dgvCell.Value = drLookup["Ma_Kho"].ToString();
                dgvCell.Tag = drLookup["Ten_Kho"].ToString();
            }
            return true;
        }
        private bool dgvLookupMa_Po(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;

            //frmPo frmLookup = new frmPo();
            DataRow drLookup = Lookup.ShowLookup("Ma_Po", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvEditCt1.CancelEdit();
                dgvCell.Value = drLookup["Ma_Po"].ToString();
                dgvCell.Tag = drLookup["Ten_Po"].ToString();
            }
            return true;
        }
        private bool dgvLookupMa_CbNv(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;

            //
            DataRow drLookup = Lookup.ShowLookup("Ma_CbNv", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvEditCt1.CancelEdit();
                dgvCell.Value = drLookup["Ma_CbNv"].ToString();
                dgvCell.Tag = drLookup["Ten_CbNv"].ToString();
            }
            return true;
        }
		#endregion

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			this.dgvEditCt1.ClearSelection(); //Chi co tac dung sau khi show form

			if (this.enuNew_Edit == enuEdit.Edit)
			{
                //Chứng từ đã duyệt -> không cho sửa
                if (!Element.sysIs_Admin) //Nếu không phải là Admin
                {
                    if (Parameters.GetParaValue("NOT_EDIT_DUYET").ToString().Trim() == "1" && drEditPh["Duyet_Log"].ToString() != "" && (bool)drEditPh["Duyet"] == true)
                    {
                        this.btgAccept.btAccept.Enabled = false;
                    }
                }

				if (!Common.CheckDataLocked((DateTime)drEdit["Ngay_Ct"]))
				{
					this.dteNgay_Ct.Enabled = false;
					this.btgAccept.btAccept.Enabled = false;
				}

                //if (!Element.sysIs_Admin)
                //{
                //	string strCreate_User = (string)drEditPh["Create_Log"];

                //	if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
                //	{
                //		string strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM SYSMEMBER WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";

                //		if (!strUser_Allow.Contains("*,")) //Được phép sửa tất cả
                //		{
                //			if (!strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
                //			{
                //				this.btgAccept.btAccept.Enabled = false;
                //				return;
                //			}
                //		}
                //	}
                //}

                //Sua chung tu
                string strCreate_User = (string)drEditPh["Create_Log"];
                if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
                {
                    string strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM SYSMEMBER WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";

                    if (!strUser_Allow.Contains("*,")) //Được phép sửa tất cả
                    {
                        if (!strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
                        {
                            this.btgAccept.btAccept.Enabled = false;
                            return;
                        }
                    }
                }

            }
		}
        
	}
}
