using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Usuarios.Responses
{
    public class UsuarioCadastroResponse
    {
        public bool Sucesso { get; set; }
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Erro { get; set; }

        public UsuarioCadastroResponse(bool sucesso = true)
        {
            Sucesso = sucesso;
        }

        public void AdicionarErro(string erro)
        {
            Erro = erro;
        }
    }
}