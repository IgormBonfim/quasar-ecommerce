using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Genericos.Requests
{
    public class PaginacaoRequest
    {
        public int Pagina { get; set; }
        public int QuantidadePorPagina { get; set; }
        public int TotalPaginas { get; set; }
    }
}