using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Genericos;
using Quasar.Dominio.Produtos.Entidades;

namespace Quasar.Dominio.Produtos.Repositorios
{
    public interface IProdutosRepositorio : IGenericosRepositorio<Produto>{}
}