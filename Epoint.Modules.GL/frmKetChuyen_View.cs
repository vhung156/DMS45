using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Elements;


namespace Epoint.Modules.GL
{
	public partial class frmKetChuyen_View : Epoint.Systems.Customizes.frmView
	{

		#region Khai bao bien
		DataTable dtKetChuyen;
		DataRow drCurrent;
		BindingSource bdsKetChuyen = new BindingSource();
		dgvControl dgvKetChuyen = new dgvControl();

        bool iKetchuyen = true;
        
        DateTime dteNgay_Ct1 ;
        DateTime dteNgay_Ct2;
		#endregion

		#region Contructor

		public frmKetChuyen_View()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(frmDmKetChuyen_View_KeyDown);
            this.btKet_Chuyen.Click += new EventHandler(btKet_Chuyen_Click);
		}
		public override void Load()
		{
			this.Tag = this.Tag;
			Build();
			FillData();
			BindingLanguage();

			this.Show();
		}

		private void KetChuyen()
		{
            dgvKetChuyen.EndEdit();
            bdsKetChuyen.EndEdit();

            //if (Common.GetPartitionCurrent() != 0 && Common.GetPartitionCurrent() != Element.sysWorkingYear)
            //{
            //    Common.MsgCancel("Phải chuyển về phân vùng dữ liệu " + Element.sysWorkingYear.ToString() + "!");
            //    return;
            //}

            //frmKetChuyen_Run frm = new frmKetChuyen_Run();
            //frm.Tag = "Ket_Chuyen";

            //frm.numThang1.Value = Element.sysNgay_Ct1.Month;
            //frm.numThang2.Value = Element.sysNgay_Ct2.Month;

            //frm.Load();
            //if (!frm.isAccept)
            //    return;

            //DateTime dteNgay_Ct1 = Library.StrToDate("01/" + frm.numThang1.Value + "/" + Element.sysWorkingYear);
            //DateTime dteNgay_Ct2 = Library.StrToDate("01/" + frm.numThang2.Value + "/" + Element.sysWorkingYear);
            //dteNgay_Ct2 = dteNgay_Ct2.AddMonths(1).AddDays(-1);

            EpointProcessBox.setMaxValue(dgvKetChuyen.Rows.Count);

            if (!Common.CheckDataLocked(dteNgay_Ct1))
            {
                //Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
                EpointProcessBox.AddMessage(EpointMessage.GetMessage("DATALOCK"));
                return;
            }

			foreach (DataRow dr in dtKetChuyen.Rows)
			{
				if ((bool)dr["SELECT"] == false)
					continue;

				Hashtable ht = new Hashtable();
				ht["NGAY_CT1"] = dteNgay_Ct1;
				ht["NGAY_CT2"] = dteNgay_Ct2;
				ht["STT"] = dr["Stt"];
				ht["TK"] = dr["Tk"];
				ht["TK_DU_DEN"] = dr["Tk_Du_Den"];
				ht["DIEN_GIAI"] = dr["Dien_Giai"];
				ht["NO_CO_AUTO"] = dr["No_Co_Auto"];
				ht["PS_DU"] = dr["Ps_Du"];
				ht["MA_CT"] = "TD";
                ht["CREATE_LOG"] = "30" + dteNgay_Ct2.Year.ToString() + ":120000:" + Element.sysUser_Id;
				ht["MA_DVCS"] = Element.sysMa_DvCs;

                //Common.ShowStatus(Languages.GetLanguage("In_Process") + (string)dr["Dien_Giai"]);
                EpointProcessBox.AddMessage(Languages.GetLanguage("In_Process") + (string)dr["Dien_Giai"]);

				SQLExec.Execute("Sp_KetChuyen_Delete", ht, CommandType.StoredProcedure);
				SQLExec.Execute("Sp_KetChuyen", ht, CommandType.StoredProcedure);

				dr["Select"] = false;
			}

            //Common.EndShowStatus();
            //Common.MsgOk(Languages.GetLanguage("End_Process"));
            EpointProcessBox.AddMessage(Languages.GetLanguage("End_Process"));
		}

		private void KetChuyen_Delete()
		{
            dgvKetChuyen.EndEdit();
            bdsKetChuyen.EndEdit();

            //if (Common.GetPartitionCurrent() != 0 && Common.GetPartitionCurrent() != Element.sysWorkingYear)
            //{
            //    Common.MsgCancel("Phải chuyển về phân vùng dữ liệu " + Element.sysWorkingYear.ToString() + "!");
            //    return;
            //}

            //frmKetChuyen_Run frm = new frmKetChuyen_Run();
            //frm.Tag = "Ket_Chuyen_Delete";
            //frm.numThang1.Value = Element.sysNgay_Ct1.Month;
            //frm.numThang2.Value = Element.sysNgay_Ct2.Month;

            //frm.Load();
            //if (!frm.isAccept)
            //    return;

            //DateTime dteNgay_Ct1 = Library.StrToDate("01/" + frm.numThang1.Value + "/" + Element.sysWorkingYear);
            //DateTime dteNgay_Ct2 = Library.StrToDate("01/" + frm.numThang2.Value + "/" + Element.sysWorkingYear);
            //dteNgay_Ct2 = dteNgay_Ct2.AddMonths(1).AddDays(-1);

            EpointProcessBox.setMaxValue(dgvKetChuyen.Rows.Count);

			if (!Common.CheckDataLocked(dteNgay_Ct1))
			{
                //Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
                EpointProcessBox.AddMessage(EpointMessage.GetMessage("DATALOCK"));
                return;
			}

			foreach (DataRow dr in dtKetChuyen.Rows)
			{
				if ((bool)dr["SELECT"] == false)
					continue;

				Hashtable ht = new Hashtable();
				ht["NGAY_CT1"] = dteNgay_Ct1;
				ht["NGAY_CT2"] = dteNgay_Ct2;
				ht["STT"] = dr["Stt"];
				ht["MA_CT"] = "TD";
				ht["MA_DVCS"] = Element.sysMa_DvCs;

                //Common.ShowStatus(Languages.GetLanguage("In_Process") + (string)dr["Dien_Giai"]);
                EpointProcessBox.AddMessage(Languages.GetLanguage("In_Process") + (string)dr["Dien_Giai"]);

				SQLExec.Execute("Sp_KetChuyen_Delete", ht, CommandType.StoredProcedure);

				dr["Select"] = false;
			}

            //Common.EndShowStatus();
            //Common.MsgOk(Languages.GetLanguage("End_Process"));
            EpointProcessBox.AddMessage(Languages.GetLanguage("End_Process"));
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			dgvKetChuyen.Dock = DockStyle.Fill;
			dgvKetChuyen.strZone = "KETCHUYEN";
			dgvKetChuyen.BuildGridView(this.isLookup);

            this.splitContainer1.Panel1.Controls.Add(dgvKetChuyen);                
		}

		private void FillData()
		{
			dtKetChuyen = DataTool.SQLGetDataTable("GLKETCHUYEN", "*, CAST(0 AS BIT) AS [SELECT]", this.strLookupKeyFilter, "Stt");

			bdsKetChuyen.DataSource = dtKetChuyen;
			dgvKetChuyen.DataSource = bdsKetChuyen;
			bdsKetChuyen.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsKetChuyen;
			ExportControl = dgvKetChuyen;

			dgvKetChuyen.ReadOnly = false;
			foreach (DataGridViewColumn dgvc in dgvKetChuyen.Columns)
				dgvc.ReadOnly = true;

			dgvKetChuyen.Columns["SELECT"].ReadOnly = false;
		}

        public override void EpointRelease()
        {
            EpointProcessBox.SetStatus("Kết chuyển");
            if (iKetchuyen)
                KetChuyen();
            else
                KetChuyen_Delete();
        }
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsKetChuyen.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsKetChuyen.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsKetChuyen.Current).Row, ref drCurrent);
			else
				drCurrent = dtKetChuyen.NewRow();

			frmKetChuyen_Edit frmEdit = new frmKetChuyen_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsKetChuyen.Position >= 0)
						dtKetChuyen.ImportRow(drCurrent);
					else
						dtKetChuyen.Rows.Add(drCurrent);

					bdsKetChuyen.Position = bdsKetChuyen.Find("Stt", drCurrent["Stt"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsKetChuyen.Current).Row);

				dtKetChuyen.AcceptChanges();
			}
			else
				dtKetChuyen.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsKetChuyen.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsKetChuyen.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("GLKETCHUYEN", drCurrent))
			{
				bdsKetChuyen.RemoveAt(bdsKetChuyen.Position);
				dtKetChuyen.AcceptChanges();
			}
		}

		#endregion

		#region Su kien

        void btKet_Chuyen_Click(object sender, EventArgs e)
        {
            //KetChuyen
            frmKetChuyen_Run frm = new frmKetChuyen_Run();
            frm.Tag = "Ket_Chuyen";

            frm.numThang1.Value = Element.sysNgay_Ct1.Month;
            frm.numThang2.Value = Element.sysNgay_Ct2.Month;

            frm.Load();
            if (!frm.isAccept)
                return;

            dteNgay_Ct1 = Library.StrToDate("01/" + frm.numThang1.Value + "/" + Element.sysWorkingYear);
            dteNgay_Ct2 = Library.StrToDate("01/" + frm.numThang2.Value + "/" + Element.sysWorkingYear);
            dteNgay_Ct2 = dteNgay_Ct2.AddMonths(1).AddDays(-1);

            iKetchuyen = true;
            EpointProcessBox.Show(this);
        }

		void frmDmKetChuyen_View_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			{
				for (int i = 0; i < dtKetChuyen.Rows.Count; i++)
				{
					dtKetChuyen.Rows[i]["SELECT"] = true;
				}
			}

			else if (e.Control && e.KeyCode == Keys.U)
			{
				for (int i = 0; i < dtKetChuyen.Rows.Count; i++)
				{
					dtKetChuyen.Rows[i]["SELECT"] = false;
				}
			}

			else if (!e.Control && e.KeyCode == Keys.F10)
			{
                //KetChuyen
                frmKetChuyen_Run frm = new frmKetChuyen_Run();
                frm.Tag = "Ket_Chuyen";

                frm.numThang1.Value = Element.sysNgay_Ct1.Month;
                frm.numThang2.Value = Element.sysNgay_Ct2.Month;

                frm.Load();
                if (!frm.isAccept)
                    return;

                dteNgay_Ct1 = Library.StrToDate("01/" + frm.numThang1.Value + "/" + Element.sysWorkingYear);
                dteNgay_Ct2 = Library.StrToDate("01/" + frm.numThang2.Value + "/" + Element.sysWorkingYear);
                dteNgay_Ct2 = dteNgay_Ct2.AddMonths(1).AddDays(-1);

                iKetchuyen = true;
                EpointProcessBox.Show(this);
			}
			else if (e.Control && e.KeyCode == Keys.F10)
			{
                //KetChuyen_Delete();
                frmKetChuyen_Run frm = new frmKetChuyen_Run();
                frm.Tag = "Ket_Chuyen";

                frm.numThang1.Value = Element.sysNgay_Ct1.Month;
                frm.numThang2.Value = Element.sysNgay_Ct2.Month;

                frm.Load();
                if (!frm.isAccept)
                    return;

                dteNgay_Ct1 = Library.StrToDate("01/" + frm.numThang1.Value + "/" + Element.sysWorkingYear);
                dteNgay_Ct2 = Library.StrToDate("01/" + frm.numThang2.Value + "/" + Element.sysWorkingYear);
                dteNgay_Ct2 = dteNgay_Ct2.AddMonths(1).AddDays(-1);

                iKetchuyen = false;

                EpointProcessBox.Show(this);

			}
			else if (e.KeyCode == Keys.Space)
				((DataRowView)bdsKetChuyen.Current).Row["Select"] = !(bool)((DataRowView)bdsKetChuyen.Current).Row["Select"];

		}

		#endregion
	}
}