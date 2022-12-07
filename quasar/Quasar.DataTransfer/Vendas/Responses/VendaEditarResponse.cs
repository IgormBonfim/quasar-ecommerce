using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Vendas.Responses
{
    public class VendaEditarResponse
    {
        public int? Codigo {get; set;}
        public StatusVendaResponse StatusVenda { get; set; }
    }
}