namespace Billing_System
{
    partial class frmLoading
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
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2BorderlessForm2 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.loadingPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.loadingPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.loadingPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::Billing_System.Properties.Resources.logomain;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(191, 24);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(225, 251);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 3;
            this.guna2PictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AccessibleName = "LoadingData";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Loading...";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 15;
            // 
            // guna2BorderlessForm2
            // 
            this.guna2BorderlessForm2.ContainerControl = this;
            this.guna2BorderlessForm2.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm2.ShadowColor = System.Drawing.Color.DarkViolet;
            this.guna2BorderlessForm2.TransparentWhileDrag = true;
            // 
            // loadingPanel2
            // 
            this.loadingPanel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.loadingPanel2.BorderRadius = 3;
            this.loadingPanel2.FillColor = System.Drawing.Color.DarkViolet;
            this.loadingPanel2.FillColor2 = System.Drawing.Color.Fuchsia;
            this.loadingPanel2.Location = new System.Drawing.Point(-2, 0);
            this.loadingPanel2.Name = "loadingPanel2";
            this.loadingPanel2.Size = new System.Drawing.Size(10, 10);
            this.loadingPanel2.TabIndex = 2;
            // 
            // loadingPanel1
            // 
            this.loadingPanel1.BorderRadius = 3;
            this.loadingPanel1.Controls.Add(this.loadingPanel2);
            this.loadingPanel1.Location = new System.Drawing.Point(1, 326);
            this.loadingPanel1.Name = "loadingPanel1";
            this.loadingPanel1.Size = new System.Drawing.Size(616, 10);
            this.loadingPanel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AccessibleName = "LoadingPresentage";
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(573, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "100%";
            // 
            // frmLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(617, 338);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.loadingPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2PictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "frmLoading";
            this.Text = "frmLoading";
            this.Load += new System.EventHandler(this.frmLoading_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.loadingPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm2;
        private Guna.UI2.WinForms.Guna2GradientPanel loadingPanel1;
        private Guna.UI2.WinForms.Guna2GradientPanel loadingPanel2;
        private System.Windows.Forms.Label label2;
    }



}