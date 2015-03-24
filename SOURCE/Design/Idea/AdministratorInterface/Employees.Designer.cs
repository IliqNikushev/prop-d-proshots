namespace Design.Examples
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
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.FilterComboBox = new System.Windows.Forms.ComboBox();
            this.SearchByNameTXTB = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Employees";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::Design.Properties.Resources.manager;
            this.pictureBox8.Location = new System.Drawing.Point(89, 12);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(128, 128);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 16;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Design.Properties.Resources.Back;
            this.pictureBox3.Location = new System.Drawing.Point(1, 1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            // 
            // FilterComboBox
            // 
            this.FilterComboBox.FormattingEnabled = true;
            this.FilterComboBox.Location = new System.Drawing.Point(234, 17);
            this.FilterComboBox.Name = "FilterComboBox";
            this.FilterComboBox.Size = new System.Drawing.Size(121, 24);
            this.FilterComboBox.TabIndex = 18;
            // 
            // SearchByNameTXTB
            // 
            this.SearchByNameTXTB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.SearchByNameTXTB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.SearchByNameTXTB.Location = new System.Drawing.Point(371, 17);
            this.SearchByNameTXTB.Name = "SearchByNameTXTB";
            this.SearchByNameTXTB.Size = new System.Drawing.Size(109, 22);
            this.SearchByNameTXTB.TabIndex = 19;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 164);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(548, 260);
            this.listBox1.TabIndex = 20;
            // 
            // Employees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 442);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.SearchByNameTXTB);
            this.Controls.Add(this.FilterComboBox);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.label5);
            this.Name = "Employees";
            this.Text = "Employees";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ComboBox FilterComboBox;
        private System.Windows.Forms.TextBox SearchByNameTXTB;
        private System.Windows.Forms.ListBox listBox1;
    }
}