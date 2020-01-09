using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CatCatalogsET
    {
        public int IdCatalog { get; set; }
        public int IdProvider { get; set; }
        public string Season { get; set; }
        public string StarActiveDate { get; set; }
        public string EndActiveDate { get; set; }
        public string DateUpdate { get; set; }
        public string IsEnabled { get; set; }
    }
}
