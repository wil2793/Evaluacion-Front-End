using _1.Entities;
using _3.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evaluacion.Controllers
{
    public class HomeController : Controller
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



        private blRecibo _blRecibo;
        private blRecibo blRec
        {
            get
            {
                if (_blRecibo == null)
                {
                    _blRecibo = new blRecibo();
                }
                return _blRecibo;
            }
        }
        public ActionResult Index()
        {
            eUsuario user = blUser.BuscarUser(Utils.IdUser);

            ViewBag.Nombre = Utils.nombreCompleto;
            return View();
        }

        public ActionResult Perfil()
        {
            eUsuario user = blUser.BuscarUser(Utils.IdUser);
            return View(user);
        }

        [HttpPost]
        public ActionResult Perfil(int userId, string user, string pass, string pNombre, string sNombre, string APat, string AMat)
        {
            eUsuario usuario = new eUsuario();
            usuario.IdUser = userId;
            usuario.UserName = user;
            usuario.Contrasena = pass;
            usuario.Nombre = pNombre;
            usuario.SegNombre = sNombre;
            usuario.ApellidoPat = APat;
            usuario.ApellidoMat = AMat;
            blUser.GuardarUsuario(usuario, usuario.IdUser);
            return Redirect("/Home/Perfil");
        }

        public ActionResult Recibos()
        {
            List<eRecibo> recibos = blRec.BuscarRecibos(Utils.IdUser);
            if (recibos == null)
            {
                recibos = new List<eRecibo>();
                eRecibo recibo = new eRecibo();
                recibo.IdRecibo = 0;
                recibo.Proveedor = string.Empty;
                recibo.Monto = 0;
                recibo.Moneda = string.Empty;
                recibo.Fecha = Convert.ToDateTime("01/01/1753");
                recibo.Comentario = string.Empty;
                recibo.IdUser = Utils.IdUser;
                recibos.Add(recibo);
            }
            return View(recibos);
        }

        public ActionResult Recibo(int reciboId = 0)
        {
            bool BlnNuevo = false;
            eRecibo recibo = new eRecibo();
            if (reciboId == 0)
            {
                BlnNuevo = true;

                recibo.IdRecibo = 0;
                recibo.Proveedor = string.Empty;
                recibo.Monto = 0;
                recibo.Moneda = string.Empty;
                recibo.Fecha = Convert.ToDateTime("01/01/1753");
                recibo.Comentario = string.Empty;
                recibo.IdUser = Utils.IdUser;
            }
            else
            {
                recibo = blRec.BuscarRecibo(reciboId);
            }

            ViewBag.lNuevo = BlnNuevo;
            return View(recibo);
        }

        [HttpPost]
        public ActionResult Recibo(int reciboId, string proveedor, double monto, string moneda, DateTime fecha, string comentario)
        {
            eRecibo recibo = new eRecibo();
            recibo.IdRecibo = reciboId;
            recibo.Proveedor = proveedor;
            recibo.Monto = monto;
            recibo.Moneda = moneda;
            recibo.Fecha = fecha;
            recibo.Comentario = comentario;
            recibo.IdUser = Utils.IdUser;
            blRec.GuardarRecibo(recibo, recibo.IdRecibo);
            return Redirect("/Home/Recibos");
        }
        public ActionResult EliminarRecibo(int reciboId)
        {
            blRec.EliminarRecibo(reciboId);
            return Redirect("/Home/Recibos");
        }

        public ActionResult cerrarSesion()
        {
            blSes.cerrarSesion(Utils.IdLogin);
            Utils.IdLogin = 0;
            Utils.IdUser = 0;
            Utils.nombreCompleto = string.Empty;
            return Redirect("/Login/Index");
        }
    }
}