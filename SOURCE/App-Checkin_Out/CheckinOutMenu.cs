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
        public CheckinOutMenu(App_Common.Menu parent) : base(parent)
        {
            InitializeComponent();

            reader.OnDetect += reader_OnDetect;
        }

        void reader_OnDetect(string tag)
        {
            this.timer.Stop();
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
                this.timer.Start();
            }
            else
            {
                if (Classes.Database.CanConnect)
                    statePbox.Image = Properties.Resources.Error;
                else
                    statePbox.Image = Properties.Resources.Error404;
                this.timer.Start();
                System.Media.SystemSounds.Beep.Play();
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            statePbox.Image = Properties.Resources.Idle;
            timer.Stop();
        }
    }
}
