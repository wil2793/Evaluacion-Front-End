using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Entities
{
    public class eSesion
    {
        public int IdSesion { get; set; }
        public bool lSession { get; set; }
        public DateTime DteInicio { get; set; }
        public DateTime DteFin { get; set; }
        public int IdUser { get; set; }
    }
}
