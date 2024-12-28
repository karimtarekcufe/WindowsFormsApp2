using DBapplication;
using System;
using System.Windows.Forms;
using WindowsFormsApp2;

public partial class PaymentForm : Form
{
    private decimal maxPrice;

    public decimal? PaymentAmount { get; private set; }
    Controller cont1;
    int reqid;
    public PaymentForm(makerequest m,decimal maxPrice, int reqid)
    {
        m.Close();
        cont1 = new Controller();
        InitializeComponent();
        this.maxPrice = maxPrice;
        lblPrompt.Text = $"Enter the amount you want to pay (max: {maxPrice:C}):";
        this.reqid = reqid;
    }

    private void btnSubmit_Click(object sender, EventArgs e)
    {
        if (decimal.TryParse(txtAmount.Text, out decimal amount))
        {
            if (amount > 0 && amount <= maxPrice)
            {
                PaymentAmount = amount;
                DialogResult = DialogResult.OK;
                cont1.deductpayment(reqid,amount);
            }

            else
            {
                MessageBox.Show($"Please enter a valid amount greater than 0 and less than or equal to {maxPrice:C}.",
                                "Invalid Input",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
        else
        {
            MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }
}

