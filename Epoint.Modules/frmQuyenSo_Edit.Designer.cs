namespace Epoint.Modules
{
	partial class frmQuyenSo_Edit
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
            this.lblTen = new Epoint.Systems.Controls.lblControl();
            this.dteNgay_Begin = new Epoint.Systems.Controls.txtDateTime();
            this.lbNgay_Begin = new Epoint.Systems.Controls.lblControl();
            this.lbMa_Quyen = new Epoint.Systems.Controls.lblControl();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.txtMa_Quyen = new Epoint.Systems.Controls.txtTextLookup();
            this.txtQuyen_So = new Epoint.Systems.Controls.txtTextLookup();
            this.txtNgay_End = new Epoint.Systems.Controls.txtDateTime();
            this.lblNgay_End = new Epoint.Systems.Controls.lblControl();
            this.SuspendLayout();
            // 
            // lblTen
            // 
            this.lblTen.AutoEllipsis = true;
            this.lblTen.AutoSize = true;
            this.lblTen.BackColor = System.Drawing.Color.Transparent;
            this.lblTen.Location = new System.Drawing.Point(43, 50);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(52, 13);
            this.lblTen.TabIndex = 69;
            this.lblTen.Tag = "";
            this.lblTen.Text = "Quyển số";
            this.lblTen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Begin
            // 
            this.dteNgay_Begin.bAllowEmpty = true;
            this.dteNgay_Begin.bRequire = false;
            this.dteNgay_Begin.bSelectOnFocus = false;
            this.dteNgay_Begin.bShowDateTimePicker = true;
            this.dteNgay_Begin.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Begin.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Begin.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Begin.Location = new System.Drawing.Point(128, 71);
            this.dteNgay_Begin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Begin.Mask = "00/00/0000";
            this.dteNgay_Begin.Name = "dteNgay_Begin";
            this.dteNgay_Begin.Size = new System.Drawing.Size(120, 20);
            this.dteNgay_Begin.TabIndex = 2;
            // 
            // lbNgay_Begin
            // 
            this.lbNgay_Begin.AutoEllipsis = true;
            this.lbNgay_Begin.AutoSize = true;
            this.lbNgay_Begin.BackColor = System.Drawing.Color.Transparent;
            this.lbNgay_Begin.Location = new System.Drawing.Point(43, 74);
            this.lbNgay_Begin.Name = "lbNgay_Begin";
            this.lbNgay_Begin.Size = new System.Drawing.Size(47, 13);
            this.lbNgay_Begin.TabIndex = 66;
            this.lbNgay_Begin.Tag = "";
            this.lbNgay_Begin.Text = "Ngày áp";
            this.lbNgay_Begin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Quyen
            // 
            this.lbMa_Quyen.AutoEllipsis = true;
            this.lbMa_Quyen.AutoSize = true;
            this.lbMa_Quyen.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_Quyen.Location = new System.Drawing.Point(43, 26);
            this.lbMa_Quyen.Name = "lbMa_Quyen";
            this.lbMa_Quyen.Size = new System.Drawing.Size(22, 13);
            this.lbMa_Quyen.TabIndex = 65;
            this.lbMa_Quyen.Tag = "";
            this.lbMa_Quyen.Text = "Mã";
            this.lbMa_Quyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(292, 140);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 29);
            this.btgAccept.TabIndex = 4;
            // 
            // txtMa_Quyen
            // 
            this.txtMa_Quyen.bEnabled = true;
            this.txtMa_Quyen.bIsLookup = false;
            this.txtMa_Quyen.bReadOnly = false;
            this.txtMa_Quyen.bRequire = false;
            this.txtMa_Quyen.ColumnsView = null;
            this.txtMa_Quyen.KeyFilter = "";
            this.txtMa_Quyen.Location = new System.Drawing.Point(128, 23);
            this.txtMa_Quyen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Quyen.Name = "txtMa_Quyen";
            this.txtMa_Quyen.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Quyen.TabIndex = 0;
            this.txtMa_Quyen.UseAutoFilter = false;
            // 
            // txtQuyen_So
            // 
            this.txtQuyen_So.bEnabled = true;
            this.txtQuyen_So.bIsLookup = false;
            this.txtQuyen_So.bReadOnly = false;
            this.txtQuyen_So.bRequire = false;
            this.txtQuyen_So.ColumnsView = null;
            this.txtQuyen_So.KeyFilter = "";
            this.txtQuyen_So.Location = new System.Drawing.Point(128, 47);
            this.txtQuyen_So.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtQuyen_So.Name = "txtQuyen_So";
            this.txtQuyen_So.Size = new System.Drawing.Size(216, 20);
            this.txtQuyen_So.TabIndex = 1;
            this.txtQuyen_So.UseAutoFilter = false;
            // 
            // txtNgay_End
            // 
            this.txtNgay_End.bAllowEmpty = true;
            this.txtNgay_End.bRequire = false;
            this.txtNgay_End.bSelectOnFocus = false;
            this.txtNgay_End.bShowDateTimePicker = true;
            this.txtNgay_End.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.txtNgay_End.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_End.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_End.Location = new System.Drawing.Point(128, 95);
            this.txtNgay_End.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_End.Mask = "00/00/0000";
            this.txtNgay_End.Name = "txtNgay_End";
            this.txtNgay_End.Size = new System.Drawing.Size(120, 20);
            this.txtNgay_End.TabIndex = 3;
            // 
            // lblNgay_End
            // 
            this.lblNgay_End.AutoEllipsis = true;
            this.lblNgay_End.AutoSize = true;
            this.lblNgay_End.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay_End.Location = new System.Drawing.Point(43, 99);
            this.lblNgay_End.Name = "lblNgay_End";
            this.lblNgay_End.Size = new System.Drawing.Size(74, 13);
            this.lblNgay_End.TabIndex = 75;
            this.lblNgay_End.Tag = "";
            this.lblNgay_End.Text = "Ngày kết thúc";
            this.lblNgay_End.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmQuyenSo_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 181);
            this.Controls.Add(this.txtNgay_End);
            this.Controls.Add(this.lblNgay_End);
            this.Controls.Add(this.txtQuyen_So);
            this.Controls.Add(this.txtMa_Quyen);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.dteNgay_Begin);
            this.Controls.Add(this.lbNgay_Begin);
            this.Controls.Add(this.lbMa_Quyen);
            this.Name = "frmQuyenSo_Edit";
            this.Tag = "";
            this.Text = "frmQuyenSo";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Epoint.Systems.Controls.lblControl lblTen;
		private Epoint.Systems.Controls.txtDateTime dteNgay_Begin;
        private Epoint.Systems.Controls.lblControl lbNgay_Begin;
		private Epoint.Systems.Controls.lblControl lbMa_Quyen;
		private Epoint.Systems.Customizes.btgAccept btgAccept;
        private Systems.Controls.txtTextLookup txtMa_Quyen;
        private Systems.Controls.txtTextLookup txtQuyen_So;
        private Systems.Controls.txtDateTime txtNgay_End;
        private Systems.Controls.lblControl lblNgay_End;
	}
}