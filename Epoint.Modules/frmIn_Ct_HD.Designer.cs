namespace Epoint.Modules
{
	partial class frmIn_Ct_HD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIn_Ct_HD));
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbTien_Nt = new Epoint.Systems.Controls.rdbControl();
            this.rdbTien_VND = new Epoint.Systems.Controls.rdbControl();
            this.txtTk_Nh_B = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl5 = new Epoint.Systems.Controls.lblControl();
            this.txtTen_DtGtGt = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.txtDia_Chi = new Epoint.Systems.Controls.txtTextBox();
            this.lblDia_Chi = new Epoint.Systems.Controls.lblControl();
            this.txtOng_Ba = new Epoint.Systems.Controls.txtTextBox();
            this.lblOng_Ba = new Epoint.Systems.Controls.lblControl();
            this.txtMa_So_Thue = new Epoint.Systems.Controls.txtTextBox();
            this.lblMa_So_Thue = new Epoint.Systems.Controls.lblControl();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.txtTen_NH_B = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl3 = new Epoint.Systems.Controls.lblControl();
            this.txtPt_Tt = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl4 = new Epoint.Systems.Controls.lblControl();
            this.txtDia_Chi_Gh = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl6 = new Epoint.Systems.Controls.lblControl();
            this.txtDia_Chi_Nh = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl7 = new Epoint.Systems.Controls.lblControl();
            this.txtSo_Van_Don = new Epoint.Systems.Controls.txtTextBox();
            this.txtSo_Container = new Epoint.Systems.Controls.txtTextBox();
            this.txtTen_Dv_Vc = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl8 = new Epoint.Systems.Controls.lblControl();
            this.lblControl9 = new Epoint.Systems.Controls.lblControl();
            this.chkInVisibleNextPrint = new System.Windows.Forms.CheckBox();
            this.cboMau_In = new System.Windows.Forms.ComboBox();
            this.lblMau_In = new Epoint.Systems.Controls.lblControl();
            this.gbThong_Tin = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.gbThong_Tin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(313, 463);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 29);
            this.btgAccept.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.rdbTien_Nt);
            this.groupBox2.Controls.Add(this.rdbTien_VND);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(21, 339);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 43);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "In_Tien";
            this.groupBox2.Text = "Chọn loại tiền in";
            // 
            // rdbTien_Nt
            // 
            this.rdbTien_Nt.AutoSize = true;
            this.rdbTien_Nt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTien_Nt.Location = new System.Drawing.Point(151, 20);
            this.rdbTien_Nt.Name = "rdbTien_Nt";
            this.rdbTien_Nt.Size = new System.Drawing.Size(87, 17);
            this.rdbTien_Nt.TabIndex = 1;
            this.rdbTien_Nt.Tag = "Tien_USD";
            this.rdbTien_Nt.Text = "Tiền ngoại tệ";
            this.rdbTien_Nt.UnChecked = true;
            this.rdbTien_Nt.UseVisualStyleBackColor = true;
            // 
            // rdbTien_VND
            // 
            this.rdbTien_VND.AutoSize = true;
            this.rdbTien_VND.Checked = true;
            this.rdbTien_VND.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTien_VND.Location = new System.Drawing.Point(22, 20);
            this.rdbTien_VND.Name = "rdbTien_VND";
            this.rdbTien_VND.Size = new System.Drawing.Size(96, 17);
            this.rdbTien_VND.TabIndex = 0;
            this.rdbTien_VND.TabStop = true;
            this.rdbTien_VND.Tag = "Tien_VND";
            this.rdbTien_VND.Text = "Tiền nguyên tệ";
            this.rdbTien_VND.UnChecked = false;
            this.rdbTien_VND.UseVisualStyleBackColor = true;
            // 
            // txtTk_Nh_B
            // 
            this.txtTk_Nh_B.bEnabled = true;
            this.txtTk_Nh_B.bIsLookup = false;
            this.txtTk_Nh_B.bReadOnly = false;
            this.txtTk_Nh_B.bRequire = false;
            this.txtTk_Nh_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTk_Nh_B.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTk_Nh_B.KeyFilter = "";
            this.txtTk_Nh_B.Location = new System.Drawing.Point(125, 116);
            this.txtTk_Nh_B.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTk_Nh_B.Name = "txtTk_Nh_B";
            this.txtTk_Nh_B.Size = new System.Drawing.Size(196, 20);
            this.txtTk_Nh_B.TabIndex = 4;
            this.txtTk_Nh_B.UseAutoFilter = false;
            // 
            // lblControl5
            // 
            this.lblControl5.AutoEllipsis = true;
            this.lblControl5.AutoSize = true;
            this.lblControl5.BackColor = System.Drawing.Color.Transparent;
            this.lblControl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblControl5.Location = new System.Drawing.Point(19, 119);
            this.lblControl5.Name = "lblControl5";
            this.lblControl5.Size = new System.Drawing.Size(67, 13);
            this.lblControl5.TabIndex = 17;
            this.lblControl5.Tag = "";
            this.lblControl5.Text = "Số tài khoản";
            this.lblControl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_DtGtGt
            // 
            this.txtTen_DtGtGt.bEnabled = true;
            this.txtTen_DtGtGt.bIsLookup = false;
            this.txtTen_DtGtGt.bReadOnly = false;
            this.txtTen_DtGtGt.bRequire = false;
            this.txtTen_DtGtGt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen_DtGtGt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTen_DtGtGt.KeyFilter = "";
            this.txtTen_DtGtGt.Location = new System.Drawing.Point(125, 47);
            this.txtTen_DtGtGt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_DtGtGt.Name = "txtTen_DtGtGt";
            this.txtTen_DtGtGt.ReadOnly = true;
            this.txtTen_DtGtGt.Size = new System.Drawing.Size(283, 20);
            this.txtTen_DtGtGt.TabIndex = 1;
            this.txtTen_DtGtGt.TabStop = false;
            this.txtTen_DtGtGt.UseAutoFilter = false;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblControl1.Location = new System.Drawing.Point(19, 50);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(59, 13);
            this.lblControl1.TabIndex = 19;
            this.lblControl1.Tag = "";
            this.lblControl1.Text = "Tên đơn vị";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDia_Chi
            // 
            this.txtDia_Chi.bEnabled = true;
            this.txtDia_Chi.bIsLookup = false;
            this.txtDia_Chi.bReadOnly = false;
            this.txtDia_Chi.bRequire = false;
            this.txtDia_Chi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDia_Chi.KeyFilter = "";
            this.txtDia_Chi.Location = new System.Drawing.Point(125, 70);
            this.txtDia_Chi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDia_Chi.MaxLength = 200;
            this.txtDia_Chi.Name = "txtDia_Chi";
            this.txtDia_Chi.ReadOnly = true;
            this.txtDia_Chi.Size = new System.Drawing.Size(283, 20);
            this.txtDia_Chi.TabIndex = 2;
            this.txtDia_Chi.TabStop = false;
            this.txtDia_Chi.UseAutoFilter = false;
            // 
            // lblDia_Chi
            // 
            this.lblDia_Chi.AutoEllipsis = true;
            this.lblDia_Chi.AutoSize = true;
            this.lblDia_Chi.BackColor = System.Drawing.Color.Transparent;
            this.lblDia_Chi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDia_Chi.Location = new System.Drawing.Point(19, 73);
            this.lblDia_Chi.Name = "lblDia_Chi";
            this.lblDia_Chi.Size = new System.Drawing.Size(40, 13);
            this.lblDia_Chi.TabIndex = 66;
            this.lblDia_Chi.Tag = "Dia_Chi";
            this.lblDia_Chi.Text = "Địa chỉ";
            this.lblDia_Chi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOng_Ba
            // 
            this.txtOng_Ba.bEnabled = true;
            this.txtOng_Ba.bIsLookup = false;
            this.txtOng_Ba.bReadOnly = false;
            this.txtOng_Ba.bRequire = false;
            this.txtOng_Ba.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOng_Ba.KeyFilter = "";
            this.txtOng_Ba.Location = new System.Drawing.Point(125, 24);
            this.txtOng_Ba.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtOng_Ba.MaxLength = 100;
            this.txtOng_Ba.Name = "txtOng_Ba";
            this.txtOng_Ba.ReadOnly = true;
            this.txtOng_Ba.Size = new System.Drawing.Size(283, 20);
            this.txtOng_Ba.TabIndex = 0;
            this.txtOng_Ba.TabStop = false;
            this.txtOng_Ba.UseAutoFilter = false;
            // 
            // lblOng_Ba
            // 
            this.lblOng_Ba.AutoEllipsis = true;
            this.lblOng_Ba.AutoSize = true;
            this.lblOng_Ba.BackColor = System.Drawing.Color.Transparent;
            this.lblOng_Ba.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOng_Ba.Location = new System.Drawing.Point(19, 27);
            this.lblOng_Ba.Name = "lblOng_Ba";
            this.lblOng_Ba.Size = new System.Drawing.Size(42, 13);
            this.lblOng_Ba.TabIndex = 65;
            this.lblOng_Ba.Tag = "Ong_Ba";
            this.lblOng_Ba.Text = "Ông bà";
            this.lblOng_Ba.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_So_Thue
            // 
            this.txtMa_So_Thue.bEnabled = true;
            this.txtMa_So_Thue.bIsLookup = false;
            this.txtMa_So_Thue.bReadOnly = false;
            this.txtMa_So_Thue.bRequire = false;
            this.txtMa_So_Thue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_So_Thue.KeyFilter = "";
            this.txtMa_So_Thue.Location = new System.Drawing.Point(125, 93);
            this.txtMa_So_Thue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_So_Thue.MaxLength = 20;
            this.txtMa_So_Thue.Name = "txtMa_So_Thue";
            this.txtMa_So_Thue.ReadOnly = true;
            this.txtMa_So_Thue.Size = new System.Drawing.Size(196, 20);
            this.txtMa_So_Thue.TabIndex = 3;
            this.txtMa_So_Thue.TabStop = false;
            this.txtMa_So_Thue.UseAutoFilter = false;
            // 
            // lblMa_So_Thue
            // 
            this.lblMa_So_Thue.AutoEllipsis = true;
            this.lblMa_So_Thue.AutoSize = true;
            this.lblMa_So_Thue.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_So_Thue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMa_So_Thue.Location = new System.Drawing.Point(19, 96);
            this.lblMa_So_Thue.Name = "lblMa_So_Thue";
            this.lblMa_So_Thue.Size = new System.Drawing.Size(60, 13);
            this.lblMa_So_Thue.TabIndex = 128;
            this.lblMa_So_Thue.Tag = "Ma_So_Thue";
            this.lblMa_So_Thue.Text = "Mã số thuế";
            this.lblMa_So_Thue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblControl2.Location = new System.Drawing.Point(19, 142);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(60, 13);
            this.lblControl2.TabIndex = 17;
            this.lblControl2.Tag = "";
            this.lblControl2.Text = "Ngân hàng";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_NH_B
            // 
            this.txtTen_NH_B.bEnabled = true;
            this.txtTen_NH_B.bIsLookup = false;
            this.txtTen_NH_B.bReadOnly = false;
            this.txtTen_NH_B.bRequire = false;
            this.txtTen_NH_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen_NH_B.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTen_NH_B.KeyFilter = "";
            this.txtTen_NH_B.Location = new System.Drawing.Point(125, 139);
            this.txtTen_NH_B.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_NH_B.Name = "txtTen_NH_B";
            this.txtTen_NH_B.Size = new System.Drawing.Size(325, 20);
            this.txtTen_NH_B.TabIndex = 5;
            this.txtTen_NH_B.UseAutoFilter = false;
            // 
            // lblControl3
            // 
            this.lblControl3.AutoEllipsis = true;
            this.lblControl3.AutoSize = true;
            this.lblControl3.BackColor = System.Drawing.Color.Transparent;
            this.lblControl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblControl3.Location = new System.Drawing.Point(19, 165);
            this.lblControl3.Name = "lblControl3";
            this.lblControl3.Size = new System.Drawing.Size(80, 13);
            this.lblControl3.TabIndex = 17;
            this.lblControl3.Tag = "";
            this.lblControl3.Text = "Hình thức ttoán";
            this.lblControl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPt_Tt
            // 
            this.txtPt_Tt.bEnabled = true;
            this.txtPt_Tt.bIsLookup = false;
            this.txtPt_Tt.bReadOnly = false;
            this.txtPt_Tt.bRequire = false;
            this.txtPt_Tt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPt_Tt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPt_Tt.KeyFilter = "";
            this.txtPt_Tt.Location = new System.Drawing.Point(125, 162);
            this.txtPt_Tt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPt_Tt.Name = "txtPt_Tt";
            this.txtPt_Tt.Size = new System.Drawing.Size(196, 20);
            this.txtPt_Tt.TabIndex = 6;
            this.txtPt_Tt.UseAutoFilter = false;
            // 
            // lblControl4
            // 
            this.lblControl4.AutoEllipsis = true;
            this.lblControl4.AutoSize = true;
            this.lblControl4.BackColor = System.Drawing.Color.Transparent;
            this.lblControl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblControl4.Location = new System.Drawing.Point(19, 188);
            this.lblControl4.Name = "lblControl4";
            this.lblControl4.Size = new System.Drawing.Size(99, 13);
            this.lblControl4.TabIndex = 17;
            this.lblControl4.Tag = "";
            this.lblControl4.Text = "Địa điểm giao hàng";
            this.lblControl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDia_Chi_Gh
            // 
            this.txtDia_Chi_Gh.bEnabled = true;
            this.txtDia_Chi_Gh.bIsLookup = false;
            this.txtDia_Chi_Gh.bReadOnly = false;
            this.txtDia_Chi_Gh.bRequire = false;
            this.txtDia_Chi_Gh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDia_Chi_Gh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDia_Chi_Gh.KeyFilter = "";
            this.txtDia_Chi_Gh.Location = new System.Drawing.Point(125, 185);
            this.txtDia_Chi_Gh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDia_Chi_Gh.Name = "txtDia_Chi_Gh";
            this.txtDia_Chi_Gh.Size = new System.Drawing.Size(325, 20);
            this.txtDia_Chi_Gh.TabIndex = 7;
            this.txtDia_Chi_Gh.UseAutoFilter = false;
            // 
            // lblControl6
            // 
            this.lblControl6.AutoEllipsis = true;
            this.lblControl6.AutoSize = true;
            this.lblControl6.BackColor = System.Drawing.Color.Transparent;
            this.lblControl6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblControl6.Location = new System.Drawing.Point(20, 211);
            this.lblControl6.Name = "lblControl6";
            this.lblControl6.Size = new System.Drawing.Size(103, 13);
            this.lblControl6.TabIndex = 17;
            this.lblControl6.Tag = "";
            this.lblControl6.Text = "Địa điểm nhận hàng";
            this.lblControl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDia_Chi_Nh
            // 
            this.txtDia_Chi_Nh.bEnabled = true;
            this.txtDia_Chi_Nh.bIsLookup = false;
            this.txtDia_Chi_Nh.bReadOnly = false;
            this.txtDia_Chi_Nh.bRequire = false;
            this.txtDia_Chi_Nh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDia_Chi_Nh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDia_Chi_Nh.KeyFilter = "";
            this.txtDia_Chi_Nh.Location = new System.Drawing.Point(126, 208);
            this.txtDia_Chi_Nh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDia_Chi_Nh.Name = "txtDia_Chi_Nh";
            this.txtDia_Chi_Nh.Size = new System.Drawing.Size(324, 20);
            this.txtDia_Chi_Nh.TabIndex = 8;
            this.txtDia_Chi_Nh.UseAutoFilter = false;
            // 
            // lblControl7
            // 
            this.lblControl7.AutoEllipsis = true;
            this.lblControl7.AutoSize = true;
            this.lblControl7.BackColor = System.Drawing.Color.Transparent;
            this.lblControl7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblControl7.Location = new System.Drawing.Point(20, 234);
            this.lblControl7.Name = "lblControl7";
            this.lblControl7.Size = new System.Drawing.Size(63, 13);
            this.lblControl7.TabIndex = 17;
            this.lblControl7.Tag = "";
            this.lblControl7.Text = "Số vận đơn";
            this.lblControl7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSo_Van_Don
            // 
            this.txtSo_Van_Don.bEnabled = true;
            this.txtSo_Van_Don.bIsLookup = false;
            this.txtSo_Van_Don.bReadOnly = false;
            this.txtSo_Van_Don.bRequire = false;
            this.txtSo_Van_Don.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSo_Van_Don.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtSo_Van_Don.KeyFilter = "";
            this.txtSo_Van_Don.Location = new System.Drawing.Point(126, 231);
            this.txtSo_Van_Don.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Van_Don.Name = "txtSo_Van_Don";
            this.txtSo_Van_Don.Size = new System.Drawing.Size(196, 20);
            this.txtSo_Van_Don.TabIndex = 9;
            this.txtSo_Van_Don.UseAutoFilter = false;
            // 
            // txtSo_Container
            // 
            this.txtSo_Container.bEnabled = true;
            this.txtSo_Container.bIsLookup = false;
            this.txtSo_Container.bReadOnly = false;
            this.txtSo_Container.bRequire = false;
            this.txtSo_Container.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSo_Container.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtSo_Container.KeyFilter = "";
            this.txtSo_Container.Location = new System.Drawing.Point(125, 254);
            this.txtSo_Container.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Container.Name = "txtSo_Container";
            this.txtSo_Container.Size = new System.Drawing.Size(196, 20);
            this.txtSo_Container.TabIndex = 10;
            this.txtSo_Container.UseAutoFilter = false;
            // 
            // txtTen_Dv_Vc
            // 
            this.txtTen_Dv_Vc.bEnabled = true;
            this.txtTen_Dv_Vc.bIsLookup = false;
            this.txtTen_Dv_Vc.bReadOnly = false;
            this.txtTen_Dv_Vc.bRequire = false;
            this.txtTen_Dv_Vc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen_Dv_Vc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTen_Dv_Vc.KeyFilter = "";
            this.txtTen_Dv_Vc.Location = new System.Drawing.Point(126, 277);
            this.txtTen_Dv_Vc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Dv_Vc.Name = "txtTen_Dv_Vc";
            this.txtTen_Dv_Vc.Size = new System.Drawing.Size(324, 20);
            this.txtTen_Dv_Vc.TabIndex = 11;
            this.txtTen_Dv_Vc.UseAutoFilter = false;
            // 
            // lblControl8
            // 
            this.lblControl8.AutoEllipsis = true;
            this.lblControl8.AutoSize = true;
            this.lblControl8.BackColor = System.Drawing.Color.Transparent;
            this.lblControl8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblControl8.Location = new System.Drawing.Point(22, 257);
            this.lblControl8.Name = "lblControl8";
            this.lblControl8.Size = new System.Drawing.Size(67, 13);
            this.lblControl8.TabIndex = 17;
            this.lblControl8.Tag = "";
            this.lblControl8.Text = "Số container";
            this.lblControl8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl9
            // 
            this.lblControl9.AutoEllipsis = true;
            this.lblControl9.AutoSize = true;
            this.lblControl9.BackColor = System.Drawing.Color.Transparent;
            this.lblControl9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblControl9.Location = new System.Drawing.Point(21, 280);
            this.lblControl9.Name = "lblControl9";
            this.lblControl9.Size = new System.Drawing.Size(102, 13);
            this.lblControl9.TabIndex = 17;
            this.lblControl9.Tag = "";
            this.lblControl9.Text = "Tên Dv vận chuyển";
            this.lblControl9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkInVisibleNextPrint
            // 
            this.chkInVisibleNextPrint.AutoSize = true;
            this.chkInVisibleNextPrint.ForeColor = System.Drawing.Color.Blue;
            this.chkInVisibleNextPrint.Location = new System.Drawing.Point(248, 418);
            this.chkInVisibleNextPrint.Name = "chkInVisibleNextPrint";
            this.chkInVisibleNextPrint.Size = new System.Drawing.Size(168, 17);
            this.chkInVisibleNextPrint.TabIndex = 129;
            this.chkInVisibleNextPrint.Tag = "InVisibleNextPrint";
            this.chkInVisibleNextPrint.Text = "Không xuất hiện khi in lần sau";
            this.chkInVisibleNextPrint.UseVisualStyleBackColor = true;
            // 
            // cboMau_In
            // 
            this.cboMau_In.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboMau_In.FormattingEnabled = true;
            this.cboMau_In.Location = new System.Drawing.Point(28, 415);
            this.cboMau_In.Name = "cboMau_In";
            this.cboMau_In.Size = new System.Drawing.Size(191, 21);
            this.cboMau_In.TabIndex = 130;
            this.cboMau_In.Text = "Hóa đơn bán hàng";
            // 
            // lblMau_In
            // 
            this.lblMau_In.AutoEllipsis = true;
            this.lblMau_In.AutoSize = true;
            this.lblMau_In.BackColor = System.Drawing.Color.Transparent;
            this.lblMau_In.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMau_In.ForeColor = System.Drawing.Color.Blue;
            this.lblMau_In.Location = new System.Drawing.Point(26, 394);
            this.lblMau_In.Name = "lblMau_In";
            this.lblMau_In.Size = new System.Drawing.Size(77, 13);
            this.lblMau_In.TabIndex = 131;
            this.lblMau_In.Tag = "CHON_MAU_IN";
            this.lblMau_In.Text = "Chọn mẫu in";
            this.lblMau_In.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbThong_Tin
            // 
            this.gbThong_Tin.Controls.Add(this.txtTen_Dv_Vc);
            this.gbThong_Tin.Controls.Add(this.lblControl5);
            this.gbThong_Tin.Controls.Add(this.txtTk_Nh_B);
            this.gbThong_Tin.Controls.Add(this.lblControl2);
            this.gbThong_Tin.Controls.Add(this.txtMa_So_Thue);
            this.gbThong_Tin.Controls.Add(this.txtTen_NH_B);
            this.gbThong_Tin.Controls.Add(this.lblMa_So_Thue);
            this.gbThong_Tin.Controls.Add(this.lblControl3);
            this.gbThong_Tin.Controls.Add(this.txtDia_Chi);
            this.gbThong_Tin.Controls.Add(this.lblControl7);
            this.gbThong_Tin.Controls.Add(this.lblDia_Chi);
            this.gbThong_Tin.Controls.Add(this.lblControl8);
            this.gbThong_Tin.Controls.Add(this.txtOng_Ba);
            this.gbThong_Tin.Controls.Add(this.lblControl9);
            this.gbThong_Tin.Controls.Add(this.lblOng_Ba);
            this.gbThong_Tin.Controls.Add(this.lblControl4);
            this.gbThong_Tin.Controls.Add(this.txtTen_DtGtGt);
            this.gbThong_Tin.Controls.Add(this.lblControl6);
            this.gbThong_Tin.Controls.Add(this.lblControl1);
            this.gbThong_Tin.Controls.Add(this.txtPt_Tt);
            this.gbThong_Tin.Controls.Add(this.txtDia_Chi_Nh);
            this.gbThong_Tin.Controls.Add(this.txtSo_Van_Don);
            this.gbThong_Tin.Controls.Add(this.txtDia_Chi_Gh);
            this.gbThong_Tin.Controls.Add(this.txtSo_Container);
            this.gbThong_Tin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbThong_Tin.Location = new System.Drawing.Point(21, 15);
            this.gbThong_Tin.Name = "gbThong_Tin";
            this.gbThong_Tin.Size = new System.Drawing.Size(467, 312);
            this.gbThong_Tin.TabIndex = 132;
            this.gbThong_Tin.TabStop = false;
            this.gbThong_Tin.Tag = "THONG_TIN";
            this.gbThong_Tin.Text = "Thông tin";
            // 
            // frmIn_Ct_HD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 507);
            this.Controls.Add(this.gbThong_Tin);
            this.Controls.Add(this.lblMau_In);
            this.Controls.Add(this.cboMau_In);
            this.Controls.Add(this.chkInVisibleNextPrint);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btgAccept);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIn_Ct_HD";
            this.Tag = "";
            this.Text = "frmIn_Ct_HD";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbThong_Tin.ResumeLayout(false);
            this.gbThong_Tin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Epoint.Systems.Customizes.btgAccept btgAccept;
        public System.Windows.Forms.GroupBox groupBox2;
        public Epoint.Systems.Controls.rdbControl rdbTien_Nt;
        public Epoint.Systems.Controls.rdbControl rdbTien_VND;
		private Epoint.Systems.Controls.txtTextBox txtTk_Nh_B;
		private Epoint.Systems.Controls.lblControl lblControl5;
		private Epoint.Systems.Controls.txtTextBox txtTen_DtGtGt;
		private Epoint.Systems.Controls.lblControl lblControl1;
		private Epoint.Systems.Controls.txtTextBox txtDia_Chi;
		private Epoint.Systems.Controls.lblControl lblDia_Chi;
		private Epoint.Systems.Controls.txtTextBox txtOng_Ba;
		private Epoint.Systems.Controls.lblControl lblOng_Ba;
		private Epoint.Systems.Controls.txtTextBox txtMa_So_Thue;
		private Epoint.Systems.Controls.lblControl lblMa_So_Thue;
		private Epoint.Systems.Controls.lblControl lblControl2;
		private Epoint.Systems.Controls.txtTextBox txtTen_NH_B;
		private Epoint.Systems.Controls.lblControl lblControl3;
        private Epoint.Systems.Controls.txtTextBox txtPt_Tt;
		private Epoint.Systems.Controls.lblControl lblControl4;
		private Epoint.Systems.Controls.txtTextBox txtDia_Chi_Gh;
		private Epoint.Systems.Controls.lblControl lblControl6;
		private Epoint.Systems.Controls.txtTextBox txtDia_Chi_Nh;
		private Epoint.Systems.Controls.lblControl lblControl7;
		private Epoint.Systems.Controls.txtTextBox txtSo_Van_Don;
		private Epoint.Systems.Controls.txtTextBox txtSo_Container;
		private Epoint.Systems.Controls.txtTextBox txtTen_Dv_Vc;
		private Epoint.Systems.Controls.lblControl lblControl8;
		private Epoint.Systems.Controls.lblControl lblControl9;
        public System.Windows.Forms.CheckBox chkInVisibleNextPrint;
        public System.Windows.Forms.ComboBox cboMau_In;
        private Systems.Controls.lblControl lblMau_In;
        private System.Windows.Forms.GroupBox gbThong_Tin;
	}
}