namespace Design.Examples
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
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Item",
            "Sub Item"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "Item",
            "Sub Item"}, -1);
            this.itemsListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.purchaseBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cartListView = new System.Windows.Forms.ListView();
            this.addOneBtn = new System.Windows.Forms.Button();
            this.removeOneBtn = new System.Windows.Forms.Button();
            this.addMultipleBtn = new System.Windows.Forms.Button();
            this.removeMultipleBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // itemsListView
            // 
            this.itemsListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3});
            this.itemsListView.Location = new System.Drawing.Point(12, 40);
            this.itemsListView.Name = "itemsListView";
            this.itemsListView.Size = new System.Drawing.Size(260, 180);
            this.itemsListView.TabIndex = 0;
            this.itemsListView.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "shop name";
            // 
            // purchaseBtn
            // 
            this.purchaseBtn.Location = new System.Drawing.Point(256, 226);
            this.purchaseBtn.Name = "purchaseBtn";
            this.purchaseBtn.Size = new System.Drawing.Size(75, 23);
            this.purchaseBtn.TabIndex = 3;
            this.purchaseBtn.Text = "Purchase";
            this.purchaseBtn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(340, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "cart";
            // 
            // cartListView
            // 
            this.cartListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4});
            this.cartListView.Location = new System.Drawing.Point(326, 40);
            this.cartListView.Name = "cartListView";
            this.cartListView.Size = new System.Drawing.Size(260, 180);
            this.cartListView.TabIndex = 5;
            this.cartListView.UseCompatibleStateImageBehavior = false;
            // 
            // addOneBtn
            // 
            this.addOneBtn.Location = new System.Drawing.Point(278, 71);
            this.addOneBtn.Name = "addOneBtn";
            this.addOneBtn.Size = new System.Drawing.Size(42, 23);
            this.addOneBtn.TabIndex = 6;
            this.addOneBtn.Text = ">";
            this.addOneBtn.UseVisualStyleBackColor = true;
            // 
            // removeOneBtn
            // 
            this.removeOneBtn.Location = new System.Drawing.Point(278, 155);
            this.removeOneBtn.Name = "removeOneBtn";
            this.removeOneBtn.Size = new System.Drawing.Size(42, 23);
            this.removeOneBtn.TabIndex = 7;
            this.removeOneBtn.Text = "<";
            this.removeOneBtn.UseVisualStyleBackColor = true;
            // 
            // addMultipleBtn
            // 
            this.addMultipleBtn.Location = new System.Drawing.Point(12, 226);
            this.addMultipleBtn.Name = "addMultipleBtn";
            this.addMultipleBtn.Size = new System.Drawing.Size(113, 23);
            this.addMultipleBtn.TabIndex = 9;
            this.addMultipleBtn.Text = "Add Multiple";
            this.addMultipleBtn.UseVisualStyleBackColor = true;
            // 
            // removeMultipleBtn
            // 
            this.removeMultipleBtn.Location = new System.Drawing.Point(473, 226);
            this.removeMultipleBtn.Name = "removeMultipleBtn";
            this.removeMultipleBtn.Size = new System.Drawing.Size(113, 23);
            this.removeMultipleBtn.TabIndex = 10;
            this.removeMultipleBtn.Text = "Remove Multiple";
            this.removeMultipleBtn.UseVisualStyleBackColor = true;
            // 
            // Store
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 256);
            this.Controls.Add(this.removeMultipleBtn);
            this.Controls.Add(this.addMultipleBtn);
            this.Controls.Add(this.removeOneBtn);
            this.Controls.Add(this.addOneBtn);
            this.Controls.Add(this.cartListView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.purchaseBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.itemsListView);
            this.Name = "Store";
            this.Text = "Store";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView itemsListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button purchaseBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView cartListView;
        private System.Windows.Forms.Button addOneBtn;
        private System.Windows.Forms.Button removeOneBtn;
        private System.Windows.Forms.Button addMultipleBtn;
        private System.Windows.Forms.Button removeMultipleBtn;
    }
}