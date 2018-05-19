using System.Data.Entity;
using BlogWeb.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogWeb.Infra
{
    public class BlogContext : IdentityDbContext
    {
        public DbSet<Post> Posts { get; set; }

        public BlogContext() : base("name=blog")
        {
        }
    }
}