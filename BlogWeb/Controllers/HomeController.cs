using System.Linq;
using System.Web.Mvc;
using BlogWeb.DAO;


namespace BlogWeb.Controllers
{
    public class HomeController : Controller
    {
        private PostDaoEF dao;

        public HomeController() {
            dao = new PostDaoEF();
        }
        // GET: Home
        public ActionResult Index()
        {
            var posts = dao.Lista()
                .Where(p => p.Publicado).ToList();
            return View(posts);
        }

        public ActionResult Busca(string termo)
        {
            var posts = dao.Lista()
                .Where(p => (p.Publicado) && (p.Titulo.ToLower().Contains(termo.ToLower()) || 
                p.Resumo.ToLower().Contains(termo.ToLower()))).ToList();
            return View("Index", posts);
        }
    }
}