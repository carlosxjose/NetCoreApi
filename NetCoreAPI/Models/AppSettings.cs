using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPI.Models
{
    public class AppSettings
    {
        public string ImagesPath { get; set; }
        public List<string> ImagesFolders { get; set; }
        public string ConnectionString { get; set; }
    }
}
