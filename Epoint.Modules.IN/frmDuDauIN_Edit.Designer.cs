namespace Epoint.Modules.IN
{
    partial class frmDuDauIN_Edit
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
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Kho = new Epoint.Systems.Controls.lbtControl();
            this.numTon_Dau = new Epoint.Systems.Controls.numControl();
            this.lblDu_No = new Epoint.Systems.Controls.lblControl();
            this.lblControl3 = new Epoint.Systems.Controls.lblControl();
            this.numGia = new Epoint.Systems.Controls.numControl();
            this.lblControl4 = new Epoint.Systems.Controls.lblControl();
            this.numDu_Dau = new Epoint.Systems.Controls.numControl();
            this.dteNgay_Ct = new Epoint.Systems.Controls.txtDateTime();
            this.lblControl6 = new Epoint.Systems.Controls.lblControl();
            this.lblControl5 = new Epoint.Systems.Controls.lblControl();
            this.lblControl7 = new Epoint.Systems.Controls.lblControl();
            this.numGia_Nt = new Epoint.Systems.Controls.numControl();
            this.numDu_Dau_Nt = new Epoint.Systems.Controls.numControl();
            this.lbtTen_Vt = new Epoint.Systems.Controls.lbtControl();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.lbtDvt = new Epoint.Systems.Controls.lbtControl();
            this.txtMa_Vt = new Epoint.Systems.Controls.txtTextLookup();
            this.txtMa_Kho = new Epoint.Systems.Controls.txtTextLookup();
            this.lblMa_Lo = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Lo = new Epoint.Systems.Controls.txtTextLookup();
            this.dteHan_Sd = new Epoint.Systems.Controls.txtDateTime();
            this.lblHan_Sd = new Epoint.Systems.Controls.lblControl();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(370, 299);
            this.btgAccept.Size = new System.Drawing.Size(181, 29);
            this.btgAccept.TabIndex = 10;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(36, 49);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(43, 13);
            this.lblControl1.TabIndex = 2;
            this.lblControl1.Tag = "Ma_Kho";
            this.lblControl1.Text = "Mã kho";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Kho
            // 
            this.lbtTen_Kho.AutoSize = true;
            this.lbtTen_Kho.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Kho.Location = new System.Drawing.Point(245, 50);
            this.lbtTen_Kho.Name = "lbtTen_Kho";
            this.lbtTen_Kho.Size = new System.Drawing.Size(51, 13);
            this.lbtTen_Kho.TabIndex = 3;
            this.lbtTen_Kho.Tag = "Ten_Kho";
            this.lbtTen_Kho.Text = "Ten_Kho";
            this.lbtTen_Kho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTon_Dau
            // 
            this.numTon_Dau.bEnabled = true;
            this.numTon_Dau.bFormat = true;
            this.numTon_Dau.bIsLookup = false;
            this.numTon_Dau.bReadOnly = false;
            this.numTon_Dau.bRequire = false;
            this.numTon_Dau.KeyFilter = "";
            this.numTon_Dau.Location = new System.Drawing.Point(120, 155);
            this.numTon_Dau.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numTon_Dau.Name = "numTon_Dau";
            this.numTon_Dau.Scale = 2;
            this.numTon_Dau.Size = new System.Drawing.Size(127, 20);
            this.numTon_Dau.TabIndex = 5;
            this.numTon_Dau.Tag = "So_Luong";
            this.numTon_Dau.Text = "0.00";
            this.numTon_Dau.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTon_Dau.UseAutoFilter = false;
            this.numTon_Dau.Value = 0D;
            // 
            // lblDu_No
            // 
            this.lblDu_No.AutoEllipsis = true;
            this.lblDu_No.AutoSize = true;
            this.lblDu_No.BackColor = System.Drawing.Color.Transparent;
            this.lblDu_No.Location = new System.Drawing.Point(36, 159);
            this.lblDu_No.Name = "lblDu_No";
            this.lblDu_No.Size = new System.Drawing.Size(49, 13);
            this.lblDu_No.TabIndex = 2;
            this.lblDu_No.Tag = "So_Luong";
            this.lblDu_No.Text = "Số lượng";
            this.lblDu_No.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl3
            // 
            this.lblControl3.AutoEllipsis = true;
            this.lblControl3.AutoSize = true;
            this.lblControl3.BackColor = System.Drawing.Color.Transparent;
            this.lblControl3.Location = new System.Drawing.Point(36, 182);
            this.lblControl3.Name = "lblControl3";
            this.lblControl3.Size = new System.Drawing.Size(44, 13);
            this.lblControl3.TabIndex = 2;
            this.lblControl3.Tag = "Gia";
            this.lblControl3.Text = "Đơn giá";
            this.lblControl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numGia
            // 
            this.numGia.bEnabled = true;
            this.numGia.bFormat = true;
            this.numGia.bIsLookup = false;
            this.numGia.bReadOnly = false;
            this.numGia.bRequire = false;
            this.numGia.KeyFilter = "";
            this.numGia.Location = new System.Drawing.Point(120, 178);
            this.numGia.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numGia.Name = "numGia";
            this.numGia.Scale = 2;
            this.numGia.Size = new System.Drawing.Size(127, 20);
            this.numGia.TabIndex = 6;
            this.numGia.Tag = "Gia";
            this.numGia.Text = "0.00";
            this.numGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numGia.UseAutoFilter = false;
            this.numGia.Value = 0D;
            // 
            // lblControl4
            // 
            this.lblControl4.AutoEllipsis = true;
            this.lblControl4.AutoSize = true;
            this.lblControl4.BackColor = System.Drawing.Color.Transparent;
            this.lblControl4.Location = new System.Drawing.Point(36, 205);
            this.lblControl4.Name = "lblControl4";
            this.lblControl4.Size = new System.Drawing.Size(58, 13);
            this.lblControl4.TabIndex = 2;
            this.lblControl4.Tag = "Tien";
            this.lblControl4.Text = "Thành tiền";
            this.lblControl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numDu_Dau
            // 
            this.numDu_Dau.bEnabled = true;
            this.numDu_Dau.bFormat = true;
            this.numDu_Dau.bIsLookup = false;
            this.numDu_Dau.bReadOnly = false;
            this.numDu_Dau.bRequire = false;
            this.numDu_Dau.KeyFilter = "";
            this.numDu_Dau.Location = new System.Drawing.Point(120, 201);
            this.numDu_Dau.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numDu_Dau.Name = "numDu_Dau";
            this.numDu_Dau.Scale = 0;
            this.numDu_Dau.Size = new System.Drawing.Size(127, 20);
            this.numDu_Dau.TabIndex = 8;
            this.numDu_Dau.Tag = "Tien";
            this.numDu_Dau.Text = "0";
            this.numDu_Dau.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDu_Dau.UseAutoFilter = false;
            this.numDu_Dau.Value = 0D;
            // 
            // dteNgay_Ct
            // 
            this.dteNgay_Ct.bAllowEmpty = true;
            this.dteNgay_Ct.bRequire = false;
            this.dteNgay_Ct.bSelectOnFocus = false;
            this.dteNgay_Ct.bShowDateTimePicker = true;
            this.dteNgay_Ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct.Location = new System.Drawing.Point(121, 22);
            this.dteNgay_Ct.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Ct.Mask = "00/00/0000";
            this.dteNgay_Ct.Name = "dteNgay_Ct";
            this.dteNgay_Ct.Size = new System.Drawing.Size(120, 20);
            this.dteNgay_Ct.TabIndex = 0;
            this.dteNgay_Ct.Tag = "Ngay_Ct";
            // 
            // lblControl6
            // 
            this.lblControl6.AutoEllipsis = true;
            this.lblControl6.AutoSize = true;
            this.lblControl6.BackColor = System.Drawing.Color.Transparent;
            this.lblControl6.Location = new System.Drawing.Point(36, 26);
            this.lblControl6.Name = "lblControl6";
            this.lblControl6.Size = new System.Drawing.Size(32, 13);
            this.lblControl6.TabIndex = 2;
            this.lblControl6.Tag = "Date";
            this.lblControl6.Text = "Ngày";
            this.lblControl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl5
            // 
            this.lblControl5.AutoEllipsis = true;
            this.lblControl5.AutoSize = true;
            this.lblControl5.BackColor = System.Drawing.Color.Transparent;
            this.lblControl5.Location = new System.Drawing.Point(271, 205);
            this.lblControl5.Name = "lblControl5";
            this.lblControl5.Size = new System.Drawing.Size(42, 13);
            this.lblControl5.TabIndex = 2;
            this.lblControl5.Tag = "Tien_Nt";
            this.lblControl5.Text = "Tiền Nt";
            this.lblControl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl7
            // 
            this.lblControl7.AutoEllipsis = true;
            this.lblControl7.AutoSize = true;
            this.lblControl7.BackColor = System.Drawing.Color.Transparent;
            this.lblControl7.Location = new System.Drawing.Point(271, 182);
            this.lblControl7.Name = "lblControl7";
            this.lblControl7.Size = new System.Drawing.Size(37, 13);
            this.lblControl7.TabIndex = 2;
            this.lblControl7.Tag = "Gia_Nt";
            this.lblControl7.Text = "Giá Nt";
            this.lblControl7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numGia_Nt
            // 
            this.numGia_Nt.bEnabled = true;
            this.numGia_Nt.bFormat = true;
            this.numGia_Nt.bIsLookup = false;
            this.numGia_Nt.bReadOnly = false;
            this.numGia_Nt.bRequire = false;
            this.numGia_Nt.KeyFilter = "";
            this.numGia_Nt.Location = new System.Drawing.Point(334, 178);
            this.numGia_Nt.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numGia_Nt.Name = "numGia_Nt";
            this.numGia_Nt.Scale = 2;
            this.numGia_Nt.Size = new System.Drawing.Size(127, 20);
            this.numGia_Nt.TabIndex = 7;
            this.numGia_Nt.Tag = "Gia_Nt";
            this.numGia_Nt.Text = "0.00";
            this.numGia_Nt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numGia_Nt.UseAutoFilter = false;
            this.numGia_Nt.Value = 0D;
            // 
            // numDu_Dau_Nt
            // 
            this.numDu_Dau_Nt.bEnabled = true;
            this.numDu_Dau_Nt.bFormat = true;
            this.numDu_Dau_Nt.bIsLookup = false;
            this.numDu_Dau_Nt.bReadOnly = false;
            this.numDu_Dau_Nt.bRequire = false;
            this.numDu_Dau_Nt.KeyFilter = "";
            this.numDu_Dau_Nt.Location = new System.Drawing.Point(334, 201);
            this.numDu_Dau_Nt.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numDu_Dau_Nt.Name = "numDu_Dau_Nt";
            this.numDu_Dau_Nt.Scale = 2;
            this.numDu_Dau_Nt.Size = new System.Drawing.Size(127, 20);
            this.numDu_Dau_Nt.TabIndex = 9;
            this.numDu_Dau_Nt.Tag = "Tien_Nt";
            this.numDu_Dau_Nt.Text = "0.00";
            this.numDu_Dau_Nt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDu_Dau_Nt.UseAutoFilter = false;
            this.numDu_Dau_Nt.Value = 0D;
            // 
            // lbtTen_Vt
            // 
            this.lbtTen_Vt.AutoSize = true;
            this.lbtTen_Vt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt.Location = new System.Drawing.Point(245, 72);
            this.lbtTen_Vt.Name = "lbtTen_Vt";
            this.lbtTen_Vt.Size = new System.Drawing.Size(42, 13);
            this.lbtTen_Vt.TabIndex = 3;
            this.lbtTen_Vt.Tag = "Ten_Vt";
            this.lbtTen_Vt.Text = "Ten_Vt";
            this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(36, 72);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(52, 13);
            this.lblControl2.TabIndex = 2;
            this.lblControl2.Tag = "Ma_Vt";
            this.lblControl2.Text = "Mã vật tư";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtDvt
            // 
            this.lbtDvt.AutoSize = true;
            this.lbtDvt.ForeColor = System.Drawing.Color.Blue;
            this.lbtDvt.Location = new System.Drawing.Point(253, 159);
            this.lbtDvt.Name = "lbtDvt";
            this.lbtDvt.Size = new System.Drawing.Size(35, 13);
            this.lbtDvt.TabIndex = 3;
            this.lbtDvt.Tag = "";
            this.lbtDvt.Text = "lbtDvt";
            this.lbtDvt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Vt
            // 
            this.txtMa_Vt.bEnabled = true;
            this.txtMa_Vt.bIsLookup = false;
            this.txtMa_Vt.bReadOnly = false;
            this.txtMa_Vt.bRequire = false;
            this.txtMa_Vt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Vt.ColumnsView = null;
            this.txtMa_Vt.CtrlDepend = null;
            this.txtMa_Vt.KeyFilter = "Ma_Vt";
            this.txtMa_Vt.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtMa_Vt.ListFilter = new string[0];
            this.txtMa_Vt.Location = new System.Drawing.Point(121, 68);
            this.txtMa_Vt.LookupKeyFilter = "";
            this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt.Name = "txtMa_Vt";
            this.txtMa_Vt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Vt.TabIndex = 2;
            this.txtMa_Vt.UseAutoFilter = true;
            // 
            // txtMa_Kho
            // 
            this.txtMa_Kho.bEnabled = true;
            this.txtMa_Kho.bIsLookup = false;
            this.txtMa_Kho.bReadOnly = false;
            this.txtMa_Kho.bRequire = false;
            this.txtMa_Kho.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Kho.ColumnsView = null;
            this.txtMa_Kho.CtrlDepend = null;
            this.txtMa_Kho.KeyFilter = "Ma_Kho";
            this.txtMa_Kho.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtMa_Kho.ListFilter = new string[0];
            this.txtMa_Kho.Location = new System.Drawing.Point(121, 45);
            this.txtMa_Kho.LookupKeyFilter = "";
            this.txtMa_Kho.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Kho.Name = "txtMa_Kho";
            this.txtMa_Kho.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Kho.TabIndex = 1;
            this.txtMa_Kho.UseAutoFilter = true;
            // 
            // lblMa_Lo
            // 
            this.lblMa_Lo.AutoEllipsis = true;
            this.lblMa_Lo.AutoSize = true;
            this.lblMa_Lo.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Lo.Location = new System.Drawing.Point(36, 98);
            this.lblMa_Lo.Name = "lblMa_Lo";
            this.lblMa_Lo.Size = new System.Drawing.Size(37, 13);
            this.lblMa_Lo.TabIndex = 2;
            this.lblMa_Lo.Tag = "Ma_Lo";
            this.lblMa_Lo.Text = "Mã Lô";
            this.lblMa_Lo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMa_Lo.Visible = false;
            // 
            // txtMa_Lo
            // 
            this.txtMa_Lo.bEnabled = true;
            this.txtMa_Lo.bIsLookup = false;
            this.txtMa_Lo.bReadOnly = false;
            this.txtMa_Lo.bRequire = false;
            this.txtMa_Lo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Lo.ColumnsView = null;
            this.txtMa_Lo.CtrlDepend = null;
            this.txtMa_Lo.KeyFilter = "";
            this.txtMa_Lo.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtMa_Lo.ListFilter = new string[0];
            this.txtMa_Lo.Location = new System.Drawing.Point(121, 94);
            this.txtMa_Lo.LookupKeyFilter = "";
            this.txtMa_Lo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Lo.Name = "txtMa_Lo";
            this.txtMa_Lo.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Lo.TabIndex = 3;
            this.txtMa_Lo.UseAutoFilter = false;
            this.txtMa_Lo.Visible = false;
            // 
            // dteHan_Sd
            // 
            this.dteHan_Sd.bAllowEmpty = true;
            this.dteHan_Sd.bRequire = false;
            this.dteHan_Sd.bSelectOnFocus = false;
            this.dteHan_Sd.bShowDateTimePicker = true;
            this.dteHan_Sd.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteHan_Sd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteHan_Sd.Location = new System.Drawing.Point(121, 116);
            this.dteHan_Sd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteHan_Sd.Mask = "00/00/0000";
            this.dteHan_Sd.Name = "dteHan_Sd";
            this.dteHan_Sd.Size = new System.Drawing.Size(120, 20);
            this.dteHan_Sd.TabIndex = 4;
            this.dteHan_Sd.Tag = "Ngay_Ct";
            this.dteHan_Sd.Visible = false;
            // 
            // lblHan_Sd
            // 
            this.lblHan_Sd.AutoEllipsis = true;
            this.lblHan_Sd.AutoSize = true;
            this.lblHan_Sd.BackColor = System.Drawing.Color.Transparent;
            this.lblHan_Sd.Location = new System.Drawing.Point(36, 119);
            this.lblHan_Sd.Name = "lblHan_Sd";
            this.lblHan_Sd.Size = new System.Drawing.Size(43, 13);
            this.lblHan_Sd.TabIndex = 2;
            this.lblHan_Sd.Tag = "";
            this.lblHan_Sd.Text = "Hạn Sd";
            this.lblHan_Sd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHan_Sd.Visible = false;
            // 
            // frmDuDauIN_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 333);
            this.Controls.Add(this.txtMa_Lo);
            this.Controls.Add(this.txtMa_Vt);
            this.Controls.Add(this.txtMa_Kho);
            this.Controls.Add(this.dteHan_Sd);
            this.Controls.Add(this.dteNgay_Ct);
            this.Controls.Add(this.numTon_Dau);
            this.Controls.Add(this.numDu_Dau_Nt);
            this.Controls.Add(this.numDu_Dau);
            this.Controls.Add(this.numGia_Nt);
            this.Controls.Add(this.numGia);
            this.Controls.Add(this.lblHan_Sd);
            this.Controls.Add(this.lblMa_Lo);
            this.Controls.Add(this.lblControl2);
            this.Controls.Add(this.lblControl6);
            this.Controls.Add(this.lblControl7);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.lblControl5);
            this.Controls.Add(this.lblControl3);
            this.Controls.Add(this.lblControl4);
            this.Controls.Add(this.lblDu_No);
            this.Controls.Add(this.lbtDvt);
            this.Controls.Add(this.lbtTen_Vt);
            this.Controls.Add(this.lbtTen_Kho);
            this.Name = "frmDuDauIN_Edit";
            this.Tag = "frmDuDauIN";
            this.Text = "frmDuDauIN_Edit";
            this.Controls.SetChildIndex(this.lbtTen_Kho, 0);
            this.Controls.SetChildIndex(this.lbtTen_Vt, 0);
            this.Controls.SetChildIndex(this.lbtDvt, 0);
            this.Controls.SetChildIndex(this.lblDu_No, 0);
            this.Controls.SetChildIndex(this.lblControl4, 0);
            this.Controls.SetChildIndex(this.lblControl3, 0);
            this.Controls.SetChildIndex(this.lblControl5, 0);
            this.Controls.SetChildIndex(this.lblControl1, 0);
            this.Controls.SetChildIndex(this.lblControl7, 0);
            this.Controls.SetChildIndex(this.lblControl6, 0);
            this.Controls.SetChildIndex(this.lblControl2, 0);
            this.Controls.SetChildIndex(this.lblMa_Lo, 0);
            this.Controls.SetChildIndex(this.lblHan_Sd, 0);
            this.Controls.SetChildIndex(this.numGia, 0);
            this.Controls.SetChildIndex(this.numGia_Nt, 0);
            this.Controls.SetChildIndex(this.numDu_Dau, 0);
            this.Controls.SetChildIndex(this.numDu_Dau_Nt, 0);
            this.Controls.SetChildIndex(this.numTon_Dau, 0);
            this.Controls.SetChildIndex(this.btgAccept, 0);
            this.Controls.SetChildIndex(this.dteNgay_Ct, 0);
            this.Controls.SetChildIndex(this.dteHan_Sd, 0);
            this.Controls.SetChildIndex(this.txtMa_Kho, 0);
            this.Controls.SetChildIndex(this.txtMa_Vt, 0);
            this.Controls.SetChildIndex(this.txtMa_Lo, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Epoint.Systems.Controls.lblControl lblControl1;
		private Epoint.Systems.Controls.lbtControl lbtTen_Kho;
		private Epoint.Systems.Controls.numControl numTon_Dau;
		private Epoint.Systems.Controls.lblControl lblDu_No;
		private Epoint.Systems.Controls.lblControl lblControl3;
		private Epoint.Systems.Controls.numControl numGia;
		private Epoint.Systems.Controls.lblControl lblControl4;
		private Epoint.Systems.Controls.numControl numDu_Dau;
		private Epoint.Systems.Controls.txtDateTime dteNgay_Ct;
		private Epoint.Systems.Controls.lblControl lblControl6;
		private Epoint.Systems.Controls.lblControl lblControl5;
		private Epoint.Systems.Controls.lblControl lblControl7;
		private Epoint.Systems.Controls.numControl numGia_Nt;
		private Epoint.Systems.Controls.numControl numDu_Dau_Nt;
		private Epoint.Systems.Controls.lbtControl lbtTen_Vt;
        private Epoint.Systems.Controls.lblControl lblControl2;
		private Epoint.Systems.Controls.lbtControl lbtDvt;
        private Systems.Controls.txtTextLookup txtMa_Vt;
        private Systems.Controls.txtTextLookup txtMa_Kho;
        private Systems.Controls.lblControl lblMa_Lo;
        private Systems.Controls.txtTextLookup txtMa_Lo;
        private Systems.Controls.txtDateTime dteHan_Sd;
        private Systems.Controls.lblControl lblHan_Sd;
	}
}