namespace App_Employee
{
    partial class PCDoctorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PCDoctorForm));
            this.btnView = new System.Windows.Forms.Button();
            this.lblModel = new System.Windows.Forms.Label();
            this.tbModel = new System.Windows.Forms.TextBox();
            this.lblDescr = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.tbBrand = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblComp = new System.Windows.Forms.Label();
            this.lbCompleted = new System.Windows.Forms.ListBox();
            this.btnFinish = new System.Windows.Forms.Button();
            this.lblQueue = new System.Windows.Forms.Label();
            this.lbQueue = new System.Windows.Forms.ListBox();
            this.picVis = new System.Windows.Forms.PictureBox();
            this.lblVisCard = new System.Windows.Forms.Label();
            this.tbVisCard = new System.Windows.Forms.TextBox();
            this.lblVisName = new System.Windows.Forms.Label();
            this.tbVisName = new System.Windows.Forms.TextBox();
            this.logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picVis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.Location = new System.Drawing.Point(221, 272);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(85, 33);
            this.btnView.TabIndex = 130;
            this.btnView.Text = "View tasks";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(27, 192);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(36, 13);
            this.lblModel.TabIndex = 129;
            this.lblModel.Text = "Model";
            // 
            // tbModel
            // 
            this.tbModel.Location = new System.Drawing.Point(73, 192);
            this.tbModel.Name = "tbModel";
            this.tbModel.Size = new System.Drawing.Size(86, 20);
            this.tbModel.TabIndex = 128;
            // 
            // lblDescr
            // 
            this.lblDescr.AutoSize = true;
            this.lblDescr.Location = new System.Drawing.Point(8, 218);
            this.lblDescr.Name = "lblDescr";
            this.lblDescr.Size = new System.Drawing.Size(60, 13);
            this.lblDescr.TabIndex = 127;
            this.lblDescr.Text = "Description";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(32, 166);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(35, 13);
            this.lblBrand.TabIndex = 126;
            this.lblBrand.Text = "Brand";
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(73, 218);
            this.tbDesc.Multiline = true;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(142, 48);
            this.tbDesc.TabIndex = 125;
            // 
            // tbBrand
            // 
            this.tbBrand.Location = new System.Drawing.Point(73, 166);
            this.tbBrand.Name = "tbBrand";
            this.tbBrand.Size = new System.Drawing.Size(86, 20);
            this.tbBrand.TabIndex = 124;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(81, 272);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(134, 33);
            this.btnAdd.TabIndex = 123;
            this.btnAdd.Text = "Add appointment";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblComp
            // 
            this.lblComp.AutoSize = true;
            this.lblComp.Location = new System.Drawing.Point(352, 330);
            this.lblComp.Name = "lblComp";
            this.lblComp.Size = new System.Drawing.Size(123, 13);
            this.lblComp.TabIndex = 122;
            this.lblComp.Text = "Completed appointments";
            // 
            // lbCompleted
            // 
            this.lbCompleted.FormattingEnabled = true;
            this.lbCompleted.Location = new System.Drawing.Point(350, 349);
            this.lbCompleted.Name = "lbCompleted";
            this.lbCompleted.Size = new System.Drawing.Size(332, 186);
            this.lbCompleted.TabIndex = 121;
            // 
            // btnFinish
            // 
            this.btnFinish.Image = ((System.Drawing.Image)(resources.GetObject("btnFinish.Image")));
            this.btnFinish.Location = new System.Drawing.Point(25, 542);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(134, 33);
            this.btnFinish.TabIndex = 120;
            this.btnFinish.Text = "Finish appointment";
            this.btnFinish.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFinish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // lblQueue
            // 
            this.lblQueue.AutoSize = true;
            this.lblQueue.Location = new System.Drawing.Point(22, 330);
            this.lblQueue.Name = "lblQueue";
            this.lblQueue.Size = new System.Drawing.Size(111, 13);
            this.lblQueue.TabIndex = 119;
            this.lblQueue.Text = "Queued appointments";
            // 
            // lbQueue
            // 
            this.lbQueue.FormattingEnabled = true;
            this.lbQueue.Location = new System.Drawing.Point(12, 349);
            this.lbQueue.Name = "lbQueue";
            this.lbQueue.Size = new System.Drawing.Size(332, 186);
            this.lbQueue.TabIndex = 118;
            // 
            // picVis
            // 
            this.picVis.Image = ((System.Drawing.Image)(resources.GetObject("picVis.Image")));
            this.picVis.InitialImage = null;
            this.picVis.Location = new System.Drawing.Point(6, 11);
            this.picVis.Name = "picVis";
            this.picVis.Size = new System.Drawing.Size(100, 95);
            this.picVis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVis.TabIndex = 112;
            this.picVis.TabStop = false;
            // 
            // lblVisCard
            // 
            this.lblVisCard.AutoSize = true;
            this.lblVisCard.Location = new System.Drawing.Point(110, 31);
            this.lblVisCard.Name = "lblVisCard";
            this.lblVisCard.Size = new System.Drawing.Size(43, 13);
            this.lblVisCard.TabIndex = 113;
            this.lblVisCard.Text = "ID Card";
            // 
            // tbVisCard
            // 
            this.tbVisCard.Location = new System.Drawing.Point(153, 28);
            this.tbVisCard.Name = "tbVisCard";
            this.tbVisCard.Size = new System.Drawing.Size(86, 20);
            this.tbVisCard.TabIndex = 115;
            // 
            // lblVisName
            // 
            this.lblVisName.AutoSize = true;
            this.lblVisName.Location = new System.Drawing.Point(112, 62);
            this.lblVisName.Name = "lblVisName";
            this.lblVisName.Size = new System.Drawing.Size(35, 13);
            this.lblVisName.TabIndex = 114;
            this.lblVisName.Text = "Name";
            // 
            // tbVisName
            // 
            this.tbVisName.Location = new System.Drawing.Point(153, 58);
            this.tbVisName.Name = "tbVisName";
            this.tbVisName.Size = new System.Drawing.Size(86, 20);
            this.tbVisName.TabIndex = 116;
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(641, -1);
            this.logo.Margin = new System.Windows.Forms.Padding(2);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(64, 64);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 117;
            this.logo.TabStop = false;
            // 
            // PCDoctorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 583);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.tbModel);
            this.Controls.Add(this.lblDescr);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.tbBrand);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblComp);
            this.Controls.Add(this.lbCompleted);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.lblQueue);
            this.Controls.Add(this.lbQueue);
            this.Controls.Add(this.picVis);
            this.Controls.Add(this.lblVisCard);
            this.Controls.Add(this.tbVisCard);
            this.Controls.Add(this.lblVisName);
            this.Controls.Add(this.tbVisName);
            this.Controls.Add(this.logo);
            this.Name = "PCDoctorForm";
            this.Text = "PCDoctor";
            ((System.ComponentModel.ISupportInitialize)(this.picVis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox tbModel;
        private System.Windows.Forms.Label lblDescr;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.TextBox tbBrand;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblComp;
        private System.Windows.Forms.ListBox lbCompleted;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label lblQueue;
        private System.Windows.Forms.ListBox lbQueue;
        private System.Windows.Forms.PictureBox picVis;
        private System.Windows.Forms.Label lblVisCard;
        private System.Windows.Forms.TextBox tbVisCard;
        private System.Windows.Forms.Label lblVisName;
        private System.Windows.Forms.TextBox tbVisName;
        private System.Windows.Forms.PictureBox logo;
    }
}