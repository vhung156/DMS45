namespace Epoint.Modules.IN
{
    partial class frmPKiemKe_View
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPKiemKe_View));
            this.tabDiscCountDetail = new Epoint.Systems.Controls.tabControl();
            this.tpCtDiscount = new System.Windows.Forms.TabPage();
            this.dgvKKDetail = new Epoint.Systems.Controls.dgvControl();
            this.dgvKK_PH = new Epoint.Systems.Controls.dgvGridControl();
            this.tabEmployee = new System.Windows.Forms.TabControl();
            this.pageDiscountProg = new System.Windows.Forms.TabPage();
            this.pnFillter = new System.Windows.Forms.Panel();
            this.txtMau_In = new Epoint.Systems.Controls.txtEnum();
            this.txtMa_KhoKK = new Epoint.Systems.Controls.txtTextLookup();
            this.lblSo_Ct1 = new Epoint.Systems.Controls.lblControl();
            this.btPrintReport = new Epoint.Systems.Customizes.btPreview();
            this.btPrint000 = new Epoint.Systems.Customizes.btPreview();
            this.btFillterData = new Epoint.Systems.Customizes.btPreview();
            this.dteNgay_Ct2 = new Epoint.Systems.Controls.dteDateTime();
            this.lblNgay_Ct2 = new Epoint.Systems.Controls.lblControl();
            this.dteNgay_Ct1 = new Epoint.Systems.Controls.dteDateTime();
            this.lblNgay_Ct1 = new Epoint.Systems.Controls.lblControl();
            this.pnPXK = new System.Windows.Forms.Panel();
            this.cbxReport_List = new Epoint.Systems.Controls.cboControl();
            this.tabDiscCountDetail.SuspendLayout();
            this.tpCtDiscount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKKDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKK_PH)).BeginInit();
            this.tabEmployee.SuspendLayout();
            this.pageDiscountProg.SuspendLayout();
            this.pnFillter.SuspendLayout();
            this.pnPXK.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDiscCountDetail
            // 
            this.tabDiscCountDetail.Controls.Add(this.tpCtDiscount);
            this.tabDiscCountDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabDiscCountDetail.Location = new System.Drawing.Point(0, 332);
            this.tabDiscCountDetail.Name = "tabDiscCountDetail";
            this.tabDiscCountDetail.SelectedIndex = 0;
            this.tabDiscCountDetail.Size = new System.Drawing.Size(990, 234);
            this.tabDiscCountDetail.TabIndex = 2;
            // 
            // tpCtDiscount
            // 
            this.tpCtDiscount.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tpCtDiscount.Controls.Add(this.dgvKKDetail);
            this.tpCtDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpCtDiscount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpCtDiscount.Location = new System.Drawing.Point(4, 22);
            this.tpCtDiscount.Name = "tpCtDiscount";
            this.tpCtDiscount.Padding = new System.Windows.Forms.Padding(3);
            this.tpCtDiscount.Size = new System.Drawing.Size(982, 208);
            this.tpCtDiscount.TabIndex = 0;
            this.tpCtDiscount.Tag = "";
            this.tpCtDiscount.Text = "Chi tiết kiểm kê";
            this.tpCtDiscount.UseVisualStyleBackColor = true;
            // 
            // dgvKKDetail
            // 
            this.dgvKKDetail.AllowUserToAddRows = false;
            this.dgvKKDetail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvKKDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKKDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvKKDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKKDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKKDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKKDetail.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKKDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKKDetail.EnableHeadersVisualStyles = false;
            this.dgvKKDetail.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvKKDetail.Location = new System.Drawing.Point(3, 3);
            this.dgvKKDetail.MultiSelect = false;
            this.dgvKKDetail.Name = "dgvKKDetail";
            this.dgvKKDetail.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKKDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvKKDetail.Size = new System.Drawing.Size(976, 202);
            this.dgvKKDetail.strZone = "";
            this.dgvKKDetail.TabIndex = 0;
            // 
            // dgvKK_PH
            // 
            this.dgvKK_PH.AllowEdit = false;
            this.dgvKK_PH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKK_PH.Location = new System.Drawing.Point(0, 0);
            this.dgvKK_PH.Name = "dgvPXK";
            this.dgvKK_PH.Size = new System.Drawing.Size(976, 244);
            this.dgvKK_PH.strZone = "";
            this.dgvKK_PH.TabIndex = 4;
            // 
            // tabEmployee
            // 
            this.tabEmployee.Controls.Add(this.pageDiscountProg);
            this.tabEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEmployee.Location = new System.Drawing.Point(0, 0);
            this.tabEmployee.Name = "tabEmployee";
            this.tabEmployee.SelectedIndex = 0;
            this.tabEmployee.Size = new System.Drawing.Size(990, 332);
            this.tabEmployee.TabIndex = 5;
            // 
            // pageDiscountProg
            // 
            this.pageDiscountProg.Controls.Add(this.pnFillter);
            this.pageDiscountProg.Controls.Add(this.pnPXK);
            this.pageDiscountProg.Location = new System.Drawing.Point(4, 22);
            this.pageDiscountProg.Name = "pageDiscountProg";
            this.pageDiscountProg.Padding = new System.Windows.Forms.Padding(3);
            this.pageDiscountProg.Size = new System.Drawing.Size(982, 306);
            this.pageDiscountProg.TabIndex = 0;
            this.pageDiscountProg.Text = "Danh sách phiếu kiểm kê";
            this.pageDiscountProg.UseVisualStyleBackColor = true;
            // 
            // pnFillter
            // 
            this.pnFillter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnFillter.Controls.Add(this.cbxReport_List);
            this.pnFillter.Controls.Add(this.txtMau_In);
            this.pnFillter.Controls.Add(this.txtMa_KhoKK);
            this.pnFillter.Controls.Add(this.lblSo_Ct1);
            this.pnFillter.Controls.Add(this.btPrintReport);
            this.pnFillter.Controls.Add(this.btPrint000);
            this.pnFillter.Controls.Add(this.btFillterData);
            this.pnFillter.Controls.Add(this.dteNgay_Ct2);
            this.pnFillter.Controls.Add(this.lblNgay_Ct2);
            this.pnFillter.Controls.Add(this.dteNgay_Ct1);
            this.pnFillter.Controls.Add(this.lblNgay_Ct1);
            this.pnFillter.Location = new System.Drawing.Point(3, 3);
            this.pnFillter.Name = "pnFillter";
            this.pnFillter.Size = new System.Drawing.Size(976, 56);
            this.pnFillter.TabIndex = 6;
            // 
            // txtMau_In
            // 
            this.txtMau_In.bEnabled = true;
            this.txtMau_In.bIsLookup = false;
            this.txtMau_In.bReadOnly = false;
            this.txtMau_In.bRequire = false;
            this.txtMau_In.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMau_In.InputMask = "rptPXK,rptPXKList";
            this.txtMau_In.KeyFilter = "";
            this.txtMau_In.Location = new System.Drawing.Point(261, 34);
            this.txtMau_In.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMau_In.Name = "txtMau_In";
            this.txtMau_In.Size = new System.Drawing.Size(104, 20);
            this.txtMau_In.TabIndex = 156;
            this.txtMau_In.UseAutoFilter = false;
            this.txtMau_In.Visible = false;
            // 
            // txtMa_KhoKK
            // 
            this.txtMa_KhoKK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMa_KhoKK.bEnabled = true;
            this.txtMa_KhoKK.bIsLookup = false;
            this.txtMa_KhoKK.bReadOnly = false;
            this.txtMa_KhoKK.bRequire = false;
            this.txtMa_KhoKK.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_KhoKK.ColumnsView = null;
            this.txtMa_KhoKK.CtrlDepend = null;
            this.txtMa_KhoKK.KeyFilter = "Ma_Kho";
            this.txtMa_KhoKK.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtMa_KhoKK.ListFilter = new string[0];
            this.txtMa_KhoKK.Location = new System.Drawing.Point(84, 34);
            this.txtMa_KhoKK.LookupKeyFilter = "";
            this.txtMa_KhoKK.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_KhoKK.Name = "txtMa_KhoKK";
            this.txtMa_KhoKK.Size = new System.Drawing.Size(104, 20);
            this.txtMa_KhoKK.TabIndex = 155;
            this.txtMa_KhoKK.UseAutoFilter = true;
            // 
            // lblSo_Ct1
            // 
            this.lblSo_Ct1.AutoEllipsis = true;
            this.lblSo_Ct1.AutoSize = true;
            this.lblSo_Ct1.BackColor = System.Drawing.Color.Transparent;
            this.lblSo_Ct1.Location = new System.Drawing.Point(5, 35);
            this.lblSo_Ct1.Name = "lblSo_Ct1";
            this.lblSo_Ct1.Size = new System.Drawing.Size(47, 13);
            this.lblSo_Ct1.TabIndex = 95;
            this.lblSo_Ct1.Tag = "Ma_Kho";
            this.lblSo_Ct1.Text = "Ma_Kho";
            this.lblSo_Ct1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btPrintReport
            // 
            this.btPrintReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrintReport.Image = ((System.Drawing.Image)(resources.GetObject("btPrintReport.Image")));
            this.btPrintReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrintReport.Location = new System.Drawing.Point(603, 25);
            this.btPrintReport.Name = "btPrintReport";
            this.btPrintReport.Size = new System.Drawing.Size(223, 32);
            this.btPrintReport.TabIndex = 5;
            this.btPrintReport.Tag = "";
            this.btPrintReport.Text = "Xem Báo cáo";
            this.btPrintReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPrintReport.UseVisualStyleBackColor = true;
            // 
            // btPrint000
            // 
            this.btPrint000.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrint000.Image = ((System.Drawing.Image)(resources.GetObject("btPrint000.Image")));
            this.btPrint000.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrint000.Location = new System.Drawing.Point(831, 25);
            this.btPrint000.Name = "btPrint000";
            this.btPrint000.Size = new System.Drawing.Size(125, 31);
            this.btPrint000.TabIndex = 4;
            this.btPrint000.Tag = "";
            this.btPrint000.Text = "Xem PXK Tổng";
            this.btPrint000.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPrint000.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPrint000.UseVisualStyleBackColor = true;
            this.btPrint000.Visible = false;
            // 
            // btFillterData
            // 
            this.btFillterData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFillterData.Image = ((System.Drawing.Image)(resources.GetObject("btFillterData.Image")));
            this.btFillterData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFillterData.Location = new System.Drawing.Point(380, 5);
            this.btFillterData.Name = "btFillterData";
            this.btFillterData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btFillterData.Size = new System.Drawing.Size(121, 49);
            this.btFillterData.TabIndex = 3;
            this.btFillterData.Tag = "Preview";
            this.btFillterData.Text = "Lọc dữ liệu";
            this.btFillterData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFillterData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btFillterData.UseVisualStyleBackColor = true;
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.bAllowEmpty = true;
            this.dteNgay_Ct2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dteNgay_Ct2.bRequire = false;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.Culture = new System.Globalization.CultureInfo("en-US");
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(261, 9);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.SelectedText = "";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(106, 22);
            this.dteNgay_Ct2.TabIndex = 1;
            // 
            // lblNgay_Ct2
            // 
            this.lblNgay_Ct2.AutoEllipsis = true;
            this.lblNgay_Ct2.AutoSize = true;
            this.lblNgay_Ct2.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay_Ct2.Location = new System.Drawing.Point(203, 15);
            this.lblNgay_Ct2.Name = "lblNgay_Ct2";
            this.lblNgay_Ct2.Size = new System.Drawing.Size(53, 13);
            this.lblNgay_Ct2.TabIndex = 92;
            this.lblNgay_Ct2.Tag = "Ngay_Ct2";
            this.lblNgay_Ct2.Text = "Đến ngày";
            this.lblNgay_Ct2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.bAllowEmpty = true;
            this.dteNgay_Ct1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dteNgay_Ct1.bRequire = false;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("en-US");
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(84, 11);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.SelectedText = "";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(104, 19);
            this.dteNgay_Ct1.TabIndex = 0;
            // 
            // lblNgay_Ct1
            // 
            this.lblNgay_Ct1.AutoEllipsis = true;
            this.lblNgay_Ct1.AutoSize = true;
            this.lblNgay_Ct1.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay_Ct1.Location = new System.Drawing.Point(5, 11);
            this.lblNgay_Ct1.Name = "lblNgay_Ct1";
            this.lblNgay_Ct1.Size = new System.Drawing.Size(46, 13);
            this.lblNgay_Ct1.TabIndex = 91;
            this.lblNgay_Ct1.Tag = "Ngay_Ct1";
            this.lblNgay_Ct1.Text = "Từ ngày";
            this.lblNgay_Ct1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnPXK
            // 
            this.pnPXK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnPXK.Controls.Add(this.dgvKK_PH);
            this.pnPXK.Location = new System.Drawing.Point(3, 60);
            this.pnPXK.Name = "pnPXK";
            this.pnPXK.Size = new System.Drawing.Size(976, 244);
            this.pnPXK.TabIndex = 5;
            // 
            // cbxReport_List
            // 
            this.cbxReport_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxReport_List.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxReport_List.FormattingEnabled = true;
            this.cbxReport_List.InitValue = null;
            this.cbxReport_List.Location = new System.Drawing.Point(603, 0);
            this.cbxReport_List.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cbxReport_List.Name = "cbxReport_List";
            this.cbxReport_List.Size = new System.Drawing.Size(223, 21);
            this.cbxReport_List.strValueList = null;
            this.cbxReport_List.TabIndex = 157;
            this.cbxReport_List.UpperCase = false;
            this.cbxReport_List.UseAutoComplete = false;
            this.cbxReport_List.UseBindingValue = false;
            // 
            // frmPKiemKe_View
            // 
            this.AcceptButton = this.btFillterData;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 566);
            this.Controls.Add(this.tabEmployee);
            this.Controls.Add(this.tabDiscCountDetail);
            this.Name = "frmPKiemKe_View";
            this.Text = "frmDiscount";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabDiscCountDetail.ResumeLayout(false);
            this.tpCtDiscount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKKDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKK_PH)).EndInit();
            this.tabEmployee.ResumeLayout(false);
            this.pageDiscountProg.ResumeLayout(false);
            this.pnFillter.ResumeLayout(false);
            this.pnFillter.PerformLayout();
            this.pnPXK.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Systems.Controls.tabControl tabDiscCountDetail;
        private System.Windows.Forms.TabPage tpCtDiscount;
        private Systems.Controls.dgvControl dgvKKDetail;
        private Systems.Controls.dgvGridControl dgvKK_PH;
        private System.Windows.Forms.TabControl tabEmployee;
        private System.Windows.Forms.TabPage pageDiscountProg;
        private System.Windows.Forms.Panel pnFillter;
        private System.Windows.Forms.Panel pnPXK;
        private Systems.Controls.dteDateTime dteNgay_Ct2;
        private Systems.Controls.lblControl lblNgay_Ct2;
        private Systems.Controls.dteDateTime dteNgay_Ct1;
        private Systems.Controls.lblControl lblNgay_Ct1;
        private Systems.Customizes.btPreview btPrint000;
        private Systems.Customizes.btPreview btFillterData;
        private Systems.Controls.lblControl lblSo_Ct1;
        private Systems.Customizes.btPreview btPrintReport;
        private Systems.Controls.txtTextLookup txtMa_KhoKK;
        private Systems.Controls.txtEnum txtMau_In;
        private Systems.Controls.cboControl cbxReport_List;
    }
}