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
	public partial class frmGiaBanNh_Copy : Epoint.Systems.Customizes.frmEdit
	{
		#region Contructor

        public frmGiaBanNh_Copy()
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
			if(txtMa_Nh_Dt.Text == string.Empty)
            {
                EpointMessage.MsgOk("Mã nhóm đối tượng rỗng !");
                txtMa_Nh_Dt.Select();
                return false;
            }

            if (txtMa_Nh_Dt_To.Text == string.Empty)
            {
                EpointMessage.MsgOk("Mã nhóm đối tượng đến rỗng !");
                txtMa_Nh_Dt_To.Select();
                return false;
            }

            if (txtMa_Nh_Dt.Text == txtMa_Nh_Dt_To.Text)
            {
                EpointMessage.MsgOk("Hai mã nhóm không được giống nhau !");
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
				if (Common.MsgYes_No("Bạn có chắc chắn muốn copy giá vào mã nhóm" +txtMa_Nh_Dt_To.Text+"?", "Y"))
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
