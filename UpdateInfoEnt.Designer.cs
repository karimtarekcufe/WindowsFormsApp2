namespace WindowsFormsApp2
{
    partial class UpdateInfoEnt
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
            this.price = new System.Windows.Forms.TextBox();
            this.dependOnType = new System.Windows.Forms.TextBox();
            this.priceButton = new System.Windows.Forms.Button();
            this.DependOnTypeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(36, 35);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(100, 20);
            this.price.TabIndex = 0;
            // 
            // dependOnType
            // 
            this.dependOnType.Location = new System.Drawing.Point(36, 79);
            this.dependOnType.Name = "dependOnType";
            this.dependOnType.Size = new System.Drawing.Size(100, 20);
            this.dependOnType.TabIndex = 1;
            // 
            // priceButton
            // 
            this.priceButton.Location = new System.Drawing.Point(142, 35);
            this.priceButton.Name = "priceButton";
            this.priceButton.Size = new System.Drawing.Size(120, 23);
            this.priceButton.TabIndex = 2;
            this.priceButton.Text = "change price pre hour";
            this.priceButton.UseVisualStyleBackColor = true;
            this.priceButton.Click += new System.EventHandler(this.priceButton_Click);
            // 
            // DependOnTypeButton
            // 
            this.DependOnTypeButton.Location = new System.Drawing.Point(142, 77);
            this.DependOnTypeButton.Name = "DependOnTypeButton";
            this.DependOnTypeButton.Size = new System.Drawing.Size(120, 23);
            this.DependOnTypeButton.TabIndex = 3;
            this.DependOnTypeButton.Text = "button1";
            this.DependOnTypeButton.UseVisualStyleBackColor = true;
            this.DependOnTypeButton.Click += new System.EventHandler(this.DependOnTypeButton_Click);
            // 
            // UpdateInfoEnt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 339);
            this.Controls.Add(this.DependOnTypeButton);
            this.Controls.Add(this.priceButton);
            this.Controls.Add(this.dependOnType);
            this.Controls.Add(this.price);
            this.Name = "UpdateInfoEnt";
            this.Text = "UpdateInfoEnt";
            this.Load += new System.EventHandler(this.UpdateInfoEnt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.TextBox dependOnType;
        private System.Windows.Forms.Button priceButton;
        private System.Windows.Forms.Button DependOnTypeButton;
    }
}