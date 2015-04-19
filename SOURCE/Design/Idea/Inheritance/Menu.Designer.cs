namespace Design.Idea.Inheritance
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
            this.dynamicContainer = new System.Windows.Forms.GroupBox();
            this.topNav = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // dynamicContainer
            // 
            this.dynamicContainer.Location = new System.Drawing.Point(9, 47);
            this.dynamicContainer.Name = "dynamicContainer";
            this.dynamicContainer.Size = new System.Drawing.Size(200, 100);
            this.dynamicContainer.TabIndex = 0;
            this.dynamicContainer.TabStop = false;
            this.dynamicContainer.Text = "dynamicContainer";
            // 
            // topNav
            // 
            this.topNav.Location = new System.Drawing.Point(9, 12);
            this.topNav.Name = "topNav";
            this.topNav.Size = new System.Drawing.Size(263, 29);
            this.topNav.TabIndex = 1;
            this.topNav.TabStop = false;
            this.topNav.Text = "TopNav";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.topNav);
            this.Controls.Add(this.dynamicContainer);
            this.Name = "Menu";
            this.Text = "MenuBase";
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox dynamicContainer;
        private System.Windows.Forms.GroupBox topNav;

    }
}