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
    public class DepartmentService : IDepartmentService
    {
        IDepartmentRepository _departmentRepository;
        public DepartmentService()
        {
            _departmentRepository = new DepartmentRepository();
        }

        public List<Department> GetAllDepartments()
        {
            List<Department> lstDepartments = _departmentRepository.GetAllDepartments();
            return lstDepartments;
        }

        public Department GetDepartmentById(int id)
        {
            Department lstDepartments = _departmentRepository.GetDepartmentById(id);
            return lstDepartments;
        }

        public bool InsertDepartment(Department model)
        {
            bool success = _departmentRepository.InsertDepartment(model);
            return success;
        }
        public Department UpdateDepartmentName(Department model)
        {
            Department department = _departmentRepository.UpdateDepartmentName(model);
            return department;
        }

        public bool DeleteDepartmentById(int? id)
        {
            bool success = _departmentRepository.DeleteDepartmentById(id); 
            return success;
        }
    }
}
