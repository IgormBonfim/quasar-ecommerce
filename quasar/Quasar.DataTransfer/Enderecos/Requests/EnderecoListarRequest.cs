using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Genericos.Requests;

namespace Quasar.DataTransfer.Enderecos.Requests
{
    public class EnderecoListarRequest : PaginacaoRequest
    {
        public string? CodUsuario {get; set;}        
    }
}