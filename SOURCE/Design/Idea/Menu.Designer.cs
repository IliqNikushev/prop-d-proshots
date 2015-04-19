namespace Design.Idea
{
    partial class Menu
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
            this.dynamicContainer = new System.Windows.Forms.Panel();
            this.topNavContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // dynamicContainer
            // 
            this.dynamicContainer.Location = new System.Drawing.Point(12, 47);
            this.dynamicContainer.Name = "dynamicContainer";
            this.dynamicContainer.Size = new System.Drawing.Size(260, 202);
            this.dynamicContainer.TabIndex = 2;
            // 
            // topNav
            // 
            this.topNavContainer.Location = new System.Drawing.Point(15, 12);
            this.topNavContainer.Name = "topNav";
            this.topNavContainer.Size = new System.Drawing.Size(257, 29);
            this.topNavContainer.TabIndex = 0;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.topNavContainer);
            this.Controls.Add(this.dynamicContainer);
            this.Name = "Menu";
            this.Text = "MenuBase";
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel dynamicContainer;
        protected System.Windows.Forms.Panel topNavContainer;
    }
}