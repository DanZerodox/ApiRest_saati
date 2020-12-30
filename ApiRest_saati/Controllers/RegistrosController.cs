using ApiRest_saati.Models;
using ApiRest_saati.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRest_saati.Controllers
{
    [RoutePrefix("api/Registros")]
    public class RegistrosController : ApiController
    {
        private static readonly string CLASS_NAME = typeof(RegistrosController).FullName;

        [HttpPost]
        [Route("BuscarColaborador")]

        public IHttpActionResult PostBuscarColaborador(EmpleadoIn empleado){

            var model = new RegistrosNegocio();
            List<EmpleadosOut> empleados = new List<EmpleadosOut>();

            empleados = model.BuscarColaborador(empleado);

            return Json(empleados);
        }
       
    }
}
