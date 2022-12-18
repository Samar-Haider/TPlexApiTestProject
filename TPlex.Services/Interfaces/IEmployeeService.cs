using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPlex.Models.Models;

namespace TPlex.Services.Interfaces
{
    public interface IEmployeeService
    {
        public List<Employee> GetAllEmployees();
        public Employee GetEmployeeById(int id);
        public bool InsertEmployee(Employee model);
        public Employee UpdateEmployee(Employee model);
        public bool DeleteEmployeeById(int? id);
    }
}
