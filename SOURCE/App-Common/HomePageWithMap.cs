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
    public partial class HomePageWithMap : HomePage
    {
        private MapPoint[] points = new MapPoint[]{
        };

        Dictionary<Control, Control> fixedChildren = new Dictionary<Control, Control>();

        private void FixChild(Control control)
        {
            fixedChildren.Add(control, control.Parent);
            this.Controls.Add(control);
        }

        //Fix for issue with inheritance between controls ( my child is not actually mine, but the main menu's )
        protected void Fix()
        {
            FixChild(this.findByNameLbl);
            FixChild(this.findByTypeTb);
            FixChild(this.findByTypeLbl);
            FixChild(this.findByNameTb);
        }

        protected void Unfix()
        {
            foreach (var item in fixedChildren)
                item.Key.Parent = item.Value;
            fixedChildren.Clear();
        }

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

        public HomePageWithMap() { InitializeComponent(); }

        public HomePageWithMap(App_Common.Menu parent)
            : base(parent)
        {
            InitializeComponent();

            int mapX = mapArea.Left;
            int mapY = mapArea.Top;

            mapArea.Image = global::App_Common.Properties.Resources.Park_English;
            PictureBox holder = new PictureBox();
            holder.Size = new Size(mapArea.Size.Width, mapArea.Size.Height);

            holder.Left = mapX;
            holder.Top = mapY;
            this.Controls.Add(holder);

            SetParent(holder, mapHolder);

            SetParent(ZoomInBtn, mapHolder);
            SetParent(zoomOutBtn, mapHolder);
            SetParent(zoomTb, mapHolder);
            SetParent(zoomOnItemsBtn, mapHolder);
            SetParent(resetZoomBtn, mapHolder);
            SetParent(findByNameLbl, mapHolder);
            SetParent(findByNameTb, mapHolder);
            SetParent(findByTypeLbl, mapHolder);
            SetParent(findByTypeTb, mapHolder);

            mapArea.Parent = holder;
            mapArea.Left = 0;
            mapArea.Top = 0;

            holder.BringToFront();
            mapArea.BringToFront();
            foreach (MapPoint pointable in points)
                pointable.AddToMap(mapArea);

            mapArea.MouseDown += (x, mouse) =>
            {
                if (mapDragging) return;

                this.mapDragging = true;

                MainMenu.Cursor = Cursors.Cross;
                mouseDragStartLocation = mouse.Location;
            };

            mapArea.MouseUp += (x, mouse) =>
            {
                if (!mapDragging) return;

                mapDragging = false;
                MainMenu.Cursor = Cursors.Default;
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
                    SetZoom(float.Parse(selection.ToString().Replace("%", "")) / 100);
                });

            //var pointableTypes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes().
            //    Where(x => x.IsSubclassOf(typeof(Classes.Landmark)));

            findByTypeTb.AutoCompleteCustomSource.Add("All");

            findByTypeTb.AutoCompleteCustomSource.AddRange(Enum.GetNames(typeof(LandmarkType)).Select(x=>x.Replace("_"," ")).ToArray());

            AddAutoCompleteTo(findByTypeTb,
                (e) =>
                {
                    if (e.KeyChar == (char)Keys.Return)
                    {
                        SetNameSearchCollection(findByTypeTb.Text);
                        e.KeyChar = '\0';
                    }
                }, (selection) => SetNameSearchCollection(selection.ToString()));

            AddAutoCompleteTo(findByNameTb,
                (e) =>
                {
                    if (e.KeyChar == (char)Keys.Return)
                    {
                        SetMapItems(findByTypeTb.Text, findByNameTb.Text);
                        e.KeyChar = '\0';
                    }
                }, (selection) => SetMapItems(findByTypeTb.Text, selection.ToString()));

            zoomTb.Text = "100%";

            findByTypeTb.Text = "All";
            SetNameSearchCollection("All");

            resetZoomBtn.Visible = false;
        }

        protected override void OnSet()
        {
            base.OnSet();
            foreach (var item in this.OnAutoComplete)
                item.Value.ListBox.Visible = false;
            if (mapHolder.Visible)
            {
                MainMenu.Width -= mapHolder.Width;
                mapHolder.Visible = false;
            }
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
            if (wantedZoom + amount < 1) amount = 1 - wantedZoom;
            if (amount == 0) return;

            //example : change from 1.1 to 1.2
            float target = wantedZoom + amount; //1.2
            float current = zoom; // 1.1
            float difference = target / current; // 1.1 * ? = 1.2

            zoom *= difference;

            if (wantedZoom == 1) resetZoomBtn.Visible = true;
            wantedZoom += amount;

            mapArea.Scale(new SizeF(difference, difference));

            mapArea.Location = dragOffset;

            zoomTb.Text = (wantedZoom * 100) + "%";


            if (wantedZoom == 1) resetZoomBtn.Visible = false;
        }

        private void SetNameSearchCollection(string type)
        {
            findByNameTb.AutoCompleteCustomSource.Clear();
            SetMapItems(type);
        }

        protected void SetMapItems(IEnumerable<Classes.Landmark> items)
        {
            foreach (var item in this.points)
                item.Clear();

            this.points = items.Select(x => new MapPoint(x)).ToArray();
            this.findByTypeTb.AutoCompleteCustomSource.Clear();
            this.findByTypeTb.AutoCompleteCustomSource.AddRange(this.points.Select(x => x.Type.ToString()).Distinct().ToArray());

            foreach (var item in this.points)
                item.AddToMap(this.mapArea);
        }

        private void SetMapItems(string type, string label = "")
        {
            IEnumerable<MapPoint> collection = new MapPoint[0];
            type = type.ToLower();
            if (type == "none")
            {
                foreach (var item in points)
                    item.HideInMap();
                return;
            }
            else
                collection = GetVisibleItemsOnMap(type, label);

            SetMapItems("none");
            foreach (var item in collection)
            {
                item.ShowInMap();
                findByNameTb.AutoCompleteCustomSource.Add(item.Label);
            }
        }

        private void ZoomToItems(params MapPoint[] items)
        {
            ZoomToItems(items);
        }

        private IEnumerable<MapPoint> GetVisibleItemsOnMap(string type, string label)
        {
            type = type.ToLower();
            label = label.ToLower();
            IEnumerable<MapPoint> collection = new MapPoint[0];
            if (type == "all")
                if (label == "")
                    collection = points;
                else
                    collection = (points.Where(x => x.Label.ToLower() == label));
            else
                if (type != "none")
                    if (label == "")
                        collection = points.Where(x => x.Type.ToString().ToLower() == type);
                    else
                        collection = points.Where(x => x.Type.ToString().ToLower() == type && x.Label.ToLower() == label);
            return collection;
        }

        private void ZoomToItems(IEnumerable<MapPoint> items)
        {
            ResetZoom();

            MapPoint first = items.FirstOrDefault();
            if (first == null) return;

            int left = first.X;
            int right = first.X;
            int top = first.Y;
            int bottom = first.Y;

            foreach (MapPoint item in items)
            {
                item.ShowInMap();
                if (item.X < left) left = item.X;
                else if (item.X > right) right = item.X;

                if (item.Y < top) top = item.Y;
                else if (item.Y > bottom) bottom = item.Y;
            }

            float width = right - left + MapPoint.IconSize;
            float height = bottom - top + MapPoint.IconSize;

            dragOffset = new Point(left, top);

            float deltaZoomWidth = mapArea.Width / width;
            float deltaZoomHeight = mapArea.Height / height;
            float deltaZoom = deltaZoomWidth > deltaZoomHeight ? deltaZoomWidth : deltaZoomHeight;

            ChangeZoom(deltaZoom - 1);
        }

        protected virtual void OnTogglingMap(bool state)
        {
            if (state)
            {
                int sum = mapHolder.Height + mapHolder.Top;
                if (MainMenu.Height < sum)
                    MainMenu.Height = sum;
            }
        }

        private void ToggleMap()
        {
            mapHolder.Visible = !mapHolder.Visible;
            OnTogglingMap(mapHolder.Visible);

            MainMenu.Width += mapHolder.Width * (mapHolder.Visible ? 1 : -1);
        }

        private void mapBtn_Click(object sender, EventArgs e)
        {
            ToggleMap();
        }

        public void SelectItem(Classes.Landmark landmark)
        {
            foreach (MapPoint point in this.points)
                point.Deselect();
            foreach (MapPoint point in this.points)
            {
                if (point == landmark)
                {
                    point.Select();
                    return;
                }
            }
        }

        private void zoomOnItemsBtn_Click(object sender, EventArgs e)
        {
            if (points.Length == 0) return;
            string type = findByTypeTb.Text;
            string label = findByNameTb.Text;
            SetMapItems(type, label);
            ZoomToItems(GetVisibleItemsOnMap(type, label));
        }

        private void resetZoomBtn_Click(object sender, EventArgs e)
        {
            ResetZoom();
        }

        private void ZoomInBtn_Click(object sender, EventArgs e)
        {
            ChangeZoom(wantedZoom * 0.1f);
        }

        private void zoomOutBtn_Click(object sender, EventArgs e)
        {
            ChangeZoom(wantedZoom * -0.1f);
        }

        private void mapHolder_Click(object sender, EventArgs e)
        {

        }
    }
}
