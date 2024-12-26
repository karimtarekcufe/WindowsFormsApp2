namespace WindowsFormsApp2
{
    partial class EntertainersStatics
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.priceHtoLow = new System.Windows.Forms.Button();
            this.priceLtoHigh = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Min = new System.Windows.Forms.Button();
            this.Max = new System.Windows.Forms.Button();
            this.Avg = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(321, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(467, 292);
            this.dataGridView1.TabIndex = 0;
            // 
            // priceHtoLow
            // 
            this.priceHtoLow.Location = new System.Drawing.Point(12, 66);
            this.priceHtoLow.Name = "priceHtoLow";
            this.priceHtoLow.Size = new System.Drawing.Size(122, 48);
            this.priceHtoLow.TabIndex = 2;
            this.priceHtoLow.Text = "price high to low";
            this.priceHtoLow.UseVisualStyleBackColor = true;
            this.priceHtoLow.Click += new System.EventHandler(this.priceHtoLow_Click);
            // 
            // priceLtoHigh
            // 
            this.priceLtoHigh.Location = new System.Drawing.Point(12, 120);
            this.priceLtoHigh.Name = "priceLtoHigh";
            this.priceLtoHigh.Size = new System.Drawing.Size(122, 48);
            this.priceLtoHigh.TabIndex = 3;
            this.priceLtoHigh.Text = "price low to high";
            this.priceLtoHigh.UseVisualStyleBackColor = true;
            this.priceLtoHigh.Click += new System.EventHandler(this.priceLtoHigh_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 287);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(90, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "group by type";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Min
            // 
            this.Min.Location = new System.Drawing.Point(12, 310);
            this.Min.Name = "Min";
            this.Min.Size = new System.Drawing.Size(75, 23);
            this.Min.TabIndex = 5;
            this.Min.Text = "Min";
            this.Min.UseVisualStyleBackColor = true;
            this.Min.Click += new System.EventHandler(this.Min_Click);
            // 
            // Max
            // 
            this.Max.Location = new System.Drawing.Point(12, 339);
            this.Max.Name = "Max";
            this.Max.Size = new System.Drawing.Size(75, 23);
            this.Max.TabIndex = 6;
            this.Max.Text = "Max";
            this.Max.UseVisualStyleBackColor = true;
            this.Max.Click += new System.EventHandler(this.Max_Click);
            // 
            // Avg
            // 
            this.Avg.Location = new System.Drawing.Point(12, 368);
            this.Avg.Name = "Avg";
            this.Avg.Size = new System.Drawing.Size(75, 23);
            this.Avg.TabIndex = 7;
            this.Avg.Text = "Average";
            this.Avg.UseVisualStyleBackColor = true;
            this.Avg.Click += new System.EventHandler(this.Avg_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // EntertainersStatics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Avg);
            this.Controls.Add(this.Max);
            this.Controls.Add(this.Min);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.priceLtoHigh);
            this.Controls.Add(this.priceHtoLow);
            this.Controls.Add(this.dataGridView1);
            this.Name = "EntertainersStatics";
            this.Text = "EntertainersStatics";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button priceHtoLow;
        private System.Windows.Forms.Button priceLtoHigh;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button Min;
        private System.Windows.Forms.Button Max;
        private System.Windows.Forms.Button Avg;
        private System.Windows.Forms.Label label1;
    }
}