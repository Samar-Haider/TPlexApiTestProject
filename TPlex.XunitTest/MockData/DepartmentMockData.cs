using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPlex.Models.Models;

namespace TPlex.XunitTest.MockData
{
    public class DepartmentMockData
    {
        public static List<Department> GetDepartments()
        {
            return new List<Department>{
             new Department{
                 Id = 1,
                 Name  = "HR Department"
             },
             new Department{
                 Id = 2,
                 Name  = "Admin Department"
             },
             new Department{
                 Id = 3,
                 Name  = "Software Department"
             }
         };
    }

    }
}