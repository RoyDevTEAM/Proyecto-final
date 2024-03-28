using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Venta
    {
        public int id_venta {  get; set; }
        public Descuento oDescuento { get; set; }
        public Cliente oCliente {  get; set; }
        public Usuario oUsuario { get; set; }
        public string fecha_venta { get; set; }
        public string tipo_pago {  get; set; }
        public decimal total_venta { get; set; }
    }
}
