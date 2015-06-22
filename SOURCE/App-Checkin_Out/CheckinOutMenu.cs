using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Checkin_Out
{
    public partial class CheckinOutMenu : App_Common.Menu
    {
        object locker = new object();
        public CheckinOutMenu(App_Common.Menu parent) : base(parent)
        {
            InitializeComponent();
            reader.OnDetect += reader_OnDetect;
        }

        static bool working = false;

        System.Threading.Thread thread;

        void reader_OnDetect(string tag)
        {
            if (thread != null)
                if (thread.IsAlive)
                    thread.Abort();
            statePbox.Image = Properties.Resources.Waiting;

            Classes.Visitor visitor = Classes.Visitor.Authenticate(tag);
            if (visitor)
            {
                if (visitor.IsInTheEvent)
                {
                    visitor.CheckOut();
                    statePbox.Image = Properties.Resources.Yes_bye;
                }
                else
                {
                    visitor.CheckIn();
                    statePbox.Image = Properties.Resources.Ok;
                }
                System.Media.SystemSounds.Beep.Play();
            }
            else
            {
                if (Classes.Database.CanConnect)
                    statePbox.Image = Properties.Resources.Error;
                else
                    statePbox.Image = Properties.Resources.Error404;
                System.Media.SystemSounds.Beep.Play();
                System.Media.SystemSounds.Beep.Play();
            }
            try
            {
                if (thread != null)
                    if (thread.IsAlive)
                        thread.Abort();
                thread = new System.Threading.Thread(
                    () =>
                    {
                        System.Threading.Thread.Sleep(2000);
                        this.Invoke(new Action(() => this.statePbox.Image = Properties.Resources.Idle));
                    });
                thread.Start();
            }
            catch { }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lock (locker)
            {
                statePbox.Image = Properties.Resources.Idle;
                timer.Enabled = false;
            }
        }
    }
}
