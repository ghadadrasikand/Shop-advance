using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Host.Models.Options
{
    public class CDNConfig
    {
        public string Cdn { get; set; }
        public string Path { get; set; }
        public string HttpProductImagePath { get; set; }
    }
}
