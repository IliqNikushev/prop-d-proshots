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
    public partial class Warnings : Form
    {
        private List<Warning> warnings;
        public Warnings()
        {
            InitializeComponent();
            warnings = Database.All<Warning>();
            foreach (Warning w in warnings)
            {
                listBoxWarn.Items.Add(w.Name);   
            }
                

        }

        private void Warnnings_Load(object sender, EventArgs e)
        {
            
        }

        private void listBoxWarn_SelectedIndexChanged(object sender, EventArgs e)
        {
           Warning warn= warnings[listBoxWarn.SelectedIndex];

            richTextBoxDesc.Text = warn.Description;

 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
