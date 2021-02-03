using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Elements;
using Epoint.Systems.Customizes;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Lists;
using System.Collections;

namespace Epoint.Modules
{
    public partial class frmTrans_Voucher : Epoint.Systems.Controls.frmBase
    {
        string strMa_Ct;
        public frmTrans_Voucher()
        {
            InitializeComponent();

            btAccept.Click += new EventHandler(btOk_Click);
            btCancel.Click += new EventHandler(btCancel_Click);

            chkAll.Click += new EventHandler(chkAll_Click);
        }

        void chkAll_Click(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                //txtMa_Ct_List.Enabled = false;
                //txtMa_Ct_List.Text = "ALL";
            }
            else
            {
                //txtMa_Ct_List.Enabled = true;
                //txtMa_Ct_List.Text = "";
            }
        }

        new public void Load()
        {

            //txtMa_Ct_List.Validating += new CancelEventHandler(txtMa_Ct_Validating);
            this.txtNgay_Ct1.Text = Element.sysNgay_Ct1.ToString();
            this.txtNgay_Ct2.Text = Element.sysNgay_Ct2.ToString();

            this.BindingLanguage();
            this.Show();
        }

        void btOk_Click(object sender, EventArgs e)
        {
            //string strServerSource = Parameters.GetParaValue("SERVER_SOURCE").ToString();
            //Object strDBSource = Parameters.GetParaValue("DATABASE_SOURCE");
            string strDBSource = Element.sysDatabaseName.ToString();
            //string strServerDest = Parameters.GetParaValue("SERVER_DEST").ToString();
            //Object strDBSource = Element.sysDatabaseName;
            string strDBDest = Parameters.GetParaValue("DATABASE_DEST").ToString();

            DateTime dteNgay_Ct1 = Library.StrToDate(this.txtNgay_Ct1.Text);
            DateTime dteNgay_Ct2 = Library.StrToDate(this.txtNgay_Ct2.Text);

            if (!Common.CheckDataLocked(dteNgay_Ct1) || !Common.CheckDataLocked(dteNgay_Ct2))
            {
                Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
                return;
            }
            Hashtable ht = new Hashtable();
            //ht["SERVERSOURCE"] = strServerSource;
            //ht["SERVERDEST"] = strServerDest;
            ht["NGAY_CT1"] = dteNgay_Ct1;
            ht["NGAY_CT2"] = dteNgay_Ct2;
            ht["DBSOURCE"] = strDBSource;
            ht["DBDEST"] = strDBDest;
            ht["MA_DVCS"] = Element.sysMa_DvCs.ToString();

            Common.ShowStatus(Languages.GetLanguage("In_Process"));               
            SQLExec.Execute("sp_DuyetCt",ht, CommandType.StoredProcedure);

            if (chkDanhMuc.Checked)
            {
                SQLExec.Execute("sp_Tranfer_DanhMuc", ht, CommandType.StoredProcedure);
            }

            //lock (this)
            //{
            //    if (chkDanhMuc.Checked)
            //    {
            //        string[] strArrPara = new string[] { "@ServerSource", "@ServerDest", "@DBSource", "@DBDest", "@Ma_DvCs" };
            //        object[] objArrPara = new object[] { strServerSource, strServerDest, strDBSource, strDBDest, Element.sysMa_DvCs };
            //        SQLExec.Execute("sp_Tranfer_DanhMuc", strArrPara, objArrPara, CommandType.StoredProcedure);
            //    }

            //}
            Element.sysNgay_Ct1 = Library.StrToDate(this.txtNgay_Ct1.Text);
            Element.sysNgay_Ct2 = Library.StrToDate(this.txtNgay_Ct2.Text);

            Common.MsgOk(Languages.GetLanguage("EndProcess"));
            Common.EndShowStatus();

            this.Close();

        }

        void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
