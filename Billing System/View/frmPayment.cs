using Billing_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_System.View
{
    public partial class frmPayment : SampleView
    {
        public frmPayment()
        {
            InitializeComponent();
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private async void LoadData()
        {
            string qry = @"SELECT ROW_NUMBER() OVER(ORDER BY p.payID) AS 'Sr#',
                                   p.payID,
                                   p.mdate AS 'Payment Date',
                                   s.sName AS 'Supplier Name',
                                   p.description AS 'Description',
                                   p.NetAmount AS 'Amount'
                            FROM tblPayment p
                            INNER JOIN tblSupplier s ON p.PersonID = s.supID
                            WHERE s.sName LIKE '%" + txtSearch.Text + @"%'
                            ORDER BY p.payID";


            DataTable dt = null;

            // Run the data-fetching task asynchronously
            await Task.Run(() =>
            {
                // Fetch data in the background thread
                dt = MainClass.Functions.GetData(qry);
            });

            // Update the DataGridView on the UI thread
            if (guna2DataGridView1.InvokeRequired)
            {
                guna2DataGridView1.Invoke((MethodInvoker)delegate
                {
                    guna2DataGridView1.DataSource = dt;
                    // Hide the payID column
                    if (guna2DataGridView1.Columns["payID"] != null)
                    {
                        guna2DataGridView1.Columns["payID"].Visible = false; // Hide the payID column
                    }
                    SetSrColumnWidth(); // Call this after data is loaded
                });
            }
            else
            {
                guna2DataGridView1.DataSource = dt;
                // Hide the payID column
                if (guna2DataGridView1.Columns["payID"] != null)
                {
                    guna2DataGridView1.Columns["payID"].Visible = false; // Hide the payID column
                }
                SetSrColumnWidth(); // Call this after data is loaded
            }
        }

        // Method to adjust the "Sr" column width
        private void SetSrColumnWidth()
        {
            if (guna2DataGridView1.Columns["Sr#"] != null)
            {
                guna2DataGridView1.Columns["Sr#"].Width = 80; // Adjust the width
            }
            if (guna2DataGridView1.Columns["payID"] != null)
            {
                guna2DataGridView1.Columns["payID"].Width = 80; // Adjust the width of "proID"
            }
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            new frmPaymentAdd().ShowDialog();
            LoadData();
        }

        public override void guna2DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (guna2DataGridView1.CurrentRow != null)
            {
                // Get the payID from the selected row
                int payID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["payID"].Value);

                // Open the frmPaymentAdd form and pass the payID
                frmPaymentAdd paymentAddForm = new frmPaymentAdd
                {
                    editID = payID // Set the editID property to load the payment details
                };

                paymentAddForm.ShowDialog(); // Show the form as a dialog
                LoadData(); // Reload the payment list after closing the form
            }
        }

    }
}