using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.Carrinhos.Entidades;
using Quasar.Dominio.Carrinhos.Repositorios;
using Quasar.Infra.Genericos;

namespace Quasar.Infra.Carrinhos
{
    public class CarrinhosRepositorio : GenericosRepositorio<Carrinho>, ICarrinhosRepositorio
    {
        public CarrinhosRepositorio(ISession session) : base(session){}
    }
}