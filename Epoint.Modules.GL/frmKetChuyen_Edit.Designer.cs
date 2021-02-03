namespace Epoint.Modules.GL
{
    partial class frmKetChuyen_Edit
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
            this.numStt = new Epoint.Systems.Controls.numControl();
            this.txtDien_Giai = new Epoint.Systems.Controls.txtTextBox();
            this.lbMa_Hd = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Tk = new Epoint.Systems.Controls.lblControl();
            this.lblTk = new Epoint.Systems.Controls.lblControl();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Tk_Du_Den = new Epoint.Systems.Controls.lblControl();
            this.lbtLoai_Ct = new Epoint.Systems.Controls.lblControl();
            this.txtNo_Co_Auto = new Epoint.Systems.Controls.txtEnum();
            this.txtPs_Du = new Epoint.Systems.Controls.txtEnum();
            this.lblControl3 = new Epoint.Systems.Controls.lblControl();
            this.lblControl4 = new Epoint.Systems.Controls.lblControl();
            this.lblControl5 = new Epoint.Systems.Controls.lblControl();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.lblControl6 = new Epoint.Systems.Controls.lblControl();
            this.txtTk = new Epoint.Systems.Controls.txtTextLookup();
            this.txtTk_Du_Den = new Epoint.Systems.Controls.txtTextLookup();
            this.SuspendLayout();
            // 
            // numStt
            // 
            this.numStt.bEnabled = true;
            this.numStt.bFormat = true;
            this.numStt.bIsLookup = false;
            this.numStt.bReadOnly = false;
            this.numStt.bRequire = false;
            this.numStt.KeyFilter = "";
            this.numStt.Location = new System.Drawing.Point(150, 27);
            this.numStt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numStt.Name = "numStt";
            this.numStt.Scale = 0;
            this.numStt.Size = new System.Drawing.Size(39, 20);
            this.numStt.TabIndex = 0;
            this.numStt.Text = "0";
            this.numStt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numStt.UseAutoFilter = false;
            this.numStt.Value = 0D;
            // 
            // txtDien_Giai
            // 
            this.txtDien_Giai.bEnabled = true;
            this.txtDien_Giai.bIsLookup = false;
            this.txtDien_Giai.bReadOnly = false;
            this.txtDien_Giai.bRequire = false;
            this.txtDien_Giai.KeyFilter = "";
            this.txtDien_Giai.Location = new System.Drawing.Point(150, 51);
            this.txtDien_Giai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDien_Giai.MaxLength = 200;
            this.txtDien_Giai.Name = "txtDien_Giai";
            this.txtDien_Giai.Size = new System.Drawing.Size(361, 20);
            this.txtDien_Giai.TabIndex = 1;
            this.txtDien_Giai.UseAutoFilter = false;
            // 
            // lbMa_Hd
            // 
            this.lbMa_Hd.AutoEllipsis = true;
            this.lbMa_Hd.AutoSize = true;
            this.lbMa_Hd.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_Hd.Location = new System.Drawing.Point(33, 53);
            this.lbMa_Hd.Name = "lbMa_Hd";
            this.lbMa_Hd.Size = new System.Drawing.Size(48, 13);
            this.lbMa_Hd.TabIndex = 34;
            this.lbMa_Hd.Tag = "Dien_Giai";
            this.lbMa_Hd.Text = "Diễn giải";
            this.lbMa_Hd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Tk
            // 
            this.lbtTen_Tk.AutoEllipsis = true;
            this.lbtTen_Tk.AutoSize = true;
            this.lbtTen_Tk.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Tk.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Tk.Location = new System.Drawing.Point(209, 78);
            this.lbtTen_Tk.Name = "lbtTen_Tk";
            this.lbtTen_Tk.Size = new System.Drawing.Size(73, 13);
            this.lbtTen_Tk.TabIndex = 142;
            this.lbtTen_Tk.Text = "Tên tài khoản";
            this.lbtTen_Tk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTk
            // 
            this.lblTk.AutoEllipsis = true;
            this.lblTk.AutoSize = true;
            this.lblTk.BackColor = System.Drawing.Color.Transparent;
            this.lblTk.Location = new System.Drawing.Point(33, 77);
            this.lblTk.Name = "lblTk";
            this.lblTk.Size = new System.Drawing.Size(67, 13);
            this.lblTk.TabIndex = 141;
            this.lblTk.Tag = "Tk_Di";
            this.lblTk.Text = "Tài khoản đi";
            this.lblTk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(33, 102);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(77, 13);
            this.lblControl1.TabIndex = 141;
            this.lblControl1.Tag = "Tk_Den";
            this.lblControl1.Text = "Tài khoản đến";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Tk_Du_Den
            // 
            this.lbtTen_Tk_Du_Den.AutoEllipsis = true;
            this.lbtTen_Tk_Du_Den.AutoSize = true;
            this.lbtTen_Tk_Du_Den.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Tk_Du_Den.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Tk_Du_Den.Location = new System.Drawing.Point(209, 102);
            this.lbtTen_Tk_Du_Den.Name = "lbtTen_Tk_Du_Den";
            this.lbtTen_Tk_Du_Den.Size = new System.Drawing.Size(95, 13);
            this.lbtTen_Tk_Du_Den.TabIndex = 142;
            this.lbtTen_Tk_Du_Den.Text = "Tên tài khoản đến";
            this.lbtTen_Tk_Du_Den.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtLoai_Ct
            // 
            this.lbtLoai_Ct.AutoEllipsis = true;
            this.lbtLoai_Ct.AutoSize = true;
            this.lbtLoai_Ct.BackColor = System.Drawing.Color.Transparent;
            this.lbtLoai_Ct.ForeColor = System.Drawing.Color.Blue;
            this.lbtLoai_Ct.Location = new System.Drawing.Point(176, 152);
            this.lbtLoai_Ct.Name = "lbtLoai_Ct";
            this.lbtLoai_Ct.Size = new System.Drawing.Size(384, 13);
            this.lbtLoai_Ct.TabIndex = 144;
            this.lbtLoai_Ct.Tag = "No_Co_Auto";
            this.lbtLoai_Ct.Text = "1 - Nợ, 2 - Có, 3 - Tự động xác định, 4 - Kết chuyển căn cứ vào tk có giá trị nhỏ" +
    "";
            this.lbtLoai_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNo_Co_Auto
            // 
            this.txtNo_Co_Auto.bEnabled = true;
            this.txtNo_Co_Auto.bIsLookup = false;
            this.txtNo_Co_Auto.bReadOnly = false;
            this.txtNo_Co_Auto.bRequire = false;
            this.txtNo_Co_Auto.InputMask = "1,2,3,4";
            this.txtNo_Co_Auto.KeyFilter = "";
            this.txtNo_Co_Auto.Location = new System.Drawing.Point(150, 147);
            this.txtNo_Co_Auto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNo_Co_Auto.Name = "txtNo_Co_Auto";
            this.txtNo_Co_Auto.Size = new System.Drawing.Size(21, 20);
            this.txtNo_Co_Auto.TabIndex = 5;
            this.txtNo_Co_Auto.Text = "1";
            this.txtNo_Co_Auto.UseAutoFilter = false;
            // 
            // txtPs_Du
            // 
            this.txtPs_Du.bEnabled = true;
            this.txtPs_Du.bIsLookup = false;
            this.txtPs_Du.bReadOnly = false;
            this.txtPs_Du.bRequire = false;
            this.txtPs_Du.InputMask = "1,2";
            this.txtPs_Du.KeyFilter = "";
            this.txtPs_Du.Location = new System.Drawing.Point(150, 123);
            this.txtPs_Du.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPs_Du.Name = "txtPs_Du";
            this.txtPs_Du.Size = new System.Drawing.Size(21, 20);
            this.txtPs_Du.TabIndex = 4;
            this.txtPs_Du.Text = "1";
            this.txtPs_Du.UseAutoFilter = false;
            // 
            // lblControl3
            // 
            this.lblControl3.AutoEllipsis = true;
            this.lblControl3.AutoSize = true;
            this.lblControl3.BackColor = System.Drawing.Color.Transparent;
            this.lblControl3.ForeColor = System.Drawing.Color.Blue;
            this.lblControl3.Location = new System.Drawing.Point(176, 128);
            this.lblControl3.Name = "lblControl3";
            this.lblControl3.Size = new System.Drawing.Size(130, 13);
            this.lblControl3.TabIndex = 144;
            this.lblControl3.Tag = "PS_DU";
            this.lblControl3.Text = "1 - Số phát sinh, 2 - Số dư";
            this.lblControl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl4
            // 
            this.lblControl4.AutoEllipsis = true;
            this.lblControl4.BackColor = System.Drawing.Color.Transparent;
            this.lblControl4.Location = new System.Drawing.Point(33, 148);
            this.lblControl4.Name = "lblControl4";
            this.lblControl4.Size = new System.Drawing.Size(108, 30);
            this.lblControl4.TabIndex = 141;
            this.lblControl4.Tag = "";
            this.lblControl4.Text = "Kết chuyển sang bên của Tk đi";
            this.lblControl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl5
            // 
            this.lblControl5.AutoEllipsis = true;
            this.lblControl5.AutoSize = true;
            this.lblControl5.BackColor = System.Drawing.Color.Transparent;
            this.lblControl5.Location = new System.Drawing.Point(33, 127);
            this.lblControl5.Name = "lblControl5";
            this.lblControl5.Size = new System.Drawing.Size(61, 13);
            this.lblControl5.TabIndex = 141;
            this.lblControl5.Tag = "";
            this.lblControl5.Text = "Kết chuyển";
            this.lblControl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(402, 206);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(186, 30);
            this.btgAccept.TabIndex = 7;
            // 
            // lblControl6
            // 
            this.lblControl6.AutoEllipsis = true;
            this.lblControl6.AutoSize = true;
            this.lblControl6.BackColor = System.Drawing.Color.Transparent;
            this.lblControl6.Location = new System.Drawing.Point(33, 29);
            this.lblControl6.Name = "lblControl6";
            this.lblControl6.Size = new System.Drawing.Size(50, 13);
            this.lblControl6.TabIndex = 34;
            this.lblControl6.Tag = "Stt";
            this.lblControl6.Text = "Số thứ tự";
            this.lblControl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTk
            // 
            this.txtTk.bEnabled = true;
            this.txtTk.bIsLookup = false;
            this.txtTk.bReadOnly = false;
            this.txtTk.bRequire = false;
            this.txtTk.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTk.ColumnsView = null;
            this.txtTk.KeyFilter = "Tk";
            this.txtTk.Location = new System.Drawing.Point(150, 75);
            this.txtTk.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTk.Name = "txtTk";
            this.txtTk.Size = new System.Drawing.Size(54, 20);
            this.txtTk.TabIndex = 2;
            this.txtTk.UseAutoFilter = true;
            // 
            // txtTk_Du_Den
            // 
            this.txtTk_Du_Den.bEnabled = true;
            this.txtTk_Du_Den.bIsLookup = false;
            this.txtTk_Du_Den.bReadOnly = false;
            this.txtTk_Du_Den.bRequire = false;
            this.txtTk_Du_Den.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTk_Du_Den.ColumnsView = null;
            this.txtTk_Du_Den.KeyFilter = "Tk";
            this.txtTk_Du_Den.Location = new System.Drawing.Point(150, 99);
            this.txtTk_Du_Den.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTk_Du_Den.Name = "txtTk_Du_Den";
            this.txtTk_Du_Den.Size = new System.Drawing.Size(54, 20);
            this.txtTk_Du_Den.TabIndex = 3;
            this.txtTk_Du_Den.UseAutoFilter = true;
            // 
            // frmKetChuyen_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 248);
            this.Controls.Add(this.txtTk_Du_Den);
            this.Controls.Add(this.txtTk);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.lblControl3);
            this.Controls.Add(this.txtPs_Du);
            this.Controls.Add(this.lbtLoai_Ct);
            this.Controls.Add(this.txtNo_Co_Auto);
            this.Controls.Add(this.lbtTen_Tk_Du_Den);
            this.Controls.Add(this.lbtTen_Tk);
            this.Controls.Add(this.lblControl5);
            this.Controls.Add(this.lblControl4);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.lblTk);
            this.Controls.Add(this.txtDien_Giai);
            this.Controls.Add(this.lblControl6);
            this.Controls.Add(this.lbMa_Hd);
            this.Controls.Add(this.numStt);
            this.Name = "frmKetChuyen_Edit";
            this.Object_ID = "KETCHUYEN";
            this.Tag = "frmKetChuyen, ESC";
            this.Text = "frmKetChuyen_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.numControl numStt;
        private Epoint.Systems.Controls.txtTextBox txtDien_Giai;
        private Epoint.Systems.Controls.lblControl lbMa_Hd;
        private Epoint.Systems.Controls.lblControl lbtTen_Tk;
        private Epoint.Systems.Controls.lblControl lblTk;
        private Epoint.Systems.Controls.lblControl lblControl1;
        private Epoint.Systems.Controls.lblControl lbtTen_Tk_Du_Den;
        private Epoint.Systems.Controls.lblControl lbtLoai_Ct;
        private Epoint.Systems.Controls.txtEnum txtNo_Co_Auto;
        private Epoint.Systems.Controls.txtEnum txtPs_Du;
        private Epoint.Systems.Controls.lblControl lblControl3;
        private Epoint.Systems.Controls.lblControl lblControl4;
        private Epoint.Systems.Controls.lblControl lblControl5;
        public Epoint.Systems.Customizes.btgAccept btgAccept;
		private Epoint.Systems.Controls.lblControl lblControl6;
        private Systems.Controls.txtTextLookup txtTk;
        private Systems.Controls.txtTextLookup txtTk_Du_Den;

	}
}