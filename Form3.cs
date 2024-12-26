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
    public partial class Form3 : Form
    {
        public Form3(Form f ,string role,string name)
        {
            f.Hide();
            InitializeComponent();
            label5.Text = role;
            label7.Text = name;
            switch (role)
            {
               
                case "Admin":
                    break;
                case "Customer":
                    break;
                case "HallProvider":
                    break;
                case "Caterer":
                    break;
                case "Entertainer":
                    break;



            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
