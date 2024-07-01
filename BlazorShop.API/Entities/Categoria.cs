using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorShop.API.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        [MaxLength(100)] //usado antes de criar as tabelas do banco
        public string Nome { get; set; } = string.Empty;
        public string IconCSS { get; set; } = string.Empty;

        //public Collection<Produtos> Produtos { get; set; } = new Collection<Produtos>();
    }
}
