﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBancoSucursales.ViewModels
{
    public class SucursalVM
    {
        public int? IdSucursal { get; set; }
        public int IdBanco { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}