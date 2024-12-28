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
using WindowsFormsApp2;

namespace WindowsFormsApp2
{
    public partial class makerequest : Form
    {
        string username;
        Controller controller1;
        DataTable dt;
        DataTable dt1;
        DataTable dt2;
        DataTable dt3;
        DataTable dt4;
        DataTable dt5;
        int cid;
        int tempreqid;






        public makerequest(Form3 form, string name, int cid)
        {
          



            form.Hide();
            InitializeComponent();
            controller1 = new Controller();
            dt = new DataTable();
            DataGridViewTextBoxColumn errorColumn = new DataGridViewTextBoxColumn
            {
                Name = "ErrorMessage",
                HeaderText = "Error Message",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dataGridView1.Columns.Add(errorColumn);

            this.cid = cid; ;

            dt = controller1.gethallocation();
            comboBox6.DataSource = dt;
            comboBox6.DisplayMember = "location";
            comboBox6.ValueMember = "location";

            label7.Visible = false;
            comboBox5.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            comboBox3.Visible = false;
            textBox4.Visible = false;


        }
        public int gethallid(string name)
        {
            return (int)controller1.gethallid(name).Rows[0][0];
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    label6.Visible = false;
                    textBox4.Visible = false;
                    label5.Visible = true;
                    label5.Text = "Genre";
                    comboBox3.Visible = true;
                    DataTable dt = controller1.selectgenre();

                    comboBox3.DataSource = dt;
                    comboBox3.ValueMember = "genre";
                    comboBox3.DisplayMember = "genre";


                    break;
                case 1:
                    label6.Visible = false;
                    textBox4.Visible = false;
                    label5.Visible = true;
                    label5.Text = "camera type";
                    comboBox3.Visible = true;
                    dt = controller1.selectcamera();
                    comboBox3.DataSource = dt;
                    comboBox3.ValueMember = "camera";
                    comboBox3.DisplayMember = "camera";

                    break;
                case 2:
                    label6.Visible = false;
                    textBox4.Visible = false;
                    label5.Visible = true;
                    label5.Text = "transportation";
                    comboBox3.Visible = true;
                    if (string.IsNullOrEmpty(comboBox5.Text))
                    {
                    }
                    else
                    {
                        dt = controller1.selecttransportation(gethallid(comboBox5.Text));
                        comboBox3.DataSource = dt;
                        comboBox3.ValueMember = "Type";
                        comboBox3.DisplayMember = "Type";
                    }

                    break;
                case 3:
                    label5.Visible = true;
                    label5.Text = "Food";
                    label6.Visible = true;
                    label6.Text = "quantity";
                    textBox4.Visible = true;
                    comboBox3.Visible = true;
                    dt = controller1.selectfood();
                    comboBox3.DataSource = dt;
                    comboBox3.ValueMember = "Fname";
                    comboBox3.DisplayMember = "Fname";
                    break;
                case 4:
                    label6.Visible = false;
                    textBox4.Visible = false;
                    label5.Visible = true;
                    label5.Text = "flower arrangements";
                    comboBox3.Visible = true;
                    dt = controller1.selectflower();
                    comboBox3.DataSource = dt;
                    comboBox3.ValueMember = "Arrangement";
                    comboBox3.DisplayMember = "Arrangement";
                    break;
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    dt1 = new DataTable();
                    insertservice(dt1);
                    break;
                case 1:
                    dt2 = new DataTable();
                    insertservice(dt2);


                    break;
                case 2:
                    dt3 = new DataTable();
                    insertservice(dt3);


                    break;
                case 3:
                    dt4 = new DataTable();
                    insertservice(dt4);


                    break;
                case 4:
                    dt5 = new DataTable();
                    insertservice(dt5);

                    break;
            }



        }

        private void insertservice(DataTable dta)
        {
            DataRow newRow = dta.NewRow();

            if (comboBox3.Visible)
            {
                if (!string.IsNullOrEmpty(comboBox3.Text))
                {
                    if (!dta.Columns.Contains(label5.Text))
                    {
                        dta.Columns.Add(label5.Text);
                    }
                    newRow[label5.Text] = comboBox3.Text;
                }
                else
                {
                    MessageBox.Show($"Please do not leave {label5.Text} empty.");
                    return;
                }
            }
            if (textBox4.Visible)
            {
                if (!string.IsNullOrEmpty(textBox4.Text))
                {
                    if (!dta.Columns.Contains(label6.Text))
                    {
                        dta.Columns.Add(label6.Text);
                    }
                    newRow[label6.Text] = textBox4.Text;
                

                }
                else
                {
                    MessageBox.Show($"Please do not leave {label6.Text} empty.");

                    return;
                }

            }

            dta.Rows.Add(newRow);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int price = 0;
            if (string.IsNullOrEmpty(comboBox5.Text))
            {
                MessageBox.Show("please fill hall name");
                return;
            }

            if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("please fill date and time");
                return;
            }
            string startTime = textBox1.Text;
            string endTime = textBox2.Text;

            if (!TimeSpan.TryParse(startTime, out _) || !TimeSpan.TryParse(endTime, out _))
            {
                MessageBox.Show("please enter time format data");
                return;
            }

            if (!IsValidDate(textBox3.Text))
            {
                MessageBox.Show("the string is not a valid date in yyyy-MM-dd format.");
                return;
            }
            if (string.IsNullOrEmpty(comboBox1.Text)){

                MessageBox.Show("please enter payment method");
                return;
            }

            DateTime enteredDate = Convert.ToDateTime(textBox3.Text);
            DateTime currentDate = DateTime.Now.Date;

            if (enteredDate < currentDate.AddDays(1)) 
            {
                MessageBox.Show("Please enter a date at least one day in the future.");
                return;
            }

            TimeSpan start = TimeSpan.Parse(textBox1.Text);
            TimeSpan end = TimeSpan.Parse(textBox2.Text);

            if (end <= start.Add(TimeSpan.FromHours(1))) // Ensure end time is at least 1 hour after the start time
            {
                MessageBox.Show("End time should be at least 1 hour after the start time.");
                return;
            }

            int c = controller1.IsHallBooked(comboBox5.Text, enteredDate, textBox1.Text, textBox2.Text);
            if (c == 0)
            {
                DataTable hall = controller1.gethallinfo(comboBox5.Text);
                string hallid = Convert.ToString(hall.Rows[0][0]);
                string provid = Convert.ToString(hall.Rows[0][1]);
                int originalprice = Convert.ToInt32(controller1.gethallbookingprice(hallid, provid).Rows[0][0]);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to proceed?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int reqid = controller1.inssertrequest(cid, textBox1.Text, textBox2.Text, hallid, provid, textBox3.Text, originalprice);
                    price += originalprice;
                    int pricer = serveallrequests(reqid, 0,price);
                    MessageBox.Show($"request is done with price={pricer}");
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            
                            PaymentForm p = new PaymentForm(this,pricer,reqid);
                            p.Show();
                                break;

                    }
                    MessageBox.Show($"view grid for details and press close request to close" +
                        $"for delete access your homepage");
                }
            }
            else
            {
                MessageBox.Show("please book another hall!! hall OCCUPIED");
            }
        }


        static bool IsValidDate(string dateString)
        {
            return DateTime.TryParseExact(
                dateString,
                "yyyy-MM-dd",
                null,
                System.Globalization.DateTimeStyles.None,
                out _);
        }
        public int serveallrequests(int id, int failure,int price)
        {
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                foreach (DataRow row in dt1.Rows)
                {

                    DataTable date = controller1.getasssignedrequestdate(id);
                    DateTime date1 = Convert.ToDateTime(date.Rows[0][0]).Date;
                    string musician = row["Genre"].ToString();
                    DataTable musiciandt = controller1.selectappropriatemusician(musician, Convert.ToString(date1));
                        if (musiciandt != null)
                    {
                        if (musiciandt.Rows.Count > 0)
                        {
                            controller1.insertMusician(id, Convert.ToString(musiciandt.Rows[0][0]));
                            price += Convert.ToInt32(controller1.GetEntertainerPriceData(Convert.ToString(musiciandt.Rows[0][0]), Convert.ToString(id)).Rows[0][0]);


                        }
                        else
                        {
                            DataGridViewRow newRow = new DataGridViewRow();
                            newRow.Cells.Add(new DataGridViewTextBoxCell { Value = $"Failed to assign a musician with the specified genre{musician} at the current time" });
                            dataGridView1.Rows.Add(newRow);
                            failure++;
                        }
                    }
                }
            }



            if (dt2 != null && dt2.Rows.Count > 0)
            {
                foreach (DataRow row in dt2.Rows)
                {
                    DataTable date = controller1.getasssignedrequestdate(id);
                    DateTime date1 = Convert.ToDateTime(date.Rows[0][0]);
                    string cameraType = row["camera type"].ToString();

                    DataTable photographerDt = controller1.selectAppropriatePhotographer(cameraType, Convert.ToString(date1));

                    if (photographerDt.Rows.Count > 0)
                    {

                        // Assign photographer to the request
                        controller1.insertPhotographer(id, Convert.ToString(photographerDt.Rows[0]["PhotographerID"]));
                        price += Convert.ToInt32(controller1.GetEntertainerPriceData(Convert.ToString(photographerDt.Rows[0][0]), Convert.ToString(id)).Rows[0][0]);

                    }
                    else
                    {
                        // Log failure to assign a photographer
                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.Cells.Add(new DataGridViewTextBoxCell { Value = $"Failed to assign a photographer with the specified camera type {cameraType} at the current time" });
                        dataGridView1.Rows.Add(newRow);
                        failure++;
                    }
                }
            }
            if (dt3 != null && dt3.Rows.Count > 0)
            {
                foreach (DataRow row in dt3.Rows)
                {
                    DataTable date = controller1.getasssignedrequestdate(id);
                    DateTime date1 = Convert.ToDateTime(date.Rows[0][0]);
                    string transportationType = row["transportation"].ToString();
                    int hid=Convert.ToInt32(controller1.gethallid(comboBox5.Text).Rows[0][0]);
                    // Call a controller method to find the first suitable transportation ID
                    DataTable result = controller1.selectAvailableTransportation(Convert.ToString(hid), transportationType,Convert.ToString(date1));

                    if (result != null && result.Rows.Count > 0)
                    {
                        string transportationId = result.Rows[0]["ID"].ToString();

                        // Call a controller method to insert into TransportationRequest
                        controller1.insertTransportationRequest(Convert.ToString(id), transportationId);
                        price += Convert.ToInt32(controller1.calcpricetransport(Convert.ToString(transportationId), Convert.ToString(id)).Rows[0][0]);

                    }
                    else
                    {
                        // Log failure to find transportation
                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.Cells.Add(new DataGridViewTextBoxCell
                        {
                            Value = $"No available transportation of type {transportationType} found for Hall ID associated with Request {id}"
                        });
                        dataGridView1.Rows.Add(newRow);
                    }
                }
            }


            if (dt4 != null && dt4.Rows.Count > 0)
            {
                foreach (DataRow row in dt4.Rows)
                {
                    string foodMenu = row["Food"].ToString();
                    string quantity = row["quantity"].ToString();



                    DataTable date = controller1.getasssignedrequestdate(id);
                    DateTime date1 = Convert.ToDateTime(date.Rows[0][0]);

                    String hid = Convert.ToString(controller1.gethallid(comboBox5.Text).Rows[0][0]);

                    DataTable result = controller1.selectAvailableCatererForFood(hid, foodMenu, date1.ToString("yyyy-MM-dd"),quantity);

                    if (result != null && result.Rows.Count > 0)
                    {
                        string catererId = result.Rows[0]["CatererID"].ToString();

                        controller1.insertFoodMenuRequest(id.ToString(), foodMenu, catererId,quantity);
                        price += Convert.ToInt32(controller1.calcpricefood(Convert.ToString(catererId), Convert.ToString(foodMenu), Convert.ToString(id)).Rows[0][0]);

                    }
                    else
                    {
                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.Cells.Add(new DataGridViewTextBoxCell
                        {
                            Value = $"No available caterer for {foodMenu} found for Hall ID associated with Request {id} on {date1.ToString("yyyy-MM-dd")}"
                        });
                                                dataGridView1.Rows.Add(newRow);

                    }
                }

            }


            if (dt5 != null && dt5.Rows.Count > 0)
            {
                foreach (DataRow row in dt5.Rows)
                {
                    DataTable date = controller1.getasssignedrequestdate(id);
                    DateTime date1 = Convert.ToDateTime(date.Rows[0][0]);
                    string arrangementType = row["flower arrangements"].ToString();
                    DataTable floristDt = controller1.selectAppropriateFlorist(arrangementType, Convert.ToString(date1));

                    if (floristDt != null || floristDt.Rows.Count > 0)
                    {

                        controller1.insertFlorist(id, Convert.ToString(floristDt.Rows[0]["EntertainerID"]));
                        price += Convert.ToInt32(controller1.GetEntertainerPriceData(Convert.ToString(floristDt.Rows[0][0]), Convert.ToString(id)).Rows[0][0]);

                    }
                    else
                    {

                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.Cells.Add(new DataGridViewTextBoxCell { Value = $"Failed to assign a florist with the specified arrangement type {arrangementType} at the current time" });
                        dataGridView1.Rows.Add(newRow);
                        failure++;
                    }
                }
            }
            controller1.modifyprice(price, id);
            controller1.modifyduepayment(price, id);


            return price;
        }



        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox6.Text))
            {
                label7.Visible = true;
                comboBox5.Visible = true;
                comboBox5.DataSource = controller1.gethallname(comboBox6.Text);
                comboBox5.DisplayMember = "hallname";
                comboBox5.ValueMember = "hallname";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Create and show the confirmation dialog
            
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to close the form?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }

        private void makerequest_Load(object sender, EventArgs e)
        {

        }







    }
    }

