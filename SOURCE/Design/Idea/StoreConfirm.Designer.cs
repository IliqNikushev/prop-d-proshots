namespace Design.Idea
{
    partial class StoreConfirm
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
            this.SuspendLayout();
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(197, 226);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmBtn.TabIndex = 0;
            this.confirmBtn.Text = "Confirm";
            this.confirmBtn.UseVisualStyleBackColor = true;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(177, 12);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 237);
            this.vScrollBar1.TabIndex = 2;
            // 
            // totalLbl
            // 
            this.totalLbl.AutoSize = true;
            this.totalLbl.Location = new System.Drawing.Point(219, 171);
            this.totalLbl.Name = "totalLbl";
            this.totalLbl.Size = new System.Drawing.Size(31, 13);
            this.totalLbl.TabIndex = 3;
            this.totalLbl.Text = "Total";
            this.totalLbl.Click += new System.EventHandler(this.totalLbl_Click);
            // 
            // totalValueLbl
            // 
            this.totalValueLbl.AutoSize = true;
            this.totalValueLbl.Location = new System.Drawing.Point(197, 197);
            this.totalValueLbl.Name = "totalValueLbl";
            this.totalValueLbl.Size = new System.Drawing.Size(41, 13);
            this.totalValueLbl.TabIndex = 4;
            this.totalValueLbl.Text = "Total #";
            // 
            // numberLbl
            // 
            this.numberLbl.AutoSize = true;
            this.numberLbl.Location = new System.Drawing.Point(197, 73);
            this.numberLbl.Name = "numberLbl";
            this.numberLbl.Size = new System.Drawing.Size(83, 13);
            this.numberLbl.TabIndex = 5;
            this.numberLbl.Text = "Number of items";
            // 
            // numberValueLbl
            // 
            this.numberValueLbl.AutoSize = true;
            this.numberValueLbl.Location = new System.Drawing.Point(197, 99);
            this.numberValueLbl.Name = "numberValueLbl";
            this.numberValueLbl.Size = new System.Drawing.Size(53, 13);
            this.numberValueLbl.TabIndex = 6;
            this.numberValueLbl.Text = "# of items";
            // 
            // StoreConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.numberValueLbl);
            this.Controls.Add(this.numberLbl);
            this.Controls.Add(this.totalValueLbl);
            this.Controls.Add(this.totalLbl);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.confirmBtn);
            this.Name = "StoreConfirm";
            this.Text = "StoreConfirm";
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
    }
}