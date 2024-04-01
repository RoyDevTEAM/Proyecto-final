using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public abstract class DbConecction
    {
        public static string cn = "Server=(local); DataBase=BDVentas; Integrated Security=true";
        private readonly string connectionString;

        public DbConecction()
        {
            connectionString = cn;
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
