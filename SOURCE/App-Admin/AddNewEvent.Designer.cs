namespace App_Admin
{
    partial class AddNewEvent
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
            this.textBoxLabel = new System.Windows.Forms.TextBox();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBoxLandmark = new System.Windows.Forms.PictureBox();
            this.pictureBoxMap = new System.Windows.Forms.PictureBox();
            this.buttonCreat = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLandmark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxLabel
            // 
            this.textBoxLabel.Location = new System.Drawing.Point(32, 43);
            this.textBoxLabel.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLabel.Name = "textBoxLabel";
            this.textBoxLabel.Size = new System.Drawing.Size(76, 20);
            this.textBoxLabel.TabIndex = 0;
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Location = new System.Drawing.Point(40, 224);
            this.richTextBoxDescription.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(270, 119);
            this.richTextBoxDescription.TabIndex = 3;
            this.richTextBoxDescription.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Start Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 139);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "End Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 201);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Description:";
            // 
            // pictureBoxLandmark
            // 
            this.pictureBoxLandmark.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLandmark.Image = global::App_Admin.Properties.Resources.pin601;
            this.pictureBoxLandmark.Location = new System.Drawing.Point(467, 54);
            this.pictureBoxLandmark.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxLandmark.Name = "pictureBoxLandmark";
            this.pictureBoxLandmark.Size = new System.Drawing.Size(29, 37);
            this.pictureBoxLandmark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLandmark.TabIndex = 9;
            this.pictureBoxLandmark.TabStop = false;
            this.pictureBoxLandmark.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLandmark_MouseDown);
            this.pictureBoxLandmark.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLandmark_MouseMove);
            this.pictureBoxLandmark.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLandmark_MouseUp);
            // 
            // pictureBoxMap
            // 
            this.pictureBoxMap.Image = global::App_Admin.Properties.Resources.Park_English;
            this.pictureBoxMap.Location = new System.Drawing.Point(314, 9);
            this.pictureBoxMap.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxMap.Name = "pictureBoxMap";
            this.pictureBoxMap.Size = new System.Drawing.Size(287, 369);
            this.pictureBoxMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMap.TabIndex = 8;
            this.pictureBoxMap.TabStop = false;
            // 
            // buttonCreat
            // 
            this.buttonCreat.Location = new System.Drawing.Point(192, 347);
            this.buttonCreat.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCreat.Name = "buttonCreat";
            this.buttonCreat.Size = new System.Drawing.Size(68, 19);
            this.buttonCreat.TabIndex = 10;
            this.buttonCreat.Text = "Create";
            this.buttonCreat.UseVisualStyleBackColor = true;
            this.buttonCreat.Click += new System.EventHandler(this.buttonCreat_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(52, 347);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(56, 19);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(32, 103);
            this.dateTimePickerStart.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerStart.MaxDate = new System.DateTime(2015, 6, 30, 0, 0, 0, 0);
            this.dateTimePickerStart.MinDate = new System.DateTime(2015, 6, 25, 0, 0, 0, 0);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerStart.TabIndex = 12;
            this.dateTimePickerStart.Value = new System.DateTime(2015, 6, 25, 0, 0, 0, 0);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(32, 164);
            this.dateTimePickerEnd.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerEnd.MaxDate = new System.DateTime(2015, 6, 30, 0, 0, 0, 0);
            this.dateTimePickerEnd.MinDate = new System.DateTime(2015, 6, 25, 0, 0, 0, 0);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerEnd.TabIndex = 13;
            this.dateTimePickerEnd.Value = new System.DateTime(2015, 6, 25, 0, 0, 0, 0);
            // 
            // AddNewEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 386);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCreat);
            this.Controls.Add(this.pictureBoxLandmark);
            this.Controls.Add(this.pictureBoxMap);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.textBoxLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddNewEvent";
            this.Text = "AddNewEvent";
            this.Load += new System.EventHandler(this.AddNewEvent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLandmark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLabel;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBoxMap;
        private System.Windows.Forms.PictureBox pictureBoxLandmark;
        private System.Windows.Forms.Button buttonCreat;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
    }
}