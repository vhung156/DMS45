namespace Epoint.Modules.AR
{
    partial class frmPromotionBudget
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPromotionBudget));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btFillterData = new Epoint.Systems.Customizes.btPreview();
            this.lbGia = new Epoint.Systems.Controls.lblControl();
            this.dteNgay_Kt = new Epoint.Systems.Controls.txtDateTime();
            this.dteNgay_BD = new Epoint.Systems.Controls.txtDateTime();
            this.lbNgay_Ap = new Epoint.Systems.Controls.lblControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvBudget = new Epoint.Systems.Controls.dgvControl();
            this.dgvBudgetDetail = new Epoint.Systems.Controls.dgvGridControl();
            this.btPJPDetail = new Epoint.Systems.Customizes.btPreview();
            this.btImport = new Epoint.Systems.Customizes.btFilter();
            this.btAddCust = new Epoint.Systems.Customizes.btPreview();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBudgetDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // btFillterData
            // 
            this.btFillterData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFillterData.Image = ((System.Drawing.Image)(resources.GetObject("btFillterData.Image")));
            this.btFillterData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFillterData.Location = new System.Drawing.Point(542, 3);
            this.btFillterData.Name = "btFillterData";
            this.btFillterData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btFillterData.Size = new System.Drawing.Size(121, 27);
            this.btFillterData.TabIndex = 72;
            this.btFillterData.Tag = "Preview";
            this.btFillterData.Text = "Lọc dữ liệu";
            this.btFillterData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFillterData.UseVisualStyleBackColor = true;
            // 
            // lbGia
            // 
            this.lbGia.AutoEllipsis = true;
            this.lbGia.AutoSize = true;
            this.lbGia.BackColor = System.Drawing.Color.Transparent;
            this.lbGia.Location = new System.Drawing.Point(275, 6);
            this.lbGia.Name = "lbGia";
            this.lbGia.Size = new System.Drawing.Size(74, 13);
            this.lbGia.TabIndex = 71;
            this.lbGia.Tag = "Ngay_Kt";
            this.lbGia.Text = "Ngày kết thúc";
            this.lbGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Kt
            // 
            this.dteNgay_Kt.bAllowEmpty = true;
            this.dteNgay_Kt.bRequire = false;
            this.dteNgay_Kt.bSelectOnFocus = false;
            this.dteNgay_Kt.bShowDateTimePicker = true;
            this.dteNgay_Kt.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Kt.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Kt.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Kt.Location = new System.Drawing.Point(380, 3);
            this.dteNgay_Kt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Kt.Mask = "00/00/0000";
            this.dteNgay_Kt.Name = "dteNgay_Kt";
            this.dteNgay_Kt.Size = new System.Drawing.Size(111, 20);
            this.dteNgay_Kt.TabIndex = 69;
            // 
            // dteNgay_BD
            // 
            this.dteNgay_BD.bAllowEmpty = true;
            this.dteNgay_BD.bRequire = false;
            this.dteNgay_BD.bSelectOnFocus = false;
            this.dteNgay_BD.bShowDateTimePicker = true;
            this.dteNgay_BD.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_BD.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_BD.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_BD.Location = new System.Drawing.Point(132, 4);
            this.dteNgay_BD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_BD.Mask = "00/00/0000";
            this.dteNgay_BD.Name = "dteNgay_BD";
            this.dteNgay_BD.Size = new System.Drawing.Size(111, 20);
            this.dteNgay_BD.TabIndex = 68;
            // 
            // lbNgay_Ap
            // 
            this.lbNgay_Ap.AutoEllipsis = true;
            this.lbNgay_Ap.AutoSize = true;
            this.lbNgay_Ap.BackColor = System.Drawing.Color.Transparent;
            this.lbNgay_Ap.Location = new System.Drawing.Point(29, 7);
            this.lbNgay_Ap.Name = "lbNgay_Ap";
            this.lbNgay_Ap.Size = new System.Drawing.Size(72, 13);
            this.lbNgay_Ap.TabIndex = 70;
            this.lbNgay_Ap.Tag = "Ngay_BD";
            this.lbNgay_Ap.Text = "Ngày bắt đầu";
            this.lbNgay_Ap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(7, 71);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvBudget);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvBudgetDetail);
            this.splitContainer1.Size = new System.Drawing.Size(1053, 621);
            this.splitContainer1.SplitterDistance = 257;
            this.splitContainer1.TabIndex = 75;
            // 
            // dgvBudget
            // 
            this.dgvBudget.AllowUserToAddRows = false;
            this.dgvBudget.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvBudget.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBudget.BackgroundColor = System.Drawing.Color.White;
            this.dgvBudget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBudget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBudget.EnableHeadersVisualStyles = false;
            this.dgvBudget.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvBudget.Location = new System.Drawing.Point(0, 0);
            this.dgvBudget.MultiSelect = false;
            this.dgvBudget.Name = "dgvBudget";
            this.dgvBudget.ReadOnly = true;
            this.dgvBudget.Size = new System.Drawing.Size(1053, 257);
            this.dgvBudget.strZone = "";
            this.dgvBudget.TabIndex = 4;
            // 
            // dgvBudgetDetail
            // 
            this.dgvBudgetDetail.AllowEdit = false;
            this.dgvBudgetDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBudgetDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvBudgetDetail.Name = "dgvPJPDetail";
            this.dgvBudgetDetail.Size = new System.Drawing.Size(1053, 360);
            this.dgvBudgetDetail.strZone = "";
            this.dgvBudgetDetail.TabIndex = 4;
            // 
            // btPJPDetail
            // 
            this.btPJPDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPJPDetail.Image = ((System.Drawing.Image)(resources.GetObject("btPJPDetail.Image")));
            this.btPJPDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPJPDetail.Location = new System.Drawing.Point(838, 0);
            this.btPJPDetail.Name = "btPJPDetail";
            this.btPJPDetail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btPJPDetail.Size = new System.Drawing.Size(103, 27);
            this.btPJPDetail.TabIndex = 72;
            this.btPJPDetail.Tag = "";
            this.btPJPDetail.Text = "Lịch chi tiết";
            this.btPJPDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPJPDetail.UseVisualStyleBackColor = true;
            this.btPJPDetail.Visible = false;
            // 
            // btImport
            // 
            this.btImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImport.Image = ((System.Drawing.Image)(resources.GetObject("btImport.Image")));
            this.btImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btImport.Location = new System.Drawing.Point(947, 0);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(113, 27);
            this.btImport.TabIndex = 77;
            this.btImport.Tag = "";
            this.btImport.Text = "&Import";
            this.btImport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btImport.UseVisualStyleBackColor = true;
            this.btImport.Visible = false;
            // 
            // btAddCust
            // 
            this.btAddCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddCust.Image = ((System.Drawing.Image)(resources.GetObject("btAddCust.Image")));
            this.btAddCust.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAddCust.Location = new System.Drawing.Point(945, 38);
            this.btAddCust.Name = "btAddCust";
            this.btAddCust.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btAddCust.Size = new System.Drawing.Size(115, 27);
            this.btAddCust.TabIndex = 78;
            this.btAddCust.Tag = "Add";
            this.btAddCust.Text = "Thêm";
            this.btAddCust.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAddCust.UseVisualStyleBackColor = true;
            // 
            // frmPromotionBudget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 734);
            this.Controls.Add(this.btAddCust);
            this.Controls.Add(this.btImport);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btPJPDetail);
            this.Controls.Add(this.btFillterData);
            this.Controls.Add(this.lbNgay_Ap);
            this.Controls.Add(this.dteNgay_BD);
            this.Controls.Add(this.dteNgay_Kt);
            this.Controls.Add(this.lbGia);
            this.Name = "frmPromotionBudget";
            this.Text = "frmPromotionBudget";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBudgetDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Systems.Controls.lblControl lbGia;
        private Systems.Controls.txtDateTime dteNgay_Kt;
        private Systems.Controls.txtDateTime dteNgay_BD;
        private Systems.Controls.lblControl lbNgay_Ap;
        private Systems.Customizes.btPreview btFillterData;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Systems.Controls.dgvControl dgvBudget;
        private Systems.Controls.dgvGridControl dgvBudgetDetail;
        private Systems.Customizes.btPreview btPJPDetail;
        protected Systems.Customizes.btFilter btImport;
        private Systems.Customizes.btPreview btAddCust;
    }
}