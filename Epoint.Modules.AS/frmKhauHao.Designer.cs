namespace Epoint.Modules.AS
{
	partial class frmKhauHao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhauHao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.numThang = new Epoint.Systems.Controls.numControl();
            this.label1 = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Nh_Ts = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Nh_Ts = new Epoint.Systems.Controls.txtTextBox();
            this.lblMa_Nh_Ts = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Ts = new Epoint.Systems.Controls.txtTextBox();
            this.lbMa_Ts = new Epoint.Systems.Controls.lblControl();
            this.lblTen_Ts = new Epoint.Systems.Controls.lblControl();
            this.btThuc_Hien = new Epoint.Systems.Controls.btControl();
            this.btPosted = new Epoint.Systems.Controls.btControl();
            this.dgvKhauHao = new Epoint.Systems.Controls.dgvControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhauHao)).BeginInit();
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
            this.numThang.Size = new System.Drawing.Size(33, 20);
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
            this.label1.Location = new System.Drawing.Point(23, 15);
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
            this.txtMa_Nh_Ts.TabIndex = 2;
            this.txtMa_Nh_Ts.UseAutoFilter = false;
            // 
            // lblMa_Nh_Ts
            // 
            this.lblMa_Nh_Ts.AutoEllipsis = true;
            this.lblMa_Nh_Ts.AutoSize = true;
            this.lblMa_Nh_Ts.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Nh_Ts.Location = new System.Drawing.Point(23, 61);
            this.lblMa_Nh_Ts.Name = "lblMa_Nh_Ts";
            this.lblMa_Nh_Ts.Size = new System.Drawing.Size(51, 13);
            this.lblMa_Nh_Ts.TabIndex = 60;
            this.lblMa_Nh_Ts.Tag = "Ma_Nh_Ts";
            this.lblMa_Nh_Ts.Text = "Mã nhóm";
            this.lblMa_Nh_Ts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Ts
            // 
            this.txtMa_Ts.bEnabled = true;
            this.txtMa_Ts.bIsLookup = false;
            this.txtMa_Ts.bReadOnly = false;
            this.txtMa_Ts.bRequire = false;
            this.txtMa_Ts.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Ts.KeyFilter = "";
            this.txtMa_Ts.Location = new System.Drawing.Point(107, 35);
            this.txtMa_Ts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Ts.MaxLength = 20;
            this.txtMa_Ts.Name = "txtMa_Ts";
            this.txtMa_Ts.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Ts.TabIndex = 1;
            this.txtMa_Ts.UseAutoFilter = false;
            // 
            // lbMa_Ts
            // 
            this.lbMa_Ts.AutoEllipsis = true;
            this.lbMa_Ts.AutoSize = true;
            this.lbMa_Ts.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_Ts.Location = new System.Drawing.Point(23, 38);
            this.lbMa_Ts.Name = "lbMa_Ts";
            this.lbMa_Ts.Size = new System.Drawing.Size(56, 13);
            this.lbMa_Ts.TabIndex = 59;
            this.lbMa_Ts.Tag = "Ma_Ts";
            this.lbMa_Ts.Text = "Mã tài sản";
            this.lbMa_Ts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTen_Ts
            // 
            this.lblTen_Ts.AutoEllipsis = true;
            this.lblTen_Ts.AutoSize = true;
            this.lblTen_Ts.BackColor = System.Drawing.Color.Transparent;
            this.lblTen_Ts.ForeColor = System.Drawing.Color.Blue;
            this.lblTen_Ts.Location = new System.Drawing.Point(236, 38);
            this.lblTen_Ts.Name = "lblTen_Ts";
            this.lblTen_Ts.Size = new System.Drawing.Size(41, 13);
            this.lblTen_Ts.TabIndex = 61;
            this.lblTen_Ts.Tag = "Ten_Ts";
            this.lblTen_Ts.Text = "Tên Ts";
            this.lblTen_Ts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btThuc_Hien
            // 
            this.btThuc_Hien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btThuc_Hien.Image = ((System.Drawing.Image)(resources.GetObject("btThuc_Hien.Image")));
            this.btThuc_Hien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btThuc_Hien.Location = new System.Drawing.Point(21, 531);
            this.btThuc_Hien.Name = "btThuc_Hien";
            this.btThuc_Hien.Size = new System.Drawing.Size(127, 29);
            this.btThuc_Hien.TabIndex = 64;
            this.btThuc_Hien.Tag = "Tinh_Khau_Hao";
            this.btThuc_Hien.Text = "&Tính khấu hao";
            this.btThuc_Hien.UseVisualStyleBackColor = true;
            // 
            // btPosted
            // 
            this.btPosted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btPosted.Image = ((System.Drawing.Image)(resources.GetObject("btPosted.Image")));
            this.btPosted.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPosted.Location = new System.Drawing.Point(154, 531);
            this.btPosted.Name = "btPosted";
            this.btPosted.Size = new System.Drawing.Size(151, 29);
            this.btPosted.TabIndex = 64;
            this.btPosted.Tag = "Posted";
            this.btPosted.Text = "Tạo &phiếu hạch toán";
            this.btPosted.UseVisualStyleBackColor = true;
            // 
            // dgvKhauHao
            // 
            this.dgvKhauHao.AllowUserToAddRows = false;
            this.dgvKhauHao.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvKhauHao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKhauHao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKhauHao.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhauHao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvKhauHao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhauHao.EnableHeadersVisualStyles = false;
            this.dgvKhauHao.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvKhauHao.Location = new System.Drawing.Point(4, 83);
            this.dgvKhauHao.MultiSelect = false;
            this.dgvKhauHao.Name = "dgvKhauHao";
            this.dgvKhauHao.ReadOnly = true;
            this.dgvKhauHao.Size = new System.Drawing.Size(786, 442);
            this.dgvKhauHao.strZone = "";
            this.dgvKhauHao.TabIndex = 3;
            // 
            // frmKhauHao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btPosted);
            this.Controls.Add(this.btThuc_Hien);
            this.Controls.Add(this.lblTen_Ts);
            this.Controls.Add(this.lbtTen_Nh_Ts);
            this.Controls.Add(this.txtMa_Nh_Ts);
            this.Controls.Add(this.lblMa_Nh_Ts);
            this.Controls.Add(this.txtMa_Ts);
            this.Controls.Add(this.lbMa_Ts);
            this.Controls.Add(this.dgvKhauHao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numThang);
            this.Name = "frmKhauHao";
            this.Text = "frmKhauHao";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhauHao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.numControl numThang;
		private Epoint.Systems.Controls.lblControl label1;
		private Epoint.Systems.Controls.lblControl lbtTen_Nh_Ts;
		private Epoint.Systems.Controls.txtTextBox txtMa_Nh_Ts;
		private Epoint.Systems.Controls.lblControl lblMa_Nh_Ts;
		private Epoint.Systems.Controls.txtTextBox txtMa_Ts;
		private Epoint.Systems.Controls.lblControl lbMa_Ts;
		private Epoint.Systems.Controls.lblControl lblTen_Ts;
        private Epoint.Systems.Controls.btControl btThuc_Hien;
		private Epoint.Systems.Controls.btControl btPosted;
		private Epoint.Systems.Controls.dgvControl dgvKhauHao;
	}
}