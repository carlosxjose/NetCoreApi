using NetCoreAPI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPI.Entities.DTOs
{
    public class InvMasteList
    {
        public int key1 { get; set; }
        public List<InvMaster> invMastersAgregados { get; set; }
    }
}
