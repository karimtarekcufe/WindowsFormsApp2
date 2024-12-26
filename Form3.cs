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
        string role;
        string name; 
        public Form3(Form f ,string role,string name)
        {
            f.Hide();
            this.role = role;
            this.name = name;
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
                    { button1.Text = "View Booking";
                      button2.Text = "Add Venue";
                      button3.Text = "Remove Venue";

                    }
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
            if (role == "HallProvider")
            {
                View_Booking view_Booking = new View_Booking(name);
                view_Booking.Show();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (role == "HallProvider")
            {
                Add_Venue view_Booking = new Add_Venue(name);
                view_Booking.Show();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (role == "HallProvider")
            {
                Remove_Venue remove_Venue = new Remove_Venue(name);
                remove_Venue.Show();
            }
        }
    }
}
