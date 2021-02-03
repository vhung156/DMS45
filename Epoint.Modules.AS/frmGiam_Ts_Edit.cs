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
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;
using Epoint.Lists;

namespace Epoint.Modules.AS
{
	public partial class frmGiam_Ts_Edit : Epoint.Systems.Customizes.frmEdit
	{
		#region Contructor

		public frmGiam_Ts_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtMa_Giam_Ts.Enter += new EventHandler(txtMa_Giam_Enter);
			txtMa_Giam_Ts.Validating += new CancelEventHandler(txtMa_Giam_Validating);			
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;

			Common.ScaterMemvar(this, ref drEdit);
		
			this.Init();
			this.LoadDicName();
			this.BindingLanguage();

			this.ShowDialog();
		}

		#endregion

		#region Phuong thuc

		private void Init()
		{
			if (enuNew_Edit == enuEdit.Edit)
			{
			//	this.txtLoai_Ps.Enabled = false;
			}
			else
			{
			//	this.txtMa_Tte.Text = Epoint.Systems.Elements.Element.sysMa_Tte;
			//	this.numTy_Gia.Value = 1;
			}

		}

		private void LoadDicName()
		{
			//Ma_Giam
			if (txtMa_Giam_Ts.Text.Trim() != string.Empty)
			{
				lbtTen_Tg.Text = DataTool.SQLGetNameByCode("ASTG", "Ma_Tg", "Ten_Tg", txtMa_Giam_Ts.Text.Trim());
				dicName.SetValue(lbtTen_Tg.Name, lbtTen_Tg.Text);
			}
			else
				lbtTen_Tg.Text = string.Empty;

		}		

		private bool FormCheckValid()
		{			
			if (dteNgay_Giam_Ts.Text.Replace(" ", "") == "//")
			{
				Common.MsgOk(Languages.GetLanguage("Ngay_Giam_Ts") + " " +
							 Languages.GetLanguage("Cannot_Empty"));
				return false;
			}
			if (txtMa_Giam_Ts.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Giam_Ts") + " " +
							 Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			return true;
		}

		private bool Save()
		{
			if (!Common.CheckDataLocked(Library.StrToDate(dteNgay_Giam_Ts.Text)))
			{
				Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
				return false;
			}

			Common.GatherMemvar(this, ref drEdit);

			if (txtMa_Giam_Ts.Text != "")
			{
				drEdit["Is_Giam_Ts"] = true;
			}	

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			////Xac dinh Stt
			//if (this.enuNew_Edit == enuEdit.New)
			//    drEdit["Stt"] = Common.GetNewStt("06", true);

			//Kiem tra Valid CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "ASTGNG", ref drEdit))
				return false;

			return true;
		}

		#endregion

		#region Su kien

		#region button
		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				isAccept = true;
				this.Close();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}
		#endregion

		#region Ma_Giam
		void txtMa_Giam_Enter(object sender, EventArgs e)
		{
			lbtTen_Tg.Text = dicName.GetValue(lbtTen_Tg.Name);
		}

		void txtMa_Giam_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Giam_Ts.Text.Trim();
			bool bRequire = true;

			frmDmTg frmLookup = new frmDmTg();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "ASTG", "Ma_Tg", strValue, bRequire, " Ma_Tg LIKE 'G%'");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				lbtTen_Tg.Text = string.Empty;
				lbtTen_Tg.Text = string.Empty;
			}
			else
			{
				txtMa_Giam_Ts.Text = ((string)drLookup["Ma_Tg"]).Trim();
				lbtTen_Tg.Text = ((string)drLookup["Ten_Tg"]).Trim();
			}

			dicName.SetValue(lbtTen_Tg.Name, lbtTen_Tg.Text);
		}
		
		#endregion		

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			//if (this.enuNew_Edit == enuEdit.Edit)
			//{
			//    if (!Common.CheckDataLocked((DateTime)drEdit["Ngay_Giam"]))
			//    {
			//        this.dteNgay_Giam.Enabled = false;
			//        this.btgAccept.btAccept.Enabled = false;

			//        return;
			//    }
			//}
		}
	}
}