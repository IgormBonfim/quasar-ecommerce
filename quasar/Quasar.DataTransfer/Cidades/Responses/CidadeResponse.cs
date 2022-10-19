using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Ufs.Responses;

namespace Quasar.DataTransfer.Cidades.Responses
{
    public class CidadeResponse
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public UfResponse Uf { get; set; }
    }
}