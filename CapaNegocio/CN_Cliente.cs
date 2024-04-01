using CapaDatos;
using CapaEntidad;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Cliente
    {
        public static DataTable ListarCliente(string cTexto)
        {
            CD_Cliente cliente = new CD_Cliente();
            return cliente.Listar_Cliente(cTexto);
        }

        public static void GuardarCliente(Cliente cliente)
        {
            CD_Cliente cdCliente = new CD_Cliente();
            cdCliente.GuardarCliente(cliente);
        }

        public static void ModificarCliente(Cliente cliente)
        {
            CD_Cliente cdCliente = new CD_Cliente();
            cdCliente.ModificarCliente(cliente);
        }

        public static bool ExisteClientePorCarnet(string carnet, string clienteId)
        {
            try
            {
                CD_Cliente cdCliente = new CD_Cliente();
                return cdCliente.ExisteClientePorCarnet(carnet, clienteId);
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la verificación del cliente
                throw new Exception("Error al verificar existencia de cliente por carnet: " + ex.Message, ex);
            }
        }
    }
}
