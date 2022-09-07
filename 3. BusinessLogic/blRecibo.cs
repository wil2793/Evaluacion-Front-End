using _1.Entities;
using _2.DataAcces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.BusinessLogic
{
    public class blRecibo
    {
        private daRecibo _daRecibo { get; set; }

        public daRecibo daRec
        {
            get { if (_daRecibo == null) { _daRecibo = new daRecibo(); } return _daRecibo; }

        }

        public eRecibo BuscarRecibo(int reciboId)
        {
            return JsonConvert.DeserializeObject<eRecibo>(daRec.GetRecibo(reciboId));
        }

        public List<eRecibo> BuscarRecibos(int userId)
        {
            var z = JsonConvert.DeserializeObject<List<eRecibo>>(daRec.GetRecibos(userId));
            return z;
        }

        public void GuardarRecibo(eRecibo recibo, int reciboId = 0)
        {
            if (reciboId == 0)
            {
                daRec.PostRecibo(recibo);
            }
            else
            {
                daRec.PutRecibo(reciboId, recibo);
            }
        }

        public void EliminarRecibo(int id)
        {
            daRec.DeleteRecibo(id);
        }
    }
}
