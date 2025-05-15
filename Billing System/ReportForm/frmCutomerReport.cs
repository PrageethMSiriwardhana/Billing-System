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
    public partial class frmCutomerReport : Sample
    {
        public frmCutomerReport()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCutomerReport_Load(object sender, EventArgs e)
        {
            // Add Supplier to combobox
            string qry = "Select cusID 'id', cName 'name' from tblCustomer";
            //CBFill
            MainClass.Functions.CBFfill(qry, PersonID);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            string qry = @" Select mdate 'Date', cName 'Customer', 'Bill amount agaist inv#' + CONVERT(varchar(10),mainID) 'Description', NetAmount , 0 'Receipt'
                            from tblInvMain m
                            inner join tblCustomer c on m.PersonID = c.cusID
                            where mType = 'Sale' and PersonID = "+ PersonID.SelectedValue + " " +

                            " UNION ALL "+

                            " select mdate , cName , description , 0 'Sale Amount', NetAmount" +
                            " from tblReceipt r" +
                            " inner join tblCustomer on cusID = PersonID" +
                            " where PersonID = " + PersonID.SelectedValue + " ";


                            DataTable dt = MainClass.Functions.GetTable(qry);

                            rptCustomer cr = new rptCustomer();
                            cr.SetDataSource(dt); // NO SetDatabaseLogon
                            frmPrint frm = new frmPrint();
                            frm.crystalReportViewer1.ReportSource = cr;
                            frm.Show();


        }
    }
}
