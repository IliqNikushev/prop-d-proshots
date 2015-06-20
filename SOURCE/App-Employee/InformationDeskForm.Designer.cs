namespace App_Employee
{
    partial class InformationDeskForm
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
            this.logoPBox = new System.Windows.Forms.PictureBox();
            this.logOutBtn = new System.Windows.Forms.Button();
            this.lblRfid = new System.Windows.Forms.Label();
            this.lblInfoRow3 = new System.Windows.Forms.Label();
            this.giveTagBtn = new System.Windows.Forms.Button();
            this.closeAccountBtn = new System.Windows.Forms.Button();
            this.payTicketBtn = new System.Windows.Forms.Button();
            this.lblInfoRow1 = new System.Windows.Forms.Label();
            this.visitorSearchTbox = new System.Windows.Forms.TextBox();
            this.lblInfoRow2 = new System.Windows.Forms.Label();
            this.lbPeople = new System.Windows.Forms.ListBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTicket = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPBox)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPBox
            // 
            this.logoPBox.Image = global::App_Employee.Properties.Resources.LOGO_Proshot;
            this.logoPBox.Location = new System.Drawing.Point(458, 2);
            this.logoPBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.logoPBox.Name = "logoPBox";
            this.logoPBox.Size = new System.Drawing.Size(64, 64);
            this.logoPBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPBox.TabIndex = 14;
            this.logoPBox.TabStop = false;
            // 
            // logOutBtn
            // 
            this.logOutBtn.Location = new System.Drawing.Point(52, 313);
            this.logOutBtn.Name = "logOutBtn";
            this.logOutBtn.Size = new System.Drawing.Size(75, 23);
            this.logOutBtn.TabIndex = 29;
            this.logOutBtn.Text = "Logout";
            this.logOutBtn.UseVisualStyleBackColor = true;
            this.logOutBtn.Click += new System.EventHandler(this.logOutBtn_Click_1);
            // 
            // lblRfid
            // 
            this.lblRfid.AutoSize = true;
            this.lblRfid.Location = new System.Drawing.Point(374, 124);
            this.lblRfid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRfid.Name = "lblRfid";
            this.lblRfid.Size = new System.Drawing.Size(32, 13);
            this.lblRfid.TabIndex = 41;
            this.lblRfid.Text = "RFID";
            // 
            // lblInfoRow3
            // 
            this.lblInfoRow3.AutoSize = true;
            this.lblInfoRow3.Location = new System.Drawing.Point(50, 85);
            this.lblInfoRow3.Name = "lblInfoRow3";
            this.lblInfoRow3.Size = new System.Drawing.Size(100, 13);
            this.lblInfoRow3.TabIndex = 31;
            this.lblInfoRow3.Text = "Search for a person";
            // 
            // giveTagBtn
            // 
            this.giveTagBtn.Location = new System.Drawing.Point(397, 313);
            this.giveTagBtn.Name = "giveTagBtn";
            this.giveTagBtn.Size = new System.Drawing.Size(75, 23);
            this.giveTagBtn.TabIndex = 32;
            this.giveTagBtn.Text = "Give Tag";
            this.giveTagBtn.UseVisualStyleBackColor = true;
            this.giveTagBtn.Click += new System.EventHandler(this.giveTagBtn_Click);
            // 
            // closeAccountBtn
            // 
            this.closeAccountBtn.Location = new System.Drawing.Point(199, 313);
            this.closeAccountBtn.Name = "closeAccountBtn";
            this.closeAccountBtn.Size = new System.Drawing.Size(90, 23);
            this.closeAccountBtn.TabIndex = 33;
            this.closeAccountBtn.Text = "Close Account";
            this.closeAccountBtn.UseVisualStyleBackColor = true;
            this.closeAccountBtn.Click += new System.EventHandler(this.closeAccountBtn_Click);
            // 
            // payTicketBtn
            // 
            this.payTicketBtn.Location = new System.Drawing.Point(207, 276);
            this.payTicketBtn.Name = "payTicketBtn";
            this.payTicketBtn.Size = new System.Drawing.Size(75, 23);
            this.payTicketBtn.TabIndex = 34;
            this.payTicketBtn.Text = "Pay Ticket";
            this.payTicketBtn.UseVisualStyleBackColor = true;
            this.payTicketBtn.Click += new System.EventHandler(this.payTicketBtn_Click_1);
            // 
            // lblInfoRow1
            // 
            this.lblInfoRow1.AutoSize = true;
            this.lblInfoRow1.Location = new System.Drawing.Point(4, 58);
            this.lblInfoRow1.Name = "lblInfoRow1";
            this.lblInfoRow1.Size = new System.Drawing.Size(192, 13);
            this.lblInfoRow1.TabIndex = 35;
            this.lblInfoRow1.Text = "Approach the visitor\'s tag to the reader ";
            // 
            // visitorSearchTbox
            // 
            this.visitorSearchTbox.Location = new System.Drawing.Point(52, 102);
            this.visitorSearchTbox.Name = "visitorSearchTbox";
            this.visitorSearchTbox.Size = new System.Drawing.Size(420, 20);
            this.visitorSearchTbox.TabIndex = 30;
            this.visitorSearchTbox.TextChanged += new System.EventHandler(this.visitorSearchTbox_TextChanged_1);
            // 
            // lblInfoRow2
            // 
            this.lblInfoRow2.AutoSize = true;
            this.lblInfoRow2.Location = new System.Drawing.Point(88, 72);
            this.lblInfoRow2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInfoRow2.Name = "lblInfoRow2";
            this.lblInfoRow2.Size = new System.Drawing.Size(16, 13);
            this.lblInfoRow2.TabIndex = 37;
            this.lblInfoRow2.Text = "or";
            // 
            // lbPeople
            // 
            this.lbPeople.FormattingEnabled = true;
            this.lbPeople.Location = new System.Drawing.Point(52, 137);
            this.lbPeople.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbPeople.Name = "lbPeople";
            this.lbPeople.Size = new System.Drawing.Size(420, 121);
            this.lbPeople.TabIndex = 38;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(60, 124);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 39;
            this.lblName.Text = "Name";
            // 
            // lblTicket
            // 
            this.lblTicket.AutoSize = true;
            this.lblTicket.Location = new System.Drawing.Point(235, 124);
            this.lblTicket.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTicket.Name = "lblTicket";
            this.lblTicket.Size = new System.Drawing.Size(37, 13);
            this.lblTicket.TabIndex = 40;
            this.lblTicket.Text = "Ticket";
            // 
            // InformationDeskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 384);
            this.Controls.Add(this.lblRfid);
            this.Controls.Add(this.lblTicket);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lbPeople);
            this.Controls.Add(this.lblInfoRow2);
            this.Controls.Add(this.lblInfoRow1);
            this.Controls.Add(this.payTicketBtn);
            this.Controls.Add(this.closeAccountBtn);
            this.Controls.Add(this.giveTagBtn);
            this.Controls.Add(this.lblInfoRow3);
            this.Controls.Add(this.visitorSearchTbox);
            this.Controls.Add(this.logOutBtn);
            this.Controls.Add(this.logoPBox);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "InformationDeskForm";
            this.Text = "Information Desk";
            ((System.ComponentModel.ISupportInitialize)(this.logoPBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPBox;
        private System.Windows.Forms.Button logOutBtn;
        private System.Windows.Forms.Label lblRfid;
        private System.Windows.Forms.Label lblInfoRow3;
        private System.Windows.Forms.Button giveTagBtn;
        private System.Windows.Forms.Button closeAccountBtn;
        private System.Windows.Forms.Button payTicketBtn;
        private System.Windows.Forms.Label lblInfoRow1;
        private System.Windows.Forms.TextBox visitorSearchTbox;
        private System.Windows.Forms.Label lblInfoRow2;
        private System.Windows.Forms.ListBox lbPeople;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTicket;

    }
}