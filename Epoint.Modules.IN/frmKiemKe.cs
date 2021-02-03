using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;
using Epoint.Systems.Elements;
//using DevExpress.XtraTreeList.Columns;


namespace Epoint.Modules.IN
{
	public partial class frmKiemKe : Epoint.Systems.Customizes.frmView
	{
		#region Fields

        public int iThang = 1;
        public string strMa_Kho = string.Empty;
        public string strMa_Vt = string.Empty;
        public bool chkCapNhatTonKho = false;
        public bool chkCapNhatKiemKe = false;

		private DataTable dtDmKho;
		private DataTable dtKiemKe;

		private DataRow drCurrent;
		private BindingSource bdsDmKho = new BindingSource();
		private BindingSource bdsKiemKe = new BindingSource();

        frmVoucher_Edit frmEditCt;
        frmKiemKe_Filter frm = new frmKiemKe_Filter();

		private dgvControl dgvDmKho = new dgvControl();
		private dgvControl dgvKiemKe = new dgvControl();

		

		#endregion

		#region Methods

		public frmKiemKe()
		{
			InitializeComponent();            
		}

        new public void Load()
		{
			this.Build();
			this.FillData();
			this.BindingLanguage();
			
            if (this.frmEditCt == null)
                this.Show();
            else
                this.ShowDialog();
		}
        public void Init()
        {
            frm = new frmKiemKe_Filter();            
            frm.Load();
            iThang = Convert.ToInt16(frm.numThang.Value);
            strMa_Kho = frm.txtMa_Kho.Text.Trim();
            strMa_Vt = frm.txtMa_Vt.Text.Trim();
            chkCapNhatTonKho = frm.chkCapNhatTonKho.Checked;
            chkCapNhatKiemKe = frm.chkCapNhatKiemKe.Checked;

            if (!frm.isAccept)
            {
                this.Close();
                this.isView = false;                
            }
            else
                Load();
        }
		private void Build()
		{
			this.dgvDmKho.strZone = "INDUDAU_VIEW";
			this.dgvDmKho.Dock = DockStyle.Fill;

            this.dgvKiemKe.strZone = "KIEMKE_VIEW";
            this.dgvKiemKe.Dock = DockStyle.Fill;

            this.Controls.Add(dgvDmKho);
            this.Controls.Add(dgvKiemKe);

            this.dgvDmKho.BuildGridView();
            this.dgvKiemKe.BuildGridView();

            this.dgvKiemKe.Visible = false;
		}

		private void FillData()
		{
            Hashtable ht = new Hashtable();
            ht["NGAY_CT"] = new DateTime(Element.sysWorkingYear, iThang, 1).AddMonths(1).AddDays(-1);
            ht["MA_KHO"] = strMa_Kho;
            ht["MA_VT"] = strMa_Vt;
            ht["CAPNHATTONKHO"] = chkCapNhatTonKho;
            ht["CAPNHATKIEMKE"] = chkCapNhatKiemKe;
            ht["MA_DVCS"] = Element.sysMa_DvCs;

            SQLExec.Execute("sp_UpdateKiemKe", ht, CommandType.StoredProcedure);
            
            //string strKey = "(MONTH(Ngay_Ct) = " + iThang + ")";
			string strKey = "(0 = 0)";

			if (strMa_Kho != string.Empty)
				strKey = strKey + " AND (Ma_Kho = '" + strMa_Kho + "')";

			dtDmKho = DataTool.SQLGetDataTable("LIKHO", "*", strKey, "");

			bdsDmKho.DataSource = dtDmKho;
			dgvDmKho.DataSource = bdsDmKho;
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsKiemKe.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsKiemKe.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsKiemKe.Current).Row, ref drCurrent);
			else
				drCurrent = dtKiemKe.NewRow();

			frmKiemKe_Edit frmEdit = new frmKiemKe_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			drCurrent["SL_Cl"] = Convert.ToDouble(drCurrent["So_Luong_Kk"]) - Convert.ToDouble(drCurrent["So_Luong"]);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsKiemKe.Position >= 0)
						dtKiemKe.ImportRow(drCurrent);
					else
						dtKiemKe.Rows.Add(drCurrent);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsKiemKe.Current).Row);

				dtKiemKe.AcceptChanges();
			}
			else
				dtKiemKe.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsKiemKe.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsKiemKe.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("INKIEMKE", drCurrent))
			{
				bdsKiemKe.RemoveAt(bdsKiemKe.Position);
				dtKiemKe.AcceptChanges();
			}
		}

		#endregion

		#region Events

		void EnterValid()
		{
			if (bdsDmKho.Count <= 0)
				return;

			string strQuery = "SELECT *, So_Luong_Kk - So_Luong AS SL_Cl FROM INKIEMKE WHERE Ma_Kho = '" + (string)((DataRowView)bdsDmKho.Current)["Ma_Kho"] + "' AND (MONTH(Ngay_Ct) = " + iThang + ") AND (YEAR(Ngay_Ct) = " + Element.sysWorkingYear + " )";

			dtKiemKe = SQLExec.ExecuteReturnDt(strQuery);

			bdsKiemKe.DataSource = dtKiemKe;
			dgvKiemKe.DataSource = bdsKiemKe;

			dgvKiemKe.Visible = true;
			dgvDmKho.Visible = false;

		}
		protected override void OnKeyDown(KeyEventArgs e)		
        {
            switch (e.KeyCode)
			{
				case Keys.Enter:
					EnterValid();
					return;

				case Keys.Escape:
                    if (dgvKiemKe.Visible)
                    {
                        dgvDmKho.Visible = true;
                        dgvKiemKe.Visible = false;
                    }
                    else
                    {
                        Common.CloseCurrentFormOnMain();                        
                    }
					return;

			}

			if (this.ActiveControl == dgvKiemKe)
			{
				switch (e.KeyCode)
				{
					case Keys.F2:
						this.Edit(enuEdit.New);
						return;

					case Keys.F3:
						this.Edit(enuEdit.Edit);
						return;

					case Keys.F8:
						this.Delete();
						return;
				}
			}
			base.OnKeyDown(e);
		}

		#endregion
	}
}

