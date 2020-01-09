using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CatTypeProductET
    {
        public int IdType { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public System.DateTime DateUpdate { get; set; }
        public bool IsEnabled { get; set; }
    }
}
