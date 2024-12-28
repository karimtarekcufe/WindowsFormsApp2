namespace WindowsFormsApp2
{
    partial class AddMenuOption
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
            this.Okay = new System.Windows.Forms.Button();
            this.FName = new System.Windows.Forms.TextBox();
            this.Price = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Okay
            // 
            this.Okay.Location = new System.Drawing.Point(243, 65);
            this.Okay.Name = "Okay";
            this.Okay.Size = new System.Drawing.Size(91, 28);
            this.Okay.TabIndex = 0;
            this.Okay.Text = "Okay";
            this.Okay.UseVisualStyleBackColor = true;
            this.Okay.Click += new System.EventHandler(this.Okay_Click);
            // 
            // FName
            // 
            this.FName.Location = new System.Drawing.Point(77, 51);
            this.FName.Name = "FName";
            this.FName.Size = new System.Drawing.Size(100, 20);
            this.FName.TabIndex = 1;
            // 
            // Price
            // 
            this.Price.Location = new System.Drawing.Point(77, 77);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(100, 20);
            this.Price.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "FName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Price";
            // 
            // AddMenuOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 248);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.FName);
            this.Controls.Add(this.Okay);
            this.Name = "AddMenuOption";
            this.Text = "AddMenuOption";
            this.Load += new System.EventHandler(this.AddMenuOption_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Okay;
        private System.Windows.Forms.TextBox FName;
        private System.Windows.Forms.TextBox Price;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}