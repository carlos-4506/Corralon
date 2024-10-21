using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticaCorralon.Managers.Entidades
{
    public class Direccion
    {
        public int IdDireccion { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public string Departamento { get; set; }
        public string Barrio { get; set; }
        public string Localidad { get; set; }

    }
}
