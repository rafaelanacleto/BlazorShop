﻿namespace BlazorShop.API.Entities
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string ImagemUrl { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Quantidade { get; set; } 


    }
}
