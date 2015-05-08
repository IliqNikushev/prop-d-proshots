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
        protected static Classes.User LoggedInUser = null;

        protected static Menu MainMenu;
        private static List<Menu> Menus = new List<Menu>();

        private List<Control> controls = null;

        protected virtual List<Control> Inherited
        {
            get
            {
                return new List<Control>();
            }
        }

        public Menu()
        {
            if (MainMenu == null)
            {
                if (Classes.Database.CanConnect)
                {
                    Classes.Database.CheckConsistency();
                    if (Classes.Database.consistencyExceptions.Count > 0)
                        LogException(new Exception(), string.Join("\n", Classes.Database.consistencyExceptions));
                    if (Classes.Database.OnUnableToProcessSQL == null)
                        Classes.Database.OnUnableToProcessSQL = LogException;
                }
            }
            
            InitializeComponent();

            this.FormClosed += (x, y) => MainMenu = null;
            this.Disposed += (x, y) => Menus.Clear();
        }

        private void LogException(Exception ex, string sql)
        {
            string message = "";
            if (Classes.Database.CanConnect)
            {
                //process exception type and message -> what is the issue
                message = ex.GetType().Name.Replace("Exception", "\n") + ex.Message;
            }
            else
                message = "Unable to connect to the database";
            MessageBox.Show(message +"\n"+sql);
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

        private void Clear()
        {
            foreach (Control control in this.controls)
                    control.Visible = false;
            foreach (Control control in this.Inherited)
            {
                control.Visible = true;
            }
            this.Controls.Clear();
        }

        protected virtual void OnSet() { }

        private void Set(Menu menu)
        {
            this.controls = menu.controls;
            foreach (Control control in this.controls)
            {
                control.Visible = true;
                this.Controls.Add(control);
            }

            this.Width = menu.Width;
            this.Height = menu.Height;

            menu.OnSet();
        }

        private static void ChangeMenuTo(Menu menu)
        {
            if (menu.controls == null)
            {
                menu.controls = new List<Control>();
                foreach (Control control in menu.Controls)
                    menu.controls.Add(control);
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
