using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPlex.Models.Models;
using TPlex.Repository.Implementation;
using TPlex.Repository.Interfaces;
using TPlex.Services.Interfaces;

namespace TPlex.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> lstEmployees = _employeeRepository.GetAllEmployees();
            return lstEmployees;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = _employeeRepository.GetEmployeeById(id);
            return employee;
        }

        public bool InsertEmployee(Employee model)
        {
            bool success = _employeeRepository.InsertEmployee(model);
            return success;
        }
        public Employee UpdateEmployee(Employee model)
        {
            Employee employee = _employeeRepository.UpdateEmployee(model);
            return employee;
        }

        public bool DeleteEmployeeById(int? id)
        {
            bool success = _employeeRepository.DeleteEmployeeById(id);
            return success;
        }

    }
}
