using BLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WSComercio.DataContract;
using BEntities;

namespace WSComercio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ComercioService : IComercioService
    {
        [WebInvoke(Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped)]
        public List<OrdenPagoDC> ListarOrdenPago(string tipoMoneda)
        {
            try
            {
                var resultado = new List<OrdenPagoDC>();
                var lista = new BLOrdenPago().ListarOrdenPagoxMoneda(tipoMoneda);

                if (lista != null && lista.Count > 0)
                {
                    foreach (var item in lista)
                    {
                        resultado.Add(new OrdenPagoDC()
                        {
                            IdOrdenPago = item.IdOrdenPago,
                            IdBanco = item.IdBanco,
                            Banco = item.Banco,
                            IdSucursal = item.IdSucursal,
                            Sucursal = item.Sucursal,
                            Monto = item.Monto,
                            Moneda = item.Moneda,
                            IdEstado = item.IdEstado,
                            Estado = item.Estado,
                            FechaPago = item.FechaPago.ToShortDateString()
                        });
                    }

                    return resultado;
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


        [WebInvoke(Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Xml,
        BodyStyle = WebMessageBodyStyle.Wrapped)]
        public List<SucursalDC> ListarSucural(int idBanco)
        {
            try
            {
                var resultado = new List<SucursalDC>();
                var lista = new BLSucursal().ListarSucursal(idBanco);

                if (lista != null && lista.Count > 0)
                {
                    foreach (var item in lista)
                    {
                        resultado.Add(new SucursalDC()
                        {
                            IdBanco = item.IdBanco,
                            IdSucursal = item.IdSucursal,
                            Nombre = item.Nombre,
                            Direccion = item.Direccion,
                            FechaRegistro = item.FechaRegistro.ToShortDateString()
                        });
                    }

                    return resultado;
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
