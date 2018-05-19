﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BlogWeb.Models.ViewModels
{
    public class RegistroViewModel
    {
        [Required]
        [Display(Name = "Usuário")]
        public string LoginName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Senha")]
        [Display(Name = "Confirmação de Senha")]
        public string ConfirmacaoSenha { get; set; }
    }
}