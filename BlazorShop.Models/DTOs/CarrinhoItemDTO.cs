﻿namespace BlazorShop.Models.DTOs
{
    public class CarrinhoItemDTO
    {
        public int Id { get; set; }
        public int CarrinhoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }

        public string ProdutoNome { get; set; } = string.Empty;
        public string ProdutoDescricao { get; set; } = string.Empty;
        public string ProdutoImagemURL { get; set; } = string.Empty;

        public decimal Preco { get; set; }
        public decimal PrecoTotal { get; set; }


    }
}
