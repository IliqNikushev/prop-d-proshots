namespace App_Employee
{
    partial class StoreInventoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoreInventoryForm));
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.lblModified = new System.Windows.Forms.Label();
            this.lblUnique = new System.Windows.Forms.Label();
            this.lblFind = new System.Windows.Forms.Label();
            this.nameTbox = new System.Windows.Forms.TextBox();
            this.itemsModifiedLbl = new System.Windows.Forms.Label();
            this.uniqueAddedLbl = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(301, 9);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 293);
            this.vScrollBar1.TabIndex = 3;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(339, 306);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(339, 246);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmBtn.TabIndex = 5;
            this.confirmBtn.Text = "Confirm";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // lblModified
            // 
            this.lblModified.AutoSize = true;
            this.lblModified.Location = new System.Drawing.Point(340, 138);
            this.lblModified.Name = "lblModified";
            this.lblModified.Size = new System.Drawing.Size(74, 13);
            this.lblModified.TabIndex = 6;
            this.lblModified.Text = "Items modified";
            // 
            // lblUnique
            // 
            this.lblUnique.AutoSize = true;
            this.lblUnique.Location = new System.Drawing.Point(330, 187);
            this.lblUnique.Name = "lblUnique";
            this.lblUnique.Size = new System.Drawing.Size(101, 13);
            this.lblUnique.TabIndex = 7;
            this.lblUnique.Text = "Unique items added";
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(98, 303);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(70, 13);
            this.lblFind.TabIndex = 8;
            this.lblFind.Text = "Find by name";
            // 
            // nameTbox
            // 
            this.nameTbox.Location = new System.Drawing.Point(12, 319);
            this.nameTbox.Name = "nameTbox";
            this.nameTbox.Size = new System.Drawing.Size(277, 20);
            this.nameTbox.TabIndex = 9;
            // 
            // itemsModifiedLbl
            // 
            this.itemsModifiedLbl.AutoSize = true;
            this.itemsModifiedLbl.Location = new System.Drawing.Point(329, 153);
            this.itemsModifiedLbl.Name = "itemsModifiedLbl";
            this.itemsModifiedLbl.Size = new System.Drawing.Size(85, 13);
            this.itemsModifiedLbl.TabIndex = 10;
            this.itemsModifiedLbl.Text = "itemsModifiedLbl";
            // 
            // uniqueAddedLbl
            // 
            this.uniqueAddedLbl.AutoSize = true;
            this.uniqueAddedLbl.Location = new System.Drawing.Point(330, 204);
            this.uniqueAddedLbl.Name = "uniqueAddedLbl";
            this.uniqueAddedLbl.Size = new System.Drawing.Size(84, 13);
            this.uniqueAddedLbl.TabIndex = 11;
            this.uniqueAddedLbl.Text = "uniqueAddedLbl";
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(380, 1);
            this.logo.Margin = new System.Windows.Forms.Padding(2);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(64, 64);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 98;
            this.logo.TabStop = false;
            // 
            // StoreInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 341);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.uniqueAddedLbl);
            this.Controls.Add(this.itemsModifiedLbl);
            this.Controls.Add(this.nameTbox);
            this.Controls.Add(this.lblFind);
            this.Controls.Add(this.lblUnique);
            this.Controls.Add(this.lblModified);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.vScrollBar1);
            this.Name = "StoreInventoryForm";
            this.Text = "StoreInventory";
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Label lblModified;
        private System.Windows.Forms.Label lblUnique;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.TextBox nameTbox;
        private System.Windows.Forms.Label itemsModifiedLbl;
        private System.Windows.Forms.Label uniqueAddedLbl;
        private System.Windows.Forms.PictureBox logo;
    }
}