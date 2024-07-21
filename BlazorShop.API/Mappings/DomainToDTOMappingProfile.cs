using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlazorShop.API.Entities;
using BlazorShop.Models.DTOs;

namespace BlazorShop.API.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<ProdutosDTO, Produtos>().ReverseMap();
            CreateMap<Carrinho, CarrinhoDTO>().ReverseMap();
            CreateMap<CarrinhoItem, CarrinhoItemDTO>().ReverseMap();
            
        }
    }
}