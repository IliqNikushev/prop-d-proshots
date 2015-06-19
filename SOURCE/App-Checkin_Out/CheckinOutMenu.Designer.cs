namespace App_Checkin_Out
{
    partial class CheckinOutMenu
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
            this.components = new System.ComponentModel.Container();
            this.statePbox = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.statePbox)).BeginInit();
            this.SuspendLayout();
            // 
            // statePbox
            // 
            this.statePbox.Location = new System.Drawing.Point(12, 12);
            this.statePbox.Name = "statePbox";
            this.statePbox.Size = new System.Drawing.Size(260, 237);
            this.statePbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.statePbox.TabIndex = 0;
            this.statePbox.TabStop = false;
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // CheckinOutMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.statePbox);
            this.Name = "CheckinOutMenu";
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.statePbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox statePbox;
        private System.Windows.Forms.Timer timer;
    }
}

