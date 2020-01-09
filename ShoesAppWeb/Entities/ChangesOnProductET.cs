using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ChangesOnProductET
    {
        public int IdLog { get; set; }
        public int IdProduct { get; set; }
        public int ActionMade { get; set; }
    }
}
