using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quasar.Autenticacao.Entidades;

namespace Quasar.Autenticacao.Data
{
    //Classe de contexto (Classe que faz a configuração do Entity Framework com banco de dados)
    public class IdentityDataContext : IdentityDbContext<Usuario>
    {
        public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options) { }
    }
}