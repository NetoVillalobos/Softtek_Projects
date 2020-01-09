using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class QualificationET
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int IdRating { get; set; }
        public int Count { get; set; }
        public System.DateTime DateUpdate { get; set; }
    }
}
