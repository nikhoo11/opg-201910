using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opg_201910_interview.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FileDirectoryPath { get; set; }
        public string ClientOrder { get; set; }
        public List<string> Files { get; set; }
    }
}
