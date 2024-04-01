using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NProducto
    {


        //Metodo Insertar que llama al metodo Insertar de la clase DArticulo de la CapaDatos
        //public static string Insertar(int id_unidad_medida, int id_subcategoria, string nombre_producto,
        //    string precio_producto, string descripcion_producto, string textoBuscar)
        //{
        //    DProducto Obj = new DProducto();
        //    Obj.Id_unidad_medida = id_unidad_medida;
        //    Obj.Id_subcategoria = id_subcategoria;
        //    Obj.Nombre_producto = nombre_producto;
        //    Obj.Precio_producto = precio_producto;
        //    Obj.Descripcion_producto = descripcion_producto;
        //    Obj.TextoBuscar = textoBuscar;
        //    return Obj.Insertar(Obj);
        //}





        //Metodo Mostrar que llama al metodo Mostrar de la clase DArticulo de la CapaDatos
        public static DataTable MostrarProducto()
        {
            return new DProducto().MostrarP();
        }




        public static DataTable BuscarNombreP(string textobuscar)
        {
            DProducto Obj = new DProducto();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombreP(Obj);
        }

    }
}
