﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetVS2017.Capitulo03.Portfolio.Models
{
    public class ContatoViewModel
    {
        
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Mensagem { get; set; }
    }
}