using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPI.Entities.DTOs
{
    public class Configurations
    {
        public string ConnectionString { get; set; }
        public string ConnectionStringAut { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public int? idUsuario { get; set; }
    }
}
