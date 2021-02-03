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

namespace Epoint.Modules.GL
{
	public partial class frmBudgetCp : Epoint.Systems.Customizes.frmView
	{
		DataTable dtBudgetCp;
		BindingSource bdsBudgetCp = new BindingSource();

		DataRow drCurrent;

		string strTk = string.Empty;

		public frmBudgetCp()
		{
			InitializeComponent();

			btNew.Click += new EventHandler(btNew_Click);
			btEdit.Click += new EventHandler(btEdit_Click);
			btDelete.Click += new EventHandler(btDelete_Click);			
		}

		public void Load(string strTk)
		{
			this.strTk = strTk;

			this.Build();
			this.FillData();
			this.BindingLanguage();

			this.Show();
		}

		void Build()
		{
			dgvBudgetCp.strZone = "GLBudgetCp";
			dgvBudgetCp.BuildGridView();
		}

		void FillData()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("NAM", Element.sysWorkingYear);
			htPara.Add("TK", strTk);
			htPara.Add("KIEU_TH", 1);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			dtBudgetCp = SQLExec.ExecuteReturnDt("sp_GetBudgetCp", htPara, CommandType.StoredProcedure);

			DataColumn dcNew = new DataColumn("TTIEN_KH", typeof(double));
			dcNew.Expression = "Tien_Kh01+Tien_Kh02+Tien_Kh03+Tien_Kh04+Tien_Kh05+Tien_Kh06+Tien_Kh07+Tien_Kh08+Tien_Kh09+Tien_Kh10+Tien_Kh11+Tien_Kh12";
			dtBudgetCp.Columns.Add(dcNew);

			bdsBudgetCp.DataSource = dtBudgetCp;
			dgvBudgetCp.DataSource = bdsBudgetCp;

			bdsBudgetCp.Sort = "Bold, TK, MA_KM";

			bdsSearch = bdsBudgetCp;
			ExportControl = dgvBudgetCp;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsBudgetCp.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai
			//if (bdsBudgetCp.Position >= 0)
			if (enuNew_Edit == enuEdit.Edit)
				Common.CopyDataRow(((DataRowView)bdsBudgetCp.Current).Row, ref drCurrent);
			else
				drCurrent = dtBudgetCp.NewRow();

			if (enuNew_Edit == enuEdit.New)
			{
				drCurrent["Nam"] = Element.sysWorkingYear;
				drCurrent["Bold"] = false;
				//drCurrent["Tk"] = strTk;
			}

			frmBudgetCp_Edit frmEdit = new frmBudgetCp_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					//if (bdsBudgetCp.Position >= 0)
					if (enuNew_Edit == enuEdit.Edit)
						dtBudgetCp.ImportRow(drCurrent);
					else
						dtBudgetCp.Rows.Add(drCurrent);

					bdsBudgetCp.Position = bdsBudgetCp.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsBudgetCp.Current).Row);

				dtBudgetCp.AcceptChanges();

				this.Update_TTien();
			}
		}

		public override void Delete()
		{
			if (bdsBudgetCp.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsBudgetCp.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("GLKEHOACH", drCurrent))
			{
				bdsBudgetCp.RemoveAt(bdsBudgetCp.Position);
				dtBudgetCp.AcceptChanges();
			}
		}

		void Update_TTien()
		{
			DataRow drTotal = dtBudgetCp.Select("Bold = true")[0];

			for (int iThang = 1; iThang <= 12; iThang++)
			{
				drTotal["Tien_Kh" + iThang.ToString().Trim().PadLeft(2, '0')] = Common.SumDCValue(dtBudgetCp, "Tien_Kh" + iThang.ToString().Trim().PadLeft(2, '0'), "Bold = false");
			}
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
	}
}
