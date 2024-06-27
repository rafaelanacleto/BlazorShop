using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.Models.DTOs
{
    public class CarrinhoDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
    }
}
