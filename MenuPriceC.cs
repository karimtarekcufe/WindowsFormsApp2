using DBapplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class MenuPriceC : Form
    {
        Form3 f;
        Controller c;
        int id;
        public MenuPriceC(Form3 f,Controller c, int id)
        {
            this.f = f;
            this.c = c;
            this.id = id;
            this.FormClosing += MenuP_FormClosing;
            InitializeComponent();
            dataGridView1.DataSource = c.getCatMenu(id);
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1 || dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("SelectRow to change the price");
                return;
            }
            string str = textBox1.Text;

            int result;

            if (int.TryParse(str, out result) && str != "")
            {
                string name = null;
                name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                int x = c.changeCatPrice(id, name, Convert.ToInt32(textBox1.Text));
                if (x == 0) { MessageBox.Show("Error In inserting"); }
                else
                {
                    MessageBox.Show("Inserting was successful");
                    dataGridView1.DataSource = c.getCatMenu(id);
                    dataGridView1.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Enter Integers only");
            }
        }
        private void MenuP_FormClosing(object sender, FormClosingEventArgs e)
        {
            f.Show();
        }
    }
}
