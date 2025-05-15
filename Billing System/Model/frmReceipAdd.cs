using Guna.UI2.WinForms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_System.Model
{
    public partial class frmReceipAdd : SampleAdd
    {
        public frmReceipAdd()
        {
            InitializeComponent();

        }


        private int lastRowIndex = -1;

        private void mdate_ValueChanged(object sender, EventArgs e)
        {
            MainClass.Functions.MaskD(mdate);
        }

        private void frmReceipAdd_Load(object sender, EventArgs e)
        {
            PersonID.SelectedIndexChanged -= PersonID_SelectedIndexChanged;
            mainID.Text = "0";

            string qry = "SELECT cusID 'id', cName 'name' FROM tblCustomer";
            MainClass.Functions.CBFill(qry, PersonID);

            if (editID > 0)
            {
                MainClass.Functions.AutoLoadForEdit(this, "tblReceipt", editID);

                if (!string.IsNullOrWhiteSpace(description.Text) && description.Text.Contains("Invoice #"))
                {
                    string[] parts = description.Text.Split('#');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int parsedMainID))
                    {
                        mainID.Text = parsedMainID.ToString();
                    }
                }

                if (PersonID.SelectedValue != null)
                {
                    int customerID = Convert.ToInt32(PersonID.SelectedValue);
                    LoadInvoicesForCustomer(customerID);
                    SelectRowInGridByMainID(mainID.Text);
                }
            }
            else
            {
                PersonID_SelectedIndexChanged(null, null);
            }

            PersonID.SelectedIndexChanged += PersonID_SelectedIndexChanged;

            guna2DataGridView1.SelectionChanged -= guna2DataGridView1_SelectionChanged;
            guna2DataGridView1.SelectionChanged += guna2DataGridView1_SelectionChanged;
        }

        private void SelectRowInGridByMainID(string invoiceID)
        {
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.Cells["mainID"].Value != null && row.Cells["mainID"].Value.ToString() == invoiceID)
                {
                    guna2DataGridView1.ClearSelection();
                    row.Selected = true;
                    guna2DataGridView1.FirstDisplayedScrollingRowIndex = row.Index;

                    if (row.Cells["Balance"].Value != null)
                        NetAmount.Text = row.Cells["Balance"].Value.ToString();

                    description.Text = $"Payment for Invoice #{mainID.Text}";
                    break;
                }
            }
        }

        private void LoadInvoicesForCustomer(int customerID)
        {
            string qry = $@"
            SELECT 0 AS 'Sr#',
                   m.mainID,
                   m.NetAmount AS 'Invoice Amount',
                   (SELECT ISNULL(SUM(r.NetAmount), 0) FROM tblReceipt r WHERE r.mainID = m.mainID) AS 'Payment',
                   m.NetAmount - (SELECT ISNULL(SUM(r.NetAmount), 0) FROM tblReceipt r WHERE r.mainID = m.mainID) AS 'Balance'
            FROM tblInvMain m
            WHERE m.mType = 'Sale'
              AND m.mType <> 'Cash'
              AND m.PersonID = {customerID}";

            MainClass.Functions.LoadData(qry, guna2DataGridView1);

            if (guna2DataGridView1.Columns.Contains("mainID"))
                guna2DataGridView1.Columns["mainID"].Visible = true;

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.Cells["mainID"].Value != null && row.Cells["mainID"].Value.ToString() == mainID.Text)
                {
                    row.Selected = true;
                    if (row.Cells["Balance"].Value != null)
                        NetAmount.Text = row.Cells["Balance"].Value.ToString();

                    description.Text = $"Payment for Invoice #{mainID.Text}";
                    break;
                }
            }
        }

        private void PersonID_SelectedIndexChanged(object sender, EventArgs e)
        {
            lastRowIndex = -1;
            int partyID = (PersonID.SelectedIndex == -1) ? 0 : Convert.ToInt32(PersonID.SelectedValue);
            guna2DataGridView1.DataSource = null;

            string qry = $@"
                SELECT 0 AS 'Sr#',
                       m.mainID,
                       m.NetAmount AS 'Invoice Amount',
                       (SELECT ISNULL(SUM(r.NetAmount), 0) FROM tblReceipt r WHERE r.mainID = m.mainID) AS 'Payment',
                       m.NetAmount - (SELECT ISNULL(SUM(r.NetAmount), 0) FROM tblReceipt r WHERE r.mainID = m.mainID) AS 'Balance'
                FROM tblInvMain m
                WHERE m.NetAmount - (SELECT ISNULL(SUM(r.NetAmount), 0) FROM tblReceipt r WHERE r.mainID = m.mainID) <> 0
                  AND m.mType <> 'Cash'
                  AND m.mType = 'Sale'
                  AND m.PersonID = {partyID}";

            MainClass.Functions.LoadData(qry, guna2DataGridView1);

            if (guna2DataGridView1.Columns.Contains("mainID"))
                guna2DataGridView1.Columns["mainID"].Visible = true;

            if (guna2DataGridView1.Rows.Count > 0)
            {
                guna2DataGridView1.ClearSelection();
                guna2DataGridView1.Rows[0].Selected = true;

                var row = guna2DataGridView1.Rows[0];
                if (row.Cells["mainID"].Value != null)
                    mainID.Text = row.Cells["mainID"].Value.ToString();

                if (row.Cells["Balance"].Value != null)
                    NetAmount.Text = row.Cells["Balance"].Value.ToString();

                description.Text = $"Payment for Invoice #{mainID.Text}";
            }
        }

        private void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                var row = guna2DataGridView1.SelectedRows[0];

                if (row.Cells["mainID"].Value != null)
                    mainID.Text = row.Cells["mainID"].Value.ToString();

                if (row.Cells["Balance"].Value != null)
                    NetAmount.Text = row.Cells["Balance"].Value.ToString();

                description.Text = $"Payment for Invoice #{mainID.Text}";
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex != lastRowIndex)
            {
                lastRowIndex = e.RowIndex;
                var row = guna2DataGridView1.Rows[e.RowIndex];

                if (row.Cells["mainID"].Value != null)
                    mainID.Text = row.Cells["mainID"].Value.ToString();

                if (row.Cells["Balance"].Value != null)
                    NetAmount.Text = row.Cells["Balance"].Value.ToString();

                description.Text = $"Payment for Invoice #{mainID.Text}";
            }
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (PersonID.SelectedIndex == -1 || string.IsNullOrWhiteSpace(PersonID.Text))
            {
                ShowMsg("Please select a customer!", MessageDialogIcon.Warning);
                return;
            }

            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                ShowMsg("Please select an invoice from the list!", MessageDialogIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(description.Text))
            {
                ShowMsg("Please enter a description!", MessageDialogIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(NetAmount.Text) || !decimal.TryParse(NetAmount.Text, out decimal amount) || amount <= 0)
            {
                ShowMsg("Please enter a valid amount!", MessageDialogIcon.Warning);
                return;
            }

            try
            {
                if (mainID.Text == "0") return;
                if (!MainClass.Functions.Validatation(this)) return;

                if (editID == 0)
                    MainClass.Functions.AutoSQL(this, "tblReceipt", MainClass.Functions.enmType.Insert, editID);
                    
                else
                    MainClass.Functions.AutoSQL(this, "tblReceipt", MainClass.Functions.enmType.Update, editID);
                    
            }

            catch (Exception ex)
            {
                MessageBox.Show("Save error: " + ex.Message);
                return;
            }

            MainClass.Functions.ClearAll(this);
            mainID.Text = "0";
            editID = 0;
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.ClearSelection();
            description.Text = "";
            NetAmount.Text = "";
            PersonID.SelectedIndex = -1;

            ShowMsg("Receipt saved successfully!", MessageDialogIcon.Information);
        }

        public override void btnDelete_Click(object sender, EventArgs e)
        {
            MainClass.Functions.AutoSQL(this, "tblReceipt", MainClass.Functions.enmType.Delete, editID);
            editID = 0;
            MainClass.Functions.ClearAll(this);
        }

  

        private void ShowMsg(string message, MessageDialogIcon icon)
        {
            guna2MessageDialog1.Parent = this;
            guna2MessageDialog1.Style = MessageDialogStyle.Dark;
            guna2MessageDialog1.Icon = icon;
            guna2MessageDialog1.Caption = "Billing System";
            guna2MessageDialog1.Text = message;
            guna2MessageDialog1.Buttons = MessageDialogButtons.OK;
            guna2MessageDialog1.Show();
        }
    }
}