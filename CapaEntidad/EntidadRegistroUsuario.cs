using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntidadRegistroUsuario
    {
        public int idAgent { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string VerifyPassword { get; set; }
    }
}

