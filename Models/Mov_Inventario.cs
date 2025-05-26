using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace WebInventario.Models
{
    public class Mov_Inventario
    {
        [Key]
        [Column(Order=1)]
        [DisplayName("CODIGO CIA")]
        public string COD_CIA { get; set; }
        [Key]
        [Column(Order = 2)]
        [DisplayName("COMPANIA")]
        public string COMPANIA_VENTA_3 { get; set; }
        [Key]
        [Column(Order = 3)]
        [DisplayName("ALMACEN VENTA")]
        public string ALMACEN_VENTA { get; set; }
        [Key]
        [Column(Order = 4)]
        [DisplayName("TIPO MOVIMIENTO")]
        public string TIPO_MOVIMIENTO { get; set; }
        [Key]
        [Column(Order = 5)]
        [DisplayName("TIPO DOCUMENTO")]
        public string TIPO_DOCUMENTO { get; set; }
        [Key]
        [Column(Order = 6)]
        [DisplayName("NRO DOCUMENTO")]
        public string NRO_DOCUMENTO { get; set; }
        [Key]
        [Column(Order = 7)]
        [DisplayName("COD ITEM2")]
        public string COD_ITEM_2 { get; set; }

        [DisplayName("PROVEEDOR")]
        public string PROVEEDOR { get; set; }
        [DisplayName("ALMACEN DESTINO")]
        public string ALMACEN_DESTINO { get; set; }
        [DisplayName("CANTIDAD")]
        public int CANTIDAD { get; set; }
        [DisplayName("DOC REF1")]
        public string DOC_REF_1 { get; set; }
        [DisplayName("DOC REF2")]
        public string DOC_REF_2 { get; set; }
        [DisplayName("DOC REF3")]
        public string DOC_REF_3 { get; set; }
        [DisplayName("DOC REF4")]
        public string DOC_REF_4 { get; set; }
        [DisplayName("DOC REF5")]
        public string DOC_REF_5 { get; set; }
        [DisplayName("FECHA TRANSACCION")]
        public DateTime FECHA_TRANSACCION { get; set; }
    }
}
