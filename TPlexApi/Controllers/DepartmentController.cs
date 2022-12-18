using Microsoft.AspNetCore.Mvc;
using TPlex.Models.Models;
using TPlex.Services.Interfaces;

namespace TPlexApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : BaseController
    {
        private IDepartmentService _departmentService;

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
                success = true;
                message = "Departments fetched successfully";
            }
            catch (Exception ex)
            {
                message = ex.Message;
                success = false;
                message = "Departments not fetched";
                //Log.Logger.Error(ex, message);
                //throw;
            }

            response = new { success = success, message = message, departments = departments };
            return Ok(response);
        }
    }
}