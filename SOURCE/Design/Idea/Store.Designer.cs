namespace Design.Idea
{
    partial class Store
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Item",
            "Sub Item"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Item",
            "Sub Item"}, -1);
            this.itemsListView = new System.Windows.Forms.ListView();
            this.purchaseBtn = new System.Windows.Forms.Button();
            this.cartListView = new System.Windows.Forms.ListView();
            this.addOneBtn = new System.Windows.Forms.Button();
            this.removeOneBtn = new System.Windows.Forms.Button();
            this.addMultipleBtn = new System.Windows.Forms.Button();
            this.removeMultipleBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // itemsListView
            // 
            this.itemsListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.itemsListView.Location = new System.Drawing.Point(13, 209);
            this.itemsListView.Margin = new System.Windows.Forms.Padding(4);
            this.itemsListView.Name = "itemsListView";
            this.itemsListView.Size = new System.Drawing.Size(345, 221);
            this.itemsListView.TabIndex = 0;
            this.itemsListView.UseCompatibleStateImageBehavior = false;
            // 
            // purchaseBtn
            // 
            this.purchaseBtn.Location = new System.Drawing.Point(338, 438);
            this.purchaseBtn.Margin = new System.Windows.Forms.Padding(4);
            this.purchaseBtn.Name = "purchaseBtn";
            this.purchaseBtn.Size = new System.Drawing.Size(100, 28);
            this.purchaseBtn.TabIndex = 3;
            this.purchaseBtn.Text = "Purchase";
            this.purchaseBtn.UseVisualStyleBackColor = true;
            // 
            // cartListView
            // 
            this.cartListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.cartListView.Location = new System.Drawing.Point(432, 209);
            this.cartListView.Margin = new System.Windows.Forms.Padding(4);
            this.cartListView.Name = "cartListView";
            this.cartListView.Size = new System.Drawing.Size(345, 221);
            this.cartListView.TabIndex = 5;
            this.cartListView.UseCompatibleStateImageBehavior = false;
            // 
            // addOneBtn
            // 
            this.addOneBtn.Location = new System.Drawing.Point(368, 247);
            this.addOneBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addOneBtn.Name = "addOneBtn";
            this.addOneBtn.Size = new System.Drawing.Size(56, 28);
            this.addOneBtn.TabIndex = 6;
            this.addOneBtn.Text = ">";
            this.addOneBtn.UseVisualStyleBackColor = true;
            // 
            // removeOneBtn
            // 
            this.removeOneBtn.Location = new System.Drawing.Point(368, 351);
            this.removeOneBtn.Margin = new System.Windows.Forms.Padding(4);
            this.removeOneBtn.Name = "removeOneBtn";
            this.removeOneBtn.Size = new System.Drawing.Size(56, 28);
            this.removeOneBtn.TabIndex = 7;
            this.removeOneBtn.Text = "<";
            this.removeOneBtn.UseVisualStyleBackColor = true;
            // 
            // addMultipleBtn
            // 
            this.addMultipleBtn.Location = new System.Drawing.Point(13, 438);
            this.addMultipleBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addMultipleBtn.Name = "addMultipleBtn";
            this.addMultipleBtn.Size = new System.Drawing.Size(151, 28);
            this.addMultipleBtn.TabIndex = 9;
            this.addMultipleBtn.Text = "Add Multiple";
            this.addMultipleBtn.UseVisualStyleBackColor = true;
            // 
            // removeMultipleBtn
            // 
            this.removeMultipleBtn.Location = new System.Drawing.Point(628, 438);
            this.removeMultipleBtn.Margin = new System.Windows.Forms.Padding(4);
            this.removeMultipleBtn.Name = "removeMultipleBtn";
            this.removeMultipleBtn.Size = new System.Drawing.Size(151, 28);
            this.removeMultipleBtn.TabIndex = 10;
            this.removeMultipleBtn.Text = "Remove Multiple";
            this.removeMultipleBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(437, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Shops";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Design.Properties.Resources.shop_nice;
            this.pictureBox4.Location = new System.Drawing.Point(432, 1);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(128, 128);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 21;
            this.pictureBox4.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(209, 64);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(113, 22);
            this.textBox3.TabIndex = 42;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(209, 33);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(113, 22);
            this.textBox2.TabIndex = 41;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 126);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(89, 22);
            this.textBox1.TabIndex = 40;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::Design.Properties.Resources.addMoney;
            this.pictureBox7.Location = new System.Drawing.Point(121, 129);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(64, 47);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 39;
            this.pictureBox7.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 129);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 38;
            this.label1.Text = "Balance";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(154, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 37;
            this.label5.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 36;
            this.label4.Text = "ID Card";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 42);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 17);
            this.label7.TabIndex = 35;
            this.label7.Text = "Profile Pic";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Design.Properties.Resources.Employees;
            this.pictureBox2.Location = new System.Drawing.Point(13, 13);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(133, 82);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 43;
            this.label3.Text = "Menu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(437, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 44;
            this.label6.Text = "shop List";
            // 
            // Store
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 538);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.removeMultipleBtn);
            this.Controls.Add(this.addMultipleBtn);
            this.Controls.Add(this.removeOneBtn);
            this.Controls.Add(this.addOneBtn);
            this.Controls.Add(this.cartListView);
            this.Controls.Add(this.purchaseBtn);
            this.Controls.Add(this.itemsListView);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Store";
            this.Text = "Store";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView itemsListView;
        private System.Windows.Forms.Button purchaseBtn;
        private System.Windows.Forms.ListView cartListView;
        private System.Windows.Forms.Button addOneBtn;
        private System.Windows.Forms.Button removeOneBtn;
        private System.Windows.Forms.Button addMultipleBtn;
        private System.Windows.Forms.Button removeMultipleBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
    }
}