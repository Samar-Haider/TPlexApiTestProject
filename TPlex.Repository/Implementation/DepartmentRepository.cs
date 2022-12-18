using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPlex.Models.Models;
using TPlex.Repository.Interfaces;

namespace TPlex.Repository.Implementation
{
    public class DepartmentRepository : IDepartmentRepository
    {
        TplexTestDbContext db;
        public DepartmentRepository()
        {
            this.db = new TplexTestDbContext();
        }

        public List<Department> GetAllDepartments()
        {
            List<Department> lstDepartments = db.Departments.ToList();
            return lstDepartments;
        }

        public Department GetDepartmentById(int id)
        {
            Department department = db.Departments?.Where(x => x.Id.Equals(id)).FirstOrDefault();
            return department;
        }

        public bool InsertDepartment(Department model)
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

        public Department UpdateDepartmentName(Department model)
        {
            Department department = db.Departments?.Where(x => x.Id.Equals(model.Id)).FirstOrDefault();
            department.Name = model.Name;

            db.SaveChanges();
            return department;
        }

        public bool DeleteDepartmentById(int? id)
        {
            bool success = false;
            Department department = db.Departments?.Where(x => x.Id.Equals(id)).FirstOrDefault();
            db.Remove(department);
            db.SaveChanges();
            success = true;
            return success;
        }
    }
}
