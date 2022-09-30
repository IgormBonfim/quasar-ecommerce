using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.FormasPagamento.Entidades;

namespace Quasar.Dominio.FormasPagamento.Repositorios
{
    public interface IFormasPagamentoRepositorio
    {
        FormaPagamento Recuperar(int id);
        IQueryable<FormaPagamento> Query();
    }
}