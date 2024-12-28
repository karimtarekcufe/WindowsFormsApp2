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
    public partial class modifyrequest: Form
    {
        Controller cont1;
        int cid;
        public modifyrequest(Form3 f,int id)
        {
            cont1 = new Controller();
            f.Close();
            InitializeComponent();
            cid = id;
            comboBox1.DataSource = cont1.selectallidmusician(cid);
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "id";
            textBox1.Visible = false;
            label10.Visible = false;
            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.Name = "Status";
            statusColumn.HeaderText = "Status";
            statusColumn.Width = 300;
            dataGridView5.Columns.Add(statusColumn);

        }

        private void modifyrequest_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    label10.Visible = false;
                    textBox1.Visible = false;
                    label9.Text = "Genre";
                    comboBox3.Visible = true;
                    DataTable dt = cont1.selectgenre();

                    comboBox3.DataSource = dt;
                    comboBox3.ValueMember = "genre";
                    comboBox3.DisplayMember = "genre";


                    break;
                case 1:
                    label10.Visible = false;
                    textBox1.Visible = false;
                    label9.Text = "camera type";
                    comboBox3.Visible = true;
                    dt = cont1.selectcamera();
                    comboBox3.DataSource = dt;
                    comboBox3.ValueMember = "camera";
                    comboBox3.DisplayMember = "camera";

                    break;
                case 2:
                    label10.Visible = false;
                    textBox1.Visible = false;
                    label9.Text = "transportation";
                    comboBox3.Visible = true;

                    dt = cont1.selecttransportation(Convert.ToInt32(cont1.gethallreqid(Convert.ToString(comboBox1.Text)).Rows[0][0]));
                    comboBox3.DataSource = dt;
                    comboBox3.ValueMember = "Type";
                    comboBox3.DisplayMember = "Type";


                    break;
                case 3:

                    label9.Visible = true;
                    label9.Text = "Food";
                    label10.Visible = true;
                    textBox1.Visible = true;
                    label10.Text = "quantity";
                    dt = cont1.selectfood();
                    comboBox3.DataSource = dt;
                    comboBox3.ValueMember = "Fname";
                    comboBox3.DisplayMember = "Fname";
                    break;
                case 4:
                    label10.Visible = false;
                    textBox1.Visible = false;
                    label9.Text = "flower arrangements";
                    dt = cont1.selectflower();
                    comboBox3.DataSource = dt;
                    comboBox3.ValueMember = "Arrangement";
                    comboBox3.DisplayMember = "Arrangement";
                    break;
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int failure = 0;
            int reqid = Convert.ToInt32(comboBox1.Text);
            string reqids=Convert.ToString(comboBox1.Text);
            if (comboBox2.SelectedIndex == 0) // Genre - Musician
                {
                    string genre = comboBox3.SelectedValue.ToString(); // Selected genre from comboBox3
                    DateTime requestDate = Convert.ToDateTime(cont1.getasssignedrequestdate(reqid).Rows[0][0]).Date;

                    // Find the appropriate musician based on the selected genre and request date
                    DataTable musicianDt = cont1.selectappropriatemusician(genre, requestDate.ToString("yyyy-MM-dd"));

                    if (musicianDt != null && musicianDt.Rows.Count > 0)
                    {
                        // Insert musician into the database
                        cont1.insertMusician(reqid, Convert.ToString(musicianDt.Rows[0][0]));
                    }
                    else
                    {
                        // Log failure if no musician found
                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.Cells.Add(new DataGridViewTextBoxCell
                        {
                            Value = $"Failed to assign a musician with the genre {genre} for the selected date."
                        });
                        dataGridView5.Rows.Add(newRow);
                        failure++;
                    }
                }

                // Check if the "Camera Type" service (Photographer) is selected in comboBox2
                else if (comboBox2.SelectedIndex == 1) // Camera Type - Photographer
                {
                    string cameraType = comboBox3.SelectedValue.ToString(); // Selected camera type from comboBox3
                    DateTime requestDate = Convert.ToDateTime(cont1.getasssignedrequestdate(reqid).Rows[0][0]);

                    // Find the appropriate photographer for the selected camera type and request date
                    DataTable photographerDt = cont1.selectAppropriatePhotographer(cameraType, requestDate.ToString("yyyy-MM-dd"));

                    if (photographerDt != null && photographerDt.Rows.Count > 0)
                    {
                        // Insert photographer into the database
                        cont1.insertPhotographer(reqid, Convert.ToString(photographerDt.Rows[0]["PhotographerID"]));
                    }
                    else
                    {
                        // Log failure if no photographer found
                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.Cells.Add(new DataGridViewTextBoxCell
                        {
                            Value = $"Failed to assign a photographer with the camera type {cameraType} for the selected date."
                        });
                        dataGridView5.Rows.Add(newRow);
                        failure++;
                    }
                }

                // Check if the "Transportation" service is selected in comboBox2
                else if (comboBox2.SelectedIndex == 2) // Transportation
                {
                    string transportationType = comboBox3.SelectedValue.ToString(); // Selected transportation type from comboBox3
                    DateTime requestDate = Convert.ToDateTime(cont1.getasssignedrequestdate(reqid).Rows[0][0]);

                    int hallId = Convert.ToInt32(cont1.gethallreqid(Convert.ToString(comboBox1.Text)).Rows[0][0]);

                    // Check available transportation for the selected hall, transportation type, and request date
                    DataTable result = cont1.selectAvailableTransportation(hallId.ToString(), transportationType, requestDate.ToString("yyyy-MM-dd"));

                    if (result != null && result.Rows.Count > 0)
                    {
                        // Insert transportation into the database
                        string transportationId = result.Rows[0]["ID"].ToString();
                        cont1.insertTransportationRequest(reqid.ToString(), transportationId);
                    }
                    else
                    {
                        // Log failure if no transportation found
                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.Cells.Add(new DataGridViewTextBoxCell
                        {
                            Value = $"No available transportation of type {transportationType} found for Hall ID ."
                        });
                        dataGridView5.Rows.Add(newRow);
                        failure++;
                    }
                }

                // Check if the "Food" service is selected in comboBox2
                else if (comboBox2.SelectedIndex == 3) // Food
                {
                    string foodMenu = comboBox3.SelectedValue.ToString(); // Selected food menu from comboBox3
                    string quantity = textBox1.Text; // Quantity from textBox3

                    DateTime requestDate = Convert.ToDateTime(cont1.getasssignedrequestdate(reqid).Rows[0][0]);

                    string hallId = cont1.gethallreqid(Convert.ToString(comboBox1.Text)).Rows[0][0].ToString();

                    // Check available caterer for the selected food menu and quantity
                    DataTable result = cont1.selectAvailableCatererForFood(hallId, foodMenu, requestDate.ToString("yyyy-MM-dd"), quantity);

                    if (result != null && result.Rows.Count > 0)
                    {
                        // Insert food request into the database
                        string catererId = result.Rows[0]["CatererID"].ToString();
                        cont1.insertFoodMenuRequest(reqid.ToString(), foodMenu, catererId, quantity);
                    }
                    else
                    {
                        // Log failure if no caterer found
                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.Cells.Add(new DataGridViewTextBoxCell
                        {
                            Value = $"No available caterer for {foodMenu} found for Hall ID "
                        });
                        dataGridView5.Rows.Add(newRow);
                        failure++;
                    }
                }

                // Check if the "Flower Arrangement" service is selected in comboBox2
                else if (comboBox2.SelectedIndex == 4) // Flower Arrangement
                {
                    string arrangementType = comboBox3.SelectedItem.ToString(); // Selected flower arrangement from comboBox3
                    DateTime requestDate = Convert.ToDateTime(cont1.getasssignedrequestdate(reqid).Rows[0][0]);

                    // Find the appropriate florist based on the selected arrangement type and request date
                    DataTable floristDt = cont1.selectAppropriateFlorist(arrangementType, requestDate.ToString("yyyy-MM-dd"));

                    if (floristDt != null && floristDt.Rows.Count > 0)
                    {
                        // Insert florist into the database
                        cont1.insertFlorist(reqid, Convert.ToString(floristDt.Rows[0]["EntertainerID"]));
                    }
                    else
                    {
                        // Log failure if no florist found
                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.Cells.Add(new DataGridViewTextBoxCell
                        {
                            Value = $"Failed to assign a florist with the arrangement type {arrangementType} for the selected date."
                        });
                        dataGridView5.Rows.Add(newRow);
                        failure++;
                    }
                }

                
            }

        
    }
}
