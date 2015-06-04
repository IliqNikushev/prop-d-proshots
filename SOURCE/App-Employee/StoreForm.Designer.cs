namespace App_Employee
{
    public partial class StoreForm
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

        private System.Windows.Forms.Label totalItemsCountLbl;
        private System.Windows.Forms.Label numberItemsLbl;
        private System.Windows.Forms.Label totalNumberLbl;
        private System.Windows.Forms.Label totalCountLbl;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.VScrollBar verticalBar;
        private System.Windows.Forms.Label exampleLbl;
        private System.Windows.Forms.PictureBox subPbox;
        private System.Windows.Forms.Panel itemsPanel;
        private System.Windows.Forms.PictureBox addPbox;
        private System.Windows.Forms.PictureBox storeLogoPbox;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
       private void InitializeComponent()
        {
            this.totalItemsCountLbl = new System.Windows.Forms.Label();
            this.numberItemsLbl = new System.Windows.Forms.Label();
            this.totalNumberLbl = new System.Windows.Forms.Label();
            this.totalCountLbl = new System.Windows.Forms.Label();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.verticalBar = new System.Windows.Forms.VScrollBar();
            this.exampleLbl = new System.Windows.Forms.Label();
            this.itemsPanel = new System.Windows.Forms.Panel();
            this.resetBtn = new System.Windows.Forms.Button();
            this.activeVisitorLbl = new System.Windows.Forms.Label();
            this.subPbox = new System.Windows.Forms.PictureBox();
            this.addPbox = new System.Windows.Forms.PictureBox();
            this.storeLogoPbox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.subPbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addPbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeLogoPbox)).BeginInit();
            this.SuspendLayout();
            // 
            // totalItemsCountLbl
            // 
            this.totalItemsCountLbl.AutoSize = true;
            this.totalItemsCountLbl.Location = new System.Drawing.Point(319, 56);
            this.totalItemsCountLbl.Name = "totalItemsCountLbl";
            this.totalItemsCountLbl.Size = new System.Drawing.Size(35, 13);
            this.totalItemsCountLbl.TabIndex = 65;
            this.totalItemsCountLbl.Text = "Count";
            // 
            // numberItemsLbl
            // 
            this.numberItemsLbl.AutoSize = true;
            this.numberItemsLbl.Location = new System.Drawing.Point(230, 56);
            this.numberItemsLbl.Name = "numberItemsLbl";
            this.numberItemsLbl.Size = new System.Drawing.Size(83, 13);
            this.numberItemsLbl.TabIndex = 64;
            this.numberItemsLbl.Text = "Number of items";
            // 
            // totalNumberLbl
            // 
            this.totalNumberLbl.AutoSize = true;
            this.totalNumberLbl.Location = new System.Drawing.Point(319, 79);
            this.totalNumberLbl.Name = "totalNumberLbl";
            this.totalNumberLbl.Size = new System.Drawing.Size(28, 13);
            this.totalNumberLbl.TabIndex = 63;
            this.totalNumberLbl.Text = "Sum";
            // 
            // totalCountLbl
            // 
            this.totalCountLbl.AutoSize = true;
            this.totalCountLbl.Location = new System.Drawing.Point(282, 79);
            this.totalCountLbl.Name = "totalCountLbl";
            this.totalCountLbl.Size = new System.Drawing.Size(31, 13);
            this.totalCountLbl.TabIndex = 62;
            this.totalCountLbl.Text = "Total";
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(248, 106);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmBtn.TabIndex = 61;
            this.confirmBtn.Text = "Confirm";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // verticalBar
            // 
            this.verticalBar.Location = new System.Drawing.Point(585, 150);
            this.verticalBar.Name = "verticalBar";
            this.verticalBar.Size = new System.Drawing.Size(17, 286);
            this.verticalBar.TabIndex = 60;
            // 
            // exampleLbl
            // 
            this.exampleLbl.AutoSize = true;
            this.exampleLbl.Location = new System.Drawing.Point(390, 3);
            this.exampleLbl.Name = "exampleLbl";
            this.exampleLbl.Size = new System.Drawing.Size(46, 13);
            this.exampleLbl.TabIndex = 59;
            this.exampleLbl.Text = "example";
            // 
            // itemsPanel
            // 
            this.itemsPanel.Location = new System.Drawing.Point(12, 150);
            this.itemsPanel.Name = "itemsPanel";
            this.itemsPanel.Size = new System.Drawing.Size(574, 283);
            this.itemsPanel.TabIndex = 57;
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(12, 106);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(75, 23);
            this.resetBtn.TabIndex = 66;
            this.resetBtn.Text = "New order";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // activeVisitorLbl
            // 
            this.activeVisitorLbl.AutoSize = true;
            this.activeVisitorLbl.Location = new System.Drawing.Point(70, 3);
            this.activeVisitorLbl.Name = "activeVisitorLbl";
            this.activeVisitorLbl.Size = new System.Drawing.Size(70, 13);
            this.activeVisitorLbl.TabIndex = 67;
            this.activeVisitorLbl.Text = "Active visitor:";
            // 
            // subPbox
            // 
            this.subPbox.BackColor = System.Drawing.Color.Transparent;
            this.subPbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.subPbox.Image = global::App_Employee.Properties.Resources.minus;
            this.subPbox.Location = new System.Drawing.Point(177, 96);
            this.subPbox.Name = "subPbox";
            this.subPbox.Size = new System.Drawing.Size(48, 48);
            this.subPbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.subPbox.TabIndex = 58;
            this.subPbox.TabStop = false;
            // 
            // addPbox
            // 
            this.addPbox.Image = global::App_Employee.Properties.Resources.plus;
            this.addPbox.Location = new System.Drawing.Point(103, 96);
            this.addPbox.Name = "addPbox";
            this.addPbox.Size = new System.Drawing.Size(48, 48);
            this.addPbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.addPbox.TabIndex = 56;
            this.addPbox.TabStop = false;
            this.addPbox.Click += new System.EventHandler(this.addPbox_Click);
            // 
            // storeLogoPbox
            // 
            this.storeLogoPbox.Location = new System.Drawing.Point(0, 0);
            this.storeLogoPbox.Name = "storeLogoPbox";
            this.storeLogoPbox.Size = new System.Drawing.Size(64, 64);
            this.storeLogoPbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.storeLogoPbox.TabIndex = 53;
            this.storeLogoPbox.TabStop = false;
            // 
            // StoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(606, 443);
            this.Controls.Add(this.activeVisitorLbl);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.totalItemsCountLbl);
            this.Controls.Add(this.numberItemsLbl);
            this.Controls.Add(this.totalNumberLbl);
            this.Controls.Add(this.totalCountLbl);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.verticalBar);
            this.Controls.Add(this.exampleLbl);
            this.Controls.Add(this.subPbox);
            this.Controls.Add(this.itemsPanel);
            this.Controls.Add(this.addPbox);
            this.Controls.Add(this.storeLogoPbox);
            this.Name = "StoreForm";
            this.Text = "<SHOPNAME>:Order menu";
            ((System.ComponentModel.ISupportInitialize)(this.subPbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addPbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeLogoPbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        # endregion

       private System.Windows.Forms.Button resetBtn;
       private System.Windows.Forms.Label activeVisitorLbl;
    }
}