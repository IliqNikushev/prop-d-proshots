using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design.Idea.Menus
{
    public partial class EmployeeMenu : Menu
    {
        public EmployeeMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Menus.AdminMenu().SetAsActive();
        }
    }
}
