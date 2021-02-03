namespace Epoint.Modules.AR
{
	partial class frmGiaBan
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
            this.pnlGiaban = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMa_Dt = new Epoint.Systems.Controls.lblControl();
            this.lbMa_Vt = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Dt = new Epoint.Systems.Controls.txtTextLookup();
            this.txtMa_Vt = new Epoint.Systems.Controls.txtTextLookup();
            this.lbtTen_Dt = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Vt = new Epoint.Systems.Controls.lblControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGiaban
            // 
            this.pnlGiaban.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGiaban.Location = new System.Drawing.Point(0, 92);
            this.pnlGiaban.Name = "pnlGiaban";
            this.pnlGiaban.Size = new System.Drawing.Size(792, 474);
            this.pnlGiaban.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMa_Dt);
            this.groupBox1.Controls.Add(this.txtMa_Vt);
            this.groupBox1.Controls.Add(this.lbtTen_Dt);
            this.groupBox1.Controls.Add(this.lbtTen_Vt);
            this.groupBox1.Controls.Add(this.lblMa_Dt);
            this.groupBox1.Controls.Add(this.lbMa_Vt);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 86);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lọc giá bán";
            // 
            // lblMa_Dt
            // 
            this.lblMa_Dt.AutoEllipsis = true;
            this.lblMa_Dt.AutoSize = true;
            this.lblMa_Dt.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Dt.Location = new System.Drawing.Point(29, 55);
            this.lblMa_Dt.Name = "lblMa_Dt";
            this.lblMa_Dt.Size = new System.Drawing.Size(70, 13);
            this.lblMa_Dt.TabIndex = 72;
            this.lblMa_Dt.Tag = "Ma_Dt";
            this.lblMa_Dt.Text = "Mã đối tượng";
            this.lblMa_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Vt
            // 
            this.lbMa_Vt.AutoEllipsis = true;
            this.lbMa_Vt.AutoSize = true;
            this.lbMa_Vt.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_Vt.Location = new System.Drawing.Point(29, 32);
            this.lbMa_Vt.Name = "lbMa_Vt";
            this.lbMa_Vt.Size = new System.Drawing.Size(52, 13);
            this.lbMa_Vt.TabIndex = 71;
            this.lbMa_Vt.Tag = "Ma_Vt";
            this.lbMa_Vt.Text = "Mã vật tư";
            this.lbMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt
            // 
            this.txtMa_Dt.bEnabled = true;
            this.txtMa_Dt.bIsLookup = false;
            this.txtMa_Dt.bReadOnly = false;
            this.txtMa_Dt.bRequire = false;
            this.txtMa_Dt.ColumnsView = null;
            this.txtMa_Dt.CtrlDepend = null;
            this.txtMa_Dt.KeyFilter = "Ma_Dt";
            this.txtMa_Dt.Location = new System.Drawing.Point(148, 52);
            this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt.Name = "txtMa_Dt";
            this.txtMa_Dt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Dt.TabIndex = 81;
            this.txtMa_Dt.UseAutoFilter = true;
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
            this.txtMa_Vt.Location = new System.Drawing.Point(148, 29);
            this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt.Name = "txtMa_Vt";
            this.txtMa_Vt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Vt.TabIndex = 80;
            this.txtMa_Vt.UseAutoFilter = true;
            // 
            // lbtTen_Dt
            // 
            this.lbtTen_Dt.AutoEllipsis = true;
            this.lbtTen_Dt.AutoSize = true;
            this.lbtTen_Dt.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Dt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt.Location = new System.Drawing.Point(274, 55);
            this.lbtTen_Dt.Name = "lbtTen_Dt";
            this.lbtTen_Dt.Size = new System.Drawing.Size(74, 13);
            this.lbtTen_Dt.TabIndex = 84;
            this.lbtTen_Dt.Text = "Tên đối tượng";
            this.lbtTen_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Vt
            // 
            this.lbtTen_Vt.AutoEllipsis = true;
            this.lbtTen_Vt.AutoSize = true;
            this.lbtTen_Vt.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Vt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt.Location = new System.Drawing.Point(274, 32);
            this.lbtTen_Vt.Name = "lbtTen_Vt";
            this.lbtTen_Vt.Size = new System.Drawing.Size(56, 13);
            this.lbtTen_Vt.TabIndex = 83;
            this.lbtTen_Vt.Text = "Tên vật tư";
            this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmGiaBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlGiaban);
            this.Name = "frmGiaBan";
            this.Text = "frmGiaBanBan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Panel pnlGiaban;
        private System.Windows.Forms.GroupBox groupBox1;
        private Systems.Controls.lblControl lblMa_Dt;
        private Systems.Controls.lblControl lbMa_Vt;
        private Systems.Controls.txtTextLookup txtMa_Dt;
        private Systems.Controls.txtTextLookup txtMa_Vt;
        private Systems.Controls.lblControl lbtTen_Dt;
        private Systems.Controls.lblControl lbtTen_Vt;
	}
}