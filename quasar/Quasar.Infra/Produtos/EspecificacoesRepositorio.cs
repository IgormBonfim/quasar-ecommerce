using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Produtos.Repositorios;

namespace Quasar.Infra.Produtos
{
    public class EspecificacoesRepositorio : IEspecificacoesRepositorio
    {
        private readonly ISession session;
        public EspecificacoesRepositorio(ISession session)
        {
            this.session = session;
        }
        public void Deletar(Especificacao especificacao)
        {
            session.Delete(especificacao);
        }

        public Especificacao Editar(Especificacao especificacao)
        {
            session.Update(especificacao);
            return especificacao;
        }

        public Especificacao Inserir(Especificacao especificacao)
        {
            int codigo = (int)session.Save(especificacao);
            especificacao.SetCodigo(codigo);
            return especificacao;
        }

        public IQueryable<Especificacao> Query()
        {
            return session.Query<Especificacao>();
        }

        public Especificacao Recuperar(int codigo)
        {
            return session.Get<Especificacao>(codigo);
        }
    }
}