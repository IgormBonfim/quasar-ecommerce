using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.Estoques.Entidades;
using Quasar.Dominio.Estoques.Respositorios;

namespace Quasar.Infra.Estoques
{
    public class EstoquesRepositorio : IEstoquesRepositorio
    {
        private readonly ISession session;

        public EstoquesRepositorio(ISession session)
        {
            this.session = session;
        }

        public Estoque Inserir(Estoque estoque)
        {
            int codigo = (int)session.Save(estoque);
            estoque.SetCodigo(codigo);
            return estoque;
        }

        public Estoque Editar(Estoque estoque)
        {
            session.Update(estoque);
            return estoque;
        }

        public Estoque Recuperar(int codigo)
        {
            return session.Get<Estoque>(codigo);

        }

        public IQueryable<Estoque> Query()
        {
            return session.Query<Estoque>();;
        }

        public Estoque Recuperar(Estoque estoque)
        {
            throw new NotImplementedException();
        }
    }
}