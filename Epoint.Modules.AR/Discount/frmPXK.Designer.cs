namespace Epoint.Modules.AR
{
    partial class frmPXK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPXK));
            this.tabDiscCountDetail = new Epoint.Systems.Controls.tabControl();
            this.tpCtDiscount = new System.Windows.Forms.TabPage();
            this.dgvPXDetail = new Epoint.Systems.Controls.dgvControl();
            this.dgvPXK = new Epoint.Systems.Controls.dgvGridControl();
            this.tabEmployee = new System.Windows.Forms.TabControl();
            this.pageDiscountProg = new System.Windows.Forms.TabPage();
            this.pnFillter = new System.Windows.Forms.Panel();
            this.cboMa_Ct = new Epoint.Systems.Controls.cboControl();
            this.cbxReport_List = new Epoint.Systems.Controls.cboControl();
            this.txtMau_In = new Epoint.Systems.Controls.txtEnum();
            this.txtSo_Ct = new Epoint.Systems.Controls.txtTextBox();
            this.lblSo_Ct1 = new Epoint.Systems.Controls.lblControl();
            this.btPrintReport = new Epoint.Systems.Customizes.btPreview();
            this.btPrint000 = new Epoint.Systems.Customizes.btPreview();
            this.btFillterData = new Epoint.Systems.Customizes.btPreview();
            this.dteNgay_Ct2 = new Epoint.Systems.Controls.dteDateTime();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.lblNgay_Ct2 = new Epoint.Systems.Controls.lblControl();
            this.dteNgay_Ct1 = new Epoint.Systems.Controls.dteDateTime();
            this.lblNgay_Ct1 = new Epoint.Systems.Controls.lblControl();
            this.pnPXK = new System.Windows.Forms.Panel();
            this.tabDiscCountDetail.SuspendLayout();
            this.tpCtDiscount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPXDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPXK)).BeginInit();
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
            this.tpCtDiscount.Controls.Add(this.dgvPXDetail);
            this.tpCtDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpCtDiscount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpCtDiscount.Location = new System.Drawing.Point(4, 22);
            this.tpCtDiscount.Name = "tpCtDiscount";
            this.tpCtDiscount.Padding = new System.Windows.Forms.Padding(3);
            this.tpCtDiscount.Size = new System.Drawing.Size(982, 208);
            this.tpCtDiscount.TabIndex = 0;
            this.tpCtDiscount.Tag = "";
            this.tpCtDiscount.Text = "Chi tiết phiếu xuất";
            this.tpCtDiscount.UseVisualStyleBackColor = true;
            // 
            // dgvPXDetail
            // 
            this.dgvPXDetail.AllowUserToAddRows = false;
            this.dgvPXDetail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPXDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPXDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvPXDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPXDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPXDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPXDetail.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPXDetail.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvPXDetail.EnableHeadersVisualStyles = false;
            this.dgvPXDetail.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvPXDetail.Location = new System.Drawing.Point(3, 3);
            this.dgvPXDetail.MultiSelect = false;
            this.dgvPXDetail.Name = "dgvPXDetail";
            this.dgvPXDetail.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPXDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPXDetail.Size = new System.Drawing.Size(976, 202);
            this.dgvPXDetail.strZone = "";
            this.dgvPXDetail.TabIndex = 0;
            // 
            // dgvPXK
            // 
            this.dgvPXK.AllowEdit = false;
            this.dgvPXK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPXK.Location = new System.Drawing.Point(0, 0);
            this.dgvPXK.Name = "dgvPXK";
            this.dgvPXK.Size = new System.Drawing.Size(976, 244);
            this.dgvPXK.strZone = "";
            this.dgvPXK.TabIndex = 4;
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
            this.pageDiscountProg.Text = "Danh sách phiếu xuất kho";
            this.pageDiscountProg.UseVisualStyleBackColor = true;
            // 
            // pnFillter
            // 
            this.pnFillter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnFillter.Controls.Add(this.cboMa_Ct);
            this.pnFillter.Controls.Add(this.cbxReport_List);
            this.pnFillter.Controls.Add(this.txtMau_In);
            this.pnFillter.Controls.Add(this.txtSo_Ct);
            this.pnFillter.Controls.Add(this.lblSo_Ct1);
            this.pnFillter.Controls.Add(this.btPrintReport);
            this.pnFillter.Controls.Add(this.btPrint000);
            this.pnFillter.Controls.Add(this.btFillterData);
            this.pnFillter.Controls.Add(this.dteNgay_Ct2);
            this.pnFillter.Controls.Add(this.lblControl1);
            this.pnFillter.Controls.Add(this.lblNgay_Ct2);
            this.pnFillter.Controls.Add(this.dteNgay_Ct1);
            this.pnFillter.Controls.Add(this.lblNgay_Ct1);
            this.pnFillter.Location = new System.Drawing.Point(3, 3);
            this.pnFillter.Name = "pnFillter";
            this.pnFillter.Size = new System.Drawing.Size(976, 56);
            this.pnFillter.TabIndex = 6;
            // 
            // cboMa_Ct
            // 
            this.cboMa_Ct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMa_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMa_Ct.FormattingEnabled = true;
            this.cboMa_Ct.InitValue = null;
            this.cboMa_Ct.Location = new System.Drawing.Point(260, 31);
            this.cboMa_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboMa_Ct.Name = "cboMa_Ct";
            this.cboMa_Ct.Size = new System.Drawing.Size(107, 21);
            this.cboMa_Ct.strValueList = null;
            this.cboMa_Ct.TabIndex = 96;
            this.cboMa_Ct.UpperCase = false;
            this.cboMa_Ct.UseAutoComplete = false;
            this.cboMa_Ct.UseBindingValue = false;
            // 
            // cbxReport_List
            // 
            this.cbxReport_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxReport_List.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxReport_List.FormattingEnabled = true;
            this.cbxReport_List.InitValue = null;
            this.cbxReport_List.Location = new System.Drawing.Point(603, 3);
            this.cbxReport_List.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cbxReport_List.Name = "cbxReport_List";
            this.cbxReport_List.Size = new System.Drawing.Size(223, 21);
            this.cbxReport_List.strValueList = null;
            this.cbxReport_List.TabIndex = 96;
            this.cbxReport_List.UpperCase = false;
            this.cbxReport_List.UseAutoComplete = false;
            this.cbxReport_List.UseBindingValue = false;
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
            this.txtMau_In.Location = new System.Drawing.Point(84, 32);
            this.txtMau_In.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMau_In.Name = "txtMau_In";
            this.txtMau_In.Size = new System.Drawing.Size(104, 20);
            this.txtMau_In.TabIndex = 6;
            this.txtMau_In.UseAutoFilter = false;
            this.txtMau_In.Visible = false;
            // 
            // txtSo_Ct
            // 
            this.txtSo_Ct.bEnabled = true;
            this.txtSo_Ct.bIsLookup = false;
            this.txtSo_Ct.bReadOnly = false;
            this.txtSo_Ct.bRequire = false;
            this.txtSo_Ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSo_Ct.KeyFilter = "";
            this.txtSo_Ct.Location = new System.Drawing.Point(84, 33);
            this.txtSo_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Ct.MaxLength = 20;
            this.txtSo_Ct.Name = "txtSo_Ct";
            this.txtSo_Ct.Size = new System.Drawing.Size(104, 20);
            this.txtSo_Ct.TabIndex = 2;
            this.txtSo_Ct.UseAutoFilter = false;
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
            this.lblSo_Ct1.Tag = "So_Ct";
            this.lblSo_Ct1.Text = "Từ số Ct";
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
            this.btPrint000.Location = new System.Drawing.Point(831, 9);
            this.btPrint000.Name = "btPrint000";
            this.btPrint000.Size = new System.Drawing.Size(125, 47);
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
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(203, 36);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(27, 13);
            this.lblControl1.TabIndex = 92;
            this.lblControl1.Tag = "";
            this.lblControl1.Text = "Loại";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.pnPXK.Controls.Add(this.dgvPXK);
            this.pnPXK.Location = new System.Drawing.Point(3, 60);
            this.pnPXK.Name = "pnPXK";
            this.pnPXK.Size = new System.Drawing.Size(976, 244);
            this.pnPXK.TabIndex = 5;
            // 
            // frmPXK
            // 
            this.AcceptButton = this.btFillterData;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 566);
            this.Controls.Add(this.tabEmployee);
            this.Controls.Add(this.tabDiscCountDetail);
            this.Name = "frmPXK";
            this.Text = "frmDiscount";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabDiscCountDetail.ResumeLayout(false);
            this.tpCtDiscount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPXDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPXK)).EndInit();
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
        private Systems.Controls.dgvControl dgvPXDetail;
        private Systems.Controls.dgvGridControl dgvPXK;
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
        private Systems.Controls.txtTextBox txtSo_Ct;
        private Systems.Controls.lblControl lblSo_Ct1;
        private Systems.Customizes.btPreview btPrintReport;
        private Systems.Controls.txtEnum txtMau_In;
        private Systems.Controls.cboControl cbxReport_List;
        private Systems.Controls.cboControl cboMa_Ct;
        private Systems.Controls.lblControl lblControl1;
	}
}