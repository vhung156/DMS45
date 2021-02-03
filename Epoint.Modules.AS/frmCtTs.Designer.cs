namespace Epoint.Modules.AS
{
	partial class frmCtTs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCtTs));
            this.dgvCtTs = new Epoint.Systems.Controls.dgvControl();
            this.tabControl1 = new Epoint.Systems.Controls.tabControl();
            this.tpCtTsNGia = new System.Windows.Forms.TabPage();
            this.dgvCtTsNGia = new Epoint.Systems.Controls.dgvControl();
            this.tpCtTsHMon = new System.Windows.Forms.TabPage();
            this.dgvCtTsHMon = new Epoint.Systems.Controls.dgvControl();
            this.tpCtTsStatus = new System.Windows.Forms.TabPage();
            this.dgvCtTsStatus = new Epoint.Systems.Controls.dgvControl();
            this.pnlControl1 = new Epoint.Systems.Controls.pnlControl();
            this.btRefresh = new Epoint.Systems.Customizes.btDelete();
            this.btEdit = new Epoint.Systems.Customizes.btEdit();
            this.btDelete = new Epoint.Systems.Customizes.btDelete();
            this.btNew = new Epoint.Systems.Customizes.btNew();
            this.linkHelp = new System.Windows.Forms.LinkLabel();
            this.btImport = new Epoint.Systems.Customizes.btDelete();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtTs)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpCtTsNGia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtTsNGia)).BeginInit();
            this.tpCtTsHMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtTsHMon)).BeginInit();
            this.tpCtTsStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtTsStatus)).BeginInit();
            this.pnlControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCtTs
            // 
            this.dgvCtTs.AllowUserToAddRows = false;
            this.dgvCtTs.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCtTs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCtTs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCtTs.BackgroundColor = System.Drawing.Color.White;
            this.dgvCtTs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCtTs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCtTs.EnableHeadersVisualStyles = false;
            this.dgvCtTs.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvCtTs.Location = new System.Drawing.Point(6, 6);
            this.dgvCtTs.MultiSelect = false;
            this.dgvCtTs.Name = "dgvCtTs";
            this.dgvCtTs.ReadOnly = true;
            this.dgvCtTs.Size = new System.Drawing.Size(795, 242);
            this.dgvCtTs.strZone = "";
            this.dgvCtTs.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpCtTsNGia);
            this.tabControl1.Controls.Add(this.tpCtTsHMon);
            this.tabControl1.Controls.Add(this.tpCtTsStatus);
            this.tabControl1.Location = new System.Drawing.Point(6, 254);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(795, 266);
            this.tabControl1.TabIndex = 1;
            // 
            // tpCtTsNGia
            // 
            this.tpCtTsNGia.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tpCtTsNGia.Controls.Add(this.dgvCtTsNGia);
            this.tpCtTsNGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpCtTsNGia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpCtTsNGia.Location = new System.Drawing.Point(4, 22);
            this.tpCtTsNGia.Name = "tpCtTsNGia";
            this.tpCtTsNGia.Padding = new System.Windows.Forms.Padding(3);
            this.tpCtTsNGia.Size = new System.Drawing.Size(787, 240);
            this.tpCtTsNGia.TabIndex = 0;
            this.tpCtTsNGia.Tag = "CtTSNGia";
            this.tpCtTsNGia.Text = "Chi tiết nguyên giá";
            this.tpCtTsNGia.UseVisualStyleBackColor = true;
            // 
            // dgvCtTsNGia
            // 
            this.dgvCtTsNGia.AllowUserToAddRows = false;
            this.dgvCtTsNGia.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCtTsNGia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCtTsNGia.BackgroundColor = System.Drawing.Color.White;
            this.dgvCtTsNGia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCtTsNGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCtTsNGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCtTsNGia.EnableHeadersVisualStyles = false;
            this.dgvCtTsNGia.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvCtTsNGia.Location = new System.Drawing.Point(3, 3);
            this.dgvCtTsNGia.MultiSelect = false;
            this.dgvCtTsNGia.Name = "dgvCtTsNGia";
            this.dgvCtTsNGia.ReadOnly = true;
            this.dgvCtTsNGia.Size = new System.Drawing.Size(781, 234);
            this.dgvCtTsNGia.strZone = "";
            this.dgvCtTsNGia.TabIndex = 0;
            // 
            // tpCtTsHMon
            // 
            this.tpCtTsHMon.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tpCtTsHMon.Controls.Add(this.dgvCtTsHMon);
            this.tpCtTsHMon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpCtTsHMon.Location = new System.Drawing.Point(4, 22);
            this.tpCtTsHMon.Name = "tpCtTsHMon";
            this.tpCtTsHMon.Padding = new System.Windows.Forms.Padding(3);
            this.tpCtTsHMon.Size = new System.Drawing.Size(787, 240);
            this.tpCtTsHMon.TabIndex = 1;
            this.tpCtTsHMon.Tag = "CtTSHMon";
            this.tpCtTsHMon.Text = "Chi tiết hao mòn";
            this.tpCtTsHMon.UseVisualStyleBackColor = true;
            // 
            // dgvCtTsHMon
            // 
            this.dgvCtTsHMon.AllowUserToAddRows = false;
            this.dgvCtTsHMon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCtTsHMon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCtTsHMon.BackgroundColor = System.Drawing.Color.White;
            this.dgvCtTsHMon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCtTsHMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCtTsHMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCtTsHMon.EnableHeadersVisualStyles = false;
            this.dgvCtTsHMon.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvCtTsHMon.Location = new System.Drawing.Point(3, 3);
            this.dgvCtTsHMon.MultiSelect = false;
            this.dgvCtTsHMon.Name = "dgvCtTsHMon";
            this.dgvCtTsHMon.ReadOnly = true;
            this.dgvCtTsHMon.Size = new System.Drawing.Size(781, 234);
            this.dgvCtTsHMon.strZone = "";
            this.dgvCtTsHMon.TabIndex = 0;
            // 
            // tpCtTsStatus
            // 
            this.tpCtTsStatus.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tpCtTsStatus.Controls.Add(this.dgvCtTsStatus);
            this.tpCtTsStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpCtTsStatus.Location = new System.Drawing.Point(4, 22);
            this.tpCtTsStatus.Name = "tpCtTsStatus";
            this.tpCtTsStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tpCtTsStatus.Size = new System.Drawing.Size(787, 240);
            this.tpCtTsStatus.TabIndex = 2;
            this.tpCtTsStatus.Tag = "CtTSStatus";
            this.tpCtTsStatus.Text = "Luân chuyển trạng thái tài sản";
            this.tpCtTsStatus.UseVisualStyleBackColor = true;
            // 
            // dgvCtTsStatus
            // 
            this.dgvCtTsStatus.AllowUserToAddRows = false;
            this.dgvCtTsStatus.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCtTsStatus.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCtTsStatus.BackgroundColor = System.Drawing.Color.White;
            this.dgvCtTsStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCtTsStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCtTsStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCtTsStatus.EnableHeadersVisualStyles = false;
            this.dgvCtTsStatus.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvCtTsStatus.Location = new System.Drawing.Point(3, 3);
            this.dgvCtTsStatus.MultiSelect = false;
            this.dgvCtTsStatus.Name = "dgvCtTsStatus";
            this.dgvCtTsStatus.ReadOnly = true;
            this.dgvCtTsStatus.Size = new System.Drawing.Size(781, 234);
            this.dgvCtTsStatus.strZone = "";
            this.dgvCtTsStatus.TabIndex = 0;
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
            this.linkHelp.Location = new System.Drawing.Point(358, 258);
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
            this.btImport.Location = new System.Drawing.Point(709, 529);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(88, 31);
            this.btImport.TabIndex = 4;
            this.btImport.Tag = "Import";
            this.btImport.Text = "Lấy dữ liệu";
            this.btImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btImport.UseVisualStyleBackColor = true;
            // 
            // frmCtTs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 569);
            this.Controls.Add(this.btImport);
            this.Controls.Add(this.linkHelp);
            this.Controls.Add(this.pnlControl1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dgvCtTs);
            this.Name = "frmCtTs";
            this.Tag = "frmCtTS, F2, F3, F8, ESC";
            this.Text = "frmCtTS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtTs)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpCtTsNGia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtTsNGia)).EndInit();
            this.tpCtTsHMon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtTsHMon)).EndInit();
            this.tpCtTsStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtTsStatus)).EndInit();
            this.pnlControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.dgvControl dgvCtTs;
		private Epoint.Systems.Controls.tabControl tabControl1;
		private System.Windows.Forms.TabPage tpCtTsNGia;
		private System.Windows.Forms.TabPage tpCtTsHMon;
		private System.Windows.Forms.TabPage tpCtTsStatus;
		private Epoint.Systems.Controls.dgvControl dgvCtTsNGia;
		private Epoint.Systems.Controls.dgvControl dgvCtTsHMon;
		private Epoint.Systems.Controls.dgvControl dgvCtTsStatus;
		private Epoint.Systems.Controls.pnlControl pnlControl1;
		private Epoint.Systems.Customizes.btEdit btEdit;
		private Epoint.Systems.Customizes.btDelete btDelete;
        private Epoint.Systems.Customizes.btNew btNew;
        private Systems.Customizes.btDelete btRefresh;
        private System.Windows.Forms.LinkLabel linkHelp;
        private Systems.Customizes.btDelete btImport;


	}
}