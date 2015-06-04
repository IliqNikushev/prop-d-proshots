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
    public partial class InformationDeskForm : App_Common.Menu
    {
        private Classes.InformationKioskWorkplace job;
        private Classes.Employee employee;
        public InformationDeskForm(App_Common.Menu parent) : base(parent)
        {
            this.employee = LoggedInEmployee;
            this.job = this.employee.Workplace as Classes.InformationKioskWorkplace;
            InitializeComponent();
        }
    }
}
