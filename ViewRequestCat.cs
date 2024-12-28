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

namespace WindowsFormsApp2
{
    public partial class ViewRequestCat : Form
    {
        Form3 f;
        Controller c;
        int id;
        public ViewRequestCat(Form3 f, Controller c,int id)
        {
            this.f = f;
            this.c = c;
            this.id = id;
            InitializeComponent();
            this.FormClosing += ViewReq_FormClosing;
            dataGridView1.DataSource = c.getCatReq(id);
            dataGridView1.Refresh();
        }

        private void ViewRequestCat_Load(object sender, EventArgs e)
        {

        }

        private void ViewReq_FormClosing(object sender, FormClosingEventArgs e)
        {
            f.Show();
        }
    }
}
