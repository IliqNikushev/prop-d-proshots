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
        protected static Menu ActiveMenu;
        private static List<Menu> Menus = new List<Menu>();
        private Menu ParentMenu;
        private List<Control> controls = null;
        private List<Control> enlisted = new List<Control>();

        public void Enlist(Control c) { this.enlisted.Add(c); }

        protected static Classes.RFID reader;

        private bool IsRendering = false;

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
                MainMenu = this;
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

            this.controls = new List<Control>();

            this.ControlAdded += (x, y) =>
            {
                if (IsRendering)
                    MainMenu.Controls.Add(y.Control);
                else
                    this.controls.Add(y.Control);
            };

            this.ControlRemoved += (x, y) =>
            {
                if (IsRendering)
                    MainMenu.Controls.Remove(y.Control);
                else
                    this.controls.Remove(y.Control);
            };
            
            InitializeComponent();

            this.ControlBox = false;

            this.ParentMenu = parent;
        }

        new public void Show()
        {
            if (this == MainMenu)
            {
                this.IsRendering = true;
                base.Show();
            }
            else
                SetAsActive();
        }

        public void SetAsActive()
        {
            ChangeMenuTo(this);
        }

        private void Clear()
        {
            List<Control> c = new List<Control>(this.controls);
            this.Controls.Clear();
            this.controls = c;
        }

        protected virtual void OnSet() { }

        private void Set(Menu menu)
        {
            List<Control> controls = new List<Control>(menu.controls);
            List<Control> current = new List<Control>(this.controls);
            foreach (var item in controls)
                this.Controls.Add(item);
            this.controls = current;

            this.Width = menu.Width;
            this.Height = menu.Height;
            this.Text = menu.Text;
            menu.OnSet();
        }

        private static void ChangeMenuTo(Menu menu)
        {
            if (ActiveMenu != null) ActiveMenu.IsRendering = false;
            ActiveMenu = menu;
            menu.IsRendering = true;
            Menu found = Menus.Find(x => x.GetType() == menu.GetType());

            if (found == null)
            {
                Menus.Add(menu);
                found = menu;
            }

            MainMenu.Clear();
            MainMenu.Set(found);
        }
    }
}
