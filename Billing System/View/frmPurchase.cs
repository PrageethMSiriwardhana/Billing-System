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
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace Billing_System.View
{
    public partial class frmPurchase : SampleView
    {
        public frmPurchase()
        {
            InitializeComponent();
        }

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
                    string qry = @"
            Select ROW_NUMBER() OVER (ORDER BY mainID) 'Sr', 
                   mainID, 
                   mdate 'Date', 
                   mDueDate 'Due Date', 
                   s.sName 'Supplier Name',
                   mTotal 'Gross Amount', 
                   Discount, 
                   NetAmount 'Net Amount'
            from tblInvMain m
            inner join tblSupplier s on m.PersonID = s.supID
            where mType = 'Purchase' 
            and sName like '%" + txtSearch.Text + "%' order by mainID";



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
                    // Hide the mainID column
                    if (guna2DataGridView1.Columns["mainID"] != null)
                    {
                        guna2DataGridView1.Columns["mainID"].Visible = false; // Hide the mainID column
                    }

                });
            }
            else
            {
                guna2DataGridView1.DataSource = dt;
                // Hide the mainID column
                if (guna2DataGridView1.Columns["mainID"] != null)
                {
                    guna2DataGridView1.Columns["mainID"].Visible = false; // Hide the mainID column
                }

            }
        }



        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            new frmPurchaseAdd().ShowDialog();
            LoadData();
        }

        public override void guna2DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells[1].Value); // mainID column එක
            new frmPurchaseAdd() { editID = id }.ShowDialog();
            LoadData();
        }

    }
}
