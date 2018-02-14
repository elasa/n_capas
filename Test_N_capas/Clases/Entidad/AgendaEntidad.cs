using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_N_capas.Clases.Entidad
{
    public class AgendaEntidad
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }

        public void test()
        {

        }
    }

    public class test : AgendaEntidad
    {
       public test()
        {

        }
    }
}