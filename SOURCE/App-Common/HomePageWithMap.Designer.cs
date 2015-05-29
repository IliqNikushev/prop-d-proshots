namespace App_Common
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
            this.mapArea = new System.Windows.Forms.PictureBox();
            this.mapHolder = new System.Windows.Forms.PictureBox();
            this.findByNameTb = new System.Windows.Forms.TextBox();
            this.findByNameLbl = new System.Windows.Forms.Label();
            this.findByTypeLbl = new System.Windows.Forms.Label();
            this.findByTypeTb = new System.Windows.Forms.TextBox();
            this.mapBtn = new System.Windows.Forms.Button();
            this.zoomOnItemsBtn = new System.Windows.Forms.Button();
            this.resetZoomBtn = new System.Windows.Forms.Button();
            this.vr = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mapArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapHolder)).BeginInit();
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
            this.zoomTb.Location = new System.Drawing.Point(528, 399);
            this.zoomTb.Name = "zoomTb";
            this.zoomTb.Size = new System.Drawing.Size(52, 20);
            this.zoomTb.TabIndex = 29;
            // 
            // zoomOutBtn
            // 
            this.zoomOutBtn.Location = new System.Drawing.Point(593, 398);
            this.zoomOutBtn.Name = "zoomOutBtn";
            this.zoomOutBtn.Size = new System.Drawing.Size(42, 24);
            this.zoomOutBtn.TabIndex = 28;
            this.zoomOutBtn.Text = "-";
            this.zoomOutBtn.UseVisualStyleBackColor = true;
            this.zoomOutBtn.Click += new System.EventHandler(this.zoomOutBtn_Click);
            // 
            // ZoomInBtn
            // 
            this.ZoomInBtn.Location = new System.Drawing.Point(471, 399);
            this.ZoomInBtn.Name = "ZoomInBtn";
            this.ZoomInBtn.Size = new System.Drawing.Size(42, 23);
            this.ZoomInBtn.TabIndex = 27;
            this.ZoomInBtn.Text = "+";
            this.ZoomInBtn.UseVisualStyleBackColor = true;
            this.ZoomInBtn.Click += new System.EventHandler(this.ZoomInBtn_Click);
            // 
            // mapArea
            // 
            this.mapArea.Image = global::App_Common.Properties.Resources.Park_English;
            this.mapArea.InitialImage = null;
            this.mapArea.Location = new System.Drawing.Point(368, 19);
            this.mapArea.Name = "mapArea";
            this.mapArea.Size = new System.Drawing.Size(371, 369);
            this.mapArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mapArea.TabIndex = 0;
            this.mapArea.TabStop = false;
            // 
            // mapHolder
            // 
            this.mapHolder.Image = global::App_Common.Properties.Resources.imac1;
            this.mapHolder.Location = new System.Drawing.Point(354, 2);
            this.mapHolder.Margin = new System.Windows.Forms.Padding(2);
            this.mapHolder.Name = "mapHolder";
            this.mapHolder.Size = new System.Drawing.Size(400, 474);
            this.mapHolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mapHolder.TabIndex = 23;
            this.mapHolder.TabStop = false;
            // 
            // findByNameTb
            // 
            this.findByNameTb.AcceptsReturn = true;
            this.findByNameTb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.findByNameTb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.findByNameTb.Location = new System.Drawing.Point(354, 443);
            this.findByNameTb.Multiline = true;
            this.findByNameTb.Name = "findByNameTb";
            this.findByNameTb.Size = new System.Drawing.Size(130, 20);
            this.findByNameTb.TabIndex = 30;
            // 
            // findByNameLbl
            // 
            this.findByNameLbl.AutoSize = true;
            this.findByNameLbl.Location = new System.Drawing.Point(386, 427);
            this.findByNameLbl.Name = "findByNameLbl";
            this.findByNameLbl.Size = new System.Drawing.Size(72, 13);
            this.findByNameLbl.TabIndex = 31;
            this.findByNameLbl.Text = "Find by Name";
            // 
            // findByTypeLbl
            // 
            this.findByTypeLbl.AutoSize = true;
            this.findByTypeLbl.Location = new System.Drawing.Point(659, 427);
            this.findByTypeLbl.Name = "findByTypeLbl";
            this.findByTypeLbl.Size = new System.Drawing.Size(68, 13);
            this.findByTypeLbl.TabIndex = 33;
            this.findByTypeLbl.Text = "Find by Type";
            // 
            // findByTypeTb
            // 
            this.findByTypeTb.AcceptsReturn = true;
            this.findByTypeTb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.findByTypeTb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.findByTypeTb.Location = new System.Drawing.Point(624, 443);
            this.findByTypeTb.Multiline = true;
            this.findByTypeTb.Name = "findByTypeTb";
            this.findByTypeTb.Size = new System.Drawing.Size(130, 20);
            this.findByTypeTb.TabIndex = 34;
            // 
            // mapBtn
            // 
            this.mapBtn.Location = new System.Drawing.Point(4, 4);
            this.mapBtn.Name = "mapBtn";
            this.mapBtn.Size = new System.Drawing.Size(75, 23);
            this.mapBtn.TabIndex = 0;
            this.mapBtn.Text = "Map";
            this.mapBtn.UseVisualStyleBackColor = true;
            this.mapBtn.Click += new System.EventHandler(this.mapBtn_Click);
            // 
            // zoomOnItemsBtn
            // 
            this.zoomOnItemsBtn.Location = new System.Drawing.Point(362, 399);
            this.zoomOnItemsBtn.Name = "zoomOnItemsBtn";
            this.zoomOnItemsBtn.Size = new System.Drawing.Size(102, 23);
            this.zoomOnItemsBtn.TabIndex = 35;
            this.zoomOnItemsBtn.Text = "Zoom on items";
            this.zoomOnItemsBtn.UseVisualStyleBackColor = true;
            this.zoomOnItemsBtn.Click += new System.EventHandler(this.zoomOnItemsBtn_Click);
            // 
            // resetZoomBtn
            // 
            this.resetZoomBtn.Location = new System.Drawing.Point(654, 398);
            this.resetZoomBtn.Name = "resetZoomBtn";
            this.resetZoomBtn.Size = new System.Drawing.Size(86, 23);
            this.resetZoomBtn.TabIndex = 36;
            this.resetZoomBtn.Text = "Reset zoom";
            this.resetZoomBtn.UseVisualStyleBackColor = true;
            this.resetZoomBtn.Click += new System.EventHandler(this.resetZoomBtn_Click);
            // 
            // vr
            // 
            this.vr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vr.Location = new System.Drawing.Point(339, -20);
            this.vr.Name = "vr";
            this.vr.Size = new System.Drawing.Size(10, 496);
            this.vr.TabIndex = 47;
            // 
            // HomePageWithMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 714);
            this.Controls.Add(this.vr);
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
            this.Controls.Add(this.mapHolder);
            this.Controls.Add(this.mapBtn);
            this.Name = "HomePageWithMap";
            this.Text = "HomePageWithMap";
            ((System.ComponentModel.ISupportInitialize)(this.mapArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapHolder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mapArea;
        private System.Windows.Forms.PictureBox mapHolder;
        private System.Windows.Forms.Button zoomOutBtn;
        private System.Windows.Forms.Button ZoomInBtn;
        private System.Windows.Forms.TextBox zoomTb;
        protected System.Windows.Forms.TextBox findByNameTb;
        protected System.Windows.Forms.Label findByNameLbl;
        protected System.Windows.Forms.Label findByTypeLbl;
        protected System.Windows.Forms.TextBox findByTypeTb;
        private System.Windows.Forms.Button mapBtn;
        private System.Windows.Forms.Button resetZoomBtn;
        private System.Windows.Forms.Button zoomOnItemsBtn;
        private System.Windows.Forms.Label vr;
    }
}