using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;

namespace Epoint.Modules
{
    public partial class frmHanTtCust_View : Epoint.Systems.Customizes.frmView
	{
		DataTable dtHanTt;
		DataTable dtHanTt0;

		BindingSource bdsHanTt = new BindingSource();
		BindingSource bdsHanTt0 = new BindingSource();

		frmVoucher_Edit frmEditCt;
		frmHanTt_Filter frmFilter = new frmHanTt_Filter();
		string strStt = string.Empty;

		DateTime dtNgay_Ct = DateTime.MinValue;

		#region Contructor

        public frmHanTtCust_View()
		{
			InitializeComponent();

			this.bdsHanTt.PositionChanged += new EventHandler(bdsHanTt_PositionChanged);
			this.dgvHanTt.RowValidated += new DataGridViewCellEventHandler(dgvHanTt_RowValidated);
			this.dgvHanTt0.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvHanTt0_CellMouseClick);
			this.dgvHanTt0.CellBeginEdit += new DataGridViewCellCancelEventHandler(dgvHanTt0_CellBeginEdit);
			this.dgvHanTt0.CellEndEdit += new DataGridViewCellEventHandler(dgvHanTt0_CellEndEdit);

			this.dgvHanTt.GotFocus += new EventHandler(dgvHanTt_GotFocus);
			this.dgvHanTt0.GotFocus += new EventHandler(dgvHanTt0_GotFocus);

            this.btSave.Click += new EventHandler(btSave_Click);
		}

		new public void Load()
		{
			Build();

			if (this.frmEditCt != null) //Điền dữ liệu thanh toán từ EditCt
				FillHanTtFromEditCt();
			else
				FillHanTtFromCongNo();

			BindingLanguage();
			dgvHanTt.Focus();

			if (this.frmEditCt == null)
				this.Show();
			else
				this.ShowDialog();
		}

		public void Load(DateTime dtNgay_Ct, string strTk, string strMa_Dt, string strStt, string strMa_Ct)
		{
			frmFilter.dteNgay_Ct1.Text = Library.DateToStr(dtNgay_Ct);
			frmFilter.dteNgay_Ct2.Text = Library.DateToStr(dtNgay_Ct);
			this.dtNgay_Ct = dtNgay_Ct;
			frmFilter.txtTk.Text = strTk;
			frmFilter.txtMa_Dt.Text = strMa_Dt;
			frmFilter.txtMa_Ct.Text = strMa_Ct;

			this.strStt = strStt;

			this.Load();
		}

		public void Load(frmVoucher_Edit frmEditCt)
		{
			this.frmEditCt = frmEditCt;
			this.dtNgay_Ct = (DateTime)frmEditCt.dtEditPh.Rows[0]["Ngay_Ct"];

			this.strStt = (string)frmEditCt.dtEditPh.Rows[0]["Stt"];

			this.Load();
		}

		#endregion

		#region Method

        public void Init()
        {
            frmFilter = new frmHanTt_Filter();
            frmFilter.Load();

            if (!frmFilter.isAccept)
            {
                this.Close();
                this.isView = false;
            }
            else
                Load();
        }

		private void Build()
		{
			dgvHanTt.strZone = "HANTT";
			dgvHanTt.BuildGridView();

			dgvHanTt0.ReadOnly = false;
			dgvHanTt0.strZone = "HANTT0";
			dgvHanTt0.BuildGridView();

			////Thêm cột để đánh dấu có modify hay không
			//DataGridViewColumn dgvc1 = new DataGridViewColumn();
			//dgvc1.DataPropertyName = "Modify";
			//dgvc1.
			//dgvc1.Visible = false;
			//dgvHanTt0.Columns.Add(dgvc1);

			foreach (DataGridViewColumn dgvc in dgvHanTt0.Columns)
			{
				if (dgvc.Name == "TIEN_TT1" || dgvc.Name == "TIEN_TT_NT1")
					dgvc.ReadOnly = false;
				else
					dgvc.ReadOnly = true;
			}
		}

		private void FillHanTtFromCongNo()
		{
			Hashtable htParameter = new Hashtable();

			if (dtNgay_Ct != DateTime.MinValue)
			{
				htParameter.Add("NGAY_CT1", dtNgay_Ct);
				htParameter.Add("NGAY_CT2", dtNgay_Ct);
			}
			else
			{
				htParameter.Add("NGAY_CT1", Library.StrToDate(frmFilter.dteNgay_Ct1.Text));
				htParameter.Add("NGAY_CT2", Library.StrToDate(frmFilter.dteNgay_Ct2.Text));
			}
			htParameter.Add("TK", frmFilter.txtTk.Text);
			htParameter.Add("MA_DT", frmFilter.txtMa_Dt.Text);
			htParameter.Add("MA_CT", frmFilter.txtMa_Ct.Text);
			htParameter.Add("DU_CUOI_ONLY", frmFilter.chkDu_Cuoi_Only.Checked);
			htParameter.Add("STT", this.strStt);
			htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

			dtHanTt = SQLExec.ExecuteReturnDt("Sp_GetThanhToan", htParameter, CommandType.StoredProcedure);

			dgvHanTt.DataSource = bdsHanTt;
			bdsHanTt.DataSource = dtHanTt;

		}

		private void FillHanTtFromEditCt()
		{
			Voucher.Update_Detail(frmEditCt);

			string strSQLExec =
					"SELECT TOP 0 Stt, Ma_Ct, Ngay_Ct, So_Ct, Dien_Giai, Tk, Ma_Dt, Ma_Tte, Ty_Gia, Tien_Tt AS Tien, Tien_Tt_Nt AS Tien_Nt, CAST(0 AS BIT) AS Is_UngTruoc " +

				   " FROM vw_HanTt WHERE 0 = 1";

			dtHanTt = SQLExec.ExecuteReturnDt(strSQLExec);

			//Điền dữ liệu từ frmEditCt vào HanTt0
			string strArrTk_CongNo_List = "," + (string)Parameters.GetParaValue("TK_CONGNO_LIST");
			DataRow[] drArr = frmEditCt.dtEditCt.Select("Deleted = false");

			string strTk_No, strTk_Co, strMa_Dt, strMa_Dt_Co, strMa_Ct;
			double dbTien, dbTien_Nt;
			bool bIs_UngTruoc = false;

			//Lấy dữ liệu từ hạch toán gốc
			foreach (DataRow dr in drArr)
			{
                if (!Common.InlistLike(this.frmEditCt.strMa_Ct, "INT"))
                {
                    if (dr.Table.Columns.Contains("TIEN"))
                    {
                        strTk_No = ((string)dr["Tk_No"]).Trim();
                        strTk_Co = ((string)dr["Tk_Co"]).Trim();
                        strMa_Dt = ((string)dr["Ma_Dt"]).Trim();
                        strMa_Ct = ((string)dr["Ma_Ct"]).Trim();
                        dbTien = Convert.ToDouble(dr["Tien"]);
                        dbTien_Nt = Convert.ToDouble(dr["Tien_Nt"]);

                        if (dr.Table.Columns.Contains("Is_UngTruoc"))
                            bIs_UngTruoc = (bool)dr["Is_UngTruoc"];

                        if (dr.Table.Columns.Contains("Ma_Dt_Co") && (string)dr["Ma_Dt_Co"] != string.Empty)
                            strMa_Dt_Co = (string)dr["Ma_Dt_Co"];
                        else
                            strMa_Dt_Co = strMa_Dt;

                        if (strTk_No != string.Empty && strTk_Co != string.Empty)
                        {
                            //Kiểm tra Tk_No
                            if (strArrTk_CongNo_List.Contains("," + strTk_No.Substring(0, 3)))
                            {
                                if (frmEditCt.dtEditCt.Select("Tk_No LIKE '" + strTk_No + "%' AND Han_Tt = 0").Length > 0)
                                    this.SaveToHanTt(strTk_No, strMa_Dt, dbTien, dbTien_Nt, "N", bIs_UngTruoc);
                            }

                            //Kiểm tra Tk_Co
                            if (strArrTk_CongNo_List.Contains("," + strTk_Co.Substring(0, 3)))
                            {
                                if (strMa_Ct == "BT" && frmEditCt.dtEditCt.Columns.Contains("Han_Tt_Co"))
                                {
                                    if (frmEditCt.dtEditCt.Select("Tk_Co LIKE '" + strTk_Co + "%' AND Han_Tt_Co = 0").Length > 0)
                                        this.SaveToHanTt(strTk_Co, strMa_Dt_Co, dbTien, dbTien_Nt, "C", bIs_UngTruoc);
                                }
                                else
                                {
                                    if (frmEditCt.dtEditCt.Select("Tk_Co LIKE '" + strTk_Co + "%' AND Han_Tt = 0").Length > 0)
                                        this.SaveToHanTt(strTk_Co, strMa_Dt_Co, dbTien, dbTien_Nt, "C", bIs_UngTruoc);
                                }
                            }
                        }
                    }
                }
                else // đối với chứng từ trả hàng từ khách hàng
                {
                    if (dr.Table.Columns.Contains("TIEN2"))
                    {
                        strTk_No = ((string)dr["Tk_No2"]).Trim();
                        strTk_Co = ((string)dr["Tk_Co2"]).Trim();
                        strMa_Dt = ((string)dr["Ma_Dt"]).Trim();
                        strMa_Ct = ((string)dr["Ma_Ct"]).Trim();
                        dbTien = Convert.ToDouble(dr["Tien2"]);
                        dbTien_Nt = Convert.ToDouble(dr["Tien_Nt2"]);

                        if (dr.Table.Columns.Contains("Is_UngTruoc"))
                            bIs_UngTruoc = (bool)dr["Is_UngTruoc"];

                        if (dr.Table.Columns.Contains("Ma_Dt_Co") && (string)dr["Ma_Dt_Co"] != string.Empty)
                            strMa_Dt_Co = (string)dr["Ma_Dt_Co"];
                        else
                            strMa_Dt_Co = strMa_Dt;

                        if (strTk_No != string.Empty && strTk_Co != string.Empty)
                        {
                            //Kiểm tra Tk_No
                            if (strArrTk_CongNo_List.Contains("," + strTk_No.Substring(0, 3)))
                            {
                                if (frmEditCt.dtEditCt.Select("Tk_No2 LIKE '" + strTk_No + "%' AND Han_Tt = 0").Length > 0)
                                    this.SaveToHanTt(strTk_No, strMa_Dt, dbTien, dbTien_Nt, "N", bIs_UngTruoc);
                            }

                            //Kiểm tra Tk_Co
                            if (strArrTk_CongNo_List.Contains("," + strTk_Co.Substring(0, 3)))
                            {
                                if (strMa_Ct == "BT" && frmEditCt.dtEditCt.Columns.Contains("Han_Tt_Co"))
                                {
                                    if (frmEditCt.dtEditCt.Select("Tk_Co2 LIKE '" + strTk_Co + "%' AND Han_Tt_Co = 0").Length > 0)
                                        this.SaveToHanTt(strTk_Co, strMa_Dt_Co, dbTien, dbTien_Nt, "C", bIs_UngTruoc);
                                }
                                else
                                {
                                    if (frmEditCt.dtEditCt.Select("Tk_Co2 LIKE '" + strTk_Co + "%' AND Han_Tt = 0").Length > 0)
                                        this.SaveToHanTt(strTk_Co, strMa_Dt_Co, dbTien, dbTien_Nt, "C", bIs_UngTruoc);
                                }
                            }
                        }
                    }
                }

				if (dr.Table.Columns.Contains("TIEN3"))
				{
					strTk_No = ((string)dr["Tk_No3"]).Trim();
					strTk_Co = ((string)dr["Tk_Co3"]).Trim();
					strMa_Dt = ((string)dr["Ma_Dt"]).Trim();
					dbTien = Convert.ToDouble(dr["Tien3"]);
					dbTien_Nt = Convert.ToDouble(dr["Tien_Nt3"]);

					if (dr.Table.Columns.Contains("Ma_Dt_Co") && (string)dr["Ma_Dt_Co"] != string.Empty)
						strMa_Dt_Co = (string)dr["Ma_Dt_Co"];
					else
						strMa_Dt_Co = strMa_Dt;

					if (strTk_No != string.Empty && strTk_Co != string.Empty)
					{
						//Kiểm tra Tk_No
						if (strArrTk_CongNo_List.Contains("," + strTk_No.Substring(0, 3)))
						{
							if (frmEditCt.dtEditCt.Select("Tk_No LIKE '" + strTk_No + "%' AND Han_Tt = 0").Length > 0)
								this.SaveToHanTt(strTk_No, strMa_Dt, dbTien, dbTien_Nt, "N", bIs_UngTruoc);
						}

						//Kiểm tra Tk_Co
						if (strArrTk_CongNo_List.Contains("," + strTk_Co.Substring(0, 3)))
						{
							if (frmEditCt.dtEditCt.Select("Tk_Co LIKE '" + strTk_Co + "%' AND Han_Tt = 0").Length > 0)
								this.SaveToHanTt(strTk_Co, strMa_Dt_Co, dbTien, dbTien_Nt, "C", bIs_UngTruoc);
						}
					}
				}
			}

			//Cập nhật lại Tỷ giá
			foreach (DataRow dr in dtHanTt.Rows)
			{
				dbTien = Convert.ToDouble(dr["Tien"]);
				dbTien_Nt = Convert.ToDouble(dr["Tien_Nt"]);
				if (dbTien != dbTien_Nt && dbTien_Nt != 0)
					dr["Ty_Gia"] = Math.Round(dbTien / dbTien_Nt, 0, MidpointRounding.AwayFromZero);
			}

			dgvHanTt.DataSource = bdsHanTt;
			bdsHanTt.DataSource = dtHanTt;
		}

		private void SaveToHanTt(string strTk, string strMa_Dt, double dbTien_Tt, double dbTien_Tt_Nt, string strNo_Co, bool bIs_UngTruoc)
		{
			DataRow[] drArrHanTt = dtHanTt.Select("Tk = '" + strTk + "' AND Ma_Dt = '" + strMa_Dt + "'");
			DataRow drAdd;

			if (drArrHanTt.Length == 0)
			{
				drAdd = dtHanTt.NewRow();
				Common.SetDefaultDataRow(ref drAdd);

				dtHanTt.Rows.Add(drAdd);
			}
			else
				drAdd = drArrHanTt[0];

			Common.CopyDataRow(frmEditCt.dtEditCt.Rows[0], drAdd, "Stt,Ma_Ct,Ngay_Ct,So_Ct,Dien_Giai,Ma_Tte,Ty_Gia");

			string strTk_No_Giam_CongNo = "," + (string)Parameters.GetParaValue("TK_NO_GIAM_CONGNO");
			if (strNo_Co == "N" && !strTk_No_Giam_CongNo.Contains("," + strTk.Substring(0, 3)))
			{
				dbTien_Tt = -dbTien_Tt;
				dbTien_Tt_Nt = -dbTien_Tt_Nt;
			}
			else if (strNo_Co == "C" && strTk_No_Giam_CongNo.Contains("," + strTk.Substring(0, 3)))
			{
				dbTien_Tt = -dbTien_Tt;
				dbTien_Tt_Nt = -dbTien_Tt_Nt;
			}

			drAdd["Tk"] = strTk;
			drAdd["Ma_Dt"] = strMa_Dt;
			drAdd["Tien"] = Convert.ToDouble(drAdd["Tien"]) + dbTien_Tt;
			drAdd["Tien_Nt"] = Convert.ToDouble(drAdd["Tien_Nt"]) + dbTien_Tt_Nt;
			drAdd["Is_UngTruoc"] = bIs_UngTruoc;

			dtHanTt.AcceptChanges();
		}

		private void Auto_Ticked()
		{
			DataRow drHanTt = ((DataRowView)bdsHanTt.Current).Row;

			DataRow drHanTt0 = ((DataRowView)bdsHanTt0.Current).Row;
			DataGridViewCell dgvCell = dgvHanTt0.CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (dgvHanTt0.ReadOnly)
				return;

			if (Common.Inlist(strColumnName, "THANH_TOAN"))
			{
				//Không cho người này được sửa thanh toán của người khác
				if (!Element.sysIs_Admin)
				{
					string strUser = (string)drHanTt0["LastModify_Log"];
					if (strUser.Length > 0)
						strUser = strUser.Substring(14);

					if (strUser != string.Empty && strUser != Element.sysUser_Id)
					{
						Common.MsgCancel("Không được sửa dữ liệu do " + strUser + " đã thanh toán!");
						return;
					}
				}

                //double dbTien = Convert.ToDouble(drHanTt["Tien"]); // Tiền trên phiếu trả hàng dùng để cấn trừ công nợ.

				this.btSave.Enabled = true;
				bool bThanh_Toan = !(bool)dgvCell.EditedFormattedValue;

				drHanTt0["Thanh_Toan"] = bThanh_Toan;
				drHanTt0["Modify"] = true;

				if (bThanh_Toan) //Thanh toan
				{
					string strTk = (string)drHanTt["Tk"];

					double dbTien_No1 = Convert.ToDouble(drHanTt0["Tien_No1"]);
					double dbTien_No_Nt1 = Convert.ToDouble(drHanTt0["Tien_No_Nt1"]);
					double dbTy_Gia = Convert.ToDouble(drHanTt0["Ty_Gia"]);

					double dbTien_Tt_PT = Convert.ToDouble(drHanTt["Tien"]);
					double dbTien_Tt_PT_Nt = Convert.ToDouble(drHanTt["Tien_Nt"]);
					//double dbTy_Gia_PT = Convert.ToDouble(drHanTt["Ty_Gia"]);
					double dbTy_Gia_PT = Math.Round(dbTien_Tt_PT / dbTien_Tt_PT_Nt, 2, MidpointRounding.AwayFromZero);

					//Tổng số tiền đã thanh toán
					double dbTTien_Tt1 = Common.SumDCValue(dtHanTt0, "Tien_Tt1", "Stt_Tt = '" + (string)drHanTt["Stt"] + "'");
					double dbTTien_Tt_Nt1 = Common.SumDCValue(dtHanTt0, "Tien_Tt_Nt1", "Stt_Tt = '" + (string)drHanTt["Stt"] + "'");

					double dbTTien_CLTG = Common.SumDCValue(dtHanTt0, "Tien_ClTg", "Stt_Tt = '" + (string)drHanTt["Stt"] + "'");

					double dbTTien_Tt_Allow;
					double dbTTien_Tt_Nt_Allow;
					double dbTien_Tt1;
					double dbTien_Tt_Nt1;

					//Tổng số tiền cho phép thanh toán
					if (dbTien_Tt_PT >= 0)
					{
						dbTTien_Tt_Allow = Math.Max(0, dbTien_Tt_PT - dbTTien_Tt1);
						dbTTien_Tt_Nt_Allow = Math.Max(0, dbTien_Tt_PT_Nt - dbTTien_Tt_Nt1);

						dbTien_Tt1 = Math.Min(dbTien_No1, dbTTien_Tt_Allow);
						dbTien_Tt_Nt1 = Math.Min(dbTien_No_Nt1, dbTTien_Tt_Nt_Allow);
					}
					else
					{
						dbTTien_Tt_Allow = Math.Min(0, dbTien_Tt_PT - dbTTien_Tt1);
						dbTTien_Tt_Nt_Allow = Math.Min(0, dbTien_Tt_PT_Nt - dbTTien_Tt_Nt1);

						dbTien_Tt1 = Math.Max(dbTien_No1, dbTTien_Tt_Allow);
						dbTien_Tt_Nt1 = Math.Max(dbTien_No_Nt1, dbTTien_Tt_Nt_Allow);
					}

					//Nếu thanh toán bằng Tiền_Nt => phải quy Tiền_Nt về Tien_VND theo tỷ giá trên phiếu thanh toán
					if (dbTien_Tt_Nt1 > 0)
					{
						if (dbTy_Gia_PT == dbTy_Gia) //Nếu Tỷ giá bằng nhau
							dbTien_Tt1 = dbTien_Tt1;
						else
							if (dbTien_Tt_Nt1 == dbTTien_Tt_Nt_Allow) //Nếu trả hết tiền trên PT => trả hết tiền VND do lấy tỷ giá trên PT
								dbTien_Tt1 = dbTTien_Tt_Allow;
							else
								dbTien_Tt1 = Math.Round(dbTien_Tt_Nt1 * dbTy_Gia_PT, 0, MidpointRounding.AwayFromZero);

						//Kiểm tra lại tiền thanh toán cho phép: không được thanh toán vượt quá Tien_VND trên Phieu thu
						if (dbTien_Tt_PT >= 0)
							dbTien_Tt1 = Math.Min(dbTien_Tt1, dbTTien_Tt_Allow);
						else
							dbTien_Tt1 = Math.Max(dbTien_Tt1, dbTTien_Tt_Allow);
					}

					drHanTt0["Tien_Tt1"] = dbTien_Tt1;
					drHanTt0["Tien_Tt_Nt1"] = dbTien_Tt_Nt1;
                    
                    //Tiền nợ còn lại
                    drHanTt0["Tien_Cl1"] = dbTien_No1 - dbTien_Tt1;
                    if (dbTien_Tt_Nt1 > 0)//Nếu thanh toán bằng Tien_Nt thì mới có Tien_Cl_Nt
                        drHanTt0["Tien_Cl_Nt1"] = dbTien_No_Nt1 - dbTien_Tt_Nt1;
                    else
                        drHanTt0["Tien_Cl_Nt1"] = 0;

					drHanTt0["Stt_Tt"] = (string)drHanTt["Stt"];
					drHanTt0["LastModify_Log"] = Common.GetCurrent_Log();
				}
				else //Khong thanh toan
				{
					drHanTt0["Tien_Tt1"] = 0;
					drHanTt0["Tien_Tt_Nt1"] = 0;
                    
                    //Tiền nợ còn lại
                    drHanTt0["Tien_Cl1"] = Convert.ToDouble(drHanTt0["Tien_No1"]) - Convert.ToDouble(drHanTt0["Tien_Tt1"]);
                    if (Convert.ToDouble(drHanTt0["Tien_Tt_Nt1"]) > 0)//Nếu thanh toán bằng Tien_Nt thì mới có Tien_Cl_Nt
                        drHanTt0["Tien_Cl_Nt1"] = Convert.ToDouble(drHanTt0["dbTien_No_Nt1"]) - Convert.ToDouble(drHanTt0["Tien_Tt_Nt1"]);
                    else
                        drHanTt0["Tien_Cl_Nt1"] = 0;

					drHanTt0["Stt_Tt"] = string.Empty;
					drHanTt0["LastModify_Log"] = string.Empty;
				}

				this.Calc_CLTG();

				drHanTt0.AcceptChanges();
				dgvHanTt0.EndEdit();

				this.Tinh_Tong();
			}
		}

		private void Calc_CLTG()
		{
			DataRow drHanTt = ((DataRowView)bdsHanTt.Current).Row;            

            if (Convert.ToBoolean(drHanTt["Is_UngTruoc"]))
                return;

			DataRow drHanTt0 = ((DataRowView)bdsHanTt0.Current).Row;
			DataGridViewCell dgvCell = dgvHanTt0.CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (btSave.Enabled)
			{
				string strTk = (string)drHanTt0["Tk"];

				double dbTien_No1 = Convert.ToDouble(drHanTt0["Tien_No1"]);
				double dbTien_No_Nt1 = Convert.ToDouble(drHanTt0["Tien_No_Nt1"]);

				double dbTien_Tt1 = Convert.ToDouble(drHanTt0["Tien_Tt1"]);
				double dbTien_Tt_Nt1 = Convert.ToDouble(drHanTt0["Tien_Tt_Nt1"]);

				double dbTy_Gia_Tt = 0;
				double dbTy_Gia_CL = 0;
				double dbTien_ClTg = 0;

				if (dbTien_Tt_Nt1 == 0 || dbTien_No_Nt1 == 0 || dbTien_Tt1 == dbTien_No1)
				{
					drHanTt0["Tien_CLTG"] = 0;
					return;
				}

				if (dbTien_Tt_Nt1 == dbTien_No_Nt1) //Thanh toán hết tiền Nt
				{
					if (((string)drHanTt0["Tk"]).StartsWith("1") || ((string)drHanTt0["Tk"]).StartsWith("2"))
						dbTien_ClTg = dbTien_Tt1 - dbTien_No1;
					else
						dbTien_ClTg = dbTien_No1 - dbTien_Tt1;
				}
				else
				{
					dbTy_Gia_Tt = Math.Round(dbTien_Tt1 / dbTien_Tt_Nt1, 2, MidpointRounding.AwayFromZero); //Convert.ToDouble(drHanTt["Ty_Gia"])

					if (((string)drHanTt0["Tk"]).StartsWith("1") || ((string)drHanTt0["Tk"]).StartsWith("2"))
						dbTy_Gia_CL = dbTy_Gia_Tt - Convert.ToDouble(drHanTt0["Ty_Gia"]);
					else
						dbTy_Gia_CL = -dbTy_Gia_Tt + Convert.ToDouble(drHanTt0["Ty_Gia"]);

					dbTien_ClTg = Math.Round(dbTy_Gia_CL * dbTien_Tt_Nt1, MidpointRounding.AwayFromZero);
				}

				drHanTt0["Tien_CLTG"] = dbTien_ClTg;

			}
		}

		private void Save_HanTt0()
		{
			if (this.frmEditCt != null) //Lưu xuống DataTable
			{
				if (frmEditCt.dtHanTt0 == null)
					frmEditCt.dtHanTt0 = dtHanTt0.Clone();

				DataRow drHanTt = ((DataRowView)bdsHanTt.Current).Row;
				bool bReFillHanTt0 = true;

				if (!(frmEditCt.dtHanTt0.Select("Tk = '" + (string)drHanTt["Tk"] + "' AND Ma_Dt = '" + (string)drHanTt["Ma_Dt"] + "'").Length > 0))
				{
					for (int i = 0; i <= dtHanTt0.Rows.Count - 1; i++)
					{
						if ((bool)dtHanTt0.Rows[i]["Modify"])
							frmEditCt.dtHanTt0.ImportRow(dtHanTt0.Rows[i]);
					}
				}

				frmEditCt.dtHanTt0.AcceptChanges();
				this.btSave.Enabled = false;
			}
			else //Lưu xuống SQL Server
			{

				DataRow drHanTt = ((DataRowView)bdsHanTt.Current).Row;
				DataRow[] drArrHanTt0 = dtHanTt0.Select(bdsHanTt0.Filter);

				double dbTien_PT = Convert.ToDouble(drHanTt["Tien"]);
				double dbTien_PT_Nt = Convert.ToDouble(drHanTt["Tien_Nt"]);

				if (dbTien_PT != numTTien_Tt.Value)
				{
					if (!Common.MsgYes_No("Giá trị trên chứng từ thanh toán khác với tổng giá trị thanh toán. Bạn có muốn tiếp tục hay không?"))
						return;
				}
				else
				{
					if (dbTien_PT_Nt != numTTien_Tt_Nt.Value)
						if (!Common.MsgYes_No("Giá trị Nt trên chứng từ thanh toán khác với tổng giá trị Nt thanh toán. Bạn có muốn tiếp tục hay không?"))
							return;
				}

				Hashtable htParameter = new Hashtable();
				htParameter.Add("STT", drHanTt["Stt"]);
				htParameter.Add("MA_CT", drHanTt["Ma_Ct"]);
				htParameter.Add("NGAY_CT", drHanTt["Ngay_Ct"]);
				htParameter.Add("SO_CT", drHanTt["So_Ct"]);
				htParameter.Add("DIEN_GIAI", drHanTt["Dien_Giai"]);
				htParameter.Add("MA_TTE", drHanTt["Ma_Tte"]);
				htParameter.Add("TY_GIA", drHanTt["Ty_Gia"]);
				htParameter.Add("TK", drHanTt["Tk"]);
				htParameter.Add("MA_DT", drHanTt["Ma_Dt"]);
				htParameter.Add("TIEN_TT", 0);
				htParameter.Add("TIEN_TT_NT", 0);
				htParameter.Add("TIEN_CLTG", 0);
				htParameter.Add("STT_HD", string.Empty);
				htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

				foreach (DataRow dr in drArrHanTt0)
				{
					if (!(bool)dr["Modify"])
						continue;

					htParameter["TIEN_TT"] = Math.Round(Convert.ToDouble(dr["Tien_Tt1"]), 0);
					htParameter["TIEN_TT_NT"] = Math.Round(Convert.ToDouble(dr["Tien_Tt_Nt1"]), 2, MidpointRounding.AwayFromZero);
					htParameter["TIEN_CLTG"] = dr["Tien_ClTg"];
					htParameter["STT_HD"] = dr["Stt"];
					htParameter["LASTMODIFY_LOG"] = dr["LastModify_Log"];

					SQLExec.Execute("sp_UpdateHanTt0", htParameter, CommandType.StoredProcedure);
				}

				this.btSave.Enabled = false;
			}
		}

		private void Tinh_Tong()
		{
			this.numTTien_Tt.Value = Common.SumDCValue(dtHanTt0, "Tien_Tt1", "");
			this.numTTien_Tt_Nt.Value = Common.SumDCValue(dtHanTt0, "Tien_Tt_Nt1", "");
			this.numTTien_CLTG.Value = Common.SumDCValue(dtHanTt0, "Tien_CLTG", "");
		}

		#endregion

		#region Event

		void dgvHanTt0_GotFocus(object sender, EventArgs e)
		{
			this.ExportControl = dgvHanTt0;
			this.bdsSearch = bdsHanTt0;
		}

		void dgvHanTt_GotFocus(object sender, EventArgs e)
		{
			this.ExportControl = dgvHanTt;
			this.bdsSearch = bdsHanTt;
		}

		void bdsHanTt_PositionChanged(object sender, EventArgs e)
		{
			DataRow drHanTt = ((DataRowView)bdsHanTt.Current).Row;
			bool bReFillHanTt0 = true;

			if (frmEditCt != null && frmEditCt.dtHanTt0 != null)
			{
				if (frmEditCt.dtHanTt0.Select("Tk = '" + (string)drHanTt["Tk"] + "' AND Ma_Dt = '" + (string)drHanTt["Ma_Dt"] + "'").Length > 0)
				{
					bReFillHanTt0 = false;

					dtHanTt0 = frmEditCt.dtHanTt0;

					bdsHanTt0.DataSource = dtHanTt0;
					dgvHanTt0.DataSource = bdsHanTt0;
				}
			}

			if (bReFillHanTt0)
			{
				Hashtable htParameter = new Hashtable();

				if (dtNgay_Ct != DateTime.MinValue)
				{
					htParameter.Add("NGAY_CT1", dtNgay_Ct);
					htParameter.Add("NGAY_CT2", dtNgay_Ct);
				}
				else
				{
					htParameter.Add("NGAY_CT1", Library.StrToDate(frmFilter.dteNgay_Ct1.Text));
					htParameter.Add("NGAY_CT2", Library.StrToDate(frmFilter.dteNgay_Ct2.Text));
				}

				htParameter.Add("TK", (string)drHanTt["Tk"]);
				htParameter.Add("MA_DT", (string)drHanTt["Ma_Dt"]);
				htParameter.Add("STT_PT", (string)drHanTt["Stt"]);
				htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

                dtHanTt0 = SQLExec.ExecuteReturnDt("sp_AR_GetHanTt", htParameter, CommandType.StoredProcedure);

				//Kiểm tra có Modify
				if (!dtHanTt0.Columns.Contains("Modify"))
				{
					dtHanTt0.Columns.Add(new DataColumn("Modify", typeof(bool)));
					dtHanTt0.Columns["Modify"].DefaultValue = false;
				}

				bdsHanTt0.DataSource = dtHanTt0;
				dgvHanTt0.DataSource = bdsHanTt0;
			}

			this.Tinh_Tong();

			if (!Common.CheckDataLocked((DateTime)drHanTt["Ngay_Ct"]) && !(bool)drHanTt["Is_UngTruoc"])
			{
				Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
				this.dgvHanTt0.ReadOnly = true;
				return;
			}
			else
			{
				this.dgvHanTt0.ReadOnly = false;
				this.dgvHanTt0.Enabled = true;
			}
		}

		void dgvHanTt_RowValidated(object sender, DataGridViewCellEventArgs e)
		{
			if (this.btSave.Enabled == true)
			{
				if (Common.MsgYes_No(Languages.GetLanguage("Do_You_Want_To_Save")))
					this.Save_HanTt0();
				else
					this.btSave.Enabled = false;
			}
		}

		void dgvHanTt0_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			this.Auto_Ticked();
		}

		void dgvHanTt0_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			DataGridViewCell dgvCell = dgvHanTt0.CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (Common.Inlist(strColumnName, "TIEN_TT1,TIEN_TT_NT1"))
			{
				DataRow drHanTt0 = ((DataRowView)bdsHanTt0.Current).Row;

				//Không cho người này được sửa thanh toán của người khác
				if (!Element.sysIs_Admin)
				{
					string strUser = (string)drHanTt0["LastModify_Log"];
					if (strUser.Length > 0)
						strUser = strUser.Substring(14);

					if (strUser != string.Empty && strUser != Element.sysUser_Id)
					{
						Common.MsgCancel("Không được sửa dữ liệu do " + strUser + " đã thanh toán!");
						this.btSave.Enabled = false;
						e.Cancel = true;

						return;
					}
				}

				this.btSave.Enabled = true;
			}
		}

		void dgvHanTt0_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewCell dgvCell = dgvHanTt0.CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (Common.Inlist(strColumnName, "TIEN_TT1,TIEN_TT_NT1"))
			{
				DataRow drHanTt0 = ((DataRowView)bdsHanTt0.Current).Row;
				drHanTt0["Modify"] = true;

				this.Calc_CLTG();

				this.Tinh_Tong();
			}
		}

		void btSave_Click(object sender, EventArgs e)
		{
			this.Save_HanTt0();
            this.Close();
		}
		
		#endregion
	}
}
