using System;
using System.Collections.Generic;

namespace NetCoreAPI.Entities.Models
{
    public partial class inv_grp1
    {
        public inv_grp1()
        {
            inv_master = new HashSet<inv_master>();
        }

        public int key1 { get; set; }
        public int id_grp0 { get; set; }
        public int orden { get; set; }
        public string nombre { get; set; }
        public string cod_ant { get; set; }

        public virtual inv_grp0 id_grp0Navigation { get; set; }
        public virtual ICollection<inv_master> inv_master { get; set; }
    }
}
