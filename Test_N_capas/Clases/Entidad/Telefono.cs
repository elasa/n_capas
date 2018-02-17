using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_N_capas.Clases.Entidad
{
    public class Telefono
    {

        public int Id { get; set; } = 0;
        public int IdUsuario { get; set; } = 0;
        public int Telefonos { get; set; } = 0;
        public string Estado { get; set; } = "Activo";
        public int IdPais { get; set; } = 0;
        public int IdCiudad { get; set; } = 0;
    }


}