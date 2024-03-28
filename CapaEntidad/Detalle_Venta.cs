using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Detalle_Venta
    {
        public int id_detalle_venta {  get; set; }
        public Venta oVenta { get; set;}
        public Producto oProducto {  get; set; }
        public int cantidad { get; set; }
        public decimal sub_total {  get; set; }
    }
}
