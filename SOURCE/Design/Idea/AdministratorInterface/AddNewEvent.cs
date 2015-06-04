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
        public Point p;
        public AddNewEvent()
        {
            InitializeComponent();
        }

        private void AddNewEvent_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void buttonCreat_Click(object sender, EventArgs e)
        {
            EventLandmark ll = new EventLandmark(textBoxLabel.Text, richTextBoxDescription.Text, pictureBoxLandmark.Left - pictureBoxMap.Left, pictureBoxLandmark.Top - pictureBoxMap.Top, dateTimePickerStart.Value, dateTimePickerEnd.Value);

            ll.Create();

        }

        private void pictureBoxLandmark_MouseUp(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                Point d = new Point();

                d.X = pictureBoxLandmark.Left + e.X - p.X;
                d.Y = pictureBoxLandmark.Top + e.Y - p.Y;
                if (d.X > pictureBoxMap.Width + pictureBoxMap.Left || d.X < pictureBoxMap.Left)
                {
                    return;
                }
                if (d.Y > pictureBoxMap.Height + pictureBoxMap.Top || d.Y < pictureBoxMap.Top)
                {
                    return;
                }

                pictureBoxLandmark.Left = d.X;
                pictureBoxLandmark.Top = d.Y;
                p = e.Location;
            }
            flag = false;


        }

        private void pictureBoxLandmark_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;
            p = e.Location;
        }

        private void pictureBoxLandmark_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                Point d = new Point();

                d.X = pictureBoxLandmark.Left + e.X - p.X;
                d.Y = pictureBoxLandmark.Top + e.Y - p.Y;
                if (d.X > pictureBoxMap.Width + pictureBoxMap.Left || d.X < pictureBoxMap.Left)
                {
                    return;
                }
                if (d.Y > pictureBoxMap.Height + pictureBoxMap.Top || d.Y < pictureBoxMap.Top)
                {
                    return;
                }

                pictureBoxLandmark.Left = d.X;
                pictureBoxLandmark.Top = d.Y;
                p = e.Location;
            }
        }
    }
}
