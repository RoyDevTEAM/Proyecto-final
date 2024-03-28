using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Pago_Credito
    {
        public int id_pago_credito {  get; set; }
        public string fecha_pago {  get; set; }
        public decimal monto_pagado { get; set; }
        public decimal saldo_pendiente {  get; set; }
    }
}
