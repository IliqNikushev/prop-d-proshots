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
            this.dynamicContainer.Location = new System.Drawing.Point(16, 197);
            this.dynamicContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dynamicContainer.Name = "dynamicContainer";
            this.dynamicContainer.Size = new System.Drawing.Size(347, 249);
            this.dynamicContainer.TabIndex = 2;
            // 
            // topNavContainer
            // 
            this.topNavContainer.Location = new System.Drawing.Point(20, 15);
            this.topNavContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.topNavContainer.Name = "topNavContainer";
            this.topNavContainer.Size = new System.Drawing.Size(343, 174);
            this.topNavContainer.TabIndex = 0;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 471);
            this.Controls.Add(this.topNavContainer);
            this.Controls.Add(this.dynamicContainer);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Menu";
            this.Text = "MenuBase";
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel dynamicContainer;
        protected System.Windows.Forms.Panel topNavContainer;
    }
}