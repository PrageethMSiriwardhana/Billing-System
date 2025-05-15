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
    public partial class SampleAdd : Sample
    {
        public SampleAdd()
        {
            InitializeComponent();
        }

        public int editID = 0;


        public virtual void btnSave_Click(object sender, EventArgs e)
        {

        }

        public virtual void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
