﻿namespace Design.Idea
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
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.findByNameTb = new System.Windows.Forms.TextBox();
            this.findByNameLbl = new System.Windows.Forms.Label();
            this.findByTypeLbl = new System.Windows.Forms.Label();
            this.findByTypeTb = new System.Windows.Forms.TextBox();
            this.mapBtn = new System.Windows.Forms.Button();
            this.dynamicContainer.SuspendLayout();
            this.topNavContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // dynamicContainer
            // 
            this.dynamicContainer.Controls.Add(this.findByNameTb);
            this.dynamicContainer.Controls.Add(this.zoomOutBtn);
            this.dynamicContainer.Controls.Add(this.zoomTb);
            this.dynamicContainer.Controls.Add(this.findByTypeLbl);
            this.dynamicContainer.Controls.Add(this.findByTypeTb);
            this.dynamicContainer.Controls.Add(this.ZoomInBtn);
            this.dynamicContainer.Controls.Add(this.findByNameLbl);
            this.dynamicContainer.Controls.Add(this.mapArea);
            this.dynamicContainer.Controls.Add(this.pictureBox10);
            this.dynamicContainer.Size = new System.Drawing.Size(768, 531);
            // 
            // topNav
            // 
            this.topNavContainer.Controls.Add(this.mapBtn);
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
            this.zoomTb.Location = new System.Drawing.Point(528, 398);
            this.zoomTb.Name = "zoomTb";
            this.zoomTb.Size = new System.Drawing.Size(52, 20);
            this.zoomTb.TabIndex = 29;
            // 
            // zoomOutBtn
            // 
            this.zoomOutBtn.Location = new System.Drawing.Point(586, 395);
            this.zoomOutBtn.Name = "zoomOutBtn";
            this.zoomOutBtn.Size = new System.Drawing.Size(42, 24);
            this.zoomOutBtn.TabIndex = 28;
            this.zoomOutBtn.Text = "-";
            this.zoomOutBtn.UseVisualStyleBackColor = true;
            // 
            // ZoomInBtn
            // 
            this.ZoomInBtn.Location = new System.Drawing.Point(480, 396);
            this.ZoomInBtn.Name = "ZoomInBtn";
            this.ZoomInBtn.Size = new System.Drawing.Size(42, 23);
            this.ZoomInBtn.TabIndex = 27;
            this.ZoomInBtn.Text = "+";
            this.ZoomInBtn.UseVisualStyleBackColor = true;
            // 
            // mapArea
            // 
            this.mapArea.Image = global::Design.Properties.Resources.Park_English;
            this.mapArea.InitialImage = null;
            this.mapArea.Location = new System.Drawing.Point(367, 20);
            this.mapArea.Name = "mapArea";
            this.mapArea.Size = new System.Drawing.Size(371, 369);
            this.mapArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mapArea.TabIndex = 0;
            this.mapArea.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::Design.Properties.Resources.imac1;
            this.pictureBox10.Location = new System.Drawing.Point(354, 2);
            this.pictureBox10.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(400, 474);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 23;
            this.pictureBox10.TabStop = false;
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
            // HomePageWithMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 714);
            this.Name = "HomePageWithMap";
            this.Text = "HomePageWithMap";
            this.dynamicContainer.ResumeLayout(false);
            this.dynamicContainer.PerformLayout();
            this.topNavContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);

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
    }
}