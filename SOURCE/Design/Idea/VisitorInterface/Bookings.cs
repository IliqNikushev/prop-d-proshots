using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design.Idea.VisitorInterface
{
    public partial class Bookings : SubMenuBase
    {
        public Bookings(Form parent) : base(parent)
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new New.Bookings(this).Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new View.Bookings(this).Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
