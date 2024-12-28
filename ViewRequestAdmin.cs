using DBapplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class ViewRequestAdmin : Form
    {
        Admin f;
        Controller c;
        public ViewRequestAdmin(Admin f, Controller c)
        {
            this.f = f;
            this.c = c;
            InitializeComponent();
            this.FormClosing += ViewReq_closing;
            label1.Hide();
            label2.Hide();
        }

        private void price_high_to_low_Click(object sender, EventArgs e)
        {
            label1.Hide();
            label2.Hide();
            DataTable dt = null;
            if (radioButton2.Checked)
            {
                dt = c.getAlreadyDoneHtoLReq();
            }
            else if(radioButton1.Checked)
            {
                dt = c.getUpcomingReqHtoL();
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();

        }
        private void price_low_to_high_Click(object sender, EventArgs e)
        {
            label1.Hide();
            label2.Hide();
            DataTable dt = null;
            if (radioButton2.Checked)
            {
                dt = c.getAlreadyDoneLtoHReq();
            }
            else if (radioButton1.Checked)
            {
                dt = c.getUpcomingReqLtoH();
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void ViewReq_closing(object sender, EventArgs e)
        {
            f.Show();
        }

        private void ViewRequestAdmin_Load(object sender, EventArgs e)
        {

        }

        private void show_Min_Click(object sender, EventArgs e)
        {
            label1.Show();
            label2.Show();
            label2.Text = c.getMinPrice().ToString();
            label1.Text = "Minimum Price =";
        }

        private void show_Max_Click(object sender, EventArgs e)
        {
            label1.Show();
            label2.Show();
            label2.Text = c.getMaxPrice().ToString();
            label1.Text = "Maximum Price =";
        }

        private void show_Average_Click(object sender, EventArgs e)
        {
            label1.Show();
            label2.Show();
            label2.Text = c.getAvgPrice().ToString();
            label1.Text = "Average Price =";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Show();
            label2.Show();
            label1.Text = "Total Price =";
            label2.Text = c.GetTotalPriceReq().ToString();
        }
    }
}
