using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Lists;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;


namespace Epoint.Modules.AR
{
	public partial class frmPJPDetail : Epoint.Systems.Customizes.frmEdit
	{
		#region Contructor

        public DateTime dtNgay1;
        public DateTime dtNgay2;

        public frmPJPDetail()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}		

		#endregion		

		#region phuong thuc

		public void Load()
		{
			this.ShowDialog();
		}
        public void Load(string strMa_PJP)
        {
            DataRow drPJP = DataTool.SQLGetDataRowByID("OM_PJP", "Ma_PJP", strMa_PJP);
            txtMa_PJP.Text = strMa_PJP;
            txtTen_PJP.Text = drPJP["Ten_PJP"].ToString();
            txtMa_Cbnv.Text = drPJP["Ma_Cbnv"].ToString();
            dteNgay_BD.Text = Library.DateToStr(DateTime.Now);
            dteNgay_Kt.Text = drPJP["Ngay_Kt"].ToString();
            this.ShowDialog();
        }
		private bool FormCheckValid()
		{
			bool bvalid = true;
			
			return bvalid;
		}

		#endregion

		#region Event

		void btAccept_Click(object sender, EventArgs e)
		{
			this.isAccept = true;
            this.dtNgay1 = Library.StrToDate( dteNgay_BD.Text);
            this.dtNgay2 = Library.StrToDate(dteNgay_Kt.Text);
			this.Close();
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}

		#endregion

	}
}
