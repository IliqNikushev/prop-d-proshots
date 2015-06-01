using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;

namespace Design.Idea.AdministratorInterface
{
    public partial class AddNewEvent : Form
    {
        public bool flag=false;
        public AddNewEvent()
        {
            InitializeComponent();

            foreach (Control item in this.Controls)
            {
                item.MouseUp += pictureBoxLandmark_MouseUp;
            }

            pictureBoxMap.Controls.Add(pictureBoxLandmark);
            pictureBoxLandmark.Left = pictureBoxLandmark.Left - pictureBoxMap.Left;
            pictureBoxLandmark.Top = pictureBoxLandmark.Top - pictureBoxMap.Top;
            pictureBoxLandmark.BackColor = Color.FromArgb(0,255,255,255);
        }

        private void AddNewEvent_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private float MapScaleX
        {
            get
            {
                return this.pictureBoxMap.Width / (float)new HomePageWithMap().MapWidth;
            }
        }

        private float MapScaleY
        {
            get
            {
                return this.pictureBoxMap.Height / (float)new HomePageWithMap().MapHeight;
            }
        }

        private void buttonCreat_Click(object sender, EventArgs e)
        {
            EventLandmark ll = new EventLandmark(textBoxLabel.Text, richTextBoxDescription.Text,
                (int)((float)(pictureBoxLandmark.Left * MapScaleX)),
                (int)((float)(pictureBoxLandmark.Top * MapScaleY)),
                dateTimePickerStart.Value, dateTimePickerEnd.Value);

            ll.Create();

        }

        private void pictureBoxLandmark_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
        }

        private void pictureBoxLandmark_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;
        }

        private void pictureBoxLandmark_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                Point d = new Point();

                d.X = e.X + pictureBoxLandmark.Left - pictureBoxLandmark.Width / 2;
                d.Y = e.Y + pictureBoxLandmark.Top - pictureBoxLandmark.Height;
               
                if (d.X > pictureBoxMap.Width - pictureBoxLandmark.Width || d.X < 0)
                {
                    return;
                }
                if (d.Y > pictureBoxMap.Height - pictureBoxLandmark.Height || d.Y < 0)
                {
                    return;
                }
                pictureBoxLandmark.Refresh();
                pictureBoxMap.Refresh();
                pictureBoxLandmark.Location = d;
            }
        }
    }
}
