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
    public partial class Menu : Form
    {
        private static Menu MainMenu;
        private static List<Menu> Menus = new List<Menu>();

        private List<Control> DynamicControls = null;

        public Menu()
        {
            InitializeComponent();
        }

        public void SetAsActive()
        {
            ChangeMenuTo(this);
        }

        protected virtual void OnClear() { }
        protected virtual void OnSet() { }

        private void Clear()
        {
            foreach (Control control in this.dynamicContainer.Controls)
                control.Visible = false;

            OnClear();
        }

        private void Set(Menu menu)
        {
            foreach (Control control in menu.DynamicControls)
            {
                Control found = null;
                foreach (Control toShow in this.dynamicContainer.Controls)
                {
                    if (Object.ReferenceEquals(control,toShow))
                    {
                        found = toShow;
                        break;
                    }
                }

                if (found == null)
                    this.dynamicContainer.Controls.Add(control);
                else
                    found.Visible = true;
            }
            OnSet();
        }

        private static void ChangeMenuTo(Menu menu)
        {
            if (menu.DynamicControls == null)
            {
                menu.DynamicControls = new List<Control>();
                foreach (Control control in menu.dynamicContainer.Controls)
                    menu.DynamicControls.Add(control);
            }

            Menu found = Menus.Find(x => x.GetType() == menu.GetType());
            if (found == null)
            {
                Menus.Add(menu);
                found = menu;
            }
            if (MainMenu == null)
            {
                MainMenu = found;
                MainMenu.Show();
            }
            else
            {
                MainMenu.Clear();
                MainMenu.Set(found);
            }
        }
    }
}
