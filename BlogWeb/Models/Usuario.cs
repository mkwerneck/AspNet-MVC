using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
namespace BlogWeb.Models
{
    public class Usuario : IdentityUser
    {
        public DateTime? UltimoLogin { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}