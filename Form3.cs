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
        string temprole;
        string username;
        Controller controller1;

        public Form3(Form f ,string role,string name)
        {
            controller1 = new Controller();
            temprole = role;
            username = name;
            f.Hide();
            InitializeComponent();
            label5.Text = role;
            label7.Text = name;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            switch (role)
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
            int cid = selectcid();
            if(temprole== "Customer")
            {
                makerequest makerequest = new makerequest(this,username, cid);
                makerequest.Show();

            }
        }

       public int selectcid()
        {
           DataTable dt= controller1.selectcid(label7.Text);
            return (int) dt.Rows[0][0];

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int cid = selectcid();
            if (temprole == "Customer")
            {
                showrequest srequest = new showrequest(this, cid);
                srequest.Show();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int cid = selectcid();
            if (temprole == "Customer")
            {
                addguest addguest = new addguest(this, cid);
                addguest.Show();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int cid = selectcid();
            if (temprole == "Customer")
            {
                showguest showguest = new showguest(this, cid);
                showguest.Show();

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
    }
}
