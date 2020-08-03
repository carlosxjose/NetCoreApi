using System;
using System.Collections.Generic;

namespace NetCoreAPI.Entities.Models
{
    public partial class inv_grp0
    {
        public inv_grp0()
        {
            inv_grp1 = new HashSet<inv_grp1>();
        }

        public int key1 { get; set; }
        public int orden { get; set; }
        public string nombre { get; set; }
        public string cod_ant { get; set; }
        public int? idCnt0 { get; set; }

        public virtual ICollection<inv_grp1> inv_grp1 { get; set; }
    }
}
