using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRest_saati.Models
{
    public class EmpleadoIn
    {

        public int No { get; set; }

    }

    public class EmpleadosOut
    {

        public int No { get; set; }

        public string Nombre { get; set; }

        public string ApellidoP { get; set; }

        public string ApellidoM { get; set; }

        public string Ruta { get; set; }

        public string Cedis { get; set; }
    }
}