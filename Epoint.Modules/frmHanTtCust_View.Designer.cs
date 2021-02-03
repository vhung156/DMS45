namespace Epoint.Modules
{
    partial class frmHanTtCust_View
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHanTt_View));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabChiTietThanhToan = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvHanTt0 = new Epoint.Systems.Controls.dgvControl();
            this.label2 = new System.Windows.Forms.Label();
            this.numTTien_CLTG = new Epoint.Systems.Controls.numControl();
            this.label1 = new System.Windows.Forms.Label();
            this.numTTien_Tt_Nt = new Epoint.Systems.Controls.numControl();
            this.numTTien_Tt = new Epoint.Systems.Controls.numControl();
            this.btSave = new Epoint.Systems.Controls.btControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvHanTt = new Epoint.Systems.Controls.dgvControl();
            this.tabChiTietThanhToan.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHanTt0)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHanTt)).BeginInit();
            this.SuspendLayout();
            // 
            // tabChiTietThanhToan
            // 
            this.tabChiTietThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabChiTietThanhToan.Controls.Add(this.tabPage1);
            this.tabChiTietThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChiTietThanhToan.Location = new System.Drawing.Point(4, 256);
            this.tabChiTietThanhToan.Name = "tabChiTietThanhToan";
            this.tabChiTietThanhToan.SelectedIndex = 0;
            this.tabChiTietThanhToan.Size = new System.Drawing.Size(784, 245);
            this.tabChiTietThanhToan.TabIndex = 1;
            this.tabChiTietThanhToan.Tag = "HanTT0";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvHanTt0);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 219);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Tag = "HanTt0";
            this.tabPage1.Text = "Chứng từ được thanh toán";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvHanTt0
            // 
            this.dgvHanTt0.AllowUserToAddRows = false;
            this.dgvHanTt0.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvHanTt0.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHanTt0.BackgroundColor = System.Drawing.Color.White;
            this.dgvHanTt0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvHanTt0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHanTt0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHanTt0.EnableHeadersVisualStyles = false;
            this.dgvHanTt0.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvHanTt0.Location = new System.Drawing.Point(3, 3);
            this.dgvHanTt0.Margin = new System.Windows.Forms.Padding(1);
            this.dgvHanTt0.MultiSelect = false;
            this.dgvHanTt0.Name = "dgvHanTt0";
            this.dgvHanTt0.ReadOnly = true;
            this.dgvHanTt0.Size = new System.Drawing.Size(770, 213);
            this.dgvHanTt0.strZone = "";
            this.dgvHanTt0.TabIndex = 66;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(586, 537);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Tag = "";
            this.label2.Text = "Tiền CLTG";
            // 
            // numTTien_CLTG
            // 
            this.numTTien_CLTG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numTTien_CLTG.bEnabled = true;
            this.numTTien_CLTG.bFormat = true;
            this.numTTien_CLTG.bIsLookup = false;
            this.numTTien_CLTG.bReadOnly = false;
            this.numTTien_CLTG.bRequire = false;
            this.numTTien_CLTG.Enabled = false;
            this.numTTien_CLTG.KeyFilter = "";
            this.numTTien_CLTG.Location = new System.Drawing.Point(659, 534);
            this.numTTien_CLTG.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien_CLTG.Name = "numTTien_CLTG";
            this.numTTien_CLTG.Scale = 0;
            this.numTTien_CLTG.Size = new System.Drawing.Size(121, 20);
            this.numTTien_CLTG.TabIndex = 4;
            this.numTTien_CLTG.Text = "0";
            this.numTTien_CLTG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien_CLTG.UseAutoFilter = false;
            this.numTTien_CLTG.Value = 0D;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(461, 515);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Tag = "Tong_Cong";
            this.label1.Text = "Tổng cộng";
            // 
            // numTTien_Tt_Nt
            // 
            this.numTTien_Tt_Nt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numTTien_Tt_Nt.bEnabled = true;
            this.numTTien_Tt_Nt.bFormat = true;
            this.numTTien_Tt_Nt.bIsLookup = false;
            this.numTTien_Tt_Nt.bReadOnly = false;
            this.numTTien_Tt_Nt.bRequire = false;
            this.numTTien_Tt_Nt.Enabled = false;
            this.numTTien_Tt_Nt.KeyFilter = "";
            this.numTTien_Tt_Nt.Location = new System.Drawing.Point(534, 512);
            this.numTTien_Tt_Nt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien_Tt_Nt.Name = "numTTien_Tt_Nt";
            this.numTTien_Tt_Nt.Scale = 2;
            this.numTTien_Tt_Nt.Size = new System.Drawing.Size(121, 20);
            this.numTTien_Tt_Nt.TabIndex = 2;
            this.numTTien_Tt_Nt.Text = "0.00";
            this.numTTien_Tt_Nt.UseAutoFilter = false;
            this.numTTien_Tt_Nt.Value = 0D;
            // 
            // numTTien_Tt
            // 
            this.numTTien_Tt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numTTien_Tt.bEnabled = true;
            this.numTTien_Tt.bFormat = true;
            this.numTTien_Tt.bIsLookup = false;
            this.numTTien_Tt.bReadOnly = false;
            this.numTTien_Tt.bRequire = false;
            this.numTTien_Tt.Enabled = false;
            this.numTTien_Tt.KeyFilter = "";
            this.numTTien_Tt.Location = new System.Drawing.Point(659, 512);
            this.numTTien_Tt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien_Tt.Name = "numTTien_Tt";
            this.numTTien_Tt.Scale = 0;
            this.numTTien_Tt.Size = new System.Drawing.Size(121, 20);
            this.numTTien_Tt.TabIndex = 2;
            this.numTTien_Tt.Text = "0";
            this.numTTien_Tt.UseAutoFilter = false;
            this.numTTien_Tt.Value = 0D;
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSave.Enabled = false;
            this.btSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btSave.Image = ((System.Drawing.Image)(resources.GetObject("btSave.Image")));
            this.btSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSave.Location = new System.Drawing.Point(24, 514);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(65, 31);
            this.btSave.TabIndex = 1;
            this.btSave.Tag = "Save";
            this.btSave.Text = "Lưu";
            this.btSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(4, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(783, 241);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Tag = "Payment_Voucher";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvHanTt);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(775, 215);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Tag = "HanTt";
            this.tabPage2.Text = "Chứng từ thanh toán";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvHanTt
            // 
            this.dgvHanTt.AllowUserToAddRows = false;
            this.dgvHanTt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvHanTt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHanTt.BackgroundColor = System.Drawing.Color.White;
            this.dgvHanTt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvHanTt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHanTt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHanTt.EnableHeadersVisualStyles = false;
            this.dgvHanTt.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvHanTt.Location = new System.Drawing.Point(3, 3);
            this.dgvHanTt.Margin = new System.Windows.Forms.Padding(1);
            this.dgvHanTt.MultiSelect = false;
            this.dgvHanTt.Name = "dgvHanTt";
            this.dgvHanTt.ReadOnly = true;
            this.dgvHanTt.Size = new System.Drawing.Size(769, 209);
            this.dgvHanTt.strZone = "";
            this.dgvHanTt.TabIndex = 65;
            // 
            // frmHanTt_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabChiTietThanhToan);
            this.Controls.Add(this.numTTien_CLTG);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.numTTien_Tt_Nt);
            this.Controls.Add(this.numTTien_Tt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHanTt_View";
            this.Text = "frmHanTt_View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabChiTietThanhToan.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHanTt0)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHanTt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabChiTietThanhToan;
        private System.Windows.Forms.TabPage tabPage1;
		private Epoint.Systems.Controls.btControl btSave;
		private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
		private Epoint.Systems.Controls.numControl numTTien_Tt;
		private System.Windows.Forms.Label label1;
		private Epoint.Systems.Controls.numControl numTTien_Tt_Nt;
		private System.Windows.Forms.Label label2;
		private Epoint.Systems.Controls.numControl numTTien_CLTG;
        private Systems.Controls.dgvControl dgvHanTt;
        private Systems.Controls.dgvControl dgvHanTt0;
	}
}