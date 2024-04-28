using MySql.Data.MySqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using OfficeOpenXml;
using System.IO;
using MySqlX.XDevAPI.Relational;

namespace Activity4
{
    public partial class Account_settings : Form
    {
        // Define your SqlConnection object and other necessary objects
        MySqlConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=truman94;database=activity2");
        // Declare a field to store the username
        private string customerName;

        public Account_settings(string customerName)
        {
            InitializeComponent();
            this.customerName = customerName;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            // Retrieve username and password from textboxes
            string user = name.Text;
            string passs = pass.Text;
            string names = question.Text;

            // Attempt to connect to the database and insert the new user
            try
            {
                // Open the connection
                connection.Open();

                // Check if username already exists
                string checkQuery = "SELECT COUNT(*) FROM customers WHERE customer_name = @username";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@username", user);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("Username already exists. Please choose a different username.");
                }
                else
                {
                    // Insert the new user
                    string query = "INSERT INTO customers (customer_name, password, recovery_answer) " +
                                   "VALUES (@username, @password, @answer)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@username", user);
                    cmd.Parameters.AddWithValue("@password", passs);
                    cmd.Parameters.AddWithValue("@answer", names);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User created successfully.");
                }

                connection.Close();
                // Reset username and password from textboxes
                name.Text = "";
                pass.Text = "";
                question.Text = "";
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            // Reset username and password from textboxes
            name.Text = "";
            pass.Text = "";
            question.Text = "";
        }


        private void btn_update_Click(object sender, EventArgs e)
        {
            // Retrieve password, new customer name, and recovery answer from textboxes
            string pass = passwords.Text;
            string newName = usernames.Text; // New customer name
            string answer = update_box.Text;

            // Check if any of the textboxes are empty
            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Please enter a new customer name.");
                return; // Exit the method without executing updates
            }
            else if (string.IsNullOrWhiteSpace(pass))
            {              
                MessageBox.Show("Please enter a password.");
                return; // Exit the method without executing updates
            }
            else if (string.IsNullOrWhiteSpace(answer))
            {
                MessageBox.Show("Please enter a recovery answer.");
                return; // Exit the method without executing updates
            }

            try
            {
                connection.Open();

                // Update the password column in the database
                string passwordQuery = "UPDATE customers SET password = CASE WHEN password IS NULL OR password = '' " +
                    "THEN @password ELSE password END WHERE customer_name = @username";

                MySqlCommand passwordCmd = new MySqlCommand(passwordQuery, connection);
                passwordCmd.Parameters.AddWithValue("@username", customerName); // Use customerName directly
                passwordCmd.Parameters.AddWithValue("@password", pass);

                int passwordRowsAffected = passwordCmd.ExecuteNonQuery();

                // Update the recovery_answer column in the database
                string recoveryQuery = "UPDATE customers SET recovery_answer = @Answer WHERE customer_name = @username";

                MySqlCommand recoveryCmd = new MySqlCommand(recoveryQuery, connection);
                recoveryCmd.Parameters.AddWithValue("@username", customerName); // Use customerName directly
                recoveryCmd.Parameters.AddWithValue("@Answer", answer);

                int recoveryRowsAffected = recoveryCmd.ExecuteNonQuery();

                // Update the customer_name column in the database
                string nameQuery = "UPDATE customers SET customer_name = @NewName WHERE customer_name = @OldName";

                MySqlCommand nameCmd = new MySqlCommand(nameQuery, connection);
                nameCmd.Parameters.AddWithValue("@OldName", customerName); // Use customerName directly
                nameCmd.Parameters.AddWithValue("@NewName", newName);

                int nameRowsAffected = nameCmd.ExecuteNonQuery();

                if (passwordRowsAffected > 0 && nameRowsAffected > 0)
                {
                    MessageBox.Show("Password and Username updated successfully.");
                }
                else if (recoveryRowsAffected > 0)
                {
                    MessageBox.Show("Recovery answer updated successfully.");
                }
                else if (nameRowsAffected > 0)
                {
                    MessageBox.Show("Customer name updated successfully.");
                }
                else
                {
                    MessageBox.Show("No rows were updated for customer name or recovery answer, or the user was not found.");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
                usernames.Text = "";
                passwords.Text = "";
                update_box.Text = "";
            }
        }
        private void btn_resets_Click(object sender, EventArgs e)
        {
            // Reset username and password from textboxes
            usernames.Text = "";
            passwords.Text = "";
            update_box.Text = "";
        }
        
        private void btn_display_Click(object sender, EventArgs e)
        {
            try
            {
                // Open the connection
                connection.Open();

                /* Define your query to select the required columns from the customer table
                string query = "SELECT customer_id, customer_name, customer_age, " +
                    "customer_location, active_status FROM customers";
                */
                //Define your query to select the required columns from the customer table
                string query = "SELECT customer_id, customer_name, customer_age, " +
                    "customer_location, budget FROM customers";

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
                            int startRow = 11; // Start from row 11
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
                            ExcelRange dataRangeX = worksheet.Cells[startRow, startColumn + 4, startRow + Table.Rows.Count - 1, startColumn + 4]; // Column G

                            // Create a new chart
                            var chart = graphWorksheet.Drawings.AddChart("Chart1", OfficeOpenXml.Drawing.Chart.eChartType.BarClustered);

                            // Set the title for the chart
                            chart.Title.Text = "Data Analysis";

                            // Add data to the chart
                            var seriesY = chart.Series.Add(dataRangeY.Offset(1, 0), dataRangeY.Offset(1, 0));
                            var seriesX = chart.Series.Add(dataRangeX.Offset(1, 0), dataRangeX.Offset(1, 0));

                            // Set axis titles
                            chart.YAxis.Title.Text = "Budget";
                            chart.XAxis.Title.Text = "Customers";

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

        private void btn_search_Click(object sender, EventArgs e)
        {
            string search_text = search_box.Text.Trim();

            if (!string.IsNullOrEmpty(search_text))
            {
                // Close the connection before searching
                connection?.Close();

                DataTable searchResults = SearchData(search_text);

                dataGridView1.DataSource = searchResults;
            }
        }
        private DataTable SearchData(string searchText)
        {
            DataTable dataTable = new DataTable();

            try
            {
                 connection.Open();

                 string query = "SELECT customer_id, customer_name, customer_age, customer_location FROM customers WHERE customer_name LIKE @SearchText";
                 MySqlCommand command = new MySqlCommand(query, connection);
                 command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                 MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                 adapter.Fill(dataTable);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return dataTable;
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            this.Hide();
            var goBack = new Dashboard(customerName);
            goBack.Show();

        }
    }
}
