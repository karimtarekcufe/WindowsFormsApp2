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
        public View_Booking( string name)
        {
            InitializeComponent();
            this.name = name;
            DataTable dt = new DataTable();
            dt = c.getID(name);
            int  id =(int) dt.Rows[0][0];
            string i = id.ToString();
            dataGridView1.DataSource = c.getRequestsforhall(i);
           

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
