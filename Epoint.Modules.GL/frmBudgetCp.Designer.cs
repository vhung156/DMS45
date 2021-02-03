namespace Epoint.Modules.GL
{
	partial class frmBudgetCp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBudgetCp));
            this.dgvBudgetCp = new Epoint.Systems.Controls.dgvControl();
            this.btNew = new Epoint.Systems.Customizes.btNew();
            this.btEdit = new Epoint.Systems.Customizes.btEdit();
            this.btDelete = new Epoint.Systems.Customizes.btDelete();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBudgetCp)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBudgetCp
            // 
            this.dgvBudgetCp.AllowUserToAddRows = false;
            this.dgvBudgetCp.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvBudgetCp.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBudgetCp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBudgetCp.BackgroundColor = System.Drawing.Color.White;
            this.dgvBudgetCp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBudgetCp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBudgetCp.EnableHeadersVisualStyles = false;
            this.dgvBudgetCp.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvBudgetCp.Location = new System.Drawing.Point(6, 9);
            this.dgvBudgetCp.MultiSelect = false;
            this.dgvBudgetCp.Name = "dgvBudgetCp";
            this.dgvBudgetCp.ReadOnly = true;
            this.dgvBudgetCp.Size = new System.Drawing.Size(781, 513);
            this.dgvBudgetCp.strZone = "";
            this.dgvBudgetCp.TabIndex = 0;
            // 
            // btNew
            // 
            this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btNew.Image = ((System.Drawing.Image)(resources.GetObject("btNew.Image")));
            this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNew.Location = new System.Drawing.Point(6, 528);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(67, 31);
            this.btNew.TabIndex = 20;
            this.btNew.Tag = "New";
            this.btNew.Text = "&Thêm";
            this.btNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btEdit.Image = ((System.Drawing.Image)(resources.GetObject("btEdit.Image")));
            this.btEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEdit.Location = new System.Drawing.Point(79, 528);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(65, 31);
            this.btEdit.TabIndex = 21;
            this.btEdit.Tag = "Edit";
            this.btEdit.Text = "&Sửa";
            this.btEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEdit.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDelete.Image = ((System.Drawing.Image)(resources.GetObject("btDelete.Image")));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.Location = new System.Drawing.Point(149, 528);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(67, 31);
            this.btDelete.TabIndex = 22;
            this.btDelete.Tag = "Delete";
            this.btDelete.Text = "&Xóa";
            this.btDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // frmBudgetCp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.dgvBudgetCp);
            this.Controls.Add(this.btNew);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btDelete);
            this.Name = "frmBudgetCp";
            this.Tag = "CashBudget";
            this.Text = "CashBudget";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvBudgetCp)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private Epoint.Systems.Controls.dgvControl dgvBudgetCp;
		private Epoint.Systems.Customizes.btNew btNew;
		private Epoint.Systems.Customizes.btEdit btEdit;
        private Epoint.Systems.Customizes.btDelete btDelete;


	}
}