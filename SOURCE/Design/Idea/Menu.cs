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
    public partial class Menu : Form
    {
        protected static Menu MainMenu;
        private static List<Menu> Menus = new List<Menu>();

        private List<Control> dynamicControls = null;
        private List<Control> topNavControls = new List<Control>();

        protected virtual List<Control> Inherited
        {
            get
            {
                return new List<Control>();
            }
        }

        public Menu()
        {
            InitializeComponent();

            this.FormClosed += (x, y) => MainMenu = null;
            this.Disposed += (x, y) => Menus.Remove(this);
        }

        new public void Show()
        {
            if (this == MainMenu)
                base.Show();
            else
                SetAsActive();
        }

        public void SetAsActive()
        {
            ChangeMenuTo(this);
        }

        private void Clear(Control contrainer)
        {
            foreach (Control control in contrainer.Controls)
                if (this.Inherited.Contains(control))
                    continue;
                else
                    control.Visible = false;
        }

        private void Set(Control container, Control targetContainer, List<Control> controls, List<Control> targetControls)
        {
            foreach (Control control in targetControls)
            {
                Control found = null;
                foreach (Control toShow in controls)
                {
                    if (Object.ReferenceEquals(control, toShow))
                    {
                        found = toShow;
                        break;
                    }
                }

                if (found == null)
                    container.Controls.Add(control);
                else
                    found.Visible = true;
            }

            container.Width = targetContainer.Width;
            container.Height = targetContainer.Height;
            container.Left = targetContainer.Left;
            container.Top = targetContainer.Top;
        }

        private void Clear()
        {
            Clear(this.dynamicContainer);
            Clear(this.topNavContainer);
        }

        protected virtual void OnSet() { }

        private void Set(Menu menu)
        {
            Set(this.dynamicContainer, menu.dynamicContainer, this.dynamicControls, menu.dynamicControls);
            Set(this.topNavContainer, menu.topNavContainer, this.topNavControls, menu.topNavControls);

            this.Width = menu.Width;
            this.Height = menu.Height;

            menu.OnSet();
        }

        private static bool IsIn(Control control, Control contrainer)
        {
            return
                (
                control.Left >= contrainer.Left && control.Top >= contrainer.Top &&
                control.Left <= contrainer.Left + contrainer.Width && control.Top <= contrainer.Top + contrainer.Height
                ) ||
                (
                control.Left + control.Width >= contrainer.Left && control.Left + control.Width <= contrainer.Left + contrainer.Width &&
                control.Top + control.Height >= contrainer.Top && control.Top + control.Height <= contrainer.Top + contrainer.Height
                );
        }

        private static void ChangeMenuTo(Menu menu)
        {
            if (menu.dynamicControls == null)
            {
                foreach (Control control in menu.Controls)
                {
                    if (control == menu.dynamicContainer) continue;
                    if (control == menu.topNavContainer) continue;
                    Control parent = control.Parent;
                    while (parent != null)
                    {
                        if (parent == menu.dynamicContainer) break;
                        parent = parent.Parent;
                    }
                    if (parent == menu.dynamicContainer) continue;
                    bool added = true;

                    if (IsIn(control, menu.dynamicContainer))
                        menu.dynamicContainer.Controls.Add(control);
                    else if (IsIn(control, menu.topNavContainer))
                        menu.topNavContainer.Controls.Add(control);
                    else
                        added = false;

                    if (added)
                    {
                        control.Left -= menu.dynamicContainer.Left;
                        control.Top -= menu.dynamicContainer.Top;
                    }
                }

                menu.dynamicControls = new List<Control>();
                menu.topNavControls = new List<Control>();
                foreach (Control control in menu.dynamicContainer.Controls)
                    menu.dynamicControls.Add(control);
                foreach (Control control in menu.topNavContainer.Controls)
                    menu.topNavControls.Add(control);
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
