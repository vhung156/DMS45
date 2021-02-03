namespace Epoint.Modules.AS
{
    partial class frmCtCCDCStatus_Edit
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
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.lblNgay_Ps = new Epoint.Systems.Controls.lblControl();
            this.dteNgay_Ps = new Epoint.Systems.Controls.txtDateTime();
            this.lbtTen_CCDC = new Epoint.Systems.Controls.lblControl();
            this.txtMa_CCDC = new Epoint.Systems.Controls.txtTextBox();
            this.lbMa_CCDC = new Epoint.Systems.Controls.lblControl();
            this.chkTinh_Pb = new Epoint.Systems.Controls.chkControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbtTen_Tk_Co = new Epoint.Systems.Controls.lblControl();
            this.lblTk_No = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Tk_No = new Epoint.Systems.Controls.lblControl();
            this.lblTk_Co = new Epoint.Systems.Controls.lblControl();
            this.numSo_Thang_Kh = new Epoint.Systems.Controls.numControl();
            this.lblSo_Thang = new Epoint.Systems.Controls.lblControl();
            this.lblStt_NGia = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_CCDC_NGia = new Epoint.Systems.Controls.lblControl();
            this.cboStt = new Epoint.Systems.Controls.cboMultiControl();
            this.txtMa_Sp = new Epoint.Systems.Controls.txtTextLookup();
            this.txtMa_Km = new Epoint.Systems.Controls.txtTextLookup();
            this.txtMa_Bp = new Epoint.Systems.Controls.txtTextLookup();
            this.lbtTen_Sp = new Epoint.Systems.Controls.lblControl();
            this.lblMa_Sp = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Km = new Epoint.Systems.Controls.lblControl();
            this.lblMa_Km = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Bp = new Epoint.Systems.Controls.lblControl();
            this.lbMa_Bp = new Epoint.Systems.Controls.lblControl();
            this.txtTk_Co = new Epoint.Systems.Controls.txtTextLookup();
            this.txtTk_No = new Epoint.Systems.Controls.txtTextLookup();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(342, 323);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 29);
            this.btgAccept.TabIndex = 9;
            // 
            // lblNgay_Ps
            // 
            this.lblNgay_Ps.AutoEllipsis = true;
            this.lblNgay_Ps.AutoSize = true;
            this.lblNgay_Ps.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay_Ps.Location = new System.Drawing.Point(31, 80);
            this.lblNgay_Ps.Name = "lblNgay_Ps";
            this.lblNgay_Ps.Size = new System.Drawing.Size(78, 13);
            this.lblNgay_Ps.TabIndex = 46;
            this.lblNgay_Ps.Tag = "Ngay_Ps";
            this.lblNgay_Ps.Text = "Ngày phát sinh";
            this.lblNgay_Ps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ps
            // 
            this.dteNgay_Ps.bAllowEmpty = true;
            this.dteNgay_Ps.bRequire = false;
            this.dteNgay_Ps.bSelectOnFocus = true;
            this.dteNgay_Ps.bShowDateTimePicker = true;
            this.dteNgay_Ps.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ps.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ps.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ps.Location = new System.Drawing.Point(135, 76);
            this.dteNgay_Ps.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ps.Mask = "00/00/0000";
            this.dteNgay_Ps.Name = "dteNgay_Ps";
            this.dteNgay_Ps.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ps.TabIndex = 2;
            // 
            // lbtTen_CCDC
            // 
            this.lbtTen_CCDC.AutoEllipsis = true;
            this.lbtTen_CCDC.AutoSize = true;
            this.lbtTen_CCDC.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_CCDC.Enabled = false;
            this.lbtTen_CCDC.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_CCDC.Location = new System.Drawing.Point(261, 32);
            this.lbtTen_CCDC.Name = "lbtTen_CCDC";
            this.lbtTen_CCDC.Size = new System.Drawing.Size(58, 13);
            this.lbtTen_CCDC.TabIndex = 2;
            this.lbtTen_CCDC.Text = "Tên CCDC";
            this.lbtTen_CCDC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_CCDC
            // 
            this.txtMa_CCDC.bEnabled = true;
            this.txtMa_CCDC.bIsLookup = false;
            this.txtMa_CCDC.bReadOnly = false;
            this.txtMa_CCDC.bRequire = false;
            this.txtMa_CCDC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_CCDC.Enabled = false;
            this.txtMa_CCDC.KeyFilter = "";
            this.txtMa_CCDC.Location = new System.Drawing.Point(135, 29);
            this.txtMa_CCDC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_CCDC.MaxLength = 20;
            this.txtMa_CCDC.Name = "txtMa_CCDC";
            this.txtMa_CCDC.Size = new System.Drawing.Size(120, 20);
            this.txtMa_CCDC.TabIndex = 0;
            this.txtMa_CCDC.UseAutoFilter = false;
            // 
            // lbMa_CCDC
            // 
            this.lbMa_CCDC.AutoEllipsis = true;
            this.lbMa_CCDC.AutoSize = true;
            this.lbMa_CCDC.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_CCDC.Location = new System.Drawing.Point(31, 32);
            this.lbMa_CCDC.Name = "lbMa_CCDC";
            this.lbMa_CCDC.Size = new System.Drawing.Size(54, 13);
            this.lbMa_CCDC.TabIndex = 0;
            this.lbMa_CCDC.Tag = "Ma_CCDC";
            this.lbMa_CCDC.Text = "Mã CCDC";
            this.lbMa_CCDC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkTinh_Pb
            // 
            this.chkTinh_Pb.AutoSize = true;
            this.chkTinh_Pb.Checked = true;
            this.chkTinh_Pb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTinh_Pb.Location = new System.Drawing.Point(34, 212);
            this.chkTinh_Pb.Name = "chkTinh_Pb";
            this.chkTinh_Pb.Size = new System.Drawing.Size(91, 17);
            this.chkTinh_Pb.TabIndex = 7;
            this.chkTinh_Pb.Tag = "Tinh_Pb";
            this.chkTinh_Pb.Text = "Tính phân bổ";
            this.chkTinh_Pb.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTk_Co);
            this.groupBox1.Controls.Add(this.txtTk_No);
            this.groupBox1.Controls.Add(this.lbtTen_Tk_Co);
            this.groupBox1.Controls.Add(this.lblTk_No);
            this.groupBox1.Controls.Add(this.lbtTen_Tk_No);
            this.groupBox1.Controls.Add(this.lblTk_Co);
            this.groupBox1.Location = new System.Drawing.Point(34, 225);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 71);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // lbtTen_Tk_Co
            // 
            this.lbtTen_Tk_Co.AutoEllipsis = true;
            this.lbtTen_Tk_Co.AutoSize = true;
            this.lbtTen_Tk_Co.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Tk_Co.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Tk_Co.Location = new System.Drawing.Point(191, 42);
            this.lbtTen_Tk_Co.Name = "lbtTen_Tk_Co";
            this.lbtTen_Tk_Co.Size = new System.Drawing.Size(88, 13);
            this.lbtTen_Tk_Co.TabIndex = 7;
            this.lbtTen_Tk_Co.Text = "Tên tài khoản có";
            this.lbtTen_Tk_Co.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTk_No
            // 
            this.lblTk_No.AutoEllipsis = true;
            this.lblTk_No.AutoSize = true;
            this.lblTk_No.BackColor = System.Drawing.Color.Transparent;
            this.lblTk_No.Location = new System.Drawing.Point(9, 19);
            this.lblTk_No.Name = "lblTk_No";
            this.lblTk_No.Size = new System.Drawing.Size(70, 13);
            this.lblTk_No.TabIndex = 2;
            this.lblTk_No.Tag = "Tk_No";
            this.lblTk_No.Text = "Tài khoản nợ";
            this.lblTk_No.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Tk_No
            // 
            this.lbtTen_Tk_No.AutoEllipsis = true;
            this.lbtTen_Tk_No.AutoSize = true;
            this.lbtTen_Tk_No.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Tk_No.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Tk_No.Location = new System.Drawing.Point(191, 19);
            this.lbtTen_Tk_No.Name = "lbtTen_Tk_No";
            this.lbtTen_Tk_No.Size = new System.Drawing.Size(88, 13);
            this.lbtTen_Tk_No.TabIndex = 4;
            this.lbtTen_Tk_No.Text = "Tên tài khoản nợ";
            this.lbtTen_Tk_No.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTk_Co
            // 
            this.lblTk_Co.AutoEllipsis = true;
            this.lblTk_Co.AutoSize = true;
            this.lblTk_Co.BackColor = System.Drawing.Color.Transparent;
            this.lblTk_Co.Location = new System.Drawing.Point(9, 42);
            this.lblTk_Co.Name = "lblTk_Co";
            this.lblTk_Co.Size = new System.Drawing.Size(70, 13);
            this.lblTk_Co.TabIndex = 5;
            this.lblTk_Co.Tag = "Tk_Co";
            this.lblTk_Co.Text = "Tài khoản có";
            this.lblTk_Co.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSo_Thang_Kh
            // 
            this.numSo_Thang_Kh.bEnabled = true;
            this.numSo_Thang_Kh.bFormat = true;
            this.numSo_Thang_Kh.bIsLookup = false;
            this.numSo_Thang_Kh.bReadOnly = false;
            this.numSo_Thang_Kh.bRequire = false;
            this.numSo_Thang_Kh.KeyFilter = "";
            this.numSo_Thang_Kh.Location = new System.Drawing.Point(135, 177);
            this.numSo_Thang_Kh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numSo_Thang_Kh.Name = "numSo_Thang_Kh";
            this.numSo_Thang_Kh.Scale = 0;
            this.numSo_Thang_Kh.Size = new System.Drawing.Size(38, 20);
            this.numSo_Thang_Kh.TabIndex = 6;
            this.numSo_Thang_Kh.Text = "0";
            this.numSo_Thang_Kh.UseAutoFilter = false;
            this.numSo_Thang_Kh.Value = 0D;
            // 
            // lblSo_Thang
            // 
            this.lblSo_Thang.AutoEllipsis = true;
            this.lblSo_Thang.AutoSize = true;
            this.lblSo_Thang.BackColor = System.Drawing.Color.Transparent;
            this.lblSo_Thang.Location = new System.Drawing.Point(31, 179);
            this.lblSo_Thang.Name = "lblSo_Thang";
            this.lblSo_Thang.Size = new System.Drawing.Size(50, 13);
            this.lblSo_Thang.TabIndex = 0;
            this.lblSo_Thang.Tag = "So_Thang_Kh";
            this.lblSo_Thang.Text = "Số tháng";
            this.lblSo_Thang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStt_NGia
            // 
            this.lblStt_NGia.AutoEllipsis = true;
            this.lblStt_NGia.AutoSize = true;
            this.lblStt_NGia.BackColor = System.Drawing.Color.Transparent;
            this.lblStt_NGia.Location = new System.Drawing.Point(31, 55);
            this.lblStt_NGia.Name = "lblStt_NGia";
            this.lblStt_NGia.Size = new System.Drawing.Size(47, 13);
            this.lblStt_NGia.TabIndex = 85;
            this.lblStt_NGia.Tag = "Stt_NGia";
            this.lblStt_NGia.Text = "Stt NGia";
            this.lblStt_NGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_CCDC_NGia
            // 
            this.lbtTen_CCDC_NGia.AutoEllipsis = true;
            this.lbtTen_CCDC_NGia.AutoSize = true;
            this.lbtTen_CCDC_NGia.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_CCDC_NGia.Enabled = false;
            this.lbtTen_CCDC_NGia.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_CCDC_NGia.Location = new System.Drawing.Point(260, 56);
            this.lbtTen_CCDC_NGia.Name = "lbtTen_CCDC_NGia";
            this.lbtTen_CCDC_NGia.Size = new System.Drawing.Size(58, 13);
            this.lbtTen_CCDC_NGia.TabIndex = 84;
            this.lbtTen_CCDC_NGia.Tag = "Ten_CCDC";
            this.lbtTen_CCDC_NGia.Text = "Tên CCDC";
            this.lbtTen_CCDC_NGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboStt
            // 
            this.cboStt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboStt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboStt.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboStt.Location = new System.Drawing.Point(135, 52);
            this.cboStt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboStt.MaxLength = 20;
            this.cboStt.Name = "cboStt";
            this.cboStt.Size = new System.Drawing.Size(120, 21);
            this.cboStt.TabIndex = 1;
            // 
            // txtMa_Sp
            // 
            this.txtMa_Sp.bEnabled = true;
            this.txtMa_Sp.bIsLookup = false;
            this.txtMa_Sp.bReadOnly = false;
            this.txtMa_Sp.bRequire = false;
            this.txtMa_Sp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Sp.ColumnsView = null;
            this.txtMa_Sp.KeyFilter = "Ma_Sp";
            this.txtMa_Sp.Location = new System.Drawing.Point(135, 154);
            this.txtMa_Sp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Sp.Name = "txtMa_Sp";
            this.txtMa_Sp.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Sp.TabIndex = 5;
            this.txtMa_Sp.UseAutoFilter = true;
            // 
            // txtMa_Km
            // 
            this.txtMa_Km.bEnabled = true;
            this.txtMa_Km.bIsLookup = false;
            this.txtMa_Km.bReadOnly = false;
            this.txtMa_Km.bRequire = false;
            this.txtMa_Km.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Km.ColumnsView = null;
            this.txtMa_Km.KeyFilter = "Ma_Km";
            this.txtMa_Km.Location = new System.Drawing.Point(135, 131);
            this.txtMa_Km.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Km.Name = "txtMa_Km";
            this.txtMa_Km.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Km.TabIndex = 4;
            this.txtMa_Km.UseAutoFilter = true;
            // 
            // txtMa_Bp
            // 
            this.txtMa_Bp.bEnabled = true;
            this.txtMa_Bp.bIsLookup = false;
            this.txtMa_Bp.bReadOnly = false;
            this.txtMa_Bp.bRequire = false;
            this.txtMa_Bp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Bp.ColumnsView = null;
            this.txtMa_Bp.KeyFilter = "Ma_Bp";
            this.txtMa_Bp.Location = new System.Drawing.Point(135, 108);
            this.txtMa_Bp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Bp.Name = "txtMa_Bp";
            this.txtMa_Bp.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Bp.TabIndex = 3;
            this.txtMa_Bp.UseAutoFilter = true;
            // 
            // lbtTen_Sp
            // 
            this.lbtTen_Sp.AutoEllipsis = true;
            this.lbtTen_Sp.AutoSize = true;
            this.lbtTen_Sp.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Sp.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Sp.Location = new System.Drawing.Point(260, 158);
            this.lbtTen_Sp.Name = "lbtTen_Sp";
            this.lbtTen_Sp.Size = new System.Drawing.Size(75, 13);
            this.lbtTen_Sp.TabIndex = 226;
            this.lbtTen_Sp.Text = "Tên sản phẩm";
            this.lbtTen_Sp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMa_Sp
            // 
            this.lblMa_Sp.AutoEllipsis = true;
            this.lblMa_Sp.AutoSize = true;
            this.lblMa_Sp.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Sp.Location = new System.Drawing.Point(31, 157);
            this.lblMa_Sp.Name = "lblMa_Sp";
            this.lblMa_Sp.Size = new System.Drawing.Size(71, 13);
            this.lblMa_Sp.TabIndex = 225;
            this.lblMa_Sp.Tag = "Ma_Sp";
            this.lblMa_Sp.Text = "Mã sản phẩm";
            this.lblMa_Sp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Km
            // 
            this.lbtTen_Km.AutoEllipsis = true;
            this.lbtTen_Km.AutoSize = true;
            this.lbtTen_Km.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Km.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Km.Location = new System.Drawing.Point(260, 136);
            this.lbtTen_Km.Name = "lbtTen_Km";
            this.lbtTen_Km.Size = new System.Drawing.Size(82, 13);
            this.lbtTen_Km.TabIndex = 224;
            this.lbtTen_Km.Text = "Tên khoản mục";
            this.lbtTen_Km.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMa_Km
            // 
            this.lblMa_Km.AutoEllipsis = true;
            this.lblMa_Km.AutoSize = true;
            this.lblMa_Km.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Km.Location = new System.Drawing.Point(31, 134);
            this.lblMa_Km.Name = "lblMa_Km";
            this.lblMa_Km.Size = new System.Drawing.Size(78, 13);
            this.lblMa_Km.TabIndex = 223;
            this.lblMa_Km.Tag = "Ma_Km";
            this.lblMa_Km.Text = "Mã khoản mục";
            this.lblMa_Km.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Bp
            // 
            this.lbtTen_Bp.AutoEllipsis = true;
            this.lbtTen_Bp.AutoSize = true;
            this.lbtTen_Bp.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Bp.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Bp.Location = new System.Drawing.Point(260, 113);
            this.lbtTen_Bp.Name = "lbtTen_Bp";
            this.lbtTen_Bp.Size = new System.Drawing.Size(71, 13);
            this.lbtTen_Bp.TabIndex = 222;
            this.lbtTen_Bp.Text = "Tên bộ phận ";
            this.lbtTen_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Bp
            // 
            this.lbMa_Bp.AutoEllipsis = true;
            this.lbMa_Bp.AutoSize = true;
            this.lbMa_Bp.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_Bp.Location = new System.Drawing.Point(31, 111);
            this.lbMa_Bp.Name = "lbMa_Bp";
            this.lbMa_Bp.Size = new System.Drawing.Size(64, 13);
            this.lbMa_Bp.TabIndex = 221;
            this.lbMa_Bp.Tag = "Ma_Bp";
            this.lbMa_Bp.Text = "Mã bộ phận";
            this.lbMa_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTk_Co
            // 
            this.txtTk_Co.bEnabled = true;
            this.txtTk_Co.bIsLookup = false;
            this.txtTk_Co.bReadOnly = false;
            this.txtTk_Co.bRequire = false;
            this.txtTk_Co.ColumnsView = null;
            this.txtTk_Co.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTk_Co.KeyFilter = "Tk_Co";
            this.txtTk_Co.Location = new System.Drawing.Point(100, 39);
            this.txtTk_Co.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTk_Co.Name = "txtTk_Co";
            this.txtTk_Co.Size = new System.Drawing.Size(67, 20);
            this.txtTk_Co.TabIndex = 1;
            this.txtTk_Co.UseAutoFilter = true;
            // 
            // txtTk_No
            // 
            this.txtTk_No.bEnabled = true;
            this.txtTk_No.bIsLookup = false;
            this.txtTk_No.bReadOnly = false;
            this.txtTk_No.bRequire = false;
            this.txtTk_No.ColumnsView = null;
            this.txtTk_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTk_No.KeyFilter = "Tk_No";
            this.txtTk_No.Location = new System.Drawing.Point(100, 16);
            this.txtTk_No.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTk_No.Name = "txtTk_No";
            this.txtTk_No.Size = new System.Drawing.Size(67, 20);
            this.txtTk_No.TabIndex = 0;
            this.txtTk_No.UseAutoFilter = true;
            // 
            // frmCtCCDCStatus_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 364);
            this.Controls.Add(this.txtMa_Sp);
            this.Controls.Add(this.txtMa_Km);
            this.Controls.Add(this.txtMa_Bp);
            this.Controls.Add(this.lbtTen_Sp);
            this.Controls.Add(this.lblMa_Sp);
            this.Controls.Add(this.lbtTen_Km);
            this.Controls.Add(this.lblMa_Km);
            this.Controls.Add(this.lbtTen_Bp);
            this.Controls.Add(this.lbMa_Bp);
            this.Controls.Add(this.lblStt_NGia);
            this.Controls.Add(this.lbtTen_CCDC_NGia);
            this.Controls.Add(this.cboStt);
            this.Controls.Add(this.chkTinh_Pb);
            this.Controls.Add(this.numSo_Thang_Kh);
            this.Controls.Add(this.lblSo_Thang);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbtTen_CCDC);
            this.Controls.Add(this.txtMa_CCDC);
            this.Controls.Add(this.lbMa_CCDC);
            this.Controls.Add(this.lblNgay_Ps);
            this.Controls.Add(this.dteNgay_Ps);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmCtCCDCStatus_Edit";
            this.Tag = "frmCtCCDCStatus";
            this.Text = "frmCtCCDCStatus";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Customizes.btgAccept btgAccept;
        private Epoint.Systems.Controls.lblControl lblNgay_Ps;
		private Epoint.Systems.Controls.txtDateTime dteNgay_Ps;
        private Epoint.Systems.Controls.lblControl lbtTen_CCDC;
        private Epoint.Systems.Controls.txtTextBox txtMa_CCDC;
		private Epoint.Systems.Controls.lblControl lbMa_CCDC;
        private Epoint.Systems.Controls.chkControl chkTinh_Pb;
		private System.Windows.Forms.GroupBox groupBox1;
        private Epoint.Systems.Controls.lblControl lbtTen_Tk_Co;
		private Epoint.Systems.Controls.lblControl lblTk_Co;
        private Epoint.Systems.Controls.lblControl lbtTen_Tk_No;
		private Epoint.Systems.Controls.lblControl lblTk_No;
		private Epoint.Systems.Controls.numControl numSo_Thang_Kh;
		private Epoint.Systems.Controls.lblControl lblSo_Thang;
		private Epoint.Systems.Controls.lblControl lblStt_NGia;
		private Epoint.Systems.Controls.lblControl lbtTen_CCDC_NGia;
		private Epoint.Systems.Controls.cboMultiControl cboStt;
        private Systems.Controls.txtTextLookup txtMa_Sp;
        private Systems.Controls.txtTextLookup txtMa_Km;
        private Systems.Controls.txtTextLookup txtMa_Bp;
        private Systems.Controls.lblControl lbtTen_Sp;
        private Systems.Controls.lblControl lblMa_Sp;
        private Systems.Controls.lblControl lbtTen_Km;
        private Systems.Controls.lblControl lblMa_Km;
        private Systems.Controls.lblControl lbtTen_Bp;
        private Systems.Controls.lblControl lbMa_Bp;
        private Systems.Controls.txtTextLookup txtTk_Co;
        private Systems.Controls.txtTextLookup txtTk_No;
	}
}