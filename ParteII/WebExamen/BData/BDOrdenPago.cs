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
    public class BDOrdenPago
    {
        public List<BEOrdenPago> ListarOrdenPagoxMoneda(string tipoMoneda)
        {
            var sqlcmd = new SqlCommand();
            var orden = new List<BEOrdenPago>();
            try
            {
                sqlcmd.Connection = BDConexion.ConectarBD();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "SP_ListarOrdenPago";
                sqlcmd.Parameters.Add(new SqlParameter("@tipoMoneda", tipoMoneda));

                SqlDataReader sqldr = sqlcmd.ExecuteReader();

                if (sqldr.HasRows)
                {
                    while (sqldr.Read())
                    {
                        orden.Add(new BEOrdenPago()
                        {
                            IdOrdenPago = Convert.ToInt32(sqldr["Id"]),
                            IdBanco = Convert.ToInt32(sqldr["IdBanco"]),
                            IdSucursal = Convert.ToInt32(sqldr["IdSucursal"]),
                            Banco = sqldr["NombreBanco"].ToString(),
                            Sucursal = sqldr["NombreSucursal"].ToString(),
                            Moneda = sqldr["Moneda"].ToString(),
                            Monto = Convert.ToDecimal(sqldr["Monto"]),
                            IdEstado = Convert.ToInt32(sqldr["IdEstado"]),
                            Estado = sqldr["DescripcionEstado"].ToString(),
                            FechaPago = Convert.ToDateTime(sqldr["FechaPago"])
                        });
                    }

                    return orden;
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
