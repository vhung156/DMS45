namespace Epoint.Modules.AR
{
    partial class frmDiscountProg_Edit
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
            this.lblMa_Dt = new Epoint.Systems.Controls.lblControl();
            this.lbGia = new Epoint.Systems.Controls.lblControl();
            this.dteNgay_BD = new Epoint.Systems.Controls.txtDateTime();
            this.lbNgay_Ap = new Epoint.Systems.Controls.lblControl();
            this.lbMa_Vt = new Epoint.Systems.Controls.lblControl();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.txtMa_CTKM = new Epoint.Systems.Controls.txtTextLookup();
            this.txtTen_CTKM = new Epoint.Systems.Controls.txtTextLookup();
            this.dteNgay_Kt = new Epoint.Systems.Controls.txtDateTime();
            this.cbxLoai_KM = new Epoint.Systems.Controls.cboControl();
            this.cbxLoai_Ap_Km = new Epoint.Systems.Controls.cboControl();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.lblControl3 = new Epoint.Systems.Controls.lblControl();
            this.cbxHinh_Thuc_Km = new Epoint.Systems.Controls.cboControl();
            this.lblControl4 = new Epoint.Systems.Controls.lblControl();
            this.cbxBreakBy = new Epoint.Systems.Controls.cboControl();
            this.chkActive = new Epoint.Systems.Controls.chkControl();
            this.chkHan_Km = new Epoint.Systems.Controls.chkControl();
            this.chkAutoFreeItem = new Epoint.Systems.Controls.chkControl();
            this.chkAllowEditDisc = new Epoint.Systems.Controls.chkControl();
            this.lblControl5 = new Epoint.Systems.Controls.lblControl();
            this.numTSo_Luong = new Epoint.Systems.Controls.numControl();
            this.lblTTien = new Epoint.Systems.Controls.lblControl();
            this.numTTien = new Epoint.Systems.Controls.numControl();
            this.lblControl6 = new Epoint.Systems.Controls.lblControl();
            this.lblControl7 = new Epoint.Systems.Controls.lblControl();
            this.chkTra_Sau = new Epoint.Systems.Controls.chkControl();
            this.SuspendLayout();
            // 
            // lblMa_Dt
            // 
            this.lblMa_Dt.AutoEllipsis = true;
            this.lblMa_Dt.AutoSize = true;
            this.lblMa_Dt.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Dt.Location = new System.Drawing.Point(24, 49);
            this.lblMa_Dt.Name = "lblMa_Dt";
            this.lblMa_Dt.Size = new System.Drawing.Size(59, 13);
            this.lblMa_Dt.TabIndex = 69;
            this.lblMa_Dt.Tag = "TEN_CTKM";
            this.lblMa_Dt.Text = "Tên CTKM";
            this.lblMa_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbGia
            // 
            this.lbGia.AutoEllipsis = true;
            this.lbGia.AutoSize = true;
            this.lbGia.BackColor = System.Drawing.Color.Transparent;
            this.lbGia.Location = new System.Drawing.Point(24, 191);
            this.lbGia.Name = "lbGia";
            this.lbGia.Size = new System.Drawing.Size(74, 13);
            this.lbGia.TabIndex = 67;
            this.lbGia.Tag = "Ngay_Kt";
            this.lbGia.Text = "Ngày kết thúc";
            this.lbGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_BD
            // 
            this.dteNgay_BD.bAllowEmpty = true;
            this.dteNgay_BD.bRequire = false;
            this.dteNgay_BD.bSelectOnFocus = false;
            this.dteNgay_BD.bShowDateTimePicker = true;
            this.dteNgay_BD.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_BD.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_BD.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_BD.Location = new System.Drawing.Point(129, 165);
            this.dteNgay_BD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_BD.Mask = "00/00/0000";
            this.dteNgay_BD.Name = "dteNgay_BD";
            this.dteNgay_BD.Size = new System.Drawing.Size(111, 20);
            this.dteNgay_BD.TabIndex = 6;
            // 
            // lbNgay_Ap
            // 
            this.lbNgay_Ap.AutoEllipsis = true;
            this.lbNgay_Ap.AutoSize = true;
            this.lbNgay_Ap.BackColor = System.Drawing.Color.Transparent;
            this.lbNgay_Ap.Location = new System.Drawing.Point(24, 167);
            this.lbNgay_Ap.Name = "lbNgay_Ap";
            this.lbNgay_Ap.Size = new System.Drawing.Size(72, 13);
            this.lbNgay_Ap.TabIndex = 66;
            this.lbNgay_Ap.Tag = "Ngay_BD";
            this.lbNgay_Ap.Text = "Ngày bắt đầu";
            this.lbNgay_Ap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Vt
            // 
            this.lbMa_Vt.AutoEllipsis = true;
            this.lbMa_Vt.AutoSize = true;
            this.lbMa_Vt.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_Vt.Location = new System.Drawing.Point(24, 26);
            this.lbMa_Vt.Name = "lbMa_Vt";
            this.lbMa_Vt.Size = new System.Drawing.Size(55, 13);
            this.lbMa_Vt.TabIndex = 65;
            this.lbMa_Vt.Tag = "Ma_CTKM";
            this.lbMa_Vt.Text = "Mã CTKM";
            this.lbMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(367, 366);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 29);
            this.btgAccept.TabIndex = 15;
            // 
            // txtMa_CTKM
            // 
            this.txtMa_CTKM.bEnabled = true;
            this.txtMa_CTKM.bIsLookup = false;
            this.txtMa_CTKM.bReadOnly = false;
            this.txtMa_CTKM.bRequire = false;
            this.txtMa_CTKM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_CTKM.ColumnsView = null;
            this.txtMa_CTKM.CtrlDepend = null;
            this.txtMa_CTKM.KeyFilter = "";
            this.txtMa_CTKM.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtMa_CTKM.ListFilter = new string[0];
            this.txtMa_CTKM.Location = new System.Drawing.Point(129, 23);
            this.txtMa_CTKM.LookupKeyFilter = "";
            this.txtMa_CTKM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_CTKM.Name = "txtMa_CTKM";
            this.txtMa_CTKM.Size = new System.Drawing.Size(159, 20);
            this.txtMa_CTKM.TabIndex = 0;
            this.txtMa_CTKM.UseAutoFilter = false;
            // 
            // txtTen_CTKM
            // 
            this.txtTen_CTKM.bEnabled = true;
            this.txtTen_CTKM.bIsLookup = false;
            this.txtTen_CTKM.bReadOnly = false;
            this.txtTen_CTKM.bRequire = false;
            this.txtTen_CTKM.ColumnsView = null;
            this.txtTen_CTKM.CtrlDepend = null;
            this.txtTen_CTKM.KeyFilter = "";
            this.txtTen_CTKM.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtTen_CTKM.ListFilter = new string[0];
            this.txtTen_CTKM.Location = new System.Drawing.Point(129, 46);
            this.txtTen_CTKM.LookupKeyFilter = "";
            this.txtTen_CTKM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_CTKM.Name = "txtTen_CTKM";
            this.txtTen_CTKM.Size = new System.Drawing.Size(382, 20);
            this.txtTen_CTKM.TabIndex = 1;
            this.txtTen_CTKM.UseAutoFilter = false;
            // 
            // dteNgay_Kt
            // 
            this.dteNgay_Kt.bAllowEmpty = true;
            this.dteNgay_Kt.bRequire = false;
            this.dteNgay_Kt.bSelectOnFocus = false;
            this.dteNgay_Kt.bShowDateTimePicker = true;
            this.dteNgay_Kt.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Kt.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Kt.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Kt.Location = new System.Drawing.Point(129, 188);
            this.dteNgay_Kt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Kt.Mask = "00/00/0000";
            this.dteNgay_Kt.Name = "dteNgay_Kt";
            this.dteNgay_Kt.Size = new System.Drawing.Size(111, 20);
            this.dteNgay_Kt.TabIndex = 7;
            // 
            // cbxLoai_KM
            // 
            this.cbxLoai_KM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLoai_KM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxLoai_KM.FormattingEnabled = true;
            this.cbxLoai_KM.InitValue = null;
            this.cbxLoai_KM.Location = new System.Drawing.Point(129, 68);
            this.cbxLoai_KM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cbxLoai_KM.Name = "cbxLoai_KM";
            this.cbxLoai_KM.Size = new System.Drawing.Size(223, 21);
            this.cbxLoai_KM.strValueList = null;
            this.cbxLoai_KM.TabIndex = 2;
            this.cbxLoai_KM.UpperCase = false;
            this.cbxLoai_KM.UseAutoComplete = false;
            this.cbxLoai_KM.UseBindingValue = false;
            // 
            // cbxLoai_Ap_Km
            // 
            this.cbxLoai_Ap_Km.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLoai_Ap_Km.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxLoai_Ap_Km.FormattingEnabled = true;
            this.cbxLoai_Ap_Km.InitValue = null;
            this.cbxLoai_Ap_Km.Location = new System.Drawing.Point(129, 91);
            this.cbxLoai_Ap_Km.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cbxLoai_Ap_Km.Name = "cbxLoai_Ap_Km";
            this.cbxLoai_Ap_Km.Size = new System.Drawing.Size(158, 21);
            this.cbxLoai_Ap_Km.strValueList = null;
            this.cbxLoai_Ap_Km.TabIndex = 3;
            this.cbxLoai_Ap_Km.UpperCase = false;
            this.cbxLoai_Ap_Km.UseAutoComplete = false;
            this.cbxLoai_Ap_Km.UseBindingValue = false;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(24, 73);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(60, 13);
            this.lblControl1.TabIndex = 69;
            this.lblControl1.Tag = "Loai_CTKM";
            this.lblControl1.Text = "Loại CTKM";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(24, 96);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(68, 13);
            this.lblControl2.TabIndex = 69;
            this.lblControl2.Tag = "Loai_Ap_KM";
            this.lblControl2.Text = "Áp dụng cho";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl3
            // 
            this.lblControl3.AutoEllipsis = true;
            this.lblControl3.AutoSize = true;
            this.lblControl3.BackColor = System.Drawing.Color.Transparent;
            this.lblControl3.Location = new System.Drawing.Point(24, 120);
            this.lblControl3.Name = "lblControl3";
            this.lblControl3.Size = new System.Drawing.Size(86, 13);
            this.lblControl3.TabIndex = 69;
            this.lblControl3.Tag = "KM_Theo";
            this.lblControl3.Text = "Khuyến mãi theo";
            this.lblControl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxHinh_Thuc_Km
            // 
            this.cbxHinh_Thuc_Km.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHinh_Thuc_Km.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxHinh_Thuc_Km.FormattingEnabled = true;
            this.cbxHinh_Thuc_Km.InitValue = null;
            this.cbxHinh_Thuc_Km.Location = new System.Drawing.Point(129, 115);
            this.cbxHinh_Thuc_Km.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cbxHinh_Thuc_Km.Name = "cbxHinh_Thuc_Km";
            this.cbxHinh_Thuc_Km.Size = new System.Drawing.Size(158, 21);
            this.cbxHinh_Thuc_Km.strValueList = null;
            this.cbxHinh_Thuc_Km.TabIndex = 4;
            this.cbxHinh_Thuc_Km.UpperCase = false;
            this.cbxHinh_Thuc_Km.UseAutoComplete = false;
            this.cbxHinh_Thuc_Km.UseBindingValue = false;
            // 
            // lblControl4
            // 
            this.lblControl4.AutoEllipsis = true;
            this.lblControl4.AutoSize = true;
            this.lblControl4.BackColor = System.Drawing.Color.Transparent;
            this.lblControl4.Location = new System.Drawing.Point(24, 145);
            this.lblControl4.Name = "lblControl4";
            this.lblControl4.Size = new System.Drawing.Size(69, 13);
            this.lblControl4.TabIndex = 69;
            this.lblControl4.Tag = "KIEM_TRA_THEO";
            this.lblControl4.Text = "Kiểm tra theo";
            this.lblControl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxBreakBy
            // 
            this.cbxBreakBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBreakBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBreakBy.FormattingEnabled = true;
            this.cbxBreakBy.InitValue = null;
            this.cbxBreakBy.Location = new System.Drawing.Point(129, 140);
            this.cbxBreakBy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cbxBreakBy.Name = "cbxBreakBy";
            this.cbxBreakBy.Size = new System.Drawing.Size(158, 21);
            this.cbxBreakBy.strValueList = null;
            this.cbxBreakBy.TabIndex = 5;
            this.cbxBreakBy.UpperCase = false;
            this.cbxBreakBy.UseAutoComplete = false;
            this.cbxBreakBy.UseBindingValue = false;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkActive.Location = new System.Drawing.Point(129, 268);
            this.chkActive.Name = "chkActive";
            this.chkActive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkActive.Size = new System.Drawing.Size(77, 17);
            this.chkActive.TabIndex = 11;
            this.chkActive.Tag = "Active";
            this.chkActive.Text = "Hoạt động";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // chkHan_Km
            // 
            this.chkHan_Km.AutoSize = true;
            this.chkHan_Km.Checked = true;
            this.chkHan_Km.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHan_Km.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkHan_Km.Location = new System.Drawing.Point(129, 291);
            this.chkHan_Km.Name = "chkHan_Km";
            this.chkHan_Km.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkHan_Km.Size = new System.Drawing.Size(65, 17);
            this.chkHan_Km.TabIndex = 12;
            this.chkHan_Km.Tag = "Han_KM";
            this.chkHan_Km.Text = "Hạn KM";
            this.chkHan_Km.UseVisualStyleBackColor = true;
            // 
            // chkAutoFreeItem
            // 
            this.chkAutoFreeItem.AutoSize = true;
            this.chkAutoFreeItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkAutoFreeItem.Location = new System.Drawing.Point(129, 314);
            this.chkAutoFreeItem.Name = "chkAutoFreeItem";
            this.chkAutoFreeItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkAutoFreeItem.Size = new System.Drawing.Size(118, 17);
            this.chkAutoFreeItem.TabIndex = 13;
            this.chkAutoFreeItem.Tag = "AutoFreeItem";
            this.chkAutoFreeItem.Text = "Tự động tặng hàng";
            this.chkAutoFreeItem.UseVisualStyleBackColor = true;
            // 
            // chkAllowEditDisc
            // 
            this.chkAllowEditDisc.AutoSize = true;
            this.chkAllowEditDisc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkAllowEditDisc.Location = new System.Drawing.Point(129, 337);
            this.chkAllowEditDisc.Name = "chkAllowEditDisc";
            this.chkAllowEditDisc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkAllowEditDisc.Size = new System.Drawing.Size(111, 17);
            this.chkAllowEditDisc.TabIndex = 14;
            this.chkAllowEditDisc.Tag = "AllowEditDisc";
            this.chkAllowEditDisc.Text = "Cho phép sửa KM";
            this.chkAllowEditDisc.UseVisualStyleBackColor = true;
            // 
            // lblControl5
            // 
            this.lblControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblControl5.AutoEllipsis = true;
            this.lblControl5.AutoSize = true;
            this.lblControl5.BackColor = System.Drawing.Color.Transparent;
            this.lblControl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl5.ForeColor = System.Drawing.Color.Blue;
            this.lblControl5.Location = new System.Drawing.Point(24, 239);
            this.lblControl5.Name = "lblControl5";
            this.lblControl5.Size = new System.Drawing.Size(100, 13);
            this.lblControl5.TabIndex = 120;
            this.lblControl5.Tag = "TSO_LUONG";
            this.lblControl5.Text = "Ngân sách hàng";
            this.lblControl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTSo_Luong
            // 
            this.numTSo_Luong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTSo_Luong.bEnabled = true;
            this.numTSo_Luong.bFormat = true;
            this.numTSo_Luong.bIsLookup = false;
            this.numTSo_Luong.bReadOnly = false;
            this.numTSo_Luong.bRequire = false;
            this.numTSo_Luong.Enabled = false;
            this.numTSo_Luong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTSo_Luong.ForeColor = System.Drawing.Color.Blue;
            this.numTSo_Luong.KeyFilter = "";
            this.numTSo_Luong.Location = new System.Drawing.Point(129, 235);
            this.numTSo_Luong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTSo_Luong.Name = "numTSo_Luong";
            this.numTSo_Luong.Scale = 2;
            this.numTSo_Luong.Size = new System.Drawing.Size(111, 20);
            this.numTSo_Luong.TabIndex = 9;
            this.numTSo_Luong.TabStop = false;
            this.numTSo_Luong.Text = "0.00";
            this.numTSo_Luong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTSo_Luong.UseAutoFilter = false;
            this.numTSo_Luong.Value = 0D;
            // 
            // lblTTien
            // 
            this.lblTTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTTien.AutoEllipsis = true;
            this.lblTTien.AutoSize = true;
            this.lblTTien.BackColor = System.Drawing.Color.Transparent;
            this.lblTTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTTien.ForeColor = System.Drawing.Color.Blue;
            this.lblTTien.Location = new System.Drawing.Point(24, 217);
            this.lblTTien.Name = "lblTTien";
            this.lblTTien.Size = new System.Drawing.Size(93, 13);
            this.lblTTien.TabIndex = 119;
            this.lblTTien.Tag = "";
            this.lblTTien.Text = "Ngân sách tiền";
            this.lblTTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTTien
            // 
            this.numTTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTTien.bEnabled = true;
            this.numTTien.bFormat = true;
            this.numTTien.bIsLookup = false;
            this.numTTien.bReadOnly = false;
            this.numTTien.bRequire = false;
            this.numTTien.Enabled = false;
            this.numTTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTTien.ForeColor = System.Drawing.Color.Blue;
            this.numTTien.KeyFilter = "";
            this.numTTien.Location = new System.Drawing.Point(129, 213);
            this.numTTien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien.Name = "numTTien";
            this.numTTien.Scale = 2;
            this.numTTien.Size = new System.Drawing.Size(111, 20);
            this.numTTien.TabIndex = 8;
            this.numTTien.TabStop = false;
            this.numTTien.Text = "0.00";
            this.numTTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien.UseAutoFilter = false;
            this.numTTien.Value = 0D;
            // 
            // lblControl6
            // 
            this.lblControl6.AutoEllipsis = true;
            this.lblControl6.AutoSize = true;
            this.lblControl6.BackColor = System.Drawing.Color.Transparent;
            this.lblControl6.ForeColor = System.Drawing.Color.LightCoral;
            this.lblControl6.Location = new System.Drawing.Point(303, 118);
            this.lblControl6.Name = "lblControl6";
            this.lblControl6.Size = new System.Drawing.Size(144, 13);
            this.lblControl6.TabIndex = 69;
            this.lblControl6.Tag = "";
            this.lblControl6.Text = "Loại hình tặng (Tiền,%,Hàng)";
            this.lblControl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl7
            // 
            this.lblControl7.AutoEllipsis = true;
            this.lblControl7.AutoSize = true;
            this.lblControl7.BackColor = System.Drawing.Color.Transparent;
            this.lblControl7.ForeColor = System.Drawing.Color.LightCoral;
            this.lblControl7.Location = new System.Drawing.Point(303, 148);
            this.lblControl7.Name = "lblControl7";
            this.lblControl7.Size = new System.Drawing.Size(144, 13);
            this.lblControl7.TabIndex = 69;
            this.lblControl7.Tag = "";
            this.lblControl7.Text = "Điều kiện đạt km(Tiền,Hàng)";
            this.lblControl7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkTra_Sau
            // 
            this.chkTra_Sau.AutoSize = true;
            this.chkTra_Sau.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkTra_Sau.Location = new System.Drawing.Point(275, 239);
            this.chkTra_Sau.Name = "chkTra_Sau";
            this.chkTra_Sau.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkTra_Sau.Size = new System.Drawing.Size(80, 17);
            this.chkTra_Sau.TabIndex = 10;
            this.chkTra_Sau.Tag = "Tra_Sau";
            this.chkTra_Sau.Text = "Km Trả sau";
            this.chkTra_Sau.UseVisualStyleBackColor = true;
            // 
            // frmDiscountProg_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 407);
            this.Controls.Add(this.lblControl5);
            this.Controls.Add(this.numTSo_Luong);
            this.Controls.Add(this.lblTTien);
            this.Controls.Add(this.numTTien);
            this.Controls.Add(this.chkAllowEditDisc);
            this.Controls.Add(this.chkAutoFreeItem);
            this.Controls.Add(this.chkHan_Km);
            this.Controls.Add(this.chkTra_Sau);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.cbxBreakBy);
            this.Controls.Add(this.cbxHinh_Thuc_Km);
            this.Controls.Add(this.cbxLoai_Ap_Km);
            this.Controls.Add(this.cbxLoai_KM);
            this.Controls.Add(this.txtTen_CTKM);
            this.Controls.Add(this.txtMa_CTKM);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.lblControl4);
            this.Controls.Add(this.lblControl7);
            this.Controls.Add(this.lblControl6);
            this.Controls.Add(this.lblControl3);
            this.Controls.Add(this.lblControl2);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.lblMa_Dt);
            this.Controls.Add(this.lbGia);
            this.Controls.Add(this.dteNgay_Kt);
            this.Controls.Add(this.dteNgay_BD);
            this.Controls.Add(this.lbNgay_Ap);
            this.Controls.Add(this.lbMa_Vt);
            this.Name = "frmDiscountProg_Edit";
            this.Tag = "frmGiaBan";
            this.Text = "frmGiaBan";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Epoint.Systems.Controls.lblControl lblMa_Dt;
        private Epoint.Systems.Controls.lblControl lbGia;
		private Epoint.Systems.Controls.txtDateTime dteNgay_BD;
        private Epoint.Systems.Controls.lblControl lbNgay_Ap;
		private Epoint.Systems.Controls.lblControl lbMa_Vt;
		private Epoint.Systems.Customizes.btgAccept btgAccept;
        private Systems.Controls.txtTextLookup txtMa_CTKM;
        private Systems.Controls.txtTextLookup txtTen_CTKM;
        private Systems.Controls.txtDateTime dteNgay_Kt;
        private Systems.Controls.cboControl cbxLoai_KM;
        private Systems.Controls.cboControl cbxLoai_Ap_Km;
        private Systems.Controls.lblControl lblControl1;
        private Systems.Controls.lblControl lblControl2;
        private Systems.Controls.lblControl lblControl3;
        private Systems.Controls.cboControl cbxHinh_Thuc_Km;
        private Systems.Controls.lblControl lblControl4;
        private Systems.Controls.cboControl cbxBreakBy;
        private Systems.Controls.chkControl chkActive;
        private Systems.Controls.chkControl chkHan_Km;
        private Systems.Controls.chkControl chkAutoFreeItem;
        private Systems.Controls.chkControl chkAllowEditDisc;
        private Systems.Controls.lblControl lblControl5;
        private Systems.Controls.numControl numTSo_Luong;
        private Systems.Controls.lblControl lblTTien;
        private Systems.Controls.numControl numTTien;
        private Systems.Controls.lblControl lblControl6;
        private Systems.Controls.lblControl lblControl7;
        private Systems.Controls.chkControl chkTra_Sau;
	}
}