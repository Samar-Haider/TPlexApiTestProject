using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPlex.Models.Models;

namespace TPlex.Services.Interfaces
{
    public interface IDepartmentService
    {
        List<Department> GetAllDepartments();
        public Department GetDepartmentById(int id);
        public bool InsertDepartment(Department model);
        Department UpdateDepartmentName(Department model);
        public bool DeleteDepartmentById(int? id);

    }
}
