using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Lists;

namespace Epoint.Modules.AR
{
    public partial class frmDiscBreak_Edit : Epoint.Systems.Customizes.frmEdit
    {
        public frmDiscBreak_Edit()
        {
            InitializeComponent();

            this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
        }

        public void Load(enuEdit enuNew_Edit, DataRow drEdit)
        {
            this.enuNew_Edit = enuNew_Edit;
            this.drEdit = drEdit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;

            Common.ScaterMemvar(this, ref drEdit);

            BindingLanguage();
            LoadDicName();
            Build();
            this.ShowDialog();
        }


        private void Build()
        {
            DataRow drDiscProg = DataTool.SQLGetDataRowByID("OM_Discount", "Ma_CTKM", txtMa_CTKM.Text);
            string strHinh_thu_Km = drDiscProg["Hinh_Thuc_KM"].ToString();
            string strBreakBy = drDiscProg["BreakBy"].ToString();
            if (strHinh_thu_Km == "IN")
            {
                numDiscAmt.Enabled = false;
                numDiscPer.Enabled = false;
                numDiscQty.Enabled = true;

            }
            else if (strHinh_thu_Km == "PP")
            {
                numDiscAmt.Enabled = false;
                numDiscQty.Enabled = false;
                numDiscAmt.Value = 0;
                numDiscQty.Value = 0;
                numDiscPer.Enabled = true;

            }
            else if (strHinh_thu_Km == "II")
            {
                numDiscAmt.Enabled = true;
                numDiscPer.Enabled = false;
                numDiscQty.Enabled = false;
                numDiscPer.Value = 0;
                numDiscQty.Value = 0;

            }
            
            if (strBreakBy == "Q")
            {
                numBreakAmt.Enabled = false;
                numBreakQty.Enabled = true;

                numToBreakAmt.Enabled = false;
                numToBreakQty.Enabled = true;

                numToBreakAmt.Value = 0;
                numBreakAmt.Value = 0;

            }
            else
                if (strBreakBy == "A")
                {
                    numBreakAmt.Enabled = true;
                    numBreakQty.Enabled = false;
                    numBreakQty.Value = 0;

                    numToBreakAmt.Enabled = true;
                    numToBreakQty.Enabled = false;
                    numToBreakQty.Value = 0;
                }

            

        }
        private void LoadDicName()
        {
        }

        private bool FormCheckValid()
        {


            return true;
        }

        private bool Save()
        {
            Common.GatherMemvar(this, ref drEdit);

            //Kiem tra Valid tren Form
            if (!FormCheckValid())
                return false;

            //Luu xuong CSDL
            if (!DataTool.SQLUpdate(enuNew_Edit, "OM_DISCBREAK", ref drEdit))
                return false;

            return true;
        }


        void btAccept_Click(object sender, EventArgs e)
        {
            if (this.Save())
            {
                this.isAccept = true;
                this.Close();
            }
        }
        void btCancel_Click(object sender, EventArgs e)
        {
            this.isAccept = false;
            this.Close();
        }
    }
}
