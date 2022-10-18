using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Quasar.DataTransfer.Usuarios.Responses;

namespace Quasar.Autenticacao.Servicos.Interfaces
{
    public interface IJwtServico
    {
        Task<UsuarioLoginResponse> GerarToken(IdentityUser usuario);
    }
}