using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Categorias.Requests
{
    public class CategoriaEditarRequest
    {
        [JsonIgnore]
        public int? Codigo {get; set;}
        public string? Nome {get; set;}
        public string? Imagem {get; set;}
    }
}