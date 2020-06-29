using NetCoreAPI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPI.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private NetCoreAPIContext _context;
        private BaseRepository<InvMaster> _invMaster;
        private BaseRepository<InvGrp1> _invGrp1;
        private BaseRepository<InvMasterAud> _invMasterAud;

        public UnitOfWork(NetCoreAPIContext dbcontext)
        {
            _context = dbcontext;
        }

        public IRepository<InvMaster> inv_master
        {
            get
            {
                return _invMaster ??= new BaseRepository<InvMaster>(_context);
            }
        }
        public IRepository<InvGrp1> inv_grp1
        {
            get
            {
                return _invGrp1 ??= new BaseRepository<InvGrp1>(_context);
            }
        }
        public IRepository<InvMasterAud> inv_master_aud
        {
            get
            {
                return _invMasterAud ??= new BaseRepository<InvMasterAud>(_context);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        IRepository<InvMaster> IUnitOfWork.inv_master { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IRepository<InvGrp1> IUnitOfWork.inv_grp1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IRepository<InvMasterAud> IUnitOfWork.inv_master_aud { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }
}
