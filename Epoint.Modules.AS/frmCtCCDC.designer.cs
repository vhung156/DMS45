namespace Epoint.Modules.AS
{
	partial class frmCtCCDC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCtCCDC));
            this.dgvCtCCDC = new Epoint.Systems.Controls.dgvControl();
            this.tabControl1 = new Epoint.Systems.Controls.tabControl();
            this.tpCtCCDCNGia = new System.Windows.Forms.TabPage();
            this.dgvCtCCDCNGia = new Epoint.Systems.Controls.dgvControl();
            this.tpCtCCDCHMon = new System.Windows.Forms.TabPage();
            this.dgvCtCCDCHMon = new Epoint.Systems.Controls.dgvControl();
            this.tpCtCCDCStatus = new System.Windows.Forms.TabPage();
            this.dgvCtCCDCStatus = new Epoint.Systems.Controls.dgvControl();
            this.pnlControl1 = new Epoint.Systems.Controls.pnlControl();
            this.btRefresh = new Epoint.Systems.Customizes.btDelete();
            this.btEdit = new Epoint.Systems.Customizes.btEdit();
            this.btDelete = new Epoint.Systems.Customizes.btDelete();
            this.btNew = new Epoint.Systems.Customizes.btNew();
            this.linkHelp = new System.Windows.Forms.LinkLabel();
            this.btImport = new Epoint.Systems.Customizes.btDelete();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtCCDC)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpCtCCDCNGia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtCCDCNGia)).BeginInit();
            this.tpCtCCDCHMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtCCDCHMon)).BeginInit();
            this.tpCtCCDCStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtCCDCStatus)).BeginInit();
            this.pnlControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCtCCDC
            // 
            this.dgvCtCCDC.AllowUserToAddRows = false;
            this.dgvCtCCDC.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCtCCDC.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCtCCDC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCtCCDC.BackgroundColor = System.Drawing.Color.White;
            this.dgvCtCCDC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCtCCDC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCtCCDC.EnableHeadersVisualStyles = false;
            this.dgvCtCCDC.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvCtCCDC.Location = new System.Drawing.Point(6, 6);
            this.dgvCtCCDC.MultiSelect = false;
            this.dgvCtCCDC.Name = "dgvCtCCDC";
            this.dgvCtCCDC.ReadOnly = true;
            this.dgvCtCCDC.Size = new System.Drawing.Size(795, 242);
            this.dgvCtCCDC.strZone = "";
            this.dgvCtCCDC.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpCtCCDCNGia);
            this.tabControl1.Controls.Add(this.tpCtCCDCHMon);
            this.tabControl1.Controls.Add(this.tpCtCCDCStatus);
            this.tabControl1.Location = new System.Drawing.Point(6, 254);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(795, 266);
            this.tabControl1.TabIndex = 1;
            // 
            // tpCtCCDCNGia
            // 
            this.tpCtCCDCNGia.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tpCtCCDCNGia.Controls.Add(this.dgvCtCCDCNGia);
            this.tpCtCCDCNGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpCtCCDCNGia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpCtCCDCNGia.Location = new System.Drawing.Point(4, 22);
            this.tpCtCCDCNGia.Name = "tpCtCCDCNGia";
            this.tpCtCCDCNGia.Padding = new System.Windows.Forms.Padding(3);
            this.tpCtCCDCNGia.Size = new System.Drawing.Size(787, 240);
            this.tpCtCCDCNGia.TabIndex = 0;
            this.tpCtCCDCNGia.Tag = "CTCCDCNGia";
            this.tpCtCCDCNGia.Text = "Xuất dùng CCDC";
            this.tpCtCCDCNGia.UseVisualStyleBackColor = true;
            // 
            // dgvCtCCDCNGia
            // 
            this.dgvCtCCDCNGia.AllowUserToAddRows = false;
            this.dgvCtCCDCNGia.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCtCCDCNGia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCtCCDCNGia.BackgroundColor = System.Drawing.Color.White;
            this.dgvCtCCDCNGia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCtCCDCNGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCtCCDCNGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCtCCDCNGia.EnableHeadersVisualStyles = false;
            this.dgvCtCCDCNGia.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvCtCCDCNGia.Location = new System.Drawing.Point(3, 3);
            this.dgvCtCCDCNGia.MultiSelect = false;
            this.dgvCtCCDCNGia.Name = "dgvCtCCDCNGia";
            this.dgvCtCCDCNGia.ReadOnly = true;
            this.dgvCtCCDCNGia.Size = new System.Drawing.Size(781, 234);
            this.dgvCtCCDCNGia.strZone = "";
            this.dgvCtCCDCNGia.TabIndex = 0;
            // 
            // tpCtCCDCHMon
            // 
            this.tpCtCCDCHMon.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tpCtCCDCHMon.Controls.Add(this.dgvCtCCDCHMon);
            this.tpCtCCDCHMon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpCtCCDCHMon.Location = new System.Drawing.Point(4, 22);
            this.tpCtCCDCHMon.Name = "tpCtCCDCHMon";
            this.tpCtCCDCHMon.Padding = new System.Windows.Forms.Padding(3);
            this.tpCtCCDCHMon.Size = new System.Drawing.Size(787, 240);
            this.tpCtCCDCHMon.TabIndex = 1;
            this.tpCtCCDCHMon.Tag = "CtCCDCHMon";
            this.tpCtCCDCHMon.Text = "Chi tiết hao mòn";
            this.tpCtCCDCHMon.UseVisualStyleBackColor = true;
            // 
            // dgvCtCCDCHMon
            // 
            this.dgvCtCCDCHMon.AllowUserToAddRows = false;
            this.dgvCtCCDCHMon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCtCCDCHMon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCtCCDCHMon.BackgroundColor = System.Drawing.Color.White;
            this.dgvCtCCDCHMon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCtCCDCHMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCtCCDCHMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCtCCDCHMon.EnableHeadersVisualStyles = false;
            this.dgvCtCCDCHMon.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvCtCCDCHMon.Location = new System.Drawing.Point(3, 3);
            this.dgvCtCCDCHMon.MultiSelect = false;
            this.dgvCtCCDCHMon.Name = "dgvCtCCDCHMon";
            this.dgvCtCCDCHMon.ReadOnly = true;
            this.dgvCtCCDCHMon.Size = new System.Drawing.Size(781, 234);
            this.dgvCtCCDCHMon.strZone = "";
            this.dgvCtCCDCHMon.TabIndex = 0;
            // 
            // tpCtCCDCStatus
            // 
            this.tpCtCCDCStatus.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tpCtCCDCStatus.Controls.Add(this.dgvCtCCDCStatus);
            this.tpCtCCDCStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpCtCCDCStatus.Location = new System.Drawing.Point(4, 22);
            this.tpCtCCDCStatus.Name = "tpCtCCDCStatus";
            this.tpCtCCDCStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tpCtCCDCStatus.Size = new System.Drawing.Size(787, 240);
            this.tpCtCCDCStatus.TabIndex = 2;
            this.tpCtCCDCStatus.Tag = "CtCCDCStatus";
            this.tpCtCCDCStatus.Text = "Luân chuyển CCDC";
            this.tpCtCCDCStatus.UseVisualStyleBackColor = true;
            // 
            // dgvCtCCDCStatus
            // 
            this.dgvCtCCDCStatus.AllowUserToAddRows = false;
            this.dgvCtCCDCStatus.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCtCCDCStatus.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCtCCDCStatus.BackgroundColor = System.Drawing.Color.White;
            this.dgvCtCCDCStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCtCCDCStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCtCCDCStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCtCCDCStatus.EnableHeadersVisualStyles = false;
            this.dgvCtCCDCStatus.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvCtCCDCStatus.Location = new System.Drawing.Point(3, 3);
            this.dgvCtCCDCStatus.MultiSelect = false;
            this.dgvCtCCDCStatus.Name = "dgvCtCCDCStatus";
            this.dgvCtCCDCStatus.ReadOnly = true;
            this.dgvCtCCDCStatus.Size = new System.Drawing.Size(781, 234);
            this.dgvCtCCDCStatus.strZone = "";
            this.dgvCtCCDCStatus.TabIndex = 0;
            // 
            // pnlControl1
            // 
            this.pnlControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlControl1.Controls.Add(this.btRefresh);
            this.pnlControl1.Controls.Add(this.btEdit);
            this.pnlControl1.Controls.Add(this.btDelete);
            this.pnlControl1.Controls.Add(this.btNew);
            this.pnlControl1.Location = new System.Drawing.Point(19, 525);
            this.pnlControl1.Name = "pnlControl1";
            this.pnlControl1.Size = new System.Drawing.Size(301, 41);
            this.pnlControl1.TabIndex = 7;
            // 
            // btRefresh
            // 
            this.btRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btRefresh.Image")));
            this.btRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRefresh.Location = new System.Drawing.Point(218, 4);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(74, 31);
            this.btRefresh.TabIndex = 4;
            this.btRefresh.Tag = "Refresh_TS";
            this.btRefresh.Text = "&Refresh";
            this.btRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // btEdit
            // 
            this.btEdit.Image = ((System.Drawing.Image)(resources.GetObject("btEdit.Image")));
            this.btEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEdit.Location = new System.Drawing.Point(76, 4);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(65, 31);
            this.btEdit.TabIndex = 2;
            this.btEdit.Tag = "Edit";
            this.btEdit.Text = "&Sửa";
            this.btEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEdit.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Image = ((System.Drawing.Image)(resources.GetObject("btDelete.Image")));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.Location = new System.Drawing.Point(147, 4);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(65, 31);
            this.btDelete.TabIndex = 3;
            this.btDelete.Tag = "Delete";
            this.btDelete.Text = "&Xóa";
            this.btDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // btNew
            // 
            this.btNew.Image = ((System.Drawing.Image)(resources.GetObject("btNew.Image")));
            this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNew.Location = new System.Drawing.Point(5, 4);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(65, 31);
            this.btNew.TabIndex = 1;
            this.btNew.Tag = "New";
            this.btNew.Text = "&Thêm";
            this.btNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // linkHelp
            // 
            this.linkHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkHelp.AutoSize = true;
            this.linkHelp.Location = new System.Drawing.Point(303, 258);
            this.linkHelp.Name = "linkHelp";
            this.linkHelp.Size = new System.Drawing.Size(106, 13);
            this.linkHelp.TabIndex = 205;
            this.linkHelp.TabStop = true;
            this.linkHelp.Tag = "Help_File";
            this.linkHelp.Text = "Hướng dẫn nhập liệu";
            // 
            // btImport
            // 
            this.btImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btImport.Image = ((System.Drawing.Image)(resources.GetObject("btImport.Image")));
            this.btImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btImport.Location = new System.Drawing.Point(707, 529);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(74, 31);
            this.btImport.TabIndex = 206;
            this.btImport.Tag = "Import";
            this.btImport.Text = "Import";
            this.btImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btImport.UseVisualStyleBackColor = true;
            // 
            // frmCtCCDC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 569);
            this.Controls.Add(this.btImport);
            this.Controls.Add(this.linkHelp);
            this.Controls.Add(this.pnlControl1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dgvCtCCDC);
            this.Name = "frmCtCCDC";
            this.Tag = "frmCtCCDC, F2, F3, F8, ESC";
            this.Text = "frmCtCCDC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtCCDC)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpCtCCDCNGia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtCCDCNGia)).EndInit();
            this.tpCtCCDCHMon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtCCDCHMon)).EndInit();
            this.tpCtCCDCStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtCCDCStatus)).EndInit();
            this.pnlControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.dgvControl dgvCtCCDC;
		private Epoint.Systems.Controls.tabControl tabControl1;
		private System.Windows.Forms.TabPage tpCtCCDCNGia;
		private System.Windows.Forms.TabPage tpCtCCDCHMon;
		private System.Windows.Forms.TabPage tpCtCCDCStatus;
		private Epoint.Systems.Controls.dgvControl dgvCtCCDCNGia;
		private Epoint.Systems.Controls.dgvControl dgvCtCCDCHMon;
		private Epoint.Systems.Controls.dgvControl dgvCtCCDCStatus;
		private Epoint.Systems.Controls.pnlControl pnlControl1;
		private Epoint.Systems.Customizes.btEdit btEdit;
		private Epoint.Systems.Customizes.btDelete btDelete;
        private Epoint.Systems.Customizes.btNew btNew;
        private Systems.Customizes.btDelete btRefresh;
        private System.Windows.Forms.LinkLabel linkHelp;
        private Systems.Customizes.btDelete btImport;


	}
}