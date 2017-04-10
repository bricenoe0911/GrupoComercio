using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BData
{
    public static class BDConexion
    {
        static string cadenaConexion = "Persist Security Info=False;User ID=sa;Password=p@ssw0rd;Initial Catalog=Comercio;Data Source=LAPTOP-UOKNU6M5";

        public static SqlConnection ConectarBD()
        {
            var conexion = new SqlConnection();

            conexion.ConnectionString = cadenaConexion;
            conexion.Open();

            return conexion;
        }
    }
}
