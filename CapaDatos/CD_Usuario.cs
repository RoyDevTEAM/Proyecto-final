using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Usuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select id_usuario, nombre_usuario, apellido_usuario, numero_Carnet, telefono, direccion, usuario, contrasena from usuario";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read()) {
                            lista.Add(new Usuario()
                            {
                                id_usuario = Convert.ToInt32(dr["id_usuario"]),
                                nombre_usuario = dr["nombre_usuario"].ToString(),
                                apellido_usuario = dr["apellido_usuario"].ToString(),
                                numero_carnet = dr["numero_carnet"].ToString(),
                                telefono = dr["telefono"].ToString(),
                                direccion = dr["direccion"].ToString(),
                                usuario = dr["usuario"].ToString(),
                                contrasena = dr["contrasena"].ToString(),
                            });

                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<Usuario>();
                }
            }
            return lista;
        }
    }
}
