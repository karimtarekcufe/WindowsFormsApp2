using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBapplication;

namespace WindowsFormsApp2
{
    public partial class Edit : Form
    {
        string id;
        Controller controller = new Controller();
        public Edit(int cid)
        {
            id  = cid.ToString();
            InitializeComponent();
            comboBox1.DataSource = controller.getHalls(id);
            comboBox1.DisplayMember = "HallName";
            comboBox1.ValueMember = "HallID";
            dataGridView1.DataSource = controller.getTransportToDelete(id , comboBox1.SelectedValue.ToString());
            DataTable dt = controller.getHallToUpdate(id, comboBox1.SelectedValue.ToString());
            Nametext.Text = dt.Rows[0][0].ToString();
            textBox4.Text = dt.Rows[0][1].ToString();
            textBox5.Text = dt.Rows[0][2].ToString();    
            textBox6.Text = dt.Rows[0][3].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            
                string type = textBox1.Text.Trim(); 
                string servingLocation = textBox2.Text.Trim(); 
                string pricePerBookingInput = textBox3.Text.Trim();


                if (string.IsNullOrEmpty(type))
                {
                    MessageBox.Show("Type cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(servingLocation))
                {
                    MessageBox.Show("Serving Location cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Focus();
                    return;
                }

                if (!IsValidString(type))
                {
                    MessageBox.Show("Type must only contain letters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }

                if (!IsValidString(servingLocation))
                {
                    MessageBox.Show("Serving Location must only contain letters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Focus();
                    return;
                }
            if (string.IsNullOrEmpty(pricePerBookingInput))
            {
                MessageBox.Show("Price per Booking cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }

            // Check if the input is an integer
            if (!int.TryParse(pricePerBookingInput, out int pricePerBooking))
            {
                MessageBox.Show("Price per Booking must be a valid integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }





            int result = controller.insertTransport(type, servingLocation ,pricePerBookingInput, id , comboBox1.SelectedValue.ToString());
            if (result > 0)
            {
                MessageBox.Show("Transportation Added Successfully.", "Validation Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = controller.getTransportToDelete(id ,comboBox1.SelectedValue.ToString());
            }
            }

            // Helper method to check if the string contains only letters
            private bool IsValidString(string input)
            {
              return input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)); ; 
            }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.getTransportToDelete(id, comboBox1.SelectedValue.ToString());
            DataTable dt = controller.getHallToUpdate(id, comboBox1.SelectedValue.ToString());
            if (dt!=null)
            {
                Nametext.Text = dt.Rows[0][0].ToString();
                textBox4.Text = dt.Rows[0][1].ToString();
                textBox5.Text = dt.Rows[0][2].ToString();
                textBox6.Text = dt.Rows[0][3].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1 || dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select one Transport.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int result = controller.DeleteTransport(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            if (result > 0)
            {
                MessageBox.Show("Succesfully Deleted.", " Deletion Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = controller.getTransportToDelete(id, comboBox1.SelectedValue.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {


           
                // Get the input values
                string name = Nametext.Text.Trim();
                string capacityInput = textBox4.Text.Trim();
                string sizeInput = textBox5.Text.Trim();
                string priceInput = textBox6.Text.Trim();

                // Validate Name
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Nametext.Focus();
                    return ;
                }
                if (!IsValidString(name))
                {
                    MessageBox.Show("Name must contain only letters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Nametext.Focus();
                    return ;
                }

                // Validate Capacity
                if (string.IsNullOrEmpty(capacityInput))
                {
                    MessageBox.Show("Capacity cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox4.Focus();
                    return ;
                }
                if (!IsPositiveInteger(capacityInput))
                {
                    MessageBox.Show("Capacity must be a positive integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox4.Focus();
                    return ;
                }

                // Validate Size (Optional)
                if (!string.IsNullOrEmpty(sizeInput) && !IsPositiveInteger(sizeInput))
                {
                    MessageBox.Show("Size must be a positive integer if provided.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox5.Focus();
                    return ;
                }

                // Validate Price
                if (string.IsNullOrEmpty(priceInput))
                {
                    MessageBox.Show("Price cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox6.Focus();
                    return ;
                }
                if (!IsPositiveInteger(priceInput))
                {
                    MessageBox.Show("Price must be a positive integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox6.Focus();
                    return;
                }

            int result = controller.UpdateVenueData(id, comboBox1.SelectedValue.ToString(), name, capacityInput, sizeInput, priceInput);

            if (result > 0)
            {
                MessageBox.Show("Succesfully Updated.", " Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dt = controller.getHallToUpdate(id, comboBox1.SelectedValue.ToString());
                if (dt != null)
                {
                    Nametext.Text = dt.Rows[0][0].ToString();
                    textBox4.Text = dt.Rows[0][1].ToString();
                    textBox5.Text = dt.Rows[0][2].ToString();
                    textBox6.Text = dt.Rows[0][3].ToString();
                }
                dataGridView1.DataSource = controller.getTransportToDelete(id, comboBox1.SelectedValue.ToString());
                comboBox1.DataSource = controller.getHalls(id);
                comboBox1.DisplayMember = "HallName";
                comboBox1.ValueMember = "HallID";

            }
            else
            {
                MessageBox.Show("An Error has Occured.", " Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
           
        }

          

            // Helper method to check if a string is a positive integer
            private bool IsPositiveInteger(string input)
            {
                return float.TryParse(input, out float result) && result > 0;
            }










        }
    }
    

