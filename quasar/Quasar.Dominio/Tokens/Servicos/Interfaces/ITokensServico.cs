using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Quasar.Dominio.Usuarios.Entidades;

namespace Quasar.Dominio.Tokens.Servicos.Interfaces
{
    public interface ITokensServico
    {
        Task<IList<Claim>> ObterClamis(Usuario usuario);
        Task<string> GerarToken(Usuario usuario);
    }
}