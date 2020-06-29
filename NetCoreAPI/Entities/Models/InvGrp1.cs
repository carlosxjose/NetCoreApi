using System;
using System.Collections.Generic;

namespace NetCoreAPI.Entities.Models
{
    public partial class InvGrp1
    {
        public InvGrp1()
        {
            InvMaster = new HashSet<InvMaster>();
        }

        public int Key1 { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<InvMaster> InvMaster { get; set; }
    }
}
