using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticaCorralon.Managers.Entidades
{
    public class Autenticacion
    {
        public int IdAutenticacion { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public int UsuarioId { get; set; }
    }
}
