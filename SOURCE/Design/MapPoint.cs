using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design
{
    abstract class Pointable
    {
        public const int IconSize = 32;
        private string Label;
        private string Description;
        public int X { get; private set; }
        public int Y { get; private set; }

        public Pointable(int x, int y, string label, string description)
        {
            this.Label = label;
            this.Description = description;
            this.X = x;
            this.Y = y;
        }

        public void AddToMap(System.Windows.Forms.Control map)
        {
            System.Drawing.Bitmap image = null;
            if (this.GetType() == typeof(ShopExample))
                image = Design.Properties.Resources.Back;

            if (image == null)
                throw new InvalidOperationException("Unknown type to make a marker to : " + this.GetType().Name);

            System.Windows.Forms.Label onHover = new System.Windows.Forms.Label();
            onHover.Text = this.Label;
            if (this.Description != null)
                onHover.Text += "\n" + this.Description;

            System.Windows.Forms.PictureBox marker = new System.Windows.Forms.PictureBox();
            marker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            marker.Size = new System.Drawing.Size(IconSize, IconSize);
            onHover.Visible = false;
            onHover.SendToBack();

            marker.Left = this.X;
            marker.Top = this.Y;
            onHover.Left = this.X + IconSize;
            onHover.Top = this.Y;

            onHover.AutoSize = true;

            marker.Image = image;
            marker.MouseHover += (x, y) => { if (!onHover.Visible) { onHover.Visible = true; onHover.BringToFront(); marker.BringToFront(); } };
            marker.MouseLeave += (x, y) => { if (onHover.Visible) { onHover.SendToBack(); onHover.Visible = false; } };
            marker.BringToFront();
            map.Controls.Add(onHover);
            map.Controls.Add(marker);
        }
    }

    class ShopExample : Pointable
    {
        public ShopExample(int x, int y, string label, string description)
            : base(x, y, label, description)
        { }
    }
}