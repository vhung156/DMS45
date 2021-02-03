namespace Epoint.Lists
{
    partial class frmVatTuView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVatTuView));
            this.pnlMa_Vt = new System.Windows.Forms.Panel();
            this.splitVatTu = new System.Windows.Forms.SplitContainer();
            this.pnlControl2.SuspendLayout();
            this.splControl1.Panel1.SuspendLayout();
            this.splControl1.Panel2.SuspendLayout();
            this.splControl1.SuspendLayout();
            this.splitVatTu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splControl1
            // 
            // 
            // splControl1.Panel1
            // 
            this.splControl1.Panel1.Controls.Add(this.splitVatTu);
            this.splControl1.Size = new System.Drawing.Size(792, 569);
            this.splControl1.SplitterDistance = 508;
            // 
            // pnlMa_Vt
            // 
            this.pnlMa_Vt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMa_Vt.Location = new System.Drawing.Point(0, 0);
            this.pnlMa_Vt.Name = "pnlMa_Vt";
            this.pnlMa_Vt.Size = new System.Drawing.Size(792, 569);
            this.pnlMa_Vt.TabIndex = 3;
            // 
            // splitVatTu
            // 
            this.splitVatTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitVatTu.Location = new System.Drawing.Point(0, 0);
            this.splitVatTu.Name = "splitVatTu";
            this.splitVatTu.Size = new System.Drawing.Size(792, 508);
            this.splitVatTu.SplitterDistance = 264;
            this.splitVatTu.TabIndex = 2;
            // 
            // frmVatTuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 569);
            this.Controls.Add(this.pnlMa_Vt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVatTuView";
            this.Object_ID = "LIVATTUNH";
            this.Tag = "frmDmNhVt";
            this.Text = "frmVatTuNh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.pnlMa_Vt, 0);
            this.Controls.SetChildIndex(this.splControl1, 0);
            this.pnlControl2.ResumeLayout(false);
            this.splControl1.Panel1.ResumeLayout(false);
            this.splControl1.Panel2.ResumeLayout(false);
            this.splControl1.ResumeLayout(false);
            this.splitVatTu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion        

        private System.Windows.Forms.Panel pnlMa_Vt;
        private System.Windows.Forms.SplitContainer splitVatTu;        
    }
}