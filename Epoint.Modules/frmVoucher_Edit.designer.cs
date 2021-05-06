namespace Epoint.Modules
{
	partial class frmVoucher_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVoucher_Edit));
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.ucNotice = new Epoint.Modules.ucNotice();
            this.lineControl1 = new Epoint.Systems.Controls.lineControl();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(690, 529);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(180, 28);
            this.btgAccept.TabIndex = 107;
            // 
            // ucNotice
            // 
            this.ucNotice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucNotice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ucNotice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucNotice.Location = new System.Drawing.Point(12, 529);
            this.ucNotice.Name = "ucNotice";
            this.ucNotice.Size = new System.Drawing.Size(583, 30);
            this.ucNotice.TabIndex = 108;
            // 
            // lineControl1
            // 
            this.lineControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineControl1.AutoEllipsis = true;
            this.lineControl1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lineControl1.Location = new System.Drawing.Point(0, 525);
            this.lineControl1.Name = "lineControl1";
            this.lineControl1.Size = new System.Drawing.Size(893, 1);
            this.lineControl1.TabIndex = 110;
            this.lineControl1.Text = "lineControl1";
            this.lineControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmVoucher_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 569);
            this.Controls.Add(this.lineControl1);
            this.Controls.Add(this.ucNotice);
            this.Controls.Add(this.btgAccept);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVoucher_Edit";
            this.Text = "frmVoucher";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

		}

		#endregion

		public Epoint.Systems.Customizes.btgAccept btgAccept;
		public ucNotice ucNotice;
        public Systems.Controls.lineControl lineControl1;
    }
}