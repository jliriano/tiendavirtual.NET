//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repository.Modelos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pedido
    {
        public int Id { get; set; }
        public string nombre_cliente { get; set; }
        public string email_cliente { get; set; }
        public string telefono_cliente { get; set; }
        public string direccion_cliente { get; set; }
        public string detalle { get; set; }
        public float subtotal { get; set; }
        public float iva { get; set; }
        public float envio { get; set; }
        public float total { get; set; }
    }
}
