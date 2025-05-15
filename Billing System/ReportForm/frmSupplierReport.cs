using Billing_System.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_System.ReportForm
{
    public partial class frmSupplierReport : Sample
    {
        public frmSupplierReport()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSupplierReport_Load(object sender, EventArgs e)
        {
            // Add Supplier to combobox
            string qry = "Select supID 'id', sName 'name' from tblSupplier";
            //CBFill
            MainClass.Functions.CBFfill(qry, PersonID);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            string qry = @" Select mdate 'Date', sName 'Supplier', 'Bill amount agaist inv#' + CONVERT(varchar(10),mainID) 'Description', NetAmount , 0 'Payment'
                            from tblInvMain m
                            inner join tblSupplier c on m.PersonID = c.supID
                            where mType = 'Purchase' and PersonID = " + PersonID.SelectedValue + " " +

                            " UNION ALL " +

                            " select mdate , sName , description , 0 'Sale Amount', NetAmount" +
                            " from tblPayment r" +
                            " inner join tblSupplier on supID = PersonID" +
                            " where PersonID = " + PersonID.SelectedValue + " ";


            DataTable dt = MainClass.Functions.GetTable(qry);

            rptSupplier cr = new rptSupplier();
            cr.SetDataSource(dt); // NO SetDatabaseLogon
            frmPrint frm = new frmPrint();
            frm.crystalReportViewer1.ReportSource = cr;
            frm.Show();

        }
    }
}
