namespace WindowsFormsApp2
{
    partial class HallProvidersAdmin
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
            this.capacityHtoL = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.capacityLtoH = new System.Windows.Forms.Button();
            this.maxCap = new System.Windows.Forms.Button();
            this.minCap = new System.Windows.Forms.Button();
            this.avgCap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MaxSize = new System.Windows.Forms.Button();
            this.MinSize = new System.Windows.Forms.Button();
            this.AvgSize = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.sizeHtoL = new System.Windows.Forms.Button();
            this.sizeLtoH = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // capacityHtoL
            // 
            this.capacityHtoL.Location = new System.Drawing.Point(12, 12);
            this.capacityHtoL.Name = "capacityHtoL";
            this.capacityHtoL.Size = new System.Drawing.Size(132, 46);
            this.capacityHtoL.TabIndex = 0;
            this.capacityHtoL.Text = "capacity high to low";
            this.capacityHtoL.UseVisualStyleBackColor = true;
            this.capacityHtoL.Click += new System.EventHandler(this.capacityHtoL_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(374, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(414, 231);
            this.dataGridView1.TabIndex = 1;
            // 
            // capacityLtoH
            // 
            this.capacityLtoH.Location = new System.Drawing.Point(12, 64);
            this.capacityLtoH.Name = "capacityLtoH";
            this.capacityLtoH.Size = new System.Drawing.Size(132, 46);
            this.capacityLtoH.TabIndex = 2;
            this.capacityLtoH.Text = "capacity low to high";
            this.capacityLtoH.UseVisualStyleBackColor = true;
            this.capacityLtoH.Click += new System.EventHandler(this.capacityLtoH_Click);
            // 
            // maxCap
            // 
            this.maxCap.Location = new System.Drawing.Point(12, 292);
            this.maxCap.Name = "maxCap";
            this.maxCap.Size = new System.Drawing.Size(96, 34);
            this.maxCap.TabIndex = 3;
            this.maxCap.Text = "max Capacity";
            this.maxCap.UseVisualStyleBackColor = true;
            this.maxCap.Click += new System.EventHandler(this.maxCap_Click);
            // 
            // minCap
            // 
            this.minCap.Location = new System.Drawing.Point(12, 332);
            this.minCap.Name = "minCap";
            this.minCap.Size = new System.Drawing.Size(96, 34);
            this.minCap.TabIndex = 4;
            this.minCap.Text = "min Capacity";
            this.minCap.UseVisualStyleBackColor = true;
            this.minCap.Click += new System.EventHandler(this.minCap_Click);
            // 
            // avgCap
            // 
            this.avgCap.Location = new System.Drawing.Point(12, 372);
            this.avgCap.Name = "avgCap";
            this.avgCap.Size = new System.Drawing.Size(96, 38);
            this.avgCap.TabIndex = 5;
            this.avgCap.Text = "avg Capacity";
            this.avgCap.UseVisualStyleBackColor = true;
            this.avgCap.Click += new System.EventHandler(this.avgCap_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(114, 341);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // MaxSize
            // 
            this.MaxSize.Location = new System.Drawing.Point(182, 292);
            this.MaxSize.Name = "MaxSize";
            this.MaxSize.Size = new System.Drawing.Size(83, 34);
            this.MaxSize.TabIndex = 7;
            this.MaxSize.Text = "Max Size";
            this.MaxSize.UseVisualStyleBackColor = true;
            this.MaxSize.Click += new System.EventHandler(this.MaxSize_Click);
            // 
            // MinSize
            // 
            this.MinSize.Location = new System.Drawing.Point(182, 332);
            this.MinSize.Name = "MinSize";
            this.MinSize.Size = new System.Drawing.Size(83, 34);
            this.MinSize.TabIndex = 8;
            this.MinSize.Text = "Min Size";
            this.MinSize.UseVisualStyleBackColor = true;
            this.MinSize.Click += new System.EventHandler(this.MinSize_Click);
            // 
            // AvgSize
            // 
            this.AvgSize.Location = new System.Drawing.Point(182, 374);
            this.AvgSize.Name = "AvgSize";
            this.AvgSize.Size = new System.Drawing.Size(83, 34);
            this.AvgSize.TabIndex = 9;
            this.AvgSize.Text = "Avg Size";
            this.AvgSize.UseVisualStyleBackColor = true;
            this.AvgSize.Click += new System.EventHandler(this.AvgSize_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(271, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "label2";
            // 
            // sizeHtoL
            // 
            this.sizeHtoL.Location = new System.Drawing.Point(150, 12);
            this.sizeHtoL.Name = "sizeHtoL";
            this.sizeHtoL.Size = new System.Drawing.Size(115, 46);
            this.sizeHtoL.TabIndex = 11;
            this.sizeHtoL.Text = "Size high to low ";
            this.sizeHtoL.UseVisualStyleBackColor = true;
            this.sizeHtoL.Click += new System.EventHandler(this.sizeHtoL_Click);
            // 
            // sizeLtoH
            // 
            this.sizeLtoH.Location = new System.Drawing.Point(150, 64);
            this.sizeLtoH.Name = "sizeLtoH";
            this.sizeLtoH.Size = new System.Drawing.Size(115, 46);
            this.sizeLtoH.TabIndex = 12;
            this.sizeLtoH.Text = "Size low to high";
            this.sizeLtoH.UseVisualStyleBackColor = true;
            this.sizeLtoH.Click += new System.EventHandler(this.sizeLtoH_Click);
            // 
            // HallProvidersAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sizeLtoH);
            this.Controls.Add(this.sizeHtoL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AvgSize);
            this.Controls.Add(this.MinSize);
            this.Controls.Add(this.MaxSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.avgCap);
            this.Controls.Add(this.minCap);
            this.Controls.Add(this.maxCap);
            this.Controls.Add(this.capacityLtoH);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.capacityHtoL);
            this.Name = "HallProvidersAdmin";
            this.Text = "HallProvidersAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button capacityHtoL;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button capacityLtoH;
        private System.Windows.Forms.Button maxCap;
        private System.Windows.Forms.Button minCap;
        private System.Windows.Forms.Button avgCap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button MaxSize;
        private System.Windows.Forms.Button MinSize;
        private System.Windows.Forms.Button AvgSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sizeHtoL;
        private System.Windows.Forms.Button sizeLtoH;
    }
}