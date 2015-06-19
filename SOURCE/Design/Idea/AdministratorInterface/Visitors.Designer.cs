﻿namespace Design.Idea.AdministratorInterface
{
    partial class Visitors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Visitors));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonTent = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.checkBoxVisitor = new System.Windows.Forms.CheckBox();
            this.buttonAll = new System.Windows.Forms.Button();
            this.textBoxVisitor = new System.Windows.Forms.TextBox();
            this.buttonTopUps = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonAppointment = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDate = new System.Windows.Forms.ComboBox();
            this.buttonPurchased = new System.Windows.Forms.Button();
            this.buttonloaned = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonTent);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.checkBoxVisitor);
            this.groupBox1.Controls.Add(this.buttonAll);
            this.groupBox1.Controls.Add(this.textBoxVisitor);
            this.groupBox1.Controls.Add(this.buttonTopUps);
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.buttonAppointment);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxDate);
            this.groupBox1.Controls.Add(this.buttonPurchased);
            this.groupBox1.Controls.Add(this.buttonloaned);
            this.groupBox1.Location = new System.Drawing.Point(12, 144);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(913, 442);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Overview Sorted by:";
            // 
            // buttonTent
            // 
            this.buttonTent.Location = new System.Drawing.Point(485, 105);
            this.buttonTent.Name = "buttonTent";
            this.buttonTent.Size = new System.Drawing.Size(115, 30);
            this.buttonTent.TabIndex = 54;
            this.buttonTent.Text = "Tent";
            this.buttonTent.UseVisualStyleBackColor = true;
            this.buttonTent.Click += new System.EventHandler(this.buttonTent_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(18, 141);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(833, 260);
            this.listBox1.TabIndex = 30;
            // 
            // checkBoxVisitor
            // 
            this.checkBoxVisitor.AutoSize = true;
            this.checkBoxVisitor.Location = new System.Drawing.Point(158, 27);
            this.checkBoxVisitor.Name = "checkBoxVisitor";
            this.checkBoxVisitor.Size = new System.Drawing.Size(110, 21);
            this.checkBoxVisitor.TabIndex = 53;
            this.checkBoxVisitor.Text = "Visitor Name";
            this.checkBoxVisitor.UseVisualStyleBackColor = true;
            // 
            // buttonAll
            // 
            this.buttonAll.Location = new System.Drawing.Point(16, 105);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(90, 30);
            this.buttonAll.TabIndex = 0;
            this.buttonAll.Text = "All";
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.ButtonAll_Click);
            // 
            // textBoxVisitor
            // 
            this.textBoxVisitor.Location = new System.Drawing.Point(158, 50);
            this.textBoxVisitor.Name = "textBoxVisitor";
            this.textBoxVisitor.Size = new System.Drawing.Size(100, 22);
            this.textBoxVisitor.TabIndex = 52;
            // 
            // buttonTopUps
            // 
            this.buttonTopUps.Location = new System.Drawing.Point(396, 105);
            this.buttonTopUps.Name = "buttonTopUps";
            this.buttonTopUps.Size = new System.Drawing.Size(90, 30);
            this.buttonTopUps.TabIndex = 4;
            this.buttonTopUps.Text = "Top-Ups";
            this.buttonTopUps.UseVisualStyleBackColor = true;
            this.buttonTopUps.Click += new System.EventHandler(this.buttonTopUps_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(286, 51);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 50;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.ButtonAll_Click);
            // 
            // buttonAppointment
            // 
            this.buttonAppointment.Location = new System.Drawing.Point(283, 105);
            this.buttonAppointment.Name = "buttonAppointment";
            this.buttonAppointment.Size = new System.Drawing.Size(114, 30);
            this.buttonAppointment.TabIndex = 3;
            this.buttonAppointment.Text = "Appointments";
            this.buttonAppointment.UseVisualStyleBackColor = true;
            this.buttonAppointment.Click += new System.EventHandler(this.buttonAppointment_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 47;
            this.label1.Text = "Date";
            // 
            // comboBoxDate
            // 
            this.comboBoxDate.FormattingEnabled = true;
            this.comboBoxDate.Items.AddRange(new object[] {
            "All",
            "27",
            "28",
            "29"});
            this.comboBoxDate.Location = new System.Drawing.Point(13, 50);
            this.comboBoxDate.Name = "comboBoxDate";
            this.comboBoxDate.Size = new System.Drawing.Size(121, 24);
            this.comboBoxDate.TabIndex = 46;
            // 
            // buttonPurchased
            // 
            this.buttonPurchased.Location = new System.Drawing.Point(194, 105);
            this.buttonPurchased.Name = "buttonPurchased";
            this.buttonPurchased.Size = new System.Drawing.Size(90, 30);
            this.buttonPurchased.TabIndex = 2;
            this.buttonPurchased.Text = "purchased";
            this.buttonPurchased.UseVisualStyleBackColor = true;
            this.buttonPurchased.Click += new System.EventHandler(this.buttonPurchased_Click);
            // 
            // buttonloaned
            // 
            this.buttonloaned.Location = new System.Drawing.Point(105, 105);
            this.buttonloaned.Name = "buttonloaned";
            this.buttonloaned.Size = new System.Drawing.Size(90, 30);
            this.buttonloaned.TabIndex = 1;
            this.buttonloaned.Text = "Loaned";
            this.buttonloaned.UseVisualStyleBackColor = true;
            this.buttonloaned.Click += new System.EventHandler(this.buttonloaned_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(125, 2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(165, 138);
            this.pictureBox2.TabIndex = 45;
            this.pictureBox2.TabStop = false;
            // 
            // Visitors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 589);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Visitors";
            this.Text = "Visitors";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBoxVisitor;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBoxVisitor;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buttonTopUps;
        private System.Windows.Forms.Button buttonAppointment;
        private System.Windows.Forms.Button buttonPurchased;
        private System.Windows.Forms.Button buttonloaned;
        private System.Windows.Forms.Button buttonAll;
        private System.Windows.Forms.Button buttonTent;

    }
}