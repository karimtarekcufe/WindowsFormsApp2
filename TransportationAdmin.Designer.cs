namespace WindowsFormsApp2
{
    partial class TransportationAdmin
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
            this.lowToHigh = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.highToLow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lowToHigh
            // 
            this.lowToHigh.Location = new System.Drawing.Point(48, 51);
            this.lowToHigh.Name = "lowToHigh";
            this.lowToHigh.Size = new System.Drawing.Size(150, 50);
            this.lowToHigh.TabIndex = 0;
            this.lowToHigh.Text = "order by rating low to high";
            this.lowToHigh.UseVisualStyleBackColor = true;
            this.lowToHigh.Click += new System.EventHandler(this.lowToHigh_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(396, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(392, 229);
            this.dataGridView1.TabIndex = 1;
            // 
            // highToLow
            // 
            this.highToLow.Location = new System.Drawing.Point(48, 107);
            this.highToLow.Name = "highToLow";
            this.highToLow.Size = new System.Drawing.Size(150, 50);
            this.highToLow.TabIndex = 2;
            this.highToLow.Text = "order by rating high to low";
            this.highToLow.UseVisualStyleBackColor = true;
            this.highToLow.Click += new System.EventHandler(this.highToLow_Click);
            // 
            // TransportationAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.highToLow);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lowToHigh);
            this.Name = "TransportationAdmin";
            this.Text = "TransportationAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button lowToHigh;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button highToLow;
    }
}