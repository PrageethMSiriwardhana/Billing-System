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
    public partial class frmCusAdd : SampleAdd
    {
        public frmCusAdd()
        {
            InitializeComponent();
        }

        private void frmCusAdd_Load(object sender, EventArgs e)
        {

            if (editID > 0)
            {
                MainClass.Functions.AutoLoadForEdit(this, "tblCustomer", editID);
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
                MainClass.Functions.AutoSQL(this, "tblCustomer", MainClass.Functions.enmType.Insert, editID);

                guna2MessageDialog1.Parent = this; //  Bind it to the current form
                guna2MessageDialog1.Icon = MessageDialogIcon.Information;
                guna2MessageDialog1.Style = MessageDialogStyle.Dark;
                guna2MessageDialog1.Caption = "Billing System";
                guna2MessageDialog1.Text = "Customer has been successfully saved!";
                guna2MessageDialog1.Buttons = MessageDialogButtons.OK;
                guna2MessageDialog1.Show();



                MainClass.Functions.ClearAll(this);
            }
            else // Update existing product
            {
                MainClass.Functions.AutoSQL(this, "tblCustomer", MainClass.Functions.enmType.Update, editID);

                guna2MessageDialog2.Parent = this; //  Bind dialog to this form
                guna2MessageDialog2.Icon = MessageDialogIcon.Information;
                guna2MessageDialog2.Style = MessageDialogStyle.Dark;
                guna2MessageDialog2.Caption = "Billing System";
                guna2MessageDialog2.Text = "Customer updated successfully!";
                guna2MessageDialog2.Buttons = MessageDialogButtons.OK;
                guna2MessageDialog2.Show();

            }

            editID = 0;
            MainClass.Functions.ClearAll(this);

        }

        public override void btnDelete_Click(object sender, EventArgs e)
        {
            // Show Yes/No confirmation before deleting
            guna2MessageDialog3.Parent = this;
            guna2MessageDialog3.Icon = MessageDialogIcon.Question;
            guna2MessageDialog3.Style = MessageDialogStyle.Dark;
            guna2MessageDialog3.Caption = "Confirm Deletion";
            guna2MessageDialog3.Text = "Are you sure you want to delete this customer?";
            guna2MessageDialog3.Buttons = MessageDialogButtons.YesNo;

            DialogResult result = guna2MessageDialog3.Show();

            if (result == DialogResult.Yes)
            {
                //Proceed with deletion
                MainClass.Functions.AutoSQL(this, "tblCustomer", MainClass.Functions.enmType.Delete, editID);
                editID = 0;
                MainClass.Functions.ClearAll(this);

            }
        }




    }
}
