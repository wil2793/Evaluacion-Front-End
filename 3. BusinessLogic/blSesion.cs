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
    public class blSesion
    {
        private daSesion _daSesion { get; set; }

        public daSesion daSesion
        {
            get { if (_daSesion == null) { _daSesion = new daSesion(); } return _daSesion; }

        }

        public bool validarSesionActiva(int userId)
        {
            bool BlnReturn = false;
            string respuesta = daSesion.GetSesionUser(userId);
            if (respuesta != "" && respuesta != "null")
            {
                eSesion sesion = JsonConvert.DeserializeObject<eSesion>(respuesta);
                Utils.IdLogin = sesion.IdSesion;
                BlnReturn = true;
            }

            return BlnReturn;
        }

        public bool iniciarSesion(int userId)
        {
            string problema = "";
            try
            {
                if (daSesion.GetSesionUser(userId) == string.Empty)
                {
                    eSesion sesion = new eSesion();
                    sesion.lSession = true;
                    sesion.DteInicio = DateTime.Now;
                    sesion.DteFin = Convert.ToDateTime("01/01/1753");
                    sesion.IdUser = userId;
                    daSesion.PostSesion(sesion);

                    if (!validarSesionActiva(userId))
                    {
                        problema = "Problema al validar sesión";
                    }
                }
            }
            catch (Exception ex)
            {
                problema = ex.Message;
            }

            return problema == "";
        }

        public void cerrarSesion(int id)
        {
            eSesion sesion = JsonConvert.DeserializeObject<eSesion>(daSesion.GetSesion(id));
            sesion.lSession = false;
            sesion.DteFin = DateTime.Now;
            daSesion.PutSesion(id, sesion);
        }
    }
}
