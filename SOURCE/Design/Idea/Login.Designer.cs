namespace Design.Idea
{
    partial class Login
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.dynamicContainer.SuspendLayout();
            this.topNavContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.SuspendLayout();
            // 
            // dynamicContainer
            // 
            this.dynamicContainer.Controls.Add(this.label1);
            this.dynamicContainer.Controls.Add(this.textBox1);
            this.dynamicContainer.Controls.Add(this.textBox2);
            this.dynamicContainer.Controls.Add(this.button1);
            this.dynamicContainer.Location = new System.Drawing.Point(20, 119);
            this.dynamicContainer.Margin = new System.Windows.Forms.Padding(5);
            this.dynamicContainer.Size = new System.Drawing.Size(310, 214);
            // 
            // topNavContainer
            // 
            this.topNavContainer.Controls.Add(this.pictureBox11);
            this.topNavContainer.Location = new System.Drawing.Point(-1, 0);
            this.topNavContainer.Margin = new System.Windows.Forms.Padding(5);
            this.topNavContainer.Size = new System.Drawing.Size(403, 148);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 176);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(73, 86);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(207, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Identifier // username // code";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(73, 118);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(207, 22);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "password";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(69, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 50);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter you credentials OR Approach your card to the reader";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = global::Design.Properties.Resources.LOGO_Proshot;
            this.pictureBox11.Location = new System.Drawing.Point(98, 0);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(203, 167);
            this.pictureBox11.TabIndex = 8;
            this.pictureBox11.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 334);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Login";
            this.Text = "Login";
            this.dynamicContainer.ResumeLayout(false);
            this.dynamicContainer.PerformLayout();
            this.topNavContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox11;
    }
}