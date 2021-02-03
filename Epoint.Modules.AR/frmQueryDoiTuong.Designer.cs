namespace Epoint.Modules.AR
{
	partial class frmQueryDoiTuong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQueryDoiTuong));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboMa_Nh_Dt = new Epoint.Systems.Controls.cboMultiControl();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.cboMa_Kv = new Epoint.Systems.Controls.cboMultiControl();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.cboMa_CbNv = new Epoint.Systems.Controls.cboMultiControl();
            this.label1 = new Epoint.Systems.Controls.lblControl();
            this.dgvDoiTuong = new Epoint.Systems.Controls.dgvControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoiTuong)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cboMa_Nh_Dt);
            this.groupBox1.Controls.Add(this.lblControl2);
            this.groupBox1.Controls.Add(this.cboMa_Kv);
            this.groupBox1.Controls.Add(this.lblControl1);
            this.groupBox1.Controls.Add(this.cboMa_CbNv);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(774, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Truy vấn danh mục đối tượng";
            // 
            // cboMa_Nh_Dt
            // 
            this.cboMa_Nh_Dt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMa_Nh_Dt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboMa_Nh_Dt.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboMa_Nh_Dt.FormattingEnabled = true;
            this.cboMa_Nh_Dt.InitValue = null;
            this.cboMa_Nh_Dt.Location = new System.Drawing.Point(544, 30);
            this.cboMa_Nh_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboMa_Nh_Dt.Name = "cboMa_Nh_Dt";
            this.cboMa_Nh_Dt.Size = new System.Drawing.Size(125, 21);
            this.cboMa_Nh_Dt.strValueList = null;
            this.cboMa_Nh_Dt.TabIndex = 2;
            this.cboMa_Nh_Dt.UpperCase = false;
            this.cboMa_Nh_Dt.UseAutoComplete = false;
            this.cboMa_Nh_Dt.UseBindingValue = false;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(487, 33);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(51, 13);
            this.lblControl2.TabIndex = 1;
            this.lblControl2.Tag = "Ma_Nhom";
            this.lblControl2.Text = "Mã nhóm";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMa_Kv
            // 
            this.cboMa_Kv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMa_Kv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboMa_Kv.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboMa_Kv.FormattingEnabled = true;
            this.cboMa_Kv.InitValue = null;
            this.cboMa_Kv.Location = new System.Drawing.Point(329, 30);
            this.cboMa_Kv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboMa_Kv.Name = "cboMa_Kv";
            this.cboMa_Kv.Size = new System.Drawing.Size(125, 21);
            this.cboMa_Kv.strValueList = null;
            this.cboMa_Kv.TabIndex = 1;
            this.cboMa_Kv.UpperCase = false;
            this.cboMa_Kv.UseAutoComplete = false;
            this.cboMa_Kv.UseBindingValue = false;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(258, 33);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(64, 13);
            this.lblControl1.TabIndex = 1;
            this.lblControl1.Tag = "Ma_Kv";
            this.lblControl1.Text = "Mã khu vực";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMa_CbNv
            // 
            this.cboMa_CbNv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMa_CbNv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboMa_CbNv.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboMa_CbNv.FormattingEnabled = true;
            this.cboMa_CbNv.InitValue = null;
            this.cboMa_CbNv.Location = new System.Drawing.Point(108, 30);
            this.cboMa_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboMa_CbNv.Name = "cboMa_CbNv";
            this.cboMa_CbNv.Size = new System.Drawing.Size(125, 21);
            this.cboMa_CbNv.strValueList = null;
            this.cboMa_CbNv.TabIndex = 0;
            this.cboMa_CbNv.UpperCase = false;
            this.cboMa_CbNv.UseAutoComplete = false;
            this.cboMa_CbNv.UseBindingValue = false;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(28, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Tag = "Ma_CbNv";
            this.label1.Text = "Mã nhân viên";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvDoiTuong
            // 
            this.dgvDoiTuong.AllowUserToAddRows = false;
            this.dgvDoiTuong.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDoiTuong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDoiTuong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDoiTuong.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoiTuong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDoiTuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoiTuong.EnableHeadersVisualStyles = false;
            this.dgvDoiTuong.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvDoiTuong.Location = new System.Drawing.Point(9, 83);
            this.dgvDoiTuong.Margin = new System.Windows.Forms.Padding(0);
            this.dgvDoiTuong.MultiSelect = false;
            this.dgvDoiTuong.Name = "dgvDoiTuong";
            this.dgvDoiTuong.ReadOnly = true;
            this.dgvDoiTuong.Size = new System.Drawing.Size(774, 473);
            this.dgvDoiTuong.strZone = "";
            this.dgvDoiTuong.TabIndex = 1;
            // 
            // frmQueryDoiTuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvDoiTuong);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmQueryDoiTuong";
            this.Tag = "frmQueryDoiTuong";
            this.Text = "frmQueryDoiTuong";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoiTuong)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private Epoint.Systems.Controls.dgvControl dgvDoiTuong;
		private System.Windows.Forms.GroupBox groupBox1;
		private Epoint.Systems.Controls.lblControl label1;
		private Epoint.Systems.Controls.cboMultiControl cboMa_CbNv;
		private Epoint.Systems.Controls.cboMultiControl cboMa_Nh_Dt;
		private Epoint.Systems.Controls.lblControl lblControl2;
		private Epoint.Systems.Controls.cboMultiControl cboMa_Kv;
        private Epoint.Systems.Controls.lblControl lblControl1;
	}
}