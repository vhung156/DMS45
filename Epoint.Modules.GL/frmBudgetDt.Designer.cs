namespace Epoint.Modules.GL
{
	partial class frmBudgetDt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBudgetDt));
            this.dgvBudget = new Epoint.Systems.Controls.dgvControl();
            this.btNew = new Epoint.Systems.Customizes.btNew();
            this.btEdit = new Epoint.Systems.Customizes.btEdit();
            this.btDelete = new Epoint.Systems.Customizes.btDelete();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBudget)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBudget
            // 
            this.dgvBudget.AllowUserToAddRows = false;
            this.dgvBudget.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvBudget.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBudget.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBudget.BackgroundColor = System.Drawing.Color.White;
            this.dgvBudget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBudget.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBudget.EnableHeadersVisualStyles = false;
            this.dgvBudget.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvBudget.Location = new System.Drawing.Point(6, 9);
            this.dgvBudget.MultiSelect = false;
            this.dgvBudget.Name = "dgvBudget";
            this.dgvBudget.ReadOnly = true;
            this.dgvBudget.Size = new System.Drawing.Size(781, 513);
            this.dgvBudget.strZone = "";
            this.dgvBudget.TabIndex = 0;
            // 
            // btNew
            // 
            this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btNew.Image = ((System.Drawing.Image)(resources.GetObject("btNew.Image")));
            this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNew.Location = new System.Drawing.Point(6, 528);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(65, 31);
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
            this.btEdit.Location = new System.Drawing.Point(77, 528);
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
            this.btDelete.Location = new System.Drawing.Point(148, 528);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(65, 31);
            this.btDelete.TabIndex = 22;
            this.btDelete.Tag = "Delete";
            this.btDelete.Text = "&Xóa";
            this.btDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // frmBudgetDt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.dgvBudget);
            this.Controls.Add(this.btNew);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btDelete);
            this.Name = "frmBudgetDt";
            this.Text = "CashBudget";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvBudget)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private Epoint.Systems.Controls.dgvControl dgvBudget;
		private Epoint.Systems.Customizes.btNew btNew;
		private Epoint.Systems.Customizes.btEdit btEdit;
        private Epoint.Systems.Customizes.btDelete btDelete;


	}
}