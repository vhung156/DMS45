namespace Epoint.Modules.AR
{
    partial class frmCtSO_View_Bk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCtSO_View_Bk));
            this.dgvViewPh = new Epoint.Systems.Customizes.dgvVoucherGrid();
            this.dgvViewCt = new Epoint.Systems.Customizes.dgvVoucherGrid();
            this.numTTien3 = new Epoint.Systems.Controls.numControl();
            this.numTTien0 = new Epoint.Systems.Controls.numControl();
            this.lbtTTien3 = new Epoint.Systems.Controls.lblControl();
            this.lbtTTien0 = new Epoint.Systems.Controls.lblControl();
            this.numTTien_Nt3 = new Epoint.Systems.Controls.numControl();
            this.numTTien_Nt0 = new Epoint.Systems.Controls.numControl();
            this.btnPXK = new Epoint.Systems.Customizes.btFilter();
            this.btDiscoutDetail = new Epoint.Systems.Customizes.btFilter();
            ((System.ComponentModel.ISupportInitialize)(this.dsVoucher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsViewPh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsViewCt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewPh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewCt)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvViewPh
            // 
            this.dgvViewPh.AllowEdit = false;
            this.dgvViewPh.Location = new System.Drawing.Point(3, 3);
            this.dgvViewPh.LookAndFeel.SkinName = "Office 2010 Silver";
            this.dgvViewPh.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dgvViewPh.Name = "dgvViewPh";
            this.dgvViewPh.Size = new System.Drawing.Size(782, 204);
            this.dgvViewPh.strZone = "";
            this.dgvViewPh.TabIndex = 0;
            // 
            // dgvViewCt
            // 
            this.dgvViewCt.AllowEdit = false;
            this.dgvViewCt.Location = new System.Drawing.Point(3, 207);
            this.dgvViewCt.LookAndFeel.SkinName = "Office 2010 Silver";
            this.dgvViewCt.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dgvViewCt.Name = "dgvViewCt";
            this.dgvViewCt.Size = new System.Drawing.Size(782, 115);
            this.dgvViewCt.strZone = "";
            this.dgvViewCt.TabIndex = 0;
            // 
            // numTTien3
            // 
            this.numTTien3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numTTien3.bEnabled = true;
            this.numTTien3.bFormat = true;
            this.numTTien3.bIsLookup = false;
            this.numTTien3.bReadOnly = false;
            this.numTTien3.bRequire = false;
            this.numTTien3.KeyFilter = "";
            this.numTTien3.Location = new System.Drawing.Point(1, 30);
            this.numTTien3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien3.Name = "numTTien3";
            this.numTTien3.Scale = 0;
            this.numTTien3.Size = new System.Drawing.Size(99, 20);
            this.numTTien3.TabIndex = 87;
            this.numTTien3.TabStop = false;
            this.numTTien3.Text = "0";
            this.numTTien3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien3.UseAutoFilter = false;
            this.numTTien3.Value = 0D;
            // 
            // numTTien0
            // 
            this.numTTien0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numTTien0.bEnabled = true;
            this.numTTien0.bFormat = true;
            this.numTTien0.bIsLookup = false;
            this.numTTien0.bReadOnly = false;
            this.numTTien0.bRequire = false;
            this.numTTien0.KeyFilter = "";
            this.numTTien0.Location = new System.Drawing.Point(1, 8);
            this.numTTien0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien0.Name = "numTTien0";
            this.numTTien0.Scale = 0;
            this.numTTien0.Size = new System.Drawing.Size(99, 20);
            this.numTTien0.TabIndex = 84;
            this.numTTien0.TabStop = false;
            this.numTTien0.Text = "0";
            this.numTTien0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien0.UseAutoFilter = false;
            this.numTTien0.Value = 0D;
            // 
            // lbtTTien3
            // 
            this.lbtTTien3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbtTTien3.AutoEllipsis = true;
            this.lbtTTien3.AutoSize = true;
            this.lbtTTien3.BackColor = System.Drawing.Color.Transparent;
            this.lbtTTien3.Location = new System.Drawing.Point(5, 34);
            this.lbtTTien3.Name = "lbtTTien3";
            this.lbtTTien3.Size = new System.Drawing.Size(52, 13);
            this.lbtTTien3.TabIndex = 111;
            this.lbtTTien3.Text = "Tiền VAT";
            this.lbtTTien3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTTien0
            // 
            this.lbtTTien0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbtTTien0.AutoEllipsis = true;
            this.lbtTTien0.AutoSize = true;
            this.lbtTTien0.BackColor = System.Drawing.Color.Transparent;
            this.lbtTTien0.Location = new System.Drawing.Point(5, 12);
            this.lbtTTien0.Name = "lbtTTien0";
            this.lbtTTien0.Size = new System.Drawing.Size(55, 13);
            this.lbtTTien0.TabIndex = 110;
            this.lbtTTien0.Text = "Tiền hàng";
            this.lbtTTien0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTTien_Nt3
            // 
            this.numTTien_Nt3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numTTien_Nt3.bEnabled = true;
            this.numTTien_Nt3.bFormat = true;
            this.numTTien_Nt3.bIsLookup = false;
            this.numTTien_Nt3.bReadOnly = false;
            this.numTTien_Nt3.bRequire = false;
            this.numTTien_Nt3.KeyFilter = "";
            this.numTTien_Nt3.Location = new System.Drawing.Point(64, 30);
            this.numTTien_Nt3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien_Nt3.Name = "numTTien_Nt3";
            this.numTTien_Nt3.Scale = 2;
            this.numTTien_Nt3.Size = new System.Drawing.Size(99, 20);
            this.numTTien_Nt3.TabIndex = 86;
            this.numTTien_Nt3.TabStop = false;
            this.numTTien_Nt3.Text = "0.00";
            this.numTTien_Nt3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien_Nt3.UseAutoFilter = false;
            this.numTTien_Nt3.Value = 0D;
            // 
            // numTTien_Nt0
            // 
            this.numTTien_Nt0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numTTien_Nt0.bEnabled = true;
            this.numTTien_Nt0.bFormat = true;
            this.numTTien_Nt0.bIsLookup = false;
            this.numTTien_Nt0.bReadOnly = false;
            this.numTTien_Nt0.bRequire = false;
            this.numTTien_Nt0.KeyFilter = "";
            this.numTTien_Nt0.Location = new System.Drawing.Point(64, 8);
            this.numTTien_Nt0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien_Nt0.Name = "numTTien_Nt0";
            this.numTTien_Nt0.Scale = 2;
            this.numTTien_Nt0.Size = new System.Drawing.Size(99, 20);
            this.numTTien_Nt0.TabIndex = 83;
            this.numTTien_Nt0.TabStop = false;
            this.numTTien_Nt0.Text = "0.00";
            this.numTTien_Nt0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien_Nt0.UseAutoFilter = false;
            this.numTTien_Nt0.Value = 0D;
            // 
            // btnPXK
            // 
            this.btnPXK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPXK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPXK.Image = ((System.Drawing.Image)(resources.GetObject("btnPXK.Image")));
            this.btnPXK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPXK.Location = new System.Drawing.Point(458, 305);
            this.btnPXK.Name = "btnPXK";
            this.btnPXK.Size = new System.Drawing.Size(92, 49);
            this.btnPXK.TabIndex = 110;
            this.btnPXK.Tag = "";
            this.btnPXK.Text = "Tạo Phiếu Xuất kho";
            this.btnPXK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPXK.UseVisualStyleBackColor = true;
            // 
            // btDiscoutDetail
            // 
            this.btDiscoutDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDiscoutDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDiscoutDetail.Image = ((System.Drawing.Image)(resources.GetObject("btDiscoutDetail.Image")));
            this.btDiscoutDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDiscoutDetail.Location = new System.Drawing.Point(352, 305);
            this.btDiscoutDetail.Name = "btDiscoutDetail";
            this.btDiscoutDetail.Size = new System.Drawing.Size(100, 49);
            this.btDiscoutDetail.TabIndex = 110;
            this.btDiscoutDetail.Tag = "";
            this.btDiscoutDetail.Text = "Chi tiết KM";
            this.btDiscoutDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDiscoutDetail.UseVisualStyleBackColor = true;
            // 
            // frmCtSO_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(773, 369);
            this.Controls.Add(this.btDiscoutDetail);
            this.Controls.Add(this.btnPXK);
            this.Name = "frmCtSO_View";
            this.Tag = "frmCtHD, F2, F3, F7, F8, ESC";
            this.Text = "frmCt_View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.btnPXK, 0);
            this.Controls.SetChildIndex(this.btDiscoutDetail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsVoucher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsViewPh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsViewCt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewPh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewCt)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private Epoint.Systems.Controls.numControl numTTien3;
		private Epoint.Systems.Controls.numControl numTTien0;
		private Epoint.Systems.Controls.lblControl lbtTTien3;
		private Epoint.Systems.Controls.lblControl lbtTTien0;
		private Epoint.Systems.Controls.numControl numTTien_Nt3;
        private Epoint.Systems.Controls.numControl numTTien_Nt0;
        private Systems.Customizes.btFilter btnPXK;
        //private Systems.Customizes.dgvVoucherGrid dgvViewPh;
        //private Systems.Customizes.dgvVoucherGrid dgvViewCt;
        private Systems.Customizes.btFilter btDiscoutDetail;

	}
}