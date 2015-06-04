using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;

namespace Design.Idea.AdministratorInterface
{
    public partial class Employees : HomePageWithMap
    {
        
        private List<Classes.Employee> employee;
        private List<Classes.ShopJob> shopjob;
        private Classes.Employee currentEmployee;
        public Employees(Form parent) : base()
        {
            InitializeComponent();
            this.employee = Classes.Database.All<Classes.Employee>();
            currentEmployee = LoggedInUser as Employee;
            this.comboBoxDuty.Items.Clear();
            this.comboBoxDuty.Items.Add("ALL");
            this.comboBoxDuty.Items.AddRange(Database.Jobs.ToArray());
           
        }

         

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new Home().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Classes.Employee> EmployeeToShow = this.employee;
            if (checkBoxEmployee.Checked)
            {
                EmployeeToShow = EmployeeToShow.Where(x => x.FullName.Contains(textBoxEmployee.Text)).ToList();
            }
            //search
            
            else if (comboBoxDuty.SelectedItem != null && comboBoxDuty.SelectedItem.ToString() != "All" )
                EmployeeToShow = EmployeeToShow.Where(x => x.Duty == (comboBoxDuty.SelectedItem ).ToString()).ToList();

           

            this.listBox1.Items.Clear();
            this.listBox1.Items.AddRange(EmployeeToShow.ToArray());
        }
    }
}
