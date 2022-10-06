using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Categorias.Requests
{
    public class CategoriaEditarRequest
    {
        public int? IdCategoria {get; set;}
        public string? NomeCategoria {get; set;}
        public string? ImgCategoria {get; set;}
    }
}