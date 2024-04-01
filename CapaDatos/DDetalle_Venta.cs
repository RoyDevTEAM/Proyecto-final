using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace CapaDatos
{
    public class DDetalle_Venta : DbConecction
    {

        //Variables
        private int _Iddetalle_venta;
        private int _Id_venta;
        private int _Id_producto;
        private int _Cantidad;
        private decimal _Subtotal;



        //propiedades
        public int Iddetalle_venta { get => _Iddetalle_venta; set => _Iddetalle_venta = value; }
        public int Id_venta { get => _Id_venta; set => _Id_venta = value; }
        public int Id_producto { get => _Id_producto; set => _Id_producto = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public decimal Subtotal { get => _Subtotal; set => _Subtotal = value; }

        //constructores

        public DDetalle_Venta()
        {

        }

        public DDetalle_Venta(int iddetalle_venta, int id_venta, int id_producto,
            int cantidad, decimal subtotal)
        {
            Iddetalle_venta = iddetalle_venta;
            Id_venta = id_venta;
            Id_producto = id_producto;
            Cantidad = cantidad;
            Subtotal = subtotal;
        }




        public string Insertar(DDetalle_Venta Detalle_venta, ref SqlConnection SqlCon,
            ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {
                //Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_ingreso = new SqlParameter();
                ParIddetalle_ingreso.ParameterName = "@id_detalle_venta";
                ParIddetalle_ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_ingreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddetalle_ingreso);

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@id_venta";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = Detalle_venta.Id_venta;
                SqlCmd.Parameters.Add(ParIdventa);

                SqlParameter ParIdproducto = new SqlParameter();
                ParIdproducto.ParameterName = "@id_producto";
                ParIdproducto.SqlDbType = SqlDbType.Int;
                ParIdproducto.Value = Detalle_venta.Id_producto;
                SqlCmd.Parameters.Add(ParIdproducto);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Detalle_venta.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);



                SqlParameter ParSubtotal = new SqlParameter();
                ParSubtotal.ParameterName = "@subtotal";
                ParSubtotal.SqlDbType = SqlDbType.Decimal;
                ParSubtotal.Value = Detalle_venta.Subtotal;
                SqlCmd.Parameters.Add(ParSubtotal);



                //SqlParameter ParFecha_produccion = new SqlParameter();
                //ParFecha_produccion.ParameterName = "@fecha_produccion";
                //ParFecha_produccion.SqlDbType = SqlDbType.Date;
                //ParFecha_produccion.Value = Detalle_ingreso.Fecha_produccion;
                //SqlCmd.Parameters.Add(ParFecha_produccion);

                //SqlParameter ParFecha_vencimiento = new SqlParameter();
                //ParFecha_vencimiento.ParameterName = "@fecha_vencimiento";
                //ParFecha_vencimiento.SqlDbType = SqlDbType.Date;
                //ParFecha_vencimiento.Value = Detalle_ingreso.Fecha_vencimiento;
                //SqlCmd.Parameters.Add(ParFecha_vencimiento);
                //Ejecutamos el comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE INGRESO EL REGISTRO";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }














        public string DisminuirStock(int id_producto, int cantidad)
        {
            string rpta = "";
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spdisminuir_stock";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParId_producto = new SqlParameter();
                        ParId_producto.ParameterName = "@id_producto";
                        ParId_producto.SqlDbType = SqlDbType.Int;
                        ParId_producto.Value = id_producto;
                        command.Parameters.Add(ParId_producto);

                        SqlParameter ParCantidad = new SqlParameter();
                        ParCantidad.ParameterName = "@cantidad";
                        ParCantidad.SqlDbType = SqlDbType.Int;
                        ParCantidad.Value = cantidad;
                        command.Parameters.Add(ParCantidad);


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



    }
}
































