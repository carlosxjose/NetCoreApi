using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreAPI.Entities.Models;

namespace NetCoreAPI.Services
{
    public interface IUnitOfWork
    {
        IRepository<inv_master> inv_master { get; set; }
        IRepository<inv_grp1> inv_grp1 { get; set; }
        IRepository<inv_master_aud> inv_master_aud { get; set; }

        void Save();
    }
}
