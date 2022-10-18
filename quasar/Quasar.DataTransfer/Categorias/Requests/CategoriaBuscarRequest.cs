using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Categorias.Requests
{
    public class CategoriaBuscarRequest
    {
        public int? Codigo {get; set;}
        public string? Nome {get; set;}
    }
}