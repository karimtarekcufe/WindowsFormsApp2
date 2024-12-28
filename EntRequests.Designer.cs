namespace WindowsFormsApp2
{
    partial class EntRequests
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
            this.requestCombo = new System.Windows.Forms.ComboBox();
            this.approve = new System.Windows.Forms.Button();
            this.deny = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(383, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(405, 267);
            this.dataGridView1.TabIndex = 0;
            // 
            // requestCombo
            // 
            this.requestCombo.FormattingEnabled = true;
            this.requestCombo.Location = new System.Drawing.Point(28, 48);
            this.requestCombo.Name = "requestCombo";
            this.requestCombo.Size = new System.Drawing.Size(121, 21);
            this.requestCombo.TabIndex = 1;
            // 
            // approve
            // 
            this.approve.Location = new System.Drawing.Point(28, 75);
            this.approve.Name = "approve";
            this.approve.Size = new System.Drawing.Size(75, 23);
            this.approve.TabIndex = 2;
            this.approve.Text = "approve";
            this.approve.UseVisualStyleBackColor = true;
            this.approve.Click += new System.EventHandler(this.approve_Click);
            // 
            // deny
            // 
            this.deny.Location = new System.Drawing.Point(109, 75);
            this.deny.Name = "deny";
            this.deny.Size = new System.Drawing.Size(75, 23);
            this.deny.TabIndex = 3;
            this.deny.Text = "deny";
            this.deny.UseVisualStyleBackColor = true;
            this.deny.Click += new System.EventHandler(this.deny_Click);
            // 
            // EntRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deny);
            this.Controls.Add(this.approve);
            this.Controls.Add(this.requestCombo);
            this.Controls.Add(this.dataGridView1);
            this.Name = "EntRequests";
            this.Text = "EntRequests";
            this.Load += new System.EventHandler(this.EntRequests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox requestCombo;
        private System.Windows.Forms.Button approve;
        private System.Windows.Forms.Button deny;
    }
}