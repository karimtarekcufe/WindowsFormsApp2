using DBapplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        int id;
        Form1 f;
        string temprole;
        string username;
        Controller controller1;

        public Form3(Form1 f ,string role,string name)
        {
            controller1 = new Controller();
            temprole = role;
            username = name;
            f.Hide();
            controlobj = f.GetController();
            id = controller1.getID();
            InitializeComponent();
            label5.Text = role;
            label7.Text = name;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            this.FormClosing += Form3_FormClosing;
            switch (temprole)
            {
               
                case "Admin":
                    break;
                case "Customer":
                    button1.Text = "make request";
                    button2.Text = "show all asssociated requests";
                    button3.Text = "add to guest list";
                    button4.Visible = true;
                    button4.Text = "view guest list";
                    button5.Visible = true;
                    button5.Text = "delete from guest list";
                    button6.Visible = true;
                    button6.Text = "cancel request";



                    break;
                case "HallProvider":
                    { button1.Text = "View Booking";
                      button2.Text = "Add Venue";
                      button3.Text = "Remove Venue";
                      button4.Visible = true;
                      button4.Text = "Edit Venue";
                    }
                    break;
                case "Caterer":
                    break;
                case "Entertainer":
                    string type = controlobj.EntType(ID);
                    button1.Text = "view Requests";
                    switch (type)
                    {
                    case "Musician":
                        label8.Text = "Musician";
                        button2.Text = "Update info";
                        button3.Text = "Delete User";
                        break;
                    case "Florist":
                        label8.Text = "Florist";
                        button2.Text = "Update info";
                        button3.Text = "Delete User";
                        break;
                    case "Photographers":
                        label8.Text = "Photographers";
                        button2.Text = "Update info";
                        button3.Text = "Delete User";
                        button3.Hide();
                        break;
                    }
                    break;



            }
        }

        public Controller GetController()
        {
            return controlobj;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public int selectcid()
        {
            DataTable dt = controller1.selectcid(label7.Text);
            return (int)dt.Rows[0][0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (temprole == "HallProvider")
            {
                View_Booking view_Booking = new View_Booking(username);
                view_Booking.Show();
            }
            int cid = selectcid();
            if (temprole == "Customer")
            {
                makerequest makerequest = new makerequest(this, username, cid);
                makerequest.Show();

            }
            if (temprole == "Entertainer")
            {
                EntRequests f = new EntRequests(this, id);
                f.Show();
                this.Hide();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (temprole == "HallProvider")
            {
                Add_Venue view_Booking = new Add_Venue(username);
                view_Booking.Show();
            }
            int cid = selectcid();
            if (temprole == "Customer")
            {
                showrequest srequest = new showrequest(this, cid);
                srequest.Show();

            }
            if (temprole == "Entertainer")
            {
                UpdateInfoEnt f = new UpdateInfoEnt(this, id, label8.Text);
                f.Show();
            }
        }

        



   

        private void button3_Click(object sender, EventArgs e)
        {
            if (temprole == "HallProvider")
            {
                Remove_Venue remove_Venue = new Remove_Venue(username);
                remove_Venue.Show();
            }
            int cid = selectcid();
            if (temprole == "Customer")
            {
                addguest addguest = new addguest(this, cid);
                addguest.Show();

            }
            if(temprole == "Entertainer")
            {
                DataTable dt = controlobj.getDateEnt(id);
                //DataTable dt2 = controlobj.getStatusEnt(id);
                bool cannotDel = false;
                DateTime currentDate = DateTime.Now;
                if (dt == null)
                {
                    break;
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (currentDate > (DateTime)(dt.Rows[i][0]))
                    {
                        cannotDel = true;
                    }
                }
                if (cannotDel)
                {
                    MessageBox.Show("Cannot delete Enterainer till he finishes all request");
                }
                else
                {
                    DeleteEnt f2 = new DeleteEnt(this, id, label5.Text);
                    f2.Show();
                    this.Hide();
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

     


        private void button4_Click(object sender, EventArgs e)
        {
            int cid = selectcid();
            if (temprole == "Customer")
            {
                showguest showguest = new showguest(this, cid);
                showguest.Show();

            }
            if (temprole == "HallProvider")
            {
                Edit editguest = new Edit(cid);
                editguest.Show();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int cid = selectcid();
            if (temprole == "Customer")
            {
                deleteguest deleteguest = new deleteguest(this, cid);
                deleteguest.Show();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int cid = selectcid();
            if (temprole == "Customer")
            {
                cancelrequest cancel = new cancelrequest(this, cid);
                cancel.Show();

            }
        }
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            f.Show();
        }
    }
}
