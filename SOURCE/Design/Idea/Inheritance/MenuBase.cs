using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design.Idea.Inheritance
{
    public partial class MenuBase : Form
    {
        public MenuBase(LayoutBase layout) : this() 
        {
            foreach (var item in layout.Controls)
                this.Controls.Add(item as Control);
        }

        public MenuBase()
        {
            InitializeComponent();
        }
    }
}
