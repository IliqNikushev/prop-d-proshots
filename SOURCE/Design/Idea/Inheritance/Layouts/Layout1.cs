using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design.Idea.Inheritance.Layouts
{
    public partial class Layout1 : LayoutBase
    {
        public Layout1() : base()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((sender as Control).Parent as Form).Close();
        }
    }
}
