using NetCoreAPI.Data;
using NetCoreAPI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPI.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private DenariusAPIContext _context;
        private BaseRepository<inv_master> _invMaster;
        private BaseRepository<inv_grp1> _invGrp1;
        private BaseRepository<inv_master_aud> _invMasterAud;
        private BaseRepository<mps_usuarios> _mpsUsuarios;

        public UnitOfWork(DenariusAPIContext dbcontext)
        {
            _context = dbcontext;
        }

        public IRepository<inv_master> inv_master
        {
            get
            {
                return _invMaster ??= new BaseRepository<inv_master>(_context);
            }
        }
        public IRepository<inv_grp1> inv_grp1
        {
            get
            {
                return _invGrp1 ??= new BaseRepository<inv_grp1>(_context);
            }
        }
        public IRepository<inv_master_aud> inv_master_aud
        {
            get
            {
                return _invMasterAud ??= new BaseRepository<inv_master_aud>(_context);
            }
        }

        public IRepository<mps_usuarios> mps_usuario
        {
            get
            {
                return _mpsUsuarios ??= new BaseRepository<mps_usuarios>(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        IRepository<inv_master> IUnitOfWork.inv_master { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IRepository<inv_grp1> IUnitOfWork.inv_grp1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IRepository<inv_master_aud> IUnitOfWork.inv_master_aud { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        IRepository<mps_usuarios> IUnitOfWork.mps_usuarios { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }
}
