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
        public cancelrequest(Form3 form,int id)
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
            switch (comboBox1.SelectedIndex) {
                case 0:

                    break;
            }
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            switch (comboBox1.SelectedIndex)
            {
                case 0:

                    
            
     
                    break;
                case 1:
                    comboBox3.Enabled = true;
                    comboBox3.DataSource = cont1.selectallridentertainers(comboBox1.Text,"music");
                    comboBox3.ValueMember = "id";
                    comboBox3.DisplayMember = "id";
                    break;
                case 2:
                    comboBox3.Enabled = true;
                    comboBox3.DataSource = cont1.selectallridentertainers(comboBox1.Text, "florist");
                    comboBox3.ValueMember = "id";
                    comboBox3.DisplayMember = "id";
                    
                    break;
                case 5:
                    comboBox3.Enabled = true;
                    comboBox3.DataSource = cont1.selectallridentertainers(comboBox1.Text, "photographer");
                    comboBox3.ValueMember = "id";
                    comboBox3.DisplayMember = "id";

                    break;
                case 3:

                    break;
                case 4:


                    break;

            }

        }
    }
}
