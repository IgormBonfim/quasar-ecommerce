using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Genericos.Requests
{
    public class PaginacaoRequest
    {
        public int Pagina { get; set; } = 1;
        public int QuantidadePorPagina { get; set; } = 20;
    }
}