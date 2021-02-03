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


namespace Epoint.Modules
{
	public partial class frmDanhSo_Ct : Epoint.Systems.Customizes.frmEdit
	{
		#region Contructor

		public frmDanhSo_Ct()
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

		private bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtFormat_Text.Text == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("FORMAT_TEXT") + " " + Languages.GetLanguage("NOTEMPTY"));
				return false;
			}

			if (txtFix_Text.Text == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Fix_Tex") + " " + Languages.GetLanguage("NOTEMPTY"));
				return false;
			}

			return bvalid;
		}

		#endregion

		#region Event

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.FormCheckValid())
			{
				if (Common.MsgYes_No("Bạn có chắc chắn đánh lại số chứng từ hay không?", "Y"))
				{
					this.isAccept = true;
					this.Close();
				}
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}

		#endregion

	}
}
