namespace App_Camps
{
    partial class CampingMenu
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
            this.logoutBtn = new System.Windows.Forms.Button();
            this.todayLbl = new System.Windows.Forms.Label();
            this.freeTentsLbl = new System.Windows.Forms.Label();
            this.occupiedByYouLbl = new System.Windows.Forms.Label();
            this.bookedByDetailsBtn = new System.Windows.Forms.Button();
            this.bookedForDetailsBtn = new System.Windows.Forms.Button();
            this.bookedByLBox = new System.Windows.Forms.ListBox();
            this.bookedForLBox = new System.Windows.Forms.ListBox();
            this.includedInLbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.takenTentsLbl = new System.Windows.Forms.Label();
            this.dtBookedLbl = new System.Windows.Forms.Label();
            this.bookedByLbl = new System.Windows.Forms.Label();
            this.isPaidLbl = new System.Windows.Forms.Label();
            this.bookedForLbl = new System.Windows.Forms.Label();
            this.bookedForDetailsLbox = new System.Windows.Forms.ListBox();
            this.pitchNumberLbl = new System.Windows.Forms.Label();
            this.showOnMapBtn = new System.Windows.Forms.Button();
            this.detailsPanel = new System.Windows.Forms.Panel();
            this.isPaidCbox = new System.Windows.Forms.CheckBox();
            this.closeDetailsBtn = new System.Windows.Forms.Button();
            this.detailsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // logoutBtn
            // 
            this.logoutBtn.Location = new System.Drawing.Point(26, 244);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(75, 23);
            this.logoutBtn.TabIndex = 0;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // todayLbl
            // 
            this.todayLbl.AutoSize = true;
            this.todayLbl.Location = new System.Drawing.Point(122, 9);
            this.todayLbl.Name = "todayLbl";
            this.todayLbl.Size = new System.Drawing.Size(62, 13);
            this.todayLbl.TabIndex = 1;
            this.todayLbl.Text = "Today label";
            // 
            // freeTentsLbl
            // 
            this.freeTentsLbl.AutoSize = true;
            this.freeTentsLbl.Location = new System.Drawing.Point(43, 28);
            this.freeTentsLbl.Name = "freeTentsLbl";
            this.freeTentsLbl.Size = new System.Drawing.Size(144, 13);
            this.freeTentsLbl.TabIndex = 2;
            this.freeTentsLbl.Text = "Number of free tent pitches : ";
            // 
            // occupiedByYouLbl
            // 
            this.occupiedByYouLbl.AutoSize = true;
            this.occupiedByYouLbl.Location = new System.Drawing.Point(23, 66);
            this.occupiedByYouLbl.Name = "occupiedByYouLbl";
            this.occupiedByYouLbl.Size = new System.Drawing.Size(139, 13);
            this.occupiedByYouLbl.TabIndex = 3;
            this.occupiedByYouLbl.Text = "Booked tent pitches by you:";
            // 
            // bookedByDetailsBtn
            // 
            this.bookedByDetailsBtn.Location = new System.Drawing.Point(233, 101);
            this.bookedByDetailsBtn.Name = "bookedByDetailsBtn";
            this.bookedByDetailsBtn.Size = new System.Drawing.Size(77, 23);
            this.bookedByDetailsBtn.TabIndex = 4;
            this.bookedByDetailsBtn.Text = "Details";
            this.bookedByDetailsBtn.UseVisualStyleBackColor = true;
            this.bookedByDetailsBtn.Click += new System.EventHandler(this.bookedByDetailsBtn_Click);
            // 
            // bookedForDetailsBtn
            // 
            this.bookedForDetailsBtn.Location = new System.Drawing.Point(235, 182);
            this.bookedForDetailsBtn.Name = "bookedForDetailsBtn";
            this.bookedForDetailsBtn.Size = new System.Drawing.Size(75, 23);
            this.bookedForDetailsBtn.TabIndex = 5;
            this.bookedForDetailsBtn.Text = "Details";
            this.bookedForDetailsBtn.UseVisualStyleBackColor = true;
            this.bookedForDetailsBtn.Click += new System.EventHandler(this.bookedForDetailsBtn_Click);
            // 
            // bookedByLBox
            // 
            this.bookedByLBox.FormattingEnabled = true;
            this.bookedByLBox.Location = new System.Drawing.Point(26, 84);
            this.bookedByLBox.Name = "bookedByLBox";
            this.bookedByLBox.Size = new System.Drawing.Size(196, 56);
            this.bookedByLBox.TabIndex = 6;
            // 
            // bookedForLBox
            // 
            this.bookedForLBox.FormattingEnabled = true;
            this.bookedForLBox.Location = new System.Drawing.Point(26, 165);
            this.bookedForLBox.Name = "bookedForLBox";
            this.bookedForLBox.Size = new System.Drawing.Size(196, 56);
            this.bookedForLBox.TabIndex = 7;
            // 
            // includedInLbl
            // 
            this.includedInLbl.AutoSize = true;
            this.includedInLbl.Location = new System.Drawing.Point(23, 149);
            this.includedInLbl.Name = "includedInLbl";
            this.includedInLbl.Size = new System.Drawing.Size(161, 13);
            this.includedInLbl.TabIndex = 8;
            this.includedInLbl.Text = "Tent pitches you are included in:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Book a tent pitch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // takenTentsLbl
            // 
            this.takenTentsLbl.AutoSize = true;
            this.takenTentsLbl.Location = new System.Drawing.Point(35, 45);
            this.takenTentsLbl.Name = "takenTentsLbl";
            this.takenTentsLbl.Size = new System.Drawing.Size(153, 13);
            this.takenTentsLbl.TabIndex = 10;
            this.takenTentsLbl.Text = "Number of taken tent pitches : ";
            // 
            // dtBookedLbl
            // 
            this.dtBookedLbl.AutoSize = true;
            this.dtBookedLbl.Location = new System.Drawing.Point(10, 46);
            this.dtBookedLbl.Name = "dtBookedLbl";
            this.dtBookedLbl.Size = new System.Drawing.Size(143, 13);
            this.dtBookedLbl.TabIndex = 11;
            this.dtBookedLbl.Text = "Date and time tent is booked";
            // 
            // bookedByLbl
            // 
            this.bookedByLbl.AutoSize = true;
            this.bookedByLbl.Location = new System.Drawing.Point(10, 87);
            this.bookedByLbl.Name = "bookedByLbl";
            this.bookedByLbl.Size = new System.Drawing.Size(58, 13);
            this.bookedByLbl.TabIndex = 12;
            this.bookedByLbl.Text = "Booked by";
            // 
            // isPaidLbl
            // 
            this.isPaidLbl.AutoSize = true;
            this.isPaidLbl.Location = new System.Drawing.Point(10, 125);
            this.isPaidLbl.Name = "isPaidLbl";
            this.isPaidLbl.Size = new System.Drawing.Size(39, 13);
            this.isPaidLbl.TabIndex = 13;
            this.isPaidLbl.Text = "Is Paid";
            // 
            // bookedForLbl
            // 
            this.bookedForLbl.AutoSize = true;
            this.bookedForLbl.Location = new System.Drawing.Point(10, 146);
            this.bookedForLbl.Name = "bookedForLbl";
            this.bookedForLbl.Size = new System.Drawing.Size(62, 13);
            this.bookedForLbl.TabIndex = 14;
            this.bookedForLbl.Text = "Booked for:";
            // 
            // bookedForDetailsLbox
            // 
            this.bookedForDetailsLbox.FormattingEnabled = true;
            this.bookedForDetailsLbox.Location = new System.Drawing.Point(7, 161);
            this.bookedForDetailsLbox.Name = "bookedForDetailsLbox";
            this.bookedForDetailsLbox.Size = new System.Drawing.Size(146, 69);
            this.bookedForDetailsLbox.TabIndex = 15;
            // 
            // pitchNumberLbl
            // 
            this.pitchNumberLbl.AutoSize = true;
            this.pitchNumberLbl.Location = new System.Drawing.Point(13, 9);
            this.pitchNumberLbl.Name = "pitchNumberLbl";
            this.pitchNumberLbl.Size = new System.Drawing.Size(69, 13);
            this.pitchNumberLbl.TabIndex = 16;
            this.pitchNumberLbl.Text = "Pitch number";
            // 
            // showOnMapBtn
            // 
            this.showOnMapBtn.Location = new System.Drawing.Point(43, 236);
            this.showOnMapBtn.Name = "showOnMapBtn";
            this.showOnMapBtn.Size = new System.Drawing.Size(75, 23);
            this.showOnMapBtn.TabIndex = 17;
            this.showOnMapBtn.Text = "See on map";
            this.showOnMapBtn.UseVisualStyleBackColor = true;
            this.showOnMapBtn.Click += new System.EventHandler(this.showOnMapBtn_Click);
            // 
            // detailsPanel
            // 
            this.detailsPanel.Controls.Add(this.closeDetailsBtn);
            this.detailsPanel.Controls.Add(this.isPaidCbox);
            this.detailsPanel.Controls.Add(this.showOnMapBtn);
            this.detailsPanel.Controls.Add(this.pitchNumberLbl);
            this.detailsPanel.Controls.Add(this.dtBookedLbl);
            this.detailsPanel.Controls.Add(this.bookedForDetailsLbox);
            this.detailsPanel.Controls.Add(this.bookedByLbl);
            this.detailsPanel.Controls.Add(this.bookedForLbl);
            this.detailsPanel.Controls.Add(this.isPaidLbl);
            this.detailsPanel.Location = new System.Drawing.Point(322, 12);
            this.detailsPanel.Name = "detailsPanel";
            this.detailsPanel.Size = new System.Drawing.Size(155, 263);
            this.detailsPanel.TabIndex = 18;
            // 
            // isPaidCbox
            // 
            this.isPaidCbox.AutoSize = true;
            this.isPaidCbox.Location = new System.Drawing.Point(55, 124);
            this.isPaidCbox.Name = "isPaidCbox";
            this.isPaidCbox.Size = new System.Drawing.Size(83, 17);
            this.isPaidCbox.TabIndex = 18;
            this.isPaidCbox.Text = "$$$$$$$.$$";
            this.isPaidCbox.UseVisualStyleBackColor = true;
            // 
            // closeDetailsBtn
            // 
            this.closeDetailsBtn.Location = new System.Drawing.Point(137, 0);
            this.closeDetailsBtn.Name = "closeDetailsBtn";
            this.closeDetailsBtn.Size = new System.Drawing.Size(18, 23);
            this.closeDetailsBtn.TabIndex = 19;
            this.closeDetailsBtn.Text = "X";
            this.closeDetailsBtn.UseVisualStyleBackColor = true;
            this.closeDetailsBtn.Click += new System.EventHandler(this.closeDetailsBtn_Click);
            // 
            // CampingMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 278);
            this.Controls.Add(this.takenTentsLbl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.includedInLbl);
            this.Controls.Add(this.bookedForLBox);
            this.Controls.Add(this.bookedByLBox);
            this.Controls.Add(this.bookedForDetailsBtn);
            this.Controls.Add(this.bookedByDetailsBtn);
            this.Controls.Add(this.occupiedByYouLbl);
            this.Controls.Add(this.freeTentsLbl);
            this.Controls.Add(this.todayLbl);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.detailsPanel);
            this.Name = "CampingMenu";
            this.Text = "Camping Menu";
            this.detailsPanel.ResumeLayout(false);
            this.detailsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Label todayLbl;
        private System.Windows.Forms.Label freeTentsLbl;
        private System.Windows.Forms.Label occupiedByYouLbl;
        private System.Windows.Forms.Button bookedByDetailsBtn;
        private System.Windows.Forms.Button bookedForDetailsBtn;
        private System.Windows.Forms.ListBox bookedByLBox;
        private System.Windows.Forms.ListBox bookedForLBox;
        private System.Windows.Forms.Label includedInLbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label takenTentsLbl;
        private System.Windows.Forms.Label dtBookedLbl;
        private System.Windows.Forms.Label bookedByLbl;
        private System.Windows.Forms.Label isPaidLbl;
        private System.Windows.Forms.Label bookedForLbl;
        private System.Windows.Forms.ListBox bookedForDetailsLbox;
        private System.Windows.Forms.Label pitchNumberLbl;
        private System.Windows.Forms.Button showOnMapBtn;
        private System.Windows.Forms.Panel detailsPanel;
        private System.Windows.Forms.CheckBox isPaidCbox;
        private System.Windows.Forms.Button closeDetailsBtn;
    }
}