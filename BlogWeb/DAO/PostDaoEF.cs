using BlogWeb.Models;
using BlogWeb.Infra;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Diagnostics;

namespace BlogWeb.DAO
{
    public class PostDaoEF
    {
        private BlogContext ctx;
        public PostDaoEF()
        {
            ctx = new BlogContext();
            ctx.Database.Log = LogarSQL;
        }

        public IList<Post> Lista()
        {
            return ctx.Posts.ToList();
        }

        public void Incluir(Post post)
        {
            ctx.Posts.Add(post);
            ctx.SaveChanges();
        }

        public void Remover(int id)
        {
            var post = ctx.Posts.First(p => p.Id == id);
            ctx.Posts.Remove(post);
            ctx.SaveChanges();
        }

        public void Alterar(Post post)
        {
            ctx.Entry(post).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public Post BuscaPorId(int id)
        {
            return ctx.Posts.FirstOrDefault(p => p.Id == id);
        }

        private void LogarSQL(string sql)
        {
            Debug.WriteLine(sql);
        }
    }
}