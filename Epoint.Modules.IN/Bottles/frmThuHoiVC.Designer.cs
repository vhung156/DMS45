namespace Epoint.Modules.IN
{
    partial class frmThuHoiVC
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThuHoiVC));
            this.tabChiTietThuHoi = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvHanTt0 = new Epoint.Systems.Controls.dgvGridControl();
            this.numTSo_Luong = new Epoint.Systems.Controls.numControl();
            this.btSave = new Epoint.Systems.Controls.btControl();
            this.lblMa_Tte = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Tte = new Epoint.Systems.Controls.txtEnum();
            this.numTy_Gia = new Epoint.Systems.Controls.numControl();
            this.lblTk = new Epoint.Systems.Controls.lblControl();
            this.txtTk = new Epoint.Systems.Controls.txtTextLookup();
            this.dteNgay_Ct1 = new Epoint.Systems.Controls.txtDateTime();
            this.lblNgay_Ct = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Dt = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Dt = new Epoint.Systems.Controls.txtTextLookup();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Tk = new Epoint.Systems.Controls.lblControl();
            this.chkDu_Cuoi_Only = new Epoint.Systems.Controls.chkControl();
            this.btFillterData = new Epoint.Systems.Customizes.btPreview();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.dteNgay_Ct2 = new Epoint.Systems.Controls.txtDateTime();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numTien_Tt_Auto = new Epoint.Systems.Controls.numControl();
            this.txtMa_Tuyen = new Epoint.Systems.Controls.txtTextLookup();
            this.txtMa_Nh_Dt = new Epoint.Systems.Controls.txtTextLookup();
            this.lblControl9 = new Epoint.Systems.Controls.lblControl();
            this.lblControl7 = new Epoint.Systems.Controls.lblControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboTK_List = new Epoint.Systems.Controls.cboMultiControl();
            this.lblControl5 = new Epoint.Systems.Controls.lblControl();
            this.lblOng_Ba = new Epoint.Systems.Controls.lblControl();
            this.txtDien_Giai = new Epoint.Systems.Controls.txtTextBox();
            this.btCheckAll = new Epoint.Systems.Customizes.btPreview();
            this.btThanhtoan = new Epoint.Systems.Customizes.btPreview();
            this.lbt_Ten_Tk_Tt = new Epoint.Systems.Controls.lblControl();
            this.txtTk_Tt = new Epoint.Systems.Controls.txtTextLookup();
            this.dteNgay_Ct_TT = new Epoint.Systems.Controls.txtDateTime();
            this.numTTien_Tt_Nt = new Epoint.Systems.Controls.numControl();
            this.lblControl8 = new Epoint.Systems.Controls.lblControl();
            this.lblControl11 = new Epoint.Systems.Controls.lblControl();
            this.lblControl12 = new Epoint.Systems.Controls.lblControl();
            this.tabChiTietThuHoi.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHanTt0)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabChiTietThuHoi
            // 
            this.tabChiTietThuHoi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabChiTietThuHoi.Controls.Add(this.tabPage1);
            this.tabChiTietThuHoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChiTietThuHoi.Location = new System.Drawing.Point(4, 150);
            this.tabChiTietThuHoi.Name = "tabChiTietThuHoi";
            this.tabChiTietThuHoi.SelectedIndex = 0;
            this.tabChiTietThuHoi.Size = new System.Drawing.Size(983, 571);
            this.tabChiTietThuHoi.TabIndex = 2;
            this.tabChiTietThuHoi.Tag = "HanTT0";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvHanTt0);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(975, 545);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Tag = "HanTt0";
            this.tabPage1.Text = "Chi tiết thu hồi vỏ chai";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvHanTt0
            // 
            this.dgvHanTt0.AllowEdit = false;
            this.dgvHanTt0.Location = new System.Drawing.Point(0, 0);
            this.dgvHanTt0.Name = "dgvHanTt0";
            this.dgvHanTt0.strZone = "";
            this.dgvHanTt0.TabIndex = 0;
            // 
            // numTSo_Luong
            // 
            this.numTSo_Luong.bEnabled = true;
            this.numTSo_Luong.bFormat = true;
            this.numTSo_Luong.bIsLookup = false;
            this.numTSo_Luong.bReadOnly = false;
            this.numTSo_Luong.bRequire = false;
            this.numTSo_Luong.Enabled = false;
            this.numTSo_Luong.KeyFilter = "";
            this.numTSo_Luong.Location = new System.Drawing.Point(347, 28);
            this.numTSo_Luong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTSo_Luong.Name = "numTSo_Luong";
            this.numTSo_Luong.Scale = 0;
            this.numTSo_Luong.Size = new System.Drawing.Size(121, 20);
            this.numTSo_Luong.TabIndex = 2;
            this.numTSo_Luong.Text = "0";
            this.numTSo_Luong.UseAutoFilter = false;
            this.numTSo_Luong.Value = 0D;
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSave.Enabled = false;
            this.btSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btSave.Image = ((System.Drawing.Image)(resources.GetObject("btSave.Image")));
            this.btSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSave.Location = new System.Drawing.Point(24, 681);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(65, 31);
            this.btSave.TabIndex = 1;
            this.btSave.Tag = "Save";
            this.btSave.Text = "Lưu";
            this.btSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // lblMa_Tte
            // 
            this.lblMa_Tte.AutoEllipsis = true;
            this.lblMa_Tte.AutoSize = true;
            this.lblMa_Tte.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Tte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMa_Tte.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMa_Tte.Location = new System.Drawing.Point(237, 42);
            this.lblMa_Tte.Name = "lblMa_Tte";
            this.lblMa_Tte.Size = new System.Drawing.Size(54, 13);
            this.lblMa_Tte.TabIndex = 56;
            this.lblMa_Tte.Tag = "Ma_Tte";
            this.lblMa_Tte.Text = "Mã tiền tệ";
            this.lblMa_Tte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMa_Tte.Visible = false;
            // 
            // txtMa_Tte
            // 
            this.txtMa_Tte.bEnabled = true;
            this.txtMa_Tte.bIsLookup = false;
            this.txtMa_Tte.bReadOnly = false;
            this.txtMa_Tte.bRequire = false;
            this.txtMa_Tte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_Tte.InputMask = "VND,USD";
            this.txtMa_Tte.KeyFilter = "";
            this.txtMa_Tte.Location = new System.Drawing.Point(294, 39);
            this.txtMa_Tte.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Tte.Name = "txtMa_Tte";
            this.txtMa_Tte.Size = new System.Drawing.Size(29, 20);
            this.txtMa_Tte.TabIndex = 3;
            this.txtMa_Tte.Text = "VND";
            this.txtMa_Tte.UseAutoFilter = false;
            this.txtMa_Tte.Visible = false;
            // 
            // numTy_Gia
            // 
            this.numTy_Gia.bEnabled = true;
            this.numTy_Gia.bFormat = true;
            this.numTy_Gia.bIsLookup = false;
            this.numTy_Gia.bReadOnly = false;
            this.numTy_Gia.bRequire = false;
            this.numTy_Gia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTy_Gia.KeyFilter = "";
            this.numTy_Gia.Location = new System.Drawing.Point(325, 39);
            this.numTy_Gia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTy_Gia.Name = "numTy_Gia";
            this.numTy_Gia.Scale = 2;
            this.numTy_Gia.Size = new System.Drawing.Size(70, 20);
            this.numTy_Gia.TabIndex = 4;
            this.numTy_Gia.Text = "0.00";
            this.numTy_Gia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTy_Gia.UseAutoFilter = false;
            this.numTy_Gia.Value = 0D;
            this.numTy_Gia.Visible = false;
            // 
            // lblTk
            // 
            this.lblTk.AutoEllipsis = true;
            this.lblTk.AutoSize = true;
            this.lblTk.BackColor = System.Drawing.Color.Transparent;
            this.lblTk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTk.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTk.Location = new System.Drawing.Point(6, 20);
            this.lblTk.Name = "lblTk";
            this.lblTk.Size = new System.Drawing.Size(55, 13);
            this.lblTk.TabIndex = 60;
            this.lblTk.Tag = "Tk";
            this.lblTk.Text = "Tài khoản";
            this.lblTk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTk
            // 
            this.txtTk.bEnabled = true;
            this.txtTk.bIsLookup = false;
            this.txtTk.bReadOnly = false;
            this.txtTk.bRequire = false;
            this.txtTk.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTk.ColumnsView = null;
            this.txtTk.CtrlDepend = null;
            this.txtTk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTk.KeyFilter = "Tk";
            this.txtTk.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtTk.ListFilter = new string[0];
            this.txtTk.Location = new System.Drawing.Point(112, 17);
            this.txtTk.LookupKeyFilter = "";
            this.txtTk.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTk.Name = "txtTk";
            this.txtTk.ReadOnly = true;
            this.txtTk.Size = new System.Drawing.Size(120, 20);
            this.txtTk.TabIndex = 0;
            this.txtTk.Text = "1311";
            this.txtTk.UseAutoFilter = true;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.bAllowEmpty = false;
            this.dteNgay_Ct1.bRequire = true;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.bShowDateTimePicker = true;
            this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(112, 105);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(120, 20);
            this.dteNgay_Ct1.TabIndex = 3;
            // 
            // lblNgay_Ct
            // 
            this.lblNgay_Ct.AutoEllipsis = true;
            this.lblNgay_Ct.AutoSize = true;
            this.lblNgay_Ct.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgay_Ct.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNgay_Ct.Location = new System.Drawing.Point(6, 110);
            this.lblNgay_Ct.Name = "lblNgay_Ct";
            this.lblNgay_Ct.Size = new System.Drawing.Size(48, 13);
            this.lblNgay_Ct.TabIndex = 61;
            this.lblNgay_Ct.Tag = "Ngay_Ct1";
            this.lblNgay_Ct.Text = "Từ Ngày";
            this.lblNgay_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Dt
            // 
            this.lbtTen_Dt.AutoEllipsis = true;
            this.lbtTen_Dt.AutoSize = true;
            this.lbtTen_Dt.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Dt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_Dt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt.Location = new System.Drawing.Point(237, 85);
            this.lbtTen_Dt.Name = "lbtTen_Dt";
            this.lbtTen_Dt.Size = new System.Drawing.Size(86, 13);
            this.lbtTen_Dt.TabIndex = 63;
            this.lbtTen_Dt.Text = "Tên khách hàng";
            this.lbtTen_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt
            // 
            this.txtMa_Dt.bEnabled = true;
            this.txtMa_Dt.bIsLookup = false;
            this.txtMa_Dt.bReadOnly = false;
            this.txtMa_Dt.bRequire = false;
            this.txtMa_Dt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt.ColumnsView = null;
            this.txtMa_Dt.CtrlDepend = null;
            this.txtMa_Dt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_Dt.KeyFilter = "Ma_Dt";
            this.txtMa_Dt.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtMa_Dt.ListFilter = new string[0];
            this.txtMa_Dt.Location = new System.Drawing.Point(112, 82);
            this.txtMa_Dt.LookupKeyFilter = "";
            this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt.Name = "txtMa_Dt";
            this.txtMa_Dt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Dt.TabIndex = 0;
            this.txtMa_Dt.UseAutoFilter = true;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblControl1.Location = new System.Drawing.Point(6, 85);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(70, 13);
            this.lblControl1.TabIndex = 60;
            this.lblControl1.Tag = "Ma_Dt";
            this.lblControl1.Text = "Mã đối tượng";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Tk
            // 
            this.lbtTen_Tk.AutoEllipsis = true;
            this.lbtTen_Tk.AutoSize = true;
            this.lbtTen_Tk.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Tk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_Tk.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Tk.Location = new System.Drawing.Point(236, 20);
            this.lbtTen_Tk.Name = "lbtTen_Tk";
            this.lbtTen_Tk.Size = new System.Drawing.Size(73, 13);
            this.lbtTen_Tk.TabIndex = 63;
            this.lbtTen_Tk.Text = "Tên tài khoản";
            this.lbtTen_Tk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkDu_Cuoi_Only
            // 
            this.chkDu_Cuoi_Only.AutoSize = true;
            this.chkDu_Cuoi_Only.Checked = true;
            this.chkDu_Cuoi_Only.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDu_Cuoi_Only.Location = new System.Drawing.Point(325, 82);
            this.chkDu_Cuoi_Only.Name = "chkDu_Cuoi_Only";
            this.chkDu_Cuoi_Only.Size = new System.Drawing.Size(176, 17);
            this.chkDu_Cuoi_Only.TabIndex = 5;
            this.chkDu_Cuoi_Only.Tag = "Du_Cuoi_Only";
            this.chkDu_Cuoi_Only.Text = "Hiện những chứng từ còn số dư";
            this.chkDu_Cuoi_Only.UseVisualStyleBackColor = true;
            // 
            // btFillterData
            // 
            this.btFillterData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFillterData.Image = ((System.Drawing.Image)(resources.GetObject("btFillterData.Image")));
            this.btFillterData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFillterData.Location = new System.Drawing.Point(240, 110);
            this.btFillterData.Name = "btFillterData";
            this.btFillterData.Size = new System.Drawing.Size(121, 33);
            this.btFillterData.TabIndex = 6;
            this.btFillterData.Tag = "Preview";
            this.btFillterData.Text = "Xem";
            this.btFillterData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFillterData.UseVisualStyleBackColor = true;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblControl2.Location = new System.Drawing.Point(6, 131);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(55, 13);
            this.lblControl2.TabIndex = 61;
            this.lblControl2.Tag = "Ngay_Ct2";
            this.lblControl2.Text = "Đến Ngày";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.bAllowEmpty = false;
            this.dteNgay_Ct2.bRequire = true;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.bShowDateTimePicker = true;
            this.dteNgay_Ct2.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(112, 127);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(120, 20);
            this.dteNgay_Ct2.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btFillterData);
            this.groupBox1.Controls.Add(this.chkDu_Cuoi_Only);
            this.groupBox1.Controls.Add(this.lblMa_Tte);
            this.groupBox1.Controls.Add(this.txtMa_Tte);
            this.groupBox1.Controls.Add(this.lbtTen_Tk);
            this.groupBox1.Controls.Add(this.numTy_Gia);
            this.groupBox1.Controls.Add(this.lbtTen_Dt);
            this.groupBox1.Controls.Add(this.dteNgay_Ct2);
            this.groupBox1.Controls.Add(this.txtTk);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblControl2);
            this.groupBox1.Controls.Add(this.numTien_Tt_Auto);
            this.groupBox1.Controls.Add(this.txtMa_Tuyen);
            this.groupBox1.Controls.Add(this.txtMa_Nh_Dt);
            this.groupBox1.Controls.Add(this.txtMa_Dt);
            this.groupBox1.Controls.Add(this.dteNgay_Ct1);
            this.groupBox1.Controls.Add(this.lblControl9);
            this.groupBox1.Controls.Add(this.lblTk);
            this.groupBox1.Controls.Add(this.lblControl7);
            this.groupBox1.Controls.Add(this.lblNgay_Ct);
            this.groupBox1.Controls.Add(this.lblControl1);
            this.groupBox1.Location = new System.Drawing.Point(607, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 151);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lọc dữ liệu";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(241, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Tag = "";
            this.label2.Text = "Tiền thanh toán";
            this.label2.Visible = false;
            // 
            // numTien_Tt_Auto
            // 
            this.numTien_Tt_Auto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTien_Tt_Auto.bEnabled = true;
            this.numTien_Tt_Auto.bFormat = true;
            this.numTien_Tt_Auto.bIsLookup = false;
            this.numTien_Tt_Auto.bReadOnly = false;
            this.numTien_Tt_Auto.bRequire = false;
            this.numTien_Tt_Auto.KeyFilter = "";
            this.numTien_Tt_Auto.Location = new System.Drawing.Point(340, 61);
            this.numTien_Tt_Auto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTien_Tt_Auto.Name = "numTien_Tt_Auto";
            this.numTien_Tt_Auto.Scale = 0;
            this.numTien_Tt_Auto.Size = new System.Drawing.Size(121, 20);
            this.numTien_Tt_Auto.TabIndex = 2;
            this.numTien_Tt_Auto.Text = "0";
            this.numTien_Tt_Auto.UseAutoFilter = false;
            this.numTien_Tt_Auto.Value = 0D;
            this.numTien_Tt_Auto.Visible = false;
            // 
            // txtMa_Tuyen
            // 
            this.txtMa_Tuyen.bEnabled = true;
            this.txtMa_Tuyen.bIsLookup = false;
            this.txtMa_Tuyen.bReadOnly = false;
            this.txtMa_Tuyen.bRequire = false;
            this.txtMa_Tuyen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Tuyen.ColumnsView = null;
            this.txtMa_Tuyen.CtrlDepend = null;
            this.txtMa_Tuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_Tuyen.KeyFilter = "Ma_Tuyen";
            this.txtMa_Tuyen.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtMa_Tuyen.ListFilter = new string[0];
            this.txtMa_Tuyen.Location = new System.Drawing.Point(112, 39);
            this.txtMa_Tuyen.LookupKeyFilter = "";
            this.txtMa_Tuyen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Tuyen.Name = "txtMa_Tuyen";
            this.txtMa_Tuyen.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Tuyen.TabIndex = 0;
            this.txtMa_Tuyen.UseAutoFilter = true;
            // 
            // txtMa_Nh_Dt
            // 
            this.txtMa_Nh_Dt.bEnabled = true;
            this.txtMa_Nh_Dt.bIsLookup = false;
            this.txtMa_Nh_Dt.bReadOnly = false;
            this.txtMa_Nh_Dt.bRequire = false;
            this.txtMa_Nh_Dt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Nh_Dt.ColumnsView = null;
            this.txtMa_Nh_Dt.CtrlDepend = null;
            this.txtMa_Nh_Dt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_Nh_Dt.KeyFilter = "Ma_Nh_Dt";
            this.txtMa_Nh_Dt.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtMa_Nh_Dt.ListFilter = new string[0];
            this.txtMa_Nh_Dt.Location = new System.Drawing.Point(112, 61);
            this.txtMa_Nh_Dt.LookupKeyFilter = "";
            this.txtMa_Nh_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Nh_Dt.Name = "txtMa_Nh_Dt";
            this.txtMa_Nh_Dt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Nh_Dt.TabIndex = 0;
            this.txtMa_Nh_Dt.UseAutoFilter = true;
            // 
            // lblControl9
            // 
            this.lblControl9.AutoEllipsis = true;
            this.lblControl9.AutoSize = true;
            this.lblControl9.BackColor = System.Drawing.Color.Transparent;
            this.lblControl9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblControl9.Location = new System.Drawing.Point(6, 42);
            this.lblControl9.Name = "lblControl9";
            this.lblControl9.Size = new System.Drawing.Size(55, 13);
            this.lblControl9.TabIndex = 60;
            this.lblControl9.Tag = "Ma_Tuyen";
            this.lblControl9.Text = "Mã Tuyến";
            this.lblControl9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl7
            // 
            this.lblControl7.AutoEllipsis = true;
            this.lblControl7.AutoSize = true;
            this.lblControl7.BackColor = System.Drawing.Color.Transparent;
            this.lblControl7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblControl7.Location = new System.Drawing.Point(6, 64);
            this.lblControl7.Name = "lblControl7";
            this.lblControl7.Size = new System.Drawing.Size(39, 13);
            this.lblControl7.TabIndex = 60;
            this.lblControl7.Tag = "Ma_Px";
            this.lblControl7.Text = "Mã PX";
            this.lblControl7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cboTK_List);
            this.groupBox2.Controls.Add(this.lblControl5);
            this.groupBox2.Controls.Add(this.lblOng_Ba);
            this.groupBox2.Controls.Add(this.txtDien_Giai);
            this.groupBox2.Controls.Add(this.btCheckAll);
            this.groupBox2.Controls.Add(this.btThanhtoan);
            this.groupBox2.Controls.Add(this.lbt_Ten_Tk_Tt);
            this.groupBox2.Controls.Add(this.txtTk_Tt);
            this.groupBox2.Controls.Add(this.dteNgay_Ct_TT);
            this.groupBox2.Controls.Add(this.numTTien_Tt_Nt);
            this.groupBox2.Controls.Add(this.numTSo_Luong);
            this.groupBox2.Controls.Add(this.lblControl8);
            this.groupBox2.Controls.Add(this.lblControl11);
            this.groupBox2.Controls.Add(this.lblControl12);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(603, 125);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin thanh toán";
            // 
            // cboTK_List
            // 
            this.cboTK_List.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTK_List.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboTK_List.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboTK_List.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTK_List.FormattingEnabled = true;
            this.cboTK_List.InitValue = null;
            this.cboTK_List.Location = new System.Drawing.Point(111, 24);
            this.cboTK_List.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboTK_List.MaxLength = 20;
            this.cboTK_List.Name = "cboTK_List";
            this.cboTK_List.Size = new System.Drawing.Size(120, 21);
            this.cboTK_List.strValueList = null;
            this.cboTK_List.TabIndex = 66;
            this.cboTK_List.UpperCase = false;
            this.cboTK_List.UseAutoComplete = false;
            this.cboTK_List.UseBindingValue = false;
            // 
            // lblControl5
            // 
            this.lblControl5.AutoEllipsis = true;
            this.lblControl5.AutoSize = true;
            this.lblControl5.BackColor = System.Drawing.Color.Transparent;
            this.lblControl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblControl5.Location = new System.Drawing.Point(248, 28);
            this.lblControl5.Name = "lblControl5";
            this.lblControl5.Size = new System.Drawing.Size(61, 13);
            this.lblControl5.TabIndex = 65;
            this.lblControl5.Tag = "";
            this.lblControl5.Text = "Tổng số vỏ";
            this.lblControl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOng_Ba
            // 
            this.lblOng_Ba.AutoEllipsis = true;
            this.lblOng_Ba.AutoSize = true;
            this.lblOng_Ba.BackColor = System.Drawing.Color.Transparent;
            this.lblOng_Ba.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOng_Ba.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOng_Ba.Location = new System.Drawing.Point(12, 105);
            this.lblOng_Ba.Name = "lblOng_Ba";
            this.lblOng_Ba.Size = new System.Drawing.Size(48, 13);
            this.lblOng_Ba.TabIndex = 65;
            this.lblOng_Ba.Tag = "";
            this.lblOng_Ba.Text = "Diễn giải";
            this.lblOng_Ba.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDien_Giai
            // 
            this.txtDien_Giai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDien_Giai.bEnabled = true;
            this.txtDien_Giai.bIsLookup = false;
            this.txtDien_Giai.bReadOnly = false;
            this.txtDien_Giai.bRequire = false;
            this.txtDien_Giai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDien_Giai.KeyFilter = "";
            this.txtDien_Giai.Location = new System.Drawing.Point(111, 103);
            this.txtDien_Giai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDien_Giai.MaxLength = 100;
            this.txtDien_Giai.Name = "txtDien_Giai";
            this.txtDien_Giai.Size = new System.Drawing.Size(241, 20);
            this.txtDien_Giai.TabIndex = 2;
            this.txtDien_Giai.Text = "Thu hồi vỏ chai khách hàng";
            this.txtDien_Giai.UseAutoFilter = false;
            // 
            // btCheckAll
            // 
            this.btCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCheckAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCheckAll.Image = ((System.Drawing.Image)(resources.GetObject("btCheckAll.Image")));
            this.btCheckAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCheckAll.Location = new System.Drawing.Point(377, 91);
            this.btCheckAll.Name = "btCheckAll";
            this.btCheckAll.Size = new System.Drawing.Size(106, 32);
            this.btCheckAll.TabIndex = 5;
            this.btCheckAll.Tag = "";
            this.btCheckAll.Text = "Chọn tất cả";
            this.btCheckAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCheckAll.UseVisualStyleBackColor = true;
            // 
            // btThanhtoan
            // 
            this.btThanhtoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btThanhtoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThanhtoan.Image = ((System.Drawing.Image)(resources.GetObject("btThanhtoan.Image")));
            this.btThanhtoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btThanhtoan.Location = new System.Drawing.Point(489, 91);
            this.btThanhtoan.Name = "btThanhtoan";
            this.btThanhtoan.Size = new System.Drawing.Size(106, 31);
            this.btThanhtoan.TabIndex = 3;
            this.btThanhtoan.Tag = "";
            this.btThanhtoan.Text = "Xử lý";
            this.btThanhtoan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btThanhtoan.UseVisualStyleBackColor = true;
            // 
            // lbt_Ten_Tk_Tt
            // 
            this.lbt_Ten_Tk_Tt.AutoEllipsis = true;
            this.lbt_Ten_Tk_Tt.AutoSize = true;
            this.lbt_Ten_Tk_Tt.BackColor = System.Drawing.Color.Transparent;
            this.lbt_Ten_Tk_Tt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbt_Ten_Tk_Tt.ForeColor = System.Drawing.Color.Blue;
            this.lbt_Ten_Tk_Tt.Location = new System.Drawing.Point(236, 54);
            this.lbt_Ten_Tk_Tt.Name = "lbt_Ten_Tk_Tt";
            this.lbt_Ten_Tk_Tt.Size = new System.Drawing.Size(73, 13);
            this.lbt_Ten_Tk_Tt.TabIndex = 63;
            this.lbt_Ten_Tk_Tt.Text = "Tên tài khoản";
            this.lbt_Ten_Tk_Tt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTk_Tt
            // 
            this.txtTk_Tt.bEnabled = true;
            this.txtTk_Tt.bIsLookup = false;
            this.txtTk_Tt.bReadOnly = false;
            this.txtTk_Tt.bRequire = false;
            this.txtTk_Tt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTk_Tt.ColumnsView = null;
            this.txtTk_Tt.CtrlDepend = null;
            this.txtTk_Tt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTk_Tt.KeyFilter = "Tk";
            this.txtTk_Tt.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtTk_Tt.ListFilter = new string[0];
            this.txtTk_Tt.Location = new System.Drawing.Point(111, 51);
            this.txtTk_Tt.LookupKeyFilter = "";
            this.txtTk_Tt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTk_Tt.Name = "txtTk_Tt";
            this.txtTk_Tt.ReadOnly = true;
            this.txtTk_Tt.Size = new System.Drawing.Size(120, 20);
            this.txtTk_Tt.TabIndex = 0;
            this.txtTk_Tt.Text = "1111";
            this.txtTk_Tt.UseAutoFilter = true;
            // 
            // dteNgay_Ct_TT
            // 
            this.dteNgay_Ct_TT.bAllowEmpty = false;
            this.dteNgay_Ct_TT.bRequire = true;
            this.dteNgay_Ct_TT.bSelectOnFocus = false;
            this.dteNgay_Ct_TT.bShowDateTimePicker = true;
            this.dteNgay_Ct_TT.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct_TT.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct_TT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteNgay_Ct_TT.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct_TT.Location = new System.Drawing.Point(111, 76);
            this.dteNgay_Ct_TT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct_TT.Mask = "00/00/0000";
            this.dteNgay_Ct_TT.Name = "dteNgay_Ct_TT";
            this.dteNgay_Ct_TT.Size = new System.Drawing.Size(120, 20);
            this.dteNgay_Ct_TT.TabIndex = 0;
            // 
            // numTTien_Tt_Nt
            // 
            this.numTTien_Tt_Nt.bEnabled = true;
            this.numTTien_Tt_Nt.bFormat = true;
            this.numTTien_Tt_Nt.bIsLookup = false;
            this.numTTien_Tt_Nt.bReadOnly = false;
            this.numTTien_Tt_Nt.bRequire = false;
            this.numTTien_Tt_Nt.Enabled = false;
            this.numTTien_Tt_Nt.KeyFilter = "";
            this.numTTien_Tt_Nt.Location = new System.Drawing.Point(475, 28);
            this.numTTien_Tt_Nt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien_Tt_Nt.Name = "numTTien_Tt_Nt";
            this.numTTien_Tt_Nt.Scale = 0;
            this.numTTien_Tt_Nt.Size = new System.Drawing.Size(121, 20);
            this.numTTien_Tt_Nt.TabIndex = 2;
            this.numTTien_Tt_Nt.Text = "0";
            this.numTTien_Tt_Nt.UseAutoFilter = false;
            this.numTTien_Tt_Nt.Value = 0D;
            this.numTTien_Tt_Nt.Visible = false;
            // 
            // lblControl8
            // 
            this.lblControl8.AutoEllipsis = true;
            this.lblControl8.AutoSize = true;
            this.lblControl8.BackColor = System.Drawing.Color.Transparent;
            this.lblControl8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblControl8.Location = new System.Drawing.Point(10, 28);
            this.lblControl8.Name = "lblControl8";
            this.lblControl8.Size = new System.Drawing.Size(81, 13);
            this.lblControl8.TabIndex = 60;
            this.lblControl8.Tag = "";
            this.lblControl8.Text = "Loại thanh toán";
            this.lblControl8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl11
            // 
            this.lblControl11.AutoEllipsis = true;
            this.lblControl11.AutoSize = true;
            this.lblControl11.BackColor = System.Drawing.Color.Transparent;
            this.lblControl11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblControl11.Location = new System.Drawing.Point(10, 54);
            this.lblControl11.Name = "lblControl11";
            this.lblControl11.Size = new System.Drawing.Size(55, 13);
            this.lblControl11.TabIndex = 60;
            this.lblControl11.Tag = "Tk";
            this.lblControl11.Text = "Tài khoản";
            this.lblControl11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl12
            // 
            this.lblControl12.AutoEllipsis = true;
            this.lblControl12.AutoSize = true;
            this.lblControl12.BackColor = System.Drawing.Color.Transparent;
            this.lblControl12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblControl12.Location = new System.Drawing.Point(10, 76);
            this.lblControl12.Name = "lblControl12";
            this.lblControl12.Size = new System.Drawing.Size(86, 13);
            this.lblControl12.TabIndex = 61;
            this.lblControl12.Tag = "Ngay_tt";
            this.lblControl12.Text = "Ngày thanh toán";
            this.lblControl12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmThuHoiVC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(991, 733);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabChiTietThuHoi);
            this.Controls.Add(this.btSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThuHoiVC";
            this.Text = "frmHanTt_View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabChiTietThuHoi.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHanTt0)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabChiTietThuHoi;
        private System.Windows.Forms.TabPage tabPage1;
        private Epoint.Systems.Controls.btControl btSave;
        private Epoint.Systems.Controls.numControl numTSo_Luong;
        private Systems.Controls.dgvGridControl dgvHanTt0;
        private Systems.Controls.lblControl lblMa_Tte;
        private Systems.Controls.txtEnum txtMa_Tte;
        private Systems.Controls.numControl numTy_Gia;
        private Systems.Controls.lblControl lblTk;
        private Systems.Controls.txtTextLookup txtTk;
        private Systems.Controls.txtDateTime dteNgay_Ct1;
        private Systems.Controls.lblControl lblNgay_Ct;
        private Systems.Controls.lblControl lbtTen_Dt;
        private Systems.Controls.txtTextLookup txtMa_Dt;
        private Systems.Controls.lblControl lblControl1;
        private Systems.Controls.lblControl lbtTen_Tk;
        public Systems.Controls.chkControl chkDu_Cuoi_Only;
        private Systems.Customizes.btPreview btFillterData;
        private Systems.Controls.lblControl lblControl2;
        private Systems.Controls.txtDateTime dteNgay_Ct2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Systems.Customizes.btPreview btThanhtoan;
        private Systems.Controls.lblControl lbt_Ten_Tk_Tt;
        private Systems.Controls.txtTextLookup txtTk_Tt;
        private Systems.Controls.txtDateTime dteNgay_Ct_TT;
        private Systems.Controls.lblControl lblControl11;
        private Systems.Controls.lblControl lblControl12;
        private Systems.Controls.lblControl lblOng_Ba;
        private Systems.Controls.txtTextBox txtDien_Giai;
        private Systems.Controls.numControl numTTien_Tt_Nt;
        private Systems.Controls.lblControl lblControl5;
        private Systems.Customizes.btPreview btCheckAll;
        private Systems.Controls.cboMultiControl cboTK_List;
        private Systems.Controls.lblControl lblControl8;
        private Systems.Controls.txtTextLookup txtMa_Nh_Dt;
        private Systems.Controls.lblControl lblControl7;
        private Systems.Controls.txtTextLookup txtMa_Tuyen;
        private Systems.Controls.lblControl lblControl9;
        private System.Windows.Forms.Label label2;
        private Systems.Controls.numControl numTien_Tt_Auto;
	}
}