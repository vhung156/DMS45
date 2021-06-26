using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Text;

using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Elements;
using System.Windows.Forms;

namespace Epoint.Modules
{
	public class PrintVoucher
	{
        public static bool Print(DataRow drPhView, bool bPreview, bool bShowDialog, ref bool bInVisibleNextPrint, ref string strReport_File_First)
		{
			string strStt = (string)drPhView["Stt"];
			string strMa_Ct = (string)drPhView["Ma_Ct"];
            string strMa_Tte = "VND";// (string)drPhView["Ma_Tte"];
			string strReportTag = string.Empty;
			string strTable_Ph = string.Empty;
			string strTable_Ct = string.Empty;
			bool bIs_Vnd = true;            
            string strReport_File = string.Empty;
            bool bInVisibleNextPrint0 = false;
            bool bIs_Doc_Tien1 = false;
            int iSo_Lien = 1;

			DataRow drDmCt = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", strMa_Ct);
			DataTable dtHeader;
			DataTable dtDetail;

			strTable_Ph = (string)drDmCt["Table_Ph"];
			strTable_Ct = (string)drDmCt["Table_Ct"];
            strReport_File = (string)drDmCt["Report_File"];

            if (strMa_Ct == "BN" && !bInVisibleNextPrint)
            {
                DataRow drCtTien = DataTool.SQLGetDataRowByID(strTable_Ct, "Stt", strStt);

                if (!drPhView.Table.Columns.Contains("TK_NH"))
                    drPhView.Table.Columns.Add("TK_NH", typeof(string));

                drPhView["Tk_Nh"] = (string)drCtTien["Tk_Co"];

                frmIn_CT_UNC frm = new frmIn_CT_UNC();

                if (strMa_Tte != Element.sysMa_Tte)
                    frm.rdbTien_Nt.Checked = true;

                frm.Load(drPhView);

                if (!frm.isAccept)
                    return false;

                bInVisibleNextPrint0 = frm.chkInVisibleNextPrint.Checked;
                bIs_Vnd = frm.rdbTien_VND.Checked;

                strReport_File = frm.cboMau_In.SelectedValue.ToString();
                iSo_Lien = frm.iSo_Lien;
            }
            else
            {
                //In thông tin chữ ký
                string strName1 = string.Empty;
                string strName2 = string.Empty;
                string strName3 = string.Empty;
                string strName4 = string.Empty;
                string strName5 = string.Empty;
                
                string strKey = "Ma_Dvcs = '" + Element.sysMa_DvCs + "'" + " AND Ma_Ct = '" + strMa_Ct + "'";
                DataTable dtDmCk = DataTool.SQLGetDataTable("SYSDMCK", "*", strKey, "Ma_Ct");
                if (dtDmCk != null)
                {
                    foreach (DataRow drDmCk in dtDmCk.Rows)
                    {
                        strName1 = drDmCk["Name1"].ToString();
                        strName2 = drDmCk["Name2"].ToString();
                        strName3 = drDmCk["Name3"].ToString();
                        strName4 = drDmCk["Name4"].ToString();
                        strName5 = drDmCk["Name5"].ToString();
                    }
                }

                //Cập nhật thông tin chữ ký xuống GLVOUCHER
               
                string strSQLUpdate = "UPDATE " + strTable_Ph + " SET " +
                        @"Chu_Ky_1 = @Chu_Ky_1, Chu_Ky_2 = @Chu_Ky_2, Chu_Ky_3 = @Chu_Ky_3, Chu_Ky_4 = @Chu_Ky_4, Chu_Ky_5 = @Chu_Ky_5" +
                        " WHERE Stt = @Stt";

                Hashtable htChuKy = new Hashtable();
                htChuKy["CHU_KY_1"] = strName1;
                htChuKy["CHU_KY_2"] = strName2;
                htChuKy["CHU_KY_3"] = strName3;
                htChuKy["CHU_KY_4"] = strName4;
                htChuKy["CHU_KY_5"] = strName5;
                htChuKy["STT"] = strStt;

                SQLExec.Execute(strSQLUpdate, htChuKy, CommandType.Text);
                
                //In Tien_Nt
                if (strMa_Tte != Element.sysMa_Tte)
                {
                    frmIn_CT_Tien_NT frm = new frmIn_CT_Tien_NT();
                    frm.Load(drPhView);

                    if (!frm.isAccept)
                        return false;

                    bIs_Vnd = frm.rdbTien_VND.Checked;
                }
            }

            //Chon nhieu mau report khi in
            DataTable dtDmMauIn = DataTool.SQLGetDataTable("SYSDMMAUCT", "Ma_Mau, Ten_Mau", "Ma_Ct = '" + strMa_Ct + "'", "Ma_Mau");            

            if (dtDmMauIn.Rows.Count == 1)
                strReport_File = (string)dtDmMauIn.Rows[0]["Ma_Mau"];
            else if (strMa_Ct != "BN" && dtDmMauIn.Rows.Count > 1 && !bInVisibleNextPrint)
            {
                if (strMa_Ct == "PC" || strMa_Ct == "PT")
                {
                    frmIn_Ct_Khac frmInHD = new frmIn_Ct_Khac();
                    frmInHD.strMa_Ct = strMa_Ct;
                    frmInHD.Is_Design = false;
                    frmInHD.Load(drPhView);

                    strReport_File = frmInHD.cboMau_In.SelectedValue.ToString();
                    iSo_Lien = frmInHD.iSo_Lien;
                    bInVisibleNextPrint0 = frmInHD.chkInVisibleNextPrint.Checked;
                    bIs_Doc_Tien1 = frmInHD.chkIs_Doc_Tien1.Checked;
                    if (!frmInHD.Is_Design)
                        return false;
                }
                else
                {
                    frmIn_Ct_HD frmInHD = new frmIn_Ct_HD();
                    frmInHD.strMa_Ct = strMa_Ct;
                    frmInHD.Is_Design = false;
                    frmInHD.Load(drPhView);

                    strReport_File = frmInHD.cboMau_In.SelectedValue.ToString();
                    iSo_Lien = frmInHD.iSo_Lien;
                    bInVisibleNextPrint0 = frmInHD.chkInVisibleNextPrint.Checked;

                    if (!frmInHD.Is_Design)
                        return false;
                }
            }            
            string strMau_So = string.Empty;

            if (drPhView.Table.Columns.Contains("Mau_So"))
                strMau_So = (string)drPhView["Mau_So"];

			Hashtable ht = new Hashtable();
            ht.Add("STT", strStt);
            ht.Add("MA_CT", strMa_Ct);
            ht.Add("IS_VND", bIs_Vnd ? 1 : 0);
            ht.Add("LANGUAGE_TYPE", (char)Element.sysLanguage);

			DataSet dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintVoucher", ht, CommandType.StoredProcedure);

			//Upadte Gia = 0, Tien = 0, TTien = 0 khi in chung tu doi voi User cam ACCESS_PRICE
			DataTable dtPrinVoucherHeader = new DataTable();
			DataTable dtPrinVoucherDetail = new DataTable();
			dtPrinVoucherHeader = dsPrintVoucher.Tables[0];
			dtPrinVoucherDetail = dsPrintVoucher.Tables[1];
			if (DataTool.SQLCheckExist("SYSOBJECT", "Object_ID", "ACCESS_PRICE") && !Common.CheckPermission("ACCESS_PRICE", enuPermission_Type.Allow_Access))
			{
				foreach (DataColumn dc in dtPrinVoucherHeader.Columns)
				{
					if (dc.ColumnName.StartsWith("GIA") || dc.ColumnName.StartsWith("TIEN") || dc.ColumnName.StartsWith("TTIEN") || dc.ColumnName.StartsWith("PS_NO") || dc.ColumnName.StartsWith("PS_CO") || dc.ColumnName.StartsWith("PS_TANG") || dc.ColumnName.StartsWith("PS_GIAM") || dc.ColumnName.StartsWith("DU_DAU") || dc.ColumnName.StartsWith("DU_CUOI") || dc.ColumnName.StartsWith("DU_NO") || dc.ColumnName.StartsWith("DU_CO"))
					{
						if (dc.DataType == typeof(double) || dc.DataType == typeof(decimal))
						{
							//Gán cột dữ liệu về 0
							foreach (DataRow dr in dtPrinVoucherHeader.Rows)
							{
								dr[dc] = 0;
							}

						}
						if (dc.DataType == typeof(string))
						{
							//Gán cột dữ liệu về rổng
							foreach (DataRow dr in dtPrinVoucherHeader.Rows)
							{
								dr[dc] = "";
							}

						}
					}
				}
				foreach (DataColumn dc in dtPrinVoucherDetail.Columns)
				{
					if (dc.ColumnName.StartsWith("GIA") || dc.ColumnName.StartsWith("TIEN") || dc.ColumnName.StartsWith("PS_NO") || dc.ColumnName.StartsWith("PS_CO") || dc.ColumnName.StartsWith("PS_TANG") || dc.ColumnName.StartsWith("PS_GIAM") || dc.ColumnName.StartsWith("DU_DAU") || dc.ColumnName.StartsWith("DU_CUOI") || dc.ColumnName.StartsWith("DU_NO") || dc.ColumnName.StartsWith("DU_CO"))
					{
						if (dc.DataType == typeof(double) || dc.DataType == typeof(decimal))
						{
							//Gán cột dữ liệu về 0
							foreach (DataRow dr in dtPrinVoucherDetail.Rows)
							{
								dr[dc] = 0;
							}

						}
					}
				}
			}

			dtHeader = dtPrinVoucherHeader;
			dtDetail = dtPrinVoucherDetail;

			dtHeader.Columns.Add("REPORT_FILE", typeof(string));
			dtHeader.Columns.Add("TITLE", typeof(string));
			dtHeader.Columns.Add("IS_VND", typeof(bool));
			dtHeader.Columns.Add("DOC_TIEN", typeof(string));
            dtHeader.Columns.Add("DOC_TIEN1", typeof(string));
            dtHeader.Columns.Add("DOC_TIEN_TC", typeof(string));

			DataRow drHeader = dtHeader.Rows[0];

			drHeader["Is_Vnd"] = bIs_Vnd;
			drHeader["Title"] = ((string)drDmCt["Title"]).ToUpper();            
            if (bInVisibleNextPrint)
            {
                drHeader["Report_File"] = strReport_File_First;
            }
            else
            {
                drHeader["Report_File"] = strReport_File;
                strReport_File_First = strReport_File;
                bInVisibleNextPrint = bInVisibleNextPrint0;
            }

            if (Element.sysLanguage == enuLanguageType.Vietnamese)
            {
                dtHeader.Rows[0]["Doc_Tien"] = !bIs_Vnd ? Common.ReadMoney(Convert.ToDouble(drHeader["TTien_Nt"]), strMa_Tte) : Common.ReadMoney(Convert.ToDouble(drHeader["TTien"]), Element.sysMa_Tte.ToString());

                if (drHeader.Table.Columns.Contains("TTien_Nt00"))
                {
                    dtHeader.Rows[0]["Doc_Tien_Tc"] = !bIs_Vnd ? Common.ReadMoney(Convert.ToDouble(drHeader["TTien_Nt00"]), strMa_Tte) : Common.ReadMoney(Convert.ToDouble(drHeader["TTien_Nt00"]), Element.sysMa_Tte.ToString());
                    dtHeader.Rows[0]["Doc_Tien_Tc"] = "(" + dtHeader.Rows[0]["Doc_Tien_Tc"].ToString() + ")";
                }
                if (bIs_Doc_Tien1)
                    dtHeader.Rows[0]["Doc_Tien1"] = "";
                else
                    dtHeader.Rows[0]["Doc_Tien1"] = !bIs_Vnd ? Common.ReadMoney(Convert.ToDouble(drHeader["TTien_Nt"]), strMa_Tte) : Common.ReadMoney(Convert.ToDouble(drHeader["TTien"]), Element.sysMa_Tte.ToString());
            }
            else
            {
                dtHeader.Rows[0]["Doc_Tien"] = !bIs_Vnd ? Common.ReadMoneyE(Convert.ToDouble(drHeader["TTien_Nt"]), strMa_Tte) : Common.ReadMoneyE(Convert.ToDouble(drHeader["TTien"]), Element.sysMa_Tte.ToString());

                if (bIs_Doc_Tien1)
                    dtHeader.Rows[0]["Doc_Tien1"] = "";
                else
                    dtHeader.Rows[0]["Doc_Tien1"] = !bIs_Vnd ? Common.ReadMoneyE(Convert.ToDouble(drHeader["TTien_Nt"]), strMa_Tte) : Common.ReadMoneyE(Convert.ToDouble(drHeader["TTien"]), Element.sysMa_Tte.ToString());
            }

			Epoint.Reports.frmReportPrint frmPrint = new Epoint.Reports.frmReportPrint();
			//frmPrint.MdiParent = Element.frmActiveMain;
			return frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog);
		}
        public static bool PrintPXK(string Ma_Px, bool bPreview, bool bShowDialog, ref bool bInVisibleNextPrint, ref string strReport_File_First,DataRow drCurrent)
        {
            string strMa_Px = Ma_Px;// (string)drPhView["Ma_Px"];
            string strReportTag = string.Empty;
            string strTable_Ph = string.Empty;
            string strTable_Ct = string.Empty;
            bool bIs_Vnd = true;
            string strReport_File = "rptPXK";
            bool bInVisibleNextPrint0 = false;

        
            DataTable dtHeader;
            DataTable dtDetail;

       

            Hashtable ht = new Hashtable();
            ht.Add("MA_PX", strMa_Px);
            DataSet dsPrintVoucher = new DataSet();
            dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintPXK", ht, CommandType.StoredProcedure);

            //Upadte Gia = 0, Tien = 0, TTien = 0 khi in chung tu doi voi User cam ACCESS_PRICE
            DataTable dtPrinVoucherHeader = new DataTable();
            DataTable dtPrinVoucherDetail = new DataTable();
            dtPrinVoucherHeader = dsPrintVoucher.Tables[0];
            dtPrinVoucherDetail = dsPrintVoucher.Tables[1];
           

            dtHeader = dtPrinVoucherHeader;
            dtDetail = dtPrinVoucherDetail;

            dtHeader.Columns.Add("REPORT_FILE", typeof(string));
            dtHeader.Columns.Add("TITLE", typeof(string));
            dtHeader.Columns.Add("IS_VND", typeof(bool));
            dtHeader.Columns.Add("DOC_TIEN", typeof(string));
            dtHeader.Columns.Add("DOC_TIEN1", typeof(string));

            DataRow drHeader = dtHeader.Rows[0];

            drHeader["Is_Vnd"] = bIs_Vnd;
            drHeader["Title"] = drCurrent["MA_CT"].ToString() == "IN" ? "PHIẾU XUẤT KHO":"PHIẾU NHẬP TRẢ HÀNG";
            if (bInVisibleNextPrint)
            {
                drHeader["Report_File"] = strReport_File_First;
            }
            else
            {
                drHeader["Report_File"] = strReport_File;
                strReport_File_First = strReport_File;
                bInVisibleNextPrint = bInVisibleNextPrint0;
            }

          
            Epoint.Reports.frmReportPrint frmPrint = new Epoint.Reports.frmReportPrint();
            //frmPrint.MdiParent = Element.frmActiveMain;
            return frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog);
        }
        public static bool PrintListOrder(string Ma_Px, bool bPreview, bool bShowDialog, ref bool bInVisibleNextPrint, ref string strReport_File_First)
        {
            string strMa_Px = Ma_Px;// (string)drPhView["Ma_Px"];
            string strReportTag = string.Empty;
            string strTable_Ph = string.Empty;
            string strTable_Ct = string.Empty;
            bool bIs_Vnd = true;
            string strReport_File = "rptPXKList";
            bool bInVisibleNextPrint0 = false;


            DataTable dtHeader;
            DataTable dtDetail;



            Hashtable ht = new Hashtable();
            ht.Add("MA_PX", strMa_Px);
            DataSet dsPrintVoucher = new DataSet();
            dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintListOrder", ht, CommandType.StoredProcedure);

            //Upadte Gia = 0, Tien = 0, TTien = 0 khi in chung tu doi voi User cam ACCESS_PRICE
            DataTable dtPrinVoucherHeader = new DataTable();
            DataTable dtPrinVoucherDetail = new DataTable();
            dtPrinVoucherHeader = dsPrintVoucher.Tables[0];
            dtPrinVoucherDetail = dsPrintVoucher.Tables[1];


            dtHeader = dtPrinVoucherHeader;
            dtDetail = dtPrinVoucherDetail;

            dtHeader.Columns.Add("REPORT_FILE", typeof(string));
            dtHeader.Columns.Add("TITLE", typeof(string));
            dtHeader.Columns.Add("IS_VND", typeof(bool));
            dtHeader.Columns.Add("DOC_TIEN", typeof(string));
            dtHeader.Columns.Add("DOC_TIEN1", typeof(string));

            DataRow drHeader = dtHeader.Rows[0];

            drHeader["Is_Vnd"] = bIs_Vnd;
            drHeader["Title"] = "DANH SÁCH ĐƠN HÀNG";
            if (bInVisibleNextPrint)
            {
                drHeader["Report_File"] = strReport_File_First;
            }
            else
            {
                drHeader["Report_File"] = strReport_File;
                strReport_File_First = strReport_File;
                bInVisibleNextPrint = bInVisibleNextPrint0;
            }


            Epoint.Reports.frmReportPrint frmPrint = new Epoint.Reports.frmReportPrint();
            //frmPrint.MdiParent = Element.frmActiveMain;
            return frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog);
        }

        public static void PrintInvoices(string Ma_Px)
        {
            string strMa_Px = Ma_Px;// (string)drPhView["Ma_Px"];
            
            bool bPreview = false;
           // bool bShowDialog;
           // bool bInVisibleNextPrint; 
           // string strReport_File_First;
            bool bAcceptShowDialog = true;
            bool bInVisibleNextPrint = false;
            string strReport_File_First = string.Empty;

            DataTable dtHeader;
            DataTable dtDetail;

            Hashtable ht = new Hashtable();
            ht.Add("MA_PX", strMa_Px);
            DataSet dsPrintVoucher = new DataSet();
            dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintListOrder", ht, CommandType.StoredProcedure);

            //Upadte Gia = 0, Tien = 0, TTien = 0 khi in chung tu doi voi User cam ACCESS_PRICE
            DataTable dtPrinVoucherHeader = new DataTable();
            DataTable dtPrinVoucherDetail = new DataTable();

            dtPrinVoucherHeader = dsPrintVoucher.Tables[0];
            dtPrinVoucherDetail = dsPrintVoucher.Tables[1];

            dtHeader = dtPrinVoucherHeader;
            dtDetail = dtPrinVoucherDetail;

            if (dtDetail.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataRow drCurrent in dtDetail.Rows)
               {
                   if (drCurrent["Stt"].ToString() != string.Empty)
                   {
                       if (i == 0)
                       {
                           bAcceptShowDialog = PrintVoucher.Print(drCurrent, bPreview, true, ref bInVisibleNextPrint, ref strReport_File_First);
                       }
                       else
                       {
                           if (bAcceptShowDialog)
                               bAcceptShowDialog = PrintVoucher.Print(drCurrent, bPreview, false, ref bInVisibleNextPrint, ref strReport_File_First);
                           else
                               break;
                       }
                       i++;
                   }
               }
            }
            
        }
        public static bool PrintIN_Crytal(string Stt,string rptFileName, bool bPreview,bool bShowDialog,string PrinterName)
        {
            //string rptFileName = Application.StartupPath + @"\Reports\CT_IN_Report.rpt";
            DataTable dtDetail;
            DataTable dtSubDetail;
            bool bAcceptShowDialog = true;
            bool bInVisibleNextPrint = false;

            Hashtable ht = new Hashtable();
            ht.Add("STT", Stt);
            DataSet dsPrintVoucher = new DataSet();
            dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintVoucher_IN", ht, CommandType.StoredProcedure);   
            Epoint.Reports.frmReportPrint_CRP frmPrint = new Epoint.Reports.frmReportPrint_CRP();
            return frmPrint.Load(Stt,dsPrintVoucher, rptFileName, bPreview, bShowDialog, PrinterName);

        }
        public static void PrintInvoices(string Ma_Px, bool IsRpt)
        {
            string strMa_Px = Ma_Px;// (string)drPhView["Ma_Px"];

            bool bPreview = false;
            bool bAcceptShowDialog = true;
            bool bInVisibleNextPrint = false;
            string strReport_File_First = string.Empty;
            string rptFileName = Application.StartupPath + @"\Reports\CT_IN_Report.rpt";
            DataTable dtHeader;
            DataTable dtDetail;

            Hashtable ht = new Hashtable();
            ht.Add("MA_PX", strMa_Px);
            DataSet dsPrintVoucher = new DataSet();
            dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintListOrder", ht, CommandType.StoredProcedure);

            //Upadte Gia = 0, Tien = 0, TTien = 0 khi in chung tu doi voi User cam ACCESS_PRICE
            DataTable dtPrinVoucherHeader = new DataTable();
            DataTable dtPrinVoucherDetail = new DataTable();

            dtPrinVoucherHeader = dsPrintVoucher.Tables[0];
            dtPrinVoucherDetail = dsPrintVoucher.Tables[1];

            dtHeader = dtPrinVoucherHeader;
            dtDetail = dtPrinVoucherDetail;


            PrintDialog dlg = new PrintDialog(); //Khởi tạo đối tượng PrintDialog
            dlg.ShowDialog(); //Hiển thị hộp thoại PrintDialog

            string PrinterName = dlg.PrinterSettings.PrinterName;


            if (dtDetail.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataRow drCurrent in dtDetail.Rows)
                {
                    string stt = drCurrent["Stt"].ToString();                    
                    if (drCurrent["Stt"].ToString() != string.Empty)
                    {
                        bAcceptShowDialog = PrintVoucher.PrintIN_Crytal(drCurrent["Stt"].ToString(), rptFileName, bPreview, true, PrinterName);
                        //if (i == 0)
                        //{
                        //    bAcceptShowDialog = PrintVoucher.PrintIN_Crytal(drCurrent["Stt"].ToString(),rptFileName, bPreview,true, PrinterName);
                        //}
                        //else
                        //{
                        //    if (bAcceptShowDialog)
                        //        bAcceptShowDialog = PrintVoucher.PrintIN_Crytal(drCurrent["Stt"].ToString(), rptFileName, bPreview,false, PrinterName);
                        //    else
                        //        break;
                        //}
                        //i++;
                    }
                }
            }

        }

        #region DocTien
        public string ReadMoneyC(Double SoTien)
        {
            string[] strSo = { " 零 ", " 壹 ", " 貳 ", " 叁 ", " 肆 ", " 伍 ", " 陆 ", " 柒 ", 
                                    " 捌 ", " 玖 " };

            string strKq = string.Empty;

            if (SoTien == 0)
                return " 零 ";

            if (SoTien == 10)
                return " 拾 ";

            long SoTien0 = Convert.ToInt64(Math.Truncate(SoTien));
            long SoTien00 = SoTien0;

            for (int i = 3; i >= 0; i--)
            {
                long ivalue = Convert.ToInt64(Math.Truncate(SoTien0 / Math.Pow(10, 3 * i)));
                SoTien0 = SoTien0 - Convert.ToInt64(ivalue * Math.Pow(10, 3 * i));

                if (ivalue > 0)
                {
                    int iDonvi = Convert.ToInt32(ivalue % 10);
                    int iChuc = Convert.ToInt32(ivalue % 100 - iDonvi);
                    int iTram = Convert.ToInt32(ivalue % 1000 - iChuc);

                    iChuc = iChuc / 10;
                    iTram = iTram / 100;

                    for (int j = 2; j >= 0; j--)
                    {
                        if (j == 2) //Hang tram
                        {
                            if (iTram == 0 && strKq == string.Empty)
                                continue;

                            if (i == 3) // ty
                                strKq += strSo[iTram] + " 佰 ";
                            else
                                if (i == 2) // tram trieu
                                    strKq += strSo[iTram] + " 億 ";
                                else
                                    if (i == 1) // tram ngan
                                        strKq += strSo[iTram] + " 拾 萬 ";
                                    else
                                        strKq += strSo[iTram] + " 佰 ";
                        }
                        else if (j == 1) //Hang chuc
                        {
                            if (iChuc == 0)
                                continue;

                            if (i == 3) // ty
                                strKq += strSo[iChuc] + " 拾 ";
                            else
                                if (i == 2) // chuc trieu
                                    strKq += strSo[iChuc] + " 仟 萬 ";
                                else
                                    if (i == 1) // chuc ngan
                                        strKq += strSo[iChuc] + " 萬 ";
                                    else
                                        if (SoTien00 < 20)
                                            strKq += " 拾 ";
                                        else
                                            strKq += strSo[iChuc] + " 拾 ";
                        }
                        else if (j == 0) //Hang dv
                        {
                            if (iDonvi == 0)
                                continue;

                            if (iChuc == 0)
                            {
                                if (strKq != string.Empty)
                                    strKq += " 零 ";
                            }

                            if (i == 3) // ty
                                strKq += strSo[iDonvi] + " 拾 億 ";
                            else
                                if (i == 2) // trieu
                                    strKq += strSo[iDonvi] + " 佰 萬 ";
                                else
                                    if (i == 1) // ngan
                                        strKq += strSo[iDonvi] + " 仟 ";
                                    else
                                        strKq += strSo[iDonvi];
                        }
                    }
                }
            }
            strKq = strKq.Replace("  ", " ").Trim();
            strKq = strKq.Substring(0, 1) + strKq.Substring(1);

            string str0 = string.Empty;
            string str1 = string.Empty;

            // rut gon nhieu chu 萬 thanh 1 chu
            for (int j = strKq.Length - 1; j >= 0; j--)
            {
                if (strKq[j].ToString() == "萬")
                {
                    str0 = strKq.Substring(j, strKq.Length - j);
                    str1 = strKq.Substring(0, j);

                    break;
                }
            }
            str1 = str1.Replace("萬 ", "");
            strKq = str1 + str0;

            // rut gon nhieu chu 億 thanh 1 chu
            for (int j = strKq.Length - 1; j >= 0; j--)
            {
                if (strKq[j].ToString() == "億")
                {
                    str0 = strKq.Substring(j, strKq.Length - j);
                    str1 = strKq.Substring(0, j);

                    break;
                }
            }
            str1 = str1.Replace("億 ", "");
            strKq = str1 + str0;

            return strKq + " 元 整 ";
        }
        #endregion
	}
}
