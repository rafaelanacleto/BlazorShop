using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.NewWeb.Models
{
    public interface IMensagem
    {
        bool Enviar(string mensagem);
    }
}