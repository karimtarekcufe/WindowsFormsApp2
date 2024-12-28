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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
            Controller controller1 = new Controller();
        public Form2(Form1 f)
        {
        



            InitializeComponent();
            SetControlVisibility(comboBox1.Text);
            label1.Visible= true;
            label2.Visible = true;
            label3.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            comboBox2.Visible = false;
            label14.Visible = true;
            textBox11.Visible = true;
            
            

            switch (comboBox1.Text)
            {
                
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
            if (checkBox1.Checked)
            {
                
                if (textBox11.Text!=textBox2.Text && textBox11.TextLength>0)
                {
                    MessageBox.Show("Both passwords aren't identical!");
                    return;
                    
                }
                if (textBox2.TextLength< 8 && textBox2.TextLength>0) { 
                    MessageBox.Show( "Password must be at least 8 characters long!");
                    return;
                    
                }
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Username must be entered!");
                    label15.Visible = true;
                    return;
                }
                else
                {
                    label15.Visible = false;
                   
                }
                if (textBox1.Text.All(char.IsDigit)&&!string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Error: Username can't be only numbers!");
                    return ;
                }
                if (textBox2.TextLength == 0)
                {
                    MessageBox.Show("You must enter a password!");
                    label16.Visible = true;
                    return;
                }
                else
                {
                    label16.Visible = false;
                }
                if (string.IsNullOrEmpty(textBox11.Text) && textBox2.TextLength > 7)
                {
                    MessageBox.Show("You must Re-type password!");
                    label17.Visible = true;
                    return;
                }
                else
                {
                    label17.Visible = false;
                }
                if (comboBox1.SelectedIndex == -1) 
                {
                    MessageBox.Show("No Role is selected!");
                    label18.Visible = true;
                    return;
                }
                
                else
                {
                    label18.Visible = false;
                    string role = comboBox1.SelectedItem.ToString();
                    

                    if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Username and password must be entered");
                        return;
                    }
                    else if (string.IsNullOrEmpty(textBox1.Text))
                    {
                        MessageBox.Show("Username must be entered!");
                        return;
                    }
                    else if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("You must enter a password!");
                        return;
                    }
                    if (role == "Entertainer")
                    {
                        
                        

                        if (string.IsNullOrEmpty(textBox10.Text))
                        {
                            MessageBox.Show("Make sure to write Price by Hour!");
                            return;
                        }
                        if (comboBox2.SelectedIndex == -1)
                        {
                            MessageBox.Show("Choose Entertainer Type!");
                            return;
                        }
                        string entertainer = comboBox2.SelectedItem.ToString();
                        if (entertainer == "Musician")
                            {
                            //if (string.IsNullOrEmpty(textBox3.Text))
                            //{
                            //    MessageBox.Show("Make sure to write Band Name!");
                            //}
                            //if (string.IsNullOrEmpty(textBox4.Text))
                            //    {
                            //        MessageBox.Show("Make sure to write Genre!");
                            //    return;
                            //}
                            }
                            else if (entertainer == "Photographer")
                            {
                            //    if (string.IsNullOrEmpty(textBox3.Text))
                            //    {
                            //        MessageBox.Show("Make sure to write Camera Type!");
                            //    return;
                            //}
                            }
                            else if (entertainer == "Florist")
                            {
                            //    if (string.IsNullOrEmpty(textBox3.Text))
                            //    {
                            //        MessageBox.Show("Make sure to write Arrangement!");
                            //    return;
                            //}
                            }
                        
                    }else if(role == "HallProvider")
                    {
                        
                        if (string.IsNullOrEmpty(textBox3.Text)|| string.IsNullOrEmpty(textBox4.Text)|| string.IsNullOrEmpty(textBox5.Text))
                        {
                            MessageBox.Show("Make sure to write All Data!");
                            return;
                        }
                        if (string.IsNullOrEmpty(textBox10.Text))
                        {
                            MessageBox.Show("Please Write your Booking Price!");
                            return;
                        }
                        if (textBox4.Text.All(char.IsDigit) && !string.IsNullOrEmpty(textBox4.Text))
                        {
                            MessageBox.Show("Error: Location can't be only numbers!");
                            return;
                        }
                        if (!int.TryParse(textBox5.Text, out int result) && !string.IsNullOrEmpty(textBox5.Text))
                        {
                            MessageBox.Show("Error: Capacity must be numbers!");
                            return;
                        }
                        if (!int.TryParse(textBox6.Text, out int result2) && !string.IsNullOrEmpty(textBox6.Text))
                        {
                            MessageBox.Show("Error: Size must be numbers!");
                            return;
                        }
                        if (!int.TryParse(textBox10.Text, out int result3) && !string.IsNullOrEmpty(textBox10.Text))
                        {
                            MessageBox.Show("Error: Booking Price must be numbers!");
                            return;
                        }
                    }
                    else if(role == "Customer")
                    {
                        if (string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text) || string.IsNullOrEmpty(textBox9.Text))
                        {
                            MessageBox.Show("All payment data are required!");

                            return;
                        }
                        //if (string.IsNullOrEmpty(textBox3.Text))
                        //{
                        //    MessageBox.Show("Make sure to write Address!");
                        //    return;
                        //}
                        if (string.IsNullOrEmpty(textBox4.Text))
                        {
                            MessageBox.Show("Please Write your Budget!");
                            return;
                        }
                        if (string.IsNullOrEmpty(textBox5.Text))
                        {
                            MessageBox.Show("Please Enter your Name!");
                            return;
                        }

                        if (string.IsNullOrEmpty(textBox6.Text))
                        {
                            MessageBox.Show("Please Write your Telephone Number!");
                            return;
                        }
                        if (!textBox5.Text.All(char.IsLetter) && !string.IsNullOrEmpty(textBox5.Text))
                        {
                            MessageBox.Show("Error: Name can't include numbers!");
                            return; 
                        }
                        if (!int.TryParse(textBox4.Text, out int result) && !string.IsNullOrEmpty(textBox4.Text))
                        {
                            MessageBox.Show("Error: Budget must be numbers!");
                            return;
                        }
                        if (!int.TryParse(textBox6.Text, out int result2) && !string.IsNullOrEmpty(textBox6.Text))
                        {
                            MessageBox.Show("Error: Telephone must be numbers!");
                            return;
                        }
                        
                       
                    }
                }
                if (controller1.CheckExistance(textBox1.Text)==0)
                {
                    string role = comboBox1.SelectedItem.ToString();
                    bool signed=false;
                   string pass=  Password.HashPassword(textBox2.Text);
                    controller1.InsertUserData(textBox1.Text, pass, role);

                    switch (role)
                    {

                        case "Customer":
                            controller1.InsertPayment(textBox7.Text, textBox8.Text, textBox9.Text);
                            controller1.InsertCustomer(controller1.GetLatestUserID(), textBox3.Text, controller1.GetLatestPaymentID(), Convert.ToDecimal(textBox4.Text), textBox5.Text, textBox6.Text);
                            signed = true;
                            break;
                        case "HallProvider":
                            controller1.InsertHallProvider(controller1.GetLatestUserID(),textBox3.Text,textBox4.Text,Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text) ,textBox10.Text);
                            signed = true;
                            break;
                        case "Caterer":
                            //add insertcaterer (not mine)
                            signed = true;
                            break;
                        case "Entertainer":
                            string entertainer = comboBox2.SelectedItem.ToString();
                            controller1.InsertEntertainer(controller1.GetLatestUserID(),textBox1.Text,entertainer,Convert.ToInt32(textBox10.Text));

                            switch (entertainer)
                            {

                                case "Florist":
                                    controller1.InsertFlorist(controller1.GetLatestEntertainerID(),textBox3.Text);
                                    break;
                                case "Photographer":
                                    controller1.InsertPhotographer(controller1.GetLatestEntertainerID(), textBox3.Text);
                                    break;
                                case "Musician":
                                    controller1.InsertMusician(controller1.GetLatestEntertainerID(),textBox3.Text, textBox4.Text);
                                    break;

                            }

                            signed = true;
                            break;
                    }
                    if (signed)
                    {
                       
                        MessageBox.Show("Signed Up Successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Try Again!");
                    }
                }
                else
                {
                    MessageBox.Show("User already exists!");
                }

            }
            else
            {               
                MessageBox.Show("You must accept Terms of Service!");
            }
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
            string role = comboBox1.SelectedItem.ToString();

            
            switch (role)
            {
                
                case "Customer":
                    label4.Text = "Address";
                    label4.Visible = true;
                    textBox3.Visible= true;
                    label5.Text = "Budget";
                    label5.Visible = true;
                    textBox4.Visible = true;
                    label8.Visible = true;
                    label9.Visible = true;
                    label10.Visible = true;
                    label11.Visible = true;
                    textBox7.Visible = true;
                    textBox8.Visible = true;
                    textBox9.Visible = true;
                    label6.Text = "Name";
                    label6.Visible = true;
                    textBox5.Visible = true;
                    label7.Text = "Telephone";
                    label7.Visible = true;
                    textBox6.Visible = true;
                    break;
                case "HallProvider":
                    label4.Visible=true;
                    textBox3.Visible=true;
                    label5.Visible = true;
                    textBox4.Visible = true;
                    label6.Visible = true;
                    textBox5.Visible = true;
                    label7.Visible = true;
                    textBox6.Visible = true;
                    label13.Text = "Booking Price";
                    label13.Visible = true;
                    textBox10.Visible = true;
                    break;
                case "Caterer":
                    

                    break;
                case "Entertainer":
                    label19.Visible = true;
                    label12.Visible = true;
                    comboBox2.Visible = true;
                    label13.Visible = true;
                    textBox10.Visible = true;
                    break;
            }
           
            comboBox1.Enabled = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string role = comboBox2.SelectedItem.ToString();
            switch (role)
            {

                case "Florist":
                    label4.Text = "Arrangement";
                    label4.Visible = true;
                    textBox3.Visible = true;
                    break;
                case "Photographer":
                    label4.Text = "Camera Type";
                    label4.Visible = true;
                    textBox3.Visible = true;
                    break;
                case "Musician":
                    label4.Text = "Band Name";
                    label4.Visible = true;
                    textBox3.Visible = true;
                    label5.Text = "Genre";
                    label5.Visible = true;
                    textBox4.Visible = true;
                    break;
               
            }
            
            comboBox2.Enabled = false;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}