using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Genericos.Responses
{
    public class ListaPaginadaResponse<T> where T : class
    {        
        public int Pagina { get; set; }
        public int Quantidade { get; set; }
        public int TotalPaginas { get; set; }
        public IList<T> Lista { get; set; }
    }
}