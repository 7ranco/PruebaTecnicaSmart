using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntidadHabitacion
    {
        public int idRoom { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public int roomType { get; set; }
        public int state { get; set; }
        public int idHotel { get; set; }
        public int Belong { get; set; }
    }
}
