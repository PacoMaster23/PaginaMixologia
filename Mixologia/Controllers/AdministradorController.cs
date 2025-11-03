using Microsoft.AspNetCore.Mvc;

namespace Mixologia.Controllers
{
    public class AdministradorController : Controller
    {
    //CREAR METODO GETALL PARA STATUSSOLICITUD
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
    //AGREGAR BOTONES Y LIGARLOS CON ID
        [HttpGet]
        public IActionResult eliminarSolicitud(int IdSolicitud)
        {
        ML.Result resultEliminar = _context.Delete(IdSolicitud);
        if(resultEliminar.Correct)
        {
        return RedirectToAction("Solicitudes")
        }
        return RedirectToAction("Solicitudes") 
        }
//CREAR NUEVA VISTA FORM
            [HttpGet]
     public IActionResult Form(int IdSolicitud)
        {
        ML.Solicitud Solicitud = new ML.Solicitud();
        Solicitud.StatusSolicitud = new ML.StatusSolicitud();

        ML.Result resultSolicitud = _context.GetById(IdSolicitud);
        if(resultSolicitud.Correct)
        {
        //AGREGAR LOS DATOS Y VALIDACION PARA VER SI ES CREAR O ACTUALIZAR
        }
        
        }
        
        [HttpPost]
           public IActionResult Form(ML.Solicitud Solicitud)
        {
        
        }
    }
}
