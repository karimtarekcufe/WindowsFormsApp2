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
    public partial class deleteguest : Form
    {
        Controller cont1;
        int cid;

        public deleteguest(Form3 f,int id)
        {
            f.Close();
            cid = id;
            InitializeComponent();
            comboBox2.Enabled = false;

            cont1 = new Controller();
            comboBox1.DataSource = cont1.selectallidmusician(cid);
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "id";

        }

        private void deleteguest_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
            comboBox2.DataSource=cont1.selctguestname(comboBox1.Text);
            comboBox2.DisplayMember = "Guestname";
            comboBox2.ValueMember="id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox2.Enabled==true && !string.IsNullOrEmpty(comboBox2.Text))
            {
               int res= cont1.deleteguest(Convert.ToString(comboBox2.SelectedValue));
                if (res == 1)
                {
                    MessageBox.Show("sucessfully deleted guest");
                }
            }
        }
    }
}
