using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreAPI.Entities.Models;

namespace NetCoreAPI.Services
{
    public interface IUnitOfWork
    {
        IRepository<InvMaster> inv_master { get; set; }
        IRepository<InvGrp1> inv_grp1 { get; set; }
        IRepository<InvMasterAud> inv_master_aud { get; set; }

        void Save();
    }
}
