using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPlex.Models.Models;
using TPlex.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace TPlex.Repository.Implementation
{
    public class EmployeeRepository :  IEmployeeRepository
    {
        TplexTestDbContext db;
        public EmployeeRepository()
        {
            this.db = new TplexTestDbContext();
        }
        public List<Employee> GetAllEmployees() 
        {
            List<Employee> lstEmployees = db.Employees.Include(x => x.Department).ToList();

            return lstEmployees;
        }
        public Employee GetEmployeeById(int id) 
        {
            Employee employee = db.Employees.Where(x => x.Id.Equals(id)).Include(x => x.Department).FirstOrDefault();
            return employee;
        }
        public bool InsertEmployee(Employee model)
        {
            bool success = false;
            try
            {
                db.Add(model);
                db.SaveChanges();
                success = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return success;
        }
        public Employee UpdateEmployee(Employee model)
        {
            Employee employee = db.Employees?.Where(x => x.Id.Equals(model.Id)).Include(x => x.Department).FirstOrDefault();
            if (employee != null)
            {
                employee.Name = model.Name;
                employee.Designation = model.Designation;
                employee.Type = model.Type;
                employee.Salary = model.Salary;
                employee.Department = model.Department;

                db.SaveChanges();
                return employee;
            }
            return employee;
        }
        public bool DeleteEmployeeById(int? id) 
        {
            bool success = false;
            Employee employee = db.Employees?.Where(x => x.Id.Equals(id)).FirstOrDefault();
            db.Remove(employee);
            db.SaveChanges();
            success = true;
            return success;
        }

       
    }
}
