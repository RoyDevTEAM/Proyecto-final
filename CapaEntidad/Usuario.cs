using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public Roles oRoles { get; set; }
        public string nombre_usuario { get; set; }
        public string apellido_usuario { get; set; }
        public string numero_carnet { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
    }
}
