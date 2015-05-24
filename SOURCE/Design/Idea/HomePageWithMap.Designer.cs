namespace Design.Idea
{
    partial class HomePageWithMap
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
            this.zoomTb = new System.Windows.Forms.TextBox();
            this.zoomOutBtn = new System.Windows.Forms.Button();
            this.ZoomInBtn = new System.Windows.Forms.Button();
            this.findByNameTb = new System.Windows.Forms.TextBox();
            this.findByNameLbl = new System.Windows.Forms.Label();
            this.findByTypeLbl = new System.Windows.Forms.Label();
            this.findByTypeTb = new System.Windows.Forms.TextBox();
            this.mapBtn = new System.Windows.Forms.Button();
            this.zoomOnItemsBtn = new System.Windows.Forms.Button();
            this.resetZoomBtn = new System.Windows.Forms.Button();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.mapArea = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // zoomTb
            // 
            this.zoomTb.AcceptsReturn = true;
            this.zoomTb.AutoCompleteCustomSource.AddRange(new string[] {
            "100%",
            "125%",
            "150%",
            "175%",
            "200%",
            "300%",
            "400%",
            "500%",
            "1000%"});
            this.zoomTb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.zoomTb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.zoomTb.Location = new System.Drawing.Point(704, 490);
            this.zoomTb.Margin = new System.Windows.Forms.Padding(4);
            this.zoomTb.Name = "zoomTb";
            this.zoomTb.Size = new System.Drawing.Size(68, 22);
            this.zoomTb.TabIndex = 29;
            // 
            // zoomOutBtn
            // 
            this.zoomOutBtn.Location = new System.Drawing.Point(781, 490);
            this.zoomOutBtn.Margin = new System.Windows.Forms.Padding(4);
            this.zoomOutBtn.Name = "zoomOutBtn";
            this.zoomOutBtn.Size = new System.Drawing.Size(56, 30);
            this.zoomOutBtn.TabIndex = 28;
            this.zoomOutBtn.Text = "-";
            this.zoomOutBtn.UseVisualStyleBackColor = true;
            this.zoomOutBtn.Click += new System.EventHandler(this.zoomOutBtn_Click);
            // 
            // ZoomInBtn
            // 
            this.ZoomInBtn.Location = new System.Drawing.Point(640, 490);
            this.ZoomInBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ZoomInBtn.Name = "ZoomInBtn";
            this.ZoomInBtn.Size = new System.Drawing.Size(56, 28);
            this.ZoomInBtn.TabIndex = 27;
            this.ZoomInBtn.Text = "+";
            this.ZoomInBtn.UseVisualStyleBackColor = true;
            this.ZoomInBtn.Click += new System.EventHandler(this.ZoomInBtn_Click);
            // 
            // findByNameTb
            // 
            this.findByNameTb.AcceptsReturn = true;
            this.findByNameTb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.findByNameTb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.findByNameTb.Location = new System.Drawing.Point(472, 545);
            this.findByNameTb.Margin = new System.Windows.Forms.Padding(4);
            this.findByNameTb.Multiline = true;
            this.findByNameTb.Name = "findByNameTb";
            this.findByNameTb.Size = new System.Drawing.Size(172, 24);
            this.findByNameTb.TabIndex = 30;
            // 
            // findByNameLbl
            // 
            this.findByNameLbl.AutoSize = true;
            this.findByNameLbl.Location = new System.Drawing.Point(515, 526);
            this.findByNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.findByNameLbl.Name = "findByNameLbl";
            this.findByNameLbl.Size = new System.Drawing.Size(95, 17);
            this.findByNameLbl.TabIndex = 31;
            this.findByNameLbl.Text = "Find by Name";
            // 
            // findByTypeLbl
            // 
            this.findByTypeLbl.AutoSize = true;
            this.findByTypeLbl.Location = new System.Drawing.Point(879, 526);
            this.findByTypeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.findByTypeLbl.Name = "findByTypeLbl";
            this.findByTypeLbl.Size = new System.Drawing.Size(90, 17);
            this.findByTypeLbl.TabIndex = 33;
            this.findByTypeLbl.Text = "Find by Type";
            // 
            // findByTypeTb
            // 
            this.findByTypeTb.AcceptsReturn = true;
            this.findByTypeTb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.findByTypeTb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.findByTypeTb.Location = new System.Drawing.Point(832, 545);
            this.findByTypeTb.Margin = new System.Windows.Forms.Padding(4);
            this.findByTypeTb.Multiline = true;
            this.findByTypeTb.Name = "findByTypeTb";
            this.findByTypeTb.Size = new System.Drawing.Size(172, 24);
            this.findByTypeTb.TabIndex = 34;
            // 
            // mapBtn
            // 
            this.mapBtn.Location = new System.Drawing.Point(365, 2);
            this.mapBtn.Margin = new System.Windows.Forms.Padding(4);
            this.mapBtn.Name = "mapBtn";
            this.mapBtn.Size = new System.Drawing.Size(100, 28);
            this.mapBtn.TabIndex = 0;
            this.mapBtn.Text = "Map";
            this.mapBtn.UseVisualStyleBackColor = true;
            this.mapBtn.Click += new System.EventHandler(this.mapBtn_Click);
            // 
            // zoomOnItemsBtn
            // 
            this.zoomOnItemsBtn.Location = new System.Drawing.Point(489, 487);
            this.zoomOnItemsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.zoomOnItemsBtn.Name = "zoomOnItemsBtn";
            this.zoomOnItemsBtn.Size = new System.Drawing.Size(136, 28);
            this.zoomOnItemsBtn.TabIndex = 35;
            this.zoomOnItemsBtn.Text = "Zoom on items";
            this.zoomOnItemsBtn.UseVisualStyleBackColor = true;
            this.zoomOnItemsBtn.Click += new System.EventHandler(this.zoomOnItemsBtn_Click);
            // 
            // resetZoomBtn
            // 
            this.resetZoomBtn.Location = new System.Drawing.Point(869, 486);
            this.resetZoomBtn.Margin = new System.Windows.Forms.Padding(4);
            this.resetZoomBtn.Name = "resetZoomBtn";
            this.resetZoomBtn.Size = new System.Drawing.Size(115, 28);
            this.resetZoomBtn.TabIndex = 36;
            this.resetZoomBtn.Text = "Reset zoom";
            this.resetZoomBtn.UseVisualStyleBackColor = true;
            this.resetZoomBtn.Click += new System.EventHandler(this.resetZoomBtn_Click);
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = global::Design.Properties.Resources.LOGO_Proshot;
            this.pictureBox11.Location = new System.Drawing.Point(139, 2);
            this.pictureBox11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(150, 125);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox11.TabIndex = 37;
            this.pictureBox11.TabStop = false;
            // 
            // mapArea
            // 
            this.mapArea.Image = global::Design.Properties.Resources.Park_English;
            this.mapArea.InitialImage = null;
            this.mapArea.Location = new System.Drawing.Point(491, 23);
            this.mapArea.Margin = new System.Windows.Forms.Padding(4);
            this.mapArea.Name = "mapArea";
            this.mapArea.Size = new System.Drawing.Size(495, 454);
            this.mapArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mapArea.TabIndex = 0;
            this.mapArea.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::Design.Properties.Resources.imac1;
            this.pictureBox10.Location = new System.Drawing.Point(472, 2);
            this.pictureBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(533, 583);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 23;
            this.pictureBox10.TabStop = false;
            // 
            // HomePageWithMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 879);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.resetZoomBtn);
            this.Controls.Add(this.zoomOnItemsBtn);
            this.Controls.Add(this.findByNameTb);
            this.Controls.Add(this.zoomOutBtn);
            this.Controls.Add(this.zoomTb);
            this.Controls.Add(this.findByTypeLbl);
            this.Controls.Add(this.findByTypeTb);
            this.Controls.Add(this.ZoomInBtn);
            this.Controls.Add(this.findByNameLbl);
            this.Controls.Add(this.mapArea);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.mapBtn);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "HomePageWithMap";
            this.Text = "HomePageWithMap";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mapArea;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Button zoomOutBtn;
        private System.Windows.Forms.Button ZoomInBtn;
        private System.Windows.Forms.TextBox zoomTb;
        private System.Windows.Forms.TextBox findByNameTb;
        private System.Windows.Forms.Label findByNameLbl;
        private System.Windows.Forms.Label findByTypeLbl;
        private System.Windows.Forms.TextBox findByTypeTb;
        private System.Windows.Forms.Button mapBtn;
        private System.Windows.Forms.Button resetZoomBtn;
        private System.Windows.Forms.Button zoomOnItemsBtn;
        private System.Windows.Forms.PictureBox pictureBox11;
    }
}