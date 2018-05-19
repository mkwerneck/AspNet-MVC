using BlogWeb.Infra;
using BlogWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWeb.Areas.Admin.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private UserManager<Usuario> _manager;
        public UserManager<Usuario> Manager
        {
            get
            {
                if (_manager == null)
                {
                    _manager = HttpContext
                        .GetOwinContext()
                        .Get<UserManager<Usuario>>();
                }
                return _manager;
            }
        }

        // GET: Admin/Usuario
        public ActionResult Index()
        {
            var lista = Manager.Users.ToList();
            return View(lista);
        }

        public ActionResult Delete(String Id)
        {
            var usuario = Manager.FindById(Id);
            var resultado = Manager.Delete(usuario);
            if (resultado.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var erro in resultado.Errors)
                {
                    ModelState.AddModelError("", erro);
                }
            }
            return RedirectToAction("Index");
        }
    }
}