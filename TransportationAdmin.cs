using DBapplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class TransportationAdmin : Form
    {
        Admin a;
        Controller c;
        public TransportationAdmin(Admin a, Controller c)
        {
            this.a = a;
            this.c = c;
            InitializeComponent();
            this.FormClosing += TransForm_closing;
        }


        private void TransForm_closing(object sender, FormClosingEventArgs e)
        {
            a.Show();
        }

        private void lowToHigh_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = c.GetTransRatingLtoH();
            dataGridView1.Refresh();
        }

        private void highToLow_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = c.GetTransRatingHtoL();
            dataGridView1.Refresh();
        }
    }
}
