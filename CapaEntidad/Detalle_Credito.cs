using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Detalle_Credito
    {
        public int id_detalle_credito {  get; set; }
        public Venta oVenta { get; set; }
        public Pago_Credito oPago_Credito {  get; set; }

    }
}
