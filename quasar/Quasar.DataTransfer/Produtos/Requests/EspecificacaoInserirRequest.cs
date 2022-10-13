using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Produtos.Requests
{
    public class EspecificacaoInserirRequest
    {
        public string Posicao { get; set; }
        public string Cor { get; set; }
        public DateTime Ano { get; set; }
        public string Veiculo { get; set; }
    }
}