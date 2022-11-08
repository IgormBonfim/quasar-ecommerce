using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Quasar.DataTransfer.Produtos.Requests;
using Quasar.DataTransfer.Usuarios.Requests;

namespace Quasar.DataTransfer.Carrinhos.Requests
{
    public class CarrinhoInserirRequest
    {
        public int Quantidade { get; set; }
        [JsonIgnore]
        public string? CodUsuario { get; set; }
        public int CodProduto { get; set; }
    }
}