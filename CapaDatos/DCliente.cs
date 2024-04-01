using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCliente : DbConecction
    {

        //variables
        private int _Id_cliente;
        private string _Nombre_cliente;
        private string _Apellido_cliente;
        private string _Numero_carnet;
        private string _Telefono;
        private string _Direccion;
        private string _Estado;
        private string _TextoBuscar;



        //propiedades
        public int Id_cliente { get => _Id_cliente; set => _Id_cliente = value; }
        public string Nombre_cliente { get => _Nombre_cliente; set => _Nombre_cliente = value; }
        public string Apellido_cliente { get => _Apellido_cliente; set => _Apellido_cliente = value; }
        public string Numero_carnet { get => _Numero_carnet; set => _Numero_carnet = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public string Estado { get => _Estado; set => _Estado = value; }

        //constructores

        public DCliente()
        {

        }


        public DCliente(int id_cliente, string nombre_cliente, string apellido_cliente,
            string numero_carnet, string telefono, string direccion ,string estado, string textoBuscar)
        {
            Id_cliente = id_cliente;
            Nombre_cliente = nombre_cliente;
            Apellido_cliente = apellido_cliente;
            Numero_carnet = numero_carnet;
            Telefono = telefono;
            Direccion = direccion;
            Estado = estado;
            TextoBuscar = textoBuscar;
        }




        //Metodos
        public string Insertar(DCliente Cliente)
        {
            string rpta = string.Empty;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "spinsertar_cliente";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdCliente = new SqlParameter();
                        ParIdCliente.ParameterName = "@id_cliente";
                        ParIdCliente.SqlDbType = SqlDbType.Int;
                        ParIdCliente.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParIdCliente);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre_cliente";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 50;
                        ParNombre.Value = Cliente.Nombre_cliente;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParApellidos = new SqlParameter();
                        ParApellidos.ParameterName = "@apellido_cliente";
                        ParApellidos.SqlDbType = SqlDbType.VarChar;
                        ParApellidos.Size = 50;
                        ParApellidos.Value = Cliente.Apellido_cliente;
                        command.Parameters.Add(ParApellidos);

                        SqlParameter ParNumero = new SqlParameter();
                        ParNumero.ParameterName = "@numero_carnet";
                        ParNumero.SqlDbType = SqlDbType.VarChar;
                        ParNumero.Size = 20;
                        ParNumero.Value = Cliente.Numero_carnet;
                        command.Parameters.Add(ParNumero);

                        SqlParameter ParTelefono = new SqlParameter();
                        ParTelefono.ParameterName = "@telefono";
                        ParTelefono.SqlDbType = SqlDbType.VarChar;
                        ParTelefono.Size = 20;
                        ParTelefono.Value = Cliente.Telefono;
                        command.Parameters.Add(ParTelefono);

                        SqlParameter ParDireccion = new SqlParameter();
                        ParDireccion.ParameterName = "@direccion";
                        ParDireccion.SqlDbType = SqlDbType.VarChar;
                        ParDireccion.Size = 50;
                        ParDireccion.Value = Cliente.Direccion;
                        command.Parameters.Add(ParDireccion);

                        SqlParameter ParEstado = new SqlParameter();
                        ParEstado.ParameterName = "@estado";
                        ParEstado.SqlDbType = SqlDbType.VarChar;
                        ParEstado.Size = 256;
                        ParEstado.Value = Cliente.Estado;
                        command.Parameters.Add(ParEstado);

                        //Ejecutamos el comando
                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE INGRESO EL REGISTRO";
                    }
                    catch (Exception ex)
                    {
                        rpta = ex.Message;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open) connection.Close();
                    }
                }
            }
            return rpta;
        }

        //Metodo Editar



        //Metodo Mostrar
        public DataTable MostrarC()
        {
            DataTable DtResultado = new DataTable("cliente");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "spmostrar_cliente";
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
        public DataTable BuscarNombreC(DCliente Cliente)
        {
            DataTable DtResultado = new DataTable("cliente");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "spbuscar_cliente_nombre";
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

    }
}
