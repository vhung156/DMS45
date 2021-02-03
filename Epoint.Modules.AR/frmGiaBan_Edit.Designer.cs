namespace Epoint.Modules.AR
{
	partial class frmGiaBan_Edit
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
            this.lbtTen_Dt = new Epoint.Systems.Controls.lblControl();
            this.lblMa_Dt = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Vt = new Epoint.Systems.Controls.lblControl();
            this.lbGia = new Epoint.Systems.Controls.lblControl();
            this.numGia = new Epoint.Systems.Controls.numControl();
            this.dteNgay_Ap = new Epoint.Systems.Controls.txtDateTime();
            this.lbNgay_Ap = new Epoint.Systems.Controls.lblControl();
            this.lbMa_Vt = new Epoint.Systems.Controls.lblControl();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.txtMa_Vt = new Epoint.Systems.Controls.txtTextLookup();
            this.txtMa_Dt = new Epoint.Systems.Controls.txtTextLookup();
            this.txtDvt = new Epoint.Systems.Controls.txtEnum();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.lbtDvt = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Nh_Dt = new Epoint.Systems.Controls.txtTextLookup();
            this.lbtTen_Nh_Dt = new Epoint.Systems.Controls.lblControl();
            this.lblMa_Nh_Dt = new Epoint.Systems.Controls.lblControl();
            this.SuspendLayout();
            // 
            // lbtTen_Dt
            // 
            this.lbtTen_Dt.AutoEllipsis = true;
            this.lbtTen_Dt.AutoSize = true;
            this.lbtTen_Dt.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Dt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt.Location = new System.Drawing.Point(255, 49);
            this.lbtTen_Dt.Name = "lbtTen_Dt";
            this.lbtTen_Dt.Size = new System.Drawing.Size(74, 13);
            this.lbtTen_Dt.TabIndex = 70;
            this.lbtTen_Dt.Text = "Tên đối tượng";
            this.lbtTen_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMa_Dt
            // 
            this.lblMa_Dt.AutoEllipsis = true;
            this.lblMa_Dt.AutoSize = true;
            this.lblMa_Dt.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Dt.Location = new System.Drawing.Point(35, 49);
            this.lblMa_Dt.Name = "lblMa_Dt";
            this.lblMa_Dt.Size = new System.Drawing.Size(70, 13);
            this.lblMa_Dt.TabIndex = 69;
            this.lblMa_Dt.Tag = "Ma_Dt";
            this.lblMa_Dt.Text = "Mã đối tượng";
            this.lblMa_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Vt
            // 
            this.lbtTen_Vt.AutoEllipsis = true;
            this.lbtTen_Vt.AutoSize = true;
            this.lbtTen_Vt.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Vt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt.Location = new System.Drawing.Point(255, 26);
            this.lbtTen_Vt.Name = "lbtTen_Vt";
            this.lbtTen_Vt.Size = new System.Drawing.Size(56, 13);
            this.lbtTen_Vt.TabIndex = 68;
            this.lbtTen_Vt.Text = "Tên vật tư";
            this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbGia
            // 
            this.lbGia.AutoEllipsis = true;
            this.lbGia.AutoSize = true;
            this.lbGia.BackColor = System.Drawing.Color.Transparent;
            this.lbGia.Location = new System.Drawing.Point(34, 121);
            this.lbGia.Name = "lbGia";
            this.lbGia.Size = new System.Drawing.Size(44, 13);
            this.lbGia.TabIndex = 67;
            this.lbGia.Tag = "Gia_Ban";
            this.lbGia.Text = "Giá bán";
            this.lbGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numGia
            // 
            this.numGia.bEnabled = true;
            this.numGia.bFormat = true;
            this.numGia.bIsLookup = false;
            this.numGia.bReadOnly = false;
            this.numGia.bRequire = false;
            this.numGia.KeyFilter = "";
            this.numGia.Location = new System.Drawing.Point(128, 118);
            this.numGia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numGia.Name = "numGia";
            this.numGia.Scale = 2;
            this.numGia.Size = new System.Drawing.Size(120, 20);
            this.numGia.TabIndex = 5;
            this.numGia.Text = "0.00";
            this.numGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numGia.UseAutoFilter = false;
            this.numGia.Value = 0D;
            // 
            // dteNgay_Ap
            // 
            this.dteNgay_Ap.bAllowEmpty = true;
            this.dteNgay_Ap.bRequire = false;
            this.dteNgay_Ap.bSelectOnFocus = false;
            this.dteNgay_Ap.bShowDateTimePicker = true;
            this.dteNgay_Ap.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ap.Location = new System.Drawing.Point(128, 95);
            this.dteNgay_Ap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ap.Mask = "00/00/0000";
            this.dteNgay_Ap.Name = "dteNgay_Ap";
            this.dteNgay_Ap.Size = new System.Drawing.Size(120, 20);
            this.dteNgay_Ap.TabIndex = 4;
            // 
            // lbNgay_Ap
            // 
            this.lbNgay_Ap.AutoEllipsis = true;
            this.lbNgay_Ap.AutoSize = true;
            this.lbNgay_Ap.BackColor = System.Drawing.Color.Transparent;
            this.lbNgay_Ap.Location = new System.Drawing.Point(34, 97);
            this.lbNgay_Ap.Name = "lbNgay_Ap";
            this.lbNgay_Ap.Size = new System.Drawing.Size(47, 13);
            this.lbNgay_Ap.TabIndex = 66;
            this.lbNgay_Ap.Tag = "Ngay_Ap";
            this.lbNgay_Ap.Text = "Ngày áp";
            this.lbNgay_Ap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Vt
            // 
            this.lbMa_Vt.AutoEllipsis = true;
            this.lbMa_Vt.AutoSize = true;
            this.lbMa_Vt.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_Vt.Location = new System.Drawing.Point(35, 26);
            this.lbMa_Vt.Name = "lbMa_Vt";
            this.lbMa_Vt.Size = new System.Drawing.Size(52, 13);
            this.lbMa_Vt.TabIndex = 65;
            this.lbMa_Vt.Tag = "Ma_Vt";
            this.lbMa_Vt.Text = "Mã vật tư";
            this.lbMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(292, 317);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 29);
            this.btgAccept.TabIndex = 6;
            // 
            // txtMa_Vt
            // 
            this.txtMa_Vt.bEnabled = true;
            this.txtMa_Vt.bIsLookup = false;
            this.txtMa_Vt.bReadOnly = false;
            this.txtMa_Vt.bRequire = false;
            this.txtMa_Vt.ColumnsView = null;
            this.txtMa_Vt.KeyFilter = "Ma_Vt";
            this.txtMa_Vt.Location = new System.Drawing.Point(129, 23);
            this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt.Name = "txtMa_Vt";
            this.txtMa_Vt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Vt.TabIndex = 0;
            this.txtMa_Vt.UseAutoFilter = true;
            // 
            // txtMa_Dt
            // 
            this.txtMa_Dt.bEnabled = true;
            this.txtMa_Dt.bIsLookup = false;
            this.txtMa_Dt.bReadOnly = false;
            this.txtMa_Dt.bRequire = false;
            this.txtMa_Dt.ColumnsView = null;
            this.txtMa_Dt.KeyFilter = "Ma_Dt";
            this.txtMa_Dt.Location = new System.Drawing.Point(129, 46);
            this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt.Name = "txtMa_Dt";
            this.txtMa_Dt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Dt.TabIndex = 1;
            this.txtMa_Dt.UseAutoFilter = true;
            // 
            // txtDvt
            // 
            this.txtDvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDvt.bEnabled = true;
            this.txtDvt.bIsLookup = false;
            this.txtDvt.bReadOnly = false;
            this.txtDvt.bRequire = true;
            this.txtDvt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDvt.InputMask = "";
            this.txtDvt.KeyFilter = "";
            this.txtDvt.Location = new System.Drawing.Point(128, 71);
            this.txtDvt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDvt.Name = "txtDvt";
            this.txtDvt.Size = new System.Drawing.Size(120, 20);
            this.txtDvt.TabIndex = 3;
            this.txtDvt.UseAutoFilter = false;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(35, 73);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(24, 13);
            this.lblControl1.TabIndex = 76;
            this.lblControl1.Tag = "Dvt";
            this.lblControl1.Text = "Dvt";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtDvt
            // 
            this.lbtDvt.AutoEllipsis = true;
            this.lbtDvt.AutoSize = true;
            this.lbtDvt.BackColor = System.Drawing.Color.Transparent;
            this.lbtDvt.ForeColor = System.Drawing.Color.Blue;
            this.lbtDvt.Location = new System.Drawing.Point(254, 78);
            this.lbtDvt.Name = "lbtDvt";
            this.lbtDvt.Size = new System.Drawing.Size(22, 13);
            this.lbtDvt.TabIndex = 75;
            this.lbtDvt.Text = "dvt";
            this.lbtDvt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Nh_Dt
            // 
            this.txtMa_Nh_Dt.bEnabled = true;
            this.txtMa_Nh_Dt.bIsLookup = false;
            this.txtMa_Nh_Dt.bReadOnly = false;
            this.txtMa_Nh_Dt.bRequire = false;
            this.txtMa_Nh_Dt.ColumnsView = null;
            this.txtMa_Nh_Dt.KeyFilter = "Ma_Nh_Dt";
            this.txtMa_Nh_Dt.Location = new System.Drawing.Point(128, 47);
            this.txtMa_Nh_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Nh_Dt.Name = "txtMa_Nh_Dt";
            this.txtMa_Nh_Dt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Nh_Dt.TabIndex = 2;
            this.txtMa_Nh_Dt.UseAutoFilter = true;
            this.txtMa_Nh_Dt.Visible = false;
            // 
            // lbtTen_Nh_Dt
            // 
            this.lbtTen_Nh_Dt.AutoEllipsis = true;
            this.lbtTen_Nh_Dt.AutoSize = true;
            this.lbtTen_Nh_Dt.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Nh_Dt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Nh_Dt.Location = new System.Drawing.Point(254, 50);
            this.lbtTen_Nh_Dt.Name = "lbtTen_Nh_Dt";
            this.lbtTen_Nh_Dt.Size = new System.Drawing.Size(103, 13);
            this.lbtTen_Nh_Dt.TabIndex = 79;
            this.lbtTen_Nh_Dt.Text = "Tên nhóm đối tượng";
            this.lbtTen_Nh_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbtTen_Nh_Dt.Visible = false;
            // 
            // lblMa_Nh_Dt
            // 
            this.lblMa_Nh_Dt.AutoEllipsis = true;
            this.lblMa_Nh_Dt.AutoSize = true;
            this.lblMa_Nh_Dt.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Nh_Dt.Location = new System.Drawing.Point(34, 50);
            this.lblMa_Nh_Dt.Name = "lblMa_Nh_Dt";
            this.lblMa_Nh_Dt.Size = new System.Drawing.Size(51, 13);
            this.lblMa_Nh_Dt.TabIndex = 78;
            this.lblMa_Nh_Dt.Tag = "Ma_Nh_Dt";
            this.lblMa_Nh_Dt.Text = "Mã nhóm";
            this.lblMa_Nh_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMa_Nh_Dt.Visible = false;
            // 
            // frmGiaBan_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 358);
            this.Controls.Add(this.txtMa_Nh_Dt);
            this.Controls.Add(this.lbtTen_Nh_Dt);
            this.Controls.Add(this.lblMa_Nh_Dt);
            this.Controls.Add(this.txtDvt);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.lbtDvt);
            this.Controls.Add(this.txtMa_Dt);
            this.Controls.Add(this.txtMa_Vt);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.lbtTen_Dt);
            this.Controls.Add(this.lblMa_Dt);
            this.Controls.Add(this.lbtTen_Vt);
            this.Controls.Add(this.lbGia);
            this.Controls.Add(this.numGia);
            this.Controls.Add(this.dteNgay_Ap);
            this.Controls.Add(this.lbNgay_Ap);
            this.Controls.Add(this.lbMa_Vt);
            this.Name = "frmGiaBan_Edit";
            this.Tag = "frmGiaBan";
            this.Text = "frmGiaBan";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Epoint.Systems.Controls.lblControl lbtTen_Dt;
		private Epoint.Systems.Controls.lblControl lblMa_Dt;
		private Epoint.Systems.Controls.lblControl lbtTen_Vt;
		private Epoint.Systems.Controls.lblControl lbGia;
		private Epoint.Systems.Controls.numControl numGia;
		private Epoint.Systems.Controls.txtDateTime dteNgay_Ap;
        private Epoint.Systems.Controls.lblControl lbNgay_Ap;
		private Epoint.Systems.Controls.lblControl lbMa_Vt;
		private Epoint.Systems.Customizes.btgAccept btgAccept;
        private Systems.Controls.txtTextLookup txtMa_Vt;
        private Systems.Controls.txtTextLookup txtMa_Dt;
        private Systems.Controls.txtEnum txtDvt;
        private Systems.Controls.lblControl lblControl1;
        private Systems.Controls.lblControl lbtDvt;
        private Systems.Controls.txtTextLookup txtMa_Nh_Dt;
        private Systems.Controls.lblControl lbtTen_Nh_Dt;
        private Systems.Controls.lblControl lblMa_Nh_Dt;
	}
}