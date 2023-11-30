using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntidadHotel
    {
        public int idHotel { get; set; }
        public string nameHotel { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public int agent  { get; set;}
        public int state { get; set; }
    }
}
