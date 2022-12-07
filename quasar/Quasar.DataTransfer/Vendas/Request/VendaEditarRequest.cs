using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Vendas.Request
{
    public class VendaEditarRequest
    {   
        [JsonIgnore]    
        public int? Codigo {get; set;}
        public int CodStatusVenda { get; set; }
        
        [JsonIgnore]
        public string? CodUsuario { get; set; }
        
    }
}