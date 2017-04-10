using BEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BData
{
    public class BDBanco
    {
        public List<BEBanco> ListarBancos()
        {
            var sqlcmd = new SqlCommand();
            var lista = new List<BEBanco>();

            sqlcmd.Connection = BDConexion.ConectarBD();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "SP_ListarBancos";
            SqlDataReader sqldr = sqlcmd.ExecuteReader();

            if (sqldr.HasRows)
            {
                while (sqldr.Read())
                {
                    lista.Add(new BEBanco()
                    {
                        IdBanco = Convert.ToInt32(sqldr["Id"]),
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
        public int AdministrarBanco(BEBanco banco)
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
                sqlcmd.CommandText = "SP_Administrar";

                sqlcmd.Parameters.Add(new SqlParameter("@Id", banco.IdBanco));
                sqlcmd.Parameters.Add(new SqlParameter("@Nombre", banco.Nombre));
                sqlcmd.Parameters.Add(new SqlParameter("@Direccion", banco.Direccion));

                idRetorno = Convert.ToInt32(sqlcmd.ExecuteScalar());
            }
            catch (Exception)
            {
                idRetorno = 0;
            }


            return idRetorno;
        }

        public bool EliminarBanco(int idBanco)
        {
            var sqlcmd = new SqlCommand();
            try
            {
                sqlcmd.Connection = BDConexion.ConectarBD();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "SP_Eliminar";

                sqlcmd.Parameters.Add(new SqlParameter("@Id", idBanco));

                sqlcmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public BEBanco BuscarxId(int idBanco)
        {
            var sqlcmd = new SqlCommand();
            var banco = new BEBanco();
            try
            {
                sqlcmd.Connection = BDConexion.ConectarBD();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "SP_BuscarxId";
                sqlcmd.Parameters.Add(new SqlParameter("@Id", idBanco));

                SqlDataReader sqldr = sqlcmd.ExecuteReader();

                if (sqldr.HasRows)
                {
                    while (sqldr.Read())
                    {
                        banco.IdBanco = Convert.ToInt32(sqldr["Id"]);
                        banco.Nombre = sqldr["Nombre"].ToString();
                        banco.Direccion = sqldr["Direccion"].ToString();
                        banco.FechaRegistro = Convert.ToDateTime(sqldr["FechaRegistro"]);
                    }

                    return banco;
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
