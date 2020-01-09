using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ImagesProductET
    {
        public int IdImage { get; set; }
        public int IdImageProduct { get; set; }
        public string Decription { get; set; }
        public byte[] Image { get; set; }
        public string DateUpdate { get; set; }
        public string IsEnabled { get; set; }
    }
}
