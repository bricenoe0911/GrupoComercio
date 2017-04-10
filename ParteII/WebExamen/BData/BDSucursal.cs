using BEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BData
{
    public class BDSucursal
    {
        public List<BESucursal> ListarSucursales(int idBanco)
        {
            var sqlcmd = new SqlCommand();
            var lista = new List<BESucursal>();

            sqlcmd.Connection = BDConexion.ConectarBD();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "SP_ListarSucursales";

            sqlcmd.Parameters.Add(new SqlParameter("@IdBanco", idBanco));

            SqlDataReader sqldr = sqlcmd.ExecuteReader();

            if (sqldr.HasRows)
            {
                while (sqldr.Read())
                {
                    lista.Add(new BESucursal()
                    {
                        IdSucursal = Convert.ToInt32(sqldr["Id"]),
                        IdBanco = Convert.ToInt32(sqldr["IdBanco"]),
                        Nombre = sqldr["Nombre"].ToString(),
                        Direccion = sqldr["Direccion"].ToString(),
                        FechaRegistro = Convert.ToDateTime(sqldr["FechaRegistro"])
                    });
                }
            }

            sqldr.Close();

            if (lista != null && lista.Count > 0)
            {
                return lista;
            }
            else
            {
                return null;
            }
        }
        public int AdministrarSucursal(BESucursal sucursal)
        {
            var sqlcmd = new SqlCommand();
            var idRetorno = 0;
            try
            {
                var cn = BDConexion.ConectarBD();
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                sqlcmd.Connection = cn;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "SP_AdministrarSucursal";

                sqlcmd.Parameters.Add(new SqlParameter("@Id", sucursal.IdSucursal));
                sqlcmd.Parameters.Add(new SqlParameter("@IdBanco", sucursal.IdBanco));
                sqlcmd.Parameters.Add(new SqlParameter("@Nombre", sucursal.Nombre));
                sqlcmd.Parameters.Add(new SqlParameter("@Direccion", sucursal.Direccion));

                idRetorno = Convert.ToInt32(sqlcmd.ExecuteScalar());
            }
            catch (Exception)
            {
                idRetorno = 0;
            }


            return idRetorno;
        }
        public BESucursal BuscarxId(int idSucursal)
        {
            var sqlcmd = new SqlCommand();
            var sucursal = new BESucursal();
            try
            {
                sqlcmd.Connection = BDConexion.ConectarBD();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "SP_BuscarxIdSucursal";
                sqlcmd.Parameters.Add(new SqlParameter("@Id", idSucursal));

                SqlDataReader sqldr = sqlcmd.ExecuteReader();

                if (sqldr.HasRows)
                {
                    while (sqldr.Read())
                    {
                        sucursal.IdSucursal = Convert.ToInt32(sqldr["Id"]);
                        sucursal.IdBanco = Convert.ToInt32(sqldr["IdBanco"]);
                        sucursal.Nombre = sqldr["Nombre"].ToString();
                        sucursal.Direccion = sqldr["Direccion"].ToString();
                        sucursal.FechaRegistro = Convert.ToDateTime(sqldr["FechaRegistro"]);
                    }

                    return sucursal;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
