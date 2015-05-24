using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Common
{
    abstract class MapPoint
    {
        public const int IconSize = 16;
        private Classes.Landmark Landmark;
        public string Label { get { return this.Landmark.Label; } }
        public string Description { get { return this.Landmark.Description; } }
        public int X { get { return this.Landmark.X; } }
        public int Y { get { return this.Landmark.Y; } }

        protected abstract System.Drawing.Bitmap Image { get; }

        private System.Windows.Forms.PictureBox marker;

        public void HideInMap()
        {
            if (marker != null)
                marker.Visible = false;
        }

        public void ShowInMap()
        {
            if (marker != null)
                marker.Visible = true;
        }

        //temporary constructor
        public MapPoint(int x, int y, string label, string description)
        {
            this.Landmark = new Classes.EventLandmark(-1, label, description, x, y, DateTime.Today, DateTime.Today);
        }

        //temporary constructor
        public MapPoint(Classes.Landmark landmark)
        {
            this.Landmark = landmark;
        }

        public void AddToMap(System.Windows.Forms.Control map)
        {
            System.Drawing.Bitmap image = this.Image;
#warning TODO:Add classes to use the map points

            System.Windows.Forms.Label onHover = new System.Windows.Forms.Label();
            onHover.Text = this.Label;
            if (this.Description != null)
                onHover.Text += "\n" + this.Description;

            marker = new System.Windows.Forms.PictureBox();
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
}