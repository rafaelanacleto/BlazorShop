using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.API.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? NomeUsuario { get; set; }

        public Carrinho? Carrinho{ get; set; } = null;
    }
}