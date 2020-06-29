using System;
using System.Collections.Generic;

namespace NetCoreAPI.Entities.Models
{
    public partial class InvMaster
    {
        public InvMaster()
        {
            InverseIdCodControlNavigation = new HashSet<InvMaster>();
        }

        public int Key1 { get; set; }
        public string Tipo { get; set; }
        public string Codigo { get; set; }
        public string NombreF { get; set; }
        public string Referencia { get; set; }
        public int? IdCodControl { get; set; }
        public int IdGrp1 { get; set; }
        public decimal? CostoUc { get; set; }
        public decimal CostoPro { get; set; }
        public decimal PrecioM { get; set; }
        public decimal PrecioE { get; set; }
        public decimal PrecioR { get; set; }
        public DateTime? FechaR { get; set; }
        public bool StsPos { get; set; }
        public bool StsNulo { get; set; }

        public virtual InvMaster IdCodControlNavigation { get; set; }
        public virtual InvGrp1 IdGrp1Navigation { get; set; }
        public virtual ICollection<InvMaster> InverseIdCodControlNavigation { get; set; }
    }
}
