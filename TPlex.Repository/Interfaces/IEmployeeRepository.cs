using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPlex.Models.Models;

namespace TPlex.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        bool InsertEmployee(Employee model);
        Employee UpdateEmployee(Employee model);
        public bool DeleteEmployeeById(int? id);
    }
}
