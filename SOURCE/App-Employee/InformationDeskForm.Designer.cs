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
            this.logOutBtn = new System.Windows.Forms.Button();
            this.visitorSearchTbox = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.searchLbl = new System.Windows.Forms.Label();
            this.giveTagBtn = new System.Windows.Forms.Button();
            this.closeAccountBtn = new System.Windows.Forms.Button();
            this.payTicketBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.logoPBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoPBox)).BeginInit();
            this.SuspendLayout();
            // 
            // logOutBtn
            // 
            this.logOutBtn.Location = new System.Drawing.Point(13, 280);
            this.logOutBtn.Name = "logOutBtn";
            this.logOutBtn.Size = new System.Drawing.Size(75, 23);
            this.logOutBtn.TabIndex = 0;
            this.logOutBtn.Text = "Logout";
            this.logOutBtn.UseVisualStyleBackColor = true;
            // 
            // visitorSearchTbox
            // 
            this.visitorSearchTbox.Location = new System.Drawing.Point(13, 70);
            this.visitorSearchTbox.Name = "visitorSearchTbox";
            this.visitorSearchTbox.Size = new System.Drawing.Size(420, 20);
            this.visitorSearchTbox.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 96);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(420, 69);
            this.listBox1.TabIndex = 2;
            // 
            // searchLbl
            // 
            this.searchLbl.AutoSize = true;
            this.searchLbl.Location = new System.Drawing.Point(70, 54);
            this.searchLbl.Name = "searchLbl";
            this.searchLbl.Size = new System.Drawing.Size(100, 13);
            this.searchLbl.TabIndex = 3;
            this.searchLbl.Text = "Search for a person";
            // 
            // giveTagBtn
            // 
            this.giveTagBtn.Location = new System.Drawing.Point(358, 280);
            this.giveTagBtn.Name = "giveTagBtn";
            this.giveTagBtn.Size = new System.Drawing.Size(75, 23);
            this.giveTagBtn.TabIndex = 4;
            this.giveTagBtn.Text = "Give Tag";
            this.giveTagBtn.UseVisualStyleBackColor = true;
            // 
            // closeAccountBtn
            // 
            this.closeAccountBtn.Location = new System.Drawing.Point(204, 280);
            this.closeAccountBtn.Name = "closeAccountBtn";
            this.closeAccountBtn.Size = new System.Drawing.Size(90, 23);
            this.closeAccountBtn.TabIndex = 5;
            this.closeAccountBtn.Text = "Close Account";
            this.closeAccountBtn.UseVisualStyleBackColor = true;
            // 
            // payTicketBtn
            // 
            this.payTicketBtn.Location = new System.Drawing.Point(358, 251);
            this.payTicketBtn.Name = "payTicketBtn";
            this.payTicketBtn.Size = new System.Drawing.Size(75, 23);
            this.payTicketBtn.TabIndex = 6;
            this.payTicketBtn.Text = "Pay Ticket";
            this.payTicketBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Approach the visitor\'s tag to the reader or";
            // 
            // logoPBox
            // 
            this.logoPBox.Image = global::App_Employee.Properties.Resources.LOGO_Proshot;
            this.logoPBox.Location = new System.Drawing.Point(391, 0);
            this.logoPBox.Margin = new System.Windows.Forms.Padding(2);
            this.logoPBox.Name = "logoPBox";
            this.logoPBox.Size = new System.Drawing.Size(55, 55);
            this.logoPBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPBox.TabIndex = 14;
            this.logoPBox.TabStop = false;
            // 
            // InformationDeskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 315);
            this.Controls.Add(this.logoPBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.payTicketBtn);
            this.Controls.Add(this.closeAccountBtn);
            this.Controls.Add(this.giveTagBtn);
            this.Controls.Add(this.searchLbl);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.visitorSearchTbox);
            this.Controls.Add(this.logOutBtn);
            this.Name = "InformationDeskForm";
            this.Text = "InformationDeskForm";
            ((System.ComponentModel.ISupportInitialize)(this.logoPBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logOutBtn;
        private System.Windows.Forms.TextBox visitorSearchTbox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label searchLbl;
        private System.Windows.Forms.Button giveTagBtn;
        private System.Windows.Forms.Button closeAccountBtn;
        private System.Windows.Forms.Button payTicketBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox logoPBox;
    }
}