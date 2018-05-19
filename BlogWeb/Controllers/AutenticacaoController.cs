using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.Models.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using BlogWeb.Infra;
using BlogWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace BlogWeb.Controllers
{
    public class AutenticacaoController : Controller
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

        // GET: Autenticacao
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = Manager.Find(model.LoginName, model.Password);
                if (usuario != null)
                {
                    var identity = Manager.CreateIdentity(usuario, DefaultAuthenticationTypes.ApplicationCookie);
                    HttpContext.GetOwinContext().Authentication.SignIn(identity);

                    usuario.UltimoLogin = DateTime.Now;
                    var resultado = Manager.Update(usuario);
                    if (resultado.Succeeded)
                    {
                        return RedirectToAction("Index", new { Area = "Admin", Controller = "Post" });
                    }
                    else
                    {
                        return View();
                    }      
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Registro() {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(RegistroViewModel model) {
            if (ModelState.IsValid) {
                Usuario usuario = new Usuario
                {
                    UserName = model.LoginName,
                    Email = model.Email
                };

                var resultado = Manager.Create(usuario, model.Senha);
                if (resultado.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var erro in resultado.Errors)
                    {
                        ModelState.AddModelError("", erro);
                    }
                }
                return RedirectToAction("Login");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}