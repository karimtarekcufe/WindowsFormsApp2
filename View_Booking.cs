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
    public partial class View_Booking : Form
    {
        Controller c = new Controller();
        string name;
        string i;
        public View_Booking( string name)
        {
            InitializeComponent();
            this.name = name;
            DataTable dt = new DataTable();
            dt = c.getID(name);
            int  id =(int) dt.Rows[0][0];
            string i = id.ToString();
            this.i = i; 
            dataGridView1.DataSource = c.getRequestsforhall(i);
           


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) {
                dataGridView1.DataSource = c.getcurrentrequestsforhall(i);
            }
            else
            {
                dataGridView1.DataSource = c.getRequestsforhall(i);
            }
        }
    }
}
