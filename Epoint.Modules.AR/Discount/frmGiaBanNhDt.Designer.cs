namespace Epoint.Modules.AR
{
    partial class frmGiaBanNhDt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiaBanNhDt));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btCopyPrice = new Epoint.Systems.Customizes.btPreview();
            this.txtMa_Vt = new Epoint.Systems.Controls.txtTextLookup();
            this.cboMa_Nh_Dt = new Epoint.Systems.Controls.cboMultiControl();
            this.lbtTen_Vt = new Epoint.Systems.Controls.lblControl();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.lbMa_Vt = new Epoint.Systems.Controls.lblControl();
            this.pnlGiaban = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btCopyPrice);
            this.groupBox1.Controls.Add(this.txtMa_Vt);
            this.groupBox1.Controls.Add(this.cboMa_Nh_Dt);
            this.groupBox1.Controls.Add(this.lbtTen_Vt);
            this.groupBox1.Controls.Add(this.lblControl2);
            this.groupBox1.Controls.Add(this.lbMa_Vt);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 52);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lọc giá bán";
            // 
            // btCopyPrice
            // 
            this.btCopyPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCopyPrice.Image = ((System.Drawing.Image)(resources.GetObject("btCopyPrice.Image")));
            this.btCopyPrice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCopyPrice.Location = new System.Drawing.Point(633, 19);
            this.btCopyPrice.Name = "btCopyPrice";
            this.btCopyPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btCopyPrice.Size = new System.Drawing.Size(125, 27);
            this.btCopyPrice.TabIndex = 73;
            this.btCopyPrice.Tag = "";
            this.btCopyPrice.Text = "Copy nhóm giá";
            this.btCopyPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCopyPrice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCopyPrice.UseVisualStyleBackColor = true;
            // 
            // txtMa_Vt
            // 
            this.txtMa_Vt.bEnabled = true;
            this.txtMa_Vt.bIsLookup = false;
            this.txtMa_Vt.bReadOnly = false;
            this.txtMa_Vt.bRequire = false;
            this.txtMa_Vt.ColumnsView = null;
            this.txtMa_Vt.CtrlDepend = null;
            this.txtMa_Vt.KeyFilter = "Ma_Vt";
            this.txtMa_Vt.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtMa_Vt.ListFilter = new string[0];
            this.txtMa_Vt.Location = new System.Drawing.Point(127, 18);
            this.txtMa_Vt.LookupKeyFilter = "";
            this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt.Name = "txtMa_Vt";
            this.txtMa_Vt.Size = new System.Drawing.Size(125, 20);
            this.txtMa_Vt.TabIndex = 83;
            this.txtMa_Vt.UseAutoFilter = true;
            // 
            // cboMa_Nh_Dt
            // 
            this.cboMa_Nh_Dt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMa_Nh_Dt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboMa_Nh_Dt.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboMa_Nh_Dt.FormattingEnabled = true;
            this.cboMa_Nh_Dt.InitValue = null;
            this.cboMa_Nh_Dt.Location = new System.Drawing.Point(440, 21);
            this.cboMa_Nh_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboMa_Nh_Dt.Name = "cboMa_Nh_Dt";
            this.cboMa_Nh_Dt.Size = new System.Drawing.Size(125, 21);
            this.cboMa_Nh_Dt.strValueList = null;
            this.cboMa_Nh_Dt.TabIndex = 2;
            this.cboMa_Nh_Dt.UpperCase = false;
            this.cboMa_Nh_Dt.UseAutoComplete = false;
            this.cboMa_Nh_Dt.UseBindingValue = false;
            // 
            // lbtTen_Vt
            // 
            this.lbtTen_Vt.AutoEllipsis = true;
            this.lbtTen_Vt.AutoSize = true;
            this.lbtTen_Vt.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Vt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt.Location = new System.Drawing.Point(263, 21);
            this.lbtTen_Vt.Name = "lbtTen_Vt";
            this.lbtTen_Vt.Size = new System.Drawing.Size(56, 13);
            this.lbtTen_Vt.TabIndex = 85;
            this.lbtTen_Vt.Text = "Tên vật tư";
            this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(346, 21);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(51, 13);
            this.lblControl2.TabIndex = 1;
            this.lblControl2.Tag = "Ma_Nhom";
            this.lblControl2.Text = "Mã nhóm";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Vt
            // 
            this.lbMa_Vt.AutoEllipsis = true;
            this.lbMa_Vt.AutoSize = true;
            this.lbMa_Vt.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_Vt.Location = new System.Drawing.Point(33, 21);
            this.lbMa_Vt.Name = "lbMa_Vt";
            this.lbMa_Vt.Size = new System.Drawing.Size(52, 13);
            this.lbMa_Vt.TabIndex = 84;
            this.lbMa_Vt.Tag = "Ma_Vt";
            this.lbMa_Vt.Text = "Mã vật tư";
            this.lbMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlGiaban
            // 
            this.pnlGiaban.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGiaban.Location = new System.Drawing.Point(0, 52);
            this.pnlGiaban.Name = "pnlGiaban";
            this.pnlGiaban.Size = new System.Drawing.Size(792, 514);
            this.pnlGiaban.TabIndex = 2;
            // 
            // frmGiaBanNhDt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.pnlGiaban);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmGiaBanNhDt";
            this.Text = "frmGiaBanBan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Systems.Controls.txtTextLookup txtMa_Vt;
        private Systems.Controls.cboMultiControl cboMa_Nh_Dt;
        private Systems.Controls.lblControl lbtTen_Vt;
        private Systems.Controls.lblControl lblControl2;
        private Systems.Controls.lblControl lbMa_Vt;
        private System.Windows.Forms.Panel pnlGiaban;
        private Systems.Customizes.btPreview btCopyPrice;

    }
}