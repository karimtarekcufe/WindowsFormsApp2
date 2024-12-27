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
    public partial class Remove_Venue : Form
    {
        string name;
        string id;
        Controller c = new Controller();
        public Remove_Venue(string name)
        {
            InitializeComponent();
            object temp = c.getID(name).Rows[0][0];
            id = temp.ToString();
            comboBox1.DataSource = c.TablesToDelete(id);
            comboBox1.DisplayMember = "HallName";
            comboBox1.ValueMember = "HallID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you Sure You Want To Remove the Venue", "Venue Deletion", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int query = c.removeHall(id, comboBox1.SelectedValue.ToString());
                if (query > 0)
                {
                    MessageBox.Show("Succesfully Deleted");
                    comboBox1.DataSource = c.TablesToDelete(id);

                }
            }
        }
    }
}
