namespace Epoint.Modules.AR
{
    partial class frmDiscItem_Edit
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
            this.txtSTT = new Epoint.Systems.Controls.txtTextLookup();
            this.txtMa_CTKM = new Epoint.Systems.Controls.txtTextLookup();
            this.lblMa_Dt = new Epoint.Systems.Controls.lblControl();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Vt = new Epoint.Systems.Controls.txtTextLookup();
            this.lblControl3 = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Vt = new Epoint.Systems.Controls.lblControl();
            this.lbMa_Vt = new Epoint.Systems.Controls.lblControl();
            this.chkActive = new Epoint.Systems.Controls.chkControl();
            this.txtDvt = new Epoint.Systems.Controls.txtEnum();
            this.lblSo_Luong = new Epoint.Systems.Controls.lblControl();
            this.numSo_Luong = new Epoint.Systems.Controls.numControl();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(282, 282);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 29);
            this.btgAccept.TabIndex = 6;
            // 
            // txtSTT
            // 
            this.txtSTT.bEnabled = true;
            this.txtSTT.bIsLookup = false;
            this.txtSTT.bReadOnly = false;
            this.txtSTT.bRequire = false;
            this.txtSTT.ColumnsView = null;
            this.txtSTT.CtrlDepend = null;
            this.txtSTT.KeyFilter = "Ma_Dt";
            this.txtSTT.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtSTT.ListFilter = new string[0];
            this.txtSTT.Location = new System.Drawing.Point(144, 54);
            this.txtSTT.LookupKeyFilter = "";
            this.txtSTT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSTT.Name = "txtSTT";
            this.txtSTT.ReadOnly = true;
            this.txtSTT.Size = new System.Drawing.Size(120, 20);
            this.txtSTT.TabIndex = 1;
            this.txtSTT.UseAutoFilter = true;
            // 
            // txtMa_CTKM
            // 
            this.txtMa_CTKM.bEnabled = true;
            this.txtMa_CTKM.bIsLookup = false;
            this.txtMa_CTKM.bReadOnly = false;
            this.txtMa_CTKM.bRequire = false;
            this.txtMa_CTKM.ColumnsView = null;
            this.txtMa_CTKM.CtrlDepend = null;
            this.txtMa_CTKM.KeyFilter = "";
            this.txtMa_CTKM.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtMa_CTKM.ListFilter = new string[0];
            this.txtMa_CTKM.Location = new System.Drawing.Point(144, 29);
            this.txtMa_CTKM.LookupKeyFilter = "";
            this.txtMa_CTKM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_CTKM.Name = "txtMa_CTKM";
            this.txtMa_CTKM.ReadOnly = true;
            this.txtMa_CTKM.Size = new System.Drawing.Size(120, 20);
            this.txtMa_CTKM.TabIndex = 0;
            this.txtMa_CTKM.UseAutoFilter = false;
            // 
            // lblMa_Dt
            // 
            this.lblMa_Dt.AutoEllipsis = true;
            this.lblMa_Dt.AutoSize = true;
            this.lblMa_Dt.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Dt.Location = new System.Drawing.Point(51, 55);
            this.lblMa_Dt.Name = "lblMa_Dt";
            this.lblMa_Dt.Size = new System.Drawing.Size(50, 13);
            this.lblMa_Dt.TabIndex = 92;
            this.lblMa_Dt.Tag = "STT";
            this.lblMa_Dt.Text = "Số thứ tự";
            this.lblMa_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(51, 32);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(55, 13);
            this.lblControl1.TabIndex = 91;
            this.lblControl1.Tag = "Ma_CTKM";
            this.lblControl1.Text = "Mã CTKM";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.txtMa_Vt.Location = new System.Drawing.Point(144, 80);
            this.txtMa_Vt.LookupKeyFilter = "";
            this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt.Name = "txtMa_Vt";
            this.txtMa_Vt.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Vt.TabIndex = 2;
            this.txtMa_Vt.UseAutoFilter = true;
            // 
            // lblControl3
            // 
            this.lblControl3.AutoEllipsis = true;
            this.lblControl3.AutoSize = true;
            this.lblControl3.BackColor = System.Drawing.Color.Transparent;
            this.lblControl3.Location = new System.Drawing.Point(51, 106);
            this.lblControl3.Name = "lblControl3";
            this.lblControl3.Size = new System.Drawing.Size(60, 13);
            this.lblControl3.TabIndex = 87;
            this.lblControl3.Tag = "DVT";
            this.lblControl3.Text = "Đơn vị tính";
            this.lblControl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Vt
            // 
            this.lbtTen_Vt.AutoEllipsis = true;
            this.lbtTen_Vt.AutoSize = true;
            this.lbtTen_Vt.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Vt.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt.Location = new System.Drawing.Point(271, 83);
            this.lbtTen_Vt.Name = "lbtTen_Vt";
            this.lbtTen_Vt.Size = new System.Drawing.Size(56, 13);
            this.lbtTen_Vt.TabIndex = 89;
            this.lbtTen_Vt.Text = "Tên vật tư";
            this.lbtTen_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Vt
            // 
            this.lbMa_Vt.AutoEllipsis = true;
            this.lbMa_Vt.AutoSize = true;
            this.lbMa_Vt.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_Vt.Location = new System.Drawing.Point(51, 83);
            this.lbMa_Vt.Name = "lbMa_Vt";
            this.lbMa_Vt.Size = new System.Drawing.Size(52, 13);
            this.lbMa_Vt.TabIndex = 88;
            this.lbMa_Vt.Tag = "Ma_Vt";
            this.lbMa_Vt.Text = "Mã vật tư";
            this.lbMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkActive.Location = new System.Drawing.Point(144, 233);
            this.chkActive.Name = "chkActive";
            this.chkActive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkActive.Size = new System.Drawing.Size(77, 17);
            this.chkActive.TabIndex = 5;
            this.chkActive.TabStop = false;
            this.chkActive.Tag = "Active";
            this.chkActive.Text = "Hoạt động";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtDvt
            // 
            this.txtDvt.bEnabled = true;
            this.txtDvt.bIsLookup = false;
            this.txtDvt.bReadOnly = false;
            this.txtDvt.bRequire = false;
            this.txtDvt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDvt.InputMask = "";
            this.txtDvt.KeyFilter = "";
            this.txtDvt.Location = new System.Drawing.Point(144, 103);
            this.txtDvt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDvt.Name = "txtDvt";
            this.txtDvt.Size = new System.Drawing.Size(120, 20);
            this.txtDvt.TabIndex = 3;
            this.txtDvt.Text = "0";
            this.txtDvt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDvt.UseAutoFilter = false;
            // 
            // lblSo_Luong
            // 
            this.lblSo_Luong.AutoEllipsis = true;
            this.lblSo_Luong.AutoSize = true;
            this.lblSo_Luong.BackColor = System.Drawing.Color.Transparent;
            this.lblSo_Luong.Location = new System.Drawing.Point(51, 135);
            this.lblSo_Luong.Name = "lblSo_Luong";
            this.lblSo_Luong.Size = new System.Drawing.Size(53, 13);
            this.lblSo_Luong.TabIndex = 87;
            this.lblSo_Luong.Tag = "So_Luong";
            this.lblSo_Luong.Text = "Số Lượng";
            this.lblSo_Luong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSo_Luong.Visible = false;
            // 
            // numSo_Luong
            // 
            this.numSo_Luong.bEnabled = true;
            this.numSo_Luong.bFormat = true;
            this.numSo_Luong.bIsLookup = false;
            this.numSo_Luong.bReadOnly = false;
            this.numSo_Luong.bRequire = false;
            this.numSo_Luong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSo_Luong.KeyFilter = "";
            this.numSo_Luong.Location = new System.Drawing.Point(144, 129);
            this.numSo_Luong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numSo_Luong.Name = "numSo_Luong";
            this.numSo_Luong.Scale = 2;
            this.numSo_Luong.Size = new System.Drawing.Size(118, 20);
            this.numSo_Luong.TabIndex = 4;
            this.numSo_Luong.Text = "0.00";
            this.numSo_Luong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSo_Luong.UseAutoFilter = false;
            this.numSo_Luong.Value = 0D;
            this.numSo_Luong.Visible = false;
            // 
            // frmDiscItem_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 323);
            this.Controls.Add(this.numSo_Luong);
            this.Controls.Add(this.txtDvt);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.txtSTT);
            this.Controls.Add(this.txtMa_CTKM);
            this.Controls.Add(this.lblMa_Dt);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.lblSo_Luong);
            this.Controls.Add(this.txtMa_Vt);
            this.Controls.Add(this.lblControl3);
            this.Controls.Add(this.lbtTen_Vt);
            this.Controls.Add(this.lbMa_Vt);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmDiscItem_Edit";
            this.Tag = "frmGiaBan";
            this.Text = "frmGiaBan";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Epoint.Systems.Customizes.btgAccept btgAccept;
        private Systems.Controls.txtTextLookup txtSTT;
        private Systems.Controls.txtTextLookup txtMa_CTKM;
        private Systems.Controls.lblControl lblMa_Dt;
        private Systems.Controls.lblControl lblControl1;
        private Systems.Controls.txtTextLookup txtMa_Vt;
        private Systems.Controls.lblControl lblControl3;
        private Systems.Controls.lblControl lbtTen_Vt;
        private Systems.Controls.lblControl lbMa_Vt;
        private Systems.Controls.chkControl chkActive;
        private Systems.Controls.txtEnum txtDvt;
        private Systems.Controls.lblControl lblSo_Luong;
        private Systems.Controls.numControl numSo_Luong;
	}
}