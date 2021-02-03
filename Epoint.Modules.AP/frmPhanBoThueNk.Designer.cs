namespace Epoint.Modules.AP
{
    partial class frmPhanBoThueNk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhanBoThueNk));
            this.lblTTien5 = new Epoint.Systems.Controls.lblControl();
            this.numTTien5 = new Epoint.Systems.Controls.numControl();
            this.lblLoai_Pb = new Epoint.Systems.Controls.lblControl();
            this.txtLoai_Pb = new Epoint.Systems.Controls.txtEnum();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.SuspendLayout();
            // 
            // lblTTien5
            // 
            this.lblTTien5.AutoEllipsis = true;
            this.lblTTien5.AutoSize = true;
            this.lblTTien5.BackColor = System.Drawing.Color.Transparent;
            this.lblTTien5.Location = new System.Drawing.Point(21, 30);
            this.lblTTien5.Name = "lblTTien5";
            this.lblTTien5.Size = new System.Drawing.Size(70, 13);
            this.lblTTien5.TabIndex = 0;
            this.lblTTien5.Text = "Tiền phân bổ";
            this.lblTTien5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTTien5
            // 
            this.numTTien5.bEnabled = true;
            this.numTTien5.bFormat = true;
            this.numTTien5.bIsLookup = false;
            this.numTTien5.bReadOnly = false;
            this.numTTien5.bRequire = false;
            this.numTTien5.KeyFilter = "";
            this.numTTien5.Location = new System.Drawing.Point(126, 27);
            this.numTTien5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTTien5.Name = "numTTien5";
            this.numTTien5.Scale = 0;
            this.numTTien5.Size = new System.Drawing.Size(118, 20);
            this.numTTien5.TabIndex = 0;
            this.numTTien5.Text = "0";
            this.numTTien5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTTien5.UseAutoFilter = false;
            this.numTTien5.Value = 0D;
            // 
            // lblLoai_Pb
            // 
            this.lblLoai_Pb.AutoEllipsis = true;
            this.lblLoai_Pb.AutoSize = true;
            this.lblLoai_Pb.BackColor = System.Drawing.Color.Transparent;
            this.lblLoai_Pb.Location = new System.Drawing.Point(21, 53);
            this.lblLoai_Pb.Name = "lblLoai_Pb";
            this.lblLoai_Pb.Size = new System.Drawing.Size(96, 13);
            this.lblLoai_Pb.TabIndex = 2;
            this.lblLoai_Pb.Text = "Phân bổ TNK theo";
            this.lblLoai_Pb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLoai_Pb
            // 
            this.txtLoai_Pb.bEnabled = true;
            this.txtLoai_Pb.bIsLookup = false;
            this.txtLoai_Pb.bReadOnly = false;
            this.txtLoai_Pb.bRequire = false;
            this.txtLoai_Pb.InputMask = "1,2";
            this.txtLoai_Pb.KeyFilter = "";
            this.txtLoai_Pb.Location = new System.Drawing.Point(126, 50);
            this.txtLoai_Pb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtLoai_Pb.Name = "txtLoai_Pb";
            this.txtLoai_Pb.Size = new System.Drawing.Size(27, 20);
            this.txtLoai_Pb.TabIndex = 1;
            this.txtLoai_Pb.Text = "1";
            this.txtLoai_Pb.UseAutoFilter = false;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.ForeColor = System.Drawing.Color.Blue;
            this.lblControl1.Location = new System.Drawing.Point(162, 53);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(100, 13);
            this.lblControl1.TabIndex = 4;
            this.lblControl1.Text = "1-Giá trị, 2-Số lượng";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(164, 102);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 29);
            this.btgAccept.TabIndex = 2;
            // 
            // frmPhanBoThueNk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 143);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.txtLoai_Pb);
            this.Controls.Add(this.lblLoai_Pb);
            this.Controls.Add(this.numTTien5);
            this.Controls.Add(this.lblTTien5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPhanBoThueNk";
            this.Tag = "frmPhanBoThueNk";
            this.Text = "frmPhanBoThueNk";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Epoint.Systems.Controls.lblControl lblTTien5;
        private Epoint.Systems.Controls.lblControl lblLoai_Pb;
        private Epoint.Systems.Controls.lblControl lblControl1;
		private Epoint.Systems.Customizes.btgAccept btgAccept;
        public Epoint.Systems.Controls.numControl numTTien5;
        public Epoint.Systems.Controls.txtEnum txtLoai_Pb;
    }
}