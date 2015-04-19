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
    public partial class HomePageWithMap : Menu
    {
        private Pointable[] examples = new Pointable[]{
            new ShopExample(0,0,"KFC", "Fried chicken"),
            new ShopExample(100,100,"MC Donalds", "Fast Food"),
            new ShopExample(200,200,"Doctor", "Fast and Easy doctor repairs")
        };

        protected override List<Control> Inherited
        {
            get
            {
                List<Control> result = base.Inherited;
                result.Add(mapBtn);
                return result;
            }
        }

        private Point dragOffset;
        private Point mouseDragStartLocation;

        float zoom = 1;
        float wantedZoom = 1;
        private bool mapDragging = false;

        private void SetParent(Control a, Control b)
        {
            a.Left = a.Left - b.Left;
            a.Top = a.Top - b.Top;
            a.Parent = b;
        }

        public HomePageWithMap()
        {
            InitializeComponent();

            int mapX = mapArea.Left;
            int mapY = mapArea.Top;

            mapArea.Image = Properties.Resources.Park_English;
            PictureBox holder = new PictureBox();
            holder.Size = new Size(mapArea.Size.Width, mapArea.Size.Height);

            holder.Left = mapX - pictureBox10.Left + 2;
            holder.Top = mapY - 3;
            mapArea.Parent.Controls.Add(holder);
            mapArea.Parent = holder;
            mapArea.Left = 0;
            mapArea.Top = 0;

            holder.Parent = pictureBox10;

            SetParent(ZoomInBtn, pictureBox10);
            SetParent(zoomOutBtn, pictureBox10);
            SetParent(zoomTb, pictureBox10);
            SetParent(findByNameLbl, pictureBox10);
            SetParent(findByNameTb, pictureBox10);
            SetParent(findByTypeLbl, pictureBox10);
            SetParent(findByTypeTb, pictureBox10);

            holder.BringToFront();
            mapArea.BringToFront();
            foreach (Pointable pointable in examples)
                pointable.AddToMap(mapArea);

            mapArea.MouseDown += (x, mouse) =>
            {
                if (mapDragging) return;
                this.Cursor = Cursors.Cross;
                this.mapDragging = true;
                mouseDragStartLocation = mouse.Location;
            };

            mapArea.MouseUp += (x, mouse) =>
            {
                if (!mapDragging) return;

                mapDragging = false;
                this.Cursor = Cursors.Default;
                mapArea.Location = dragOffset;
                holder.Refresh();
            };

            mapArea.MouseMove += (sender, mouse) =>
            {
                if (!mapDragging) return;

                if (mouse.Location == mouseDragStartLocation)
                    return;
                Point delta = new Point(mouse.Location.X - mouseDragStartLocation.X, mouse.Location.Y - mouseDragStartLocation.Y);
                Point previous = dragOffset;
                dragOffset = new Point(dragOffset.X + delta.X, dragOffset.Y + delta.Y);

                float minimumArea = 64;

                if (
                    (dragOffset.X < -mapArea.Width + minimumArea || dragOffset.Y < -mapArea.Height + minimumArea) ||
                    (dragOffset.X > holder.Width - minimumArea || dragOffset.Y > holder.Height - minimumArea)
                    )
                {
                    dragOffset = previous;
                    return;
                }
                mapArea.Location = dragOffset;
                holder.Refresh();
            };

            zoomOutBtn.Click += (x, y) => ChangeZoom(-.1f);
            ZoomInBtn.Click += (x, y) => ChangeZoom(.1f);

            zoomTb.Text = "100%";

            AddAutoCompleteTo(zoomTb, 
                (e) =>
                {
                    if (e.KeyChar > '9' || e.KeyChar < '0')
                    {
                        if (e.KeyChar != (char)13 && e.KeyChar != '.' && e.KeyChar != '\b')
                            e.KeyChar = '\0';
                        if (e.KeyChar == '.')
                            if (zoomTb.Text.Contains('.'))
                                e.KeyChar = '\0';
                    }
                    if (e.KeyChar == (char)Keys.Return) // enter
                    {
                        OnAutoComplete[zoomTb].Action(zoomTb.Text);
                        e.KeyChar = '\0';
                    }
                },
                (selection) =>
                {
                    SetZoom(float.Parse(selection.ToString().Replace("%","")) / 100);
                });

            var pointableTypes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes().
                Where(x => x.IsSubclassOf(typeof(Pointable)));

            findByTypeTb.AutoCompleteCustomSource.Add("All");

            findByTypeTb.AutoCompleteCustomSource.AddRange(
                pointableTypes.Select(x=>x.Name).ToArray()
            );

            AddAutoCompleteTo(findByTypeTb, 
                (e) => 
                {
                    if (e.KeyChar == (char)Keys.Return)
                    {
                        SetNameSearchCollection(findByTypeTb.Text);
                        e.KeyChar = '\0';
                    }
                },(selection) => SetNameSearchCollection(selection.ToString()));

            AddAutoCompleteTo(findByNameTb, 
                (e) =>
                {
                    if (e.KeyChar == (char)Keys.Return)
                    {
                        ShowItemsOnMap(findByTypeTb.Text, findByNameTb.Text);
                        e.KeyChar = '\0';
                    }
                }, (selection) => ShowItemsOnMap(findByTypeTb.Text, selection.ToString()));

            findByTypeTb.Text = "All";
            SetNameSearchCollection("All");

            
        }

        protected override void OnSet(Menu menu)
        {
            if (menu == this)
            {
                if (pictureBox10.Visible)
                {
                    MainMenu.Width -= pictureBox10.Width;
                    pictureBox10.Visible = false;
                }
            }
        }

        private void AddAutoCompleteTo(TextBox tb, Action<KeyPressEventArgs> onKeyPress, Action<object> onSelected)
        {
            tb.Multiline = true;
            tb.AcceptsReturn = true;
            tb.AutoCompleteMode = AutoCompleteMode.Suggest;
            tb.AutoCompleteSource = AutoCompleteSource.CustomSource;

            OnAutoComplete.Add(tb, new AutoCompleteData(onSelected));
            tb.KeyPress += (x, e) => onKeyPress(e);
            tb.KeyUp += AutoComplete;
        }

        private Dictionary<TextBox, AutoCompleteData> OnAutoComplete = new Dictionary<TextBox, AutoCompleteData>();

        class AutoCompleteData
        {
            public ListBox ListBox;
            public Action<object> Action;

            public AutoCompleteData(Action<object> action)
            {
                this.Action = action;
            }

            public void Invoke() { this.Action(ListBox.SelectedItem); }
        }

        private void AutoComplete(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ListBox listBox = null;
            string[] items = new string[textBox.AutoCompleteCustomSource.Count];
            textBox.AutoCompleteCustomSource.CopyTo(items, 0);

            if (OnAutoComplete[textBox].ListBox == null)
            {
                listBox = new ListBox();
                listBox.Top = textBox.Height + textBox.Top;
                listBox.Left = textBox.Left;
                listBox.Width = textBox.Width;
                listBox.IntegralHeight = false;
                listBox.Sorted = false;

                listBox.SelectedIndexChanged += (x, y) =>
                {
                    if (listBox.SelectedIndex != -1)
                    {
                        OnAutoComplete[textBox].Invoke();
                        textBox.Text = listBox.SelectedItem.ToString();
                    }
                };

                this.Controls.Add(listBox);

                listBox.BringToFront();
                OnAutoComplete[textBox].ListBox = listBox;
                OnAutoComplete[textBox].Action += (x) => listBox.Visible = false;
            }
            else
                listBox = OnAutoComplete[textBox].ListBox;

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

        private void SetZoom(float amount)
        {
            float delta = amount - wantedZoom;
            ChangeZoom(delta);
        }

        private void ResetZoom()
        {
            SetZoom(1);
        }

        private void ChangeZoom(float amount)
        {
            if (wantedZoom + amount < 1) return;
            //example : change from 1.1 to 1.2
            float target = wantedZoom + amount; //1.2
            float current = zoom; // 1.1
            float difference = target / current; // 1.1 * ? = 1.2

            zoom *= difference;
            wantedZoom += amount;

            mapArea.Scale(new SizeF(difference, difference));

            mapArea.Location = dragOffset;

            zoomTb.Text = (wantedZoom * 100) + "%";
        }

        private void SetNameSearchCollection(string type)
        {
            findByNameTb.AutoCompleteCustomSource.Clear();
            ShowItemsOnMap(type);
        }

        private void ShowItemsOnMap(string type, string label = "")
        {
            IEnumerable<Pointable> collection = new Pointable[0];
            type = type.ToLower();
            label = label.ToLower();
            if (type == "all")
                if (label == "")
                    collection = examples;
                else
                    collection = (examples.Where(x => x.Label.ToLower() == label));
            else
                if (type == "none")
                {
                    foreach (var item in examples)
                        item.HideInMap();
                    return;
                }
                else
                    if (label == "")
                        collection = examples.Where(x => x.GetType().Name.ToLower() == type);
                    else
                        collection = examples.Where(x => x.GetType().Name.ToLower() == type && x.Label.ToLower() == label);

            ShowItemsOnMap("none");
            foreach (var item in collection)
            {
                item.ShowInMap();
                findByNameTb.AutoCompleteCustomSource.Add(item.Label);
            }
        }

        private void ZoomToItems(params Pointable[] items)
        {
            ZoomToItems(items);
        }

        private void ZoomToItems(IEnumerable<Pointable> items)
        {
            ResetZoom();

            Pointable first = items.FirstOrDefault();
            if (first == null) return;

            int left = first.X;
            int right = first.X;
            int top = first.Y;
            int bottom = first.Y;

            foreach (Pointable item in items)
            {
                item.ShowInMap();
                if (item.X < left) left = item.X;
                else if (item.X > right) right = item.X;

                if (item.Y < top) top = item.Y;
                else if (item.Y > bottom) bottom = item.Y;
            }

            float width = right - left + Pointable.IconSize;
            float height = bottom - top + Pointable.IconSize;

            dragOffset = new Point(left, top);

            float deltaZoomWidth = mapArea.Width / width;
            float deltaZoomHeight = mapArea.Height / height;
            float deltaZoom = deltaZoomWidth > deltaZoomHeight ? deltaZoomWidth : deltaZoomHeight;

            ChangeZoom(deltaZoom - 1);
        }

        private void ToggleMap()
        {
            MainMenu.Width += pictureBox10.Width * (pictureBox10.Visible ? -1 : 1);
            pictureBox10.Visible = !pictureBox10.Visible;
        }

        private void mapBtn_Click(object sender, EventArgs e)
        {
            ToggleMap();
        }
    }
}
