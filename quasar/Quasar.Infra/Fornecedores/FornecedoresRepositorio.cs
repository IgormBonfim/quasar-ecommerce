using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.Fornecedores.Entidades;
using Quasar.Dominio.Fornecedores.Repositorios;

namespace Quasar.Infra.Fornecedores
{
    public class FornecedoresRepositorio : IFornecedoresRepositorio
    {
        private readonly ISession session;

        public FornecedoresRepositorio(ISession session)
        {
            this.session = session;
        }
        public void Deletar(Fornecedor fornecedor)
        {
            session.Delete(fornecedor);
        }

        public Fornecedor Editar(Fornecedor fornecedor)
        {
            session.Update(fornecedor);
            return fornecedor;
        }

        public Fornecedor Inserir(Fornecedor fornecedor)
        {
            int id = (int)session.Save(fornecedor);
            fornecedor.SetIdFornecedor(id);
            return fornecedor;
        }

        public IQueryable<Fornecedor> Query()
        {
            return session.Query<Fornecedor>();
        }

        public Fornecedor Recuperar(int id)
        {
            return session.Get<Fornecedor>(id);
        }
    }
}