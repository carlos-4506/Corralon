using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticaCorralon.Managers.Entidades
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; } // 'procesando', 'aceptada', 'entregada'
        public string NumeroFactura { get; set; }
        public int UsuarioId { get; set; }
        public int DireccionId { get; set; }

    }
}
