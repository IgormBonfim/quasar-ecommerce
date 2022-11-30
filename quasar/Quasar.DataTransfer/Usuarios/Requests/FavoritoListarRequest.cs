using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Usuarios.Requests
{
    public class FavoritoListarRequest
    {
        [JsonIgnore]
        public string? codUsuario { get; set; }

    }
}