namespace Epoint.Lists
{
	partial class frmEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEdit));
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.tabEdit = new Epoint.Systems.Controls.tabControl();
            this.Page1 = new System.Windows.Forms.TabPage();
            this.Page2 = new System.Windows.Forms.TabPage();
            this.lblMa_Data = new Epoint.Systems.Controls.lblControl();
            this.lblNgay_End = new Epoint.Systems.Controls.lblControl();
            this.lblNgay_Begin = new Epoint.Systems.Controls.lblControl();
            this.ucMa_Data = new Epoint.Systems.Customizes.ucMa_Data();
            this.txtNgay_End = new Epoint.Systems.Customizes.txtNgay_End();
            this.txtNgay_Begin = new Epoint.Systems.Customizes.txtNgay_Begin();
            this.tabEdit.SuspendLayout();
            this.Page2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(333, 198);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(169, 33);
            this.btgAccept.TabIndex = 3;
            // 
            // tabEdit
            // 
            this.tabEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabEdit.Controls.Add(this.Page1);
            this.tabEdit.Controls.Add(this.Page2);
            this.tabEdit.Location = new System.Drawing.Point(12, 10);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.SelectedIndex = 0;
            this.tabEdit.Size = new System.Drawing.Size(506, 184);
            this.tabEdit.TabIndex = 2;
            // 
            // Page1
            // 
            this.Page1.Location = new System.Drawing.Point(4, 22);
            this.Page1.Name = "Page1";
            this.Page1.Padding = new System.Windows.Forms.Padding(3);
            this.Page1.Size = new System.Drawing.Size(498, 158);
            this.Page1.TabIndex = 0;
            this.Page1.Tag = "Detail_Info";
            this.Page1.Text = "Thông tin";
            this.Page1.UseVisualStyleBackColor = true;
            // 
            // Page2
            // 
            this.Page2.Controls.Add(this.lblMa_Data);
            this.Page2.Controls.Add(this.lblNgay_End);
            this.Page2.Controls.Add(this.lblNgay_Begin);
            this.Page2.Controls.Add(this.ucMa_Data);
            this.Page2.Controls.Add(this.txtNgay_End);
            this.Page2.Controls.Add(this.txtNgay_Begin);
            this.Page2.Location = new System.Drawing.Point(4, 22);
            this.Page2.Name = "Page2";
            this.Page2.Size = new System.Drawing.Size(498, 158);
            this.Page2.TabIndex = 5;
            this.Page2.Tag = "Extra_Detail_Info";
            this.Page2.Text = "Khác";
            this.Page2.UseVisualStyleBackColor = true;
            // 
            // lblMa_Data
            // 
            this.lblMa_Data.AutoEllipsis = true;
            this.lblMa_Data.AutoSize = true;
            this.lblMa_Data.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Data.Location = new System.Drawing.Point(22, 71);
            this.lblMa_Data.Name = "lblMa_Data";
            this.lblMa_Data.Size = new System.Drawing.Size(56, 13);
            this.lblMa_Data.TabIndex = 3;
            this.lblMa_Data.Tag = "Ma_Data";
            this.lblMa_Data.Text = "Mã dữ liệu";
            this.lblMa_Data.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgay_End
            // 
            this.lblNgay_End.AutoEllipsis = true;
            this.lblNgay_End.AutoSize = true;
            this.lblNgay_End.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay_End.Location = new System.Drawing.Point(22, 47);
            this.lblNgay_End.Name = "lblNgay_End";
            this.lblNgay_End.Size = new System.Drawing.Size(74, 13);
            this.lblNgay_End.TabIndex = 3;
            this.lblNgay_End.Tag = "Ngay_End";
            this.lblNgay_End.Text = "Ngày kết thúc";
            this.lblNgay_End.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgay_Begin
            // 
            this.lblNgay_Begin.AutoEllipsis = true;
            this.lblNgay_Begin.AutoSize = true;
            this.lblNgay_Begin.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay_Begin.Location = new System.Drawing.Point(22, 23);
            this.lblNgay_Begin.Name = "lblNgay_Begin";
            this.lblNgay_Begin.Size = new System.Drawing.Size(72, 13);
            this.lblNgay_Begin.TabIndex = 3;
            this.lblNgay_Begin.Tag = "Ngay_Begin";
            this.lblNgay_Begin.Text = "Ngày bắt đầu";
            this.lblNgay_Begin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucMa_Data
            // 
            this.ucMa_Data.Location = new System.Drawing.Point(116, 67);
            this.ucMa_Data.Name = "ucMa_Data";
            this.ucMa_Data.Size = new System.Drawing.Size(99, 24);
            this.ucMa_Data.TabIndex = 2;
            // 
            // txtNgay_End
            // 
            this.txtNgay_End.bAllowEmpty = true;
            this.txtNgay_End.bRequire = false;
            this.txtNgay_End.bSelectOnFocus = false;
            this.txtNgay_End.bShowDateTimePicker = true;
            this.txtNgay_End.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_End.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_End.Location = new System.Drawing.Point(116, 44);
            this.txtNgay_End.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_End.Mask = "00/00/0000";
            this.txtNgay_End.Name = "txtNgay_End";
            this.txtNgay_End.Size = new System.Drawing.Size(74, 20);
            this.txtNgay_End.TabIndex = 1;
            // 
            // txtNgay_Begin
            // 
            this.txtNgay_Begin.bAllowEmpty = true;
            this.txtNgay_Begin.bRequire = false;
            this.txtNgay_Begin.bSelectOnFocus = false;
            this.txtNgay_Begin.bShowDateTimePicker = true;
            this.txtNgay_Begin.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_Begin.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_Begin.Location = new System.Drawing.Point(116, 20);
            this.txtNgay_Begin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_Begin.Mask = "00/00/0000";
            this.txtNgay_Begin.Name = "txtNgay_Begin";
            this.txtNgay_Begin.Size = new System.Drawing.Size(74, 20);
            this.txtNgay_Begin.TabIndex = 0;
            // 
            // frmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 240);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.tabEdit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEdit";
            this.Text = "frmEdit";
            this.tabEdit.ResumeLayout(false);
            this.Page2.ResumeLayout(false);
            this.Page2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		public Epoint.Systems.Customizes.btgAccept btgAccept;
		public Epoint.Systems.Controls.tabControl tabEdit;
		public System.Windows.Forms.TabPage Page1;
		public System.Windows.Forms.TabPage Page2;
		public Epoint.Systems.Customizes.txtNgay_End txtNgay_End;
		public Epoint.Systems.Customizes.txtNgay_Begin txtNgay_Begin;
		public Epoint.Systems.Controls.lblControl lblNgay_Begin;
		public Epoint.Systems.Customizes.ucMa_Data ucMa_Data;
		public Epoint.Systems.Controls.lblControl lblMa_Data;
		public Epoint.Systems.Controls.lblControl lblNgay_End;
	}
}