using Microsoft.AspNetCore.Mvc;

namespace Mixologia.Controllers
{
    public class AdministradorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Solicitudes()
        {
            return View();
        }
    }
}
