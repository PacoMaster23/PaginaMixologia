using Microsoft.AspNetCore.Mvc;

namespace Mixologia.Controllers
{
    public class AdministradorController : Controller
    {

    private readonly BL.Solicitudes _context
    public AdministradorController(BL.Solicitud context)
    {
    _context = context;
    }
    
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Solicitudes()
        {
        ML.Solicitud Solicitud = new ML.Solicitud();
        ML.Result resultSolicitud = new ML.Result();

        if(resultSolicitud.Correct)
        {
        Solicitud.Solicitudes = resultSolicitud.Objects;
        }
        
            return View(Solicitud);
        }


        
    }
}
