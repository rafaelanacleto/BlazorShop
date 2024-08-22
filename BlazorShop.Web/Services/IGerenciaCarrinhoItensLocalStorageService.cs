using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services
{
    public interface IGerenciaCarrinhoItensLocalStorageService
    {
        Task<List<CarrinhoItemDTO>> GetCollection();
        Task SaveCollection(List<CarrinhoItemDTO> carrinhoItensDto);
        Task RemoveCollection();
    }
}