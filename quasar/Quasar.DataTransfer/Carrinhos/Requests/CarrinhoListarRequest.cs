using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Genericos.Requests;

namespace Quasar.DataTransfer.Carrinhos.Requests
{
    public class CarrinhoListarRequest : PaginacaoRequest
    {
        public int? Codigo { get; set; }
    }
}