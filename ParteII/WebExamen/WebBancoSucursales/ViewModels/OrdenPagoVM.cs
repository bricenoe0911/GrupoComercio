using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBancoSucursales.ViewModels
{
    public class OrdenPagoVM
    {
        public int IdOrdenPago { get; set; }
        public int IdSucursal { get; set; }
        public decimal Monto { get; set; }
        public string Moneda { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public DateTime FechaPago { get; set; }
    }
}