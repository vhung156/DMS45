namespace Epoint.Modules
{
	partial class frmDesign_Mau_Ct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesign_Mau_Ct));
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.cboMau_In = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(303, 114);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 29);
            this.btgAccept.TabIndex = 4;
            // 
            // cboMau_In
            // 
            this.cboMau_In.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboMau_In.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMau_In.FormattingEnabled = true;
            this.cboMau_In.Location = new System.Drawing.Point(70, 33);
            this.cboMau_In.Name = "cboMau_In";
            this.cboMau_In.Size = new System.Drawing.Size(278, 21);
            this.cboMau_In.TabIndex = 6;
            this.cboMau_In.Text = "Chọn mẫu in";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboMau_In);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(22, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 78);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "CHON_MAU_IN";
            this.groupBox1.Text = "Chọn mẫu in";
            // 
            // frmDesign_Mau_Ct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 157);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btgAccept);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDesign_Mau_Ct";
            this.Tag = "SUA_MAU";
            this.Text = "Sửa mẫu chứng từ";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private Epoint.Systems.Customizes.btgAccept btgAccept;
        public System.Windows.Forms.ComboBox cboMau_In;
        private System.Windows.Forms.GroupBox groupBox1;
	}
}