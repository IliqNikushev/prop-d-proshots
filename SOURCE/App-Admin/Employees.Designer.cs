namespace App_Admin
{
    partial class Employees
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.textBoxEmployee = new System.Windows.Forms.TextBox();
            this.comboBoxDuty = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            this.SuspendLayout();
            // 
            // findByNameTb
            // 
            this.findByNameTb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.findByNameTb.Size = new System.Drawing.Size(172, 20);
            // 
            // findByTypeTb
            // 
            this.findByTypeTb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.findByTypeTb.Size = new System.Drawing.Size(172, 20);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.textBoxEmployee);
            this.groupBox1.Controls.Add(this.comboBoxDuty);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 144);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(440, 402);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Overview Sorted by:";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            this.groupBox1.Controls.SetChildIndex(this.listBox1, 0);
            this.groupBox1.Controls.SetChildIndex(this.comboBoxDuty, 0);
            this.groupBox1.Controls.SetChildIndex(this.textBoxEmployee, 0);
            this.groupBox1.Controls.SetChildIndex(this.btnSearch, 0);
            this.groupBox1.Controls.SetChildIndex(this.label2, 0);
            this.groupBox1.Controls.SetChildIndex(this.label3, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 36;
            this.label2.Text = "Employee Name:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(305, 52);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 35;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxEmployee
            // 
            this.textBoxEmployee.Location = new System.Drawing.Point(175, 50);
            this.textBoxEmployee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxEmployee.Name = "textBoxEmployee";
            this.textBoxEmployee.Size = new System.Drawing.Size(124, 22);
            this.textBoxEmployee.TabIndex = 34;
            // 
            // comboBoxDuty
            // 
            this.comboBoxDuty.FormattingEnabled = true;
            this.comboBoxDuty.Items.AddRange(new object[] {
            "All",
            "cashier",
            "information",
            "pcdoctor",
            "rent",
            "shopmanager"});
            this.comboBoxDuty.Location = new System.Drawing.Point(20, 50);
            this.comboBoxDuty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxDuty.Name = "comboBoxDuty";
            this.comboBoxDuty.Size = new System.Drawing.Size(121, 24);
            this.comboBoxDuty.TabIndex = 31;
            this.comboBoxDuty.SelectedIndexChanged += new System.EventHandler(this.comboBoxDuty_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(9, 98);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(411, 260);
            this.listBox1.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Duty:";
            // 
            // btnBack
            // 
            this.btnBack.Image = global::App_Admin.Properties.Resources.Back2;
            this.btnBack.Location = new System.Drawing.Point(3, 2);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(65, 42);
            this.btnBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBack.TabIndex = 43;
            this.btnBack.TabStop = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 49;
            this.label3.Text = "Date: ";
            // 
            // Employees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 679);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Employees";
            this.Text = "Employees";
            this.Controls.SetChildIndex(this.findByNameLbl, 0);
            this.Controls.SetChildIndex(this.findByTypeTb, 0);
            this.Controls.SetChildIndex(this.findByTypeLbl, 0);
            this.Controls.SetChildIndex(this.findByNameTb, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnBack, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBoxDuty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEmployee;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox btnBack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

    }
}