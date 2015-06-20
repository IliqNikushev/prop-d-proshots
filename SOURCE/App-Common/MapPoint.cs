using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Common
{
    static class MapPointUtils
    {
        public static void Remove(this System.Windows.Forms.Control c)
        {
            c.Parent.Controls.Remove(c);
        }
    }

    class MapPoint : IEquatable<Classes.Landmark>, IComparable<Classes.Landmark>
    {
        public const int IconSize = 16;
        private Classes.Landmark Landmark;
        public string Label { get { return this.Landmark.Label; } }
        public string Description { get { return this.Landmark.Description; } }
        public static LandmarkType TypeOf(Classes.Landmark l)
        {
            Type t = l.GetType();
            if (l != null)
            {
                if (t == typeof(Classes.EventLandmark)) return LandmarkType.Event;
                if (t == typeof(Classes.PayPalMachine)) return LandmarkType.Paypal;
                if (t == typeof(Classes.ShopWorkplace)) return LandmarkType.Shop;
                if (t == typeof(Classes.InformationKioskWorkplace)) return LandmarkType.Information;
                if (t == typeof(Classes.ITServiceWorkplace)) return LandmarkType.Loan;
                if (t == typeof(Classes.PCDoctorWorkplace)) return LandmarkType.PC_Doctor;
                if(t == typeof(Classes.TentPitch)) return LandmarkType.Tent;
            }
            throw new InvalidOperationException("UNKNOWN LANDMARK," + t.GetType().Name);
        }
        public LandmarkType Type
        {
            get
            {
                return TypeOf(this.Landmark);
            }
        }

        public int X { get { return this.Landmark.X; } }
        public int Y { get { return this.Landmark.Y; } }
        public string Icon { get { return this.Landmark.Icon; } }

        private System.Windows.Forms.PictureBox marker;
        System.Windows.Forms.Label onHover;

        public void Clear()
        {
            marker.Remove();
            marker = null;
            onHover.Remove();
            onHover = null;
            this.Landmark = null;
        }

        public void Select()
        {
            this.marker.BackColor = System.Drawing.Color.Green;
        }

        public void Deselect()
        {
            this.marker.BackColor = this.onHover.BackColor;
        }

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
        public MapPoint(Classes.Landmark landmark)
        {
            this.Landmark = landmark;
        }

        public void AddToMap(System.Windows.Forms.Control map)
        {
            onHover = new System.Windows.Forms.Label();
            onHover.Text = this.Label;
            if (this.Description != null && this.Description.Trim() != "")
                onHover.Text += "\n" + this.Description;

            marker = new System.Windows.Forms.PictureBox();
            marker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            marker.Size = new System.Drawing.Size(IconSize, IconSize);
            marker.ImageLocation = Icon;
            onHover.Visible = false;
            onHover.SendToBack();

            marker.Left = this.X;
            marker.Top = this.Y;
            onHover.Left = this.X + IconSize;
            onHover.Top = this.Y;

            onHover.AutoSize = true;

            marker.MouseHover += (x, y) => { if (!onHover.Visible) { onHover.Visible = true; onHover.BringToFront(); marker.BringToFront(); } };
            marker.MouseLeave += (x, y) => { if (onHover.Visible) { onHover.SendToBack(); onHover.Visible = false; } };
            marker.BringToFront();
            map.Controls.Add(onHover);
            map.Controls.Add(marker);
        }

        public bool Equals(Classes.Landmark other)
        {
            return this.Landmark == other;
        }

        public int CompareTo(Classes.Landmark other)
        {
            return this.Landmark.CompareTo(other);
        }

        public static bool operator ==(MapPoint p, Classes.Landmark l)
        {
            if ((object)p == null) return false;
            return p.Equals(l);
        }

        public static bool operator ==(Classes.Landmark l, MapPoint p)
        {
            return p.Equals(l);
        }

        public static bool operator !=(MapPoint p, Classes.Landmark l)
        {
            return !p.Equals(l);
        }

        public static bool operator !=(Classes.Landmark l, MapPoint p)
        {
            return !p.Equals(l);
        }
    }
}