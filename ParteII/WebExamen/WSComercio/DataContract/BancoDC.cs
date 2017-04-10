using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WSComercio.DataContract
{
    [DataContract]
    public class BancoDC
    {
        [DataMember]
        public int IdBanco { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string FechaRegistro { get; set; }
    }
}