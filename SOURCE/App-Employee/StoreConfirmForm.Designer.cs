namespace App_Employee
{
    partial class StoreConfirmForm
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
            this.confirmBtn = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.totalLbl = new System.Windows.Forms.Label();
            this.totalValueLbl = new System.Windows.Forms.Label();
            this.numberLbl = new System.Windows.Forms.Label();
            this.numberValueLbl = new System.Windows.Forms.Label();
            this.userAvatarPBox = new System.Windows.Forms.PictureBox();
            this.userNameLbl = new System.Windows.Forms.Label();
            this.userBalanceLbl = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.postponeBtn = new System.Windows.Forms.Button();
            this.insufficientLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.userAvatarPBox)).BeginInit();
            this.SuspendLayout();
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(342, 321);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmBtn.TabIndex = 0;
            this.confirmBtn.Text = "Confirm";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(301, 9);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 335);
            this.vScrollBar1.TabIndex = 2;
            // 
            // totalLbl
            // 
            this.totalLbl.AutoSize = true;
            this.totalLbl.Location = new System.Drawing.Point(361, 182);
            this.totalLbl.Name = "totalLbl";
            this.totalLbl.Size = new System.Drawing.Size(31, 13);
            this.totalLbl.TabIndex = 3;
            this.totalLbl.Text = "Total";
            this.totalLbl.Click += new System.EventHandler(this.totalLbl_Click);
            // 
            // totalValueLbl
            // 
            this.totalValueLbl.AutoSize = true;
            this.totalValueLbl.Location = new System.Drawing.Point(361, 195);
            this.totalValueLbl.Name = "totalValueLbl";
            this.totalValueLbl.Size = new System.Drawing.Size(41, 13);
            this.totalValueLbl.TabIndex = 4;
            this.totalValueLbl.Text = "Total #";
            // 
            // numberLbl
            // 
            this.numberLbl.AutoSize = true;
            this.numberLbl.Location = new System.Drawing.Point(334, 147);
            this.numberLbl.Name = "numberLbl";
            this.numberLbl.Size = new System.Drawing.Size(83, 13);
            this.numberLbl.TabIndex = 5;
            this.numberLbl.Text = "Number of items";
            // 
            // numberValueLbl
            // 
            this.numberValueLbl.AutoSize = true;
            this.numberValueLbl.Location = new System.Drawing.Point(351, 160);
            this.numberValueLbl.Name = "numberValueLbl";
            this.numberValueLbl.Size = new System.Drawing.Size(53, 13);
            this.numberValueLbl.TabIndex = 6;
            this.numberValueLbl.Text = "# of items";
            // 
            // userAvatarPBox
            // 
            this.userAvatarPBox.Image = global::App_Common.Properties.Resources.Employees;
            this.userAvatarPBox.Location = new System.Drawing.Point(334, 12);
            this.userAvatarPBox.Name = "userAvatarPBox";
            this.userAvatarPBox.Size = new System.Drawing.Size(100, 85);
            this.userAvatarPBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userAvatarPBox.TabIndex = 7;
            this.userAvatarPBox.TabStop = false;
            // 
            // userNameLbl
            // 
            this.userNameLbl.AutoSize = true;
            this.userNameLbl.Location = new System.Drawing.Point(334, 104);
            this.userNameLbl.Name = "userNameLbl";
            this.userNameLbl.Size = new System.Drawing.Size(35, 13);
            this.userNameLbl.TabIndex = 8;
            this.userNameLbl.Text = "Name";
            // 
            // userBalanceLbl
            // 
            this.userBalanceLbl.AutoSize = true;
            this.userBalanceLbl.Location = new System.Drawing.Point(334, 121);
            this.userBalanceLbl.Name = "userBalanceLbl";
            this.userBalanceLbl.Size = new System.Drawing.Size(46, 13);
            this.userBalanceLbl.TabIndex = 9;
            this.userBalanceLbl.Text = "Balance";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(342, 265);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 10;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // postponeBtn
            // 
            this.postponeBtn.Location = new System.Drawing.Point(342, 211);
            this.postponeBtn.Name = "postponeBtn";
            this.postponeBtn.Size = new System.Drawing.Size(75, 23);
            this.postponeBtn.TabIndex = 11;
            this.postponeBtn.Text = "Postpone";
            this.postponeBtn.UseVisualStyleBackColor = true;
            this.postponeBtn.Click += new System.EventHandler(this.postponeBtn_Click);
            // 
            // insufficientLbl
            // 
            this.insufficientLbl.AutoSize = true;
            this.insufficientLbl.ForeColor = System.Drawing.Color.Red;
            this.insufficientLbl.Location = new System.Drawing.Point(342, 302);
            this.insufficientLbl.Name = "insufficientLbl";
            this.insufficientLbl.Size = new System.Drawing.Size(66, 13);
            this.insufficientLbl.TabIndex = 12;
            this.insufficientLbl.Text = "insufficient $";
            // 
            // StoreConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 356);
            this.Controls.Add(this.insufficientLbl);
            this.Controls.Add(this.postponeBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.userBalanceLbl);
            this.Controls.Add(this.userNameLbl);
            this.Controls.Add(this.userAvatarPBox);
            this.Controls.Add(this.numberValueLbl);
            this.Controls.Add(this.numberLbl);
            this.Controls.Add(this.totalValueLbl);
            this.Controls.Add(this.totalLbl);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.confirmBtn);
            this.Name = "StoreConfirm";
            this.Text = "StoreConfirm";
            ((System.ComponentModel.ISupportInitialize)(this.userAvatarPBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Label totalLbl;
        private System.Windows.Forms.Label totalValueLbl;
        private System.Windows.Forms.Label numberLbl;
        private System.Windows.Forms.Label numberValueLbl;
        private System.Windows.Forms.PictureBox userAvatarPBox;
        private System.Windows.Forms.Label userNameLbl;
        private System.Windows.Forms.Label userBalanceLbl;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button postponeBtn;
        private System.Windows.Forms.Label insufficientLbl;
    }
}