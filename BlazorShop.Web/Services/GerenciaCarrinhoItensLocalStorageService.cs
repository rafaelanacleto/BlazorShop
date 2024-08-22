using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services
{
    public class GerenciaCarrinhoItensLocalStorageService : IGerenciaCarrinhoItensLocalStorageService
    {
        public Task<List<CarrinhoItemDTO>> GetCollection()
        {
            throw new NotImplementedException();
        }

        public Task RemoveCollection()
        {
            throw new NotImplementedException();
        }

        public Task SaveCollection(List<CarrinhoItemDTO> carrinhoItensDto)
        {
            throw new NotImplementedException();
        }
    }
}