namespace Epoint.Modules
{
	partial class frmIn_Ct_Khac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIn_Ct_Khac));
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.chkInVisibleNextPrint = new System.Windows.Forms.CheckBox();
            this.cboMau_In = new System.Windows.Forms.ComboBox();
            this.grChon = new System.Windows.Forms.GroupBox();
            this.chkIs_Doc_Tien1 = new System.Windows.Forms.CheckBox();
            this.grChon.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(294, 150);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 29);
            this.btgAccept.TabIndex = 14;
            // 
            // chkInVisibleNextPrint
            // 
            this.chkInVisibleNextPrint.AutoSize = true;
            this.chkInVisibleNextPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInVisibleNextPrint.ForeColor = System.Drawing.Color.Blue;
            this.chkInVisibleNextPrint.Location = new System.Drawing.Point(41, 72);
            this.chkInVisibleNextPrint.Name = "chkInVisibleNextPrint";
            this.chkInVisibleNextPrint.Size = new System.Drawing.Size(168, 17);
            this.chkInVisibleNextPrint.TabIndex = 129;
            this.chkInVisibleNextPrint.Tag = "InVisibleNextPrint";
            this.chkInVisibleNextPrint.Text = "Không xuất hiện khi in lần sau";
            this.chkInVisibleNextPrint.UseVisualStyleBackColor = true;
            // 
            // cboMau_In
            // 
            this.cboMau_In.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboMau_In.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMau_In.FormattingEnabled = true;
            this.cboMau_In.Location = new System.Drawing.Point(41, 33);
            this.cboMau_In.Name = "cboMau_In";
            this.cboMau_In.Size = new System.Drawing.Size(191, 21);
            this.cboMau_In.TabIndex = 130;
            this.cboMau_In.Text = "Phiếu chi tiền mặt";
            // 
            // grChon
            // 
            this.grChon.Controls.Add(this.cboMau_In);
            this.grChon.Controls.Add(this.chkInVisibleNextPrint);
            this.grChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grChon.ForeColor = System.Drawing.Color.Blue;
            this.grChon.Location = new System.Drawing.Point(34, 18);
            this.grChon.Name = "grChon";
            this.grChon.Size = new System.Drawing.Size(341, 120);
            this.grChon.TabIndex = 131;
            this.grChon.TabStop = false;
            this.grChon.Text = "Chọn mẫu in";
            // 
            // chkIs_Doc_Tien1
            // 
            this.chkIs_Doc_Tien1.AutoSize = true;
            this.chkIs_Doc_Tien1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIs_Doc_Tien1.ForeColor = System.Drawing.Color.Blue;
            this.chkIs_Doc_Tien1.Location = new System.Drawing.Point(75, 113);
            this.chkIs_Doc_Tien1.Name = "chkIs_Doc_Tien1";
            this.chkIs_Doc_Tien1.Size = new System.Drawing.Size(184, 17);
            this.chkIs_Doc_Tien1.TabIndex = 131;
            this.chkIs_Doc_Tien1.Tag = "Is_Doc_Tien1";
            this.chkIs_Doc_Tien1.Text = "Không hiển thị đọc tiền bằng chữ";
            this.chkIs_Doc_Tien1.UseVisualStyleBackColor = true;
            // 
            // frmIn_Ct_Khac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 191);
            this.Controls.Add(this.chkIs_Doc_Tien1);
            this.Controls.Add(this.grChon);
            this.Controls.Add(this.btgAccept);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIn_Ct_Khac";
            this.Tag = "frmIn_Ct_Khac";
            this.Text = "frmIn_Ct_Khac";
            this.grChon.ResumeLayout(false);
            this.grChon.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Epoint.Systems.Customizes.btgAccept btgAccept;
        public System.Windows.Forms.CheckBox chkInVisibleNextPrint;
        public System.Windows.Forms.ComboBox cboMau_In;
        private System.Windows.Forms.GroupBox grChon;
        public System.Windows.Forms.CheckBox chkIs_Doc_Tien1;
	}
}