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
    public partial class EmployeeITDesk : Menu
    {
        List<Classes.RentableItem> selectedItems = new List<Classes.RentableItem>();
        List<Classes.RentableItem> AllItems;

        public EmployeeITDesk()
        {
            InitializeComponent();
        }

        private void purchaseBtn_Click(object sender, EventArgs e)
        {
        }

        private void addMultipleBtn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
