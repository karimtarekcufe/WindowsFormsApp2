using DBapplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class UpdateInfoEnt : Form
    {
        int id;
        string type;
        Form3 f;
        Controller controllerobj ;
        public UpdateInfoEnt(Form3 f, int ID, string type)
        {
            id = ID;
            this.f = f;
            controllerobj = f.GetController();
            f.Hide();
            this.type = type;
            InitializeComponent();
            this.FormClosing += UpdateInfoEnt_FormClosing;
            switch (type)
            {
                case "Musician":
                    dependOnType.Hide();
                    DependOnTypeButton.Hide();
                    break;
                case "Florist":
                    DependOnTypeButton.Text = "change arrangment";
                    break;
                case "Photographers":
                    DependOnTypeButton.Text = "change Camera";
                    break;
            }
        }

        private void UpdateInfoEnt_Load(object sender, EventArgs e)
        {

        }

        private void priceButton_Click(object sender, EventArgs e)
        {
            int x = controllerobj.updatePriceEnt(id, Convert.ToInt32(price.Text));
            if (x == 0) { MessageBox.Show("Error"); }
            else
            {
                MessageBox.Show("Updating price was successful");
            }
        }

        private void DependOnTypeButton_Click(object sender, EventArgs e)
        {
            switch (type)
            {
                case "Florist":
                    int x = controllerobj.updateArrangmentFlorist(id, DependOnTypeButton.Text);
                    if (x == 0) { MessageBox.Show("Error"); }
                    else
                    {
                        MessageBox.Show("Updating arrangment was successful");
                    }
                    break;
                case "Photographers":
                    int y = controllerobj.updateCameraPhotographer(id, DependOnTypeButton.Text);
                    if (y == 0) { MessageBox.Show("Error"); }
                    else
                    {
                        MessageBox.Show("Updating arrangment was successful");
                    }
                    break;
            }
        }
        private void UpdateInfoEnt_FormClosing(object sender, FormClosingEventArgs e)
        {
            f.Show();
        }
    }
}
