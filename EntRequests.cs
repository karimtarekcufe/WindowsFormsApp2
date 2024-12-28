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
    public partial class EntRequests : Form
    {
        int id;
        Controller controllerobj = new Controller();
        Form3 f;
        bool hasRequest = false;
        public EntRequests(Form3 f, int Entid)
        {
            id = Entid;
            this.f = f;
            InitializeComponent();
            dataGridView1.DataSource = controllerobj.ViewBookEnt(Entid);
            dataGridView1.Refresh();
            DataTable dt = controllerobj.GetRequestIDFromEntReq(Entid);
            if (dt != null)
            {
                hasRequest = true;
            }
            if (hasRequest)
            requestCombo.DataSource = dt;
            requestCombo.DisplayMember = "RequestID";
            requestCombo.ValueMember = "RequestID";
            requestCombo.Refresh();
            this.FormClosing += EntRequests_FormClosing;
        }

        private void approve_Click(object sender, EventArgs e)
        {
            int x = 0;
            if (hasRequest)
            {
                x = controllerobj.approveRequestEnt(Convert.ToInt32(requestCombo.SelectedValue));

            }
            if (x == 0) { MessageBox.Show("Error"); }
            else
            {
                MessageBox.Show("Update was successful");
            }
            dataGridView1.DataSource = controllerobj.GetRequestIDFromEntReq(id);
            requestCombo.ValueMember = "RequestID";
            requestCombo.DisplayMember = "RequestID";
            requestCombo.Refresh();
            dataGridView1.Refresh();
        }

        private void deny_Click(object sender, EventArgs e)
        {
            int x = 0;
            if (hasRequest)
            {
                x = controllerobj.denyRequestEnt(Convert.ToInt32(requestCombo.SelectedValue));

            }
            if (x == 0) { MessageBox.Show("Error"); }
            else
            {
                MessageBox.Show("Update was successful");
            }
            DataTable dt = controllerobj.GetRequestIDFromEntReq(id);
            dataGridView1.DataSource = dt;
            requestCombo.DataSource = dt;
            requestCombo.ValueMember = "RequestID";
            requestCombo.DisplayMember = "RequestID";
            requestCombo.Refresh();
            dataGridView1.Refresh();
        }

        private void EntRequests_Load(object sender, EventArgs e)
        {

        }

        private void EntRequests_FormClosing(object sender, FormClosingEventArgs e)
        {
            f.Show();
        }
    }
}