using Microsoft.AspNetCore.Mvc;

namespace TPlexApi.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
