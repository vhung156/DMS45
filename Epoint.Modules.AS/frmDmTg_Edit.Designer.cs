namespace Epoint.Modules.AS
{
	partial class frmDmTg_Edit
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
            this.txtTen_Tg = new Epoint.Systems.Controls.txtTextBox();
            this.txtMa_Tg = new Epoint.Systems.Controls.txtTextBox();
            this.lblTen_Tg = new Epoint.Systems.Controls.lblControl();
            this.lbMa_Tg = new Epoint.Systems.Controls.lblControl();
            this.lbtLoai_Ps = new Epoint.Systems.Controls.lblControl();
            this.lblLoai_Ps = new Epoint.Systems.Controls.lblControl();
            this.txtLoai_Ps = new Epoint.Systems.Controls.txtEnum();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.SuspendLayout();
            // 
            // txtTen_Tg
            // 
            this.txtTen_Tg.bEnabled = true;
            this.txtTen_Tg.bIsLookup = false;
            this.txtTen_Tg.bReadOnly = false;
            this.txtTen_Tg.bRequire = false;
            this.txtTen_Tg.KeyFilter = "";
            this.txtTen_Tg.Location = new System.Drawing.Point(165, 59);
            this.txtTen_Tg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Tg.MaxLength = 100;
            this.txtTen_Tg.Name = "txtTen_Tg";
            this.txtTen_Tg.Size = new System.Drawing.Size(335, 20);
            this.txtTen_Tg.TabIndex = 2;
            this.txtTen_Tg.UseAutoFilter = false;
            // 
            // txtMa_Tg
            // 
            this.txtMa_Tg.bEnabled = true;
            this.txtMa_Tg.bIsLookup = false;
            this.txtMa_Tg.bReadOnly = false;
            this.txtMa_Tg.bRequire = false;
            this.txtMa_Tg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Tg.KeyFilter = "";
            this.txtMa_Tg.Location = new System.Drawing.Point(165, 36);
            this.txtMa_Tg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Tg.MaxLength = 20;
            this.txtMa_Tg.Name = "txtMa_Tg";
            this.txtMa_Tg.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Tg.TabIndex = 1;
            this.txtMa_Tg.UseAutoFilter = false;
            // 
            // lblTen_Tg
            // 
            this.lblTen_Tg.AutoEllipsis = true;
            this.lblTen_Tg.AutoSize = true;
            this.lblTen_Tg.BackColor = System.Drawing.Color.Transparent;
            this.lblTen_Tg.Location = new System.Drawing.Point(58, 60);
            this.lblTen_Tg.Name = "lblTen_Tg";
            this.lblTen_Tg.Size = new System.Drawing.Size(75, 13);
            this.lblTen_Tg.TabIndex = 15;
            this.lblTen_Tg.Tag = "Ten_Tg";
            this.lblTen_Tg.Text = "Tên tăng giảm";
            this.lblTen_Tg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Tg
            // 
            this.lbMa_Tg.AutoEllipsis = true;
            this.lbMa_Tg.AutoSize = true;
            this.lbMa_Tg.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_Tg.Location = new System.Drawing.Point(58, 36);
            this.lbMa_Tg.Name = "lbMa_Tg";
            this.lbMa_Tg.Size = new System.Drawing.Size(71, 13);
            this.lbMa_Tg.TabIndex = 16;
            this.lbMa_Tg.Tag = "Ma_Tg";
            this.lbMa_Tg.Text = "Mã tăng giảm";
            this.lbMa_Tg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtLoai_Ps
            // 
            this.lbtLoai_Ps.AutoEllipsis = true;
            this.lbtLoai_Ps.AutoSize = true;
            this.lbtLoai_Ps.BackColor = System.Drawing.Color.Transparent;
            this.lbtLoai_Ps.ForeColor = System.Drawing.Color.Blue;
            this.lbtLoai_Ps.Location = new System.Drawing.Point(208, 85);
            this.lbtLoai_Ps.Name = "lbtLoai_Ps";
            this.lbtLoai_Ps.Size = new System.Drawing.Size(80, 13);
            this.lbtLoai_Ps.TabIndex = 53;
            this.lbtLoai_Ps.Text = "1-Tăng, 2-Giảm";
            this.lbtLoai_Ps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLoai_Ps
            // 
            this.lblLoai_Ps.AutoEllipsis = true;
            this.lblLoai_Ps.AutoSize = true;
            this.lblLoai_Ps.BackColor = System.Drawing.Color.Transparent;
            this.lblLoai_Ps.Location = new System.Drawing.Point(58, 83);
            this.lblLoai_Ps.Name = "lblLoai_Ps";
            this.lblLoai_Ps.Size = new System.Drawing.Size(61, 13);
            this.lblLoai_Ps.TabIndex = 52;
            this.lblLoai_Ps.Tag = "Loai_Ps";
            this.lblLoai_Ps.Text = "Loại chi tiết";
            this.lblLoai_Ps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLoai_Ps
            // 
            this.txtLoai_Ps.bEnabled = true;
            this.txtLoai_Ps.bIsLookup = false;
            this.txtLoai_Ps.bReadOnly = false;
            this.txtLoai_Ps.bRequire = false;
            this.txtLoai_Ps.InputMask = "1,2";
            this.txtLoai_Ps.KeyFilter = "";
            this.txtLoai_Ps.Location = new System.Drawing.Point(165, 82);
            this.txtLoai_Ps.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtLoai_Ps.Name = "txtLoai_Ps";
            this.txtLoai_Ps.Size = new System.Drawing.Size(29, 20);
            this.txtLoai_Ps.TabIndex = 51;
            this.txtLoai_Ps.Text = "1";
            this.txtLoai_Ps.UseAutoFilter = false;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(358, 141);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 29);
            this.btgAccept.TabIndex = 54;
            // 
            // frmDmTg_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 182);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.lbtLoai_Ps);
            this.Controls.Add(this.lblLoai_Ps);
            this.Controls.Add(this.txtLoai_Ps);
            this.Controls.Add(this.txtTen_Tg);
            this.Controls.Add(this.txtMa_Tg);
            this.Controls.Add(this.lblTen_Tg);
            this.Controls.Add(this.lbMa_Tg);
            this.Name = "frmDmTg_Edit";
            this.Tag = "frmDmTg_Edit";
            this.Text = "frmDmTg_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.txtTextBox txtTen_Tg;
		private Epoint.Systems.Controls.txtTextBox txtMa_Tg;
		private Epoint.Systems.Controls.lblControl lblTen_Tg;
        private Epoint.Systems.Controls.lblControl lbMa_Tg;
        private Epoint.Systems.Controls.lblControl lbtLoai_Ps;
        private Epoint.Systems.Controls.lblControl lblLoai_Ps;
        private Epoint.Systems.Controls.txtEnum txtLoai_Ps;
        private Epoint.Systems.Customizes.btgAccept btgAccept;
	}
}