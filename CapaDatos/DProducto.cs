using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DProducto : DbConecction
    {
        private int _Id_producto;
        private int _Id_unidad_medida;
        private int _Id_subcategoria;
        private string _Nombre_producto;
        private string _Precio_producto;
        private string _Descripcion_producto;
        private string _Stock;
        private string _TextoBuscar;




        //propiedades
        public int Id_producto { get => _Id_producto; set => _Id_producto = value; }
        public int Id_unidad_medida { get => _Id_unidad_medida; set => _Id_unidad_medida = value; }
        public int Id_subcategoria { get => _Id_subcategoria; set => _Id_subcategoria = value; }
        public string Nombre_producto { get => _Nombre_producto; set => _Nombre_producto = value; }
        public string Precio_producto { get => _Precio_producto; set => _Precio_producto = value; }
        public string Descripcion_producto { get => _Descripcion_producto; set => _Descripcion_producto = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public string Stock { get => _Stock; set => _Stock = value; }

        //contructores

        public DProducto()
        {

        }

        public DProducto(int id_producto, int id_unidad_medida, int id_subcategoria, string nombre_producto,
            string precio_producto, string descripcion_producto, string stock, string textoBuscar)
        {
            Id_producto = id_producto;
            Id_unidad_medida = id_unidad_medida;
            Id_subcategoria = id_subcategoria;
            Nombre_producto = nombre_producto;
            Precio_producto = precio_producto;
            Descripcion_producto = descripcion_producto;
            Stock = stock;
            TextoBuscar = textoBuscar;
        }





        //Metodo Mostrar
        public DataTable MostrarP()
        {
            DataTable DtResultado = new DataTable("producto");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "spmostrar_producto";
                        command.CommandType = CommandType.StoredProcedure;
                        //Ejecutamos el comando
                        SqlDataAdapter Sqldat = new SqlDataAdapter(command);
                        Sqldat.Fill(DtResultado);
                    }
                    catch (Exception)
                    {
                        DtResultado = null;
                    }
                }
            }
            return DtResultado;
        }



        //Metodo BuscarNombre
        public DataTable BuscarNombreP(DProducto Producto)
        {
            DataTable DtResultado = new DataTable("producto");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "spbuscar_producto_nombre";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = TextoBuscar;
                        command.Parameters.Add(ParTextoBuscar);
                        //Ejecutamos el comando
                        SqlDataAdapter Sqldat = new SqlDataAdapter(command);
                        Sqldat.Fill(DtResultado);
                    }
                    catch (Exception)
                    {
                        DtResultado = null;
                    }
                }
            }
            return DtResultado;
        }


        //public int ObtenerStockDisponibleProducto(int id_producto)
        //{
        //    int stockDisponible = 0;
        //    try
        //    {
        //        using (SqlConnection connection = GetConnection())
        //        {
        //            connection.Open();
        //            string query = "SELECT stock FROM producto WHERE id_producto = @idProducto";
        //            SqlCommand command = new SqlCommand(query, connection);
        //            command.Parameters.AddWithValue("@id_producto", id_producto);
        //            object result = command.ExecuteScalar();
        //            if (result != null && result != DBNull.Value)
        //            {
        //                stockDisponible = Convert.ToInt32(result);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejar cualquier excepción aquí, por ejemplo, podrías registrar el error en un archivo de registro
        //        Console.WriteLine("Error al obtener el stock disponible del producto: " + ex.Message);
        //    }
        //    return stockDisponible;
        //}

    }
}
