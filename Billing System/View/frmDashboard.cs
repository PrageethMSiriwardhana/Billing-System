using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Billing_System.View
{
    public partial class frmDashboard : Sample
    {
        string conStr = @"Data Source=.\sqlexpress;Initial Catalog=BillingSystem;Integrated Security=True;";

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            cmbYearSelector.SelectedIndexChanged += cmbYearSelector_SelectedIndexChanged;
            cmbBarYear.SelectedIndexChanged += cmbBarYear_SelectedIndexChanged;
            LoadBarYearsToCombo(); // call once at startup


            LoadTotalProducts();
            LoadTotalCustomers();
            LoadTotalSuppliers();
            LoadTotalSales();
            LoadTotalPayments();
            LoadTotalReceipts();
            LoadTotalRevenue();
            LoadTotalPurchases();
            LoadDueCustomers();
            LoadTotalInvoices();
            LoadYearsToCombo();



        }


        private void LoadBarYearsToCombo()
        {
            cmbBarYear.Items.Clear();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string qry = "SELECT DISTINCT YEAR(mdate) AS SaleYear FROM tblInvMain ORDER BY SaleYear DESC";
                SqlCommand cmd = new SqlCommand(qry, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbBarYear.Items.Add(reader["SaleYear"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading years: " + ex.Message);
                }
            }

            if (cmbBarYear.Items.Count > 0)
                cmbBarYear.SelectedIndex = 0;
        }

        private void cmbBarYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedYear = cmbBarYear.SelectedItem.ToString();
            LoadDonutChart(selectedYear);
        }


        private void LoadDonutChart(string selectedYear)
        {
            chartDonut.Series.Clear();
            chartDonut.Titles.Clear();
            chartDonut.Legends.Clear();
            chartDonut.Annotations.Clear();

            int totalSales = 0;
            Dictionary<string, int> paymentData = new Dictionary<string, int>();

            string conStr = @"Data Source=.\sqlexpress;Initial Catalog=BillingSystem;Integrated Security=True;";
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string qry = @"
        SELECT pType, COUNT(*) AS Count
        FROM tblInvMain
        WHERE YEAR(mdate) = @year
        GROUP BY pType";

                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@year", selectedYear);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string type = reader["pType"].ToString();
                        int count = Convert.ToInt32(reader["Count"]);
                        paymentData[type] = count;
                        totalSales += count;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading donut chart: " + ex.Message);
                    return;
                }
            }

            // Chart styling
            chartDonut.BackColor = Color.FromArgb(22, 28, 36);
            chartDonut.ChartAreas[0].BackColor = Color.FromArgb(22, 28, 36);
            chartDonut.BorderSkin.SkinStyle = BorderSkinStyle.None;

            // Setup Series
            Series s = new Series("Payments");
            s.ChartType = SeriesChartType.Doughnut;
            s["PieLabelStyle"] = "Disabled";
            s.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Custom pastel purple tones
            Dictionary<string, Color> customColors = new Dictionary<string, Color>
    {
        { "Cash", ColorTranslator.FromHtml("#A237DA") },     // Light violet
        { "Credit", ColorTranslator.FromHtml("#9356DC") }    // Darker purple
    };

            foreach (var item in paymentData)
            {
                int index = s.Points.AddXY(item.Key, item.Value);
                s.Points[index].Color = customColors.ContainsKey(item.Key) ? customColors[item.Key] : Color.Gray;
                s.Points[index].LegendText = item.Key;
                s.Points[index].ToolTip = $"{item.Key}: {item.Value}"; // Hover Tooltip
            }

            chartDonut.Series.Add(s);

            // Legend
            Legend legend = new Legend();
            legend.Docking = Docking.Right;
            legend.LegendStyle = LegendStyle.Table;
            legend.ForeColor = Color.White;
            legend.BackColor = Color.Transparent;
            legend.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            chartDonut.Legends.Add(legend);

            // Center label
            TextAnnotation centerText = new TextAnnotation();
            centerText.Text = "Sales\n" + totalSales.ToString();
            centerText.ForeColor = Color.White;
            centerText.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            centerText.Alignment = ContentAlignment.MiddleCenter;
            centerText.AnchorX = 50;
            centerText.AnchorY = 50;
            centerText.AnchorAlignment = ContentAlignment.MiddleCenter;
            centerText.AxisX = chartDonut.ChartAreas[0].AxisX;
            centerText.AxisY = chartDonut.ChartAreas[0].AxisY;
            centerText.ClipToChartArea = chartDonut.ChartAreas[0].Name;
            chartDonut.Annotations.Add(centerText);

            // Add title
            chartDonut.Titles.Clear();
            chartDonut.Titles.Add(new Title
            {
                Text = $"Sales by Payment Type - {selectedYear}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                Alignment = ContentAlignment.TopCenter
            });

        }






        private void LoadYearsToCombo()
        {
            cmbYearSelector.Items.Clear();
            string conStr = @"Data Source=.\sqlexpress;Initial Catalog=BillingSystem;Integrated Security=True;";
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string qry = "SELECT DISTINCT YEAR(mdate) AS SaleYear FROM tblInvMain ORDER BY SaleYear DESC";
                SqlCommand cmd = new SqlCommand(qry, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbYearSelector.Items.Add(reader["SaleYear"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading years: " + ex.Message);
                }
            }

            if (cmbYearSelector.Items.Count > 0)
                cmbYearSelector.SelectedIndex = 0;
        }

        private void cmbYearSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedYear = cmbYearSelector.SelectedItem.ToString();
            LoadMonthlySalesChart(selectedYear);
        }


        private void LoadMonthlySalesChart(string selectedYear)
        {
            chartAreaSales.Series.Clear();
            chartAreaSales.Titles.Clear();
            chartAreaSales.ChartAreas[0].BackColor = Color.FromArgb(22, 28, 36);
            chartAreaSales.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            chartAreaSales.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            chartAreaSales.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(35, 40, 50);
            chartAreaSales.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(35, 40, 50);

            chartAreaSales.Legends[0].Docking = Docking.Right;
            chartAreaSales.Legends[0].LegendStyle = LegendStyle.Table;
            chartAreaSales.Legends[0].ForeColor = Color.White;
            chartAreaSales.Legends[0].BackColor = Color.Transparent;

            chartAreaSales.Titles.Add("Monthly Product Sales - " + selectedYear);
            chartAreaSales.Titles[0].ForeColor = Color.White;
            chartAreaSales.Titles[0].Font = new Font("Segoe UI", 11, FontStyle.Bold);

            // 12 months
            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            // Palette colors
            List<Color> palette = new List<Color>
    {
        ColorTranslator.FromHtml("#A32CC4"), ColorTranslator.FromHtml("#7A4E9B"), ColorTranslator.FromHtml("#710193"),
        ColorTranslator.FromHtml("#630A36"), ColorTranslator.FromHtml("#E3BFF6"), ColorTranslator.FromHtml("#401A35"),
        ColorTranslator.FromHtml("#A1845A"), ColorTranslator.FromHtml("#B55FCF"), ColorTranslator.FromHtml("#663046"),
        ColorTranslator.FromHtml("#6BE6F6"), ColorTranslator.FromHtml("#4D0F28"), ColorTranslator.FromHtml("#311432")
    };

            string conStr = @"Data Source=.\sqlexpress;Initial Catalog=BillingSystem;Integrated Security=True;";
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string qry = @"
        SELECT 
            p.pName AS ProductName,
            DATENAME(MONTH, m.mdate) AS SaleMonth,
            MONTH(m.mdate) AS MonthNum,
            SUM(d.Amount) AS TotalSales
        FROM 
            tblInvDetail d
        JOIN 
            tblInvMain m ON d.mainID = m.mainID
        JOIN 
            tblProduct p ON d.proID = p.proID
        WHERE 
            YEAR(m.mdate) = @year
        GROUP BY 
            p.pName, DATENAME(MONTH, m.mdate), MONTH(m.mdate)
        ORDER BY 
            p.pName, MonthNum;";

                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@year", selectedYear);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    Dictionary<string, Dictionary<int, double>> data = new Dictionary<string, Dictionary<int, double>>();

                    while (reader.Read())
                    {
                        string product = reader["ProductName"].ToString();
                        int monthNum = Convert.ToInt32(reader["MonthNum"]);
                        double total = Convert.ToDouble(reader["TotalSales"]);

                        if (!data.ContainsKey(product))
                            data[product] = new Dictionary<int, double>();

                        data[product][monthNum] = total;
                    }

                    int colorIndex = 0;

                    foreach (var product in data)
                    {
                        Series s = new Series(product.Key); // ✅ fixed
                        s.ChartType = SeriesChartType.Area;
                        s.BorderWidth = 0;
                        s.Color = palette[colorIndex % palette.Count];
                        colorIndex++;

                        for (int i = 1; i <= 12; i++)
                        {
                            double val = product.Value.ContainsKey(i) ? product.Value[i] : 0;
                            s.Points.AddXY(months[i - 1], val);
                        }

                        chartAreaSales.Series.Add(s);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading monthly sales: " + ex.Message);
                }
            }
        }




        private void LoadTotalProducts()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string qry = "SELECT COUNT(*) FROM tblProduct";
                SqlCommand cmd = new SqlCommand(qry, con);
                try
                {
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    cardProductValue.Text = count.ToString("00");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading total products: " + ex.Message);
                }
            }
        }

        private void LoadTotalCustomers()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string qry = "SELECT COUNT(*) FROM tblCustomer";
                SqlCommand cmd = new SqlCommand(qry, con);
                try
                {
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    cardCustomersValue.Text = count.ToString("00");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading total customers: " + ex.Message);
                }
            }
        }

        private void LoadTotalSuppliers()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string qry = "SELECT COUNT(*) FROM tblSupplier";
                SqlCommand cmd = new SqlCommand(qry, con);
                try
                {
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    cardSuppliersValue.Text = count.ToString("00");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading total suppliers: " + ex.Message);
                }
            }
        }

        private void LoadTotalSales()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string qry = "SELECT COUNT(*) FROM tblInvMain WHERE pType = 'Cash'";
                SqlCommand cmd = new SqlCommand(qry, con);
                try
                {
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    cardTotalSalesValue.Text = count.ToString("00");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading total sales: " + ex.Message);
                }
            }
        }

        private void LoadTotalPayments()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string qry = "SELECT COUNT(*) FROM tblPayment";
                SqlCommand cmd = new SqlCommand(qry, con);
                try
                {
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    cardTotalPaymentsValue.Text = count.ToString("00");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading total payments: " + ex.Message);
                }
            }
        }

        private void LoadTotalReceipts()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string qry = "SELECT COUNT(*) FROM tblReceipt";
                SqlCommand cmd = new SqlCommand(qry, con);
                try
                {
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    cardTotalReciptsValue.Text = count.ToString("00"); // Eg: 01, 02, etc.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading total receipts: " + ex.Message);
                }
            }
        }


        private void LoadTotalRevenue()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string qry = "SELECT ISNULL(SUM(NetAmount), 0) FROM tblInvMain";
                SqlCommand cmd = new SqlCommand(qry, con);
                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    decimal totalRevenue = Convert.ToDecimal(result);
                    cardTotalRevenueValue.Text = totalRevenue.ToString("N2"); // Format: 1,234.00
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading total revenue: " + ex.Message);
                }
            }
        }


        private void LoadTotalPurchases()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string qry = "SELECT ISNULL(SUM(NetAmount), 0) FROM tblInvMain WHERE mType = 'Purchase'";
                SqlCommand cmd = new SqlCommand(qry, con);
                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    decimal totalPurchases = Convert.ToDecimal(result);
                    cardTotalPurchasesValue.Text = totalPurchases.ToString("N2"); // Eg: 4,300.00
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading total purchases: " + ex.Message);
                }
            }
        }

        private void LoadDueCustomers()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string qry = "SELECT COUNT(DISTINCT PersonID) FROM tblInvMain WHERE mDueDate < GETDATE()";
                SqlCommand cmd = new SqlCommand(qry, con);
                try
                {
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    cardDueCustomersValue.Text = count.ToString("00");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading due customers: " + ex.Message);
                }
            }
        }


        private void LoadTotalInvoices()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string qry = "SELECT COUNT(*) FROM tblInvMain";
                SqlCommand cmd = new SqlCommand(qry, con);
                try
                {
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    cardTotalInvoicesValue.Text = count.ToString("00"); // Format it with 2 digits
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading total invoices: " + ex.Message);
                }
            }
        }








    }
}
