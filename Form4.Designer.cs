using System.Reflection.Emit;
using System.Windows.Forms;

partial class PaymentForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblPrompt;
    private TextBox txtAmount;
    private Button btnSubmit;
    private Button btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.lblPrompt = new System.Windows.Forms.Label();
        this.txtAmount = new System.Windows.Forms.TextBox();
        this.btnSubmit = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // lblPrompt
        // 
        this.lblPrompt.AutoSize = true;
        this.lblPrompt.Location = new System.Drawing.Point(12, 9);
        this.lblPrompt.Name = "lblPrompt";
        this.lblPrompt.Size = new System.Drawing.Size(120, 13);
        this.lblPrompt.TabIndex = 0;
        this.lblPrompt.Text = "Enter the payment amount:";
        // 
        // txtAmount
        // 
        this.txtAmount.Location = new System.Drawing.Point(15, 34);
        this.txtAmount.Name = "txtAmount";
        this.txtAmount.Size = new System.Drawing.Size(257, 20);
        this.txtAmount.TabIndex = 1;
        // 
        // btnSubmit
        // 
        this.btnSubmit.Location = new System.Drawing.Point(15, 69);
        this.btnSubmit.Name = "btnSubmit";
        this.btnSubmit.Size = new System.Drawing.Size(75, 23);
        this.btnSubmit.TabIndex = 2;
        this.btnSubmit.Text = "Submit";
        this.btnSubmit.UseVisualStyleBackColor = true;
        this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.Location = new System.Drawing.Point(197, 69);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(75, 23);
        this.btnCancel.TabIndex = 3;
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // PaymentForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(284, 111);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnSubmit);
        this.Controls.Add(this.txtAmount);
        this.Controls.Add(this.lblPrompt);
        this.Name = "PaymentForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Payment";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}

