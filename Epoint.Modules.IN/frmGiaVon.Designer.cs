namespace Epoint.Modules.IN
{
	partial class frmGiaVon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiaVon));
            this.btOk = new Epoint.Systems.Controls.btControl();
            this.label1 = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Vt = new Epoint.Systems.Controls.lbtControl();
            this.lblMa_Kho = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Kho = new Epoint.Systems.Controls.lbtControl();
            this.btCancel = new Epoint.Systems.Controls.btControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbGiaNTXT = new System.Windows.Forms.RadioButton();
            this.rdbGiaBQTT = new System.Windows.Forms.RadioButton();
            this.rdbGiaBQTH = new System.Windows.Forms.RadioButton();
            this.txtNgay_Ct2 = new Epoint.Systems.Controls.txtDateTime();
            this.txtNgay_Ct1 = new Epoint.Systems.Controls.txtDateTime();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Vt = new Epoint.Systems.Controls.txtTextLookup();
            this.txtMa_Kho = new Epoint.Systems.Controls.txtTextLookup();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOk.ForeColor = System.Drawing.Color.MediumBlue;
            this.btOk.Image = ((System.Drawing.Image)(resources.GetObject("btOk.Image")));
            this.btOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOk.Location = new System.Drawing.Point(288, 244);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(80, 29);
            this.btOk.TabIndex = 5;
            this.btOk.Tag = "";
            this.btOk.Text = "Đồ&ng ý";
            this.btOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOk.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(37, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Tag = "Ma_Vt";
            this.label1.Text = "Mã vật tư";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Vt
            // 
            this.lbtTen_Vt.AutoSize = true;
            this.lbtTen_Vt.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_Vt.Location = new System.Drawing.Point(227, 79);
            this.lbtTen_Vt.Name = "lbtTen_Vt";
            this.lbtTen_Vt.Size = new System.Drawing.Size(38, 13);
            this.lbtTen_Vt.TabIndex = 2;
            this.lbtTen_Vt.Tag = "Ten_Vt";
            this.lbtTen_Vt.Text = "Tên vt";
            this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMa_Kho
            // 
            this.lblMa_Kho.AutoEllipsis = true;
            this.lblMa_Kho.AutoSize = true;
            this.lblMa_Kho.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Kho.Location = new System.Drawing.Point(37, 103);
            this.lblMa_Kho.Name = "lblMa_Kho";
            this.lblMa_Kho.Size = new System.Drawing.Size(43, 13);
            this.lblMa_Kho.TabIndex = 2;
            this.lblMa_Kho.Tag = "Ma_Kho";
            this.lblMa_Kho.Text = "Mã kho";
            this.lblMa_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Kho
            // 
            this.lbtTen_Kho.AutoSize = true;
            this.lbtTen_Kho.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_Kho.Location = new System.Drawing.Point(227, 102);
            this.lbtTen_Kho.Name = "lbtTen_Kho";
            this.lbtTen_Kho.Size = new System.Drawing.Size(48, 13);
            this.lbtTen_Kho.TabIndex = 2;
            this.lbtTen_Kho.Tag = "Ten_Kho";
            this.lbtTen_Kho.Text = "Tên Kho";
            this.lbtTen_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.MediumBlue;
            this.btCancel.Image = ((System.Drawing.Image)(resources.GetObject("btCancel.Image")));
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(376, 244);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(80, 29);
            this.btCancel.TabIndex = 6;
            this.btCancel.Tag = "Cancel";
            this.btCancel.Text = "&Hủy bỏ";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbGiaNTXT);
            this.groupBox1.Controls.Add(this.rdbGiaBQTT);
            this.groupBox1.Controls.Add(this.rdbGiaBQTH);
            this.groupBox1.Location = new System.Drawing.Point(122, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 91);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "Method";
            this.groupBox1.Text = "Phương pháp tính";
            // 
            // rdbGiaNTXT
            // 
            this.rdbGiaNTXT.AutoSize = true;
            this.rdbGiaNTXT.Enabled = false;
            this.rdbGiaNTXT.Location = new System.Drawing.Point(27, 65);
            this.rdbGiaNTXT.Name = "rdbGiaNTXT";
            this.rdbGiaNTXT.Size = new System.Drawing.Size(140, 17);
            this.rdbGiaNTXT.TabIndex = 2;
            this.rdbGiaNTXT.TabStop = true;
            this.rdbGiaNTXT.Tag = "LIFO";
            this.rdbGiaNTXT.Text = "3. Nhập trước xuất trước";
            this.rdbGiaNTXT.UseVisualStyleBackColor = true;
            // 
            // rdbGiaBQTT
            // 
            this.rdbGiaBQTT.AutoSize = true;
            this.rdbGiaBQTT.Enabled = false;
            this.rdbGiaBQTT.Location = new System.Drawing.Point(27, 42);
            this.rdbGiaBQTT.Name = "rdbGiaBQTT";
            this.rdbGiaBQTT.Size = new System.Drawing.Size(123, 17);
            this.rdbGiaBQTT.TabIndex = 1;
            this.rdbGiaBQTT.TabStop = true;
            this.rdbGiaBQTT.Tag = "BQTUCTHOI";
            this.rdbGiaBQTT.Text = "2. Bình quân tức thời";
            this.rdbGiaBQTT.UseVisualStyleBackColor = true;
            // 
            // rdbGiaBQTH
            // 
            this.rdbGiaBQTH.AutoSize = true;
            this.rdbGiaBQTH.Enabled = false;
            this.rdbGiaBQTH.Location = new System.Drawing.Point(27, 19);
            this.rdbGiaBQTH.Name = "rdbGiaBQTH";
            this.rdbGiaBQTH.Size = new System.Drawing.Size(115, 17);
            this.rdbGiaBQTH.TabIndex = 0;
            this.rdbGiaBQTH.TabStop = true;
            this.rdbGiaBQTH.Tag = "BQTHANG";
            this.rdbGiaBQTH.Text = "1. Bình quân tháng";
            this.rdbGiaBQTH.UseVisualStyleBackColor = true;
            // 
            // txtNgay_Ct2
            // 
            this.txtNgay_Ct2.bAllowEmpty = true;
            this.txtNgay_Ct2.bRequire = false;
            this.txtNgay_Ct2.bSelectOnFocus = true;
            this.txtNgay_Ct2.bShowDateTimePicker = true;
            this.txtNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_Ct2.Location = new System.Drawing.Point(122, 54);
            this.txtNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_Ct2.Mask = "00/00/0000";
            this.txtNgay_Ct2.Name = "txtNgay_Ct2";
            this.txtNgay_Ct2.Size = new System.Drawing.Size(74, 20);
            this.txtNgay_Ct2.TabIndex = 1;
            this.txtNgay_Ct2.Tag = "Ngay_Ct2";
            // 
            // txtNgay_Ct1
            // 
            this.txtNgay_Ct1.bAllowEmpty = true;
            this.txtNgay_Ct1.bRequire = false;
            this.txtNgay_Ct1.bSelectOnFocus = true;
            this.txtNgay_Ct1.bShowDateTimePicker = true;
            this.txtNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_Ct1.Location = new System.Drawing.Point(122, 31);
            this.txtNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_Ct1.Mask = "00/00/0000";
            this.txtNgay_Ct1.Name = "txtNgay_Ct1";
            this.txtNgay_Ct1.Size = new System.Drawing.Size(74, 20);
            this.txtNgay_Ct1.TabIndex = 0;
            this.txtNgay_Ct1.Tag = "Ngay_Ct1";
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(37, 34);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(46, 13);
            this.lblControl1.TabIndex = 2;
            this.lblControl1.Tag = "Ngay_Ct1";
            this.lblControl1.Text = "Từ ngày";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(37, 57);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(53, 13);
            this.lblControl2.TabIndex = 2;
            this.lblControl2.Tag = "Den_Ngay";
            this.lblControl2.Text = "Đến ngày";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Vt
            // 
            this.txtMa_Vt.bEnabled = true;
            this.txtMa_Vt.bIsLookup = false;
            this.txtMa_Vt.bReadOnly = false;
            this.txtMa_Vt.bRequire = false;
            this.txtMa_Vt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Vt.KeyFilter = "Ma_Vt";
            this.txtMa_Vt.Location = new System.Drawing.Point(122, 77);
            this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt.Name = "txtMa_Vt";
            this.txtMa_Vt.Size = new System.Drawing.Size(101, 20);
            this.txtMa_Vt.TabIndex = 2;
            this.txtMa_Vt.UseAutoFilter = true;
            // 
            // txtMa_Kho
            // 
            this.txtMa_Kho.bEnabled = true;
            this.txtMa_Kho.bIsLookup = false;
            this.txtMa_Kho.bReadOnly = false;
            this.txtMa_Kho.bRequire = false;
            this.txtMa_Kho.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Kho.KeyFilter = "Ma_Kho";
            this.txtMa_Kho.Location = new System.Drawing.Point(122, 100);
            this.txtMa_Kho.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Kho.Name = "txtMa_Kho";
            this.txtMa_Kho.Size = new System.Drawing.Size(101, 20);
            this.txtMa_Kho.TabIndex = 3;
            this.txtMa_Kho.UseAutoFilter = true;
            // 
            // frmGiaVon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(486, 284);
            this.Controls.Add(this.txtMa_Vt);
            this.Controls.Add(this.txtMa_Kho);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbtTen_Kho);
            this.Controls.Add(this.lblMa_Kho);
            this.Controls.Add(this.lbtTen_Vt);
            this.Controls.Add(this.lblControl2);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNgay_Ct1);
            this.Controls.Add(this.txtNgay_Ct2);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Name = "frmGiaVon";
            this.Tag = "frmGiaVon";
            this.Text = "frmGiaVon";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Epoint.Systems.Controls.btControl btOk;
		private Epoint.Systems.Controls.lblControl label1;
        private Epoint.Systems.Controls.lbtControl lbtTen_Vt;
		private Epoint.Systems.Controls.lblControl lblMa_Kho;
		private Epoint.Systems.Controls.lbtControl lbtTen_Kho;
		private Epoint.Systems.Controls.btControl btCancel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rdbGiaBQTT;
		private System.Windows.Forms.RadioButton rdbGiaBQTH;
		private System.Windows.Forms.RadioButton rdbGiaNTXT;
		private Epoint.Systems.Controls.txtDateTime txtNgay_Ct2;
		private Epoint.Systems.Controls.txtDateTime txtNgay_Ct1;
		private Epoint.Systems.Controls.lblControl lblControl1;
        private Epoint.Systems.Controls.lblControl lblControl2;
        private Systems.Controls.txtTextLookup txtMa_Vt;
        private Systems.Controls.txtTextLookup txtMa_Kho;
	}
}