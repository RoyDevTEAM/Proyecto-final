using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaNegocio
{
    public class NVenta
    {
        public static string Insertar(int id_cliente, int id_usuario,
            DateTime fecha_venta, string tipo_pago, decimal total_venta, decimal descuento_entero, DataTable dtDetalles)
        {
            DVenta Obj = new DVenta();


            Obj.Id_cliente = id_cliente;
            Obj.Id_usuario = id_usuario;
            Obj.Fecha_venta = fecha_venta;
            Obj.Tipo_pago = tipo_pago;
            Obj.Total_venta = total_venta;
            Obj.Descuento_entero = descuento_entero;
            List<DDetalle_Venta> detalles = new List<DDetalle_Venta>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Venta detalle = new DDetalle_Venta();
                detalle.Id_producto = Convert.ToInt32(row["id_producto"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["cantidad"].ToString());
                detalle.Subtotal = Convert.ToDecimal(row["subtotal"].ToString());
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }


        //Metodo Anular ingreso




        //Metodo Buscar Fecha que llama al metodo BuscarFecha de la clase DIngreso de la CapaDatos
        public static DataTable BuscarFechas(string textobuscar1, string textobuscar2)
        {
            DVenta Obj = new DVenta();
            return Obj.BuscarFechas(textobuscar1, textobuscar2);
        }


        //Metodo Mostrar que llama al metodo mostrar de la clase DIngreso de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DVenta().Mostrar();
        }

        //Metodo mostrar detalle
        public static DataTable MostrarDetalle(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarDetalle(textobuscar);
        }


    }
}
