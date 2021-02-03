namespace Epoint.Modules.AR
{
    partial class frmDiscountManual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiscountManual));
            this.btFillterData = new Epoint.Systems.Customizes.btPreview();
            this.lbGia = new Epoint.Systems.Controls.lblControl();
            this.dteNgay_Kt = new Epoint.Systems.Controls.dteDateTime();
            this.dteNgay_BD = new Epoint.Systems.Controls.dteDateTime();
            this.lbNgay_Ap = new Epoint.Systems.Controls.lblControl();
            this.splitConFull = new System.Windows.Forms.SplitContainer();
            this.pnPXK = new System.Windows.Forms.Panel();
            this.dgvDiscountProg = new Epoint.Systems.Controls.dgvGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitConFull)).BeginInit();
            this.splitConFull.Panel1.SuspendLayout();
            this.splitConFull.SuspendLayout();
            this.pnPXK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscountProg)).BeginInit();
            this.SuspendLayout();
            // 
            // btFillterData
            // 
            this.btFillterData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFillterData.Image = ((System.Drawing.Image)(resources.GetObject("btFillterData.Image")));
            this.btFillterData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFillterData.Location = new System.Drawing.Point(452, 3);
            this.btFillterData.Name = "btFillterData";
            this.btFillterData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btFillterData.Size = new System.Drawing.Size(121, 27);
            this.btFillterData.TabIndex = 72;
            this.btFillterData.Tag = "Preview";
            this.btFillterData.Text = "Lọc dữ liệu";
            this.btFillterData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFillterData.UseVisualStyleBackColor = true;
            // 
            // lbGia
            // 
            this.lbGia.AutoEllipsis = true;
            this.lbGia.AutoSize = true;
            this.lbGia.BackColor = System.Drawing.Color.Transparent;
            this.lbGia.Location = new System.Drawing.Point(220, 12);
            this.lbGia.Name = "lbGia";
            this.lbGia.Size = new System.Drawing.Size(74, 13);
            this.lbGia.TabIndex = 71;
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
            this.dteNgay_Kt.Location = new System.Drawing.Point(325, 10);
            this.dteNgay_Kt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Kt.Mask = "00/00/0000";
            this.dteNgay_Kt.Name = "dteNgay_Kt";
            this.dteNgay_Kt.SelectedText = "";
            this.dteNgay_Kt.Size = new System.Drawing.Size(115, 20);
            this.dteNgay_Kt.TabIndex = 69;
            // 
            // dteNgay_BD
            // 
            this.dteNgay_BD.bAllowEmpty = true;
            this.dteNgay_BD.bRequire = false;
            this.dteNgay_BD.bSelectOnFocus = false;
            this.dteNgay_BD.Culture = new System.Globalization.CultureInfo("en-US");
            this.dteNgay_BD.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_BD.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_BD.Location = new System.Drawing.Point(100, 10);
            this.dteNgay_BD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_BD.Mask = "00/00/0000";
            this.dteNgay_BD.Name = "dteNgay_BD";
            this.dteNgay_BD.SelectedText = "";
            this.dteNgay_BD.Size = new System.Drawing.Size(121, 20);
            this.dteNgay_BD.TabIndex = 68;
            // 
            // lbNgay_Ap
            // 
            this.lbNgay_Ap.AutoEllipsis = true;
            this.lbNgay_Ap.AutoSize = true;
            this.lbNgay_Ap.BackColor = System.Drawing.Color.Transparent;
            this.lbNgay_Ap.Location = new System.Drawing.Point(12, 13);
            this.lbNgay_Ap.Name = "lbNgay_Ap";
            this.lbNgay_Ap.Size = new System.Drawing.Size(72, 13);
            this.lbNgay_Ap.TabIndex = 70;
            this.lbNgay_Ap.Tag = "Ngay_BD";
            this.lbNgay_Ap.Text = "Ngày bắt đầu";
            this.lbNgay_Ap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitConFull
            // 
            this.splitConFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitConFull.Location = new System.Drawing.Point(0, 0);
            this.splitConFull.Name = "splitConFull";
            this.splitConFull.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitConFull.Panel1
            // 
            this.splitConFull.Panel1.Controls.Add(this.pnPXK);
            this.splitConFull.Panel1.Controls.Add(this.btFillterData);
            this.splitConFull.Panel1.Controls.Add(this.lbNgay_Ap);
            this.splitConFull.Panel1.Controls.Add(this.lbGia);
            this.splitConFull.Panel1.Controls.Add(this.dteNgay_BD);
            this.splitConFull.Panel1.Controls.Add(this.dteNgay_Kt);
            this.splitConFull.Size = new System.Drawing.Size(909, 569);
            this.splitConFull.SplitterDistance = 540;
            this.splitConFull.TabIndex = 3;
            // 
            // pnPXK
            // 
            this.pnPXK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnPXK.Controls.Add(this.dgvDiscountProg);
            this.pnPXK.Location = new System.Drawing.Point(0, 36);
            this.pnPXK.Name = "pnPXK";
            this.pnPXK.Size = new System.Drawing.Size(906, 501);
            this.pnPXK.TabIndex = 74;
            // 
            // dgvDiscountProg
            // 
            this.dgvDiscountProg.AllowEdit = false;
            this.dgvDiscountProg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDiscountProg.Location = new System.Drawing.Point(0, 0);
            this.dgvDiscountProg.Name = "dgvDiscountProg";
            this.dgvDiscountProg.Size = new System.Drawing.Size(906, 501);
            this.dgvDiscountProg.strZone = "";
            this.dgvDiscountProg.TabIndex = 4;
            // 
            // frmDiscountManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 569);
            this.Controls.Add(this.splitConFull);
            this.Name = "frmDiscountManual";
            this.Text = "frmDiscount";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitConFull.Panel1.ResumeLayout(false);
            this.splitConFull.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitConFull)).EndInit();
            this.splitConFull.ResumeLayout(false);
            this.pnPXK.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscountProg)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private Systems.Controls.lblControl lbGia;
        private Systems.Controls.dteDateTime dteNgay_Kt;
        private Systems.Controls.dteDateTime dteNgay_BD;
        private Systems.Controls.lblControl lbNgay_Ap;
        private Systems.Customizes.btPreview btFillterData;
        private System.Windows.Forms.SplitContainer splitConFull;
        private System.Windows.Forms.Panel pnPXK;
        private Systems.Controls.dgvGridControl dgvDiscountProg;
	}
}