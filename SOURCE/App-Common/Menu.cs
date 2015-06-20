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

        private static int exceptionCounter = 0;
        private static bool exceptionBlocker = false;

        /// <summary>
        /// prevents at the rent form when the comfirm button is clicked multiple time seeing there is an error
        /// </summary>
        protected static void BlockExceptions()
        {
            exceptionCounter = 0;
            exceptionBlocker = true;
        }

        protected static void UnBlockExceptions()
        {
            exceptionCounter = 0;
            exceptionBlocker = false;
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
                        if (exceptionBlocker)
                        {
                            if (exceptionCounter++ == 0)
                                MessageBox.Show("There was an issue while using the database.");
                        }
                        else
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

            //this.ControlBox = false;

            this.ParentMenu = parent;

            this.Icon = Properties.Resources.Icon;
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

        protected void AddAutoCompleteTo(TextBox tb, Action<KeyPressEventArgs> onKeyPress, Action<object> onSelected)
        {
            tb.WordWrap = false;
            tb.Multiline = true;
            tb.AcceptsReturn = true;
            tb.AutoCompleteMode = AutoCompleteMode.None;
            tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            OnAutoComplete.Add(tb, new AutoCompleteData(onSelected));
            ListBox listBox = OnAutoComplete[tb].ListBox;
            listBox.Visible = false;
            this.Controls.Add(listBox);
            int yy = tb.Top + tb.Height + 10;
            int xx = tb.Left;

            Control c = tb.Parent;
            while (!c.GetType().IsSubclassOf(typeof(Form)))
            {
                if (c.GetType() == typeof(Form)) break;
                yy += c.Top;
                xx += c.Left;
                c = c.Parent;
            }
            listBox.Top = yy;
            listBox.Left = xx;
            listBox.Width = tb.Width;
            listBox.IntegralHeight = false;
            listBox.Sorted = false;

            listBox.SelectedIndexChanged += (x, y) =>
            {
                if (listBox.SelectedIndex != -1)
                {
                    OnAutoComplete[tb].Invoke();
                    tb.Text = listBox.SelectedItem.ToString();
                    listBox.Visible = false;
                }
            };

            listBox.BringToFront();

            tb.KeyPress += (x, e) => onKeyPress(e);
            tb.KeyUp += AutoComplete;

            //tb.LostFocus += (x, y) => listBox.Visible = false;
        }

        protected Dictionary<TextBox, AutoCompleteData> OnAutoComplete = new Dictionary<TextBox, AutoCompleteData>();

        protected class AutoCompleteData
        {
            public bool IsInitialized { get; private set; }
            public ListBox ListBox;
            public Action<object> Action;

            public AutoCompleteData(Action<object> action)
            {
                this.Action = action;
                this.ListBox = new ListBox();
            }

            public void Invoke() { this.Action(ListBox.SelectedItem); }
        }

        private void AutoComplete(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ListBox listBox = OnAutoComplete[textBox].ListBox;
            if (e.KeyCode == Keys.Return) { listBox.Visible = false; return; }
            string[] items = new string[textBox.AutoCompleteCustomSource.Count];
            textBox.AutoCompleteCustomSource.CopyTo(items, 0);

            string text = textBox.Text.ToLower();
            IEnumerable<string> localList = items.Where(x => x.ToLower().StartsWith(text) || x.ToLower().Contains(text));
            if (localList.Any())
            {
                listBox.Items.Clear();
                foreach (var item in localList.OrderByDescending(x => x.ToLower().StartsWith(text)))
                    if (!listBox.Items.Contains(item))
                        listBox.Items.Add(item);

                listBox.Visible = true;
                listBox.SelectedIndex = -1;

                listBox.Height = (listBox.ItemHeight + 3) * (listBox.Items.Count > 4 ? 4 : listBox.Items.Count);
                this.Refresh();
            }
            else
                listBox.Visible = false;
        }
    }
}
