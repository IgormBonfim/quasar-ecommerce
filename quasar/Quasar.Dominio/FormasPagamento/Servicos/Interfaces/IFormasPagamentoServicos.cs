using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.FormasPagamento.Entidades;

namespace Quasar.Dominio.FormasPagamento.Servicos.Interfaces
{
    public interface IFormasPagamentoServicos
    {
        FormaPagamento Validar(int id);
    }
}