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
    public partial class StoreInventoryForm : Form
    {
        public StoreInventoryForm(Action callback)
        {
            //todo open new form similar to confirm with list to add / remove items to restock
            InitializeComponent();

            this.FormClosed += (x, y) => callback();
        }
    }
}
