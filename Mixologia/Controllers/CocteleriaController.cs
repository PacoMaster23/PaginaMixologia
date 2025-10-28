using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mixologia.Controllers
{
    public class CocteleriaController : Controller
    {
        private readonly BL.Solicitudes _contextSolicitudes;
        public CocteleriaController(BL.Solicitudes context)
        {
            _contextSolicitudes = context;
        }
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Mixologia()
        {
            return View();
        }
    }
}
