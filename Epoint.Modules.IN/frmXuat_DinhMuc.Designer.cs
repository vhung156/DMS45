namespace Epoint.Modules.IN
{
	partial class frmXuat_DinhMuc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXuat_DinhMuc));
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.numSo_Luong = new Epoint.Systems.Controls.numControl();
            this.lblSo_Luong = new Epoint.Systems.Controls.lblControl();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Sp = new Epoint.Systems.Controls.lbtControl();
            this.dgvDinhMuc = new Epoint.Systems.Controls.dgvControl();
            this.btRefresh = new Epoint.Systems.Controls.btControl();
            this.chkDelete_Dm = new System.Windows.Forms.CheckBox();
            this.txtMa_Sp = new Epoint.Systems.Controls.txtTextLookup();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDinhMuc)).BeginInit();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(616, 412);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 29);
            this.btgAccept.TabIndex = 3;
            // 
            // numSo_Luong
            // 
            this.numSo_Luong.bEnabled = true;
            this.numSo_Luong.bFormat = true;
            this.numSo_Luong.bIsLookup = false;
            this.numSo_Luong.bReadOnly = false;
            this.numSo_Luong.bRequire = false;
            this.numSo_Luong.KeyFilter = "";
            this.numSo_Luong.Location = new System.Drawing.Point(103, 45);
            this.numSo_Luong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numSo_Luong.Name = "numSo_Luong";
            this.numSo_Luong.Scale = 2;
            this.numSo_Luong.Size = new System.Drawing.Size(98, 20);
            this.numSo_Luong.TabIndex = 1;
            this.numSo_Luong.Text = "0.00";
            this.numSo_Luong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSo_Luong.UseAutoFilter = false;
            this.numSo_Luong.Value = 0D;
            // 
            // lblSo_Luong
            // 
            this.lblSo_Luong.AutoEllipsis = true;
            this.lblSo_Luong.AutoSize = true;
            this.lblSo_Luong.BackColor = System.Drawing.Color.Transparent;
            this.lblSo_Luong.Location = new System.Drawing.Point(24, 49);
            this.lblSo_Luong.Name = "lblSo_Luong";
            this.lblSo_Luong.Size = new System.Drawing.Size(49, 13);
            this.lblSo_Luong.TabIndex = 4;
            this.lblSo_Luong.Tag = "So_Luong";
            this.lblSo_Luong.Text = "Số lượng";
            this.lblSo_Luong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(24, 19);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(71, 13);
            this.lblControl1.TabIndex = 62;
            this.lblControl1.Tag = "Ma_Sp";
            this.lblControl1.Text = "Mã sản phẩm";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Sp
            // 
            this.lbtTen_Sp.AutoEllipsis = true;
            this.lbtTen_Sp.AutoSize = true;
            this.lbtTen_Sp.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_Sp.Location = new System.Drawing.Point(206, 20);
            this.lbtTen_Sp.Name = "lbtTen_Sp";
            this.lbtTen_Sp.Size = new System.Drawing.Size(75, 13);
            this.lbtTen_Sp.TabIndex = 63;
            this.lbtTen_Sp.Tag = "Ten_Sp";
            this.lbtTen_Sp.Text = "Tên sản phẩm";
            this.lbtTen_Sp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvDinhMuc
            // 
            this.dgvDinhMuc.AllowUserToAddRows = false;
            this.dgvDinhMuc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDinhMuc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDinhMuc.BackgroundColor = System.Drawing.Color.White;
            this.dgvDinhMuc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDinhMuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDinhMuc.EnableHeadersVisualStyles = false;
            this.dgvDinhMuc.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvDinhMuc.Location = new System.Drawing.Point(3, 77);
            this.dgvDinhMuc.MultiSelect = false;
            this.dgvDinhMuc.Name = "dgvDinhMuc";
            this.dgvDinhMuc.ReadOnly = true;
            this.dgvDinhMuc.Size = new System.Drawing.Size(803, 325);
            this.dgvDinhMuc.strZone = "";
            this.dgvDinhMuc.TabIndex = 64;
            // 
            // btRefresh
            // 
            this.btRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btRefresh.Image")));
            this.btRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRefresh.Location = new System.Drawing.Point(209, 41);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(89, 27);
            this.btRefresh.TabIndex = 2;
            this.btRefresh.Tag = "Refresh";
            this.btRefresh.Text = "F5 - &Refresh";
            this.btRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // chkDelete_Dm
            // 
            this.chkDelete_Dm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDelete_Dm.AutoSize = true;
            this.chkDelete_Dm.ForeColor = System.Drawing.Color.Blue;
            this.chkDelete_Dm.Location = new System.Drawing.Point(20, 415);
            this.chkDelete_Dm.Name = "chkDelete_Dm";
            this.chkDelete_Dm.Size = new System.Drawing.Size(236, 17);
            this.chkDelete_Dm.TabIndex = 66;
            this.chkDelete_Dm.Tag = "DELETE_DM";
            this.chkDelete_Dm.Text = "Xóa các dòng dữ liệu hiện tại trong chứng từ";
            this.chkDelete_Dm.UseVisualStyleBackColor = true;
            // 
            // txtMa_Sp
            // 
            this.txtMa_Sp.bEnabled = true;
            this.txtMa_Sp.bIsLookup = false;
            this.txtMa_Sp.bReadOnly = false;
            this.txtMa_Sp.bRequire = false;
            this.txtMa_Sp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Sp.KeyFilter = "Ma_Sp";
            this.txtMa_Sp.Location = new System.Drawing.Point(103, 18);
            this.txtMa_Sp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Sp.Name = "txtMa_Sp";
            this.txtMa_Sp.Size = new System.Drawing.Size(98, 20);
            this.txtMa_Sp.TabIndex = 0;
            this.txtMa_Sp.UseAutoFilter = true;
            // 
            // frmXuat_DinhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 449);
            this.Controls.Add(this.txtMa_Sp);
            this.Controls.Add(this.chkDelete_Dm);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.dgvDinhMuc);
            this.Controls.Add(this.lbtTen_Sp);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.numSo_Luong);
            this.Controls.Add(this.lblSo_Luong);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmXuat_DinhMuc";
            this.Tag = "frmXuat_DinhMuc";
            this.Text = "frmXuat_DinhMuc";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDinhMuc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Customizes.btgAccept btgAccept;
		private Epoint.Systems.Controls.numControl numSo_Luong;
        private Epoint.Systems.Controls.lblControl lblSo_Luong;
		private Epoint.Systems.Controls.lblControl lblControl1;
		private Epoint.Systems.Controls.lbtControl lbtTen_Sp;
		private Epoint.Systems.Controls.dgvControl dgvDinhMuc;
		private Epoint.Systems.Controls.btControl btRefresh;
        private System.Windows.Forms.CheckBox chkDelete_Dm;
        private Systems.Controls.txtTextLookup txtMa_Sp;
	}
}