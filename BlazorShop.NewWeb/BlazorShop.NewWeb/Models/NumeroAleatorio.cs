using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.NewWeb.Models
{
    public class NumeroAleatorio
    {
        public int NumeroIdentificador { get; set; }

        public NumeroAleatorio()
        {
            Random rnd = new Random();
            NumeroIdentificador = rnd.Next(1, 100);
        }
    }
}