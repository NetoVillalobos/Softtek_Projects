using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DetailProductET
    {
        public int IdDetail { get; set; }
        public int IdProduct { get; set; }
        public int IdTypeDetail { get; set; }
        public string Description { get; set; }
        public string DateUpdate { get; set; }
    }
}
