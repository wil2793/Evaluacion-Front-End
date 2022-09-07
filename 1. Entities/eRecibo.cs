using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Entities
{
    public class eRecibo
    {
        public int IdRecibo { get; set; }
        public string Proveedor { get; set; }
        public double Monto { get; set; }
        public string Moneda { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public int IdUser { get; set; }
    }
}
