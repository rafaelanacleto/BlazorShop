using BlazorShop.Models.DTOs;
using System.Net.Http.Json;

namespace BlazorShop.Web.Services
{
    public class CarrinhoCompraService : ICarrinhoCompraService
    {
        private readonly HttpClient _restClient;

        public CarrinhoCompraService(HttpClient restClient)
        {
            _restClient = restClient;
        }

        public Task<CarrinhoItemDTO> AdicionaItem(CarrinhoItemAdicionaDTO itemDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CarrinhoItemDTO>> GetItens(int idUsuario)
        {
            try
            {
                var carrinho = await _restClient.GetFromJsonAsync<List<CarrinhoItemDTO>>($"api/CarrinhoCompra/{idUsuario}/GetItens"); 

                return carrinho.ToList();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
