using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.Enderecos.Entidades;
using Quasar.Dominio.Enderecos.Repositorios;
using Quasar.Infra.Genericos;

namespace Quasar.Infra.Enderecos
{
    public class EnderecosRepositorio :GenericosRepositorio<Endereco>, IEnderecosRepositorio
    {
        public EnderecosRepositorio(ISession session) : base(session) {}
    }
}