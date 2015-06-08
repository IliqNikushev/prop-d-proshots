using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Visitor
{
    public partial class HomePage : App_Common.HomePageWithMap
    {
        public HomePage(App_Common.Menu menu):base(menu)
        {
            InitializeComponent();

            SetMapItems(Classes.Database.All<Classes.Landmark>().Where(x=>
            {
                Classes.TentPitch tent = x as Classes.TentPitch;
                if(tent)
                    if(tent.IsBooked) return false;
                return true;
            }
            ));
        }
    }
}
