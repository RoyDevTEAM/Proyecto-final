using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Subcategoria
    {
        public int id_subcategoria { get; set; }
        public Categoria oCategoria { get; set; }
        public string nombre_subcategoria { get; set; }
        public string descripcion {  get; set; }
    }
}
