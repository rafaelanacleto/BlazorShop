using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Models.DTOs
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string ImagemUrl { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Preco { get; set; }
        public int Quantidade { get; set; }
        public int CategoriaId { get; set; }

        // public Collection<CarrinhoItem> Itens { get; set; }
        //      = new Collection<CarrinhoItem>();
    }
}