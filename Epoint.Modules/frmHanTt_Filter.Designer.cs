namespace Epoint.Modules
{
	partial class frmHanTt_Filter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHanTt_Filter));
            this.dteNgay_Ct2 = new Epoint.Systems.Controls.txtDateTime();
            this.lblNgay_Ct1 = new Epoint.Systems.Controls.lblControl();
            this.dteNgay_Ct1 = new Epoint.Systems.Controls.txtDateTime();
            this.lblMa_Ct = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Ct = new Epoint.Systems.Controls.txtTextBox();
            this.lblNgay_Ct2 = new Epoint.Systems.Controls.lblControl();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Dt = new Epoint.Systems.Controls.lbtControl();
            this.lbtTen_Tk = new Epoint.Systems.Controls.lbtControl();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.chkDu_Cuoi_Only = new Epoint.Systems.Controls.chkControl();
            this.txtTk = new Epoint.Systems.Controls.txtTextLookup();
            this.txtMa_Dt = new Epoint.Systems.Controls.txtTextLookup();
            this.SuspendLayout();
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.bAllowEmpty = true;
            this.dteNgay_Ct2.bRequire = false;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(151, 51);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct2.TabIndex = 1;
            // 
            // lblNgay_Ct1
            // 
            this.lblNgay_Ct1.AutoEllipsis = true;
            this.lblNgay_Ct1.AutoSize = true;
            this.lblNgay_Ct1.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay_Ct1.Location = new System.Drawing.Point(33, 28);
            this.lblNgay_Ct1.Name = "lblNgay_Ct1";
            this.lblNgay_Ct1.Size = new System.Drawing.Size(46, 13);
            this.lblNgay_Ct1.TabIndex = 71;
            this.lblNgay_Ct1.Tag = "Ngay_Ct1";
            this.lblNgay_Ct1.Text = "Từ ngày";
            this.lblNgay_Ct1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.bAllowEmpty = true;
            this.dteNgay_Ct1.bRequire = false;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(151, 28);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct1.TabIndex = 0;
            // 
            // lblMa_Ct
            // 
            this.lblMa_Ct.AutoEllipsis = true;
            this.lblMa_Ct.AutoSize = true;
            this.lblMa_Ct.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Ct.Location = new System.Drawing.Point(33, 120);
            this.lblMa_Ct.Name = "lblMa_Ct";
            this.lblMa_Ct.Size = new System.Drawing.Size(67, 13);
            this.lblMa_Ct.TabIndex = 72;
            this.lblMa_Ct.Tag = "Ma_Ct";
            this.lblMa_Ct.Text = "Mã chứng từ";
            this.lblMa_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Ct
            // 
            this.txtMa_Ct.bEnabled = true;
            this.txtMa_Ct.bIsLookup = false;
            this.txtMa_Ct.bReadOnly = false;
            this.txtMa_Ct.bRequire = false;
            this.txtMa_Ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Ct.KeyFilter = "";
            this.txtMa_Ct.Location = new System.Drawing.Point(151, 120);
            this.txtMa_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Ct.MaxLength = 20;
            this.txtMa_Ct.Name = "txtMa_Ct";
            this.txtMa_Ct.Size = new System.Drawing.Size(34, 20);
            this.txtMa_Ct.TabIndex = 4;
            this.txtMa_Ct.UseAutoFilter = false;
            // 
            // lblNgay_Ct2
            // 
            this.lblNgay_Ct2.AutoEllipsis = true;
            this.lblNgay_Ct2.AutoSize = true;
            this.lblNgay_Ct2.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay_Ct2.Location = new System.Drawing.Point(33, 51);
            this.lblNgay_Ct2.Name = "lblNgay_Ct2";
            this.lblNgay_Ct2.Size = new System.Drawing.Size(53, 13);
            this.lblNgay_Ct2.TabIndex = 73;
            this.lblNgay_Ct2.Tag = "Ngay_Ct2";
            this.lblNgay_Ct2.Text = "Đến ngày";
            this.lblNgay_Ct2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(33, 97);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(70, 13);
            this.lblControl2.TabIndex = 77;
            this.lblControl2.Tag = "Ma_Dt";
            this.lblControl2.Text = "Mã đối tượng";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(33, 74);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(55, 13);
            this.lblControl1.TabIndex = 76;
            this.lblControl1.Tag = "Tk";
            this.lblControl1.Text = "Tài khoản";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Dt
            // 
            this.lbtTen_Dt.AutoSize = true;
            this.lbtTen_Dt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt.Location = new System.Drawing.Point(257, 101);
            this.lbtTen_Dt.Name = "lbtTen_Dt";
            this.lbtTen_Dt.Size = new System.Drawing.Size(43, 13);
            this.lbtTen_Dt.TabIndex = 79;
            this.lbtTen_Dt.Tag = "Ten_Dt";
            this.lbtTen_Dt.Text = "Ten_Dt";
            this.lbtTen_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Tk
            // 
            this.lbtTen_Tk.AutoSize = true;
            this.lbtTen_Tk.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Tk.Location = new System.Drawing.Point(257, 77);
            this.lbtTen_Tk.Name = "lbtTen_Tk";
            this.lbtTen_Tk.Size = new System.Drawing.Size(45, 13);
            this.lbtTen_Tk.TabIndex = 78;
            this.lbtTen_Tk.Tag = "Ten_Tk";
            this.lbtTen_Tk.Text = "Ten_Tk";
            this.lbtTen_Tk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(318, 185);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(185, 30);
            this.btgAccept.TabIndex = 6;
            // 
            // chkDu_Cuoi_Only
            // 
            this.chkDu_Cuoi_Only.AutoSize = true;
            this.chkDu_Cuoi_Only.Checked = true;
            this.chkDu_Cuoi_Only.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDu_Cuoi_Only.Location = new System.Drawing.Point(151, 146);
            this.chkDu_Cuoi_Only.Name = "chkDu_Cuoi_Only";
            this.chkDu_Cuoi_Only.Size = new System.Drawing.Size(176, 17);
            this.chkDu_Cuoi_Only.TabIndex = 5;
            this.chkDu_Cuoi_Only.Tag = "Du_Cuoi_Only";
            this.chkDu_Cuoi_Only.Text = "Hiện những chứng từ còn số dư";
            this.chkDu_Cuoi_Only.UseVisualStyleBackColor = true;
            // 
            // txtTk
            // 
            this.txtTk.bEnabled = true;
            this.txtTk.bIsLookup = false;
            this.txtTk.bReadOnly = false;
            this.txtTk.bRequire = false;
            this.txtTk.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTk.KeyFilter = "Tk";
            this.txtTk.Location = new System.Drawing.Point(151, 74);
            this.txtTk.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTk.Name = "txtTk";
            this.txtTk.Size = new System.Drawing.Size(100, 20);
            this.txtTk.TabIndex = 2;
            this.txtTk.UseAutoFilter = true;
            // 
            // txtMa_Dt
            // 
            this.txtMa_Dt.bEnabled = true;
            this.txtMa_Dt.bIsLookup = false;
            this.txtMa_Dt.bReadOnly = false;
            this.txtMa_Dt.bRequire = false;
            this.txtMa_Dt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt.KeyFilter = "Ma_Dt";
            this.txtMa_Dt.Location = new System.Drawing.Point(151, 97);
            this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt.Name = "txtMa_Dt";
            this.txtMa_Dt.Size = new System.Drawing.Size(101, 20);
            this.txtMa_Dt.TabIndex = 3;
            this.txtMa_Dt.UseAutoFilter = true;
            // 
            // frmHanTt_Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 227);
            this.Controls.Add(this.txtMa_Dt);
            this.Controls.Add(this.txtTk);
            this.Controls.Add(this.chkDu_Cuoi_Only);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.lblControl2);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.lbtTen_Dt);
            this.Controls.Add(this.lbtTen_Tk);
            this.Controls.Add(this.dteNgay_Ct2);
            this.Controls.Add(this.lblNgay_Ct1);
            this.Controls.Add(this.dteNgay_Ct1);
            this.Controls.Add(this.lblMa_Ct);
            this.Controls.Add(this.txtMa_Ct);
            this.Controls.Add(this.lblNgay_Ct2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHanTt_Filter";
            this.Text = "frmHanTt_Filter";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		public Epoint.Systems.Controls.txtDateTime dteNgay_Ct2;
		private Epoint.Systems.Controls.lblControl lblNgay_Ct1;
		public Epoint.Systems.Controls.txtDateTime dteNgay_Ct1;
		private Epoint.Systems.Controls.lblControl lblMa_Ct;
		public Epoint.Systems.Controls.txtTextBox txtMa_Ct;
        private Epoint.Systems.Controls.lblControl lblNgay_Ct2;
		private Epoint.Systems.Controls.lblControl lblControl2;
		private Epoint.Systems.Controls.lblControl lblControl1;
		private Epoint.Systems.Controls.lbtControl lbtTen_Dt;
		private Epoint.Systems.Controls.lbtControl lbtTen_Tk;
		public Epoint.Systems.Customizes.btgAccept btgAccept;
		public Epoint.Systems.Controls.chkControl chkDu_Cuoi_Only;
        public Systems.Controls.txtTextLookup txtTk;
        public Systems.Controls.txtTextLookup txtMa_Dt;
	}
}