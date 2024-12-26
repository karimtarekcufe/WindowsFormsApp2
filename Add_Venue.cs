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
    public partial class Add_Venue : Form
    {
        string name;
        string id;
        Controller c= new Controller();
       
        public Add_Venue(string name)
        {
            InitializeComponent();
            this.name = name;
            object temp = c.getID(name).Rows[0][0];
            id = temp.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hallName = textBox1.Text.Trim();
            string location = textBox2.Text.Trim();
            string capacityText = textBox4.Text.Trim();
            string sizeText = textBox3.Text.Trim();


            if (string.IsNullOrWhiteSpace(hallName))
            {
                MessageBox.Show("Hall Name cannot be empty or whitespace.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (string.IsNullOrWhiteSpace(location))
            {
                MessageBox.Show("Location cannot be empty or whitespace.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (string.IsNullOrWhiteSpace(capacityText) || !int.TryParse(capacityText, out int capacity) || capacity <= 0)
            {
                MessageBox.Show("Capacity must be a valid positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!string.IsNullOrWhiteSpace(sizeText) && (!double.TryParse(sizeText, out double size) || size <= 0))
            {
                MessageBox.Show("Size must be a valid positive number if provided.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int result = 0;
            if (!string.IsNullOrWhiteSpace(sizeText))
            {
                result = c.insertHall(id, hallName, location, capacityText, sizeText);
            }
            else
            {
                result = c.insertHall(id, hallName, location, capacityText);
            }

            if (result>0)
            {
                MessageBox.Show("Venue added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to add venue!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
    }
    }

