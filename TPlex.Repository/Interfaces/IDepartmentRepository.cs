using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPlex.Models.Models;

namespace TPlex.Repository.Interfaces
{
    public interface IDepartmentRepository
    {
        List<Department> GetAllDepartments();
        Department GetDepartmentById(int id);
        bool InsertDepartment(Department model);
        Department UpdateDepartmentName(Department model);
        public bool DeleteDepartmentById(int? id);
    }
}
