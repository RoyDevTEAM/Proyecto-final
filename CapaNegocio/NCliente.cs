using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class NCliente
    {
        //Metodo Insertar que llama al metodo Insertar de la clase DCliente de la CapaDatos
        public static string Insertar(string nombre_cliente, string apellido_cliente,
            string numero_carnet, string telefono, string direccion, string estado)
        {
            DCliente Obj = new DCliente();
            Obj.Nombre_cliente = nombre_cliente;
            Obj.Apellido_cliente = apellido_cliente;
            Obj.Numero_carnet = numero_carnet;
            Obj.Telefono = telefono;
            Obj.Direccion = direccion;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }

        //Metodo Mostrar que llama al metodo Mostrar de la clase DCliente de la CapaDatos
        public static DataTable MostrarCliente()
        {
            return new DCliente().MostrarC();
        }


        public static DataTable BuscarNombreC(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombreC(Obj);
        }


    }
}
