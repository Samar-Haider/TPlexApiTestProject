using Microsoft.AspNetCore.Mvc;
using TPlex.Models.Models;
using TPlex.Services.Implementation;
using TPlex.Services.Interfaces;

namespace TPlex.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentService _departmentService;
        private ILogger<DepartmentController> _logger;

        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentService departmentService)
        {
            this._departmentService = departmentService;
            _logger = logger;
        }

        /// <summary>
        /// Date Time: 8/12/2022 4:00 PM
        /// Author: Samar Jafri
        /// Purpose: Get All Departments
        /// </summary>
        /// <returns></returns>

        [HttpGet("[action]")]
        public IActionResult GetAllDepartments()
        {
            bool success = false;
            string message = String.Empty;
            List<Department> departments = null;
            object response;
            try
            {
                departments = _departmentService.GetAllDepartments();
                if (departments.Count.Equals(0))
                {
                    success = false;
                    message = "No Departments Exist";
                    response = new { success = success, message = message, departments = departments };
                    return NotFound(response);
                }
                success = true;
                message = "Departments fetched successfully";
            }
            catch (Exception ex)
            {
                message = ex.Message;
                response = new { success = success, message = message, departments = departments };
                _logger.LogError(ex, message);
                return NotFound(response);
            }

            response = new { success = success, message = message, departments = departments };
            return Ok(response);
        }

        /// <summary>
        /// Date Time: 8/12/2022 4:00 PM
        /// Author: Samar Jafri
        /// Purpose: Get Department By Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult GetDepartmentById(int Id)
        {
            bool success = false;
            string message = String.Empty;
            Department department = null;
            object response;
            try
            {
                department = _departmentService.GetDepartmentById(Id);

                if (department == null)
                {
                    success = false;
                    message = $"Department with ID={Id} does not exist";
                    response = new { success = success, message = message, department = department };
                    return NotFound(response);
                }

                success = true;
                message = "Department fetched successfully";
            }
            catch (Exception ex)
            {
                message = ex.Message;
                response = new { success = success, message = message, department = department };
                _logger.LogError(ex, message);
                return NotFound(response);
            }

            response = new { success = success, message = message, department = department };
            return Ok(response);
        }

        /// <summary>
        /// Date Time: 8/12/2022 4:00 PM
        /// Author: Samar Jafri
        /// Purpose: Insert Department
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult InsertDepartment([FromBody] Department model)
        {
            bool success = false;
            string message = String.Empty;
            Department department = new Department();
            object response;
            try
            {
                if (!string.IsNullOrEmpty(model.Name) && !string.IsNullOrWhiteSpace(model.Name))
                {
                    department.Name = model.Name;
                    success = _departmentService.InsertDepartment(department);
                    message = "Department inserted successfully";
                }
                else
                {
                    success = false;
                    message = "Please specify department name";
                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
                response = new { success = success, message = message, department = department };
                _logger.LogError(ex, message);
                return NotFound(response);
            }

            response = new { success = success, message = message };
            return Ok(response);
        }

        /// <summary>
        /// Date Time: 8/12/2022 4:00 PM
        /// Author: Samar Jafri
        /// Purpose: Update Department Name by Id
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult UpdateDepartmentName([FromBody] Department model)
        {
            bool success = false;
            string message = String.Empty;
            Department department = new Department();
            object response;
            try
            {
                if (!string.IsNullOrEmpty(model.Name) && !string.IsNullOrWhiteSpace(model.Name) && model.Id != 0)
                {
                    department.Id = model.Id;
                    department.Name = model.Name;
                    department = _departmentService.UpdateDepartmentName(department);
                    message = "Department updated successfully";
                }
                else
                {
                    success = false;
                    message = "Department Id or Department Name not supplied";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                response = new { success = success, message = message, department = department };
                _logger.LogError(ex, message);
                return NotFound(response);
            }

            response = new { success = success, message = message, department = department };
            return Ok(response);
        }

        /// <summary>
        /// Date Time: 8/12/2022 4:00 PM
        /// Author: Samar Jafri
        /// Purpose: Delete Department by Id
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult DeleteDepartmentByDepartmentId(int? id)
        {
            bool success = false;
            string message = String.Empty;
            Department department = null;
            object response;
            try
            {
                if (id != 0)
                {
                    success = _departmentService.DeleteDepartmentById(id);
                    message = "Department deleted successfully";
                }
                else
                {
                    success = false;
                    message = "Department Id not supplied";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                response = new { success = success, message = message, department = department };
                _logger.LogError(ex, message);
                return NotFound(response);
            }

            response = new { success = success, message = message };
            return Ok(response);
        }
    }
}
