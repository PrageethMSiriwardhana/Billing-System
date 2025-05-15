using Billing_System.Model;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_System.View
{
    public partial class frmProduct : SampleView
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
            string qry = @"Select ROW_NUMBER() OVER(ORDER BY proID) AS 'Sr#', proID, pName 'Name', pPrice 'Price (Rs.)', pCost 'Cost (Rs.)'
                           from tblProduct where pName like '%" + txtSearch.Text + "%' order by proID";

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
                    // Hide the proID column
                    if (guna2DataGridView1.Columns["proID"] != null)
                    {
                        guna2DataGridView1.Columns["proID"].Visible = false; // Hide the proID column
                    }
                    SetSrColumnWidth(); // Call this after data is loaded
                });
            }
            else
            {
                guna2DataGridView1.DataSource = dt;
                // Hide the proID column
                if (guna2DataGridView1.Columns["proID"] != null)
                {
                    guna2DataGridView1.Columns["proID"].Visible = false; // Hide the proID column
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
            if (guna2DataGridView1.Columns["proID"] != null)
            {
                guna2DataGridView1.Columns["proID"].Width = 80; // Adjust the width of "proID"
            }
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            new frmProductAdd().ShowDialog();
            LoadData();
        }

        public override void guna2DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells[1].Value);
            new frmProductAdd() { editID = id }.ShowDialog();
            LoadData();
        }
    }
}
