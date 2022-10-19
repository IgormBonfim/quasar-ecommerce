using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Cidades.Requests
{
    public class CidadeBuscarRequest
    {
        public string? Nome {get; set; }
        public int? CodUf { get; set; }
    }
}