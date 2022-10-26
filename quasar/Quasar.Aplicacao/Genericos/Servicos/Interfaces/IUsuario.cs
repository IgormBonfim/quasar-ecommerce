using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Quasar.Aplicacao.Genericos.Servicos.Interfaces
{
    public interface IUsuario
    {
        string UsuarioLogado(HttpContext context);
    }
}