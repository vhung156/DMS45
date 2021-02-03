using System;
using System.Collections.Generic;
using System.Collections;
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

namespace Epoint.Modules.IN
{
	public partial class frmCtLR_Edit : frmVoucher_Edit, IEditCtLR
	{
		private string strTk_NoTmp = string.Empty;
		private string strTk_CoTmp = string.Empty;
        private string strModule = "05";

		DataTable dtEdiCt_LR;

		#region Contructor

		public frmCtLR_Edit()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(frmEditCtTien_KeyDown);
                        
            tabVoucher.SelectedIndexChanged += new EventHandler(tabVoucher_SelectedIndexChanged);
            tabVoucher.Enter += new EventHandler(tabVoucher_Enter);

			//txtMa_Dt.Enter += new EventHandler(txtMa_Dt_Enter);
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);

			txtMa_Hd.Enter += new EventHandler(txtMa_Hd_Enter);
			txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);
            
			txtMa_VtN.Enter += new EventHandler(txtMa_VtN_Enter);
			txtMa_VtN.Validating += new CancelEventHandler(txtMa_VtN_Validating);

			txtMa_KhoN.Enter += new EventHandler(txtMa_KhoN_Enter);
			txtMa_KhoN.Validating += new CancelEventHandler(txtMa_KhoN_Validating);

			txtMa_Ct.Enter += new EventHandler(txtMa_Ct_Enter);
			txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
			txtMa_Ct.TextChanged += new EventHandler(txtMa_Ct_TextChanged);

			txtSo_Ct.Validating += new CancelEventHandler(txtSo_Ct_Validating);
            linkHelp.LinkClicked += new LinkLabelLinkClickedEventHandler(linkHelp_LinkClicked);

			dteNgay_Ct.Validating += new CancelEventHandler(dteNgay_Ct_Validating);
			txtMa_Tte.Validating += new CancelEventHandler(txtMa_Tte_Validating);
			numTy_Gia.Leave += new EventHandler(numTy_Gia_Leave);

			//txtTk_No.Validating += new CancelEventHandler(txtTk_No_Validating);

			dgvEditCt1.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt_CellValidating);
			dgvEditCt1.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
			dgvEditCt1.CellEnter += new DataGridViewCellEventHandler(dgvEditCt_CellEnter);
			dgvEditCt1.KeyDown += new KeyEventHandler(dgvEditCt_KeyDown);

			dgvEditCt2.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt2_CellValidating);
			dgvEditCt2.CellValidated += new DataGridViewCellEventHandler(dgvEditCt2_CellValidated);
			dgvEditCt2.CellEnter += new DataGridViewCellEventHandler(dgvEditCt2_CellEnter);

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

			if (enuNew_Edit == enuEdit.New)
                this.strStt = Common.GetNewStt(strModule, true);
			else
				this.strStt = drEdit["Stt"].ToString();

			this.Build();
			this.FillData();
			this.Init_Ct();

			Common.ScaterMemvar(this, ref drEditPh);

			txtMa_Tte.bTextChange = false;
			numTy_Gia.bTextChange = false;

			this.Ma_Tte_Valid();
			this.BindingLanguage();
			this.LoadDicName();

			if (!isAccept)
				this.ShowDialog();
			else
				this.ActiveControl = txtMa_Ct;
		}

		#endregion

		#region Phuong thuc

		private void Build()
		{
			dgvEditCt1.bSortMode = false;
			dgvEditCt1.strZone = (string)drDmCt["Zone_EditCt1"];
			dgvEditCt1.BuildGridView();

			dgvEditCt2.bSortMode = false;
			dgvEditCt2.strZone = (string)drDmCt["Zone_EditCt2"];
			dgvEditCt2.BuildGridView();

			dgvEditCt2.Height = dgvEditCt1.Height;
			dgvEditCt2.Width = dgvEditCt1.Width;
			dgvEditCt2.Location = dgvEditCt1.Location;
			dgvEditCt2.Anchor = dgvEditCt1.Anchor;
			dgvEditCt2.Visible = false;
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

			dgvEditCt2.DataSource = bdsEditCt;
			dgvEditCt2.ClearSelection();

			//dtEdiCt_LR
			string strSelectCtLR = enuNew_Edit == enuEdit.New ? " TOP 0 * " : " TOP 1 * ";// 
			dtEdiCt_LR = DataTool.SQLGetDataTable("INLAPRAP", strSelectCtLR, strKeyFillterCt, null);
			if (dtEdiCt_LR.Rows.Count == 0)
				dtEdiCt_LR.Rows.Add(dtEdiCt_LR.NewRow());

		}

		private void Init_Ct()
		{
			txtMa_Tte.InputMask = (string)Systems.Librarys.Parameters.GetParaValue("MA_TTE_LIST");

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

				//Ngầm định 1 số thông tin từ chứng từ cũ
				if (drEdit != null)
					Common.CopyDataRow(drEdit, drCurrent, (string)drDmCt["Carry_Header"]);

				drCurrent["Ma_DvCs"] = Element.sysMa_DvCs;
				drCurrent["Stt"] = strStt;
				drCurrent["Stt0"] = 1;
				drCurrent["Ma_Ct"] = strMa_Ct;
				drCurrent["Ngay_Ct"] = drEdit["Ngay_Ct"] != DBNull.Value ? drEdit["Ngay_Ct"] : DateTime.Now;

				drCurrent["Tk_No"] = (string)drDmCt["Tk_No"];
				drCurrent["Tk_Co"] = (string)drDmCt["Tk_Co"];
				drCurrent["Ma_Tte"] = Element.sysMa_Tte;
				drCurrent["Ty_Gia"] = 1;

				if (dtEditCt.Columns.Contains("Auto_Cost") && (string)drDmCt["Nh_Ct"] == "2")
					drCurrent["Auto_Cost"] = true;

				drCurrent["Deleted"] = false;

				//Tinh so chung tu
				string strLoai_Ma_Ct = ((DateTime)drCurrent["Ngay_Ct"]).Month.ToString().Trim();
				string strSQLExec = "EXEC Sp_Cong_So_Ct '" + strMa_Ct + "', '" + strLoai_Ma_Ct + "'";

				DataTable dtSo_Ct = SQLExec.ExecuteReturnDt(strSQLExec);

				if (dtSo_Ct.Rows.Count > 0)
					drCurrent["So_Ct"] = (string)dtSo_Ct.Rows[0][0];

				//Clear Content in drEditPh
				foreach (DataColumn dcEditPh in dtEditPh.Columns)
					drEditPh[dcEditPh] = DBNull.Value;

				drEditPh["Ma_DvCs"] = drCurrent["Ma_DvCs"];
				drEditPh["Stt"] = drCurrent["Stt"];
				drEditPh["Ma_Ct"] = drCurrent["Ma_Ct"];
				drEditPh["Ngay_Ct"] = drCurrent["Ngay_Ct"];
				drEditPh["So_Ct"] = drCurrent["So_Ct"];

                //if (strMa_Ct == "TR")
                //{
                //    //Chuyển Tk_Co -> Tk_No
                //    lblTk_No.Name = "lblTk_Co";
                //    lblTk_No.Tag = "Tk_Co";
                //    txtTk_No.Name = "txtTk_Co";
                //}

				if (drEditPh.Table.Columns.Contains("Duyet"))
					drEditPh["Duyet"] = (bool)drDmCt["Default_Duyet"];
                if (drEditPh.Table.Columns.Contains("Is_Thue_Vat"))
                    drEditPh["Is_Thue_Vat"] = (bool)drDmCt["Default_VAT"];
			}

			Voucher.Update_Header(this);
            Voucher.Update_Stt(this, strModule);

			dgvEditCt1.Columns["Dvt"].ReadOnly = true;
			//BindingTTien                      
			if (isAccept)
			{
				numTTien.DataBindings.Clear();
				numTTien_Nt.DataBindings.Clear();
				numTSo_Luong.DataBindings.Clear();
			}

			numTTien.DataBindings.Add("Value", dtEditPh, "TTien");
			numTTien_Nt.DataBindings.Add("Value", dtEditPh, "TTien_Nt");
			numTSo_Luong.DataBindings.Add("Value", dtEditPh, "TSo_Luong");

			//CTNXLR
			if (strMa_Ct == "LR" && enuNew_Edit == enuEdit.Edit)
			{
				txtMa_VtN.Text = (string)dtEdiCt_LR.Rows[0]["Ma_Vt"];
				txtMa_KhoN.Text = (string)dtEdiCt_LR.Rows[0]["Ma_Kho"];
				lbtTen_VtN.Text = dtEdiCt_LR.Rows[0]["Ten_Vt"].ToString();

				numSo_LuongN.Value = Convert.ToDouble(dtEdiCt_LR.Rows[0]["So_Luong9"]);
			}
		}

		private void LoadDicName()
		{
			if (txtMa_Ct.Text.Trim() != string.Empty && drDmCt != null)
			{
				dicName.SetValue("Ten_Ct", (string)drDmCt["Ten_Ct"]);
			}

			//txtMa_Dt
            //if (txtMa_Dt.Text.Trim() != string.Empty)
            //{
            //    txtTen_Dt.Text = DataTool.SQLGetNameByCode("LIDOITUONG", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
            //    dicName.SetValue(txtTen_Dt.Name, txtTen_Dt.Text);
            //}
            //else
            //    txtTen_Dt.Text = string.Empty;

			//txtMa_Hd
			if (txtMa_Hd.Text.Trim() != string.Empty)
			{
				txtTen_Hd.Text = DataTool.SQLGetNameByCode("LIHOPDONG", "Ma_Hd", "Ten_Hd", txtMa_Hd.Text.Trim());
				dicName.SetValue(txtTen_Hd.Name, txtTen_Hd.Text);
			}
			else
				txtTen_Hd.Text = string.Empty;

            //txtMa_VtN
            if (txtMa_VtN.Text.Trim() != string.Empty)
            {
                lbtTen_VtN.Text = DataTool.SQLGetNameByCode("LIVATTU", "Ma_Vt", "Ten_Vt", txtMa_VtN.Text.Trim());
                dicName.SetValue(lbtTen_VtN.Name, lbtTen_VtN.Text);
            }
            else
                lbtTen_VtN.Text = string.Empty;
		}

		private bool FormCheckValid()
		{
			if (!Common.CheckDataLocked(Library.StrToDate(this.dteNgay_Ct.Text)))
				return false;

			if (Common.GetPartitionCurrent() != 0 && this.enuNew_Edit == enuEdit.Edit && this.drEditPh["Ngay_Ct", DataRowVersion.Original] != DBNull.Value)
			{
				if (((DateTime)this.drEditPh["Ngay_Ct"]).Year != ((DateTime)this.drEditPh["Ngay_Ct", DataRowVersion.Original]).Year)
				{
					Common.MsgCancel("Dữ liệu đã phân vùng, không cho phép sửa chứng từ từ năm này sang năm khác");
					return false;
				}
			}

			if (txtMa_VtN.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_VtN") + " " +
							  Languages.GetLanguage("Not_Null"));

				return false;
			}

			if (txtMa_KhoN.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_KhoN") + " " +
							  Languages.GetLanguage("Not_Null"));

				return false;
			}

			if (numSo_LuongN.Value == 0)
			{
				Common.MsgOk(Languages.GetLanguage("So_LuongN") + " " +
							  Languages.GetLanguage("Not_Null"));

				return false;
			}

			return true;
		}

		public override bool Save()
		{
			Common.GatherMemvar(this, ref this.drEditPh);
			Voucher.Update_Detail(this);

			if (!FormCheckValid())
				return false;

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

			Voucher.Update_TTien(this);
            Voucher.Update_Stt(this, strModule);

			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
				if (dtEditCt.Rows.Count > 0) //Cập nhật lại dữ liệu từ chi tiết lên Header
					Common.CopyDataRow(dtEditCt.Rows[0], drEditPh, (string)drDmCt["Update_Header"]);

				drEdit = drEditPh;
			}

			return Voucher.SQLUpdateCt(this);
		}

		public DataTable dtEdiCtLR
		{
			get
			{
				//Lưu vào R05CTNLR đối với phiếu lắp ráp, R05CTXLR đối với phiếu tháo ráp							
				DataRow drEditCtLR = dtEdiCt_LR.Rows[0];
				Common.CopyDataRow(this.dtEditCt.Rows[0], drEditCtLR);

				drEditCtLR["Ma_Kho"] = txtMa_KhoN.Text.Trim();
				drEditCtLR["Ma_Vt"] = txtMa_VtN.Text;
				drEditCtLR["Ten_Vt"] = lbtTen_VtN.Text;
				drEditCtLR["So_Luong9"] = numSo_LuongN.Value;
				drEditCtLR["He_So9"] = 1;
				drEditCtLR["So_Luong"] = numSo_LuongN.Value;

				return dtEdiCt_LR;
			}

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

				if (dgvEditCt2.Columns.Contains("TIEN3"))
					dgvEditCt2.Columns["TIEN3"].Visible = false;

				if (dgvEditCt2.Columns.Contains("TIEN5"))
					dgvEditCt2.Columns["TIEN5"].Visible = false;

				if (dgvEditCt2.Columns.Contains("TIEN6"))
					dgvEditCt2.Columns["TIEN6"].Visible = false;
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

				if (dgvEditCt2.Columns.Contains("TIEN3"))
					dgvEditCt2.Columns["TIEN3"].Visible = true;

				if (dgvEditCt2.Columns.Contains("TIEN5"))
					dgvEditCt2.Columns["TIEN5"].Visible = true;

				if (dgvEditCt2.Columns.Contains("TIEN6"))
					dgvEditCt2.Columns["TIEN6"].Visible = true;
			}

			if (dteNgay_Ct.Text != Library.DateToStr((DateTime)drEditPh["Ngay_Ct"]) || txtMa_Tte.bTextChange || numTy_Gia.bTextChange)
			{
				Common.GatherMemvar(this, ref this.drEditPh);
				Voucher.Update_Detail(this);
				Voucher.Calc_Tien_All(this);

				if (txtMa_Tte.bTextChange)
					txtMa_Tte.bTextChange = false;
			}

			numTTien_Nt.Scale = strMa_Tte == Element.sysMa_Tte ? 0 : 2;

			Voucher.FormatTien_Nt(dgvEditCt1, strMa_Tte);
			Voucher.FormatTien_Nt(dgvEditCt2, strMa_Tte);

			dgvEditCt1.ResizeGridView();
			dgvEditCt2.ResizeGridView();
		}

		private bool CellKeyEnter()
		{//Ham thuc hien phim Enter: true: thuc hien thanh cong, false: khong thuc hien duoc

			if (dgvEditCt1.CurrentCell == null )
				return false;

			DataGridViewCell dgvCell = dgvEditCt1.CurrentCell;
			string strCurrentColumn = dgvCell.OwningColumn.Name.ToUpper();

			#region Enter tai Ten_Vt
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
                // Cap nhat tien TIEN truoc khi xuong dong
                double dbTien = 0;
                if (double.TryParse(dgvEditCt1.CurrentCell.FormattedValue.ToString().Trim(), out dbTien))
                {
                    dgvEditCt1.CancelEdit();
                    drCurrent = ((DataRowView)bdsEditCt.Current).Row;
                    drCurrent["TIEN"] = dbTien;
                    Voucher.Calc_So_Luong(drCurrent);
                    Voucher.Update_TTien(this);
                }

				if (dgvEditCt1.bIsCurrentLastRow)
				{
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

        void linkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string currentDir = Environment.CurrentDirectory;
            System.Diagnostics.Process.Start(currentDir + @"\Help\" + drDmCt["Help_File"]);
        }

		void txtSo_Ct_Validating(object sender, CancelEventArgs e)
		{
			if (txtSo_Ct.Text == string.Empty)
				return;

			string strTablePh = (string)drDmCt["Table_Ph"];
			string strMa_Ct = txtMa_Ct.Text;
			string strSo_Ct = txtSo_Ct.Text;

			DateTime dNgay_Ct = Library.StrToDate(dteNgay_Ct.Text);

			string strSQLExec = "SELECT COUNT(Stt) FROM " + strTablePh + " WHERE Stt <> @Stt AND So_Ct = @So_Ct AND MONTH(Ngay_Ct) = MONTH(@Ngay_Ct) AND YEAR(Ngay_Ct) = @Nam AND Ma_Ct = @Ma_Ct AND Ma_DvCs = @Ma_DvCs";

			Hashtable ht = new Hashtable();
			ht.Add("MA_CT", strMa_Ct);
			ht.Add("SO_CT", strSo_Ct);
			ht.Add("NGAY_CT", dNgay_Ct);
			ht.Add("NAM", dNgay_Ct.Year);
			ht.Add("STT", drEditPh["Stt"]);
			ht.Add("MA_DVCS", Element.sysMa_DvCs);

			if (Convert.ToInt32(SQLExec.ExecuteReturnValue(strSQLExec, ht, CommandType.Text)) > 0)
			{
				if (!Common.MsgYes_No("Chứng từ số: " + txtSo_Ct.Text + " Ngày: " + dteNgay_Ct.Text + " đã tồn tại.\n Bạn có muốn tiếp tục không ?"))
					e.Cancel = true;
			}
		}

		void dteNgay_Ct_Validating(object sender, CancelEventArgs e)
		{
			this.Ma_Tte_Valid();
			Common.GatherMemvar(this, ref drEditPh);
		}
		void txtMa_Tte_Validating(object sender, CancelEventArgs e)
		{
			this.Ma_Tte_Valid();
		}
		void numTy_Gia_Leave(object sender, EventArgs e)
		{
			this.Ma_Tte_Valid();
		}

        //void txtMa_Dt_Enter(object sender, EventArgs e)
        //{
        //    txtTen_Dt.Text = dicName.GetValue(txtTen_Dt.Name);
        //}
		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
            Common.ResetTextChange(this);
            
            string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = true;

            //frmDoiTuong frmLookup = new frmDoiTuong();
			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "","");

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
				//txtTen_Dt.Text = drLookup["Ten_Dt"].ToString();

				if (txtMa_Dt.bTextChange)
				{
                    txtTen_Dt.Text = drLookup["Ten_Dt"].ToString();
					txtOng_Ba.Text = drLookup["Ong_Ba"].ToString() == string.Empty ? drLookup["Ten_Dt"].ToString() : drLookup["Ong_Ba"].ToString();
					txtDia_Chi.Text = drLookup["Dia_Chi"].ToString();
				}
			}

			//dicName[txtTen_Dt.Name] = txtTen_Dt.Text;

			Voucher.Update_Detail(this, "Ma_Dt");

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

		void txtMa_Hd_Enter(object sender, EventArgs e)
		{
			txtTen_Hd.Text = dicName.GetValue(txtTen_Hd.Name);
		}
		void txtMa_Hd_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Hd.Text.Trim();
			bool bRequire = false;

            //frmHopDong frmLookup = new frmHopDong();
			DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Hd.Text = string.Empty;
				txtTen_Hd.Text = string.Empty;
			}
			else
			{
				txtMa_Hd.Text = drLookup["Ma_Hd"].ToString();
				txtTen_Hd.Text = drLookup["Ten_Hd"].ToString();

				if (txtMa_Hd.bTextChange)
				{
					txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
					DataRow drDmDt = DataTool.SQLGetDataRowByID("LIDOITUONG", "Ma_Dt", (string)drLookup["Ma_Dt"]);
					if (drDmDt != null)
					{
						txtTen_Dt.Text = (string)drDmDt["Ten_Dt"];
						if ((string)drDmDt["Ong_Ba"] != string.Empty)
							txtOng_Ba.Text = (string)drDmDt["Ong_Ba"];
						else
							txtOng_Ba.Text = (string)drDmDt["Ten_Dt"];
						txtDia_Chi.Text = (string)drDmDt["Dia_Chi"];
					}
				}
			}

			dicName.SetValue(txtTen_Hd.Name, txtTen_Hd.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}		
		void txtMa_VtN_Enter(object sender, EventArgs e)
		{
			ucNotice.SetText(txtMa_VtN.Text, dicName.GetValue("Ten_VtN"));
		}
		void txtMa_VtN_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_VtN.Text.Trim();
			bool bRequire = true;

            //frmVatTu frmLookup = new frmVatTu();
			DataRow drLookup = Lookup.ShowLookup( "Ma_Vt" ,strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_VtN.Text = string.Empty;
				dicName.SetValue("Ten_VtN", string.Empty);
			}
			else
			{
				txtMa_VtN.Text = drLookup["Ma_Vt"].ToString();
				lbtTen_VtN.Text = drLookup["Ten_Vt"].ToString();
			}

			ucNotice.SetText(txtMa_VtN.Text, dicName.GetValue("Ten_VtN"));

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

		void txtMa_KhoN_Enter(object sender, EventArgs e)
		{
			ucNotice.SetText(txtMa_KhoN.Text, dicName.GetValue("Ten_KhoN"));
		}
		void txtMa_KhoN_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_KhoN.Text.Trim();
			bool bRequire = false;

            //frmKho frmLookup = new frmKho();
			DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_KhoN.Text = string.Empty;
				dicName.SetValue("Ten_KhoN", string.Empty);
			}
			else
			{
				txtMa_KhoN.Text = drLookup["Ma_Kho"].ToString();
				dicName.SetValue("Ten_KhoN", drLookup["Ten_Kho"].ToString());
			}

			ucNotice.SetText(txtMa_KhoN.Text, dicName.GetValue("Ten_KhoN"));

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

				case Keys.F4:

					if (tabVoucher.SelectedTab == tpChiTiet1)
                        tabVoucher.SelectedTab = tpChiTiet2;
					else
                        tabVoucher.SelectedTab = tpChiTiet1;
					break;

				case Keys.Up:
					if (this.dgvEditCt1.Focused && this.dgvEditCt1.bIsCurrentFirstRow)
						this.SelectNextControl(dgvEditCt1, false, true, true, true);
					break;
			}

			if (!this.dgvEditCt1.Focused)
				this.dgvEditCt1.ClearSelection();
		}

        //void txtTk_No_Validating(object sender, CancelEventArgs e)
        //{
        //    string strValue = txtTk_No.Text.Trim();
        //    bool bRequire = true;

        //    frmTaiKhoan frmLookup = new frmTaiKhoan();
        //    DataRow drLookup = Lookup.ShowLookup(frmLookup, "LITAIKHOAN", "Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

        //    if (bRequire && drLookup == null)
        //        e.Cancel = true;

        //    if (drLookup == null)
        //    {
        //        txtTk_No.Text = string.Empty;
        //        this.ucNotice.Text = string.Empty;
        //    }
        //    else
        //    {
        //        txtTk_No.Text = drLookup["Tk"].ToString();
        //        lbtTen_Tk_No.Text = drLookup["Ten_Tk"].ToString();

        //        dicName.SetValue("Ten_Tk_No", lbtTen_Tk_No.Text);
        //    }

        //    if ((string)drDmCt["Nh_Ct"] == "1")
        //        Voucher.Update_Detail(this, "Tk_Co");
        //    else
        //        Voucher.Update_Detail(this, "Tk_No");

        //    if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
        //    {
        //        ((txtTextLookup)sender).AutoFilter.Visible = false;
        //        this.SelectNextControl(this.ActiveControl, true, true, true, true);
        //    }
        //}

        void tabVoucher_Enter(object sender, EventArgs e)
        {
            if (tabVoucher.SelectedTab == tpChiTiet1)
            {
                if (bDgvEditCtFocusing)
                    this.dgvEditCt1.Focus();
            }
            else if (tabVoucher.SelectedTab == tpChiTiet2)
            {
                if (bDgvEditCtFocusing)
                    this.dgvEditCt2.Focus();
            }
        }

        void tabVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectNextControl(tabVoucher, true, true, true, true);
        }

		#endregion

		#region DataGridViewEvent

		void dgvEditCt_CellEnter(object sender, DataGridViewCellEventArgs e)
		{//Xu ly hien Notice

			dgvVoucher dgvEditCt = (dgvVoucher)sender;

			if (dgvEditCt.CurrentCell == null)
				return;

			if (this.ActiveControl != dgvEditCt)
				return;

			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (strColumnName == "TK_NO")
				this.strTk_NoTmp = dgvCell.FormattedValue.ToString();

			else if (strColumnName == "TK_CO")
				this.strTk_CoTmp = dgvCell.FormattedValue.ToString();

			if (Common.Inlist(strColumnName, "MA_VT,MA_KHO"))
			{
				if ((string)drCurrent["Ma_Vt"] != string.Empty)
					ucNotice.Text = Voucher.GetTonCuoi(drCurrent);

				dicName.SetValue("TON_CUOI", ucNotice.Text);
			}
			else if (Common.Inlist(strColumnName, "TEN_VT,DVT"))
			{
				ucNotice.Text = dicName.GetValue("TON_CUOI");
			}
			else if (dgvCell.Tag != null)
				ucNotice.Text = (string)dgvCell.Tag;
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

			if (this.ActiveControl == dgvEditCt || this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
			{
				drCurrent = ((DataRowView)bdsEditCt.Current).Row;
				DataGridViewCell dgvCell = dgvEditCt.CurrentCell;
				string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

				bool bLookup = true;

				if (Common.Inlist(strColumnName, "TK_NO,TK_CO"))
					bLookup = dgvLookupTk(ref dgvCell, strColumnName);

				else if (strColumnName == "MA_DT")
					bLookup = dgvLookupMa_Dt(ref dgvCell);

				else if (strColumnName == "MA_BP")
					bLookup = dgvLookupMa_Bp(ref dgvCell);

				else if (strColumnName == "MA_KM")
					bLookup = dgvLookupMa_Km(ref dgvCell);

				else if (strColumnName == "MA_SP")
					bLookup = dgvLookupMa_Sp(ref dgvCell);

				else if (strColumnName == "MA_JOB")
					bLookup = dgvLookupMa_Job(ref dgvCell);

				else if (strColumnName == "MA_VT")
					bLookup = dgvLookupMa_Vt(ref dgvCell);

				else if (strColumnName == "MA_KHO")
					bLookup = dgvLookupMa_Kho(ref dgvCell);

				if (bLookup == false)
					e.Cancel = true;
			}
			else
				dgvEditCt.CancelEdit();
		}

		void dgvEditCt_CellValidated(object sender, DataGridViewCellEventArgs e)
		{//Cai dat cac ham tinh toan

			dgvVoucher dgvEditCt = (dgvVoucher)sender;
			if (this.ActiveControl != dgvEditCt && this.ActiveControl != null && this.ActiveControl.GetType().Name != "DataGridViewTextBoxEditingControl")
				return;

			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (Common.Inlist(strColumnName, "SO_LUONG9,GIA_NT9,TIEN_NT9,TIEN"))
			{
				Voucher.Calc_So_Luong(drCurrent);
				Voucher.Update_TTien(this);

				//Kiểm tra tồn kho
				if ((string)drCurrent["Ma_Vt"] != string.Empty && (string)drCurrent["Ma_Kho"] != string.Empty &&
					(string)drDmCt["Nh_Ct"] == "2" && strColumnName == "SO_LUONG9")
				{
					double dbSo_Luong = Convert.ToDouble(drCurrent["So_Luong"]);
					double dbTon_Cuoi = 0;
					Voucher.GetTonCuoi(drCurrent, ref dbTon_Cuoi);

					if (dbSo_Luong > dbTon_Cuoi)
					{
						string strMsg = string.Empty;

						if (Element.sysLanguage == enuLanguageType.Vietnamese)
							strMsg = "Số lượng xuất: " + dbSo_Luong.ToString("N2") + " > số lượng tồn: " + dbTon_Cuoi.ToString("N2");
						else
							strMsg = "Out quantity: " + dbSo_Luong.ToString("N2") + " > closing inventory quantity: " + dbTon_Cuoi.ToString("N2");

						Common.MsgCancel(strMsg);
					}
				}
			}

			bdsEditCt.EndEdit();//Cap nhat lai DataSource
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

		void dgvEditCt2_CellEnter(object sender, DataGridViewCellEventArgs e)
		{// Hien notice khi Gotfocus

		}

		void dgvEditCt2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{ //Xu ly phim Enter, Lookup danh muc

			if (this.ActiveControl != dgvEditCt2)
				return;

			//Xu ly phim Enter
			if (dgvEditCt2.kLastKey == Keys.Enter)
			{
				dgvEditCt2.kLastKey = Keys.None;

				if (dgvEditCt2.bIsCurrentLastRow && dgvEditCt2.bIsCurrentLastColumn)
				{
					this.SelectNextControl(dgvEditCt2, true, true, true, true);
				}
			}

		}

		void dgvEditCt2_CellValidated(object sender, DataGridViewCellEventArgs e)
		{// Tinh toan cac Gia tri, cong thuc
			bdsEditCt.EndEdit();//Cap nhat lai DataSource
		}

		#endregion

		#region DataGridViewLookup
		private bool dgvLookupTk(ref DataGridViewCell dgvCell, string strColumnName)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = true;

			if (strColumnName == "TK_NO5" || strColumnName == "TK_CO5")
			{
				if (drCurrent["TIEN5"] == DBNull.Value || Convert.ToDouble(drCurrent["TIEN5"]) == 0)
					bRequire = false;
			}
			else
			{
				if (strColumnName == "TK_NO6" || strColumnName == "TK_CO6")
					if (drCurrent["TIEN6"] == DBNull.Value || Convert.ToDouble(drCurrent["TIEN6"]) == 0)
						bRequire = false;
			}

            //frmTaiKhoan frmLookup = new frmTaiKhoan();
			DataRow drLookup = Lookup.ShowLookup( "Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

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
				dgvCell.Value = drLookup["Tk"].ToString();
				dgvCell.Tag = drLookup["Ten_Tk"].ToString();
			}

			return true;
		}

		private bool dgvLookupMa_Dt(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = true;

            //frmDoiTuong frmLookup = new frmDoiTuong();
			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");

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
				dgvCell.Value = drLookup["Ma_Dt"].ToString();
				dgvCell.Tag = drLookup["Ten_Dt"].ToString();
			}
			return true;
		}

		private bool dgvLookupMa_Bp(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

            //frmBoPhan frmLookup = new frmBoPhan();
			DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "");

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
				dgvCell.Value = drLookup["Ma_Bp"].ToString();
				dgvCell.Tag = drLookup["Ten_Bp"].ToString();
			}

			return true;
		}

		private bool dgvLookupMa_Km(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;
			object objReturn = null;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			string strTk_No = (string)drCurrent["Tk_No"];
			string strTk_Co = (string)drCurrent["Tk_Co"];

			objReturn = SQLExec.ExecuteReturnValue("SELECT Tk_Km FROM LITAIKHOAN WHERE Tk = '" + strTk_No + "'");
			if (objReturn != null && objReturn != DBNull.Value && (bool)objReturn)
				bRequire = true;
			else
			{
				objReturn = SQLExec.ExecuteReturnValue("SELECT Tk_Km FROM LITAIKHOAN WHERE Tk = '" + strTk_Co + "'");
				if (objReturn != null && objReturn != DBNull.Value && (bool)objReturn)
					bRequire = true;
			}

            //frmKhoanMuc frmLookup = new frmKhoanMuc();
			DataRow drLookup = Lookup.ShowLookup("Ma_Km", strValue, bRequire, "", "");

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
				dgvCell.Value = drLookup["Ma_Km"].ToString();
				dgvCell.Tag = drLookup["Ten_Km"].ToString();
			}
			return true;
		}

		private bool dgvLookupMa_Sp(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;
			object objReturn = null;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			string strTk_No = (string)drCurrent["Tk_No"];
			string strTk_Co = (string)drCurrent["Tk_Co"];

			objReturn = SQLExec.ExecuteReturnValue("SELECT Tk_Sp FROM LITAIKHOAN WHERE Tk = '" + strTk_No + "'");
			if (objReturn != null && objReturn != DBNull.Value && (bool)objReturn)
				bRequire = true;
			else
			{
				objReturn = SQLExec.ExecuteReturnValue("SELECT Tk_Sp FROM LITAIKHOAN WHERE Tk = '" + strTk_Co + "'");
				if (objReturn != null && objReturn != DBNull.Value && (bool)objReturn)
					bRequire = true;
			}


            //frmSanPham frmLookup = new frmSanPham();
			DataRow drLookup = Lookup.ShowLookup("Ma_Sp", strValue, bRequire, "", "");

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
				dgvCell.Value = drLookup["Ma_Sp"].ToString();
				dgvCell.Tag = drLookup["Ten_Sp"].ToString();
			}
			return true;
		}

		private bool dgvLookupMa_Job(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = true;

            //frmTacVu frmLookup = new frmTacVu();
			DataRow drLookup = Lookup.ShowLookup("Ma_Job", strValue, bRequire, "", "");

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
				dgvCell.Value = drLookup["Ma_Job"].ToString();
				dgvCell.Tag = drLookup["Ten_Job"].ToString();
			}
			return true;
		}

		private bool dgvLookupMa_Vt(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

            //frmVatTu frmLookup = new frmVatTu();
			DataRow drLookup = Lookup.ShowLookup( "Ma_Vt" ,strValue, bRequire, "", "");

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

				string strMa_Vt_Old = string.Empty;

				if (drCurrent.HasVersion(DataRowVersion.Original))
					strMa_Vt_Old = drCurrent["Ma_Vt", DataRowVersion.Original] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt", DataRowVersion.Original];
				else
					strMa_Vt_Old = drCurrent["Ma_Vt"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt"];

				string strMa_Vt = (string)drLookup["Ma_Vt"];

				dgvEditCt1.CancelEdit();
				dgvCell.Value = drLookup["Ma_Vt"].ToString();
				dgvCell.Tag = drLookup["Ten_Vt"].ToString();

				//La vat tu dich vu                
				if ((string)drLookup["Loai_Vt"] == "0")
				{
					drCurrent["Dvt"] = drLookup["Dvt"];
				}
				else
				{
					drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];

					if (strMa_Vt != strMa_Vt_Old)
					{
						drCurrent["Dvt"] = drLookup["Dvt"];
						drCurrent["He_So9"] = 1;
						Voucher.Calc_So_Luong(drCurrent);

						if (strMa_Ct == "LR")// Phieu lap rap
							drCurrent["Tk_Co"] = drLookup["Tk_Vt"];
						else// Phieu thao rap
							drCurrent["Tk_No"] = drLookup["Tk_Vt"];

					}
					else
					{
						if (drCurrent["Dvt"] == DBNull.Value || (string)drCurrent["Dvt"] == string.Empty)
							drCurrent["Dvt"] = drLookup["Dvt"];
						if (strMa_Ct == "LR")//LR						
						{
							if (drCurrent["Tk_Co"] == DBNull.Value || (string)drCurrent["Tk_Co"] == string.Empty)
								drCurrent["Tk_Co"] = drLookup["Tk_Vt"];
						}
						else//TR
						{
							if (drCurrent["Tk_No"] == DBNull.Value || (string)drCurrent["Tk_No"] == string.Empty)
								drCurrent["Tk_No"] = drLookup["Tk_Vt"];
						}

					}
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

            //frmKho frmLookup = new frmKho();
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

		#endregion

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			this.dgvEditCt1.ClearSelection(); //Chi co tac dung sau khi show form

			if (this.enuNew_Edit == enuEdit.Edit)
			{
				if (!Common.CheckDataLocked((DateTime)drEdit["Ngay_Ct"]))
				{
					this.dteNgay_Ct.Enabled = false;
					this.btgAccept.btAccept.Enabled = false;
				}

				if (!Element.sysIs_Admin)
				{
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
}