﻿namespace Design.Idea.EmployeeV1
{
    partial class EmployeesPCDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeesPCDoc));
            this.lb5 = new System.Windows.Forms.Label();
            this.appList2 = new System.Windows.Forms.ListBox();
            this.lb4 = new System.Windows.Forms.Label();
            this.appList1 = new System.Windows.Forms.ListBox();
            this.lb1 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.TextBox();
            this.lb2 = new System.Windows.Forms.Label();
            this.name1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pic = new System.Windows.Forms.PictureBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            this.SuspendLayout();
            // 
            // lb5
            // 
            this.lb5.AutoSize = true;
            this.lb5.Location = new System.Drawing.Point(356, 326);
            this.lb5.Name = "lb5";
            this.lb5.Size = new System.Drawing.Size(123, 13);
            this.lb5.TabIndex = 102;
            this.lb5.Text = "Completed appointments";
            // 
            // appList2
            // 
            this.appList2.FormattingEnabled = true;
            this.appList2.Location = new System.Drawing.Point(354, 345);
            this.appList2.Name = "appList2";
            this.appList2.Size = new System.Drawing.Size(332, 186);
            this.appList2.TabIndex = 101;
            // 
            // lb4
            // 
            this.lb4.AutoSize = true;
            this.lb4.Location = new System.Drawing.Point(26, 326);
            this.lb4.Name = "lb4";
            this.lb4.Size = new System.Drawing.Size(111, 13);
            this.lb4.TabIndex = 99;
            this.lb4.Text = "Queued appointments";
            // 
            // appList1
            // 
            this.appList1.FormattingEnabled = true;
            this.appList1.Location = new System.Drawing.Point(16, 345);
            this.appList1.Name = "appList1";
            this.appList1.Size = new System.Drawing.Size(332, 186);
            this.appList1.TabIndex = 98;
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Location = new System.Drawing.Point(114, 27);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(43, 13);
            this.lb1.TabIndex = 91;
            this.lb1.Text = "ID Card";
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(157, 24);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(86, 20);
            this.ID.TabIndex = 95;
            // 
            // lb2
            // 
            this.lb2.AutoSize = true;
            this.lb2.Location = new System.Drawing.Point(116, 58);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(35, 13);
            this.lb2.TabIndex = 92;
            this.lb2.Text = "Name";
            // 
            // name1
            // 
            this.name1.Location = new System.Drawing.Point(157, 54);
            this.name1.Name = "name1";
            this.name1.Size = new System.Drawing.Size(86, 20);
            this.name1.TabIndex = 96;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(29, 538);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 33);
            this.button1.TabIndex = 100;
            this.button1.Text = "Finish appointment";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pic
            // 
            this.pic.Image = ((System.Drawing.Image)(resources.GetObject("pic.Image")));
            this.pic.InitialImage = null;
            this.pic.Location = new System.Drawing.Point(10, 7);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(100, 95);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 90;
            this.pic.TabStop = false;
            // 
            // pic2
            // 
            this.pic2.Image = ((System.Drawing.Image)(resources.GetObject("pic2.Image")));
            this.pic2.Location = new System.Drawing.Point(538, 11);
            this.pic2.Margin = new System.Windows.Forms.Padding(2);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(154, 125);
            this.pic2.TabIndex = 97;
            this.pic2.TabStop = false;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(85, 268);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 33);
            this.button2.TabIndex = 103;
            this.button2.Text = "Add appointment";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 162);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(86, 20);
            this.textBox1.TabIndex = 104;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(77, 214);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(142, 48);
            this.textBox2.TabIndex = 105;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 106;
            this.label1.Text = "Brand";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 107;
            this.label2.Text = "Description";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(77, 188);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(86, 20);
            this.textBox3.TabIndex = 109;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 110;
            this.label3.Text = "Model";
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(225, 268);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 33);
            this.button3.TabIndex = 111;
            this.button3.Text = "View tasks";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // EmployeesPCDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 585);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lb5);
            this.Controls.Add(this.appList2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lb4);
            this.Controls.Add(this.appList1);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.lb2);
            this.Controls.Add(this.name1);
            this.Controls.Add(this.pic2);
            this.Name = "EmployeesPCDoc";
            this.Text = "EmployeesPCDoc";
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb5;
        private System.Windows.Forms.ListBox appList2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb4;
        private System.Windows.Forms.ListBox appList1;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.TextBox name1;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
    }
}