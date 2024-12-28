using DBapplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Admin : Form
    {
        Form3 f;
        string username;
        Controller controloj;
        public Admin(Form3 f)
        {
            this .f = f;
            controloj = new Controller();
            InitializeComponent();
            this.FormClosing += adminForm_closing;
        }
        private void adminForm_closing(object sender, FormClosingEventArgs e)
        {
            f.Show();
        }

        private void view_request_Click(object sender, EventArgs e)
        {
            ViewRequestAdmin f1 = new ViewRequestAdmin (this,controloj);
            f1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntertainersStatics f2 =new EntertainersStatics(this, controloj);
            f2.Show();
            this.Hide();
        }

        private void view_trans_Click(object sender, EventArgs e)
        {
            TransportationAdmin f4 = new TransportationAdmin (this, controloj);
            f4.Show();
            this.Hide();
        }

        private void view_hallProviders_Click(object sender, EventArgs e)
        {
            HallProvidersAdmin f3 = new HallProvidersAdmin(this, controloj);
            f3.Show();
            this.Hide();
        }
    }
}
