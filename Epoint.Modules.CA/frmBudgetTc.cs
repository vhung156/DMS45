using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Lists;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;

namespace Epoint.Modules.CA
{
	public partial class frmBudgetTc : Epoint.Systems.Customizes.frmView
	{
		DataTable dtBudgetTc;
		DataTable dtBudgetTcDetail;

		BindingSource bdsBudgetTc = new BindingSource();
		BindingSource bdsBudgetDetail = new BindingSource();

		DataRow drCurrent;

		public frmBudgetTc()
		{
			InitializeComponent();

			btNew.Click += new EventHandler(btNew_Click);
			btEdit.Click += new EventHandler(btEdit_Click);
			btDelete.Click += new EventHandler(btDelete_Click);			
		}

		public void Load()
		{
			this.Build();
			this.FillData();
			this.BindingLanguage();
            this.EnterValid();
			this.Show();
		}

		void Build()
		{
			dgvBudgetTc.strZone = "CABUDGETTC";
			dgvBudgetTc.BuildGridView();

			dgvBudgetDetail.strZone = "CABUDGETTCCT";
			dgvBudgetDetail.BuildGridView();


            bdsBudgetTc.PositionChanged += new EventHandler( bdsBudgetTc_PositionChanged);
            //splitContainer1.Panel1Collapsed = true;
            //splitContainer1.Panel2Collapsed = false;
		}

        void bdsBudgetTc_PositionChanged(object sender, EventArgs e)
        {
            EnterValid();
        }

		void FillData()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("THANG", 0);
			htPara.Add("NAM", Element.sysWorkingYear);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			dtBudgetTc = SQLExec.ExecuteReturnDt("sp_GetBudgetTc", htPara, CommandType.StoredProcedure);

			bdsBudgetTc.DataSource = dtBudgetTc;
			dgvBudgetTc.DataSource = bdsBudgetTc;

			bdsSearch = bdsBudgetTc;
			ExportControl = dgvBudgetTc;



            dtBudgetTcDetail = SQLExec.ExecuteReturnDt("SELECT * FROM CAkehoach");
            bdsBudgetDetail.DataSource = dtBudgetTcDetail;
            dgvBudgetDetail.DataSource = bdsBudgetDetail;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
            if (splitContainer1.Panel2Collapsed)
                return;

			if (bdsBudgetDetail.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsBudgetDetail.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsBudgetDetail.Current).Row, ref drCurrent);
			else
				drCurrent = dtBudgetTcDetail.NewRow();

			DataRow drParent = ((DataRowView)bdsBudgetTc.Current).Row;
			if (enuNew_Edit == enuEdit.New)
			{
				if (drCurrent["Ngay_Ct"] == DBNull.Value)
					drCurrent["Ngay_Ct"] = Common.GetDate(Element.sysWorkingYear, (int)drParent["Thang"], 1);
			}

			frmBudgetTc_Edit frmEdit = new frmBudgetTc_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsBudgetDetail.Position >= 0)
						dtBudgetTcDetail.ImportRow(drCurrent);
					else
						dtBudgetTcDetail.Rows.Add(drCurrent);

					bdsBudgetDetail.Position = bdsBudgetDetail.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsBudgetDetail.Current).Row);

				numTTien_Thu.Value = Common.MaxDCValue(dtBudgetTcDetail, "Tien_Thu_Kh");
				numTTien_Chi.Value = Common.SumDCValue(dtBudgetTcDetail, "Tien_Chi_Kh", "");
				numTTien_Thu_Nt.Value = Common.SumDCValue(dtBudgetTcDetail, "Tien_Thu_Kh_Nt", "");
				numTTien_Chi_Nt.Value = Common.SumDCValue(dtBudgetTcDetail, "Tien_Chi_Kh_Nt", "");



				dtBudgetTcDetail.AcceptChanges();

                ((DataRowView)bdsBudgetTc.Current).Row["Tien_Thu_Kh"] = Common.MaxDCValue(dtBudgetTcDetail, "Tien_Thu_Kh");
                ((DataRowView)bdsBudgetTc.Current).Row["Tien_Chi_Kh"] = Common.SumDCValue(dtBudgetTcDetail, "Tien_Chi_Kh", "");
                ((DataRowView)bdsBudgetTc.Current).Row["Tien_Thu_Kh_Nt"] = Common.SumDCValue(dtBudgetTcDetail, "Tien_Thu_Kh_Nt", "");
                ((DataRowView)bdsBudgetTc.Current).Row["Tien_Chi_Kh_Nt"] = Common.SumDCValue(dtBudgetTcDetail, "Tien_Chi_Kh_Nt", "");

			}
		}

		public override void Delete()
		{
            if (splitContainer1.Panel2Collapsed)
                return;

			if (bdsBudgetDetail.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsBudgetDetail.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("CAKEHOACH", drCurrent))
			{
				bdsBudgetDetail.RemoveAt(bdsBudgetDetail.Position);
				dtBudgetTcDetail.AcceptChanges();
			}
		}

		void EnterValid()
		{
			Hashtable htPara = new Hashtable();
			htPara["THANG"] = ((DataRowView)bdsBudgetTc.Current)["Thang"];
			htPara["NAM"] = Element.sysWorkingYear;
			htPara["MA_DVCS"] = Element.sysMa_DvCs;

			dtBudgetTcDetail = SQLExec.ExecuteReturnDt("sp_GetBudgetTc", htPara, CommandType.StoredProcedure);

			bdsBudgetDetail.DataSource = dtBudgetTcDetail;
			dgvBudgetDetail.DataSource = bdsBudgetDetail;

            //splitContainer1.Panel1Collapsed = true;
            //splitContainer1.Panel2Collapsed = false;

			bdsSearch = bdsBudgetDetail;
			ExportControl = dgvBudgetDetail;

			numTTien_Thu.Value = Common.MaxDCValue(dtBudgetTcDetail, "Tien_Thu_Kh");
			numTTien_Chi.Value = Common.SumDCValue(dtBudgetTcDetail, "Tien_Chi_Kh", "");
			numTTien_Thu_Nt.Value = Common.SumDCValue(dtBudgetTcDetail, "Tien_Thu_Kh_Nt", "");
			numTTien_Chi_Nt.Value = Common.SumDCValue(dtBudgetTcDetail, "Tien_Chi_Kh_Nt", "");


            ((DataRowView)bdsBudgetTc.Current).Row["Tien_Thu_Kh"] = Common.MaxDCValue(dtBudgetTcDetail, "Tien_Thu_Kh");
            ((DataRowView)bdsBudgetTc.Current).Row["Tien_Chi_Kh"] = Common.SumDCValue(dtBudgetTcDetail, "Tien_Chi_Kh", "");
            ((DataRowView)bdsBudgetTc.Current).Row["Tien_Thu_Kh_Nt"] = Common.SumDCValue(dtBudgetTcDetail, "Tien_Thu_Kh_Nt", "");
            ((DataRowView)bdsBudgetTc.Current).Row["Tien_Chi_Kh_Nt"] = Common.SumDCValue(dtBudgetTcDetail, "Tien_Chi_Kh_Nt", "");

            

			dgvBudgetDetail.Focus();
		}

		void btNew_Click(object sender, EventArgs e)
		{
			this.Edit(enuEdit.New);
		}

		void btEdit_Click(object sender, EventArgs e)
		{
			this.Edit(enuEdit.Edit);
		}

		void btDelete_Click(object sender, EventArgs e)
		{
			this.Delete();
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Enter:
					EnterValid();
					return;
/*
				case Keys.Escape:
                    if (dgvBudgetDetail.Visible)
                    {
                        //splitContainer1.Panel1Collapsed = false;
                        //splitContainer1.Panel2Collapsed = true;

                        bdsSearch = bdsBudgetTc;
                        ExportControl = dgvBudgetTc;

                        ((DataRowView)bdsBudgetTc.Current).Row["Tien_Thu_Kh"] = Common.SumDCValue(dtBudgetTcDetail, "Tien_Thu_Kh", "");
                        ((DataRowView)bdsBudgetTc.Current).Row["Tien_Chi_Kh"] = Common.SumDCValue(dtBudgetTcDetail, "Tien_Chi_Kh", "");
                        ((DataRowView)bdsBudgetTc.Current).Row["Tien_Thu_Kh_Nt"] = Common.SumDCValue(dtBudgetTcDetail, "Tien_Thu_Kh_Nt", "");
                        ((DataRowView)bdsBudgetTc.Current).Row["Tien_Chi_Kh_Nt"] = Common.SumDCValue(dtBudgetTcDetail, "Tien_Chi_Kh_Nt", "");

                        dgvBudgetTc.Focus();
                    }
                    else
                        //this.Close();
                        Common.CloseCurrentForm();
					return;
 */

			}

			if (this.ActiveControl == dgvBudgetDetail)
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
	}
}
