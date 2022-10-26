using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Genericos.Requests;

namespace Quasar.DataTransfer.Cidades.Requests
{
    public class CidadeBuscarRequest : PaginacaoRequest
    {
        public string? Nome {get; set; }
        public int? CodUf { get; set; }
    }
}