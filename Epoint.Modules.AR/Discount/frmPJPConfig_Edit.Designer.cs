namespace Epoint.Modules.AR
{
    partial class frmPJPConfig_Edit
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
            this.chkActive = new Epoint.Systems.Controls.chkControl();
            this.txtTen_PJP = new Epoint.Systems.Controls.txtTextLookup();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.lblMa_PJP = new Epoint.Systems.Controls.lblControl();
            this.lbGia = new Epoint.Systems.Controls.lblControl();
            this.dteNgay_Kt = new Epoint.Systems.Controls.txtDateTime();
            this.dteNgay_BD = new Epoint.Systems.Controls.txtDateTime();
            this.lbNgay_Ap = new Epoint.Systems.Controls.lblControl();
            this.lbMa_Vt = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Cbnv = new Epoint.Systems.Controls.txtTextLookup();
            this.txtMa_PJP = new Epoint.Systems.Controls.txtTextLookup();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(416, 314);
            this.btgAccept.Size = new System.Drawing.Size(181, 29);
            this.btgAccept.TabIndex = 1;
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(588, 298);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.chkActive);
            this.Page1.Controls.Add(this.txtTen_PJP);
            this.Page1.Controls.Add(this.lbMa_Vt);
            this.Page1.Controls.Add(this.txtMa_Cbnv);
            this.Page1.Controls.Add(this.lbNgay_Ap);
            this.Page1.Controls.Add(this.txtMa_PJP);
            this.Page1.Controls.Add(this.dteNgay_BD);
            this.Page1.Controls.Add(this.lblControl1);
            this.Page1.Controls.Add(this.dteNgay_Kt);
            this.Page1.Controls.Add(this.lblMa_PJP);
            this.Page1.Controls.Add(this.lbGia);
            this.Page1.Size = new System.Drawing.Size(580, 272);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(580, 272);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActive.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkActive.Location = new System.Drawing.Point(122, 160);
            this.chkActive.Name = "chkActive";
            this.chkActive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkActive.Size = new System.Drawing.Size(77, 17);
            this.chkActive.TabIndex = 5;
            this.chkActive.Tag = "Active";
            this.chkActive.Text = "Hoạt động";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtTen_PJP
            // 
            this.txtTen_PJP.bEnabled = true;
            this.txtTen_PJP.bIsLookup = false;
            this.txtTen_PJP.bReadOnly = false;
            this.txtTen_PJP.bRequire = false;
            this.txtTen_PJP.ColumnsView = null;
            this.txtTen_PJP.CtrlDepend = null;
            this.txtTen_PJP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen_PJP.KeyFilter = "";
            this.txtTen_PJP.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtTen_PJP.ListFilter = new string[0];
            this.txtTen_PJP.Location = new System.Drawing.Point(122, 43);
            this.txtTen_PJP.LookupKeyFilter = "";
            this.txtTen_PJP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_PJP.Name = "txtTen_PJP";
            this.txtTen_PJP.Size = new System.Drawing.Size(382, 20);
            this.txtTen_PJP.TabIndex = 1;
            this.txtTen_PJP.UseAutoFilter = false;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl1.Location = new System.Drawing.Point(17, 70);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(72, 13);
            this.lblControl1.TabIndex = 143;
            this.lblControl1.Tag = "Ma_Cbnv";
            this.lblControl1.Text = "Mã nhân viên";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMa_PJP
            // 
            this.lblMa_PJP.AutoEllipsis = true;
            this.lblMa_PJP.AutoSize = true;
            this.lblMa_PJP.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_PJP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMa_PJP.Location = new System.Drawing.Point(16, 46);
            this.lblMa_PJP.Name = "lblMa_PJP";
            this.lblMa_PJP.Size = new System.Drawing.Size(48, 13);
            this.lblMa_PJP.TabIndex = 144;
            this.lblMa_PJP.Tag = "TEN_PJP";
            this.lblMa_PJP.Text = "Diễn giải";
            this.lblMa_PJP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbGia
            // 
            this.lbGia.AutoEllipsis = true;
            this.lbGia.AutoSize = true;
            this.lbGia.BackColor = System.Drawing.Color.Transparent;
            this.lbGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGia.Location = new System.Drawing.Point(17, 126);
            this.lbGia.Name = "lbGia";
            this.lbGia.Size = new System.Drawing.Size(74, 13);
            this.lbGia.TabIndex = 138;
            this.lbGia.Tag = "Ngay_Kt";
            this.lbGia.Text = "Ngày kết thúc";
            this.lbGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Kt
            // 
            this.dteNgay_Kt.bAllowEmpty = true;
            this.dteNgay_Kt.bRequire = false;
            this.dteNgay_Kt.bSelectOnFocus = false;
            this.dteNgay_Kt.bShowDateTimePicker = true;
            this.dteNgay_Kt.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Kt.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Kt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteNgay_Kt.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Kt.Location = new System.Drawing.Point(122, 123);
            this.dteNgay_Kt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Kt.Mask = "00/00/0000";
            this.dteNgay_Kt.Name = "dteNgay_Kt";
            this.dteNgay_Kt.Size = new System.Drawing.Size(111, 20);
            this.dteNgay_Kt.TabIndex = 4;
            // 
            // dteNgay_BD
            // 
            this.dteNgay_BD.bAllowEmpty = true;
            this.dteNgay_BD.bRequire = false;
            this.dteNgay_BD.bSelectOnFocus = false;
            this.dteNgay_BD.bShowDateTimePicker = true;
            this.dteNgay_BD.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_BD.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_BD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteNgay_BD.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_BD.Location = new System.Drawing.Point(122, 100);
            this.dteNgay_BD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_BD.Mask = "00/00/0000";
            this.dteNgay_BD.Name = "dteNgay_BD";
            this.dteNgay_BD.Size = new System.Drawing.Size(111, 20);
            this.dteNgay_BD.TabIndex = 3;
            // 
            // lbNgay_Ap
            // 
            this.lbNgay_Ap.AutoEllipsis = true;
            this.lbNgay_Ap.AutoSize = true;
            this.lbNgay_Ap.BackColor = System.Drawing.Color.Transparent;
            this.lbNgay_Ap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgay_Ap.Location = new System.Drawing.Point(17, 102);
            this.lbNgay_Ap.Name = "lbNgay_Ap";
            this.lbNgay_Ap.Size = new System.Drawing.Size(72, 13);
            this.lbNgay_Ap.TabIndex = 137;
            this.lbNgay_Ap.Tag = "Ngay_BD";
            this.lbNgay_Ap.Text = "Ngày bắt đầu";
            this.lbNgay_Ap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Vt
            // 
            this.lbMa_Vt.AutoEllipsis = true;
            this.lbMa_Vt.AutoSize = true;
            this.lbMa_Vt.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_Vt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMa_Vt.Location = new System.Drawing.Point(17, 23);
            this.lbMa_Vt.Name = "lbMa_Vt";
            this.lbMa_Vt.Size = new System.Drawing.Size(44, 13);
            this.lbMa_Vt.TabIndex = 136;
            this.lbMa_Vt.Tag = "Ma_PJP";
            this.lbMa_Vt.Text = "Mã PJP";
            this.lbMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Cbnv
            // 
            this.txtMa_Cbnv.bEnabled = true;
            this.txtMa_Cbnv.bIsLookup = false;
            this.txtMa_Cbnv.bReadOnly = false;
            this.txtMa_Cbnv.bRequire = false;
            this.txtMa_Cbnv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Cbnv.ColumnsView = null;
            this.txtMa_Cbnv.CtrlDepend = null;
            this.txtMa_Cbnv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_Cbnv.KeyFilter = "Ma_Cbnv";
            this.txtMa_Cbnv.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtMa_Cbnv.ListFilter = new string[0];
            this.txtMa_Cbnv.Location = new System.Drawing.Point(122, 67);
            this.txtMa_Cbnv.LookupKeyFilter = "";
            this.txtMa_Cbnv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Cbnv.Name = "txtMa_Cbnv";
            this.txtMa_Cbnv.Size = new System.Drawing.Size(159, 20);
            this.txtMa_Cbnv.TabIndex = 2;
            this.txtMa_Cbnv.UseAutoFilter = true;
            // 
            // txtMa_PJP
            // 
            this.txtMa_PJP.bEnabled = true;
            this.txtMa_PJP.bIsLookup = false;
            this.txtMa_PJP.bReadOnly = false;
            this.txtMa_PJP.bRequire = false;
            this.txtMa_PJP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_PJP.ColumnsView = null;
            this.txtMa_PJP.CtrlDepend = null;
            this.txtMa_PJP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_PJP.KeyFilter = "";
            this.txtMa_PJP.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtMa_PJP.ListFilter = new string[0];
            this.txtMa_PJP.Location = new System.Drawing.Point(122, 20);
            this.txtMa_PJP.LookupKeyFilter = "";
            this.txtMa_PJP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_PJP.Name = "txtMa_PJP";
            this.txtMa_PJP.Size = new System.Drawing.Size(159, 20);
            this.txtMa_PJP.TabIndex = 0;
            this.txtMa_PJP.UseAutoFilter = false;
            // 
            // frmPJPConfig_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 347);
            this.Name = "frmPJPConfig_Edit";
            this.Object_ID = "LITUYEN";
            this.Tag = "ESC";
            this.Text = "frmPJPConfig";
            this.tabEdit.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.Page1.PerformLayout();
            this.Page2.ResumeLayout(false);
            this.Page2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private Systems.Controls.chkControl chkActive;
        private Systems.Controls.txtTextLookup txtTen_PJP;
        private Systems.Controls.lblControl lblControl1;
        private Systems.Controls.lblControl lblMa_PJP;
        private Systems.Controls.lblControl lbGia;
        private Systems.Controls.txtDateTime dteNgay_Kt;
        private Systems.Controls.txtDateTime dteNgay_BD;
        private Systems.Controls.lblControl lbNgay_Ap;
        private Systems.Controls.lblControl lbMa_Vt;
        private Systems.Controls.txtTextLookup txtMa_Cbnv;
        private Systems.Controls.txtTextLookup txtMa_PJP;
	}
}