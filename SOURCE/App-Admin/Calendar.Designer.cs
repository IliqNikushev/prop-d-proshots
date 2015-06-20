namespace App_Admin
{
    partial class Calendar
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
            this.btnRem = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.labelDescription = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDate = new System.Windows.Forms.ComboBox();
            this.lbResult = new System.Windows.Forms.ListBox();
            this.btnBack = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            this.SuspendLayout();
            // 
            // findByNameTb
            // 
            this.findByNameTb.Margin = new System.Windows.Forms.Padding(2);
            this.findByNameTb.Size = new System.Drawing.Size(130, 17);
            // 
            // findByTypeTb
            // 
            this.findByTypeTb.Margin = new System.Windows.Forms.Padding(2);
            this.findByTypeTb.Size = new System.Drawing.Size(130, 17);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRem);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.labelDescription);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxDate);
            this.groupBox1.Controls.Add(this.lbResult);
            this.groupBox1.Location = new System.Drawing.Point(4, 117);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(330, 361);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Events sorted by:";
            // 
            // btnRem
            // 
            this.btnRem.Location = new System.Drawing.Point(131, 30);
            this.btnRem.Margin = new System.Windows.Forms.Padding(2);
            this.btnRem.Name = "btnRem";
            this.btnRem.Size = new System.Drawing.Size(82, 25);
            this.btnRem.TabIndex = 39;
            this.btnRem.Text = "Remove Event";
            this.btnRem.UseVisualStyleBackColor = true;
            this.btnRem.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(226, 30);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 25);
            this.btnAdd.TabIndex = 38;
            this.btnAdd.Text = "Add Event";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelDescription
            // 
            this.labelDescription.Location = new System.Drawing.Point(3, 292);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(310, 105);
            this.labelDescription.TabIndex = 37;
            this.labelDescription.Text = "Description: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Date";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBoxDate
            // 
            this.comboBoxDate.FormattingEnabled = true;
            this.comboBoxDate.Items.AddRange(new object[] {
            "ALL",
            "27",
            "28",
            "29"});
            this.comboBoxDate.Location = new System.Drawing.Point(16, 37);
            this.comboBoxDate.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxDate.Name = "comboBoxDate";
            this.comboBoxDate.Size = new System.Drawing.Size(92, 21);
            this.comboBoxDate.TabIndex = 35;
            this.comboBoxDate.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lbResult
            // 
            this.lbResult.FormattingEnabled = true;
            this.lbResult.Location = new System.Drawing.Point(5, 64);
            this.lbResult.Margin = new System.Windows.Forms.Padding(2);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(309, 212);
            this.lbResult.TabIndex = 30;
            this.lbResult.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnBack
            // 
            this.btnBack.Image = global::App_Admin.Properties.Resources.Back2;
            this.btnBack.Location = new System.Drawing.Point(4, 2);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(49, 34);
            this.btnBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBack.TabIndex = 42;
            this.btnBack.TabStop = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 534);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Calendar";
            this.Text = "Calendar";
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
        private System.Windows.Forms.ListBox lbResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDate;
        private System.Windows.Forms.PictureBox btnBack;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRem;

    }
}