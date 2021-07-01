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
using Epoint.Systems.Commons;
using System.Data.SqlClient;

namespace Epoint.Modules.AR
{
	public partial class frmPJP_Import : Epoint.Systems.Customizes.frmView
	{
		public string strError = string.Empty;
		public DataTable dtImport;


		public frmPJP_Import()
		{
			InitializeComponent();
			btSelectFile.Click += new EventHandler(btSelectFile_Click);
			btImport.Click += new EventHandler(btImport_Click);
			btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);			
		}

		public void Load()
		{          
			BindingLanguage();			           
			this.ShowDialog();
		}
        private bool Save()
        {
			return true;
        }
		void Setdefault(ref DataTable dt)
		{
			foreach (DataRow dr in dt.Rows)
			{
				int intStt = 0;
				if (int.TryParse(dr["Stt"].ToString(), out intStt))
				{
					dr["Stt"] = 0;
				}
				dr.AcceptChanges();
			}
		}
		public virtual void Import_Excel(bool CheckAPI)
		{
			//string strMsg = (Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn có muốn ghi đè lên mẫu tin đã tồn tại không ?" : "Do you want to override exists data ?");
			bool bIsImport = DataTool.SQLCheckExist("sys.procedures", "Name", "OM_Import_PJP");
			if (bIsImport)
			{

				SqlCommand command = SQLExec.GetNewSQLConnection().CreateCommand();
				command.CommandText = "OM_Import_PJP";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);
				command.Parameters.AddWithValue("@UserId", Element.sysUser_Id);
				command.Parameters.AddWithValue("@IsDelete", chkIs_Delete.Checked);
				SqlParameter parameter = new SqlParameter
				{
					SqlDbType = SqlDbType.Structured,
					ParameterName = "@TablePJP",
					TypeName = "TVP_OMPJP",
					Value = dtImport
				};
				command.Parameters.Add(parameter);
				try
				{
					command.ExecuteNonQuery();
				}
				catch (Exception exception)
				{
					command.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
					command.CommandType = CommandType.Text;
					command.Parameters.Clear();
					command.ExecuteNonQuery();
					EpointProcessBox.AddMessage("Có lỗi xảy ra :" + exception.Message);
				}

			}

			EpointProcessBox.AddMessage("Kết thúc");
		}
		public override void EpointRelease()
		{

			Import_Excel(true);

		}
		private void btAccept_Click(object sender, EventArgs e)
		{
            
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
		
			this.Close();
		}

		void btSelectFile_Click(object sender, EventArgs e)
		{			
			strError = string.Empty;

			OpenFileDialog ofdlg = new OpenFileDialog();
			ofdlg.Filter = "xls files (*.xls;*.xlsx)|*.xls;*.xlsx";
			ofdlg.RestoreDirectory = true;
			if (ofdlg.ShowDialog() != DialogResult.OK)
				return;
			txtFile_Name.Text = ofdlg.FileName;

		}
		void btImport_Click(object sender, EventArgs e)
		{
			strError = string.Empty;

			dtImport = Common.ReadExcel(txtFile_Name.Text);
			Setdefault(ref dtImport);
			EpointProcessBox.Show(this);
		}
	}
}
