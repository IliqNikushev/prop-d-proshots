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
                //if (employee.Workplace.ID != Install.Job.ID)
               //     return false;

                if (employee.Workplace is Classes.ShopWorkplace)
                    new StoreForm(this).Show();
                else if (employee.Workplace is Classes.ITServiceWorkplace)
                    new RentForm(this).Show();
                else if (employee.Workplace is Classes.PCDoctorWorkplace)
                    new PCDoctorForm(this).Show();
                else if (employee.Workplace is Classes.InformationKioskWorkplace)
                    new InformationDeskForm(this).Show();
                else
                    throw new NotImplementedException("Unknown job");
                return true;
            }
            MessageBox.Show("Invalid credentials");
            return false;
        }

        public LoginForm(App_Common.Menu parent)
            : base(parent)
        {
            InitializeComponent();
        }
    }
}
