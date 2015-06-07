﻿namespace Design
{
    partial class Main
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
            this.adminGUIBtn = new System.Windows.Forms.Button();
            this.visitorGUIBtn = new System.Windows.Forms.Button();
            this.EmployeeGUIBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // adminGUIBtn
            // 
            this.adminGUIBtn.Location = new System.Drawing.Point(13, 13);
            this.adminGUIBtn.Name = "adminGUIBtn";
            this.adminGUIBtn.Size = new System.Drawing.Size(75, 23);
            this.adminGUIBtn.TabIndex = 0;
            this.adminGUIBtn.Text = "Admin";
            this.adminGUIBtn.UseVisualStyleBackColor = true;
            this.adminGUIBtn.Click += new System.EventHandler(this.adminGUIBtn_Click);
            // 
            // visitorGUIBtn
            // 
            this.visitorGUIBtn.Location = new System.Drawing.Point(94, 13);
            this.visitorGUIBtn.Name = "visitorGUIBtn";
            this.visitorGUIBtn.Size = new System.Drawing.Size(75, 23);
            this.visitorGUIBtn.TabIndex = 1;
            this.visitorGUIBtn.Text = "visitor";
            this.visitorGUIBtn.UseVisualStyleBackColor = true;
            this.visitorGUIBtn.Click += new System.EventHandler(this.visitorGUIBtn_Click);
            // 
            // EmployeeGUIBtn
            // 
            this.EmployeeGUIBtn.Location = new System.Drawing.Point(175, 12);
            this.EmployeeGUIBtn.Name = "EmployeeGUIBtn";
            this.EmployeeGUIBtn.Size = new System.Drawing.Size(75, 23);
            this.EmployeeGUIBtn.TabIndex = 2;
            this.EmployeeGUIBtn.Text = "Employee";
            this.EmployeeGUIBtn.UseVisualStyleBackColor = true;
            this.EmployeeGUIBtn.Click += new System.EventHandler(this.employeeGUIBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "TODO : Close or Hide ? ( Keep what the visitor has done ? ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Design.Properties.Resources.LOGO_Proshot;
            this.pictureBox1.Location = new System.Drawing.Point(72, 89);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 136);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EmployeeGUIBtn);
            this.Controls.Add(this.visitorGUIBtn);
            this.Controls.Add(this.adminGUIBtn);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button adminGUIBtn;
        private System.Windows.Forms.Button visitorGUIBtn;
        private System.Windows.Forms.Button EmployeeGUIBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

