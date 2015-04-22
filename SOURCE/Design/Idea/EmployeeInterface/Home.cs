using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design.Idea.EmployeeInterface
{
    public partial class Home : HomePage
    {
        protected Classes.Employee Employee { get { return LoggedInUser as Classes.Employee; } }
        public Home()
        {
            InitializeComponent();
        }

        protected override void OnSet()
        {
            base.OnSet();
            return;
            if (Employee.Job is Classes.ITServiceJob)
                new PCDoctor().Show();
            else if (Employee.Job is Classes.ShopJob)
                new Store().Show();
            else if (Employee.Job is Classes.PCDoctorJob)
                new PCDoctor().Show();
            else
                throw new NotImplementedException("Unknown job : " + Employee.Job);
        }
    }
}
