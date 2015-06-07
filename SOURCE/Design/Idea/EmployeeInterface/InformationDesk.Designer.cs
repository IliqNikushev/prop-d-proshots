namespace Design.Idea.EmployeeInterface
{
    partial class InformationDesk
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
            this.label1 = new System.Windows.Forms.Label();
            this.payTicketBtn = new System.Windows.Forms.Button();
            this.closeAccountBtn = new System.Windows.Forms.Button();
            this.giveTagBtn = new System.Windows.Forms.Button();
            this.searchLbl = new System.Windows.Forms.Label();
            this.visitorSearchTbox = new System.Windows.Forms.TextBox();
            this.logOutBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPBox)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPBox
            // 
            this.logoPBox.Location = new System.Drawing.Point(521, 11);
            this.logoPBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logoPBox.Name = "logoPBox";
            this.logoPBox.Size = new System.Drawing.Size(116, 94);
            this.logoPBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPBox.TabIndex = 23;
            this.logoPBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Approach the visitor\'s tag to the reader ";
            // 
            // payTicketBtn
            // 
            this.payTicketBtn.Location = new System.Drawing.Point(284, 325);
            this.payTicketBtn.Margin = new System.Windows.Forms.Padding(4);
            this.payTicketBtn.Name = "payTicketBtn";
            this.payTicketBtn.Size = new System.Drawing.Size(100, 28);
            this.payTicketBtn.TabIndex = 21;
            this.payTicketBtn.Text = "Pay Ticket";
            this.payTicketBtn.UseVisualStyleBackColor = true;
            this.payTicketBtn.Click += new System.EventHandler(this.payTicketBtn_Click);
            // 
            // closeAccountBtn
            // 
            this.closeAccountBtn.Location = new System.Drawing.Point(273, 370);
            this.closeAccountBtn.Margin = new System.Windows.Forms.Padding(4);
            this.closeAccountBtn.Name = "closeAccountBtn";
            this.closeAccountBtn.Size = new System.Drawing.Size(120, 28);
            this.closeAccountBtn.TabIndex = 20;
            this.closeAccountBtn.Text = "Close Account";
            this.closeAccountBtn.UseVisualStyleBackColor = true;
            this.closeAccountBtn.Click += new System.EventHandler(this.closeAccountBtn_Click);
            // 
            // giveTagBtn
            // 
            this.giveTagBtn.Location = new System.Drawing.Point(537, 370);
            this.giveTagBtn.Margin = new System.Windows.Forms.Padding(4);
            this.giveTagBtn.Name = "giveTagBtn";
            this.giveTagBtn.Size = new System.Drawing.Size(100, 28);
            this.giveTagBtn.TabIndex = 19;
            this.giveTagBtn.Text = "Give Tag";
            this.giveTagBtn.UseVisualStyleBackColor = true;
            this.giveTagBtn.Click += new System.EventHandler(this.giveTagBtn_Click);
            // 
            // searchLbl
            // 
            this.searchLbl.AutoSize = true;
            this.searchLbl.Location = new System.Drawing.Point(74, 90);
            this.searchLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.searchLbl.Name = "searchLbl";
            this.searchLbl.Size = new System.Drawing.Size(134, 17);
            this.searchLbl.TabIndex = 18;
            this.searchLbl.Text = "Search for a person";
            // 
            // visitorSearchTbox
            // 
            this.visitorSearchTbox.Location = new System.Drawing.Point(77, 111);
            this.visitorSearchTbox.Margin = new System.Windows.Forms.Padding(4);
            this.visitorSearchTbox.Name = "visitorSearchTbox";
            this.visitorSearchTbox.Size = new System.Drawing.Size(559, 22);
            this.visitorSearchTbox.TabIndex = 16;
            this.visitorSearchTbox.TextChanged += new System.EventHandler(this.visitorSearchTbox_TextChanged);
            // 
            // logOutBtn
            // 
            this.logOutBtn.Location = new System.Drawing.Point(77, 370);
            this.logOutBtn.Margin = new System.Windows.Forms.Padding(4);
            this.logOutBtn.Name = "logOutBtn";
            this.logOutBtn.Size = new System.Drawing.Size(100, 28);
            this.logOutBtn.TabIndex = 15;
            this.logOutBtn.Text = "Logout";
            this.logOutBtn.UseVisualStyleBackColor = true;
            this.logOutBtn.Click += new System.EventHandler(this.logOutBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "or";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(77, 154);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(559, 148);
            this.listBox1.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(321, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Ticket";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(507, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "RFID";
            // 
            // InformationDesk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 422);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logoPBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.payTicketBtn);
            this.Controls.Add(this.closeAccountBtn);
            this.Controls.Add(this.giveTagBtn);
            this.Controls.Add(this.searchLbl);
            this.Controls.Add(this.visitorSearchTbox);
            this.Controls.Add(this.logOutBtn);
            this.Name = "InformationDesk";
            this.Text = "InformationDeskForm";
            ((System.ComponentModel.ISupportInitialize)(this.logoPBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button payTicketBtn;
        private System.Windows.Forms.Button closeAccountBtn;
        private System.Windows.Forms.Button giveTagBtn;
        private System.Windows.Forms.Label searchLbl;
        private System.Windows.Forms.TextBox visitorSearchTbox;
        private System.Windows.Forms.Button logOutBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}