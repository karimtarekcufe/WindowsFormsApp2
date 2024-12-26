using DBapplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Timers;  // For the advanced Timer (if needed)

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Controller controller1;
        private int failedAttempts = 0; 
        private System.Windows.Forms.Timer hideButtonTimer;  
        //hiiiii
        public Form1()
        {
            controller1 = new Controller();
            InitializeComponent();

            // Initialize the timer
            hideButtonTimer = new System.Windows.Forms.Timer(); 
            hideButtonTimer.Interval = 5000;  
            hideButtonTimer.Tick += HideButtonTimer_Tick; 
        }

        public Controller GetController()
        {
            return controller1;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Username and password should be entered");
            }
            else
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Username should be entered");
                }
                else if (string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Password should be entered");
                }
                else
                {
                    int result = controller1.checkusername(textBox1.Text);
                    if (result != 0)
                    {
                        int res = controller1.checkpasssword(textBox1.Text, textBox2.Text);
                        if (res == 0)
                        {
                            MessageBox.Show("Username does not match password");

                            failedAttempts++;
                            if (failedAttempts >= 3)
                            {
                                hideButtonTimer.Start();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Login successful!");
                            DataTable dt = controller1.selectroles(textBox1.Text, textBox2.Text);
                            if (dt.Rows[0][0] != null)
                            { 
                                string role = Convert.ToString(dt.Rows[0][0]);
                                string username = Convert.ToString(dt.Rows[0][1]);
                                if (role != "Admin")
                                {
                                    if (role == "Entertainer")
                                    {
                                        DataTable dt2 = controller1.getID(textBox1.Text, textBox2.Text);
                                        int id = Convert.ToInt32(dt2.Rows[0][0]);
                                        Form3 form3 = new Form3(this, role, username, id);
                                        form3.Show();
                                    }
                                    else
                                    {
                                        Form3 form3 = new Form3(this, role, username, -1);
                                        form3.Show();
                                    }
                                }
                                else
                                {
                                    Admin f1 = new Admin(this );
                                    f1.Show();
                                    this.Hide();
                                }
                            }

                            // Reset failed attempts on successful login
                            failedAttempts = 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Non-matching username found");
                    }
                }
            }
        }

        private void HideButtonTimer_Tick(object sender, EventArgs e)
        {
            Invoke(new Action(() => button1.Visible = false));

            hideButtonTimer.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(this);
            f.Show();

        }
    }
}
