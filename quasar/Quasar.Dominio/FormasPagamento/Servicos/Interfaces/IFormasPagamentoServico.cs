using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.FormasPagamento.Entidades;

namespace Quasar.Dominio.FormasPagamento.Servicos.Interfaces
{
    public interface IFormasPagamentoServico
    {
        FormaPagamento Validar(int codigo);
        FormaPagamento Instanciar(string? descricao);
        IList<FormaPagamento> Query(IQueryable<FormaPagamento> query);
    }
}