namespace App_PayPal
{
    partial class ProcessingForm
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
            this.profilePBox = new System.Windows.Forms.PictureBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.topUpBtn = new System.Windows.Forms.Button();
            this.amountTbox = new System.Windows.Forms.TextBox();
            this.amountLbl = new System.Windows.Forms.Label();
            this.resultLbl = new System.Windows.Forms.Label();
            this.nameLbl = new System.Windows.Forms.Label();
            this.balanceLbl = new System.Windows.Forms.Label();
            this.addCBox = new System.Windows.Forms.CheckBox();
            this.resultBalanceTxtLbl = new System.Windows.Forms.Label();
            this.optionsGBox = new System.Windows.Forms.GroupBox();
            this.setCBox = new System.Windows.Forms.CheckBox();
            this.currentBalanceTxtLbl = new System.Windows.Forms.Label();
            this.balancePnl = new System.Windows.Forms.Panel();
            this.balanceTxtLbl = new System.Windows.Forms.Label();
            this.withdrawNotAllowedLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.profilePBox)).BeginInit();
            this.optionsGBox.SuspendLayout();
            this.balancePnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // profilePBox
            // 
            this.profilePBox.Location = new System.Drawing.Point(12, 12);
            this.profilePBox.Name = "profilePBox";
            this.profilePBox.Size = new System.Drawing.Size(128, 128);
            this.profilePBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.profilePBox.TabIndex = 0;
            this.profilePBox.TabStop = false;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(12, 226);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // topUpBtn
            // 
            this.topUpBtn.Location = new System.Drawing.Point(206, 226);
            this.topUpBtn.Name = "topUpBtn";
            this.topUpBtn.Size = new System.Drawing.Size(75, 23);
            this.topUpBtn.TabIndex = 2;
            this.topUpBtn.Text = "Top Up";
            this.topUpBtn.UseVisualStyleBackColor = true;
            this.topUpBtn.Click += new System.EventHandler(this.topUpBtn_Click);
            // 
            // amountTbox
            // 
            this.amountTbox.Location = new System.Drawing.Point(89, 196);
            this.amountTbox.Name = "amountTbox";
            this.amountTbox.Size = new System.Drawing.Size(111, 20);
            this.amountTbox.TabIndex = 3;
            // 
            // amountLbl
            // 
            this.amountLbl.AutoSize = true;
            this.amountLbl.Location = new System.Drawing.Point(40, 180);
            this.amountLbl.Name = "amountLbl";
            this.amountLbl.Size = new System.Drawing.Size(210, 13);
            this.amountLbl.TabIndex = 4;
            this.amountLbl.Text = "Enter the value to modify your balance with";
            // 
            // resultLbl
            // 
            this.resultLbl.AutoSize = true;
            this.resultLbl.Location = new System.Drawing.Point(56, 22);
            this.resultLbl.Name = "resultLbl";
            this.resultLbl.Size = new System.Drawing.Size(32, 13);
            this.resultLbl.TabIndex = 5;
            this.resultLbl.Text = "result";
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(12, 147);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(35, 13);
            this.nameLbl.TabIndex = 7;
            this.nameLbl.Text = "Name";
            // 
            // balanceLbl
            // 
            this.balanceLbl.AutoSize = true;
            this.balanceLbl.Location = new System.Drawing.Point(56, 0);
            this.balanceLbl.Name = "balanceLbl";
            this.balanceLbl.Size = new System.Drawing.Size(46, 13);
            this.balanceLbl.TabIndex = 8;
            this.balanceLbl.Text = "Balance";
            // 
            // addCBox
            // 
            this.addCBox.AutoSize = true;
            this.addCBox.Checked = true;
            this.addCBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.addCBox.Location = new System.Drawing.Point(6, 19);
            this.addCBox.Name = "addCBox";
            this.addCBox.Size = new System.Drawing.Size(127, 17);
            this.addCBox.TabIndex = 9;
            this.addCBox.Text = "Add value to balance";
            this.addCBox.UseVisualStyleBackColor = true;
            this.addCBox.CheckedChanged += new System.EventHandler(this.addCBox_CheckedChanged);
            // 
            // resultBalanceTxtLbl
            // 
            this.resultBalanceTxtLbl.AutoSize = true;
            this.resultBalanceTxtLbl.Location = new System.Drawing.Point(2, 22);
            this.resultBalanceTxtLbl.Name = "resultBalanceTxtLbl";
            this.resultBalanceTxtLbl.Size = new System.Drawing.Size(37, 13);
            this.resultBalanceTxtLbl.TabIndex = 10;
            this.resultBalanceTxtLbl.Text = "Result";
            // 
            // optionsGBox
            // 
            this.optionsGBox.Controls.Add(this.setCBox);
            this.optionsGBox.Controls.Add(this.addCBox);
            this.optionsGBox.Location = new System.Drawing.Point(146, 12);
            this.optionsGBox.Name = "optionsGBox";
            this.optionsGBox.Size = new System.Drawing.Size(135, 69);
            this.optionsGBox.TabIndex = 11;
            this.optionsGBox.TabStop = false;
            this.optionsGBox.Text = "Options";
            // 
            // setCBox
            // 
            this.setCBox.AutoSize = true;
            this.setCBox.Location = new System.Drawing.Point(6, 42);
            this.setCBox.Name = "setCBox";
            this.setCBox.Size = new System.Drawing.Size(124, 17);
            this.setCBox.TabIndex = 11;
            this.setCBox.Text = "Set balance to value";
            this.setCBox.UseVisualStyleBackColor = true;
            this.setCBox.CheckedChanged += new System.EventHandler(this.setCBox_CheckedChanged);
            // 
            // currentBalanceTxtLbl
            // 
            this.currentBalanceTxtLbl.AutoSize = true;
            this.currentBalanceTxtLbl.Location = new System.Drawing.Point(2, 0);
            this.currentBalanceTxtLbl.Name = "currentBalanceTxtLbl";
            this.currentBalanceTxtLbl.Size = new System.Drawing.Size(41, 13);
            this.currentBalanceTxtLbl.TabIndex = 12;
            this.currentBalanceTxtLbl.Text = "Current";
            // 
            // balancePnl
            // 
            this.balancePnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.balancePnl.Controls.Add(this.currentBalanceTxtLbl);
            this.balancePnl.Controls.Add(this.balanceLbl);
            this.balancePnl.Controls.Add(this.resultLbl);
            this.balancePnl.Controls.Add(this.resultBalanceTxtLbl);
            this.balancePnl.Location = new System.Drawing.Point(146, 100);
            this.balancePnl.Name = "balancePnl";
            this.balancePnl.Size = new System.Drawing.Size(135, 40);
            this.balancePnl.TabIndex = 13;
            // 
            // balanceTxtLbl
            // 
            this.balanceTxtLbl.AutoSize = true;
            this.balanceTxtLbl.Location = new System.Drawing.Point(167, 84);
            this.balanceTxtLbl.Name = "balanceTxtLbl";
            this.balanceTxtLbl.Size = new System.Drawing.Size(46, 13);
            this.balanceTxtLbl.TabIndex = 14;
            this.balanceTxtLbl.Text = "Balance";
            // 
            // withdrawNotAllowedLbl
            // 
            this.withdrawNotAllowedLbl.AutoSize = true;
            this.withdrawNotAllowedLbl.Location = new System.Drawing.Point(80, 167);
            this.withdrawNotAllowedLbl.Name = "withdrawNotAllowedLbl";
            this.withdrawNotAllowedLbl.Size = new System.Drawing.Size(133, 13);
            this.withdrawNotAllowedLbl.TabIndex = 15;
            this.withdrawNotAllowedLbl.Text = "Withdrawing is not allowed";
            // 
            // ProcessingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 261);
            this.Controls.Add(this.withdrawNotAllowedLbl);
            this.Controls.Add(this.balanceTxtLbl);
            this.Controls.Add(this.optionsGBox);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.amountLbl);
            this.Controls.Add(this.amountTbox);
            this.Controls.Add(this.topUpBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.profilePBox);
            this.Controls.Add(this.balancePnl);
            this.Name = "ProcessingForm";
            this.Text = "PayPal top-up";
            ((System.ComponentModel.ISupportInitialize)(this.profilePBox)).EndInit();
            this.optionsGBox.ResumeLayout(false);
            this.optionsGBox.PerformLayout();
            this.balancePnl.ResumeLayout(false);
            this.balancePnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox profilePBox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button topUpBtn;
        private System.Windows.Forms.TextBox amountTbox;
        private System.Windows.Forms.Label amountLbl;
        private System.Windows.Forms.Label resultLbl;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Label balanceLbl;
        private System.Windows.Forms.CheckBox addCBox;
        private System.Windows.Forms.Label resultBalanceTxtLbl;
        private System.Windows.Forms.GroupBox optionsGBox;
        private System.Windows.Forms.CheckBox setCBox;
        private System.Windows.Forms.Label currentBalanceTxtLbl;
        private System.Windows.Forms.Panel balancePnl;
        private System.Windows.Forms.Label balanceTxtLbl;
        private System.Windows.Forms.Label withdrawNotAllowedLbl;
    }
}