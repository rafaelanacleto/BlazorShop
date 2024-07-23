using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlazorShop.API.Entities;
using BlazorShop.Models.DTOs;

namespace BlazorShop.API.Mappings
{
    public static class DomainToDTOMappingProfile
    {

        public static IEnumerable<CategoriaDTO> ConverterCategoriasParaDto(
                                            this IEnumerable<Categoria> categorias)
    {
        return (from categoria in categorias
                select new CategoriaDTO
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome,
                    IconCSS = categoria.IconCSS
                }).ToList();
    }
    public static IEnumerable<ProdutosDTO> ConverterProdutosParaDto(
                                         this IEnumerable<Produtos> produtos)
    {
        return (from produto in produtos
                select new ProdutosDTO
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    ImagemUrl = produto.ImagemUrl,
                    Preco = produto.Preco,
                    Quantidade = produto.Quantidade,
                    CategoriaId = produto.Categoria.Id,
                    CategoriaNome = produto.Categoria.Nome
                }).ToList();
    }
    public static ProdutosDTO ConverterProdutoParaDto(this Produtos produto)
    {
        return new ProdutosDTO
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            ImagemUrl = produto.ImagemUrl,
            Preco = produto.Preco,
            Quantidade = produto.Quantidade,
            CategoriaId = produto.Categoria.Id,
            CategoriaNome = produto.Categoria.Nome
        };
    }

    public static IEnumerable<CarrinhoItemDTO> ConverterCarrinhoItensParaDto(
        this IEnumerable<CarrinhoItem> carrinhoItens,IEnumerable<Produtos> produtos)
    {
        return (from carrinhoItem in carrinhoItens
                join produto in produtos
                on carrinhoItem.ProdutoId equals produto.Id
                select new CarrinhoItemDTO
                {
                    Id = carrinhoItem.Id,
                    ProdutoId = carrinhoItem.ProdutoId,
                    ProdutoNome = produto.Nome,
                    ProdutoDescricao = produto.Descricao,
                    ProdutoImagemURL = produto.ImagemUrl,
                    Preco = produto.Preco,
                    CarrinhoId = carrinhoItem.CarrinhoId,
                    Quantidade = carrinhoItem.Quantidade,
                    PrecoTotal = produto.Preco * carrinhoItem.Quantidade
                }).ToList();
    }

    public static CarrinhoItemDTO ConverterCarrinhoItemParaDto(this CarrinhoItem carrinhoItem,
                                               Produtos produto)
    {
        return new CarrinhoItemDTO
        {
            Id = carrinhoItem.Id,
            ProdutoId = carrinhoItem.ProdutoId,
            ProdutoNome = produto.Nome,
            ProdutoDescricao = produto.Descricao,
            ProdutoImagemURL = produto.ImagemUrl,
            Preco = produto.Preco,
            CarrinhoId = carrinhoItem.CarrinhoId,
            Quantidade = carrinhoItem.Quantidade,
            PrecoTotal = produto.Preco * carrinhoItem.Quantidade
        };
    }
    }
}