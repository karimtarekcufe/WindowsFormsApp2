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
    public partial class AddMenuOption : Form
    {
        Form3 f;
        Controller c;
        int id;
        public AddMenuOption(Form3 f,Controller c,int id)
        {
            this.f = f;
            this.c = c;
            this.id = id;
            InitializeComponent();
        this.FormClosing += AddMenu_FormClosing;

        }

        private void AddMenuOption_Load(object sender, EventArgs e)
        {

        }
        private void AddMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            f.Show();
        }

        private void Okay_Click(object sender, EventArgs e)
        {
            if (FName.Text=="")
            {
                MessageBox.Show("fill the name");
                return;
            }
            string str = Price.Text;
            int result;
            if (int.TryParse(str, out result) &&  str != "")
            {
            int x = c.AddMenuOption(id, FName.Text.ToString(), Convert.ToInt32(Price.Text));
                if (x == 0) { MessageBox.Show("Error in inserting"); }
                else
                {
                    MessageBox.Show("Inserting was successful");
                }
            }
            else
            {
                MessageBox.Show("Enter only numbers in Price section");
            }
        }
    }
}
