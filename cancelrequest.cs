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
    public partial class cancelrequest : Form
    {
        int cid;
        Controller cont1;
        public cancelrequest(Form3 form, int id)
        {
            cont1 = new Controller();
            cid = id;
            InitializeComponent();
            comboBox2.DataSource = cont1.selectallidmusician(cid);
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "id";
            comboBox3.Enabled = false;

        }

        private void cancelrequest_Load(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:

                    break;
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (comboBox1.SelectedIndex)
            {
                case 0:

                    comboBox3.Enabled = false;


                    break;
                case 1:
                    comboBox3.Enabled = true;
                    comboBox3.DataSource = cont1.selectallridentertainers(comboBox2.Text, "music");
                    comboBox3.ValueMember = "id";
                    comboBox3.DisplayMember = "Name";
                    break;
                case 2:
                    comboBox3.Enabled = true;
                    comboBox3.DataSource = cont1.selectallridentertainers(comboBox2.Text, "florist");
                    comboBox3.ValueMember = "id";
                    comboBox3.DisplayMember = "Name";

                    break;
                case 5:
                    comboBox3.Enabled = true;
                    comboBox3.DataSource = cont1.selectallridentertainers(comboBox2.Text, "photographer");
                    comboBox3.ValueMember = "id";
                    comboBox3.DisplayMember = "Name";

                    break;
                case 3:
                    comboBox3.Enabled = true;
                    comboBox3.DataSource = cont1.selectallridtransporattion(comboBox2.Text);
                    comboBox3.ValueMember = "ID";
                    comboBox3.DisplayMember = "Type";

                    break;
                case 4:

                    comboBox3.Enabled = true;
                    comboBox3.DataSource = cont1.selectallridfood(comboBox2.Text);
                    comboBox3.ValueMember = "CatererID";
                    comboBox3.DisplayMember = "Fname";

                    break;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (!string.IsNullOrEmpty(comboBox1.Text))
                    {
                        int res = cont1.deletewholerequest(comboBox2.Text);
                        if (res > 0)
                        {
                            MessageBox.Show("sucessfull deletion");
                        }
                    }
                    else
                    {
                        MessageBox.Show("please fill request id");
                        return;
                    }
                    

                    break;
                case 1:
                    if (!string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrEmpty(comboBox2.Text))
                    {
                        int res1 = cont1.deleteentertainementrequest(comboBox2.Text, Convert.ToString(comboBox3.SelectedValue));
                        if (res1 > 0)
                        {
                            MessageBox.Show("sucessfull deletion of musician");
                        }

                    }
                    else
                    {
                        MessageBox.Show("please fill request id & service id");
                        return;
                    }
                    break;
                case 2:
                    if (!string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrEmpty(comboBox2.Text))
                    {
                        int res2 = cont1.deleteentertainementrequest(comboBox2.Text, Convert.ToString(comboBox3.SelectedValue));
                        if (res2 > 0)
                        {
                            MessageBox.Show("sucessfull deletion of florist ");
                        }
                    }
                    break;
                case 5:

                    if (!string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrEmpty(comboBox2.Text))
                    {
                        int res5 = cont1.deleteentertainementrequest(comboBox2.Text, Convert.ToString(comboBox3.SelectedValue));
                        if (res5 > 0)
                        {
                            MessageBox.Show("sucessfull deletion of photographer ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("please fill request id & service id");
                        return;
                    }
                    break;
                case 4:
                    if (!string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrEmpty(comboBox2.Text)) {
                        int res3 = cont1.deletefoodrequest(comboBox2.Text, Convert.ToString(comboBox3.SelectedValue),Convert.ToString(comboBox3.Text));
                        if (res3> 0)
                        {
                            MessageBox.Show("sucessfull deletion of food ");
                        }
                    }

            
                    else
                    {
                        MessageBox.Show("please fill request id & service id");
                        return;
                    }


                    break;
                case 3:

                    if (!string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrEmpty(comboBox2.Text))
                    {
                        int res4 = cont1.deletetransportationrequest(comboBox2.Text, Convert.ToString(comboBox3.SelectedValue));
                        if (res4 > 0)
                        {
                            MessageBox.Show("sucessfull deletion of food ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("please fill request id & service id");
                        return;
                    }


                    break;

            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:

                    comboBox3.Enabled = false;


                    break;
                case 1:
                    comboBox3.Enabled = true;
                    comboBox3.DataSource = cont1.selectallridentertainers(comboBox2.Text, "music");
                    comboBox3.ValueMember = "id";
                    comboBox3.DisplayMember = "Name";
                    break;
                case 2:
                    comboBox3.Enabled = true;
                    comboBox3.DataSource = cont1.selectallridentertainers(comboBox2.Text, "florist");
                    comboBox3.ValueMember = "id";
                    comboBox3.DisplayMember = "Name";

                    break;
                case 5:
                    comboBox3.Enabled = true;
                    comboBox3.DataSource = cont1.selectallridentertainers(comboBox2.Text, "photographer");
                    comboBox3.ValueMember = "id";
                    comboBox3.DisplayMember = "Name";

                    break;
                case 3:
                    comboBox3.Enabled = true;
                    comboBox3.DataSource = cont1.selectallridtransporattion(comboBox2.Text);
                    comboBox3.ValueMember = "ID";
                    comboBox3.DisplayMember = "Type";

                    break;
                case 4:

                    comboBox3.Enabled = true;
                    comboBox3.DataSource = cont1.selectallridfood(comboBox2.Text);
                    comboBox3.ValueMember = "Fname";
                    comboBox3.DisplayMember = "Fname";

                    break;


            }
        }
    }
}
