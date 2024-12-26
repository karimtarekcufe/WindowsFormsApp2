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

namespace WindowsFormsApp2
{
    public partial class DeleteEnt : Form
    {
        int id;
        Form3 f;
        string type;
        Controller c;
        public DeleteEnt(Form3 f,int id , string type)
        {
            this.id = id;
            this.type = type;
            this.f = f;  
            c=f.GetController();
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x = c.deleteEnt(id, type);
            if (x == 0)
            {
                MessageBox.Show("Error");
            }
            else
            {
                MessageBox.Show("Delete was successful");
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            f.Show();
            this.Close();
        }
    }
}
