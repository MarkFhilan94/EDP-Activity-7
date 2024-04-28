using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity4
{
    public partial class Report : Form
    {
        private string customerName;
        public Report(string customerName)
        {
            InitializeComponent();
            this.customerName = customerName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var return1 = new Dashboard(customerName);
            return1.Show();
        }
    }
}
