using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_System.Model
{
    public partial class frmProductAdd : SampleAdd
    {
        public frmProductAdd()
        {
            InitializeComponent();
        }





        private void btnBrowser_Click(object sender, EventArgs e)
        {
            MainClass.Functions.BrowsePicture(pImage);
        }

        private void frmProductAdd_Load(object sender, EventArgs e)
        {
            if (editID > 0)
            {
                MainClass.Functions.AutoLoadForEdit(this, "tblProduct", editID);
            }
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (MainClass.Functions.Validatation(this) == false)
            {
                return;
            }

            if (editID == 0) // Save new product
            {
                MainClass.Functions.AutoSQL(this, "tblProduct", MainClass.Functions.enmType.Insert, editID);
                guna2MessageDialog1.Show();
                MainClass.Functions.ClearAll(this);
            }
            else // Update existing product
            {
                MainClass.Functions.AutoSQL(this, "tblProduct", MainClass.Functions.enmType.Update, editID);
                guna2MessageDialog2.Show();
            }

            editID = 0;
            MainClass.Functions.ClearAll(this);

            // Clear the PictureBox after saving
            pImage.Image = null; // Or set to a default image
        }

        public override void btnDelete_Click(object sender, EventArgs e)
        {
            // Show the confirmation dialog with Yes/No buttons
            DialogResult result = guna2MessageDialog3.Show();

            // Proceed with deletion only if the user selects "Yes"
            if (result == DialogResult.Yes)
            {
                MainClass.Functions.AutoSQL(this, "tblProduct", MainClass.Functions.enmType.Delete, editID);
                editID = 0;
                MainClass.Functions.ClearAll(this);

                // Clear the PictureBox after deleting
                pImage.Image = null; // Or reset to default image if needed
            }
        }
    }
}
