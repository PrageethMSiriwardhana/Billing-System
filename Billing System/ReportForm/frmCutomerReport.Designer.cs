namespace Billing_System.ReportForm
{
    partial class frmCutomerReport
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
            this.PersonID = new Guna.UI2.WinForms.Guna2ComboBox();
            this.InvlidN = new System.Windows.Forms.Label();
            this.guna2CustomGradientPanel2 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.btnClose = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnReport = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2CustomGradientPanel2.SuspendLayout();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.DockIndicatorColor = System.Drawing.Color.DarkViolet;
            // 
            // PersonID
            // 
            this.PersonID.BackColor = System.Drawing.Color.Transparent;
            this.PersonID.BorderColor = System.Drawing.Color.DarkViolet;
            this.PersonID.BorderRadius = 9;
            this.PersonID.BorderThickness = 2;
            this.PersonID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.PersonID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PersonID.FillColor = System.Drawing.Color.Black;
            this.PersonID.FocusedColor = System.Drawing.Color.Fuchsia;
            this.PersonID.FocusedState.BorderColor = System.Drawing.Color.Fuchsia;
            this.PersonID.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold);
            this.PersonID.ForeColor = System.Drawing.Color.DarkViolet;
            this.PersonID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PersonID.ItemHeight = 39;
            this.PersonID.Location = new System.Drawing.Point(93, 205);
            this.PersonID.Name = "PersonID";
            this.PersonID.Size = new System.Drawing.Size(256, 45);
            this.PersonID.TabIndex = 39;
            // 
            // InvlidN
            // 
            this.InvlidN.AutoSize = true;
            this.InvlidN.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvlidN.Location = new System.Drawing.Point(95, 168);
            this.InvlidN.Name = "InvlidN";
            this.InvlidN.Size = new System.Drawing.Size(94, 16);
            this.InvlidN.TabIndex = 38;
            this.InvlidN.Text = "Customer Name";
            // 
            // guna2CustomGradientPanel2
            // 
            this.guna2CustomGradientPanel2.Controls.Add(this.btnClose);
            this.guna2CustomGradientPanel2.Controls.Add(this.btnReport);
            this.guna2CustomGradientPanel2.CustomBorderColor = System.Drawing.Color.DarkViolet;
            this.guna2CustomGradientPanel2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.guna2CustomGradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2CustomGradientPanel2.FillColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel2.FillColor2 = System.Drawing.Color.DarkViolet;
            this.guna2CustomGradientPanel2.FillColor3 = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel2.FillColor4 = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel2.Location = new System.Drawing.Point(0, 354);
            this.guna2CustomGradientPanel2.Name = "guna2CustomGradientPanel2";
            this.guna2CustomGradientPanel2.Size = new System.Drawing.Size(449, 96);
            this.guna2CustomGradientPanel2.TabIndex = 40;
            // 
            // btnClose
            // 
            this.btnClose.Animated = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderColor = System.Drawing.Color.MediumOrchid;
            this.btnClose.BorderRadius = 9;
            this.btnClose.BorderThickness = 3;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.DarkViolet;
            this.btnClose.FillColor2 = System.Drawing.Color.MediumOrchid;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverState.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnClose.Image = global::Billing_System.Properties.Resources.close;
            this.btnClose.ImageOffset = new System.Drawing.Point(-3, 2);
            this.btnClose.ImageSize = new System.Drawing.Size(25, 25);
            this.btnClose.Location = new System.Drawing.Point(226, 24);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 41);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseTransparentBackground = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReport
            // 
            this.btnReport.Animated = true;
            this.btnReport.BackColor = System.Drawing.Color.Transparent;
            this.btnReport.BorderColor = System.Drawing.Color.MediumOrchid;
            this.btnReport.BorderRadius = 9;
            this.btnReport.BorderThickness = 3;
            this.btnReport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReport.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReport.FillColor = System.Drawing.Color.DarkViolet;
            this.btnReport.FillColor2 = System.Drawing.Color.MediumOrchid;
            this.btnReport.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.HoverState.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnReport.Image = global::Billing_System.Properties.Resources.save_file;
            this.btnReport.ImageOffset = new System.Drawing.Point(-3, 2);
            this.btnReport.ImageSize = new System.Drawing.Size(25, 25);
            this.btnReport.Location = new System.Drawing.Point(93, 24);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(123, 41);
            this.btnReport.TabIndex = 11;
            this.btnReport.Text = "REPORT";
            this.btnReport.UseTransparentBackground = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Controls.Add(this.label1);
            this.guna2CustomGradientPanel1.CustomBorderColor = System.Drawing.Color.DarkViolet;
            this.guna2CustomGradientPanel1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.DarkViolet;
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(449, 103);
            this.guna2CustomGradientPanel1.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Balance Report";
            // 
            // frmCutomerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 450);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Controls.Add(this.guna2CustomGradientPanel2);
            this.Controls.Add(this.PersonID);
            this.Controls.Add(this.InvlidN);
            this.Name = "frmCutomerReport";
            this.Text = "frmCutomerReport";
            this.Load += new System.EventHandler(this.frmCutomerReport_Load);
            this.guna2CustomGradientPanel2.ResumeLayout(false);
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox PersonID;
        private System.Windows.Forms.Label InvlidN;
        public Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel2;
        public Guna.UI2.WinForms.Guna2GradientButton btnClose;
        public Guna.UI2.WinForms.Guna2GradientButton btnReport;
        public Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        public System.Windows.Forms.Label label1;
    }
}