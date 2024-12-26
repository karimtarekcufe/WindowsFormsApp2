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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2(Form1 f)
        {
            f.Hide();



            Controller controller1 = new Controller();
            InitializeComponent();
            SetControlVisibility(comboBox1.Text);
            label1.Visible= true;
            label2.Visible = true;
            label3.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;





            switch (comboBox1.Text)
            {
                case "Admin":
                    ShowControls("label1", "label2", "textBox1", "textBox2");
                    break;
                case "Customer":
                    ShowControls("label1", "label2", "textBox1", "textBox2");

                    break;
                case "HallProvider":
                    ShowControls("label1", "label2", "textBox1", "textBox2");

                    break;
                case "Caterer":
                    ShowControls("label1", "label2", "textBox1", "textBox2");

                    break;
                case "Entertainer":
                    ShowControls("label1", "label2", "textBox1", "textBox2");

                    break;



            }


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }


        private void SetControlVisibility(string userRole)
        {
            // Hide all labels and text boxes initially
            foreach (Control control in this.Controls)
            {
                if (control is Label || control is System.Windows.Forms.TextBox)
                {
                    control.Visible = false;
                }
            }


        }
        private void ShowControls(params string[] controlNames)
        {
            foreach (string name in controlNames)
            {
                Control[] controls = this.Controls.Find(name, true);
                if (controls.Length > 0)
                {
                    controls[0].Visible = true;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}