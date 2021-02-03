using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;

namespace Epoint.Modules.IN
{
	public partial class frmDuDauIN_Edit : Epoint.Modules.frmOpening_Edit
	{
		#region Methods

		public frmDuDauIN_Edit()
		{
			InitializeComponent();

			txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);
			txtMa_Kho.LostFocus += new EventHandler(txtMa_Kho_LostFocus);
			txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);

			numTon_Dau.Validating += new CancelEventHandler(numTon_Dau_Validating);

			numGia.Validating += new CancelEventHandler(numGia_Validating);
			numDu_Dau.Validating += new CancelEventHandler(numDu_Dau_Validating);

			numGia_Nt.Validating += new CancelEventHandler(numGia_Nt_Validating);
			numDu_Dau_Nt.Validating += new CancelEventHandler(numDu_Dau_Nt_Validating);
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;

			this.Tag = (char)enuNew_Edit + "," + this.Tag;
			Common.ScaterMemvar(this, ref drEdit);

			if (enuNew_Edit == enuEdit.New)
				dteNgay_Ct.Text = "01/" + Element.sysTh_Bd_Ht.ToString().Trim().PadLeft(2, '0') + "/" + Element.sysWorkingYear;

			BindingLanguage();
			LoadDicName();
			this.ShowDialog();
		}

		private void LoadDicName()
		{
			if (txtMa_Kho.Text.Trim() != string.Empty)
			{
				lbtTen_Kho.Text = DataTool.SQLGetNameByCode("LIKHO", "Ma_Kho", "Ten_Kho", txtMa_Kho.Text.Trim());
			}
			else
				lbtTen_Kho.Text = string.Empty;

			if (txtMa_Vt.Text.Trim() != string.Empty)
			{
				DataRow drDmVt = DataTool.SQLGetDataRowByID("LIVATTU", "Ma_Vt", txtMa_Vt.Text.Trim());

				if (drDmVt != null)
				{
					lbtTen_Vt.Text = (string)drDmVt["Ten_Vt"];
					lbtDvt.Text = "/" + (string)drDmVt["Dvt"];
				}
			}
			else
			{
				lbtTen_Vt.Text = string.Empty;
				lbtDvt.Text = string.Empty;
			}
		}

		public override bool FormCheckValid()
		{


			if (txtMa_Kho.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Kho") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (txtMa_Vt.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Vt") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (dteNgay_Ct.IsNull)
			{
				Common.MsgCancel(Languages.GetLanguage("Date") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}


            DataRow drVattu = DataTool.SQLGetDataRowByID("LIVATTU", "Ma_Vt", txtMa_Vt.Text);

            if ((bool)drVattu["LotSerial"])
            {
                if (txtMa_Lo.Text.Trim() == string.Empty)
                {
                    Common.MsgCancel(Languages.GetLanguage("Ma_Lo") + " " + Languages.GetLanguage("Cannot_Empty"));
                    return false;
                }

                if (dteHan_Sd.IsNull)
                {
                    Common.MsgCancel(Languages.GetLanguage("Han_Sd") + " " + Languages.GetLanguage("Cannot_Empty"));
                    return false;
                }

            }

			bool Is_Check = false;

			if (enuNew_Edit == enuEdit.Edit)
			{
				if (((DateTime)drEdit["Ngay_Ct"]).ToString("dd/MM/yyyy") == ((DateTime)drEdit["Ngay_Ct", DataRowVersion.Original]).ToString("dd/MM/yyyy") &&
					(string)drEdit["Ma_Kho"] == (string)drEdit["Ma_Kho", DataRowVersion.Original] &&
					(string)drEdit["Ma_Vt"] == (string)drEdit["Ma_Vt", DataRowVersion.Original])
					Is_Check = false;
				else
					Is_Check = true;
			}
			if (enuNew_Edit == enuEdit.New || Is_Check)
			{
				if (DataTool.SQLCheckExist("INDUDAU", new string[] { "Ngay_Ct", "Ma_Kho", "Ma_Vt", "Ma_DvCs" }, new object[] { Library.StrToDate(dteNgay_Ct.Text), txtMa_Kho.Text, txtMa_Vt.Text, Element.sysMa_DvCs }))
				{
					string strMsg = "Ngay_Ct = {" + dteNgay_Ct.Text + "}, Ma_Kho = {" + txtMa_Kho.Text + "}, Ma_Vt = {" + txtMa_Vt.Text + "}, Ma_DvCs = {" + Element.sysMa_DvCs + "}";
					strMsg += Element.sysLanguage == enuLanguageType.English ? " must be unique" : " phải duy nhất";

					Common.MsgCancel(strMsg);
					return false;
				}
			}



			return true;
		}

		public override bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			if (drEdit.Table.Columns.Contains("Ten_Vt"))
				drEdit["Ten_Vt"] = lbtTen_Vt.Text;

			//Kiem tra cac du lieu can thiet			
			drEdit["Ma_DvCs"] = Element.sysMa_DvCs;
			if (enuNew_Edit == enuEdit.New)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Xac dinh Stt
			if (this.enuNew_Edit == enuEdit.New)
			{
				drEdit["Stt"] = Common.GetNewStt("08", true);
				while (DataTool.SQLCheckExist("INDUDAU", "Stt", drEdit["Stt"]))
				{
					drEdit["Stt"] = Common.GetNewStt("08", true);
				}
			}
			//Luu xuong CSDL
			if (!Opening.UpdateDuDauIN(this))
				return false;

			return true;
		}

		#endregion

		#region Events

		private void Ma_Kho_Valid()
		{
			if (drEdit == null)
				return;

			string strMa_Kho = txtMa_Kho.Text;

			if (strMa_Kho == string.Empty)
				return;

			DataRow drDmKho = DataTool.SQLGetDataRowByID("LIKHO", "Ma_Kho", strMa_Kho);

			if (drDmKho == null)
				return;
		}

		void txtMa_Kho_LostFocus(object sender, EventArgs e)
		{
			Ma_Kho_Valid();			
		}

		void txtMa_Kho_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Kho.Text.Trim();
			bool bRequire = true;

            //Lists.frmKho frmLookup = new Epoint.Lists.frmKho();
			DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Kho.Text = string.Empty;
				lbtTen_Kho.Text = string.Empty;
			}
			else
			{
				txtMa_Kho.Text = drLookup["Ma_Kho"].ToString();
				lbtTen_Kho.Text = drLookup["Ten_Kho"].ToString();
			}

			dicName.SetValue(lbtTen_Kho.Name, lbtTen_Kho.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

		void txtMa_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt.Text.Trim();
			bool bRequire = true;

            //Lists.frmVatTu frmLookup = new Epoint.Lists.frmVatTu();
			DataRow drLookup = Lookup.ShowLookup( "Ma_Vt" ,strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt.Text = string.Empty;
				lbtTen_Vt.Text = string.Empty;
				lbtDvt.Text = string.Empty;
			}
			else
			{
				txtMa_Vt.Text = drLookup["Ma_Vt"].ToString();
				lbtTen_Vt.Text = drLookup["Ten_Vt"].ToString();
				lbtDvt.Text = "/" + drLookup["Dvt"].ToString();

                if ((bool)drLookup["LotSerial"]) 
                {
                    txtMa_Lo.Enabled = true;
                    dteHan_Sd.Enabled = true;

                    lblMa_Lo.Visible = true;
                    lblHan_Sd.Visible = true;

                    txtMa_Lo.Visible = true;
                    dteHan_Sd.Visible = true;


                }
                else
                {
                    txtMa_Lo.Enabled = false;
                    dteHan_Sd.Enabled = false;


                    lblMa_Lo.Visible = false;
                    lblHan_Sd.Visible = false;

                    txtMa_Lo.Visible = false;
                    dteHan_Sd.Visible = false;
                }

			}

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

		void numTon_Dau_Validating(object sender, CancelEventArgs e)
		{
			double dbTon_Dau = numTon_Dau.Value;
			double dbGia = numGia.Value;
			double dbDu_Dau = numDu_Dau.Value;

			double dbTronTien = Convert.ToDouble(Parameters.GetParaValue("Tron_Thanh_Tien"));

			if (Math.Abs(dbTon_Dau * dbGia - dbDu_Dau) >= dbTronTien)
			{
				dbDu_Dau = Math.Round(dbTon_Dau * dbGia, 0, MidpointRounding.AwayFromZero);
				numDu_Dau.Value = dbDu_Dau;
			}

			if (dbTon_Dau == 0)
				numDu_Dau.Value = 0;
		}

		void numGia_Validating(object sender, CancelEventArgs e)
		{
			double dbTon_Dau = numTon_Dau.Value;
			double dbGia = numGia.Value;
			double dbDu_Dau = numDu_Dau.Value;

			double dbTronTien = Convert.ToDouble(Parameters.GetParaValue("Tron_Thanh_Tien"));

			if (Math.Abs(dbTon_Dau * dbGia - dbDu_Dau) >= dbTronTien)
			{
				dbDu_Dau = Math.Round(dbTon_Dau * dbGia, 0, MidpointRounding.AwayFromZero);
				numDu_Dau.Value = dbDu_Dau;
			}

			if (dbTon_Dau == 0)
				numDu_Dau.Value = 0;
		}

		void numDu_Dau_Validating(object sender, CancelEventArgs e)
		{
			double dbTon_Dau = numTon_Dau.Value;
			double dbGia = numGia.Value;
			double dbDu_Dau = numDu_Dau.Value;
			double dbTronTien = Convert.ToDouble(Parameters.GetParaValue("Tron_Thanh_Tien"));

			if (dbGia == 0 && dbTon_Dau == 0)
				return;

			if (dbGia == 0 && dbTon_Dau != 0)
				numGia.Value = Math.Round(dbDu_Dau / dbTon_Dau, 2, MidpointRounding.AwayFromZero);

			else if (Math.Abs(dbTon_Dau * dbGia - dbDu_Dau) >= dbTronTien)
				numDu_Dau.Value = Math.Round(dbTon_Dau * dbGia, 0, MidpointRounding.AwayFromZero);

		}

		void numGia_Nt_Validating(object sender, CancelEventArgs e)
		{
			double dbTon_Dau = numTon_Dau.Value;
			double dbGia_Nt = numGia_Nt.Value;
			double dbDu_Dau_Nt = numDu_Dau_Nt.Value;

			double dbTronTien = Convert.ToDouble(Parameters.GetParaValue("Tron_Thanh_Tien"));

			if (Math.Abs(dbTon_Dau * dbGia_Nt - dbDu_Dau_Nt) >= dbTronTien)
			{
				dbDu_Dau_Nt = Math.Round(dbTon_Dau * dbGia_Nt, MidpointRounding.AwayFromZero);
				numDu_Dau_Nt.Value = dbDu_Dau_Nt;
			}

			if (dbTon_Dau == 0)
				numDu_Dau_Nt.Value = 0;
		}

		void numDu_Dau_Nt_Validating(object sender, CancelEventArgs e)
		{
			double dbTon_Dau = numTon_Dau.Value;
			double dbGia_Nt = numGia_Nt.Value;
			double dbDu_Dau_Nt = numDu_Dau_Nt.Value;
			double dbTronTien = Convert.ToDouble(Parameters.GetParaValue("Tron_Thanh_Tien"));

			if (dbGia_Nt == 0 && dbTon_Dau == 0)
				return;

			if (dbGia_Nt == 0 && dbTon_Dau != 0)
				numGia_Nt.Value = Math.Round(dbDu_Dau_Nt / dbTon_Dau, 2, MidpointRounding.AwayFromZero);

			else if (Math.Abs(dbTon_Dau * dbGia_Nt - dbDu_Dau_Nt) >= dbTronTien)
				numDu_Dau_Nt.Value = Math.Round(dbTon_Dau * dbGia_Nt, 0, MidpointRounding.AwayFromZero);

		}		


		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);


            if(txtMa_Vt.Text == string.Empty)
            {
                lblMa_Lo.Visible = false;
                lblHan_Sd.Visible = false;

                txtMa_Lo.Visible = false;
                dteHan_Sd.Visible = false;


            }
			//Kiểm tra khóa số dư
			string strSQLExec =
				"SELECT TOP 1 Locked_Sdv FROM SYSNAM " +
					" WHERE Nam = " + Element.sysWorkingYear + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";

			if (SQLExec.ExecuteReturnDt(strSQLExec).Rows.Count > 0 && (bool)SQLExec.ExecuteReturnValue(strSQLExec))
			{
				this.btgAccept.btAccept.Enabled = false;
			}
		}
	}
}
