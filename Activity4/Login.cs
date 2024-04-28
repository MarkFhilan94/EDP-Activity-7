using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Activity4
{
    public partial class Login : Form
    {
        // Instantiate MySqlConnectionManager
        private MySqlConnectionManager connectionManager = new MySqlConnectionManager();
        string connectionString = "server=127.0.0.1;uid=root;pwd=truman94;database=activity2";

        public Login()
        {
            InitializeComponent();
        }

        private void recover_pass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            PassRecover change = new PassRecover();
            change.Show();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            // Retrieve username and password from textboxes
            string customerName = username.Text;
            string pass = password.Text;

            // Check if the username and password are correct
            if (IsValidUser(customerName, pass))
            {
                UpdateActiveStatus(customerName, "Active"); // Update active status to "Yes"
                MessageBox.Show("Login successful!");
                // Redirect to the next form
                Dashboard board = new Dashboard(customerName);
                board.Show();

                // Close the current login form
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsValidUser(string customerName, string pass)
        {
            bool isValid = false;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM customers WHERE customer_name = @customerName AND password = @pass";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@customerName", customerName);
                command.Parameters.AddWithValue("@pass", pass); // Fixed parameter name

                try
                {
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    isValid = count > 0;
                }
                catch (Exception ex)
                {
                    // Log the exception for debugging purposes
                    Console.WriteLine("Error: " + ex.Message);
                    // Return false to indicate login failure
                    return false;
                }
            }

            return isValid;
        }
        private void UpdateActiveStatus(string username, string status)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE customers SET active_status = @status WHERE customer_name = @username";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@username", username);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating active status: " + ex.Message);
            }
        }
        private void btn_connect_Click(object sender, EventArgs e)
        {
            // Call the OpenConnection method of MySqlConnectionManager
            bool isConnected = connectionManager.OpenConnection();

            // Check if the connection was successful
            if (isConnected)
            {
                MessageBox.Show("Connection to MySQL database established successfully.");
                // Proceed with further actions as needed
            }
            else
            {
                MessageBox.Show("Failed to establish connection to MySQL database.");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }

    public class MySqlConnectionManager
    {
        
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        // Constructor
        public MySqlConnectionManager()
        {
            Initialize();
        }

        // Initialize values
        private void Initialize()
        {
            server = "127.0.0.1";
            database = "activity2";
            uid = "root";
            password = "truman94";
            string connectionString;
            connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            connection = new MySqlConnection(connectionString);
        }

        // Open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException)
            {
                // Handle exception
                return false;
            }
        }
    }
}
