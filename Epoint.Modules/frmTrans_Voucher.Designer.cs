namespace Epoint.Modules
{
	partial class frmTrans_Voucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrans_Voucher));
            this.btAccept = new Epoint.Systems.Controls.btControl();
            this.btCancel = new Epoint.Systems.Controls.btControl();
            this.txtNgay_Ct2 = new Epoint.Systems.Controls.txtDateTime();
            this.txtNgay_Ct1 = new Epoint.Systems.Controls.txtDateTime();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.chkAll = new Epoint.Systems.Controls.chkControl();
            this.chkDanhMuc = new Epoint.Systems.Controls.chkControl();
            this.SuspendLayout();
            // 
            // btAccept
            // 
            this.btAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAccept.ForeColor = System.Drawing.Color.MediumBlue;
            this.btAccept.Image = ((System.Drawing.Image)(resources.GetObject("btAccept.Image")));
            this.btAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAccept.Location = new System.Drawing.Point(213, 183);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new System.Drawing.Size(80, 29);
            this.btAccept.TabIndex = 5;
            this.btAccept.Tag = "";
            this.btAccept.Text = "Đồ&ng ý";
            this.btAccept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAccept.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.MediumBlue;
            this.btCancel.Image = ((System.Drawing.Image)(resources.GetObject("btCancel.Image")));
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(299, 183);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(80, 29);
            this.btCancel.TabIndex = 6;
            this.btCancel.Tag = "Cancel";
            this.btCancel.Text = "&Hủy bỏ";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // txtNgay_Ct2
            // 
            this.txtNgay_Ct2.bAllowEmpty = true;
            this.txtNgay_Ct2.bRequire = false;
            this.txtNgay_Ct2.bSelectOnFocus = true;
            this.txtNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_Ct2.Location = new System.Drawing.Point(139, 56);
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
            this.txtNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_Ct1.Location = new System.Drawing.Point(139, 33);
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
            this.lblControl1.Location = new System.Drawing.Point(54, 36);
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
            this.lblControl2.Location = new System.Drawing.Point(54, 59);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(53, 13);
            this.lblControl2.TabIndex = 2;
            this.lblControl2.Tag = "Den_Ngay";
            this.lblControl2.Text = "Đến ngày";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Checked = true;
            this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll.Location = new System.Drawing.Point(57, 107);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(126, 17);
            this.chkAll.TabIndex = 120;
            this.chkAll.Tag = "";
            this.chkAll.Text = "Chuyển tất cả dữ liệu";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // chkDanhMuc
            // 
            this.chkDanhMuc.AutoSize = true;
            this.chkDanhMuc.Checked = true;
            this.chkDanhMuc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDanhMuc.Location = new System.Drawing.Point(57, 130);
            this.chkDanhMuc.Name = "chkDanhMuc";
            this.chkDanhMuc.Size = new System.Drawing.Size(149, 17);
            this.chkDanhMuc.TabIndex = 120;
            this.chkDanhMuc.Tag = "";
            this.chkDanhMuc.Text = "Chuyển  dữ liệu danh mục";
            this.chkDanhMuc.UseVisualStyleBackColor = true;
            // 
            // frmTrans_Voucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(406, 224);
            this.Controls.Add(this.chkDanhMuc);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.lblControl2);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.txtNgay_Ct1);
            this.Controls.Add(this.txtNgay_Ct2);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btAccept);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTrans_Voucher";
            this.Text = "frmTrans_Voucher";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.btControl btAccept;
		private Epoint.Systems.Controls.btControl btCancel;
		private Epoint.Systems.Controls.txtDateTime txtNgay_Ct2;
		private Epoint.Systems.Controls.txtDateTime txtNgay_Ct1;
		private Epoint.Systems.Controls.lblControl lblControl1;
        private Epoint.Systems.Controls.lblControl lblControl2;
        private Epoint.Systems.Controls.chkControl chkAll;
        private Epoint.Systems.Controls.chkControl chkDanhMuc;
	}
}