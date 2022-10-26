using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Cidades.Responses;

namespace Quasar.DataTransfer.Enderecos.Requests
{
    public class EnderecoEditarRequest
    {
        public int? Codigo {get; set;}
        public int? Numero {get; set;}
        public string? Bairro {get; set;}
        public string Rua {get; set;}
        public string? PontoReferencia {get; set;}
        public string? Complemento {get; set;}
        public string? Cep {get; set;}
        public int? CodigoCidade {get; set;}
        public string CodigoUsuario {get; set;}        
    }
}