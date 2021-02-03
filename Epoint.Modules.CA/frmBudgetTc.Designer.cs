namespace Epoint.Modules.CA
{
	partial class frmBudgetTc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBudgetTc));
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.dgvBudgetTc = new Epoint.Systems.Controls.dgvControl();
            this.lblTTien0 = new Epoint.Systems.Controls.lblControl();
            this.dgvBudgetDetail = new Epoint.Systems.Controls.dgvControl();
            this.btNew = new Epoint.Systems.Customizes.btNew();
            this.btEdit = new Epoint.Systems.Customizes.btEdit();
            this.numTTien_Thu_Nt = new Epoint.Systems.Controls.numControl();
            this.btDelete = new Epoint.Systems.Customizes.btDelete();
            this.numTTien_Chi_Nt = new Epoint.Systems.Controls.numControl();
            this.numTTien_Chi = new Epoint.Systems.Controls.numControl();
            this.numTTien_Thu = new Epoint.Systems.Controls.numControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBudgetTc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBudgetDetail)).BeginInit();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblControl1
            // 
            this.lblControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Enabled = false;
            this.lblControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl1.Location = new System.Drawing.Point(542, 312);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(54, 13);
            this.lblControl1.TabIndex = 113;
            this.lblControl1.Tag = "TTIEN_THU";
            this.lblControl1.Text = "Tiền thu";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvBudgetTc
            // 
            this.dgvBudgetTc.AllowUserToAddRows = false;
            this.dgvBudgetTc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvBudgetTc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBudgetTc.BackgroundColor = System.Drawing.Color.White;
            this.dgvBudgetTc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBudgetTc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBudgetTc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBudgetTc.EnableHeadersVisualStyles = false;
            this.dgvBudgetTc.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvBudgetTc.Location = new System.Drawing.Point(0, 0);
            this.dgvBudgetTc.MultiSelect = false;
            this.dgvBudgetTc.Name = "dgvBudgetTc";
            this.dgvBudgetTc.ReadOnly = true;
            this.dgvBudgetTc.Size = new System.Drawing.Size(839, 201);
            this.dgvBudgetTc.strZone = "";
            this.dgvBudgetTc.TabIndex = 19;
            // 
            // lblTTien0
            // 
            this.lblTTien0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTTien0.AutoEllipsis = true;
            this.lblTTien0.AutoSize = true;
            this.lblTTien0.BackColor = System.Drawing.Color.Transparent;
            this.lblTTien0.Enabled = false;
            this.lblTTien0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTTien0.Location = new System.Drawing.Point(542, 335);
            this.lblTTien0.Name = "lblTTien0";
            this.lblTTien0.Size = new System.Drawing.Size(53, 13);
            this.lblTTien0.TabIndex = 113;
            this.lblTTien0.Tag = "TTIEN_CHI";
            this.lblTTien0.Text = "Tiền chi";
            this.lblTTien0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvBudgetDetail
            // 
            this.dgvBudgetDetail.AllowUserToAddRows = false;
            this.dgvBudgetDetail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvBudgetDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBudgetDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBudgetDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvBudgetDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBudgetDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBudgetDetail.EnableHeadersVisualStyles = false;
            this.dgvBudgetDetail.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvBudgetDetail.Location = new System.Drawing.Point(3, 3);
            this.dgvBudgetDetail.MultiSelect = false;
            this.dgvBudgetDetail.Name = "dgvBudgetDetail";
            this.dgvBudgetDetail.ReadOnly = true;
            this.dgvBudgetDetail.Size = new System.Drawing.Size(833, 303);
            this.dgvBudgetDetail.strZone = "";
            this.dgvBudgetDetail.TabIndex = 19;
            // 
            // btNew
            // 
            this.btNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btNew.Image = ((System.Drawing.Image)(resources.GetObject("btNew.Image")));
            this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNew.Location = new System.Drawing.Point(3, 318);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(65, 31);
            this.btNew.TabIndex = 13;
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
            this.btEdit.Location = new System.Drawing.Point(74, 318);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(65, 31);
            this.btEdit.TabIndex = 14;
            this.btEdit.Tag = "Edit";
            this.btEdit.Text = "&Sửa";
            this.btEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEdit.UseVisualStyleBackColor = true;
            // 
            // numTTien_Thu_Nt
            // 
            this.numTTien_Thu_Nt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numTTien_Thu_Nt.bEnabled = true;
            this.numTTien_Thu_Nt.bFormat = true;
            this.numTTien_Thu_Nt.bIsLookup = false;
            this.numTTien_Thu_Nt.bReadOnly = false;
            this.numTTien_Thu_Nt.bRequire = false;
            this.numTTien_Thu_Nt.Enabled = false;
            this.numTTien_Thu_Nt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTTien_Thu_Nt.KeyFilter = "";
            this.numTTien_Thu_Nt.Location = new System.Drawing.Point(729, 309);
            this.numTTien_Thu_Nt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien_Thu_Nt.Name = "numTTien_Thu_Nt";
            this.numTTien_Thu_Nt.Scale = 2;
            this.numTTien_Thu_Nt.Size = new System.Drawing.Size(99, 20);
            this.numTTien_Thu_Nt.TabIndex = 111;
            this.numTTien_Thu_Nt.TabStop = false;
            this.numTTien_Thu_Nt.Text = "0.00";
            this.numTTien_Thu_Nt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien_Thu_Nt.UseAutoFilter = false;
            this.numTTien_Thu_Nt.Value = 0D;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDelete.Image = ((System.Drawing.Image)(resources.GetObject("btDelete.Image")));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.Location = new System.Drawing.Point(145, 318);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(65, 31);
            this.btDelete.TabIndex = 15;
            this.btDelete.Tag = "Delete";
            this.btDelete.Text = "&Xóa";
            this.btDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // numTTien_Chi_Nt
            // 
            this.numTTien_Chi_Nt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numTTien_Chi_Nt.bEnabled = true;
            this.numTTien_Chi_Nt.bFormat = true;
            this.numTTien_Chi_Nt.bIsLookup = false;
            this.numTTien_Chi_Nt.bReadOnly = false;
            this.numTTien_Chi_Nt.bRequire = false;
            this.numTTien_Chi_Nt.Enabled = false;
            this.numTTien_Chi_Nt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTTien_Chi_Nt.KeyFilter = "";
            this.numTTien_Chi_Nt.Location = new System.Drawing.Point(729, 332);
            this.numTTien_Chi_Nt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien_Chi_Nt.Name = "numTTien_Chi_Nt";
            this.numTTien_Chi_Nt.Scale = 2;
            this.numTTien_Chi_Nt.Size = new System.Drawing.Size(99, 20);
            this.numTTien_Chi_Nt.TabIndex = 111;
            this.numTTien_Chi_Nt.TabStop = false;
            this.numTTien_Chi_Nt.Text = "0.00";
            this.numTTien_Chi_Nt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien_Chi_Nt.UseAutoFilter = false;
            this.numTTien_Chi_Nt.Value = 0D;
            // 
            // numTTien_Chi
            // 
            this.numTTien_Chi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numTTien_Chi.bEnabled = true;
            this.numTTien_Chi.bFormat = true;
            this.numTTien_Chi.bIsLookup = false;
            this.numTTien_Chi.bReadOnly = false;
            this.numTTien_Chi.bRequire = false;
            this.numTTien_Chi.Enabled = false;
            this.numTTien_Chi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTTien_Chi.KeyFilter = "";
            this.numTTien_Chi.Location = new System.Drawing.Point(626, 332);
            this.numTTien_Chi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien_Chi.Name = "numTTien_Chi";
            this.numTTien_Chi.Scale = 0;
            this.numTTien_Chi.Size = new System.Drawing.Size(99, 20);
            this.numTTien_Chi.TabIndex = 112;
            this.numTTien_Chi.TabStop = false;
            this.numTTien_Chi.Text = "0";
            this.numTTien_Chi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien_Chi.UseAutoFilter = false;
            this.numTTien_Chi.Value = 0D;
            // 
            // numTTien_Thu
            // 
            this.numTTien_Thu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numTTien_Thu.bEnabled = true;
            this.numTTien_Thu.bFormat = true;
            this.numTTien_Thu.bIsLookup = false;
            this.numTTien_Thu.bReadOnly = false;
            this.numTTien_Thu.bRequire = false;
            this.numTTien_Thu.Enabled = false;
            this.numTTien_Thu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTTien_Thu.KeyFilter = "";
            this.numTTien_Thu.Location = new System.Drawing.Point(626, 309);
            this.numTTien_Thu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien_Thu.Name = "numTTien_Thu";
            this.numTTien_Thu.Scale = 0;
            this.numTTien_Thu.Size = new System.Drawing.Size(99, 20);
            this.numTTien_Thu.TabIndex = 112;
            this.numTTien_Thu.TabStop = false;
            this.numTTien_Thu.Text = "0";
            this.numTTien_Thu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien_Thu.UseAutoFilter = false;
            this.numTTien_Thu.Value = 0D;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblControl1);
            this.panel1.Controls.Add(this.dgvBudgetDetail);
            this.panel1.Controls.Add(this.btNew);
            this.panel1.Controls.Add(this.numTTien_Thu);
            this.panel1.Controls.Add(this.lblTTien0);
            this.panel1.Controls.Add(this.numTTien_Chi);
            this.panel1.Controls.Add(this.numTTien_Chi_Nt);
            this.panel1.Controls.Add(this.btDelete);
            this.panel1.Controls.Add(this.btEdit);
            this.panel1.Controls.Add(this.numTTien_Thu_Nt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(839, 361);
            this.panel1.TabIndex = 22;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvBudgetTc);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(839, 566);
            this.splitContainer1.SplitterDistance = 201;
            this.splitContainer1.TabIndex = 23;
            // 
            // frmBudgetTc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 566);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBudgetTc";
            this.Text = "CashBudget";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvBudgetTc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBudgetDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private Systems.Controls.lblControl lblControl1;
        private Systems.Controls.dgvControl dgvBudgetTc;
        private Systems.Controls.lblControl lblTTien0;
        private Systems.Controls.dgvControl dgvBudgetDetail;
        private Systems.Customizes.btNew btNew;
        private Systems.Customizes.btEdit btEdit;
        private Systems.Controls.numControl numTTien_Thu_Nt;
        private Systems.Customizes.btDelete btDelete;
        private Systems.Controls.numControl numTTien_Chi_Nt;
        private Systems.Controls.numControl numTTien_Chi;
        private Systems.Controls.numControl numTTien_Thu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;


    }
}