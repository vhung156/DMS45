namespace Epoint.Modules
{
	partial class frmDuyet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDuyet));
            this.dteNgay_Ct = new Epoint.Systems.Controls.txtDateTime();
            this.lblNgay_Ct1 = new Epoint.Systems.Controls.lblControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtMa_CbNV_GH = new Epoint.Systems.Controls.txtTextLookup();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.txtDuyet_Log = new Epoint.Systems.Controls.txtTextBox();
            this.chkDuyet = new Epoint.Systems.Controls.chkControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblControl3 = new Epoint.Systems.Controls.lblControl();
            this.txtCreate_Log = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl4 = new Epoint.Systems.Controls.lblControl();
            this.txtSo_Ct_Lap = new Epoint.Systems.Controls.txtTextBox();
            this.btSave = new Epoint.Systems.Controls.btControl();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dteNgay_Ct
            // 
            this.dteNgay_Ct.bAllowEmpty = true;
            this.dteNgay_Ct.bRequire = false;
            this.dteNgay_Ct.bSelectOnFocus = false;
            this.dteNgay_Ct.bShowDateTimePicker = true;
            this.dteNgay_Ct.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct.Enabled = false;
            this.dteNgay_Ct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct.Location = new System.Drawing.Point(108, 66);
            this.dteNgay_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct.Mask = "00/00/0000";
            this.dteNgay_Ct.Name = "dteNgay_Ct";
            this.dteNgay_Ct.Size = new System.Drawing.Size(68, 20);
            this.dteNgay_Ct.TabIndex = 1;
            // 
            // lblNgay_Ct1
            // 
            this.lblNgay_Ct1.AutoEllipsis = true;
            this.lblNgay_Ct1.AutoSize = true;
            this.lblNgay_Ct1.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay_Ct1.Location = new System.Drawing.Point(12, 69);
            this.lblNgay_Ct1.Name = "lblNgay_Ct1";
            this.lblNgay_Ct1.Size = new System.Drawing.Size(45, 13);
            this.lblNgay_Ct1.TabIndex = 91;
            this.lblNgay_Ct1.Tag = "";
            this.lblNgay_Ct1.Text = "Ngày Ct";
            this.lblNgay_Ct1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(423, 279);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtMa_CbNV_GH);
            this.tabPage3.Controls.Add(this.lblControl1);
            this.tabPage3.Controls.Add(this.lblControl2);
            this.tabPage3.Controls.Add(this.txtDuyet_Log);
            this.tabPage3.Controls.Add(this.chkDuyet);
            this.tabPage3.Controls.Add(this.dteNgay_Ct);
            this.tabPage3.Controls.Add(this.lblNgay_Ct1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(415, 253);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Duyệt";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtMa_CbNV_GH
            // 
            this.txtMa_CbNV_GH.bEnabled = true;
            this.txtMa_CbNV_GH.bIsLookup = false;
            this.txtMa_CbNV_GH.bReadOnly = false;
            this.txtMa_CbNV_GH.bRequire = false;
            this.txtMa_CbNV_GH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_CbNV_GH.ColumnsView = null;
            this.txtMa_CbNV_GH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_CbNV_GH.KeyFilter = "Ma_CBNV";
            this.txtMa_CbNV_GH.Location = new System.Drawing.Point(109, 44);
            this.txtMa_CbNV_GH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_CbNV_GH.Name = "txtMa_CbNV_GH";
            this.txtMa_CbNV_GH.Size = new System.Drawing.Size(136, 20);
            this.txtMa_CbNV_GH.TabIndex = 96;
            this.txtMa_CbNV_GH.UseAutoFilter = true;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblControl1.Location = new System.Drawing.Point(13, 51);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(72, 13);
            this.lblControl1.TabIndex = 97;
            this.lblControl1.Tag = "";
            this.lblControl1.Text = "NV giao hàng";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(12, 93);
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
            this.txtDuyet_Log.Location = new System.Drawing.Point(108, 90);
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
            this.chkDuyet.Size = new System.Drawing.Size(99, 17);
            this.chkDuyet.TabIndex = 0;
            this.chkDuyet.Tag = "Duyet";
            this.chkDuyet.Text = "Duyệt chứng từ";
            this.chkDuyet.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblControl3);
            this.tabPage1.Controls.Add(this.txtCreate_Log);
            this.tabPage1.Controls.Add(this.lblControl4);
            this.tabPage1.Controls.Add(this.txtSo_Ct_Lap);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(415, 253);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Lập";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblControl3
            // 
            this.lblControl3.AutoEllipsis = true;
            this.lblControl3.AutoSize = true;
            this.lblControl3.BackColor = System.Drawing.Color.Transparent;
            this.lblControl3.Location = new System.Drawing.Point(18, 60);
            this.lblControl3.Name = "lblControl3";
            this.lblControl3.Size = new System.Drawing.Size(61, 13);
            this.lblControl3.TabIndex = 101;
            this.lblControl3.Tag = "";
            this.lblControl3.Text = "Nhật ký lập";
            this.lblControl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreate_Log
            // 
            this.txtCreate_Log.bEnabled = true;
            this.txtCreate_Log.bIsLookup = false;
            this.txtCreate_Log.bReadOnly = false;
            this.txtCreate_Log.bRequire = false;
            this.txtCreate_Log.Enabled = false;
            this.txtCreate_Log.KeyFilter = "";
            this.txtCreate_Log.Location = new System.Drawing.Point(114, 57);
            this.txtCreate_Log.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtCreate_Log.MaxLength = 20;
            this.txtCreate_Log.Name = "txtCreate_Log";
            this.txtCreate_Log.Size = new System.Drawing.Size(136, 20);
            this.txtCreate_Log.TabIndex = 2;
            this.txtCreate_Log.UseAutoFilter = false;
            // 
            // lblControl4
            // 
            this.lblControl4.AutoEllipsis = true;
            this.lblControl4.AutoSize = true;
            this.lblControl4.BackColor = System.Drawing.Color.Transparent;
            this.lblControl4.Location = new System.Drawing.Point(18, 33);
            this.lblControl4.Name = "lblControl4";
            this.lblControl4.Size = new System.Drawing.Size(50, 13);
            this.lblControl4.TabIndex = 98;
            this.lblControl4.Tag = "";
            this.lblControl4.Text = "Số Ct lập";
            this.lblControl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_Ct_Lap
            // 
            this.txtSo_Ct_Lap.bEnabled = true;
            this.txtSo_Ct_Lap.bIsLookup = false;
            this.txtSo_Ct_Lap.bReadOnly = false;
            this.txtSo_Ct_Lap.bRequire = false;
            this.txtSo_Ct_Lap.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSo_Ct_Lap.KeyFilter = "";
            this.txtSo_Ct_Lap.Location = new System.Drawing.Point(114, 33);
            this.txtSo_Ct_Lap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Ct_Lap.MaxLength = 20;
            this.txtSo_Ct_Lap.Name = "txtSo_Ct_Lap";
            this.txtSo_Ct_Lap.Size = new System.Drawing.Size(68, 20);
            this.txtSo_Ct_Lap.TabIndex = 1;
            this.txtSo_Ct_Lap.UseAutoFilter = false;
            // 
            // btSave
            // 
            this.btSave.Image = ((System.Drawing.Image)(resources.GetObject("btSave.Image")));
            this.btSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSave.Location = new System.Drawing.Point(361, 297);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(65, 31);
            this.btSave.TabIndex = 1;
            this.btSave.Tag = "Save";
            this.btSave.Text = "&Lưu";
            this.btSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // frmDuyet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 340);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDuyet";
            this.Text = "frmDuyet";
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		public Epoint.Systems.Controls.txtDateTime dteNgay_Ct;
		private Epoint.Systems.Controls.lblControl lblNgay_Ct1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage3;
		private Epoint.Systems.Controls.lblControl lblControl2;
		public Epoint.Systems.Controls.txtTextBox txtDuyet_Log;
		private Epoint.Systems.Controls.chkControl chkDuyet;
		private System.Windows.Forms.TabPage tabPage1;
        private Epoint.Systems.Controls.lblControl lblControl3;
		private Epoint.Systems.Controls.lblControl lblControl4;
		public Epoint.Systems.Controls.txtTextBox txtSo_Ct_Lap;
        private Epoint.Systems.Controls.btControl btSave;
        public Epoint.Systems.Controls.txtTextBox txtCreate_Log;
        private Systems.Controls.txtTextLookup txtMa_CbNV_GH;
        private Systems.Controls.lblControl lblControl1;
	}
}