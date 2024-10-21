using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticaCorralon.Managers.Entidades
{
    public class Carrito
    {
        public int IdCarrito { get; set; }
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        public int ClienteId { get; set; }
    }
}
