using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Genericos.Requests;

namespace Quasar.DataTransfer.Categorias.Requests
{
    public class CategoriaBuscarRequest : PaginacaoRequest
    {
        public int? Codigo {get; set;}
        public string? Nome {get; set;}
    }
}