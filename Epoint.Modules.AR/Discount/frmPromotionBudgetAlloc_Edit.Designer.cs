namespace Epoint.Modules.AR
{
    partial class frmPromotionBudgetAlloc_Edit
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
            this.lbMa_Vt = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Ns = new Epoint.Systems.Controls.txtTextLookup();
            this.lblControl5 = new Epoint.Systems.Controls.lblControl();
            this.numQtyAlloc = new Epoint.Systems.Controls.numControl();
            this.lblTTien = new Epoint.Systems.Controls.lblControl();
            this.numAmtAlloc = new Epoint.Systems.Controls.numControl();
            this.txtMa_Cbnv = new Epoint.Systems.Controls.txtTextLookup();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.numAmtSpent = new Epoint.Systems.Controls.numControl();
            this.numQtySpent = new Epoint.Systems.Controls.numControl();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(415, 259);
            this.btgAccept.Size = new System.Drawing.Size(181, 29);
            this.btgAccept.TabIndex = 1;
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(587, 243);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.txtMa_Cbnv);
            this.Page1.Controls.Add(this.lblControl1);
            this.Page1.Controls.Add(this.lblControl5);
            this.Page1.Controls.Add(this.numQtySpent);
            this.Page1.Controls.Add(this.numQtyAlloc);
            this.Page1.Controls.Add(this.numAmtSpent);
            this.Page1.Controls.Add(this.lblTTien);
            this.Page1.Controls.Add(this.numAmtAlloc);
            this.Page1.Controls.Add(this.lbMa_Vt);
            this.Page1.Controls.Add(this.txtMa_Ns);
            this.Page1.Size = new System.Drawing.Size(579, 217);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(579, 217);
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
            this.txtMa_Ns.bReadOnly = true;
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
            this.lblControl5.AutoEllipsis = true;
            this.lblControl5.AutoSize = true;
            this.lblControl5.BackColor = System.Drawing.Color.Transparent;
            this.lblControl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl5.ForeColor = System.Drawing.Color.Blue;
            this.lblControl5.Location = new System.Drawing.Point(16, 100);
            this.lblControl5.Name = "lblControl5";
            this.lblControl5.Size = new System.Drawing.Size(100, 13);
            this.lblControl5.TabIndex = 151;
            this.lblControl5.Tag = "TSO_LUONG";
            this.lblControl5.Text = "Ngân sách hàng";
            this.lblControl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numQtyAlloc
            // 
            this.numQtyAlloc.bEnabled = true;
            this.numQtyAlloc.bFormat = true;
            this.numQtyAlloc.bIsLookup = false;
            this.numQtyAlloc.bReadOnly = false;
            this.numQtyAlloc.bRequire = false;
            this.numQtyAlloc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numQtyAlloc.ForeColor = System.Drawing.Color.Blue;
            this.numQtyAlloc.KeyFilter = "";
            this.numQtyAlloc.Location = new System.Drawing.Point(121, 96);
            this.numQtyAlloc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numQtyAlloc.Name = "numQtyAlloc";
            this.numQtyAlloc.Scale = 2;
            this.numQtyAlloc.Size = new System.Drawing.Size(160, 20);
            this.numQtyAlloc.TabIndex = 3;
            this.numQtyAlloc.TabStop = false;
            this.numQtyAlloc.Text = "0.00";
            this.numQtyAlloc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numQtyAlloc.UseAutoFilter = false;
            this.numQtyAlloc.Value = 0D;
            // 
            // lblTTien
            // 
            this.lblTTien.AutoEllipsis = true;
            this.lblTTien.AutoSize = true;
            this.lblTTien.BackColor = System.Drawing.Color.Transparent;
            this.lblTTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTTien.ForeColor = System.Drawing.Color.Blue;
            this.lblTTien.Location = new System.Drawing.Point(16, 78);
            this.lblTTien.Name = "lblTTien";
            this.lblTTien.Size = new System.Drawing.Size(93, 13);
            this.lblTTien.TabIndex = 150;
            this.lblTTien.Tag = "";
            this.lblTTien.Text = "Ngân sách tiền";
            this.lblTTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numAmtAlloc
            // 
            this.numAmtAlloc.bEnabled = true;
            this.numAmtAlloc.bFormat = true;
            this.numAmtAlloc.bIsLookup = false;
            this.numAmtAlloc.bReadOnly = false;
            this.numAmtAlloc.bRequire = false;
            this.numAmtAlloc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAmtAlloc.ForeColor = System.Drawing.Color.Blue;
            this.numAmtAlloc.KeyFilter = "";
            this.numAmtAlloc.Location = new System.Drawing.Point(121, 74);
            this.numAmtAlloc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numAmtAlloc.Name = "numAmtAlloc";
            this.numAmtAlloc.Scale = 2;
            this.numAmtAlloc.Size = new System.Drawing.Size(160, 20);
            this.numAmtAlloc.TabIndex = 2;
            this.numAmtAlloc.TabStop = false;
            this.numAmtAlloc.Text = "0.00";
            this.numAmtAlloc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numAmtAlloc.UseAutoFilter = false;
            this.numAmtAlloc.Value = 0D;
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
            this.txtMa_Cbnv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_Cbnv.KeyFilter = "Ma_Cbnv";
            this.txtMa_Cbnv.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtMa_Cbnv.ListFilter = new string[0];
            this.txtMa_Cbnv.Location = new System.Drawing.Point(122, 42);
            this.txtMa_Cbnv.LookupKeyFilter = "";
            this.txtMa_Cbnv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Cbnv.Name = "txtMa_Cbnv";
            this.txtMa_Cbnv.Size = new System.Drawing.Size(159, 20);
            this.txtMa_Cbnv.TabIndex = 152;
            this.txtMa_Cbnv.UseAutoFilter = true;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl1.Location = new System.Drawing.Point(17, 45);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(72, 13);
            this.lblControl1.TabIndex = 153;
            this.lblControl1.Tag = "Ma_Cbnv";
            this.lblControl1.Text = "Mã nhân viên";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numAmtSpent
            // 
            this.numAmtSpent.bEnabled = true;
            this.numAmtSpent.bFormat = true;
            this.numAmtSpent.bIsLookup = false;
            this.numAmtSpent.bReadOnly = false;
            this.numAmtSpent.bRequire = false;
            this.numAmtSpent.Enabled = false;
            this.numAmtSpent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAmtSpent.ForeColor = System.Drawing.Color.Blue;
            this.numAmtSpent.KeyFilter = "";
            this.numAmtSpent.Location = new System.Drawing.Point(300, 75);
            this.numAmtSpent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numAmtSpent.Name = "numAmtSpent";
            this.numAmtSpent.Scale = 2;
            this.numAmtSpent.Size = new System.Drawing.Size(160, 20);
            this.numAmtSpent.TabIndex = 2;
            this.numAmtSpent.TabStop = false;
            this.numAmtSpent.Text = "0.00";
            this.numAmtSpent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numAmtSpent.UseAutoFilter = false;
            this.numAmtSpent.Value = 0D;
            // 
            // numQtySpent
            // 
            this.numQtySpent.bEnabled = true;
            this.numQtySpent.bFormat = true;
            this.numQtySpent.bIsLookup = false;
            this.numQtySpent.bReadOnly = false;
            this.numQtySpent.bRequire = false;
            this.numQtySpent.Enabled = false;
            this.numQtySpent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numQtySpent.ForeColor = System.Drawing.Color.Blue;
            this.numQtySpent.KeyFilter = "";
            this.numQtySpent.Location = new System.Drawing.Point(300, 97);
            this.numQtySpent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numQtySpent.Name = "numQtySpent";
            this.numQtySpent.Scale = 2;
            this.numQtySpent.Size = new System.Drawing.Size(160, 20);
            this.numQtySpent.TabIndex = 3;
            this.numQtySpent.TabStop = false;
            this.numQtySpent.Text = "0.00";
            this.numQtySpent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numQtySpent.UseAutoFilter = false;
            this.numQtySpent.Value = 0D;
            // 
            // frmPromotionBudgetAlloc_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 292);
            this.Name = "frmPromotionBudgetAlloc_Edit";
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
        private Systems.Controls.lblControl lbMa_Vt;
        private Systems.Controls.txtTextLookup txtMa_Ns;
        private Systems.Controls.lblControl lblControl5;
        private Systems.Controls.numControl numQtyAlloc;
        private Systems.Controls.lblControl lblTTien;
        private Systems.Controls.numControl numAmtAlloc;
        private Systems.Controls.txtTextLookup txtMa_Cbnv;
        private Systems.Controls.lblControl lblControl1;
        private Systems.Controls.numControl numQtySpent;
        private Systems.Controls.numControl numAmtSpent;
    }
}