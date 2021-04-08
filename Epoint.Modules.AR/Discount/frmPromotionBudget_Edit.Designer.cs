namespace Epoint.Modules.AR
{
    partial class frmPromotionBudget_Edit
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
            this.chkActive = new Epoint.Systems.Controls.chkControl();
            this.txtTen_Ns = new Epoint.Systems.Controls.txtTextLookup();
            this.lblMa_PJP = new Epoint.Systems.Controls.lblControl();
            this.lbMa_Vt = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Ns = new Epoint.Systems.Controls.txtTextLookup();
            this.lblControl5 = new Epoint.Systems.Controls.lblControl();
            this.numQtyAlloc = new Epoint.Systems.Controls.numControl();
            this.lblTTien = new Epoint.Systems.Controls.lblControl();
            this.numAmtAlloc = new Epoint.Systems.Controls.numControl();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(416, 215);
            this.btgAccept.Size = new System.Drawing.Size(181, 29);
            this.btgAccept.TabIndex = 1;
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(588, 199);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.lblControl5);
            this.Page1.Controls.Add(this.numQtyAlloc);
            this.Page1.Controls.Add(this.lblTTien);
            this.Page1.Controls.Add(this.numAmtAlloc);
            this.Page1.Controls.Add(this.chkActive);
            this.Page1.Controls.Add(this.txtTen_Ns);
            this.Page1.Controls.Add(this.lbMa_Vt);
            this.Page1.Controls.Add(this.txtMa_Ns);
            this.Page1.Controls.Add(this.lblMa_PJP);
            this.Page1.Size = new System.Drawing.Size(580, 173);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(580, 173);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActive.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkActive.Location = new System.Drawing.Point(122, 127);
            this.chkActive.Name = "chkActive";
            this.chkActive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkActive.Size = new System.Drawing.Size(77, 17);
            this.chkActive.TabIndex = 4;
            this.chkActive.Tag = "Active";
            this.chkActive.Text = "Hoạt động";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtTen_Ns
            // 
            this.txtTen_Ns.bEnabled = true;
            this.txtTen_Ns.bIsLookup = false;
            this.txtTen_Ns.bReadOnly = false;
            this.txtTen_Ns.bRequire = false;
            this.txtTen_Ns.ColumnsView = null;
            this.txtTen_Ns.CtrlDepend = null;
            this.txtTen_Ns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen_Ns.KeyFilter = "";
            this.txtTen_Ns.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtTen_Ns.ListFilter = new string[0];
            this.txtTen_Ns.Location = new System.Drawing.Point(122, 43);
            this.txtTen_Ns.LookupKeyFilter = "";
            this.txtTen_Ns.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Ns.Name = "txtTen_Ns";
            this.txtTen_Ns.Size = new System.Drawing.Size(382, 20);
            this.txtTen_Ns.TabIndex = 1;
            this.txtTen_Ns.UseAutoFilter = false;
            // 
            // lblMa_PJP
            // 
            this.lblMa_PJP.AutoEllipsis = true;
            this.lblMa_PJP.AutoSize = true;
            this.lblMa_PJP.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_PJP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMa_PJP.Location = new System.Drawing.Point(16, 46);
            this.lblMa_PJP.Name = "lblMa_PJP";
            this.lblMa_PJP.Size = new System.Drawing.Size(48, 13);
            this.lblMa_PJP.TabIndex = 144;
            this.lblMa_PJP.Tag = "TEN_NS";
            this.lblMa_PJP.Text = "Diễn giải";
            this.lblMa_PJP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Vt
            // 
            this.lbMa_Vt.AutoEllipsis = true;
            this.lbMa_Vt.AutoSize = true;
            this.lbMa_Vt.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_Vt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMa_Vt.Location = new System.Drawing.Point(17, 23);
            this.lbMa_Vt.Name = "lbMa_Vt";
            this.lbMa_Vt.Size = new System.Drawing.Size(38, 13);
            this.lbMa_Vt.TabIndex = 136;
            this.lbMa_Vt.Tag = "Ma_NS";
            this.lbMa_Vt.Text = "Mã Ns";
            this.lbMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Ns
            // 
            this.txtMa_Ns.bEnabled = true;
            this.txtMa_Ns.bIsLookup = false;
            this.txtMa_Ns.bReadOnly = false;
            this.txtMa_Ns.bRequire = false;
            this.txtMa_Ns.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Ns.ColumnsView = null;
            this.txtMa_Ns.CtrlDepend = null;
            this.txtMa_Ns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_Ns.KeyFilter = "";
            this.txtMa_Ns.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtMa_Ns.ListFilter = new string[0];
            this.txtMa_Ns.Location = new System.Drawing.Point(122, 20);
            this.txtMa_Ns.LookupKeyFilter = "";
            this.txtMa_Ns.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Ns.Name = "txtMa_Ns";
            this.txtMa_Ns.Size = new System.Drawing.Size(159, 20);
            this.txtMa_Ns.TabIndex = 0;
            this.txtMa_Ns.UseAutoFilter = false;
            // 
            // lblControl5
            // 
            this.lblControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblControl5.AutoEllipsis = true;
            this.lblControl5.AutoSize = true;
            this.lblControl5.BackColor = System.Drawing.Color.Transparent;
            this.lblControl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl5.ForeColor = System.Drawing.Color.Blue;
            this.lblControl5.Location = new System.Drawing.Point(16, 95);
            this.lblControl5.Name = "lblControl5";
            this.lblControl5.Size = new System.Drawing.Size(100, 13);
            this.lblControl5.TabIndex = 151;
            this.lblControl5.Tag = "TSO_LUONG";
            this.lblControl5.Text = "Ngân sách hàng";
            this.lblControl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numQtyAlloc
            // 
            this.numQtyAlloc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numQtyAlloc.bEnabled = true;
            this.numQtyAlloc.bFormat = true;
            this.numQtyAlloc.bIsLookup = false;
            this.numQtyAlloc.bReadOnly = false;
            this.numQtyAlloc.bRequire = false;
            this.numQtyAlloc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numQtyAlloc.ForeColor = System.Drawing.Color.Blue;
            this.numQtyAlloc.KeyFilter = "";
            this.numQtyAlloc.Location = new System.Drawing.Point(121, 91);
            this.numQtyAlloc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numQtyAlloc.Name = "numQtyAlloc";
            this.numQtyAlloc.Scale = 2;
            this.numQtyAlloc.Size = new System.Drawing.Size(111, 20);
            this.numQtyAlloc.TabIndex = 3;
            this.numQtyAlloc.TabStop = false;
            this.numQtyAlloc.Text = "0.00";
            this.numQtyAlloc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numQtyAlloc.UseAutoFilter = false;
            this.numQtyAlloc.Value = 0D;
            // 
            // lblTTien
            // 
            this.lblTTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTTien.AutoEllipsis = true;
            this.lblTTien.AutoSize = true;
            this.lblTTien.BackColor = System.Drawing.Color.Transparent;
            this.lblTTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTTien.ForeColor = System.Drawing.Color.Blue;
            this.lblTTien.Location = new System.Drawing.Point(16, 73);
            this.lblTTien.Name = "lblTTien";
            this.lblTTien.Size = new System.Drawing.Size(93, 13);
            this.lblTTien.TabIndex = 150;
            this.lblTTien.Tag = "";
            this.lblTTien.Text = "Ngân sách tiền";
            this.lblTTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numAmtAlloc
            // 
            this.numAmtAlloc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numAmtAlloc.bEnabled = true;
            this.numAmtAlloc.bFormat = true;
            this.numAmtAlloc.bIsLookup = false;
            this.numAmtAlloc.bReadOnly = false;
            this.numAmtAlloc.bRequire = false;
            this.numAmtAlloc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAmtAlloc.ForeColor = System.Drawing.Color.Blue;
            this.numAmtAlloc.KeyFilter = "";
            this.numAmtAlloc.Location = new System.Drawing.Point(121, 69);
            this.numAmtAlloc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numAmtAlloc.Name = "numAmtAlloc";
            this.numAmtAlloc.Scale = 2;
            this.numAmtAlloc.Size = new System.Drawing.Size(111, 20);
            this.numAmtAlloc.TabIndex = 2;
            this.numAmtAlloc.TabStop = false;
            this.numAmtAlloc.Text = "0.00";
            this.numAmtAlloc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numAmtAlloc.UseAutoFilter = false;
            this.numAmtAlloc.Value = 0D;
            // 
            // frmPromotionBudget_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 248);
            this.Name = "frmPromotionBudget_Edit";
            this.Object_ID = "LITUYEN";
            this.Tag = "ESC";
            this.Text = "frmPJPConfig";
            this.tabEdit.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.Page1.PerformLayout();
            this.Page2.ResumeLayout(false);
            this.Page2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private Systems.Controls.chkControl chkActive;
        private Systems.Controls.txtTextLookup txtTen_Ns;
        private Systems.Controls.lblControl lblMa_PJP;
        private Systems.Controls.lblControl lbMa_Vt;
        private Systems.Controls.txtTextLookup txtMa_Ns;
        private Systems.Controls.lblControl lblControl5;
        private Systems.Controls.numControl numQtyAlloc;
        private Systems.Controls.lblControl lblTTien;
        private Systems.Controls.numControl numAmtAlloc;
    }
}