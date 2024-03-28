using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Detalle_Compra
    {
        public int id_detalle_compra {  get; set; }
        public Producto oProducto {  get; set; }
        public Compra oCompra {  get; set; }
        public int cantidad_detalle_compra { get; set; }
        public decimal precio_compra { get; set; }
        public string fecha_vencimiento_producto { get; set; }
        public decimal subtotal_compra { get; set; }
    }
}
