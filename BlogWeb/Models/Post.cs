using System;
using System.ComponentModel.DataAnnotations;

namespace BlogWeb.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required][StringLength(50)][Display(Name = "Título")]
        public string Titulo { get; set; }
        [Required][StringLength(255)] [Display(Name ="Resumo")]
        public string Resumo { get; set; }
        [Display(Name ="Categoria")]
        public string Categoria { get; set; }
        public bool Publicado { get; set; }
        public DateTime? DataPublicacao { get; set; }

        public string AutorId { get; set; }
        public virtual Usuario Autor { get; set; }
    }
}