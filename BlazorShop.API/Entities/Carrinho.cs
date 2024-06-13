using System.Collections.ObjectModel;

namespace BlazorShop.API.Entities
{
    public class Carrinho
    {
         public int Id { get; set; }
         public int UsuarioId { get; set; }

         public Collection<CarrinhoItem> Itens { get; set;}
             = new Collection<CarrinhoItem>();
    }
}
