namespace Epoint.Modules.GL
{
    partial class frmKetChuyen_View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKetChuyen_View));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btKet_Chuyen = new Epoint.Systems.Controls.btControl();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btKet_Chuyen);
            this.splitContainer1.Size = new System.Drawing.Size(792, 569);
            this.splitContainer1.SplitterDistance = 520;
            this.splitContainer1.TabIndex = 0;
            // 
            // btKet_Chuyen
            // 
            this.btKet_Chuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btKet_Chuyen.Image = ((System.Drawing.Image)(resources.GetObject("btKet_Chuyen.Image")));
            this.btKet_Chuyen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btKet_Chuyen.Location = new System.Drawing.Point(41, 8);
            this.btKet_Chuyen.Name = "btKet_Chuyen";
            this.btKet_Chuyen.Size = new System.Drawing.Size(114, 29);
            this.btKet_Chuyen.TabIndex = 65;
            this.btKet_Chuyen.Tag = "Ket_Chuyen";
            this.btKet_Chuyen.Text = "&Kết chuyển";
            this.btKet_Chuyen.UseVisualStyleBackColor = true;
            // 
            // frmKetChuyen_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 569);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmKetChuyen_View";
            this.Object_ID = "DMKHO";
            this.Tag = "F2, F3, F8, ESC,F10,CTRL_F10";
            this.Text = "frmKetChuyen_View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Systems.Controls.btControl btKet_Chuyen;

	}
}