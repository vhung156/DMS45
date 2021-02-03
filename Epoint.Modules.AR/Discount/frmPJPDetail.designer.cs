namespace Epoint.Modules.AR
{
    partial class frmPJPDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhSo_Ct));
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.lbGia = new Epoint.Systems.Controls.lblControl();
            this.dteNgay_Kt = new Epoint.Systems.Controls.dteDateTime();
            this.dteNgay_BD = new Epoint.Systems.Controls.dteDateTime();
            this.lbNgay_Ap = new Epoint.Systems.Controls.lblControl();
            this.txtTen_PJP = new Epoint.Systems.Controls.txtTextLookup();
            this.lbMa_Vt = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Cbnv = new Epoint.Systems.Controls.txtTextLookup();
            this.txtMa_PJP = new Epoint.Systems.Controls.txtTextLookup();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.lblMa_PJP = new Epoint.Systems.Controls.lblControl();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(205, 182);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(184, 31);
            this.btgAccept.TabIndex = 5;
            // 
            // lbGia
            // 
            this.lbGia.AutoEllipsis = true;
            this.lbGia.AutoSize = true;
            this.lbGia.BackColor = System.Drawing.Color.Transparent;
            this.lbGia.Location = new System.Drawing.Point(47, 110);
            this.lbGia.Name = "lbGia";
            this.lbGia.Size = new System.Drawing.Size(74, 13);
            this.lbGia.TabIndex = 75;
            this.lbGia.Tag = "Ngay_Kt";
            this.lbGia.Text = "Ngày kết thúc";
            this.lbGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Kt
            // 
            this.dteNgay_Kt.bAllowEmpty = true;
            this.dteNgay_Kt.bRequire = false;
            this.dteNgay_Kt.bSelectOnFocus = false;
            this.dteNgay_Kt.Culture = new System.Globalization.CultureInfo("en-US");
            this.dteNgay_Kt.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Kt.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Kt.Location = new System.Drawing.Point(152, 107);
            this.dteNgay_Kt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Kt.Mask = "00/00/0000";
            this.dteNgay_Kt.Name = "dteNgay_Kt";
            this.dteNgay_Kt.SelectedText = "";
            this.dteNgay_Kt.Size = new System.Drawing.Size(115, 23);
            this.dteNgay_Kt.TabIndex = 73;
            // 
            // dteNgay_BD
            // 
            this.dteNgay_BD.bAllowEmpty = true;
            this.dteNgay_BD.bRequire = false;
            this.dteNgay_BD.bSelectOnFocus = false;
            this.dteNgay_BD.Culture = new System.Globalization.CultureInfo("en-US");
            this.dteNgay_BD.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_BD.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_BD.Location = new System.Drawing.Point(152, 83);
            this.dteNgay_BD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_BD.Mask = "00/00/0000";
            this.dteNgay_BD.Name = "dteNgay_BD";
            this.dteNgay_BD.SelectedText = "";
            this.dteNgay_BD.Size = new System.Drawing.Size(121, 22);
            this.dteNgay_BD.TabIndex = 72;
            // 
            // lbNgay_Ap
            // 
            this.lbNgay_Ap.AutoEllipsis = true;
            this.lbNgay_Ap.AutoSize = true;
            this.lbNgay_Ap.BackColor = System.Drawing.Color.Transparent;
            this.lbNgay_Ap.Location = new System.Drawing.Point(47, 84);
            this.lbNgay_Ap.Name = "lbNgay_Ap";
            this.lbNgay_Ap.Size = new System.Drawing.Size(72, 13);
            this.lbNgay_Ap.TabIndex = 74;
            this.lbNgay_Ap.Tag = "Ngay_BD";
            this.lbNgay_Ap.Text = "Ngày bắt đầu";
            this.lbNgay_Ap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_PJP
            // 
            this.txtTen_PJP.bEnabled = true;
            this.txtTen_PJP.bIsLookup = false;
            this.txtTen_PJP.bReadOnly = false;
            this.txtTen_PJP.bRequire = false;
            this.txtTen_PJP.ColumnsView = null;
            this.txtTen_PJP.CtrlDepend = null;
            this.txtTen_PJP.Enabled = false;
            this.txtTen_PJP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen_PJP.KeyFilter = "";
            this.txtTen_PJP.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtTen_PJP.ListFilter = new string[0];
            this.txtTen_PJP.Location = new System.Drawing.Point(152, 32);
            this.txtTen_PJP.LookupKeyFilter = "";
            this.txtTen_PJP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_PJP.Name = "txtTen_PJP";
            this.txtTen_PJP.Size = new System.Drawing.Size(238, 20);
            this.txtTen_PJP.TabIndex = 146;
            this.txtTen_PJP.UseAutoFilter = false;
            // 
            // lbMa_Vt
            // 
            this.lbMa_Vt.AutoEllipsis = true;
            this.lbMa_Vt.AutoSize = true;
            this.lbMa_Vt.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_Vt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMa_Vt.Location = new System.Drawing.Point(47, 12);
            this.lbMa_Vt.Name = "lbMa_Vt";
            this.lbMa_Vt.Size = new System.Drawing.Size(44, 13);
            this.lbMa_Vt.TabIndex = 148;
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
            this.txtMa_Cbnv.Enabled = false;
            this.txtMa_Cbnv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_Cbnv.KeyFilter = "";
            this.txtMa_Cbnv.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtMa_Cbnv.ListFilter = new string[0];
            this.txtMa_Cbnv.Location = new System.Drawing.Point(152, 56);
            this.txtMa_Cbnv.LookupKeyFilter = "";
            this.txtMa_Cbnv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Cbnv.Name = "txtMa_Cbnv";
            this.txtMa_Cbnv.Size = new System.Drawing.Size(159, 20);
            this.txtMa_Cbnv.TabIndex = 147;
            this.txtMa_Cbnv.UseAutoFilter = false;
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
            this.txtMa_PJP.Enabled = false;
            this.txtMa_PJP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_PJP.KeyFilter = "";
            this.txtMa_PJP.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtMa_PJP.ListFilter = new string[0];
            this.txtMa_PJP.Location = new System.Drawing.Point(152, 9);
            this.txtMa_PJP.LookupKeyFilter = "";
            this.txtMa_PJP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_PJP.Name = "txtMa_PJP";
            this.txtMa_PJP.Size = new System.Drawing.Size(159, 20);
            this.txtMa_PJP.TabIndex = 145;
            this.txtMa_PJP.UseAutoFilter = false;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl1.Location = new System.Drawing.Point(47, 59);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(72, 13);
            this.lblControl1.TabIndex = 149;
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
            this.lblMa_PJP.Location = new System.Drawing.Point(46, 35);
            this.lblMa_PJP.Name = "lblMa_PJP";
            this.lblMa_PJP.Size = new System.Drawing.Size(48, 13);
            this.lblMa_PJP.TabIndex = 150;
            this.lblMa_PJP.Tag = "TEN_PJP";
            this.lblMa_PJP.Text = "Diễn giải";
            this.lblMa_PJP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDanhSo_Ct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 225);
            this.Controls.Add(this.txtTen_PJP);
            this.Controls.Add(this.lbMa_Vt);
            this.Controls.Add(this.txtMa_Cbnv);
            this.Controls.Add(this.txtMa_PJP);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.lblMa_PJP);
            this.Controls.Add(this.lbGia);
            this.Controls.Add(this.dteNgay_Kt);
            this.Controls.Add(this.dteNgay_BD);
            this.Controls.Add(this.lbNgay_Ap);
            this.Controls.Add(this.btgAccept);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDanhSo_Ct";
            this.Text = "frmPJPDetail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Epoint.Systems.Customizes.btgAccept btgAccept;
        private Systems.Controls.lblControl lbGia;
        private Systems.Controls.dteDateTime dteNgay_Kt;
        private Systems.Controls.dteDateTime dteNgay_BD;
        private Systems.Controls.lblControl lbNgay_Ap;
        private Systems.Controls.txtTextLookup txtTen_PJP;
        private Systems.Controls.lblControl lbMa_Vt;
        private Systems.Controls.txtTextLookup txtMa_Cbnv;
        private Systems.Controls.txtTextLookup txtMa_PJP;
        private Systems.Controls.lblControl lblControl1;
        private Systems.Controls.lblControl lblMa_PJP;
    }
}