using _1.Entities;
using _3.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evaluacion.Controllers
{
    public class LoginController : Controller
    {
        private blUsuario _blUsuario;
        private blUsuario blUser
        {
            get
            {
                if (_blUsuario == null)
                {
                    _blUsuario = new blUsuario();
                }
                return _blUsuario;
            }
        }


        private blSesion _blSesion;
        private blSesion blSes
        {
            get
            {
                if (_blSesion == null)
                {
                    _blSesion = new blSesion();
                }
                return _blSesion;
            }
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string user, string pass)
        {
            if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(pass))
            {
                eUsuario usuario = blUser.BuscarUser(user, pass);
                if (usuario != null)
                {
                    if (blSes.validarSesionActiva(usuario.IdUser))
                    {
                        Utils.IdUser = usuario.IdUser;
                        return Redirect("/Home/Index");
                    }
                    else
                    {
                        if (blSes.iniciarSesion(usuario.IdUser))
                        {
                            Utils.IdUser = usuario.IdUser;
                            return Redirect("/Home/Index");
                        }
                    }
                }
            }
            else
            {
                ViewBag.error = "Usuario y/o Contraseña incorrectos;";
            }
            return View();
        }

    }
}
