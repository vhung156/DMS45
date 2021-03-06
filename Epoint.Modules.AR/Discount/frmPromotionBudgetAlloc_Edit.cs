﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Elements;
using System.Collections;
using System.Data.SqlClient;

namespace Epoint.Modules.AR
{
    public partial class frmPromotionBudgetAlloc_Edit : Epoint.Lists.frmEdit
    {

        #region Khai báo
        private int ident00 = 0;
        private double dbAmtAlloc = 0, dbQtyAlloc = 0;

        #endregion

        #region Phuong thuc

        public frmPromotionBudgetAlloc_Edit()
        {
            InitializeComponent();

            //this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            //this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
        }
        public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
        {
            if (Element.Is_Running)
            {
                this.drEdit = drEdit;
                this.enuNew_Edit = enuNew_Edit;
                this.Tag = (char)enuNew_Edit + "," + this.Tag;

                this.BindingCombobox();
                Common.ScaterMemvar(this, ref drEdit);

                BindingLanguage();
                LoadDicName();

                if (this.drEdit["Ident00"] == DBNull.Value || this.enuNew_Edit == enuEdit.New)
                    this.drEdit["Ident00"] = 0;

                ident00 = Convert.ToInt32(this.drEdit["Ident00"]);

                if (this.enuNew_Edit == enuEdit.Edit)
                {
                    txtMa_Ns.Enabled = false;
                }

                dbAmtAlloc = Convert.ToDouble(this.drEdit["AmtAlloc"]);
                dbQtyAlloc = Convert.ToDouble(this.drEdit["QtyAlloc"]);

                if (dbQtyAlloc > 0)
                    numAmtAlloc.Enabled = false;
                else
                    numQtyAlloc.Enabled = false;
                this.ShowDialog();
            }
        }

        private void LoadDicName()
        {

        }

        public override bool FormCheckValid()
        {
            bool bvalid = true;
            if (txtMa_Ns.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ma_Ns") + " " +
                        Languages.GetLanguage("Not_Null"));
                return false;
            }
            return bvalid;
        }
        private bool FormCheckBudgetAllocated()
        {
            bool bvalid = true;
            Hashtable ht = new Hashtable();
            //Check Saleman allocated
            ht.Add("MA_NS", txtMa_Ns.Text);
            ht.Add("IDENT00", ident00);
            ht.Add("MA_DVCS", Element.sysMa_DvCs);

            int iCheck0 = Convert.ToInt32(SQLExec.ExecuteReturnValue("sp_OM_CheckBudgetAllocatedForSaleMan", ht, CommandType.StoredProcedure));
            if (iCheck0 == 0)
            {
                Common.MsgOk("Nhân viên " +txtMa_Cbnv.Text+ " đã được phân bổ ngân sách!");
                return false;
            }

            //Check sum allocated
            ht.Clear();
            ht.Add("MA_NS", txtMa_Ns.Text);
            ht.Add("IDENT00", ident00);
            ht.Add("QTYALLOC", numQtyAlloc.Value);
            ht.Add("AMTALLOC", numAmtAlloc.Value);
            ht.Add("MA_DVCS", Element.sysMa_DvCs);

            int iCheck1 = Convert.ToInt32(SQLExec.ExecuteReturnValue("sp_OM_CheckBudgetAllocated", ht, CommandType.StoredProcedure));
            if (iCheck1 == 0)
            {
                Common.MsgOk("Ngân sách phân bổ vượt  quá ngân sách tổng!");
                return false;
            }
            return bvalid;
        }
        public override bool Save()
        {

            Common.GatherMemvar(this, ref drEdit);

            //Kiem tra Valid tren Form
            if (!FormCheckValid())
                return false;

            if (!FormCheckBudgetAllocated())
                return false;


            //Luu xuong CSDL
            if (!DataTool.SQLUpdate(enuNew_Edit, "OM_BudgetAlloc", ref drEdit))
                return false;
            /*SqlCommand command = SQLExec.GetNewSQLConnection().CreateCommand();
            command.CommandText = "sp_OM_SaveBudgetAlloc";
            command.CommandType = CommandType.StoredProcedure;
            try
            {

                //command.Parameters.AddWithValue("@Ident00", ParameterDirection.Output);
                command.Parameters.Add(new SqlParameter { ParameterName = "@Ident00", Direction = ParameterDirection.Output, Value = drEdit["Ident00"] });
                command.Parameters.AddWithValue("@RefNbr", drEdit["RefNbr"]);
                command.Parameters.AddWithValue("@Ma_Cbnv", drEdit["Ma_Cbnv"]);
                command.Parameters.AddWithValue("@QtyAlloc", drEdit["QtyAlloc"]);
                command.Parameters.AddWithValue("@AmtAlloc", drEdit["AmtAlloc"]);
                command.Parameters.AddWithValue("@Ma_Dvcs", Element.sysMa_DvCs);
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                command.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
                command.CommandType = CommandType.Text;
                command.Parameters.Clear();
                command.ExecuteNonQuery();
                return false;
            }*/
            return true;
        }
        private void BindingCombobox()
        {
        }
        #endregion

        #region Su kien

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

        #endregion
    }
}