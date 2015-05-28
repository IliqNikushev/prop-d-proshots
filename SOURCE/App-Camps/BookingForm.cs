using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Camps
{
    public partial class BookingForm : App_Common.HomePageWithMap
    {
        public BookingForm(App_Common.Menu parent)
            : base(parent)
        {
            InitializeComponent();
        }
    }
}
