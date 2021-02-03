namespace Epoint.Lists
{
    partial class frmDoiTuongView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoiTuongView));
            this.pnlMa_Vt = new System.Windows.Forms.Panel();
            this.splitDoiTuong = new System.Windows.Forms.SplitContainer();
            this.pnlControl2.SuspendLayout();
            this.splControl1.Panel1.SuspendLayout();
            this.splControl1.Panel2.SuspendLayout();
            this.splControl1.SuspendLayout();
            this.splitDoiTuong.SuspendLayout();
            this.SuspendLayout();
            // 
            // splControl1
            // 
            // 
            // splControl1.Panel1
            // 
            this.splControl1.Panel1.Controls.Add(this.splitDoiTuong);
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
            // splitDoiTuong
            // 
            this.splitDoiTuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDoiTuong.Location = new System.Drawing.Point(0, 0);
            this.splitDoiTuong.Name = "splitDoiTuong";
            this.splitDoiTuong.Size = new System.Drawing.Size(792, 508);
            this.splitDoiTuong.SplitterDistance = 264;
            this.splitDoiTuong.TabIndex = 1;
            // 
            // frmDoiTuongView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 569);
            this.Controls.Add(this.pnlMa_Vt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDoiTuongView";
            this.Object_ID = "LIVATTUNH";
            this.Tag = "frmDmNhDt";
            this.Text = "frmDmNhDt";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.pnlMa_Vt, 0);
            this.Controls.SetChildIndex(this.splControl1, 0);
            this.pnlControl2.ResumeLayout(false);
            this.splControl1.Panel1.ResumeLayout(false);
            this.splControl1.Panel2.ResumeLayout(false);
            this.splControl1.ResumeLayout(false);
            this.splitDoiTuong.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion        

        private System.Windows.Forms.Panel pnlMa_Vt;
        private System.Windows.Forms.SplitContainer splitDoiTuong;
    }
}