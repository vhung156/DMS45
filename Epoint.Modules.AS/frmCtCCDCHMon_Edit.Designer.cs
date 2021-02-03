namespace Epoint.Modules.AS
{
	partial class frmCtCCDCHMon_Edit
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
            this.txtMa_CCDC = new Epoint.Systems.Controls.txtTextBox();
            this.lbMa_CCDC = new Epoint.Systems.Controls.lblControl();
            this.lblNgay_Ps = new Epoint.Systems.Controls.lblControl();
            this.dteNgay_Ps = new Epoint.Systems.Controls.txtDateTime();
            this.numTien_HM_Nt = new Epoint.Systems.Controls.numControl();
            this.lblTien_HM = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_CCDC = new Epoint.Systems.Controls.lblControl();
            this.numTien_HM = new Epoint.Systems.Controls.numControl();
            this.chkSua_HM = new Epoint.Systems.Controls.chkControl();
            this.lblStt_NGia = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_CCDC_NGia = new Epoint.Systems.Controls.lblControl();
            this.cboStt = new Epoint.Systems.Controls.cboMultiControl();
            this.txtTk_Co = new Epoint.Systems.Controls.txtTextLookup();
            this.txtTk_No = new Epoint.Systems.Controls.txtTextLookup();
            this.txtMa_Sp = new Epoint.Systems.Controls.txtTextLookup();
            this.txtMa_Km = new Epoint.Systems.Controls.txtTextLookup();
            this.txtMa_Bp = new Epoint.Systems.Controls.txtTextLookup();
            this.lbtTen_Tk_Co = new Epoint.Systems.Controls.lblControl();
            this.lblTk_Co = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Sp = new Epoint.Systems.Controls.lblControl();
            this.lblMa_Sp = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Km = new Epoint.Systems.Controls.lblControl();
            this.lblMa_Km = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Tk_No = new Epoint.Systems.Controls.lblControl();
            this.lblTk_No = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Bp = new Epoint.Systems.Controls.lblControl();
            this.lbMa_Bp = new Epoint.Systems.Controls.lblControl();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(304, 292);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 29);
            this.btgAccept.TabIndex = 12;
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
            this.txtMa_CCDC.Location = new System.Drawing.Point(139, 18);
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
            this.lbMa_CCDC.Location = new System.Drawing.Point(28, 20);
            this.lbMa_CCDC.Name = "lbMa_CCDC";
            this.lbMa_CCDC.Size = new System.Drawing.Size(54, 13);
            this.lbMa_CCDC.TabIndex = 45;
            this.lbMa_CCDC.Tag = "Ma_CCDC";
            this.lbMa_CCDC.Text = "Mã CCDC";
            this.lbMa_CCDC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgay_Ps
            // 
            this.lblNgay_Ps.AutoEllipsis = true;
            this.lblNgay_Ps.AutoSize = true;
            this.lblNgay_Ps.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay_Ps.Location = new System.Drawing.Point(28, 66);
            this.lblNgay_Ps.Name = "lblNgay_Ps";
            this.lblNgay_Ps.Size = new System.Drawing.Size(45, 13);
            this.lblNgay_Ps.TabIndex = 46;
            this.lblNgay_Ps.Text = "Ngày Ct";
            this.lblNgay_Ps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ps
            // 
            this.dteNgay_Ps.bAllowEmpty = false;
            this.dteNgay_Ps.bRequire = false;
            this.dteNgay_Ps.bSelectOnFocus = true;
            this.dteNgay_Ps.bShowDateTimePicker = true;
            this.dteNgay_Ps.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ps.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ps.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ps.Location = new System.Drawing.Point(139, 65);
            this.dteNgay_Ps.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ps.Mask = "00/00/0000";
            this.dteNgay_Ps.Name = "dteNgay_Ps";
            this.dteNgay_Ps.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ps.TabIndex = 2;
            // 
            // numTien_HM_Nt
            // 
            this.numTien_HM_Nt.bEnabled = true;
            this.numTien_HM_Nt.bFormat = true;
            this.numTien_HM_Nt.bIsLookup = false;
            this.numTien_HM_Nt.bReadOnly = false;
            this.numTien_HM_Nt.bRequire = false;
            this.numTien_HM_Nt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTien_HM_Nt.KeyFilter = "";
            this.numTien_HM_Nt.Location = new System.Drawing.Point(139, 102);
            this.numTien_HM_Nt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTien_HM_Nt.Name = "numTien_HM_Nt";
            this.numTien_HM_Nt.Scale = 0;
            this.numTien_HM_Nt.Size = new System.Drawing.Size(120, 20);
            this.numTien_HM_Nt.TabIndex = 4;
            this.numTien_HM_Nt.Text = "0";
            this.numTien_HM_Nt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTien_HM_Nt.UseAutoFilter = false;
            this.numTien_HM_Nt.Value = 0D;
            // 
            // lblTien_HM
            // 
            this.lblTien_HM.AutoEllipsis = true;
            this.lblTien_HM.AutoSize = true;
            this.lblTien_HM.BackColor = System.Drawing.Color.Transparent;
            this.lblTien_HM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTien_HM.Location = new System.Drawing.Point(28, 104);
            this.lblTien_HM.Name = "lblTien_HM";
            this.lblTien_HM.Size = new System.Drawing.Size(57, 13);
            this.lblTien_HM.TabIndex = 52;
            this.lblTien_HM.Tag = "Tien_HM";
            this.lblTien_HM.Text = "Hao mòn";
            this.lblTien_HM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_CCDC
            // 
            this.lbtTen_CCDC.AutoEllipsis = true;
            this.lbtTen_CCDC.AutoSize = true;
            this.lbtTen_CCDC.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_CCDC.Enabled = false;
            this.lbtTen_CCDC.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_CCDC.Location = new System.Drawing.Point(265, 20);
            this.lbtTen_CCDC.Name = "lbtTen_CCDC";
            this.lbtTen_CCDC.Size = new System.Drawing.Size(58, 13);
            this.lbtTen_CCDC.TabIndex = 65;
            this.lbtTen_CCDC.Text = "Tên CCDC";
            this.lbtTen_CCDC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTien_HM
            // 
            this.numTien_HM.bEnabled = true;
            this.numTien_HM.bFormat = true;
            this.numTien_HM.bIsLookup = false;
            this.numTien_HM.bReadOnly = false;
            this.numTien_HM.bRequire = false;
            this.numTien_HM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTien_HM.KeyFilter = "";
            this.numTien_HM.Location = new System.Drawing.Point(268, 102);
            this.numTien_HM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTien_HM.Name = "numTien_HM";
            this.numTien_HM.Scale = 0;
            this.numTien_HM.Size = new System.Drawing.Size(120, 20);
            this.numTien_HM.TabIndex = 5;
            this.numTien_HM.Text = "0";
            this.numTien_HM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTien_HM.UseAutoFilter = false;
            this.numTien_HM.Value = 0D;
            // 
            // chkSua_HM
            // 
            this.chkSua_HM.AutoSize = true;
            this.chkSua_HM.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkSua_HM.Location = new System.Drawing.Point(139, 127);
            this.chkSua_HM.Name = "chkSua_HM";
            this.chkSua_HM.Size = new System.Drawing.Size(89, 17);
            this.chkSua_HM.TabIndex = 6;
            this.chkSua_HM.Tag = "";
            this.chkSua_HM.Text = "Sửa hao mòn";
            this.chkSua_HM.UseVisualStyleBackColor = true;
            // 
            // lblStt_NGia
            // 
            this.lblStt_NGia.AutoEllipsis = true;
            this.lblStt_NGia.AutoSize = true;
            this.lblStt_NGia.BackColor = System.Drawing.Color.Transparent;
            this.lblStt_NGia.Location = new System.Drawing.Point(28, 44);
            this.lblStt_NGia.Name = "lblStt_NGia";
            this.lblStt_NGia.Size = new System.Drawing.Size(47, 13);
            this.lblStt_NGia.TabIndex = 88;
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
            this.lbtTen_CCDC_NGia.Location = new System.Drawing.Point(264, 45);
            this.lbtTen_CCDC_NGia.Name = "lbtTen_CCDC_NGia";
            this.lbtTen_CCDC_NGia.Size = new System.Drawing.Size(58, 13);
            this.lbtTen_CCDC_NGia.TabIndex = 87;
            this.lbtTen_CCDC_NGia.Text = "Tên CCDC";
            this.lbtTen_CCDC_NGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboStt
            // 
            this.cboStt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboStt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboStt.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboStt.Location = new System.Drawing.Point(139, 41);
            this.cboStt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboStt.MaxLength = 20;
            this.cboStt.Name = "cboStt";
            this.cboStt.Size = new System.Drawing.Size(120, 21);
            this.cboStt.TabIndex = 1;
            // 
            // txtTk_Co
            // 
            this.txtTk_Co.bEnabled = true;
            this.txtTk_Co.bIsLookup = false;
            this.txtTk_Co.bReadOnly = false;
            this.txtTk_Co.bRequire = false;
            this.txtTk_Co.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTk_Co.ColumnsView = null;
            this.txtTk_Co.KeyFilter = "Tk";
            this.txtTk_Co.Location = new System.Drawing.Point(139, 175);
            this.txtTk_Co.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTk_Co.Name = "txtTk_Co";
            this.txtTk_Co.Size = new System.Drawing.Size(68, 20);
            this.txtTk_Co.TabIndex = 8;
            this.txtTk_Co.UseAutoFilter = true;
            // 
            // txtTk_No
            // 
            this.txtTk_No.bEnabled = true;
            this.txtTk_No.bIsLookup = false;
            this.txtTk_No.bReadOnly = false;
            this.txtTk_No.bRequire = false;
            this.txtTk_No.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTk_No.ColumnsView = null;
            this.txtTk_No.KeyFilter = "Tk";
            this.txtTk_No.Location = new System.Drawing.Point(139, 152);
            this.txtTk_No.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTk_No.Name = "txtTk_No";
            this.txtTk_No.Size = new System.Drawing.Size(68, 20);
            this.txtTk_No.TabIndex = 7;
            this.txtTk_No.UseAutoFilter = true;
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
            this.txtMa_Sp.Location = new System.Drawing.Point(139, 244);
            this.txtMa_Sp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Sp.Name = "txtMa_Sp";
            this.txtMa_Sp.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Sp.TabIndex = 11;
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
            this.txtMa_Km.Location = new System.Drawing.Point(139, 221);
            this.txtMa_Km.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Km.Name = "txtMa_Km";
            this.txtMa_Km.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Km.TabIndex = 10;
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
            this.txtMa_Bp.Location = new System.Drawing.Point(139, 198);
            this.txtMa_Bp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Bp.Name = "txtMa_Bp";
            this.txtMa_Bp.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Bp.TabIndex = 9;
            this.txtMa_Bp.UseAutoFilter = true;
            // 
            // lbtTen_Tk_Co
            // 
            this.lbtTen_Tk_Co.AutoEllipsis = true;
            this.lbtTen_Tk_Co.AutoSize = true;
            this.lbtTen_Tk_Co.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Tk_Co.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Tk_Co.Location = new System.Drawing.Point(211, 179);
            this.lbtTen_Tk_Co.Name = "lbtTen_Tk_Co";
            this.lbtTen_Tk_Co.Size = new System.Drawing.Size(88, 13);
            this.lbtTen_Tk_Co.TabIndex = 217;
            this.lbtTen_Tk_Co.Text = "Tên tài khoản có";
            this.lbtTen_Tk_Co.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTk_Co
            // 
            this.lblTk_Co.AutoEllipsis = true;
            this.lblTk_Co.AutoSize = true;
            this.lblTk_Co.BackColor = System.Drawing.Color.Transparent;
            this.lblTk_Co.Location = new System.Drawing.Point(27, 177);
            this.lblTk_Co.Name = "lblTk_Co";
            this.lblTk_Co.Size = new System.Drawing.Size(70, 13);
            this.lblTk_Co.TabIndex = 216;
            this.lblTk_Co.Tag = "Tk_Co";
            this.lblTk_Co.Text = "Tài khoản có";
            this.lblTk_Co.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Sp
            // 
            this.lbtTen_Sp.AutoEllipsis = true;
            this.lbtTen_Sp.AutoSize = true;
            this.lbtTen_Sp.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Sp.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Sp.Location = new System.Drawing.Point(264, 248);
            this.lbtTen_Sp.Name = "lbtTen_Sp";
            this.lbtTen_Sp.Size = new System.Drawing.Size(75, 13);
            this.lbtTen_Sp.TabIndex = 215;
            this.lbtTen_Sp.Text = "Tên sản phẩm";
            this.lbtTen_Sp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMa_Sp
            // 
            this.lblMa_Sp.AutoEllipsis = true;
            this.lblMa_Sp.AutoSize = true;
            this.lblMa_Sp.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Sp.Location = new System.Drawing.Point(27, 246);
            this.lblMa_Sp.Name = "lblMa_Sp";
            this.lblMa_Sp.Size = new System.Drawing.Size(71, 13);
            this.lblMa_Sp.TabIndex = 214;
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
            this.lbtTen_Km.Location = new System.Drawing.Point(264, 226);
            this.lbtTen_Km.Name = "lbtTen_Km";
            this.lbtTen_Km.Size = new System.Drawing.Size(82, 13);
            this.lbtTen_Km.TabIndex = 213;
            this.lbtTen_Km.Text = "Tên khoản mục";
            this.lbtTen_Km.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMa_Km
            // 
            this.lblMa_Km.AutoEllipsis = true;
            this.lblMa_Km.AutoSize = true;
            this.lblMa_Km.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Km.Location = new System.Drawing.Point(27, 223);
            this.lblMa_Km.Name = "lblMa_Km";
            this.lblMa_Km.Size = new System.Drawing.Size(78, 13);
            this.lblMa_Km.TabIndex = 212;
            this.lblMa_Km.Tag = "Ma_Km";
            this.lblMa_Km.Text = "Mã khoản mục";
            this.lblMa_Km.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Tk_No
            // 
            this.lbtTen_Tk_No.AutoEllipsis = true;
            this.lbtTen_Tk_No.AutoSize = true;
            this.lbtTen_Tk_No.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Tk_No.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Tk_No.Location = new System.Drawing.Point(211, 155);
            this.lbtTen_Tk_No.Name = "lbtTen_Tk_No";
            this.lbtTen_Tk_No.Size = new System.Drawing.Size(88, 13);
            this.lbtTen_Tk_No.TabIndex = 211;
            this.lbtTen_Tk_No.Text = "Tên tài khoản nợ";
            this.lbtTen_Tk_No.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTk_No
            // 
            this.lblTk_No.AutoEllipsis = true;
            this.lblTk_No.AutoSize = true;
            this.lblTk_No.BackColor = System.Drawing.Color.Transparent;
            this.lblTk_No.Location = new System.Drawing.Point(27, 154);
            this.lblTk_No.Name = "lblTk_No";
            this.lblTk_No.Size = new System.Drawing.Size(70, 13);
            this.lblTk_No.TabIndex = 210;
            this.lblTk_No.Tag = "Tk_No";
            this.lblTk_No.Text = "Tài khoản nợ";
            this.lblTk_No.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Bp
            // 
            this.lbtTen_Bp.AutoEllipsis = true;
            this.lbtTen_Bp.AutoSize = true;
            this.lbtTen_Bp.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Bp.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Bp.Location = new System.Drawing.Point(264, 203);
            this.lbtTen_Bp.Name = "lbtTen_Bp";
            this.lbtTen_Bp.Size = new System.Drawing.Size(71, 13);
            this.lbtTen_Bp.TabIndex = 209;
            this.lbtTen_Bp.Text = "Tên bộ phận ";
            this.lbtTen_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Bp
            // 
            this.lbMa_Bp.AutoEllipsis = true;
            this.lbMa_Bp.AutoSize = true;
            this.lbMa_Bp.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_Bp.Location = new System.Drawing.Point(27, 200);
            this.lbMa_Bp.Name = "lbMa_Bp";
            this.lbMa_Bp.Size = new System.Drawing.Size(64, 13);
            this.lbMa_Bp.TabIndex = 208;
            this.lbMa_Bp.Tag = "Ma_Bp";
            this.lbMa_Bp.Text = "Mã bộ phận";
            this.lbMa_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCtCCDCHMon_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 337);
            this.Controls.Add(this.txtTk_Co);
            this.Controls.Add(this.txtTk_No);
            this.Controls.Add(this.txtMa_Sp);
            this.Controls.Add(this.txtMa_Km);
            this.Controls.Add(this.txtMa_Bp);
            this.Controls.Add(this.lbtTen_Tk_Co);
            this.Controls.Add(this.lblTk_Co);
            this.Controls.Add(this.lbtTen_Sp);
            this.Controls.Add(this.lblMa_Sp);
            this.Controls.Add(this.lbtTen_Km);
            this.Controls.Add(this.lblMa_Km);
            this.Controls.Add(this.lbtTen_Tk_No);
            this.Controls.Add(this.lblTk_No);
            this.Controls.Add(this.lbtTen_Bp);
            this.Controls.Add(this.lbMa_Bp);
            this.Controls.Add(this.lblStt_NGia);
            this.Controls.Add(this.lbtTen_CCDC_NGia);
            this.Controls.Add(this.cboStt);
            this.Controls.Add(this.chkSua_HM);
            this.Controls.Add(this.lbtTen_CCDC);
            this.Controls.Add(this.lblTien_HM);
            this.Controls.Add(this.numTien_HM);
            this.Controls.Add(this.numTien_HM_Nt);
            this.Controls.Add(this.lblNgay_Ps);
            this.Controls.Add(this.dteNgay_Ps);
            this.Controls.Add(this.txtMa_CCDC);
            this.Controls.Add(this.lbMa_CCDC);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmCtCCDCHMon_Edit";
            this.Tag = "frmCtCCDCHMon_Edit";
            this.Text = "frmCtCCDCHMon_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Epoint.Systems.Customizes.btgAccept btgAccept;
        private Epoint.Systems.Controls.txtTextBox txtMa_CCDC;
        private Epoint.Systems.Controls.lblControl lbMa_CCDC;
        private Epoint.Systems.Controls.lblControl lblNgay_Ps;
		private Epoint.Systems.Controls.txtDateTime dteNgay_Ps;
        private Epoint.Systems.Controls.numControl numTien_HM_Nt;
        private Epoint.Systems.Controls.lblControl lblTien_HM;
        private Epoint.Systems.Controls.lblControl lbtTen_CCDC;
		private Epoint.Systems.Controls.numControl numTien_HM;
		private Epoint.Systems.Controls.chkControl chkSua_HM;
		private Epoint.Systems.Controls.lblControl lblStt_NGia;
		private Epoint.Systems.Controls.lblControl lbtTen_CCDC_NGia;
		private Epoint.Systems.Controls.cboMultiControl cboStt;
        private Systems.Controls.txtTextLookup txtTk_Co;
        private Systems.Controls.txtTextLookup txtTk_No;
        private Systems.Controls.txtTextLookup txtMa_Sp;
        private Systems.Controls.txtTextLookup txtMa_Km;
        private Systems.Controls.txtTextLookup txtMa_Bp;
        private Systems.Controls.lblControl lbtTen_Tk_Co;
        private Systems.Controls.lblControl lblTk_Co;
        private Systems.Controls.lblControl lbtTen_Sp;
        private Systems.Controls.lblControl lblMa_Sp;
        private Systems.Controls.lblControl lbtTen_Km;
        private Systems.Controls.lblControl lblMa_Km;
        private Systems.Controls.lblControl lbtTen_Tk_No;
        private Systems.Controls.lblControl lblTk_No;
        private Systems.Controls.lblControl lbtTen_Bp;
        private Systems.Controls.lblControl lbMa_Bp;
	}
}