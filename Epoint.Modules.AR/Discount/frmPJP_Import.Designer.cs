namespace Epoint.Modules.AR
{
	partial class frmPJP_Import
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPJP_Import));
            this.grChon = new System.Windows.Forms.GroupBox();
            this.btImport = new Epoint.Systems.Controls.btControl();
            this.btSelectFile = new Epoint.Systems.Controls.btControl();
            this.label2 = new Epoint.Systems.Controls.lblControl();
            this.txtFile_Name = new Epoint.Systems.Controls.txtTextBox();
            this.chkIs_Delete = new System.Windows.Forms.CheckBox();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.grChon.SuspendLayout();
            this.SuspendLayout();
            // 
            // grChon
            // 
            this.grChon.Controls.Add(this.btImport);
            this.grChon.Controls.Add(this.btSelectFile);
            this.grChon.Controls.Add(this.label2);
            this.grChon.Controls.Add(this.txtFile_Name);
            this.grChon.Controls.Add(this.chkIs_Delete);
            this.grChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grChon.ForeColor = System.Drawing.Color.Blue;
            this.grChon.Location = new System.Drawing.Point(12, 12);
            this.grChon.Name = "grChon";
            this.grChon.Size = new System.Drawing.Size(474, 193);
            this.grChon.TabIndex = 131;
            this.grChon.TabStop = false;
            this.grChon.Text = "Import PJP";
            // 
            // btImport
            // 
            this.btImport.Image = ((System.Drawing.Image)(resources.GetObject("btImport.Image")));
            this.btImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btImport.Location = new System.Drawing.Point(245, 106);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(113, 34);
            this.btImport.TabIndex = 135;
            this.btImport.Tag = "";
            this.btImport.Text = "Import";
            this.btImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btImport.UseVisualStyleBackColor = true;
            // 
            // btSelectFile
            // 
            this.btSelectFile.Image = ((System.Drawing.Image)(resources.GetObject("btSelectFile.Image")));
            this.btSelectFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSelectFile.Location = new System.Drawing.Point(97, 109);
            this.btSelectFile.Name = "btSelectFile";
            this.btSelectFile.Size = new System.Drawing.Size(114, 31);
            this.btSelectFile.TabIndex = 132;
            this.btSelectFile.Tag = "";
            this.btSelectFile.Text = "Select File";
            this.btSelectFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSelectFile.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(4, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 134;
            this.label2.Tag = "";
            this.label2.Text = "File Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFile_Name
            // 
            this.txtFile_Name.bEnabled = true;
            this.txtFile_Name.bIsLookup = false;
            this.txtFile_Name.bReadOnly = false;
            this.txtFile_Name.bRequire = false;
            this.txtFile_Name.KeyFilter = "";
            this.txtFile_Name.Location = new System.Drawing.Point(97, 20);
            this.txtFile_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtFile_Name.Name = "txtFile_Name";
            this.txtFile_Name.Size = new System.Drawing.Size(366, 20);
            this.txtFile_Name.TabIndex = 133;
            this.txtFile_Name.UseAutoFilter = false;
            // 
            // chkIs_Delete
            // 
            this.chkIs_Delete.AutoSize = true;
            this.chkIs_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIs_Delete.ForeColor = System.Drawing.Color.Blue;
            this.chkIs_Delete.Location = new System.Drawing.Point(97, 56);
            this.chkIs_Delete.Name = "chkIs_Delete";
            this.chkIs_Delete.Size = new System.Drawing.Size(153, 17);
            this.chkIs_Delete.TabIndex = 131;
            this.chkIs_Delete.Tag = "";
            this.chkIs_Delete.Text = "Xóa tất cả Lịch viếng thăm";
            this.chkIs_Delete.UseVisualStyleBackColor = true;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(294, 225);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 29);
            this.btgAccept.TabIndex = 14;
            // 
            // frmPJP_Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 266);
            this.Controls.Add(this.grChon);
            this.Controls.Add(this.btgAccept);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPJP_Import";
            this.Tag = "frmIn_Ct_Khac";
            this.Text = "frmImport";
            this.grChon.ResumeLayout(false);
            this.grChon.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
        private System.Windows.Forms.GroupBox grChon;
        public System.Windows.Forms.CheckBox chkIs_Delete;
        private Systems.Controls.btControl btImport;
        private Systems.Controls.btControl btSelectFile;
        private Systems.Controls.lblControl label2;
        private Systems.Controls.txtTextBox txtFile_Name;
        private Systems.Customizes.btgAccept btgAccept;
    }
}