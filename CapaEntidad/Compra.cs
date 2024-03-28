using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Compra
    {
        public int id_compra {  get; set; }
        public DateTime fecha_compra { get; set; }
        public decimal precio_compra { get; set; }
        public string descripcion_compra { get; set; }
        public decimal total_compra { get; set; }
        public Proovedor oProovedor {  get; set; }
        public Usuario oUsuario {  get; set; }
    }
}
