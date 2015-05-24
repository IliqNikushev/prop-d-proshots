namespace App_Common
{
    partial class LoginForm
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
            this.loginBtn = new System.Windows.Forms.Button();
            this.infoLbl = new System.Windows.Forms.Label();
            this.idTbox = new System.Windows.Forms.TextBox();
            this.passwordTbox = new System.Windows.Forms.TextBox();
            this.logoPBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoPBox)).BeginInit();
            this.SuspendLayout();
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(97, 243);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 23);
            this.loginBtn.TabIndex = 0;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // infoLbl
            // 
            this.infoLbl.Location = new System.Drawing.Point(61, 149);
            this.infoLbl.Name = "infoLbl";
            this.infoLbl.Size = new System.Drawing.Size(171, 41);
            this.infoLbl.TabIndex = 12;
            this.infoLbl.Text = "Enter you credentials";
            this.infoLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // idTbox
            // 
            this.idTbox.Location = new System.Drawing.Point(64, 191);
            this.idTbox.Name = "idTbox";
            this.idTbox.Size = new System.Drawing.Size(156, 20);
            this.idTbox.TabIndex = 10;
            this.idTbox.Text = "username";
            // 
            // passwordTbox
            // 
            this.passwordTbox.Location = new System.Drawing.Point(64, 217);
            this.passwordTbox.Name = "passwordTbox";
            this.passwordTbox.PasswordChar = '*';
            this.passwordTbox.Size = new System.Drawing.Size(156, 20);
            this.passwordTbox.TabIndex = 11;
            this.passwordTbox.Text = "password";
            // 
            // logoPBox
            // 
            this.logoPBox.Image = global::App_Common.Properties.Resources.LOGO_Proshot;
            this.logoPBox.Location = new System.Drawing.Point(64, 11);
            this.logoPBox.Margin = new System.Windows.Forms.Padding(2);
            this.logoPBox.Name = "logoPBox";
            this.logoPBox.Size = new System.Drawing.Size(152, 136);
            this.logoPBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPBox.TabIndex = 13;
            this.logoPBox.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(284, 293);
            this.Controls.Add(this.infoLbl);
            this.Controls.Add(this.idTbox);
            this.Controls.Add(this.passwordTbox);
            this.Controls.Add(this.logoPBox);
            this.Controls.Add(this.loginBtn);
            this.Name = "LoginForm";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.logoPBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label infoLbl;
        private System.Windows.Forms.TextBox idTbox;
        private System.Windows.Forms.TextBox passwordTbox;
        private System.Windows.Forms.PictureBox logoPBox;
    }
}

