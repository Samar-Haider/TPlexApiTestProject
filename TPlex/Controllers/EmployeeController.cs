using Microsoft.AspNetCore.Mvc;
using TPlex.Models.Models;
using TPlex.Services.Implementation;
using TPlex.Services.Interfaces;

namespace TPlex.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;
        private ILogger<EmployeeController> _logger;
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _employeeService = new EmployeeService();
            _logger = logger;
        }

        /// <summary>
        /// Date Time: 8/12/2022 4:00 PM
        /// Author: Samar Jafri
        /// Purpose: Get All employees
        /// </summary>
        /// <returns></returns>

        [HttpGet("[action]")]
        public IActionResult GetAllEmployees()
        {
            bool success = false;
            string message = String.Empty;
            List<Employee> employees = null;
            object response;
            try
            {
                employees = _employeeService.GetAllEmployees();
                if (employees.Count.Equals(0))
                {
                    success = false;
                    message = "No Employees Exist";
                    response = new { success = success, message = message, employees = employees };
                    return NotFound(response);
                }
                success = true;
                message = "employees fetched successfully";
            }
            catch (Exception ex)
            {
                message = ex.Message;
                response = new { success = success, message = message, employees = employees };
                _logger.LogError(ex, message);
                return NotFound(response);

            }

            response = new { success = success, message = message, employees = employees };
            return Ok(response);
        }

        /// <summary>
        /// Date Time: 8/12/2022 4:00 PM
        /// Author: Samar Jafri
        /// Purpose: Get Employee By Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult GetEmployeeById(int Id)
        {
            bool success = false;
            string message = String.Empty;
            Employee employee = null;
            object response;
            try
            {
                employee = _employeeService.GetEmployeeById(Id);
                if (employee == null)
                {
                    success = false;
                    message = $"Employee with ID={Id} does not exist";
                    response = new { success = success, message = message, employee = employee };
                    return NotFound(response);
                }
                success = true;
                message = "Employee fetched successfully";
            }
            catch (Exception ex)
            {
                message = ex.Message;
                response = new { success = success, message = message, employee = employee };
                _logger.LogError(ex, message);
                return NotFound(response);
            }

            response = new { success = success, message = message, employee = employee };
            return Ok(response);
        }

        /// <summary>
        /// Date Time: 8/12/2022 4:00 PM
        /// Author: Samar Jafri
        /// Purpose: Insert Employee
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult InsertEmployee([FromBody] Employee model)
        {
            bool success = false;
            string message = String.Empty;
            Employee employee = new Employee();
            object response;
            try
            {
                if (!string.IsNullOrEmpty(model.Name) && !string.IsNullOrWhiteSpace(model.Name))
                {
                    employee.Name = model.Name;
                    employee.Designation = model.Designation;
                    employee.Type = model.Type;
                    employee.Salary = model.Salary;
                    employee.DepartmentId = model.DepartmentId;

                    success = _employeeService.InsertEmployee(employee);
                    message = "Employee created successfully";
                }
                else
                {
                    success = false;
                    message = "Please specify Employee name";
                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
                response = new { success = success, message = message, employee = employee };
                _logger.LogError(ex, message);
                return NotFound(response);
            }

            response = new { success = success, message = message };
            return Ok(response);
        }

        /// <summary>
        /// Date Time: 8/12/2022 4:00 PM
        /// Author: Samar Jafri
        /// Purpose: Update Employee Name by Id
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult UpdateEmployee([FromBody] Employee model)
        {
            bool success = false;
            string message = String.Empty;
            Employee employee = new Employee();
            object response;
            try
            {
                if (!string.IsNullOrEmpty(model.Name) && !string.IsNullOrWhiteSpace(model.Name) && model.Id != 0)
                {
                    employee.Name = model.Name;
                    employee = _employeeService.UpdateEmployee(model);
                    message = "Employee updated successfully";
                }
                else
                {
                    success = false;
                    message = "Employee Id or Employee Name not supplied";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                response = new { success = success, message = message, employee = employee };
                _logger.LogError(ex, message);
                return NotFound(response);
            }

            response = new { success = success, message = message, Employee = employee };
            return Ok(response);
        }

        /// <summary>
        /// Date Time: 8/12/2022 4:00 PM
        /// Author: Samar Jafri
        /// Purpose: Delete Employee by Id
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult DeleteEmployeeById(int? id)
        {
            bool success = false;
            string message = String.Empty;
            Employee employee = null;
            object response;
            try
            {
                if (id != 0)
                {
                    success = _employeeService.DeleteEmployeeById(id);
                    message = "Employee deleted successfully";
                }
                else
                {
                    success = false;
                    message = "Employee Id not supplied";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                response = new { success = success, message = message, employee = employee };
                _logger.LogError(ex, message);
                return NotFound(response);
            }

            response = new { success = success, message = message };
            return Ok(response);
        }


    }
}
