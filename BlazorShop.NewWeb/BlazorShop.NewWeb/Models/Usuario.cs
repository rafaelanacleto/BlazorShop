using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.NewWeb.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "Email é requirido")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string? Email { get; set; }
        public string? Senha { get; set; }
        
    }
}