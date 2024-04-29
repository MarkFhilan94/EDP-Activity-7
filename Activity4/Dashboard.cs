using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using OfficeOpenXml; // Add this using directive
using System.IO;

// Dashboards page for this system
namespace Activity4
{   

    public partial class Dashboard : Form
    {
        MySqlConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=truman94;database=activity2");
        // Declare a field to store the username
        private string customerName;

        // Constructor that accepts the username parameter
        public Dashboard(string username)
        {
            InitializeComponent();
            this.customerName = username;

            // Set the LicenseContext property in your application's startup code
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        private void Logout_Click_1(object sender, EventArgs e)
        {
            // Update active status to "Inactive"
            UpdateActiveStatus(customerName, "Inactive");

            // Show the login form
            var loginForm = new Login();
            loginForm.Show();

            // Close the current form
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var about = new AboutBox1();
            about.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var report = new Report(customerName);
            report.Show();
        }

        private void closeTheProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            this.Hide();
            var manage = new Account_settings(customerName);
            manage.Show();
        }

        private void UpdateActiveStatus(string username, string status)
        {
            try
            {
                connection.Open();
                string query = "UPDATE customers SET active_status = @status WHERE customer_name = @username";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@username", username);
                command.ExecuteNonQuery();               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating active status: " + ex.Message);
            }
        }

        private void btn_display_Click(object sender, EventArgs e)
        {
            try
            {
                // Open the connection
                connection.Open();

                // Define your query to select the required columns from both tables
                string query = "SELECT p.product_id, p.product_name, p.tax_price, oi.quantity FROM products p " +
                    "INNER JOIN order_items oi ON p.product_id = oi.product_id";

                // Create a SqlDataAdapter to execute the query and fill the DataTable
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Bind the DataTable to the DataGridView
                Table.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection                
                connection.Close();
            }
        }

        private void btn_display2_Click(object sender, EventArgs e)
        {
            try
            {
                // Open the connection
                connection.Open();

                // Define your query to select the required columns from both tables using INNER JOIN
                string query = "SELECT p.product_id, p.product_name, p.tax_price, c.category_name  " +
                               "FROM products p INNER JOIN categories c ON p.categories_id = c.category_id";

                // Create a MySqlDataAdapter to execute the query and fill the DataTable
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Bind the DataTable to the DataGridView
                Table2.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection                
                connection.Close();
            }

        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls|All Files|*.*";
                openFileDialog.Title = "Select Template Excel File";
                openFileDialog.InitialDirectory = @"F:\Documents";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string templateFilePath = openFileDialog.FileName;

                    // Load the selected Excel template
                    FileInfo templateFile = new FileInfo(templateFilePath);
                    using (ExcelPackage excelPackage = new ExcelPackage(templateFile))
                    {
                        // Access the worksheet in the Excel template
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.FirstOrDefault(sheet => sheet.Name == "Invoice");

                        // Check if worksheet exists
                        if (worksheet != null)
                        {
                            // Set the starting cell where you want to write the data
                            int startRow = 14; // Start from row 14
                            int startColumn = 3; // Start from column C

                            // Fill in the data from the DataGridView into specific cells in the Excel worksheet
                            for (int i = 0; i < Table.Rows.Count; i++)
                            {
                                for (int j = 0; j < Table.Columns.Count; j++)
                                {
                                    // Check for null values and valid indexes before writing to Excel
                                    if (i < Table.Rows.Count && j < Table.Columns.Count && Table.Rows[i].Cells[j].Value != null)
                                    {
                                        worksheet.Cells[startRow + i, startColumn + j].Value = Table.Rows[i].Cells[j].Value;
                                    }
                                }
                            }

                            // Create a new worksheet for the graph
                            ExcelWorksheet graphWorksheet = excelPackage.Workbook.Worksheets.Add("Graph");

                            // Define the range of data for the chart
                            ExcelRange dataRangeY = worksheet.Cells[startRow, startColumn + 1, startRow + Table.Rows.Count - 1, startColumn + 1]; // Column D
                            ExcelRange dataRangeX = worksheet.Cells[startRow, startColumn + 3, startRow + Table.Rows.Count - 1, startColumn + 3]; // Column F

                            // Create a new chart
                            var chart = graphWorksheet.Drawings.AddChart("Chart1", OfficeOpenXml.Drawing.Chart.eChartType.BarClustered);

                            // Set the title for the chart
                            chart.Title.Text = "Data Analysis";

                            // Add data to the chart
                            var seriesY = chart.Series.Add(dataRangeY.Offset(1, 0), dataRangeY.Offset(1, 0));
                            var seriesX = chart.Series.Add(dataRangeX.Offset(1, 0), dataRangeX.Offset(1, 0));

                            // Set axis titles
                            chart.YAxis.Title.Text = "Quantity";
                            chart.XAxis.Title.Text = "Product";

                            // Set the position of the chart
                            chart.SetPosition(1, 0, 4, 0);
                            chart.SetSize(800, 400);


                            // Show SaveFileDialog to allow the user to specify the output file path
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "Excel Files|*.xlsx;*.xls|All Files|*.*";
                            saveFileDialog.Title = "Save Output Excel File";
                            saveFileDialog.InitialDirectory = @"F:\Documents"; // Default to the same directory
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                string outputFile = saveFileDialog.FileName;

                                // Save the modified Excel file with the specified output file path
                                excelPackage.SaveAs(new FileInfo(outputFile));
                                MessageBox.Show("Data exported to Excel successfully.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sheet 'Invoice' not found in the selected Excel file.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Error exporting data to Excel: " + ex.Message);
            }
        }

        private void btn_export2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls|All Files|*.*";
                openFileDialog.Title = "Select Template Excel File";
                openFileDialog.InitialDirectory = @"F:\Documents";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string templateFilePath = openFileDialog.FileName;

                    // Load the selected Excel template
                    FileInfo templateFile = new FileInfo(templateFilePath);
                    using (ExcelPackage excelPackage = new ExcelPackage(templateFile))
                    {
                        // Access the worksheet in the Excel template
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.FirstOrDefault(sheet => sheet.Name == "Invoice");

                        // Check if worksheet exists
                        if (worksheet != null)
                        {
                            // Set the starting cell where you want to write the data
                            int startRow = 10; // Start from row 10
                            int startColumn = 3; // Start from column C

                            // Fill in the data from the DataGridView into specific cells in the Excel worksheet
                            for (int i = 0; i < Table2.Rows.Count; i++)
                            {
                                for (int j = 0; j < Table2.Columns.Count; j++)
                                {
                                    // Check for null values and valid indexes before writing to Excel
                                    if (i < Table2.Rows.Count && j < Table2.Columns.Count && Table2.Rows[i].Cells[j].Value != null)
                                    {
                                        worksheet.Cells[startRow + i, startColumn + j].Value = Table2.Rows[i].Cells[j].Value;
                                    }
                                }
                            }

                            // Create a new worksheet for the graph
                            ExcelWorksheet graphWorksheet = excelPackage.Workbook.Worksheets.Add("Graph");

                            ExcelRange dataRangeY = worksheet.Cells[startRow, startColumn + 1, startRow + Table2.Rows.Count - 1, startColumn + 1]; // Column D
                            ExcelRange dataRangeX = worksheet.Cells[startRow, startColumn + 2, startRow + Table2.Rows.Count - 1, startColumn + 2]; // Column E

                            // Create a new chart
                            var chart = graphWorksheet.Drawings.AddChart("Chart1", OfficeOpenXml.Drawing.Chart.eChartType.BarClustered);

                            // Set the title for the chart
                            chart.Title.Text = "Data Analysis";

                            // Add data to the chart
                            var seriesY = chart.Series.Add(dataRangeY.Offset(1, 0), dataRangeY.Offset(1, 0));
                            var seriesX = chart.Series.Add(dataRangeX.Offset(1, 0), dataRangeX.Offset(1, 0));

                            // Set axis titles
                            chart.YAxis.Title.Text = "Price";
                            chart.XAxis.Title.Text = "Product";

                            // Set the position of the chart
                            chart.SetPosition(1, 0, 4, 0);
                            chart.SetSize(800, 400);


                            // Show SaveFileDialog to allow the user to specify the output file path
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "Excel Files|*.xlsx;*.xls|All Files|*.*";
                            saveFileDialog.Title = "Save Output Excel File";
                            saveFileDialog.InitialDirectory = @"F:\Documents"; // Default to the same directory
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                string outputFile = saveFileDialog.FileName;

                                // Save the modified Excel file with the specified output file path
                                excelPackage.SaveAs(new FileInfo(outputFile));
                                MessageBox.Show("Data exported to Excel successfully.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sheet 'Invoice' not found in the selected Excel file.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Error exporting data to Excel: " + ex.Message);
            }
        }
    }
}
