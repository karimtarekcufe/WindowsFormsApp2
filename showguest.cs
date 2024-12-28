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
    public partial class showguest : Form
    {
        Controller cont1;
        int cid;
        public showguest(Form3 f,int id)
        {
       
            cont1 = new Controller();
            InitializeComponent();
            cid = id;
            comboBox1.DataSource = cont1.selectallidmusician(cid);
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "id";

        }

        private void showguest_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                dataGridView1.DataSource=cont1.showguestlist(comboBox1.Text);
            }
            else
            {
                MessageBox.Show("please choose a request id");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
