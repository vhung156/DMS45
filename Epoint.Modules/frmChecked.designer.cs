namespace Epoint.Modules
{
	partial class frmChecked
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpRevised = new System.Windows.Forms.TabPage();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.txtDuyet_Log = new Epoint.Systems.Controls.txtTextBox();
            this.chkDuyet = new Epoint.Systems.Controls.chkControl();
            this.btSave = new Epoint.Systems.Controls.btControl();
            this.tabControl1.SuspendLayout();
            this.tpRevised.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpRevised);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(400, 141);
            this.tabControl1.TabIndex = 0;
            // 
            // tpRevised
            // 
            this.tpRevised.Controls.Add(this.lblControl2);
            this.tpRevised.Controls.Add(this.txtDuyet_Log);
            this.tpRevised.Controls.Add(this.chkDuyet);
            this.tpRevised.Location = new System.Drawing.Point(4, 22);
            this.tpRevised.Name = "tpRevised";
            this.tpRevised.Padding = new System.Windows.Forms.Padding(3);
            this.tpRevised.Size = new System.Drawing.Size(392, 115);
            this.tpRevised.TabIndex = 1;
            this.tpRevised.Text = "Duyệt";
            this.tpRevised.UseVisualStyleBackColor = true;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(12, 43);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(73, 13);
            this.lblControl2.TabIndex = 95;
            this.lblControl2.Tag = "";
            this.lblControl2.Text = "Nhật ký duyệt";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDuyet_Log
            // 
            this.txtDuyet_Log.bEnabled = true;
            this.txtDuyet_Log.bIsLookup = false;
            this.txtDuyet_Log.bReadOnly = false;
            this.txtDuyet_Log.bRequire = false;
            this.txtDuyet_Log.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDuyet_Log.Enabled = false;
            this.txtDuyet_Log.KeyFilter = "";
            this.txtDuyet_Log.Location = new System.Drawing.Point(108, 40);
            this.txtDuyet_Log.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDuyet_Log.MaxLength = 20;
            this.txtDuyet_Log.Name = "txtDuyet_Log";
            this.txtDuyet_Log.Size = new System.Drawing.Size(136, 20);
            this.txtDuyet_Log.TabIndex = 3;
            this.txtDuyet_Log.UseAutoFilter = false;
            // 
            // chkDuyet
            // 
            this.chkDuyet.AutoSize = true;
            this.chkDuyet.Location = new System.Drawing.Point(108, 20);
            this.chkDuyet.Name = "chkDuyet";
            this.chkDuyet.Size = new System.Drawing.Size(142, 17);
            this.chkDuyet.TabIndex = 0;
            this.chkDuyet.Text = "Chứng từ đã được duyệt";
            this.chkDuyet.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Location = new System.Drawing.Point(334, 158);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 31);
            this.btSave.TabIndex = 1;
            this.btSave.Tag = "Save";
            this.btSave.Text = "&Lưu";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // frmChecked
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 195);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChecked";
            this.Text = "Duyệt chứng từ";
            this.tabControl1.ResumeLayout(false);
            this.tpRevised.ResumeLayout(false);
            this.tpRevised.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tpRevised;
		private Epoint.Systems.Controls.lblControl lblControl2;
		public Epoint.Systems.Controls.txtTextBox txtDuyet_Log;
		private Epoint.Systems.Controls.chkControl chkDuyet;
        private Epoint.Systems.Controls.btControl btSave;
	}
}