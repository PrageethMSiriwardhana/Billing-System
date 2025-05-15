using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_System
{
    public partial class Sample : Form
    {
        public Sample()
        {
            InitializeComponent();
            //MainClass Funtions MsgCaption and conString
            MainClass.Functions.MsgCaption = "Billing System";
            MainClass.Functions.conString = "Data Source=LAHIRU\\SQLEXPRESS;Initial Catalog=BillingSystem;Integrated Security=True";


        }

        private void Sample_Load(object sender, EventArgs e)
        {

        }
    }
}
