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
    public partial class EmployeeShop : Menu
    {
        public EmployeeShop()
        {
         
            InitializeComponent();
        }

        private void EmployeeShop_Load(object sender, EventArgs e)
        {
            itemsListView.Items.Add("Food:");
            itemsListView.Items.Add("Pizzas:");
            itemsListView.Items.Add("=============");
            itemsListView.Items.Add("1.Margarita");
            cartListView.Items.Add("User Bill:");
            cartListView.Items.Add("=============");
            cartListView.Items.Add("1.Margarita");
            cartListView.Items.Add("Coka");
        }
    }
}
