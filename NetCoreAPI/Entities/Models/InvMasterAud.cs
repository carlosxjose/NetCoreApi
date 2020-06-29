using System;
using System.Collections.Generic;

namespace NetCoreAPI.Entities.Models
{
    public partial class InvMasterAud
    {
        public int Key1 { get; set; }
        public DateTime Fechah { get; set; }
        public string Terminal { get; set; }
        public string Operation { get; set; }
        public string Usuario { get; set; }
        public int IdArticulo { get; set; }
        public string Tipo { get; set; }
        public string Codigo { get; set; }
        public string NombreF { get; set; }
        public string Referencia { get; set; }
        public decimal FactorCompra { get; set; }
        public int? IdCodControl { get; set; }
        public decimal CostoPro { get; set; }
        public decimal CostoProOld { get; set; }
        public decimal PrecioM { get; set; }
        public decimal PrecioMOld { get; set; }
        public decimal PrecioE { get; set; }
        public decimal PrecioEOld { get; set; }
        public decimal PrecioR { get; set; }
        public decimal PrecioROld { get; set; }
        public bool StsNulo { get; set; }
    }
}
