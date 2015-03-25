using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design.Idea
{
    public partial class SubMenuBase : Form
    {
        public SubMenuBase() { InitializeComponent(); }
        public SubMenuBase(Form parent)
        {
            parent.Hide();
            this.FormClosed += (x, y) => parent.Show();
            InitializeComponent();
        }
    }
}
