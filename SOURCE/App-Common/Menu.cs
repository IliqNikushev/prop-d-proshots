using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Common
{
    public partial class Menu : Form
    {
        public static bool IsInDebug
        {
            get
            {
               return System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv";
            }
        }

        protected static Classes.User LoggedInUser { get; set; }
        protected static Classes.Visitor LoggedInVisitor { get { return LoggedInUser as Classes.Visitor; } }
        protected static Classes.Employee LoggedInEmployee { get { return LoggedInUser as Classes.Employee; } }

        protected static Menu MainMenu;
        private static List<Menu> Menus = new List<Menu>();
        private Menu ParentMenu;
        private List<Control> controls = null;

        protected Classes.RFID reader;

        protected virtual List<Control> Inherited
        {
            get
            {
                return new List<Control>();
            }
        }

        public Menu() : this(null)
        {
            if (!IsInDebug)
                throw new InvalidOperationException("ALLOWED ONLY DURING DEBUG"); // call the other menu constructor
            InitializeComponent();
        }

        public Menu(Menu parent)
        {
            if (MainMenu == null)
            {
                if (!IsInDebug)
                {
                    reader = new Classes.RFID();
                    reader.OnAttach += (x) => { };
                    reader.OnDetach += (x) => { };
                    reader.OnDetect += (x) => MessageBox.Show("RFID found," + x);
                    reader.OnDetectEnd += (x) => MessageBox.Show("RFID lost, " + x);
                    reader.OnError += (x) => MessageBox.Show("RFID ERROR, " + x.Description);

                    reader.OnAttach += (x) => reader.ToggleLED();

                    this.FormClosed += (x, y) => { MainMenu = null; reader.Dispose(); };
                    this.Disposed += (x, y) => Menus.Clear();
                }
            }
            else
                this.FormClosed += (x, y) =>
                {
                    if (this == MainMenu) return;
                    if (this.ParentMenu == null) return;
                    this.ParentMenu.Show();
                };
            
            InitializeComponent();

            this.ControlBox = false;

            this.ParentMenu = parent;
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
                control.Visible = true;
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
