namespace Epoint.Modules.AS
{
	partial class frmPhanBoCCDC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhanBoCCDC));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.numThang = new Epoint.Systems.Controls.numControl();
            this.label1 = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Nh_Ts = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Nh_Ts = new Epoint.Systems.Controls.txtTextBox();
            this.lblMa_Nh_Ts = new Epoint.Systems.Controls.lblControl();
            this.txtMa_CCDC = new Epoint.Systems.Controls.txtTextBox();
            this.lblMa_CCDC = new Epoint.Systems.Controls.lblControl();
            this.lblTen_CCDC = new Epoint.Systems.Controls.lblControl();
            this.btThuc_Hien = new Epoint.Systems.Controls.btControl();
            this.btPosted = new Epoint.Systems.Controls.btControl();
            this.dgvPhanBo = new Epoint.Systems.Controls.dgvControl();
            this.numTy_Gia = new Epoint.Systems.Controls.numControl();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanBo)).BeginInit();
            this.SuspendLayout();
            // 
            // numThang
            // 
            this.numThang.bEnabled = true;
            this.numThang.bFormat = true;
            this.numThang.bIsLookup = false;
            this.numThang.bReadOnly = false;
            this.numThang.bRequire = false;
            this.numThang.KeyFilter = "";
            this.numThang.Location = new System.Drawing.Point(107, 12);
            this.numThang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numThang.Name = "numThang";
            this.numThang.Scale = 0;
            this.numThang.Size = new System.Drawing.Size(23, 20);
            this.numThang.TabIndex = 0;
            this.numThang.Text = "0";
            this.numThang.UseAutoFilter = false;
            this.numThang.Value = 0D;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(23, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 14;
            this.label1.Tag = "Month";
            this.label1.Text = "Tháng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Nh_Ts
            // 
            this.lbtTen_Nh_Ts.AutoEllipsis = true;
            this.lbtTen_Nh_Ts.AutoSize = true;
            this.lbtTen_Nh_Ts.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Nh_Ts.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Nh_Ts.Location = new System.Drawing.Point(236, 61);
            this.lbtTen_Nh_Ts.Name = "lbtTen_Nh_Ts";
            this.lbtTen_Nh_Ts.Size = new System.Drawing.Size(55, 13);
            this.lbtTen_Nh_Ts.TabIndex = 61;
            this.lbtTen_Nh_Ts.Tag = "Ten_Nh_Ts";
            this.lbtTen_Nh_Ts.Text = "Tên nhóm";
            this.lbtTen_Nh_Ts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Nh_Ts
            // 
            this.txtMa_Nh_Ts.bEnabled = true;
            this.txtMa_Nh_Ts.bIsLookup = false;
            this.txtMa_Nh_Ts.bReadOnly = false;
            this.txtMa_Nh_Ts.bRequire = false;
            this.txtMa_Nh_Ts.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Nh_Ts.KeyFilter = "";
            this.txtMa_Nh_Ts.Location = new System.Drawing.Point(107, 58);
            this.txtMa_Nh_Ts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Nh_Ts.MaxLength = 20;
            this.txtMa_Nh_Ts.Name = "txtMa_Nh_Ts";
            this.txtMa_Nh_Ts.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Nh_Ts.TabIndex = 3;
            this.txtMa_Nh_Ts.UseAutoFilter = false;
            // 
            // lblMa_Nh_Ts
            // 
            this.lblMa_Nh_Ts.AutoEllipsis = true;
            this.lblMa_Nh_Ts.AutoSize = true;
            this.lblMa_Nh_Ts.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Nh_Ts.Location = new System.Drawing.Point(23, 61);
            this.lblMa_Nh_Ts.Name = "lblMa_Nh_Ts";
            this.lblMa_Nh_Ts.Size = new System.Drawing.Size(83, 13);
            this.lblMa_Nh_Ts.TabIndex = 60;
            this.lblMa_Nh_Ts.Tag = "";
            this.lblMa_Nh_Ts.Text = "Mã nhóm CCDC";
            this.lblMa_Nh_Ts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_CCDC
            // 
            this.txtMa_CCDC.bEnabled = true;
            this.txtMa_CCDC.bIsLookup = false;
            this.txtMa_CCDC.bReadOnly = false;
            this.txtMa_CCDC.bRequire = false;
            this.txtMa_CCDC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_CCDC.KeyFilter = "";
            this.txtMa_CCDC.Location = new System.Drawing.Point(107, 35);
            this.txtMa_CCDC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_CCDC.MaxLength = 20;
            this.txtMa_CCDC.Name = "txtMa_CCDC";
            this.txtMa_CCDC.Size = new System.Drawing.Size(120, 20);
            this.txtMa_CCDC.TabIndex = 2;
            this.txtMa_CCDC.UseAutoFilter = false;
            // 
            // lblMa_CCDC
            // 
            this.lblMa_CCDC.AutoEllipsis = true;
            this.lblMa_CCDC.AutoSize = true;
            this.lblMa_CCDC.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_CCDC.Location = new System.Drawing.Point(23, 38);
            this.lblMa_CCDC.Name = "lblMa_CCDC";
            this.lblMa_CCDC.Size = new System.Drawing.Size(54, 13);
            this.lblMa_CCDC.TabIndex = 59;
            this.lblMa_CCDC.Tag = "";
            this.lblMa_CCDC.Text = "Mã CCDC";
            this.lblMa_CCDC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTen_CCDC
            // 
            this.lblTen_CCDC.AutoEllipsis = true;
            this.lblTen_CCDC.AutoSize = true;
            this.lblTen_CCDC.BackColor = System.Drawing.Color.Transparent;
            this.lblTen_CCDC.ForeColor = System.Drawing.Color.Blue;
            this.lblTen_CCDC.Location = new System.Drawing.Point(236, 38);
            this.lblTen_CCDC.Name = "lblTen_CCDC";
            this.lblTen_CCDC.Size = new System.Drawing.Size(41, 13);
            this.lblTen_CCDC.TabIndex = 61;
            this.lblTen_CCDC.Tag = "Ten_Ts";
            this.lblTen_CCDC.Text = "Tên Ts";
            this.lblTen_CCDC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btThuc_Hien
            // 
            this.btThuc_Hien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btThuc_Hien.Image = ((System.Drawing.Image)(resources.GetObject("btThuc_Hien.Image")));
            this.btThuc_Hien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btThuc_Hien.Location = new System.Drawing.Point(22, 529);
            this.btThuc_Hien.Name = "btThuc_Hien";
            this.btThuc_Hien.Size = new System.Drawing.Size(122, 29);
            this.btThuc_Hien.TabIndex = 4;
            this.btThuc_Hien.Tag = "Tinh_Phan_Bo";
            this.btThuc_Hien.Text = "&Tính phân bổ";
            this.btThuc_Hien.UseVisualStyleBackColor = true;
            // 
            // btPosted
            // 
            this.btPosted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btPosted.Image = ((System.Drawing.Image)(resources.GetObject("btPosted.Image")));
            this.btPosted.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPosted.Location = new System.Drawing.Point(150, 529);
            this.btPosted.Name = "btPosted";
            this.btPosted.Size = new System.Drawing.Size(151, 29);
            this.btPosted.TabIndex = 5;
            this.btPosted.Tag = "Posted";
            this.btPosted.Text = "Tạo &phiếu hạch toán";
            this.btPosted.UseVisualStyleBackColor = true;
            // 
            // dgvPhanBo
            // 
            this.dgvPhanBo.AllowUserToAddRows = false;
            this.dgvPhanBo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPhanBo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPhanBo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhanBo.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhanBo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPhanBo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhanBo.EnableHeadersVisualStyles = false;
            this.dgvPhanBo.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvPhanBo.Location = new System.Drawing.Point(4, 83);
            this.dgvPhanBo.MultiSelect = false;
            this.dgvPhanBo.Name = "dgvPhanBo";
            this.dgvPhanBo.ReadOnly = true;
            this.dgvPhanBo.Size = new System.Drawing.Size(786, 440);
            this.dgvPhanBo.strZone = "";
            this.dgvPhanBo.TabIndex = 3;
            // 
            // numTy_Gia
            // 
            this.numTy_Gia.bEnabled = true;
            this.numTy_Gia.bFormat = true;
            this.numTy_Gia.bIsLookup = false;
            this.numTy_Gia.bReadOnly = false;
            this.numTy_Gia.bRequire = false;
            this.numTy_Gia.KeyFilter = "";
            this.numTy_Gia.Location = new System.Drawing.Point(169, 12);
            this.numTy_Gia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTy_Gia.Name = "numTy_Gia";
            this.numTy_Gia.Scale = 2;
            this.numTy_Gia.Size = new System.Drawing.Size(56, 20);
            this.numTy_Gia.TabIndex = 1;
            this.numTy_Gia.Text = "1.00";
            this.numTy_Gia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTy_Gia.UseAutoFilter = false;
            this.numTy_Gia.Value = 1D;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(132, 16);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(36, 13);
            this.lblControl1.TabIndex = 14;
            this.lblControl1.Tag = "";
            this.lblControl1.Text = "Tỷ giá";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmPhanBoCCDC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.numThang);
            this.Controls.Add(this.numTy_Gia);
            this.Controls.Add(this.btPosted);
            this.Controls.Add(this.btThuc_Hien);
            this.Controls.Add(this.lblTen_CCDC);
            this.Controls.Add(this.lbtTen_Nh_Ts);
            this.Controls.Add(this.txtMa_Nh_Ts);
            this.Controls.Add(this.lblMa_Nh_Ts);
            this.Controls.Add(this.txtMa_CCDC);
            this.Controls.Add(this.lblMa_CCDC);
            this.Controls.Add(this.dgvPhanBo);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.label1);
            this.Name = "frmPhanBoCCDC";
            this.Tag = "frmPhanBoCCDC";
            this.Text = "frmPhanBoCCDC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanBo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.numControl numThang;
		private Epoint.Systems.Controls.lblControl label1;
		private Epoint.Systems.Controls.lblControl lbtTen_Nh_Ts;
		private Epoint.Systems.Controls.txtTextBox txtMa_Nh_Ts;
		private Epoint.Systems.Controls.lblControl lblMa_Nh_Ts;
		private Epoint.Systems.Controls.txtTextBox txtMa_CCDC;
		private Epoint.Systems.Controls.lblControl lblMa_CCDC;
		private Epoint.Systems.Controls.lblControl lblTen_CCDC;
        private Epoint.Systems.Controls.btControl btThuc_Hien;
		private Epoint.Systems.Controls.btControl btPosted;
		private Epoint.Systems.Controls.dgvControl dgvPhanBo;
        private Epoint.Systems.Controls.numControl numTy_Gia;
        private Epoint.Systems.Controls.lblControl lblControl1;
	}
}