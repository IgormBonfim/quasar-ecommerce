using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.FormasPagamento.Entidades;
using Quasar.Dominio.FormasPagamento.Repositorios;
using Quasar.Dominio.FormasPagamento.Servicos.Interfaces;

namespace Quasar.Dominio.FormasPagamento.Servicos
{
    public class FormasPagamentoServico : IFormasPagamentoServico
    {
        private readonly IFormasPagamentoRepositorio formasPagamentoRepositorio;

        public FormasPagamentoServico(IFormasPagamentoRepositorio formasPagamentoRepositorio)
        {
            this.formasPagamentoRepositorio = formasPagamentoRepositorio;
        }
        public FormaPagamento Instanciar(string? descricao)
        {
            return new FormaPagamento(descricao);
        }

        public IList<FormaPagamento> Query(IQueryable<FormaPagamento> query)
        {
            return query.ToList();
        }

        public FormaPagamento Validar(int id)
        {
            FormaPagamento formaPagamento = formasPagamentoRepositorio.Recuperar(id);
            if(formaPagamento == null)
                throw new Exception("Forma de pagamento não encontrada.");
            return formaPagamento;
        }
    }
}