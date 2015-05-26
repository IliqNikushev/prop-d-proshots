using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Employee
{
    static class Install
    {
#warning set the job based on the install prefferences ( Build for every store a new version )
        public static Classes.Job Job = Classes.Database.Find<Classes.Job>("Workplaces.id = 1");
    }
}
