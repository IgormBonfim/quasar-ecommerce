using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.Usuarios.Entidades;
using Quasar.Dominio.Usuarios.Repositorios;
using Quasar.Infra.Genericos;

namespace Quasar.Infra.Usuarios
{
    public class ClientesRepositorio : GenericosRepositorio<Cliente>, IClientesRepositorio
    {
        public ClientesRepositorio(ISession session) : base(session)
        {
            
        }
    }
}