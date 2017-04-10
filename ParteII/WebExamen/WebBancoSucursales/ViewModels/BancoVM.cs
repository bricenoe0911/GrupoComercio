using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBancoSucursales.ViewModels
{
    public class BancoVM
    {
        public BancoVM()
        {
            Sucursales = new List<SucursalVM>();
        }
        public int? IdBanco { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public List<SucursalVM> Sucursales { get; set; }
    }
}