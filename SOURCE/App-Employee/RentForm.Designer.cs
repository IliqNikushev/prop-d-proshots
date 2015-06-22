namespace App_Employee
{
    partial class RentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RentForm));
            this.lblCart = new System.Windows.Forms.Label();
            this.lbCart = new System.Windows.Forms.ListBox();
            this.cartListView = new System.Windows.Forms.ListBox();
            this.plItems = new System.Windows.Forms.Panel();
            this.lblLog = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.lbCard = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tbFullname = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.picVis = new System.Windows.Forms.PictureBox();
            this.picJob = new System.Windows.Forms.PictureBox();
            this.logo = new System.Windows.Forms.PictureBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.btnReturnItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picVis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCart
            // 
            this.lblCart.AutoSize = true;
            this.lblCart.Location = new System.Drawing.Point(387, 344);
            this.lblCart.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCart.Name = "lblCart";
            this.lblCart.Size = new System.Drawing.Size(64, 13);
            this.lblCart.TabIndex = 106;
            this.lblCart.Text = "Items in cart";
            // 
            // lbCart
            // 
            this.lbCart.FormattingEnabled = true;
            this.lbCart.Location = new System.Drawing.Point(390, 360);
            this.lbCart.Name = "lbCart";
            this.lbCart.Size = new System.Drawing.Size(484, 147);
            this.lbCart.TabIndex = 105;
            this.lbCart.SelectedIndexChanged += new System.EventHandler(this.lbCart_SelectedIndexChanged);
            // 
            // cartListView
            // 
            this.cartListView.FormattingEnabled = true;
            this.cartListView.Location = new System.Drawing.Point(390, 180);
            this.cartListView.Name = "cartListView";
            this.cartListView.Size = new System.Drawing.Size(484, 147);
            this.cartListView.TabIndex = 104;
            this.cartListView.SelectedIndexChanged += new System.EventHandler(this.cartListView_SelectedIndexChanged);
            // 
            // plItems
            // 
            this.plItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.plItems.Location = new System.Drawing.Point(7, 283);
            this.plItems.Name = "plItems";
            this.plItems.Size = new System.Drawing.Size(375, 224);
            this.plItems.TabIndex = 103;
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(387, 164);
            this.lblLog.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(86, 13);
            this.lblLog.TabIndex = 96;
            this.lblLog.Text = "Rented items log";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(10, 267);
            this.lblStock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(75, 13);
            this.lblStock.TabIndex = 95;
            this.lblStock.Text = "Items in  stock";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(10, 207);
            this.lblFrom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(91, 13);
            this.lblFrom.TabIndex = 100;
            this.lblFrom.Text = "Start Date: Today";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(10, 220);
            this.lblEnd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(55, 13);
            this.lblEnd.TabIndex = 99;
            this.lblEnd.Text = "End Date:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 89;
            this.label7.Text = "Profile Pic";
            // 
            // date
            // 
            this.date.Location = new System.Drawing.Point(13, 235);
            this.date.Margin = new System.Windows.Forms.Padding(2);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(151, 20);
            this.date.TabIndex = 98;
            this.date.ValueChanged += new System.EventHandler(this.date_ValueChanged);
            // 
            // lbCard
            // 
            this.lbCard.AutoSize = true;
            this.lbCard.Location = new System.Drawing.Point(109, 24);
            this.lbCard.Name = "lbCard";
            this.lbCard.Size = new System.Drawing.Size(43, 13);
            this.lbCard.TabIndex = 90;
            this.lbCard.Text = "ID Card";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(152, 21);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(86, 20);
            this.tbID.TabIndex = 92;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(111, 55);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 91;
            this.lblName.Text = "Name";
            // 
            // tbFullname
            // 
            this.tbFullname.Location = new System.Drawing.Point(152, 51);
            this.tbFullname.Name = "tbFullname";
            this.tbFullname.Size = new System.Drawing.Size(86, 20);
            this.tbFullname.TabIndex = 93;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Image")));
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(390, 508);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(110, 32);
            this.btnConfirm.TabIndex = 102;
            this.btnConfirm.Text = "Rent selected";
            this.btnConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnRent_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Enabled = false;
            this.btnReturn.Image = ((System.Drawing.Image)(resources.GetObject("btnReturn.Image")));
            this.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturn.Location = new System.Drawing.Point(506, 508);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(110, 32);
            this.btnReturn.TabIndex = 101;
            this.btnReturn.Text = "Return selected";
            this.btnReturn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // picVis
            // 
            this.picVis.Image = ((System.Drawing.Image)(resources.GetObject("picVis.Image")));
            this.picVis.InitialImage = null;
            this.picVis.Location = new System.Drawing.Point(5, 4);
            this.picVis.Name = "picVis";
            this.picVis.Size = new System.Drawing.Size(100, 95);
            this.picVis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVis.TabIndex = 88;
            this.picVis.TabStop = false;
            // 
            // picJob
            // 
            this.picJob.Image = ((System.Drawing.Image)(resources.GetObject("picJob.Image")));
            this.picJob.Location = new System.Drawing.Point(390, 1);
            this.picJob.Margin = new System.Windows.Forms.Padding(2);
            this.picJob.Name = "picJob";
            this.picJob.Size = new System.Drawing.Size(220, 158);
            this.picJob.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picJob.TabIndex = 87;
            this.picJob.TabStop = false;
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(831, 1);
            this.logo.Margin = new System.Windows.Forms.Padding(2);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(64, 64);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 97;
            this.logo.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(523, 344);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(57, 13);
            this.lblTotal.TabIndex = 107;
            this.lblTotal.Text = "Total cost:";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(584, 344);
            this.lbPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(40, 13);
            this.lbPrice.TabIndex = 108;
            this.lbPrice.Text = "$$$.$$";
            // 
            // btnReturnItem
            // 
            this.btnReturnItem.Enabled = false;
            this.btnReturnItem.Image = ((System.Drawing.Image)(resources.GetObject("btnReturnItem.Image")));
            this.btnReturnItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturnItem.Location = new System.Drawing.Point(764, 325);
            this.btnReturnItem.Name = "btnReturnItem";
            this.btnReturnItem.Size = new System.Drawing.Size(110, 32);
            this.btnReturnItem.TabIndex = 109;
            this.btnReturnItem.Text = "Return selected";
            this.btnReturnItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReturnItem.UseVisualStyleBackColor = true;
            this.btnReturnItem.Click += new System.EventHandler(this.btnReturnItem_Click);
            // 
            // RentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 552);
            this.Controls.Add(this.btnReturnItem);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblCart);
            this.Controls.Add(this.lbCart);
            this.Controls.Add(this.cartListView);
            this.Controls.Add(this.plItems);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.picVis);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.date);
            this.Controls.Add(this.lbCard);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.tbFullname);
            this.Controls.Add(this.picJob);
            this.Controls.Add(this.logo);
            this.Name = "RentForm";
            this.Text = "Renting";
            ((System.ComponentModel.ISupportInitialize)(this.picVis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCart;
        private System.Windows.Forms.ListBox lbCart;
        private System.Windows.Forms.ListBox cartListView;
        private System.Windows.Forms.Panel plItems;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.PictureBox picVis;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Label lbCard;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbFullname;
        private System.Windows.Forms.PictureBox picJob;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Button btnReturnItem;
    }
}