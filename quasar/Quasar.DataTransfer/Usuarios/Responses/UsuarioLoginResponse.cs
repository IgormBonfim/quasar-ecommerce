using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Usuarios.Responses
{
    public class UsuarioLoginResponse
    {
        public bool Sucesso { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Token { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Erro { get; set; }

        public UsuarioLoginResponse(bool sucesso = false)
        {
            Sucesso = sucesso;
        }

        public UsuarioLoginResponse(bool sucesso, string token) : this(sucesso)
        {
            Token = token;
        }
    }
}