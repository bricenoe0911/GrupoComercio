using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WSComercio.DataContract
{
    [DataContract]
    public class OrdenPagoDC
    {
        [DataMember]
        public int IdOrdenPago { get; set; }
        [DataMember]
        public int IdSucursal { get; set; }
        [DataMember]
        public decimal Monto { get; set; }
        [DataMember]
        public string Moneda { get; set; }
        [DataMember]
        public int IdEstado { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string FechaPago { get; set; }
        [DataMember]
        public int IdBanco { get; set; }
        [DataMember]
        public string Banco { get; set; }
        [DataMember]
        public string Sucursal { get; set; }
    }
}