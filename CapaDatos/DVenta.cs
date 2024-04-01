using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Security.Principal;

namespace CapaDatos
{
    public class DVenta : DbConecction
    {
        //variables
        private int _Id_venta;
        //private int _Id_descuento;
        private int _Id_cliente;
        private int _Id_usuario;
        private DateTime _Fecha_venta;
        private string _Tipo_pago;
        private decimal _Total_venta;
        private decimal _Descuento_entero;


        //propiedades
        public int Id_venta { get => _Id_venta; set => _Id_venta = value; }

        public int Id_cliente { get => _Id_cliente; set => _Id_cliente = value; }
        public int Id_usuario { get => _Id_usuario; set => _Id_usuario = value; }
        public DateTime Fecha_venta { get => _Fecha_venta; set => _Fecha_venta = value; }
        public string Tipo_pago { get => _Tipo_pago; set => _Tipo_pago = value; }
        public decimal Total_venta { get => _Total_venta; set => _Total_venta = value; }
        public decimal Descuento_entero { get => _Descuento_entero; set => _Descuento_entero = value; }

        //constructores

        public DVenta()
        {

        }


        public DVenta(int id_venta, int id_cliente, int id_usuario,
            DateTime fecha_venta, string tipo_pago, decimal total_venta, decimal descuento_entero)
        {
            Id_venta = id_venta;

            Id_cliente = id_cliente;
            Id_usuario = id_usuario;
            Fecha_venta = fecha_venta;
            Tipo_pago = tipo_pago;
            Total_venta = total_venta;
            Descuento_entero = descuento_entero;
        }

        //Metodo Insertar
        public string Insertar(DVenta Venta, List<DDetalle_Venta> Detalle)
        {
            string rpta = string.Empty;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = DbConecction.cn;
                SqlCon.Open();
                //Establecer la transaccion
                SqlTransaction SqlTra = SqlCon.BeginTransaction();
                //Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@id_venta";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdventa);

                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@id_cliente";
                ParIdcliente.SqlDbType = SqlDbType.Int;
                ParIdcliente.Value = Venta.Id_cliente;
                SqlCmd.Parameters.Add(ParIdcliente);

                SqlParameter ParIdusuario = new SqlParameter();
                ParIdusuario.ParameterName = "@id_usuario";
                ParIdusuario.SqlDbType = SqlDbType.Int;
                ParIdusuario.Value = Venta.Id_usuario;
                SqlCmd.Parameters.Add(ParIdusuario);



                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha_venta";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Venta.Fecha_venta;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParTipo_pago = new SqlParameter();
                ParTipo_pago.ParameterName = "@tipo_pago";
                ParTipo_pago.SqlDbType = SqlDbType.VarChar;
                ParTipo_pago.Size = 256;
                ParTipo_pago.Value = Venta.Tipo_pago;
                SqlCmd.Parameters.Add(ParTipo_pago);

                SqlParameter ParTotal_venta = new SqlParameter();
                ParTotal_venta.ParameterName = "@total_venta";
                ParTotal_venta.SqlDbType = SqlDbType.Decimal;
                ParTotal_venta.Precision = 18;
                ParTotal_venta.Scale = 0;
                ParTotal_venta.Value = Venta.Total_venta;
                SqlCmd.Parameters.Add(ParTotal_venta);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento_entero";
                ParDescuento.SqlDbType = SqlDbType.Decimal;
                ParDescuento.Precision = 18;
                ParDescuento.Scale = 0;
                ParDescuento.Value = Venta.Descuento_entero;
                SqlCmd.Parameters.Add(ParDescuento);



                //Ejecutamos el comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE INGRESO EL REGISTRO";
                if (rpta.Equals("OK"))
                {
                    //Obtener el codigo del ingreso generado
                    this.Id_venta = Convert.ToInt32(SqlCmd.Parameters["@id_venta"].Value);
                    foreach (DDetalle_Venta det in Detalle)
                    {
                        det.Id_venta = this.Id_venta;
                        //Llamar al metodo insertar de la clase DDetalle_ingreso
                        rpta = det.Insertar(det, ref SqlCon, ref SqlTra);
                        if (!rpta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }
                if (rpta.Equals("OK"))
                {
                    SqlTra.Commit();
                }
                else
                {
                    SqlTra.Rollback();
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Metodo Anular





        //Metodo Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("venta");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "spmostrar_venta";
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

        //Metodo Buscar por Fechas
        public DataTable BuscarFechas(string TextoBuscar1, string TextoBuscar2)
        {
            DataTable DtResultado = new DataTable("venta");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "spbuscar_venta_fecha";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar1";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = TextoBuscar1;
                        command.Parameters.Add(ParTextoBuscar);

                        SqlParameter ParTextoBuscar2 = new SqlParameter();
                        ParTextoBuscar2.ParameterName = "@textobuscar2";
                        ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar2.Size = 50;
                        ParTextoBuscar2.Value = TextoBuscar2;
                        command.Parameters.Add(ParTextoBuscar2);
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




        //Metodo Mostrar Detalle
        public DataTable MostrarDetalle(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("detalle_venta");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "spmostrar_detalle_venta";
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
