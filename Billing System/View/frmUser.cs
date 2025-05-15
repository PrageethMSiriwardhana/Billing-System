using Billing_System.Model;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_System.View
{
    public partial class frmUser : SampleView
    {
        public frmUser()
        {
            InitializeComponent();
            guna2DataGridView1.CellPainting += guna2DataGridView1_CellPainting; // Subscribe to the CellPainting event
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            SetUpGridView(); // Set up the grid view with columns including the image column
            LoadData(); // Load the data into the grid view
        }

        // Set up the DataGridView including an image column for profile pictures
        private void SetUpGridView()
        {
            if (!guna2DataGridView1.Columns.Contains("ProfilePicture"))
            {
                DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                imageCol.Name = "ProfilePicture";
                imageCol.HeaderText = "Profile Picture";
                imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                guna2DataGridView1.Columns.Insert(0, imageCol);
            }
            guna2DataGridView1.RowTemplate.Height = 100;  // Set the row height to 100px for larger image display
        }

        private async void LoadData()
        {



            string qry = @"SELECT u.userID, u.uName 'Name', r.RoleName 'Role', u.uEmail 'Email', u.uPhone 'Phone', u.uPass 'Password', u.uImage
                           FROM tblUser u
                           JOIN tblRole r ON u.uRole = r.RoleID
                           WHERE u.uName LIKE '%" + txtSearch.Text + "%' ORDER BY u.userID";

            DataTable dt = null;

            await Task.Run(() =>
            {
                dt = MainClass.Functions.GetData(qry);
            });

            guna2DataGridView1.DataSource = dt;

            if (guna2DataGridView1.Columns["uImage"] != null)
            {
                guna2DataGridView1.Columns["uImage"].Visible = false;
            }


            if (guna2DataGridView1.Columns["userID"] != null)
            {
                guna2DataGridView1.Columns["userID"].Visible = false; // Hide the userID column
            }



            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.Cells["uImage"].Value != DBNull.Value && row.Cells["uImage"].Value != null)
                {
                    byte[] imgBytes = (byte[])row.Cells["uImage"].Value;
                    if (imgBytes.Length > 0)
                    {
                        Image img = ByteArrayToImage(imgBytes);
                        row.Cells["ProfilePicture"].Value = img;
                    }
                    else
                    {
                        row.Cells["ProfilePicture"].Value = null;
                    }
                }
                else
                {
                    row.Cells["ProfilePicture"].Value = null;
                }
            }

            // Add cell formatting event to mask the password
            guna2DataGridView1.CellFormatting += guna2DataGridView1_CellFormatting;

            SetSrColumnWidth();
        }

        private static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }

        private void SetSrColumnWidth()
        {
            if (guna2DataGridView1.Columns["Sr#"] != null)
            {
                guna2DataGridView1.Columns["Sr#"].Width = 80;
            }
            if (guna2DataGridView1.Columns["userID"] != null)
            {
                guna2DataGridView1.Columns["userID"].Width = 80;
            }
            if (guna2DataGridView1.Columns["ProfilePicture"] != null)
            {
                guna2DataGridView1.Columns["ProfilePicture"].Width = 100;
            }
        }

        // Event to mask password as dots in the DataGridView
        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView1.Columns["Password"].Index && e.Value != null)
            {
                // Mask the password as dots
                e.Value = new string('•', e.Value.ToString().Length);
                e.FormattingApplied = true;
            }
        }

        private void guna2DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView1.Columns["ProfilePicture"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                if (e.Value != null)
                {
                    Image img = (Image)e.Value;
                    int circleSize = 60;
                    int offsetX = (e.CellBounds.Width - circleSize) / 2;
                    int offsetY = (e.CellBounds.Height - circleSize) / 2;
                    Rectangle rect = new Rectangle(e.CellBounds.Left + offsetX, e.CellBounds.Top + offsetY, circleSize, circleSize);

                    using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        path.AddEllipse(rect);
                        e.Graphics.SetClip(path);
                        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                        e.Graphics.DrawImage(img, rect);
                        e.Graphics.ResetClip();
                    }
                }

                e.Handled = true;
            }
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(); // Reload the data when the search text changes
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            new frmUserAdd().ShowDialog();
            LoadData(); // Reload the data after adding a user
        }

        public override void guna2DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells[1].Value); // Get the User ID from the selected row
            new frmUserAdd() { editID = id }.ShowDialog(); // Open the edit form for the selected user
            LoadData(); // Reload the data after editing
        }
    }
}
