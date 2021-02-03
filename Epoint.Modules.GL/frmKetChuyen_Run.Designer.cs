namespace Epoint.Modules.GL
{
    partial class frmKetChuyen_Run
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
            this.numThang1 = new Epoint.Systems.Controls.numControl();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.lblControl6 = new Epoint.Systems.Controls.lblControl();
            this.numThang2 = new Epoint.Systems.Controls.numControl();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.SuspendLayout();
            // 
            // numThang1
            // 
            this.numThang1.bEnabled = true;
            this.numThang1.bFormat = true;
            this.numThang1.bIsLookup = false;
            this.numThang1.bReadOnly = false;
            this.numThang1.bRequire = true;
            this.numThang1.KeyFilter = "";
            this.numThang1.Location = new System.Drawing.Point(90, 26);
            this.numThang1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numThang1.Name = "numThang1";
            this.numThang1.Scale = 0;
            this.numThang1.Size = new System.Drawing.Size(39, 20);
            this.numThang1.TabIndex = 0;
            this.numThang1.Text = "0";
            this.numThang1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numThang1.UseAutoFilter = false;
            this.numThang1.Value = 0D;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(210, 101);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(186, 30);
            this.btgAccept.TabIndex = 2;
            // 
            // lblControl6
            // 
            this.lblControl6.AutoEllipsis = true;
            this.lblControl6.AutoSize = true;
            this.lblControl6.BackColor = System.Drawing.Color.Transparent;
            this.lblControl6.Location = new System.Drawing.Point(27, 26);
            this.lblControl6.Name = "lblControl6";
            this.lblControl6.Size = new System.Drawing.Size(50, 13);
            this.lblControl6.TabIndex = 34;
            this.lblControl6.Tag = "Thang1";
            this.lblControl6.Text = "Từ tháng";
            this.lblControl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numThang2
            // 
            this.numThang2.bEnabled = true;
            this.numThang2.bFormat = true;
            this.numThang2.bIsLookup = false;
            this.numThang2.bReadOnly = false;
            this.numThang2.bRequire = true;
            this.numThang2.KeyFilter = "";
            this.numThang2.Location = new System.Drawing.Point(90, 55);
            this.numThang2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numThang2.Name = "numThang2";
            this.numThang2.Scale = 0;
            this.numThang2.Size = new System.Drawing.Size(39, 20);
            this.numThang2.TabIndex = 1;
            this.numThang2.Text = "0";
            this.numThang2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numThang2.UseAutoFilter = false;
            this.numThang2.Value = 0D;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(27, 57);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(57, 13);
            this.lblControl1.TabIndex = 34;
            this.lblControl1.Tag = "Thang2";
            this.lblControl1.Text = "Đến tháng";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmKetChuyen_Run
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 143);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.lblControl6);
            this.Controls.Add(this.numThang2);
            this.Controls.Add(this.numThang1);
            this.Name = "frmKetChuyen_Run";
            this.Tag = "frmKetChuyen, ESC";
            this.Text = "frmKetChuyen_Run";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        public Epoint.Systems.Customizes.btgAccept btgAccept;
        private Epoint.Systems.Controls.lblControl lblControl6;
        private Epoint.Systems.Controls.lblControl lblControl1;
        public Epoint.Systems.Controls.numControl numThang2;
        public Epoint.Systems.Controls.numControl numThang1;

	}
}