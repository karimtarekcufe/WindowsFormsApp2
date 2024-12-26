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
    public partial class HallProvidersAdmin : Form
    {
        Admin a;
        Controller c;
        public HallProvidersAdmin(Admin a, Controller c)
        {
            this.a = a;
            this.c = c;
            InitializeComponent();
            label1.Hide();
            label2.Hide();
            this.FormClosing += HallPForm_closing;
        }

        private void capacityHtoL_Click(object sender, EventArgs e)
        {
            label1.Hide();
            label2.Hide();
            dataGridView1.DataSource = c.getHallCapHtoL();
            dataGridView1.Refresh();
        }

        private void capacityLtoH_Click(object sender, EventArgs e)
        {
            label1.Hide();
            label2.Hide();
            dataGridView1.DataSource = c.getHallCapLtoH();
            dataGridView1.Refresh();
        }

        private void sizeHtoL_Click(object sender, EventArgs e)
        {
            label1.Hide();
            label2.Hide();
            dataGridView1.DataSource = c.getHallSizeHtoL();
            dataGridView1.Refresh();
        }

        private void sizeLtoH_Click(object sender, EventArgs e)
        {
            label1.Hide();
            label2.Hide();
            dataGridView1.DataSource = c.getHallSizeLtoH();
            dataGridView1.Refresh();
        }

        private void maxCap_Click(object sender, EventArgs e)
        {
            label1.Show();
            label1.Text = c.getHallCapMaxAdmin().ToString();  
        }

        private void minCap_Click(object sender, EventArgs e)
        {
            label1.Show();
            label1.Text = c.getHallCapMinAdmin().ToString();
        }

        private void avgCap_Click(object sender, EventArgs e)
        {
            label1.Show();
            label1.Text = c.getHallCapAvgAdmin().ToString();
        }

        private void MaxSize_Click(object sender, EventArgs e)
        {
            label2.Show();
            label2.Text = c.getHallSizeMaxAdmin().ToString();
        }

        private void MinSize_Click(object sender, EventArgs e)
        {
            label2.Show();
            label2.Text = c.getHallSizeMinAdmin().ToString();
        }

        private void AvgSize_Click(object sender, EventArgs e)
        {
            label2.Show();
            label2.Text = c.getHallSizeAvgAdmin().ToString();
        }
        private void HallPForm_closing(object sender, FormClosingEventArgs e)
        {
            a.Show();
        }
    }
}
