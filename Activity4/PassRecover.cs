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

namespace Activity4
{
    public partial class PassRecover : Form
    {
        private MySqlConnection connection;
        private PasswordRecoveryManager recoveryManager;

        public PassRecover()
        {
            InitializeComponent();
            // Initialize MySqlConnectionManager with your database details
            string connectionString = "server=127.0.0.1; database=activity2; uid=root; pwd=truman94;";
            connection = new MySqlConnection(connectionString);
            connection.Open();

            // Initialize the PasswordRecoveryManager
            recoveryManager = new PasswordRecoveryManager();
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            string name = username.Text; // Assuming txt_username is the TextBox where the user inputs their username

            if (recoveryManager.UserExists(name))
            {
                string securityQuestion = "What's the name of your mother?"; // Change this to your actual security question
                string answer = Prompt.ShowDialog("Security Question", securityQuestion);

                if (recoveryManager.VerifySecurityAnswer(name, answer))
                {
                    string recoveredPassword = recoveryManager.RecoverPassword(name);
                    MessageBox.Show($"Your password is: {recoveredPassword}", "Password Recovery");
                }
                else
                {
                    MessageBox.Show("Incorrect answer to security question.", "Error");
                }
            }
            else
            {
                MessageBox.Show("User does not exist.", "Error");
            }
        }
    }

    public class PasswordRecoveryManager
    {
        private string connectionString = "server=127.0.0.1; database=activity2; uid=root; pwd=truman94;";

        public bool UserExists(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM customers WHERE customer_name = @user";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@user", name);

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }

        public bool VerifySecurityAnswer(string name, string answer)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM customers WHERE customer_name = @user AND recovery_answer = @answer";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@user", name);
                command.Parameters.AddWithValue("@answer", answer);

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }

        public string RecoverPassword(string user)
        {
            string recoveredPassword = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT password FROM customers WHERE customer_name = @user";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@user", user);

                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    recoveredPassword = result.ToString();
                }
            }

            return recoveredPassword;
        }
    }

    // Custom dialog box for prompting the security question answer
    public static class Prompt
    {
        public static string ShowDialog(string caption, string text)
        {
            Form prompt = new Form();
            prompt.StartPosition = FormStartPosition.CenterScreen; // Center the form on the screen
            prompt.Width = 600; // Increased width for the form
            prompt.Height = 200; // Increased height for the form
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 50, Top = 20, Width = 500, Text = text }; // Increased width for the label
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 500 };
            Button confirmation = new Button() { Text = "Ok", Left = 250, Width = 100, Top = 100 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.ShowDialog();
            return textBox.Text;
        }
    }
}