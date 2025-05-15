namespace Billing_System.View
{
    partial class frmReport
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
            this.guna2CustomGradientPanel2 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCustomer = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnSupplier = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2CustomGradientPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2CustomGradientPanel2
            // 
            this.guna2CustomGradientPanel2.Controls.Add(this.label1);
            this.guna2CustomGradientPanel2.CustomBorderColor = System.Drawing.Color.DarkViolet;
            this.guna2CustomGradientPanel2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.guna2CustomGradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2CustomGradientPanel2.FillColor = System.Drawing.Color.DarkViolet;
            this.guna2CustomGradientPanel2.FillColor2 = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel2.FillColor3 = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel2.FillColor4 = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel2.Name = "guna2CustomGradientPanel2";
            this.guna2CustomGradientPanel2.Size = new System.Drawing.Size(800, 142);
            this.guna2CustomGradientPanel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Reports";
            // 
            // btnCustomer
            // 
            this.btnCustomer.BorderRadius = 16;
            this.btnCustomer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCustomer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCustomer.FillColor = System.Drawing.Color.DarkViolet;
            this.btnCustomer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCustomer.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.Image = global::Billing_System.Properties.Resources.report;
            this.btnCustomer.ImageSize = new System.Drawing.Size(90, 90);
            this.btnCustomer.Location = new System.Drawing.Point(45, 190);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(180, 180);
            this.btnCustomer.TabIndex = 4;
            this.btnCustomer.Text = "Customer Report";
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.BorderRadius = 16;
            this.btnSupplier.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSupplier.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSupplier.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSupplier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSupplier.FillColor = System.Drawing.Color.DarkViolet;
            this.btnSupplier.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSupplier.ForeColor = System.Drawing.Color.White;
            this.btnSupplier.Image = global::Billing_System.Properties.Resources.report;
            this.btnSupplier.ImageSize = new System.Drawing.Size(90, 90);
            this.btnSupplier.Location = new System.Drawing.Point(278, 190);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(180, 180);
            this.btnSupplier.TabIndex = 5;
            this.btnSupplier.Text = "Supplier Report";
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSupplier);
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.guna2CustomGradientPanel2);
            this.Name = "frmReport";
            this.Text = "frmReport";
            this.guna2CustomGradientPanel2.ResumeLayout(false);
            this.guna2CustomGradientPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel2;
        public System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TileButton btnCustomer;
        private Guna.UI2.WinForms.Guna2TileButton btnSupplier;
    }
}