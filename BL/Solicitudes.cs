using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Solicitudes
    {
        private readonly DL.CocteleriaContext _context;

        public Solicitudes(DL.CocteleriaContext context)
        {
            _context = context;
        }


        public ML.Result GetAll()
        {
            ML.Result result = new ML.Result();


            try
            {
                //var NombreUsuario = new SqlParameter("@NombreUsuario", soliciutdes.NombreUsuario ?? (object)DBNull.Value);
                //var Email = new SqlParameter("@Email", soliciutdes.Email ?? (object)DBNull.Value);
                //var Telefono = new SqlParameter("@Telefono", soliciutdes.Telefono ?? (object)DBNull.Value);
                //var Mensaje = new SqlParameter("@Mensaje", soliciutdes.Mensaje ?? (object)DBNull.Value);
                //var FechaSolicitud = new SqlParameter("@FechaSolicitud", soliciutdes.FechaSolicitud ?? (object)DBNull.Value);
                //var Estado = new SqlParameter("@IdStatusSolicitud", soliciutdes.StatusSolicitudes?.IdStatus ?? (object)DBNull.Value);

                var query = _context.Solicitudes.FromSqlRaw("GetAll").ToList();

                if (query != null)
                {
                    result.Objects = new List<object>();

                    foreach (var obj in query)
                    {
                        ML.Solicitudes solicitud = new ML.Solicitudes();
                        solicitud.StatusSolicitudes = new ML.StatusSolicitudes();

                        solicitud.IdSolicitud = obj.IdSolicitud;
                        solicitud.NombreUsuario = obj.NombreUsuario;
                        solicitud.Email = obj.Email;
                        solicitud.Telefono = obj.Telefono;
                        solicitud.Mensaje = obj.Mensaje;
                        solicitud.FechaSolicitud = obj.FechaSolicitud;

                        solicitud.StatusSolicitudes.IdStatus = obj.IdStatusNavigation!.IdStatus;
                        solicitud.StatusSolicitudes.Descripcion = obj.IdStatusNavigation.Descripcion;

                        result.Objects.Add(solicitud);
                    }
                    result.Correct = true;
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }



            return result;
        } //CREADO, SOLO PROBAR SU FUNCIONAMIENTO

        public ML.Result Delete(int IdSolicitud)
        {
            ML.Result result = new ML.Result();
            ML.Solicitudes solcitud = new ML.Solicitudes();

            try
            {

                var Id = new SqlParameter("@IdSolicitud", IdSolicitud);


                var query = _context.Database.ExecuteSqlRaw("DeleteSolicitud @IdSolicitud", Id);

                if (query > 0)
                {
                    result.Correct = true;
                }



            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }





            return result;
        } //CREADO, SOLO PROBAR SU FUNCIONAMIENTO

        public ML.Result GetById(int IdSolicitud)
        {
            ML.Result result = new ML.Result();

            try
            {
                var Id = new SqlParameter("@IdSolicitud", IdSolicitud);

                var query = _context.SolicitudGetById.FromSqlRaw("SolicitudGetById @IdSolicitud", Id).AsEnumerable().FirstOrDefault();

                if (query != null)
                {
                    ML.Solicitudes solicitud = new ML.Solicitudes();
                    solicitud.IdSolicitud = query.IdSolicitud;
                    solicitud.NombreUsuario = query.NombreUsuario;
                    solicitud.Email = query.Email;
                    solicitud.Telefono = query.Telefono;
                    solicitud.Mensaje = query.Mensaje;
                    solicitud.FechaSolicitud = query.FechaSolicitud;

                    solicitud.StatusSolicitudes = new ML.StatusSolicitudes();
                    solicitud.StatusSolicitudes.Descripcion = query.Descripcion;


                    result.Object = solicitud;
                    result.Correct = true;
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        } //CREADO, SOLO PROBAR SU FUNCIONAMIENTO


        public ML.Result ActualizarStatus(int IdSolicitud, int IdStatus)
        {
            ML.Result result = new ML.Result();
            try
            {
                var IdSol = new SqlParameter("@IdSolicitud", IdSolicitud);
                var IdStat = new SqlParameter("@IdStatus", IdStatus);
                var query = _context.Database.ExecuteSqlRaw("ActualizarStatus @IdSolicitud, @IdStatus", IdSol, IdStat);
                if (query > 0)
                {
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        } //CREADO, SOLO PROBAR SU FUNCIONAMIENTO
    }
}
