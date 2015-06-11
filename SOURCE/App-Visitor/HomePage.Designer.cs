namespace App_Visitor
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.ExitPicture = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelBalance = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.RentedPicture = new System.Windows.Forms.PictureBox();
            this.ProfilePicture = new System.Windows.Forms.PictureBox();
            this.BookedPicture = new System.Windows.Forms.PictureBox();
            this.PurchasedPicture = new System.Windows.Forms.PictureBox();
            this.AppointmentsPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ExitPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RentedPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BookedPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchasedPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentsPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // findByNameTb
            // 
            this.findByNameTb.Margin = new System.Windows.Forms.Padding(5);
            this.findByNameTb.Size = new System.Drawing.Size(172, 29);
            // 
            // findByTypeTb
            // 
            this.findByTypeTb.Margin = new System.Windows.Forms.Padding(5);
            this.findByTypeTb.Size = new System.Drawing.Size(172, 29);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(115, 313);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(329, 180);
            this.listBox1.TabIndex = 61;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(112, 94);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(46, 17);
            this.labelEmail.TabIndex = 60;
            this.labelEmail.Text = "Email:";
            // 
            // ExitPicture
            // 
            this.ExitPicture.Image = ((System.Drawing.Image)(resources.GetObject("ExitPicture.Image")));
            this.ExitPicture.Location = new System.Drawing.Point(12, 2);
            this.ExitPicture.Name = "ExitPicture";
            this.ExitPicture.Size = new System.Drawing.Size(38, 41);
            this.ExitPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ExitPicture.TabIndex = 59;
            this.ExitPicture.TabStop = false;
            this.ExitPicture.Click += new System.EventHandler(this.ExitPicture_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(259, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 17);
            this.label8.TabIndex = 58;
            this.label8.Text = "Rented";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 50;
            this.label2.Text = "Booked";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-1, 398);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 17);
            this.label7.TabIndex = 56;
            this.label7.Text = "Appointments";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 287);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 52;
            this.label4.Text = "Purchased";
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.Location = new System.Drawing.Point(112, 118);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(63, 17);
            this.labelBalance.TabIndex = 54;
            this.labelBalance.Text = "Balance:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(112, 68);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(49, 17);
            this.labelName.TabIndex = 53;
            this.labelName.Text = "Name:";
            // 
            // RentedPicture
            // 
            this.RentedPicture.Image = ((System.Drawing.Image)(resources.GetObject("RentedPicture.Image")));
            this.RentedPicture.Location = new System.Drawing.Point(232, 203);
            this.RentedPicture.Name = "RentedPicture";
            this.RentedPicture.Size = new System.Drawing.Size(96, 104);
            this.RentedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RentedPicture.TabIndex = 57;
            this.RentedPicture.TabStop = false;
            this.RentedPicture.Click += new System.EventHandler(this.RentedPicture_Click);
            // 
            // ProfilePicture
            // 
            this.ProfilePicture.Image = ((System.Drawing.Image)(resources.GetObject("ProfilePicture.Image")));
            this.ProfilePicture.Location = new System.Drawing.Point(-5, 59);
            this.ProfilePicture.Name = "ProfilePicture";
            this.ProfilePicture.Size = new System.Drawing.Size(111, 111);
            this.ProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProfilePicture.TabIndex = 48;
            this.ProfilePicture.TabStop = false;
            // 
            // BookedPicture
            // 
            this.BookedPicture.Image = ((System.Drawing.Image)(resources.GetObject("BookedPicture.Image")));
            this.BookedPicture.Location = new System.Drawing.Point(-3, 200);
            this.BookedPicture.Name = "BookedPicture";
            this.BookedPicture.Size = new System.Drawing.Size(96, 104);
            this.BookedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BookedPicture.TabIndex = 49;
            this.BookedPicture.TabStop = false;
            this.BookedPicture.Click += new System.EventHandler(this.BookedPicture_Click);
            // 
            // PurchasedPicture
            // 
            this.PurchasedPicture.Image = ((System.Drawing.Image)(resources.GetObject("PurchasedPicture.Image")));
            this.PurchasedPicture.Location = new System.Drawing.Point(115, 200);
            this.PurchasedPicture.Name = "PurchasedPicture";
            this.PurchasedPicture.Size = new System.Drawing.Size(96, 104);
            this.PurchasedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PurchasedPicture.TabIndex = 51;
            this.PurchasedPicture.TabStop = false;
            this.PurchasedPicture.Click += new System.EventHandler(this.PurchasedPicture_Click);
            // 
            // AppointmentsPicture
            // 
            this.AppointmentsPicture.Image = ((System.Drawing.Image)(resources.GetObject("AppointmentsPicture.Image")));
            this.AppointmentsPicture.Location = new System.Drawing.Point(-3, 311);
            this.AppointmentsPicture.Name = "AppointmentsPicture";
            this.AppointmentsPicture.Size = new System.Drawing.Size(96, 104);
            this.AppointmentsPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AppointmentsPicture.TabIndex = 55;
            this.AppointmentsPicture.TabStop = false;
            this.AppointmentsPicture.Click += new System.EventHandler(this.AppointmentsPicture_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 625);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.ExitPicture);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelBalance);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.RentedPicture);
            this.Controls.Add(this.ProfilePicture);
            this.Controls.Add(this.BookedPicture);
            this.Controls.Add(this.PurchasedPicture);
            this.Controls.Add(this.AppointmentsPicture);
            this.Margin = new System.Windows.Forms.Padding(12, 9, 12, 9);
            this.Name = "HomePage";
            this.Text = "HomePage";
            this.Controls.SetChildIndex(this.findByNameLbl, 0);
            this.Controls.SetChildIndex(this.findByTypeTb, 0);
            this.Controls.SetChildIndex(this.findByTypeLbl, 0);
            this.Controls.SetChildIndex(this.findByNameTb, 0);
            this.Controls.SetChildIndex(this.AppointmentsPicture, 0);
            this.Controls.SetChildIndex(this.PurchasedPicture, 0);
            this.Controls.SetChildIndex(this.BookedPicture, 0);
            this.Controls.SetChildIndex(this.ProfilePicture, 0);
            this.Controls.SetChildIndex(this.RentedPicture, 0);
            this.Controls.SetChildIndex(this.labelName, 0);
            this.Controls.SetChildIndex(this.labelBalance, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.ExitPicture, 0);
            this.Controls.SetChildIndex(this.labelEmail, 0);
            this.Controls.SetChildIndex(this.listBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ExitPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RentedPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BookedPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchasedPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentsPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.PictureBox ExitPicture;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.PictureBox RentedPicture;
        private System.Windows.Forms.PictureBox ProfilePicture;
        private System.Windows.Forms.PictureBox BookedPicture;
        private System.Windows.Forms.PictureBox PurchasedPicture;
        private System.Windows.Forms.PictureBox AppointmentsPicture;
    }
}