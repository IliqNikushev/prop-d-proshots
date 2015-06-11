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
        public event Action OnActivityLost = () => { };

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

        private int defaultHeight = 0;
        private int defaultWidth = 0;

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
                    //reader.OnDetect += (x) => MessageBox.Show("RFID found," + x);
                    //reader.OnDetectEnd += (x) => MessageBox.Show("RFID lost, " + x);
                    reader.OnError += (x) => {
                        Classes.Record result = new Classes.Warning("RFID", x.Description).Create(); 
                        if (result)
                            MessageBox.Show("Reader encountered an error. The error has been logged."); 
                        else
                            MessageBox.Show("Reader encountered an error. The error was not able to be logged."); 
                        };
                    Classes.Database.OnUnableToProcessSQL += (ex, sql) =>
                    {
                        new Classes.Warning("SQL error", ex.GetType() + "\n" + ex.Message + "\n" + sql).Create();
                        MessageBox.Show("There was an issue while using the database.");
                    };
                    reader.OnAttach += (x) => reader.ToggleLED();

                    this.FormClosed += (x, y) => 
                    {
                        MainMenu = null;
                        reader.Dispose();
                    };
                    this.Disposed += (x, y) => Menus.Clear();
                }
            }

            this.controls = new List<Control>();

            this.ControlAdded += (x, y) =>
            {
                if (IsRendering && this != MainMenu)
                {
                    MainMenu.Controls.Add(y.Control);
                    this.OnActivityLost += () => MainMenu.Controls.Remove(y.Control);
                }
                else
                    if (!this.controls.Contains(y.Control))
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

        protected virtual void Reset()
        {
        }

        new public void Show()
        {
            Reset();

            if (this == MainMenu)
            {
                this.IsRendering = true;
                base.Show();
            }
            else
                SetAsActive();
        }

        new public void Close()
        {
            if (this != MainMenu)
            {
                this.IsRendering = false;
                this.ParentMenu.SetAsActive();
                this.ParentMenu.Width = this.ParentMenu.defaultWidth;
                this.ParentMenu.Height = this.ParentMenu.defaultHeight;
                this.ParentMenu.Reset();

                if (ParentMenu is LoginForm)
                {
                    LoggedInUser.Logout();
                    LoggedInUser = null;
                }
            }
            else
                base.Close();
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
            if (this.defaultWidth == 0)
            {
                this.defaultHeight = this.Height;
                this.defaultWidth = this.Width;
            }
            if (menu.defaultWidth == 0)
            {
                menu.defaultHeight = menu.Height;
                menu.defaultWidth = menu.Width;
            }

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
            if (ActiveMenu != null)
            {
                ActiveMenu.IsRendering = false;
                ActiveMenu.OnActivityLost();
            }
            ActiveMenu = menu;
            menu.IsRendering = true;

            MainMenu.Clear();
            MainMenu.Set(menu);
        }
    }
}
