using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CatProvidersET
    {
        public int IdProvider { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IsEnabled { get; set; }
        public System.DateTime DateUpdate { get; set; }
        public string Url { get; set; }
    }
}
