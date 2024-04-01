using CapaEntidad;
using System;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Cliente
    {
        public DataTable Listar_Cliente(string busqueda)
        {
            DataTable Tabla = new DataTable();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    string query = "SELECT id_cliente, nombre_cliente, apellido_cliente, numero_carnet, telefono, direccion, estado " +
                                   "FROM cliente " +
                                   "WHERE nombre_cliente LIKE @busqueda OR apellido_cliente LIKE @busqueda OR numero_carnet LIKE @busqueda";

                    using (SqlCommand comando = new SqlCommand(query, oconexion))
                    {
                        oconexion.Open();
                        comando.Parameters.AddWithValue("@busqueda", "%" + busqueda + "%");

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            adaptador.Fill(Tabla);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar clientes: " + ex.Message, ex);
            }
            return Tabla;
        }

        public void GuardarCliente(Cliente cliente)
        {
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    string query = @"INSERT INTO cliente (nombre_cliente, apellido_cliente, numero_carnet, telefono, direccion, estado) 
                                     VALUES (@nombre, @apellido, @carnet, @telefono, @direccion, @estado)";

                    using (SqlCommand comando = new SqlCommand(query, oconexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", cliente.nombre_cliente);
                        comando.Parameters.AddWithValue("@apellido", cliente.apellido_cliente);
                        comando.Parameters.AddWithValue("@carnet", cliente.numero_carnet);
                        comando.Parameters.AddWithValue("@telefono", cliente.telefono);
                        comando.Parameters.AddWithValue("@direccion", cliente.direccion);
                        comando.Parameters.AddWithValue("@estado", cliente.estado);

                        oconexion.Open();
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar cliente: " + ex.Message, ex);
            }
        }

        public void ModificarCliente(Cliente cliente)
        {
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    string query = @"UPDATE cliente 
                                     SET nombre_cliente = @nombre, apellido_cliente = @apellido, numero_carnet = @carnet, 
                                         telefono = @telefono, direccion = @direccion, estado = @estado 
                                     WHERE id_cliente = @id";

                    using (SqlCommand comando = new SqlCommand(query, oconexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", cliente.nombre_cliente);
                        comando.Parameters.AddWithValue("@apellido", cliente.apellido_cliente);
                        comando.Parameters.AddWithValue("@carnet", cliente.numero_carnet);
                        comando.Parameters.AddWithValue("@telefono", cliente.telefono);
                        comando.Parameters.AddWithValue("@direccion", cliente.direccion);
                        comando.Parameters.AddWithValue("@estado", cliente.estado);
                        comando.Parameters.AddWithValue("@id", cliente.id_cliente);

                        oconexion.Open();
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar cliente: " + ex.Message, ex);
            }
        }

        public bool ExisteClientePorCarnet(string carnet, string clienteId)
        {
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    string query = @"SELECT COUNT(*) FROM cliente WHERE numero_carnet = @carnet";

                    if (!string.IsNullOrEmpty(clienteId))
                    {
                        query += " AND id_cliente != @clienteId";
                    }

                    using (SqlCommand command = new SqlCommand(query, oconexion))
                    {
                        command.Parameters.AddWithValue("@carnet", carnet);
                        if (!string.IsNullOrEmpty(clienteId))
                        {
                            command.Parameters.AddWithValue("@clienteId", clienteId);
                        }
                        oconexion.Open();
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar existencia de cliente por carnet: " + ex.Message, ex);
            }
        }
    }
}
