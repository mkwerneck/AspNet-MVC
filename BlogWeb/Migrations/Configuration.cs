namespace BlogWeb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BlogWeb.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogWeb.Infra.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlogWeb.Infra.BlogContext context)
        {
        //    var posts = new List<Post>
        //    {
        //        new Post {Titulo = "HP1", Resumo = "1 Livro", Categoria = "Livros"},
        //        new Post {Titulo = "HP2", Resumo = "2 Livro", Categoria = "Livros"},
        //        new Post {Titulo = "HP3", Resumo = "3 Livro", Categoria = "Livros"}
        //    };

        //    foreach (var p in posts)
        //    {
        //        context.Posts.Add(p);
        //    }
        }
    }
}
