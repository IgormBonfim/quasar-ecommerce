using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Quasar.Aplicacao.Genericos.Servicos.Interfaces;

namespace Quasar.Aplicacao.Genericos.Servicos
{
    public class Usuario : IUsuario
    {
        public string UsuarioLogado(HttpContext context)
        {
            string? id = context.User.FindFirst("codUsuario").Value;

            if (id == null)
                throw new Exception("Nenhum usuario está logado");
            return id;
        }
    }
}