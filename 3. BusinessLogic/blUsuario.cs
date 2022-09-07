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
    public class blUsuario
    {
        private daUsuario _daUser { get; set; }

        public daUsuario daUser
        {
            get { if (_daUser == null) { _daUser = new daUsuario(); } return _daUser; }

        }
        public eUsuario BuscarUser(string user, string pass)
        {
            string result = daUser.GetUSuario(user, pass);
            eUsuario usuario = JsonConvert.DeserializeObject<eUsuario>(result);
            return usuario;
        }

        public eUsuario BuscarUser(int userId)
        {
            string result = daUser.GetUSuario(userId);
            eUsuario usuario = JsonConvert.DeserializeObject<eUsuario>(result);
            return usuario;
        }

        public void GuardarUsuario(eUsuario usuario, int userId = 0)
        {
            if (userId == 0)
            {
                daUser.PostUsuario(usuario);
            }
            else
            {
                daUser.PutUsuario(userId, usuario);
            }
        }
    }
}
