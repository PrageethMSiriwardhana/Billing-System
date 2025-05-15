using Billing_System.ReportForm;
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
    public partial class frmReport : Sample
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            new frmCutomerReport().ShowDialog();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            new frmSupplierReport().ShowDialog();

        }
    }
}
