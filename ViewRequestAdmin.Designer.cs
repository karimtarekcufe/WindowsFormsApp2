namespace WindowsFormsApp2
{
    partial class ViewRequestAdmin
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
            this.price_low_to_high = new System.Windows.Forms.Button();
            this.price_high_to_low = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.show_Min = new System.Windows.Forms.Button();
            this.show_Max = new System.Windows.Forms.Button();
            this.show_Average = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 263);
            this.dataGridView1.TabIndex = 0;
            // 
            // price_low_to_high
            // 
            this.price_low_to_high.Location = new System.Drawing.Point(656, 300);
            this.price_low_to_high.Name = "price_low_to_high";
            this.price_low_to_high.Size = new System.Drawing.Size(132, 46);
            this.price_low_to_high.TabIndex = 1;
            this.price_low_to_high.Text = "price low to high";
            this.price_low_to_high.UseVisualStyleBackColor = true;
            this.price_low_to_high.Click += new System.EventHandler(this.price_low_to_high_Click);
            // 
            // price_high_to_low
            // 
            this.price_high_to_low.Location = new System.Drawing.Point(451, 300);
            this.price_high_to_low.Name = "price_high_to_low";
            this.price_high_to_low.Size = new System.Drawing.Size(132, 46);
            this.price_high_to_low.TabIndex = 2;
            this.price_high_to_low.Text = "price high to low";
            this.price_high_to_low.UseVisualStyleBackColor = true;
            this.price_high_to_low.Click += new System.EventHandler(this.price_high_to_low_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(59, 315);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(114, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "upcoming Request";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(59, 338);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(124, 17);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "already done request";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // show_Min
            // 
            this.show_Min.Location = new System.Drawing.Point(59, 361);
            this.show_Min.Name = "show_Min";
            this.show_Min.Size = new System.Drawing.Size(84, 32);
            this.show_Min.TabIndex = 5;
            this.show_Min.Text = "show Min";
            this.show_Min.UseVisualStyleBackColor = true;
            this.show_Min.Click += new System.EventHandler(this.show_Min_Click);
            // 
            // show_Max
            // 
            this.show_Max.Location = new System.Drawing.Point(149, 361);
            this.show_Max.Name = "show_Max";
            this.show_Max.Size = new System.Drawing.Size(84, 32);
            this.show_Max.TabIndex = 6;
            this.show_Max.Text = "show Max";
            this.show_Max.UseVisualStyleBackColor = true;
            this.show_Max.Click += new System.EventHandler(this.show_Max_Click);
            // 
            // show_Average
            // 
            this.show_Average.Location = new System.Drawing.Point(239, 361);
            this.show_Average.Name = "show_Average";
            this.show_Average.Size = new System.Drawing.Size(84, 32);
            this.show_Average.TabIndex = 7;
            this.show_Average.Text = "show Average";
            this.show_Average.UseVisualStyleBackColor = true;
            this.show_Average.Click += new System.EventHandler(this.show_Average_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(353, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(507, 368);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "label2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 399);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 39);
            this.button1.TabIndex = 10;
            this.button1.Text = "show total";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ViewRequestAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.show_Average);
            this.Controls.Add(this.show_Max);
            this.Controls.Add(this.show_Min);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.price_high_to_low);
            this.Controls.Add(this.price_low_to_high);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ViewRequestAdmin";
            this.Text = "ViewRequestAdmin";
            this.Load += new System.EventHandler(this.ViewRequestAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button price_low_to_high;
        private System.Windows.Forms.Button price_high_to_low;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button show_Min;
        private System.Windows.Forms.Button show_Max;
        private System.Windows.Forms.Button show_Average;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}