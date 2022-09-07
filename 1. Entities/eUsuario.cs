using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Entities
{
    public class eUsuario
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string SegNombre { get; set; }
        public string ApellidoPat { get; set; }
        public string ApellidoMat { get; set; }
    }
}
