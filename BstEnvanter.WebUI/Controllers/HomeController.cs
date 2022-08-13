using Microsoft.AspNetCore.Mvc;

namespace BstEnvanter.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
