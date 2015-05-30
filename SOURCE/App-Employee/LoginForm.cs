using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Employee
{
    public partial class LoginForm : App_Common.LoginForm
    {
        protected override bool OnLogin()
        {
            Classes.Employee employee = LoggedInEmployee;
            if (employee != null)
            {
                if (employee.Job.ID != Install.Job.ID)
                    return false;

                if (employee.Job is Classes.ShopJob)
                    new StoreForm(this).Show();
                else if (employee.Job is Classes.ITServiceJob)
                    new RentForm(this).Show();
                else if (employee.Job is Classes.PCDoctorJob)
                    new PCDoctorForm(this).Show();
                else if (employee.Job is Classes.InformationKioskJob)
                    new InformationDeskForm(this).Show();
                else
                    throw new NotImplementedException("Unknown job");
                return true;
            }
            return false;
        }

        public LoginForm(App_Common.Menu parent)
            : base(parent)
        {
            InitializeComponent();
        }
    }
}
