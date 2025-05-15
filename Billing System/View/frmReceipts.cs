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
    public partial class frmReceipts : SampleView
    {
        public frmReceipts()
        {
            InitializeComponent();
        }

        private void frmReceipts_Load(object sender, EventArgs e)
        {
            LoadData();
        }



        private async void LoadData()
        {
            string qry = @"SELECT ROW_NUMBER() OVER(ORDER BY r.recID) AS 'Sr#',
                                   r.recID,
                                   r.mdate AS 'Receipt Date',
                                   c.cName AS 'Customer Name',
                                   r.description AS 'Description',
                                   r.NetAmount AS 'Amount'
                            FROM tblReceipt r
                            INNER JOIN tblCustomer c ON r.PersonID = c.cusID
                            WHERE c.cName LIKE '%" + txtSearch.Text + @"%'
                            ORDER BY r.recID";


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
                    // Hide the recID column
                    if (guna2DataGridView1.Columns["recID"] != null)
                    {
                        guna2DataGridView1.Columns["recID"].Visible = false; // Hide the recID column
                    }
                    SetSrColumnWidth(); // Call this after data is loaded
                });
            }
            else
            {
                guna2DataGridView1.DataSource = dt;
                // Hide the recID column
                if (guna2DataGridView1.Columns["recID"] != null)
                {
                    guna2DataGridView1.Columns["recID"].Visible = false; // Hide the recID column
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
            new frmReceipAdd().ShowDialog();
            LoadData();
        }

        public override void guna2DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (guna2DataGridView1.CurrentRow != null)
            {
                // Get the recID from the selected row
                int recID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["recID"].Value);

                // Open the frmReceipAdd form and pass the recID
                frmReceipAdd receipAddForm = new frmReceipAdd
                {
                    editID = recID // Set the editID property to load the receipt details
                };

                receipAddForm.ShowDialog(); // Show the form as a dialog
                LoadData(); // Reload the receipt list after closing the form
            }
        }




    }
}
