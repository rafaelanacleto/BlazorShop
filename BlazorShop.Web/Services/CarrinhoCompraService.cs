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
                //envia um request GET para URI da API CarrinhoCompra
                var resp = await _restClient.GetAsync($"api/CarrinhoCompra/{idUsuario}/GetItens");

                if (resp.IsSuccessStatusCode)
                {
                    if (resp.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CarrinhoItemDTO>().ToList();
                    }

                    return await resp.Content.ReadFromJsonAsync<List<CarrinhoItemDTO>>();
                }
                else
                {
                    var message = await resp.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }                
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
