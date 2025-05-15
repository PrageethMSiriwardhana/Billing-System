using Billing_System.View;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_System
{
    public partial class frmMain : Sample
    {
        public static object Instance { get; internal set; }


        void StyleSidebarButtons()
        {
            Guna2Button[] buttons = {
        btnUser, btnCustomer, btnSupplier, btnPurchase,
        btnSale, btnPayment, btnRecipt
    };

            foreach (var btn in buttons)
            {
                btn.FillColor = Color.Transparent;
                btn.HoverState.FillColor = Color.FromArgb(40, 255, 255, 255); //  Light glassy hover
                btn.BorderThickness = 0;
                btn.BorderColor = Color.Transparent;
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.White;
                btn.Cursor = Cursors.Hand;
            }
        }


        public frmMain()
        {
            InitializeComponent();
        }

        private void RestrictUserAccess()
        {
            if (userRole.Text != "Admin") // Only Admin can access everything
            {
                // Disable all other buttons for non-admins
                btnUser.Enabled = false;
                btnProduct.Enabled = false;
                btnCustomer.Enabled = false;
                btnSupplier.Enabled = false;
                btnPurchase.Enabled = false;
                btnSale.Enabled = false;
                btnPayment.Enabled = false;
                btnRecipt.Enabled = false;

                // Optionally: Show tooltips or warnings on click
                btnUser.Click += ShowAccessDenied;
                btnCustomer.Click += ShowAccessDenied;
                btnSupplier.Click += ShowAccessDenied;
                btnPurchase.Click += ShowAccessDenied;
                btnSale.Click += ShowAccessDenied;
                btnPayment.Click += ShowAccessDenied;
                btnRecipt.Click += ShowAccessDenied;
            }
        }

        private void ShowAccessDenied(object sender, EventArgs e)
        {
            MessageBox.Show("Access Denied: This feature is only available for Admin users.",
                "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }



        private void frmMain_Load(object sender, EventArgs e)
        {
            AddControls(new frmDashboard());

            // Profile picture
            if (CurrentUser.ProfileImage != null)
            {
                using (MemoryStream ms = new MemoryStream(CurrentUser.ProfileImage))
                {
                    userProfilePic.Image = Image.FromStream(ms);
                }
            }

            // Set role name and username
            roleName.Text = CurrentUser.UserName;

            string roleQuery = "SELECT RoleName FROM tblRole WHERE RoleID = @id";
            using (SqlConnection con = new SqlConnection(MainClass.Functions.conString))
            {
                SqlCommand cmd = new SqlCommand(roleQuery, con);
                cmd.Parameters.AddWithValue("@id", CurrentUser.Role);

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        userRole.Text = result.ToString();
                    }
                    else
                    {
                        userRole.Text = "Unknown";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading role: " + ex.Message);
                }
            }

            // Restrict access if not Admin
            StyleSidebarButtons();
            RestrictUserAccess();
        }




        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addNewPanel.Visible = true;


        }

        private void addNewPanel_MouseEnter(object sender, EventArgs e)
        {
            addNewPanel.Visible = false;
        }

        private void userRole_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void AddControls(Form F)
        {
            CentralPannel.Controls.Clear();
            F.TopLevel = false;
            F.Dock = DockStyle.Fill;
            CentralPannel.Controls.Add(F);
            F.Show();

        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            AddControls(new frmProduct());
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            
            AddControls(new frmUser());
           
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            AddControls(new frmCustomer());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            AddControls(new frmSupplier());
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            AddControls(new frmPurchase());
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            AddControls(new frmSales());
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            AddControls(new frmPayment());
        }

        private void btnRecipt_Click(object sender, EventArgs e)
        {
            AddControls(new frmReceipts());
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            AddControls(new frmReport());

        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            AddControls(new frmDashboard());

        }

        private void btnCloseLogin_Click(object sender, EventArgs e)
        {
            guna2MessageDialog1.Parent = this;
            guna2MessageDialog1.Style = MessageDialogStyle.Dark;
            guna2MessageDialog1.Icon = MessageDialogIcon.Question;
            guna2MessageDialog1.Caption = "Confirm Logout";
            guna2MessageDialog1.Text = "Are you sure you want to logout?";
            guna2MessageDialog1.Buttons = MessageDialogButtons.YesNo;

            DialogResult result = guna2MessageDialog1.Show();

            if (result == DialogResult.Yes)
            {
                // Clear user session data
                CurrentUser.UserID = 0;
                CurrentUser.UserName = null;
                CurrentUser.Role = 0;
                CurrentUser.ProfileImage = null;

                // Show login form
                frmLogin loginForm = new frmLogin();
                loginForm.Show();

                // Close the main form
                this.Close();
            }
        }

    }
}
