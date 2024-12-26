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
    public partial class EntertainersStatics : Form
    {
        Admin f;
        Controller c;
        public EntertainersStatics(Admin f , Controller c)
        {
            this.f = f;
            this.c = c; 
            InitializeComponent();
            this.FormClosing += Entstatics_FormClosing;
            label1.Hide();

        }

        private void priceHtoLow_Click(object sender, EventArgs e)
        {
            DataTable dt = c.getPriceHtoLEnt();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void priceLtoHigh_Click(object sender, EventArgs e)
        {
            DataTable dt = c.getPriceLtoHEnt();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void Min_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label1.Hide();
                dataGridView1.DataSource = c.getMinEntPriceDT();
                dataGridView1.Refresh();
            }
            else
            {
                label1.Show();
                label1.Text = c.getMinEntPrice().ToString();
            }
        }

        private void Max_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label1.Hide();
                dataGridView1.DataSource = c.getMaxEntPriceDT();
                dataGridView1.Refresh();
            }
            else
            {
                label1.Show();
                label1.Text= c.getMaxEntPrice().ToString();
            }
        }

        private void Avg_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label1.Hide();
                dataGridView1.DataSource = c.getAvgEntPriceDT();
                dataGridView1.Refresh();
            }
            else
            {
                label1.Show();
                label1.Text = c.getAvgEntPrice().ToString();
            }
        }
        private void Entstatics_FormClosing(object sender, EventArgs e)
        {
            f.Show();
        }
        }
}
