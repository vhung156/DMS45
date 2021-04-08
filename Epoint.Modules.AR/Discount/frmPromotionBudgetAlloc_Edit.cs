using System;
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
        //private string Ma_CtKM_Old = string.Empty;

        #endregion

        #region Phuong thuc

        public frmPromotionBudgetAlloc_Edit()
        {
            InitializeComponent();

            this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
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

                if (this.enuNew_Edit == enuEdit.Edit)
                {
                    txtMa_Ns.Enabled = false;
                }
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

        private bool Save()
        {


            Common.GatherMemvar(this, ref drEdit);


            //Kiem tra Valid tren Form
            if (!FormCheckValid())
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