namespace Epoint.Lists
{
	partial class frmView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlControl2 = new Epoint.Systems.Controls.pnlControl();
            this.btImport = new Epoint.Systems.Customizes.btFilter();
            this.btRefresh = new Epoint.Systems.Customizes.btPreview();
            this.btExport = new Epoint.Systems.Customizes.btFilter();
            this.splControl1 = new Epoint.Systems.Controls.splControl();
            this.dgvExport = new Epoint.Systems.Controls.dgvControl();
            this.pnlControl2.SuspendLayout();
            this.splControl1.Panel1.SuspendLayout();
            this.splControl1.Panel2.SuspendLayout();
            this.splControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExport)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControl2
            // 
            this.pnlControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlControl2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlControl2.Controls.Add(this.btImport);
            this.pnlControl2.Controls.Add(this.btRefresh);
            this.pnlControl2.Controls.Add(this.btExport);
            this.pnlControl2.Location = new System.Drawing.Point(13, -1);
            this.pnlControl2.Name = "pnlControl2";
            this.pnlControl2.Size = new System.Drawing.Size(246, 56);
            this.pnlControl2.TabIndex = 12;
            // 
            // btImport
            // 
            this.btImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImport.Image = ((System.Drawing.Image)(resources.GetObject("btImport.Image")));
            this.btImport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btImport.Location = new System.Drawing.Point(166, 3);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(78, 51);
            this.btImport.TabIndex = 15;
            this.btImport.Tag = "Import";
            this.btImport.Text = "&Import";
            this.btImport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btImport.UseVisualStyleBackColor = true;
            // 
            // btRefresh
            // 
            this.btRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btRefresh.Image")));
            this.btRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btRefresh.Location = new System.Drawing.Point(2, 3);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(78, 51);
            this.btRefresh.TabIndex = 14;
            this.btRefresh.Tag = "Refresh";
            this.btRefresh.Text = "Refresh";
            this.btRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // btExport
            // 
            this.btExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExport.Image = ((System.Drawing.Image)(resources.GetObject("btExport.Image")));
            this.btExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btExport.Location = new System.Drawing.Point(84, 3);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(78, 51);
            this.btExport.TabIndex = 10;
            this.btExport.Tag = "";
            this.btExport.Text = "&Export";
            this.btExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btExport.UseVisualStyleBackColor = true;
            // 
            // splControl1
            // 
            this.splControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splControl1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splControl1.IsSplitterFixed = true;
            this.splControl1.Location = new System.Drawing.Point(0, 0);
            this.splControl1.Name = "splControl1";
            this.splControl1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splControl1.Panel1
            // 
            this.splControl1.Panel1.Controls.Add(this.dgvExport);
            // 
            // splControl1.Panel2
            // 
            this.splControl1.Panel2.Controls.Add(this.pnlControl2);
            this.splControl1.Size = new System.Drawing.Size(792, 566);
            this.splControl1.SplitterDistance = 505;
            this.splControl1.TabIndex = 13;
            // 
            // dgvExport
            // 
            this.dgvExport.AllowUserToAddRows = false;
            this.dgvExport.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvExport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExport.BackgroundColor = System.Drawing.Color.White;
            this.dgvExport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvExport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExport.EnableHeadersVisualStyles = false;
            this.dgvExport.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvExport.Location = new System.Drawing.Point(540, 343);
            this.dgvExport.MultiSelect = false;
            this.dgvExport.Name = "dgvExport";
            this.dgvExport.ReadOnly = true;
            this.dgvExport.Size = new System.Drawing.Size(240, 150);
            this.dgvExport.strZone = "";
            this.dgvExport.TabIndex = 0;
            this.dgvExport.Visible = false;
            // 
            // frmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.splControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmView";
            this.Text = "frmView";
            this.pnlControl2.ResumeLayout(false);
            this.splControl1.Panel1.ResumeLayout(false);
            this.splControl1.Panel2.ResumeLayout(false);
            this.splControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExport)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        public Systems.Controls.pnlControl pnlControl2;
        public Systems.Controls.dgvControl dgvExport;
        protected Systems.Controls.splControl splControl1;
        protected Systems.Customizes.btFilter btImport;
        protected Systems.Customizes.btPreview btRefresh;
        protected Systems.Customizes.btFilter btExport;


    }
}