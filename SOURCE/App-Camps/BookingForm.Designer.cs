namespace App_Camps
{
    partial class BookingForm
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
            this.nightsNUD = new System.Windows.Forms.NumericUpDown();
            this.nNightsLbl = new System.Windows.Forms.Label();
            this.pitchesCBox = new System.Windows.Forms.ComboBox();
            this.selectLbl = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateTagLbl = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.confrimBtn = new System.Windows.Forms.Button();
            this.hr = new System.Windows.Forms.Label();
            this.hr1 = new System.Windows.Forms.Label();
            this.totalTagLbl = new System.Windows.Forms.Label();
            this.fromLbl = new System.Windows.Forms.Label();
            this.toLbl = new System.Windows.Forms.Label();
            this.priceTagLbl = new System.Windows.Forms.Label();
            this.pricePerPersonlbl = new System.Windows.Forms.Label();
            this.initialPriceLbl = new System.Windows.Forms.Label();
            this.initialPriceTagLbl = new System.Windows.Forms.Label();
            this.priceInfoLbl = new System.Windows.Forms.Label();
            this.bookedForPeopleLbl = new System.Windows.Forms.Label();
            this.totalPriceLbl = new System.Windows.Forms.Label();
            this.addPeopleLbl = new System.Windows.Forms.Label();
            this.addPersonBtn = new System.Windows.Forms.Button();
            this.findByNameCbox = new System.Windows.Forms.CheckBox();
            this.findByEmailCbox = new System.Windows.Forms.CheckBox();
            this.bookedAlready = new System.Windows.Forms.Label();
            this.dateFromTbox = new System.Windows.Forms.TextBox();
            this.toDateTbox = new System.Windows.Forms.TextBox();
            this.peopleLocation = new System.Windows.Forms.Label();
            this.currentBalanceLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nightsNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // nightsNUD
            // 
            this.nightsNUD.Location = new System.Drawing.Point(79, 156);
            this.nightsNUD.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nightsNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nightsNUD.Name = "nightsNUD";
            this.nightsNUD.Size = new System.Drawing.Size(42, 20);
            this.nightsNUD.TabIndex = 37;
            this.nightsNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nightsNUD.ValueChanged += new System.EventHandler(this.nightsNUD_ValueChanged);
            // 
            // nNightsLbl
            // 
            this.nNightsLbl.AutoSize = true;
            this.nNightsLbl.Location = new System.Drawing.Point(12, 133);
            this.nNightsLbl.Name = "nNightsLbl";
            this.nNightsLbl.Size = new System.Drawing.Size(191, 13);
            this.nNightsLbl.TabIndex = 38;
            this.nNightsLbl.Text = "Number of nights you would like to stay";
            // 
            // pitchesCBox
            // 
            this.pitchesCBox.FormattingEnabled = true;
            this.pitchesCBox.Location = new System.Drawing.Point(71, 49);
            this.pitchesCBox.Name = "pitchesCBox";
            this.pitchesCBox.Size = new System.Drawing.Size(77, 21);
            this.pitchesCBox.TabIndex = 39;
            this.pitchesCBox.SelectedIndexChanged += new System.EventHandler(this.pitchesCBox_SelectedIndexChanged);
            // 
            // selectLbl
            // 
            this.selectLbl.AutoSize = true;
            this.selectLbl.Location = new System.Drawing.Point(12, 33);
            this.selectLbl.Name = "selectLbl";
            this.selectLbl.Size = new System.Drawing.Size(255, 13);
            this.selectLbl.TabIndex = 40;
            this.selectLbl.Text = "Select a tent from the map or using this selection box";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "dddd, dd";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(45, 101);
            this.dateTimePicker.MaxDate = new System.DateTime(2015, 6, 28, 0, 0, 0, 0);
            this.dateTimePicker.MinDate = new System.DateTime(2015, 6, 26, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker.TabIndex = 41;
            this.dateTimePicker.Value = new System.DateTime(2015, 6, 26, 0, 0, 0, 0);
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // dateTagLbl
            // 
            this.dateTagLbl.AutoSize = true;
            this.dateTagLbl.Location = new System.Drawing.Point(11, 85);
            this.dateTagLbl.Name = "dateTagLbl";
            this.dateTagLbl.Size = new System.Drawing.Size(199, 13);
            this.dateTagLbl.TabIndex = 42;
            this.dateTagLbl.Text = "Day you would like to book your pitch for";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(4, 435);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 43;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // confrimBtn
            // 
            this.confrimBtn.Location = new System.Drawing.Point(258, 435);
            this.confrimBtn.Name = "confrimBtn";
            this.confrimBtn.Size = new System.Drawing.Size(75, 23);
            this.confrimBtn.TabIndex = 44;
            this.confrimBtn.Text = "Confirm";
            this.confrimBtn.UseVisualStyleBackColor = true;
            this.confrimBtn.Click += new System.EventHandler(this.confrimBtn_Click);
            // 
            // hr
            // 
            this.hr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hr.Location = new System.Drawing.Point(-16, 422);
            this.hr.Name = "hr";
            this.hr.Size = new System.Drawing.Size(365, 10);
            this.hr.TabIndex = 45;
            // 
            // hr1
            // 
            this.hr1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hr1.Location = new System.Drawing.Point(-16, 328);
            this.hr1.Name = "hr1";
            this.hr1.Size = new System.Drawing.Size(365, 10);
            this.hr1.TabIndex = 46;
            // 
            // totalTagLbl
            // 
            this.totalTagLbl.AutoSize = true;
            this.totalTagLbl.Location = new System.Drawing.Point(185, 403);
            this.totalTagLbl.Name = "totalTagLbl";
            this.totalTagLbl.Size = new System.Drawing.Size(60, 13);
            this.totalTagLbl.TabIndex = 47;
            this.totalTagLbl.Text = "Total price:";
            // 
            // fromLbl
            // 
            this.fromLbl.AutoSize = true;
            this.fromLbl.Location = new System.Drawing.Point(12, 380);
            this.fromLbl.Name = "fromLbl";
            this.fromLbl.Size = new System.Drawing.Size(30, 13);
            this.fromLbl.TabIndex = 49;
            this.fromLbl.Text = "From";
            // 
            // toLbl
            // 
            this.toLbl.AutoSize = true;
            this.toLbl.Location = new System.Drawing.Point(190, 380);
            this.toLbl.Name = "toLbl";
            this.toLbl.Size = new System.Drawing.Size(20, 13);
            this.toLbl.TabIndex = 50;
            this.toLbl.Text = "To";
            // 
            // priceTagLbl
            // 
            this.priceTagLbl.AutoSize = true;
            this.priceTagLbl.Location = new System.Drawing.Point(12, 358);
            this.priceTagLbl.Name = "priceTagLbl";
            this.priceTagLbl.Size = new System.Drawing.Size(84, 13);
            this.priceTagLbl.TabIndex = 52;
            this.priceTagLbl.Text = "Price per person";
            // 
            // pricePerPersonlbl
            // 
            this.pricePerPersonlbl.AutoSize = true;
            this.pricePerPersonlbl.Location = new System.Drawing.Point(108, 358);
            this.pricePerPersonlbl.Name = "pricePerPersonlbl";
            this.pricePerPersonlbl.Size = new System.Drawing.Size(25, 13);
            this.pricePerPersonlbl.TabIndex = 53;
            this.pricePerPersonlbl.Text = "20$";
            // 
            // initialPriceLbl
            // 
            this.initialPriceLbl.AutoSize = true;
            this.initialPriceLbl.Location = new System.Drawing.Point(273, 358);
            this.initialPriceLbl.Name = "initialPriceLbl";
            this.initialPriceLbl.Size = new System.Drawing.Size(25, 13);
            this.initialPriceLbl.TabIndex = 55;
            this.initialPriceLbl.Text = "30$";
            // 
            // initialPriceTagLbl
            // 
            this.initialPriceTagLbl.AutoSize = true;
            this.initialPriceTagLbl.Location = new System.Drawing.Point(188, 358);
            this.initialPriceTagLbl.Name = "initialPriceTagLbl";
            this.initialPriceTagLbl.Size = new System.Drawing.Size(57, 13);
            this.initialPriceTagLbl.TabIndex = 54;
            this.initialPriceTagLbl.Text = "Initial price";
            // 
            // priceInfoLbl
            // 
            this.priceInfoLbl.AutoSize = true;
            this.priceInfoLbl.Location = new System.Drawing.Point(31, 341);
            this.priceInfoLbl.Name = "priceInfoLbl";
            this.priceInfoLbl.Size = new System.Drawing.Size(267, 13);
            this.priceInfoLbl.TabIndex = 56;
            this.priceInfoLbl.Text = "The price is calculated for every night spent individually";
            // 
            // bookedForPeopleLbl
            // 
            this.bookedForPeopleLbl.AutoSize = true;
            this.bookedForPeopleLbl.Location = new System.Drawing.Point(12, 403);
            this.bookedForPeopleLbl.Name = "bookedForPeopleLbl";
            this.bookedForPeopleLbl.Size = new System.Drawing.Size(109, 13);
            this.bookedForPeopleLbl.TabIndex = 57;
            this.bookedForPeopleLbl.Text = "Booked for <> people";
            // 
            // totalPriceLbl
            // 
            this.totalPriceLbl.AutoSize = true;
            this.totalPriceLbl.Location = new System.Drawing.Point(247, 403);
            this.totalPriceLbl.Name = "totalPriceLbl";
            this.totalPriceLbl.Size = new System.Drawing.Size(82, 13);
            this.totalPriceLbl.TabIndex = 58;
            this.totalPriceLbl.Text = "$$$$$$$$$$.$$";
            // 
            // addPeopleLbl
            // 
            this.addPeopleLbl.AutoSize = true;
            this.addPeopleLbl.Location = new System.Drawing.Point(26, 186);
            this.addPeopleLbl.Name = "addPeopleLbl";
            this.addPeopleLbl.Size = new System.Drawing.Size(215, 13);
            this.addPeopleLbl.TabIndex = 64;
            this.addPeopleLbl.Text = "You can add up to 5 people to stay with you";
            // 
            // addPersonBtn
            // 
            this.addPersonBtn.Location = new System.Drawing.Point(247, 181);
            this.addPersonBtn.Name = "addPersonBtn";
            this.addPersonBtn.Size = new System.Drawing.Size(82, 23);
            this.addPersonBtn.TabIndex = 65;
            this.addPersonBtn.Text = "Add a person";
            this.addPersonBtn.UseVisualStyleBackColor = true;
            this.addPersonBtn.Click += new System.EventHandler(this.addPersonBtn_Click);
            // 
            // findByNameCbox
            // 
            this.findByNameCbox.AutoSize = true;
            this.findByNameCbox.Checked = true;
            this.findByNameCbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.findByNameCbox.Location = new System.Drawing.Point(243, 209);
            this.findByNameCbox.Name = "findByNameCbox";
            this.findByNameCbox.Size = new System.Drawing.Size(86, 17);
            this.findByNameCbox.TabIndex = 66;
            this.findByNameCbox.Text = "find by name";
            this.findByNameCbox.UseVisualStyleBackColor = true;
            this.findByNameCbox.CheckedChanged += new System.EventHandler(this.findByNameCbox_CheckedChanged);
            // 
            // findByEmailCbox
            // 
            this.findByEmailCbox.AutoSize = true;
            this.findByEmailCbox.Location = new System.Drawing.Point(243, 231);
            this.findByEmailCbox.Name = "findByEmailCbox";
            this.findByEmailCbox.Size = new System.Drawing.Size(84, 17);
            this.findByEmailCbox.TabIndex = 67;
            this.findByEmailCbox.Text = "find by email";
            this.findByEmailCbox.UseVisualStyleBackColor = true;
            this.findByEmailCbox.CheckedChanged += new System.EventHandler(this.findByEmailCbox_CheckedChanged);
            // 
            // bookedAlready
            // 
            this.bookedAlready.Location = new System.Drawing.Point(188, 101);
            this.bookedAlready.Name = "bookedAlready";
            this.bookedAlready.Size = new System.Drawing.Size(141, 32);
            this.bookedAlready.TabIndex = 73;
            this.bookedAlready.Text = "You have an active booking for this day";
            this.bookedAlready.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dateFromTbox
            // 
            this.dateFromTbox.Location = new System.Drawing.Point(45, 376);
            this.dateFromTbox.Name = "dateFromTbox";
            this.dateFromTbox.Size = new System.Drawing.Size(100, 20);
            this.dateFromTbox.TabIndex = 74;
            // 
            // toDateTbox
            // 
            this.toDateTbox.Location = new System.Drawing.Point(216, 377);
            this.toDateTbox.Name = "toDateTbox";
            this.toDateTbox.Size = new System.Drawing.Size(100, 20);
            this.toDateTbox.TabIndex = 75;
            // 
            // peopleLocation
            // 
            this.peopleLocation.AutoSize = true;
            this.peopleLocation.Location = new System.Drawing.Point(15, 203);
            this.peopleLocation.Name = "peopleLocation";
            this.peopleLocation.Size = new System.Drawing.Size(131, 13);
            this.peopleLocation.TabIndex = 76;
            this.peopleLocation.Text = "PEOPLE PLACEHOLDER";
            // 
            // currentBalanceLbl
            // 
            this.currentBalanceLbl.AutoSize = true;
            this.currentBalanceLbl.Location = new System.Drawing.Point(96, 443);
            this.currentBalanceLbl.Name = "currentBalanceLbl";
            this.currentBalanceLbl.Size = new System.Drawing.Size(149, 13);
            this.currentBalanceLbl.TabIndex = 77;
            this.currentBalanceLbl.Text = "Your balance is: $$$$$$$$.$$";
            // 
            // BookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 470);
            this.Controls.Add(this.currentBalanceLbl);
            this.Controls.Add(this.peopleLocation);
            this.Controls.Add(this.toDateTbox);
            this.Controls.Add(this.dateFromTbox);
            this.Controls.Add(this.bookedAlready);
            this.Controls.Add(this.findByEmailCbox);
            this.Controls.Add(this.findByNameCbox);
            this.Controls.Add(this.addPersonBtn);
            this.Controls.Add(this.addPeopleLbl);
            this.Controls.Add(this.totalPriceLbl);
            this.Controls.Add(this.bookedForPeopleLbl);
            this.Controls.Add(this.priceInfoLbl);
            this.Controls.Add(this.initialPriceLbl);
            this.Controls.Add(this.initialPriceTagLbl);
            this.Controls.Add(this.pricePerPersonlbl);
            this.Controls.Add(this.priceTagLbl);
            this.Controls.Add(this.toLbl);
            this.Controls.Add(this.fromLbl);
            this.Controls.Add(this.totalTagLbl);
            this.Controls.Add(this.confrimBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.dateTagLbl);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.selectLbl);
            this.Controls.Add(this.pitchesCBox);
            this.Controls.Add(this.nNightsLbl);
            this.Controls.Add(this.nightsNUD);
            this.Controls.Add(this.hr1);
            this.Controls.Add(this.hr);
            this.Name = "BookingForm";
            this.Text = "Book a tent pitch";
            //this.Controls.SetChildIndex(this.findByNameLbl, 0);
            //this.Controls.SetChildIndex(this.findByTypeTb, 0);
            //this.Controls.SetChildIndex(this.findByTypeLbl, 0);
            //this.Controls.SetChildIndex(this.findByNameTb, 0);
            this.Controls.SetChildIndex(this.hr, 0);
            this.Controls.SetChildIndex(this.hr1, 0);
            this.Controls.SetChildIndex(this.nightsNUD, 0);
            this.Controls.SetChildIndex(this.nNightsLbl, 0);
            this.Controls.SetChildIndex(this.pitchesCBox, 0);
            this.Controls.SetChildIndex(this.selectLbl, 0);
            this.Controls.SetChildIndex(this.dateTimePicker, 0);
            this.Controls.SetChildIndex(this.dateTagLbl, 0);
            this.Controls.SetChildIndex(this.cancelBtn, 0);
            this.Controls.SetChildIndex(this.confrimBtn, 0);
            this.Controls.SetChildIndex(this.totalTagLbl, 0);
            this.Controls.SetChildIndex(this.fromLbl, 0);
            this.Controls.SetChildIndex(this.toLbl, 0);
            this.Controls.SetChildIndex(this.priceTagLbl, 0);
            this.Controls.SetChildIndex(this.pricePerPersonlbl, 0);
            this.Controls.SetChildIndex(this.initialPriceTagLbl, 0);
            this.Controls.SetChildIndex(this.initialPriceLbl, 0);
            this.Controls.SetChildIndex(this.priceInfoLbl, 0);
            this.Controls.SetChildIndex(this.bookedForPeopleLbl, 0);
            this.Controls.SetChildIndex(this.totalPriceLbl, 0);
            this.Controls.SetChildIndex(this.addPeopleLbl, 0);
            this.Controls.SetChildIndex(this.addPersonBtn, 0);
            this.Controls.SetChildIndex(this.findByNameCbox, 0);
            this.Controls.SetChildIndex(this.findByEmailCbox, 0);
            this.Controls.SetChildIndex(this.bookedAlready, 0);
            this.Controls.SetChildIndex(this.dateFromTbox, 0);
            this.Controls.SetChildIndex(this.toDateTbox, 0);
            this.Controls.SetChildIndex(this.peopleLocation, 0);
            this.Controls.SetChildIndex(this.currentBalanceLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nightsNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nightsNUD;
        private System.Windows.Forms.Label nNightsLbl;
        private System.Windows.Forms.ComboBox pitchesCBox;
        private System.Windows.Forms.Label selectLbl;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label dateTagLbl;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button confrimBtn;
        private System.Windows.Forms.Label hr;
        private System.Windows.Forms.Label hr1;
        private System.Windows.Forms.Label totalTagLbl;
        private System.Windows.Forms.Label fromLbl;
        private System.Windows.Forms.Label toLbl;
        private System.Windows.Forms.Label priceTagLbl;
        private System.Windows.Forms.Label pricePerPersonlbl;
        private System.Windows.Forms.Label initialPriceLbl;
        private System.Windows.Forms.Label initialPriceTagLbl;
        private System.Windows.Forms.Label priceInfoLbl;
        private System.Windows.Forms.Label bookedForPeopleLbl;
        private System.Windows.Forms.Label totalPriceLbl;
        private System.Windows.Forms.Label addPeopleLbl;
        private System.Windows.Forms.Button addPersonBtn;
        private System.Windows.Forms.CheckBox findByNameCbox;
        private System.Windows.Forms.CheckBox findByEmailCbox;
        private System.Windows.Forms.Label bookedAlready;
        private System.Windows.Forms.TextBox dateFromTbox;
        private System.Windows.Forms.TextBox toDateTbox;
        private System.Windows.Forms.Label peopleLocation;
        private System.Windows.Forms.Label currentBalanceLbl;
    }
}