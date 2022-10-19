using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Usuarios.Responses
{
    public class UsuarioCadastroResponse
    {
        public bool Sucesso { get; set; }
        public List<string> Erros { get; set; }

        public UsuarioCadastroResponse() =>
            Erros = new List<string>();
        public UsuarioCadastroResponse(bool sucesso = true) :this() =>
            Sucesso = sucesso;
        public void AdicionarErros(IEnumerable<string> erros) =>
            Erros.AddRange(erros);
    }
}