namespace WindowsFormsApp2
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.view_request = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.view_hallProviders = new System.Windows.Forms.Button();
            this.view_trans = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // view_request
            // 
            this.view_request.Location = new System.Drawing.Point(12, 12);
            this.view_request.Name = "view_request";
            this.view_request.Size = new System.Drawing.Size(131, 57);
            this.view_request.TabIndex = 0;
            this.view_request.Text = "View Request ";
            this.view_request.UseVisualStyleBackColor = true;
            this.view_request.Click += new System.EventHandler(this.view_request_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(149, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 57);
            this.button1.TabIndex = 1;
            this.button1.Text = "View Enterianters";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // view_hallProviders
            // 
            this.view_hallProviders.Location = new System.Drawing.Point(149, 75);
            this.view_hallProviders.Name = "view_hallProviders";
            this.view_hallProviders.Size = new System.Drawing.Size(131, 57);
            this.view_hallProviders.TabIndex = 2;
            this.view_hallProviders.Text = "view hallProviders";
            this.view_hallProviders.UseVisualStyleBackColor = true;
            this.view_hallProviders.Click += new System.EventHandler(this.view_hallProviders_Click);
            // 
            // view_trans
            // 
            this.view_trans.Location = new System.Drawing.Point(12, 75);
            this.view_trans.Name = "view_trans";
            this.view_trans.Size = new System.Drawing.Size(131, 57);
            this.view_trans.TabIndex = 3;
            this.view_trans.Text = "view transportations";
            this.view_trans.UseVisualStyleBackColor = true;
            this.view_trans.Click += new System.EventHandler(this.view_trans_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 199);
            this.Controls.Add(this.view_trans);
            this.Controls.Add(this.view_hallProviders);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.view_request);
            this.Name = "Admin";
            this.Text = "Admin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button view_request;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button view_hallProviders;
        private System.Windows.Forms.Button view_trans;
    }
}