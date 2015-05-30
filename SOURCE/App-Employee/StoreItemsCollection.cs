using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Employee
{
    public class StoreItemsCollection
    {
        public VScrollBar Bar;
        public Panel panel;
        public IEnumerable<Control> Controls;
        public int X;
        public int Y;

        public StoreItemsCollection(Control parent, VScrollBar verticalBar, int neededHeight, IEnumerable<Control> controls, int x = 0, int y = 0)
        {
            this.Bar = verticalBar;
            this.X = x;
            this.Y = y;

            Panel holder = new Panel();

            this.panel = new Panel();
            holder.Controls.Add(panel);
            parent.Controls.Add(holder);

            holder.Left = x;
            holder.Top = y;
            holder.Height = verticalBar.Height + 10;
            panel.Width = verticalBar.Left - x;
            holder.Width = panel.Width;
            panel.Height = neededHeight + 10;

            foreach (Control control in controls)
                control.Parent = panel;

            if (neededHeight > verticalBar.Height)
            {
                verticalBar.Visible = true;
                verticalBar.Maximum = neededHeight - verticalBar.Height;
                verticalBar.Scroll += (xx, yy) => this.panel.Top = -verticalBar.Value;
            }
            else
                verticalBar.Visible = false;
        }
    }
}
