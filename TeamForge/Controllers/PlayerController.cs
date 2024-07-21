using Microsoft.AspNetCore.Mvc;

namespace TeamForge.Controllers
{
    public class PlayerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
