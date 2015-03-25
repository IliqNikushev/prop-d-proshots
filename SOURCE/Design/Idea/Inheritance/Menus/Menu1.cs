using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design.Idea.Inheritance.Menus
{
    public partial class Menu1 : MenuBase
    {
        public Menu1(LayoutBase layout):base(layout)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Menu2(new Layouts.Layout1()).Show();
        }
    }
}
