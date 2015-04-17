using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design.Idea.AdministratorInterface
{
    public partial class Landing : LandingBase
    {
        private Pointable[] examples = new Pointable[]{
            new ShopExample(0,0,"KFC", "Fried chicken"),
            new ShopExample(100,100,"MC Donalds", "Fast Food"),
            new ShopExample(200,200,"Doctor", "Fast and Easy doctor repairs")
        };

        private Point dragOffset;
        private Point mouseDragStartLocation;

        float zoom = 1;
        float wantedZoom = 1;
        private bool mapDragging = false;
        public Landing(Form parent)
            : base(parent)
        {
            InitializeComponent();
            int mapX = mapArea.Left;
            int mapY = mapArea.Top;

            mapArea.Image = Properties.Resources.Park_English;
            PictureBox holder = new PictureBox();
            holder.Size = new Size(mapArea.Size.Width, mapArea.Size.Height);

            holder.Left = mapX;
            holder.Top = mapY;

            mapArea.Parent = holder;
            mapArea.Left = 0;
            mapArea.Top = 0;

            this.Controls.Add(holder);
            holder.BringToFront();
            mapArea.BringToFront();
            foreach (Pointable pointable in examples)
                pointable.AddToMap(mapArea);

            mapArea.MouseDown += (x, mouse) =>
            {
                if (mapDragging) return;
                this.Cursor = Cursors.Cross;
                this.mapDragging = true;
                mouseDragStartLocation = mouse.Location;
            };

            mapArea.MouseUp += (x, mouse) =>
            {
                if (!mapDragging) return;

                mapDragging = false;
                this.Cursor = Cursors.Default;
                mapArea.Location = dragOffset;
                holder.Refresh();
            };

            mapArea.MouseMove += (sender, mouse) =>
            {
                if (!mapDragging) return;

                if (mouse.Location == mouseDragStartLocation)
                    return;
                Point delta = new Point(mouse.Location.X - mouseDragStartLocation.X, mouse.Location.Y - mouseDragStartLocation.Y);
                Point previous = dragOffset;
                dragOffset = new Point(dragOffset.X + delta.X, dragOffset.Y + delta.Y);

                float minimumArea = 64;

                if (
                    (dragOffset.X < -mapArea.Width + minimumArea || dragOffset.Y < -mapArea.Height + minimumArea) ||
                    (dragOffset.X > holder.Width - minimumArea || dragOffset.Y > holder.Height - minimumArea)
                    )
                {
                    dragOffset = previous;
                    return;
                }
                mapArea.Location = dragOffset;
                holder.Refresh();
            };
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void SetZoom(float amount)
        {
            float delta = amount - wantedZoom;
            ChangeZoom(delta);
        }

        private void ResetZoom()
        {
            SetZoom(1);
        }

        private void ChangeZoom(float amount)
        {
            if (wantedZoom + amount <= 1) return;
            //example : change from 1.1 to 1.2
            float target = wantedZoom + amount; //1.2
            float current = zoom; // 1.1
            float difference = target / current; // 1.1 * ? = 1.2

            zoom *= difference;
            wantedZoom += amount;

            mapArea.Scale(new SizeF(difference, difference));

            mapArea.Location = dragOffset;
        }

        private void ZoomToItems(params Pointable[] items)
        {
            int left = items[0].X;
            int right = items[0].X;
            int top = items[0].Y;
            int bottom = items[0].Y;

            foreach (Pointable item in items)
            {
                if (item.X < left) left = item.X;
                else if (item.X > right) right = item.X;

                if (item.Y < top) top = item.Y;
                else if (item.Y > bottom) bottom = item.Y;
            }

            float width = right - left + Pointable.IconSize;
            float height = bottom - top + Pointable.IconSize;

            dragOffset = new Point(left, top);

            float deltaZoomWidth = mapArea.Width / width;
            float deltaZoomHeight = mapArea.Height / height;
            float deltaZoom = deltaZoomWidth > deltaZoomHeight ? deltaZoomWidth : deltaZoomHeight;

            ChangeZoom(deltaZoom - 1);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new ShopSubMenu(this).Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new Calendar(this).Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            new Camping(this).Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new ServiceDesk(this).Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            new Visitors(this).Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            new PcDoctor(this).Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            new Employees(this).Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeZoom(0.1f);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeZoom(-0.1f);
        }
    }
}