namespace Design
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
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // adminGUIBtn
            // 
            this.adminGUIBtn.Location = new System.Drawing.Point(17, 16);
            this.adminGUIBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.adminGUIBtn.Name = "adminGUIBtn";
            this.adminGUIBtn.Size = new System.Drawing.Size(100, 28);
            this.adminGUIBtn.TabIndex = 0;
            this.adminGUIBtn.Text = "Admin";
            this.adminGUIBtn.UseVisualStyleBackColor = true;
            this.adminGUIBtn.Click += new System.EventHandler(this.adminGUIBtn_Click);
            // 
            // visitorGUIBtn
            // 
            this.visitorGUIBtn.Location = new System.Drawing.Point(125, 16);
            this.visitorGUIBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.visitorGUIBtn.Name = "visitorGUIBtn";
            this.visitorGUIBtn.Size = new System.Drawing.Size(100, 28);
            this.visitorGUIBtn.TabIndex = 1;
            this.visitorGUIBtn.Text = "visitor";
            this.visitorGUIBtn.UseVisualStyleBackColor = true;
            this.visitorGUIBtn.Click += new System.EventHandler(this.visitorGUIBtn_Click);
            // 
            // EmployeeGUIBtn
            // 
            this.EmployeeGUIBtn.Location = new System.Drawing.Point(233, 15);
            this.EmployeeGUIBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EmployeeGUIBtn.Name = "EmployeeGUIBtn";
            this.EmployeeGUIBtn.Size = new System.Drawing.Size(100, 28);
            this.EmployeeGUIBtn.TabIndex = 2;
            this.EmployeeGUIBtn.Text = "Employee";
            this.EmployeeGUIBtn.UseVisualStyleBackColor = true;
            this.EmployeeGUIBtn.Click += new System.EventHandler(this.employeeGUIBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 294);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "TODO : Close or Hide ? ( Keep what the visitor has done ? ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(125, 61);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Inheritance";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Design.Properties.Resources.LOGO_Proshot;
            this.pictureBox1.Location = new System.Drawing.Point(96, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 167);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EmployeeGUIBtn);
            this.Controls.Add(this.visitorGUIBtn);
            this.Controls.Add(this.adminGUIBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Main";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button adminGUIBtn;
        private System.Windows.Forms.Button visitorGUIBtn;
        private System.Windows.Forms.Button EmployeeGUIBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

