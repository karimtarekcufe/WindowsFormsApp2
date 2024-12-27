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

     
    public partial class addguest : Form
    {
        Controller cont1;
        int cid;
        
        public addguest(Form3 f,int id)
        {
            cid = id;

            cont1 = new Controller();
            InitializeComponent();
            comboBox1.DataSource = cont1.selectallidmusician(cid);
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "id";




        }

        private void addguest_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Please choose a request id.");
                return;
            }
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter a name.");
                return;
            }

            if (!textBox1.Text.All(char.IsLetter))
            {
                MessageBox.Show("Name must contain only alphabetic characters.");
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please enter a phone number.");
                return;
            }
            foreach (char c in textBox2.Text)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("Phone number must contain only digits.");
                    return;
                }
            }

            if (textBox2.Text.Length != 10)
            {
                MessageBox.Show("Phone number must be exactly 10 digits.");
                return;
            }

            if (cont1.checkcapacity(comboBox1.Text) < Convert.ToInt32(cont1.getassignedhallidcsapacity(comboBox1.Text).Rows[0][0]))
            {
                int res=cont1.addtoguestlist(comboBox1.Text, textBox1.Text, textBox2.Text,textBox3.Text);
                if (res == 1)
                {
                    MessageBox.Show("sucessfull inserion");
                }
            }
            else
            {
                MessageBox.Show("capacity full!!");
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
