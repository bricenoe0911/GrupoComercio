using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEntities
{
    public class BEBanco
    {
        public BEBanco()
        {
            Sucursales = new List<BESucursal>();
        }
        public int IdBanco { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public List<BESucursal> Sucursales { get; set; }
    }
}
