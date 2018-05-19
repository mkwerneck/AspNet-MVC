using BlogWeb.DAO;
using System.Web.Mvc;
using BlogWeb.Models;
using System;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace BlogWeb.Areas.Admin.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private PostDaoEF dao;

        public PostController()
        {
            dao = new PostDaoEF();
        }

        public ActionResult Index()
        {
            var lista = dao.Lista();
            return View(lista);
        }

        public ActionResult Novo()
        {
            return View(new Post());
        }

        [HttpPost]
        public ActionResult Incluir(Post post)
        {
            if (ModelState.IsValid)
            {
                post.AutorId = this.User.Identity.GetUserId();
                dao.Incluir(post);
                return RedirectToAction("Index", new { Area = "Admin"});
            }

            HttpContext.Response.StatusCode = 400;
            return View("Novo", post);
        }

        [HttpGet]
        public ActionResult Remover(int id)
        {
            dao.Remover(id);

            return RedirectToAction("Index", new { Area = "Admin"});
        }

        [HttpGet]
        public ActionResult Detalhe(int id)
        {
            Post post = dao.BuscaPorId(id);

            if (post != null)
            {
                return View(post);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Alterar(Post post)
        {
            if (ModelState.IsValid)
            {
                dao.Alterar(post);
                return RedirectToAction("Index", new { Area = "Admin"});
            }
            HttpContext.Response.StatusCode = 400;
            return View("Detalhe", post);
        }

        public ActionResult Publicar(int id)
        {
            var post = dao.BuscaPorId(id);
            if (post != null)
            {
                post.Publicado = true;
                post.DataPublicacao = DateTime.Now;

                dao.Alterar(post);
                return RedirectToAction("Index", new { Area="Admin" });
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult CategoriaAutoComplete(string term) {
            var categorias = dao.Lista()
                .Where(p => p.Categoria.Contains(term))
                .Select(p => new { label = p.Categoria})
                .Distinct();

            return Json(categorias);
        }
    }
}