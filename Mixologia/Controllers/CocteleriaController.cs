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


        [HttpGet]
        public IActionResult Mixologia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form(ML.Solicitudes Solicitud)
        {
            ML.Result resultPost = _contextSolicitudes.CrearSolicitud(Solicitud);

            if (resultPost.Correct)
            {
                ViewBag.Message = "¡Tu solicitud ha sido enviada exitosamente!";
            }
            else
            {
                ViewBag.Message = "Hubo un error al enviar tu solicitud: " + resultPost.ErrorMessage;
            }


            return View();
        }
    }
}
