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
    public partial class showrequest : Form
    { Controller cont1;
        int cid;
        public showrequest(Form3 f,int id)
        {
            cid = id;
      
            InitializeComponent();
            cont1 = new Controller();
            
            dataGridView1.DataSource = cont1.getaalunservedrequests(cid);
            dataGridView2.DataSource = cont1.getaalservedrequests(cid);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
