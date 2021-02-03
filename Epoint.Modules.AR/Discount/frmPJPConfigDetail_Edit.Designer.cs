namespace Epoint.Modules.AR
{
    partial class frmPJPConfigDetail_Edit
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
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.lbMa_Vt = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Dt = new Epoint.Systems.Controls.txtTextLookup();
            this.txtMa_PJP = new Epoint.Systems.Controls.txtTextLookup();
            this.grbVisitOp = new System.Windows.Forms.GroupBox();
            this.chkMon = new System.Windows.Forms.CheckBox();
            this.chkSun = new System.Windows.Forms.CheckBox();
            this.chkTue = new System.Windows.Forms.CheckBox();
            this.chkWed = new System.Windows.Forms.CheckBox();
            this.chkSat = new System.Windows.Forms.CheckBox();
            this.chkThu = new System.Windows.Forms.CheckBox();
            this.chkFri = new System.Windows.Forms.CheckBox();
            this.cboTan_Suat = new Epoint.Systems.Controls.cboControl();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.numStt = new Epoint.Systems.Controls.numControl();
            this.lblControl3 = new Epoint.Systems.Controls.lblControl();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            this.grbVisitOp.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(428, 314);
            this.btgAccept.Size = new System.Drawing.Size(181, 29);
            this.btgAccept.TabIndex = 1;
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(600, 298);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.numStt);
            this.Page1.Controls.Add(this.cboTan_Suat);
            this.Page1.Controls.Add(this.lblControl3);
            this.Page1.Controls.Add(this.lblControl2);
            this.Page1.Controls.Add(this.grbVisitOp);
            this.Page1.Controls.Add(this.lbMa_Vt);
            this.Page1.Controls.Add(this.txtMa_Dt);
            this.Page1.Controls.Add(this.txtMa_PJP);
            this.Page1.Controls.Add(this.lblControl1);
            this.Page1.Size = new System.Drawing.Size(592, 272);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(592, 272);
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl1.Location = new System.Drawing.Point(17, 45);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(35, 13);
            this.lblControl1.TabIndex = 143;
            this.lblControl1.Tag = "Ma_Dt";
            this.lblControl1.Text = "Mã đt";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Vt
            // 
            this.lbMa_Vt.AutoEllipsis = true;
            this.lbMa_Vt.AutoSize = true;
            this.lbMa_Vt.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_Vt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMa_Vt.Location = new System.Drawing.Point(17, 23);
            this.lbMa_Vt.Name = "lbMa_Vt";
            this.lbMa_Vt.Size = new System.Drawing.Size(44, 13);
            this.lbMa_Vt.TabIndex = 136;
            this.lbMa_Vt.Tag = "Ma_PJP";
            this.lbMa_Vt.Text = "Mã PJP";
            this.lbMa_Vt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dt
            // 
            this.txtMa_Dt.bEnabled = true;
            this.txtMa_Dt.bIsLookup = false;
            this.txtMa_Dt.bReadOnly = true;
            this.txtMa_Dt.bRequire = false;
            this.txtMa_Dt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt.ColumnsView = null;
            this.txtMa_Dt.CtrlDepend = null;
            this.txtMa_Dt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_Dt.KeyFilter = "Ma_Cbnv";
            this.txtMa_Dt.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtMa_Dt.ListFilter = new string[0];
            this.txtMa_Dt.Location = new System.Drawing.Point(122, 42);
            this.txtMa_Dt.LookupKeyFilter = "";
            this.txtMa_Dt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt.Name = "txtMa_Dt";
            this.txtMa_Dt.Size = new System.Drawing.Size(159, 20);
            this.txtMa_Dt.TabIndex = 2;
            this.txtMa_Dt.UseAutoFilter = true;
            // 
            // txtMa_PJP
            // 
            this.txtMa_PJP.bEnabled = true;
            this.txtMa_PJP.bIsLookup = false;
            this.txtMa_PJP.bReadOnly = true;
            this.txtMa_PJP.bRequire = false;
            this.txtMa_PJP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_PJP.ColumnsView = null;
            this.txtMa_PJP.CtrlDepend = null;
            this.txtMa_PJP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_PJP.KeyFilter = "";
            this.txtMa_PJP.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtMa_PJP.ListFilter = new string[0];
            this.txtMa_PJP.Location = new System.Drawing.Point(122, 20);
            this.txtMa_PJP.LookupKeyFilter = "";
            this.txtMa_PJP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_PJP.Name = "txtMa_PJP";
            this.txtMa_PJP.Size = new System.Drawing.Size(159, 20);
            this.txtMa_PJP.TabIndex = 0;
            this.txtMa_PJP.UseAutoFilter = false;
            // 
            // grbVisitOp
            // 
            this.grbVisitOp.Controls.Add(this.chkMon);
            this.grbVisitOp.Controls.Add(this.chkSun);
            this.grbVisitOp.Controls.Add(this.chkTue);
            this.grbVisitOp.Controls.Add(this.chkWed);
            this.grbVisitOp.Controls.Add(this.chkSat);
            this.grbVisitOp.Controls.Add(this.chkThu);
            this.grbVisitOp.Controls.Add(this.chkFri);
            this.grbVisitOp.Location = new System.Drawing.Point(20, 135);
            this.grbVisitOp.Name = "grbVisitOp";
            this.grbVisitOp.Size = new System.Drawing.Size(560, 37);
            this.grbVisitOp.TabIndex = 144;
            this.grbVisitOp.TabStop = false;
            this.grbVisitOp.Text = "Viếng thăm";
            // 
            // chkMon
            // 
            this.chkMon.AutoSize = true;
            this.chkMon.Location = new System.Drawing.Point(6, 19);
            this.chkMon.Name = "chkMon";
            this.chkMon.Size = new System.Drawing.Size(39, 17);
            this.chkMon.TabIndex = 75;
            this.chkMon.Text = "T2";
            this.chkMon.UseVisualStyleBackColor = true;
            // 
            // chkSun
            // 
            this.chkSun.AutoSize = true;
            this.chkSun.Location = new System.Drawing.Point(510, 19);
            this.chkSun.Name = "chkSun";
            this.chkSun.Size = new System.Drawing.Size(41, 17);
            this.chkSun.TabIndex = 75;
            this.chkSun.Text = "CN";
            this.chkSun.UseVisualStyleBackColor = true;
            // 
            // chkTue
            // 
            this.chkTue.AutoSize = true;
            this.chkTue.Location = new System.Drawing.Point(90, 19);
            this.chkTue.Name = "chkTue";
            this.chkTue.Size = new System.Drawing.Size(39, 17);
            this.chkTue.TabIndex = 75;
            this.chkTue.Text = "T3";
            this.chkTue.UseVisualStyleBackColor = true;
            // 
            // chkWed
            // 
            this.chkWed.AutoSize = true;
            this.chkWed.Location = new System.Drawing.Point(174, 19);
            this.chkWed.Name = "chkWed";
            this.chkWed.Size = new System.Drawing.Size(39, 17);
            this.chkWed.TabIndex = 75;
            this.chkWed.Text = "T4";
            this.chkWed.UseVisualStyleBackColor = true;
            // 
            // chkSat
            // 
            this.chkSat.AutoSize = true;
            this.chkSat.Location = new System.Drawing.Point(426, 19);
            this.chkSat.Name = "chkSat";
            this.chkSat.Size = new System.Drawing.Size(39, 17);
            this.chkSat.TabIndex = 75;
            this.chkSat.Text = "T7";
            this.chkSat.UseVisualStyleBackColor = true;
            // 
            // chkThu
            // 
            this.chkThu.AutoSize = true;
            this.chkThu.Location = new System.Drawing.Point(258, 19);
            this.chkThu.Name = "chkThu";
            this.chkThu.Size = new System.Drawing.Size(39, 17);
            this.chkThu.TabIndex = 75;
            this.chkThu.Text = "T5";
            this.chkThu.UseVisualStyleBackColor = true;
            // 
            // chkFri
            // 
            this.chkFri.AutoSize = true;
            this.chkFri.Location = new System.Drawing.Point(342, 19);
            this.chkFri.Name = "chkFri";
            this.chkFri.Size = new System.Drawing.Size(39, 17);
            this.chkFri.TabIndex = 75;
            this.chkFri.Text = "T6";
            this.chkFri.UseVisualStyleBackColor = true;
            // 
            // cboTan_Suat
            // 
            this.cboTan_Suat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTan_Suat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTan_Suat.FormattingEnabled = true;
            this.cboTan_Suat.InitValue = "F2";
            this.cboTan_Suat.Items.AddRange(new object[] {
            "F2",
            "F4",
            "F8",
            "F12"});
            this.cboTan_Suat.Location = new System.Drawing.Point(122, 64);
            this.cboTan_Suat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboTan_Suat.Name = "cboTan_Suat";
            this.cboTan_Suat.Size = new System.Drawing.Size(159, 21);
            this.cboTan_Suat.strValueList = null;
            this.cboTan_Suat.TabIndex = 143;
            this.cboTan_Suat.UpperCase = false;
            this.cboTan_Suat.UseAutoComplete = false;
            this.cboTan_Suat.UseBindingValue = false;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl2.Location = new System.Drawing.Point(17, 67);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(49, 13);
            this.lblControl2.TabIndex = 144;
            this.lblControl2.Tag = "Tan_Suat";
            this.lblControl2.Text = "Tần suất";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numStt
            // 
            this.numStt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numStt.bEnabled = true;
            this.numStt.bFormat = true;
            this.numStt.bIsLookup = false;
            this.numStt.bReadOnly = false;
            this.numStt.bRequire = false;
            this.numStt.KeyFilter = "";
            this.numStt.Location = new System.Drawing.Point(122, 87);
            this.numStt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numStt.Name = "numStt";
            this.numStt.Scale = 0;
            this.numStt.Size = new System.Drawing.Size(159, 20);
            this.numStt.TabIndex = 145;
            this.numStt.TabStop = false;
            this.numStt.Text = "0";
            this.numStt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numStt.UseAutoFilter = false;
            this.numStt.Value = 0D;
            // 
            // lblControl3
            // 
            this.lblControl3.AutoEllipsis = true;
            this.lblControl3.AutoSize = true;
            this.lblControl3.BackColor = System.Drawing.Color.Transparent;
            this.lblControl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl3.Location = new System.Drawing.Point(17, 90);
            this.lblControl3.Name = "lblControl3";
            this.lblControl3.Size = new System.Drawing.Size(38, 13);
            this.lblControl3.TabIndex = 144;
            this.lblControl3.Tag = "";
            this.lblControl3.Text = "Thứ tự";
            this.lblControl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmPJPConfigDetail_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 347);
            this.Name = "frmPJPConfigDetail_Edit";
            this.Object_ID = "LITUYEN";
            this.Tag = "ESC";
            this.Text = "frmPJPConfig";
            this.tabEdit.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.Page1.PerformLayout();
            this.Page2.ResumeLayout(false);
            this.Page2.PerformLayout();
            this.grbVisitOp.ResumeLayout(false);
            this.grbVisitOp.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private Systems.Controls.lblControl lblControl1;
        private Systems.Controls.lblControl lbMa_Vt;
        private Systems.Controls.txtTextLookup txtMa_Dt;
        private Systems.Controls.txtTextLookup txtMa_PJP;
        private System.Windows.Forms.GroupBox grbVisitOp;
        private Systems.Controls.cboControl cboTan_Suat;
        private Systems.Controls.lblControl lblControl2;
        private System.Windows.Forms.CheckBox chkMon;
        private System.Windows.Forms.CheckBox chkSun;
        private System.Windows.Forms.CheckBox chkTue;
        private System.Windows.Forms.CheckBox chkWed;
        private System.Windows.Forms.CheckBox chkSat;
        private System.Windows.Forms.CheckBox chkThu;
        private System.Windows.Forms.CheckBox chkFri;
        private Systems.Controls.numControl numStt;
        private Systems.Controls.lblControl lblControl3;
	}
}