using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Produtos.Repositorios;
using Quasar.Infra.Genericos;

namespace Quasar.Infra.Produtos
{
    public class ProdutosRepositorio : GenericosRepositorio<Produto>, IProdutosRepositorio 
    {
        public ProdutosRepositorio(ISession session) : base(session) {}
    }
}