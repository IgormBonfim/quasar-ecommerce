using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.Dominio.FormasPagamento.Entidades
{
    public class FormaPagamento
    {
        public virtual int IdFormaPagamento { get; protected set; }
        public virtual string DescricaoFormaPagamento { get; set; }

        public FormaPagamento()
        {
            
        }

        public virtual void SetIdFormaPagamento(int? id)
        {
            if(!id.HasValue || id.Value <= 0)
                throw new Exception("O campo Id não pode ter um valor inferior a 0!");
        }

        public virtual void SetDescricaoFormaPagamento(string? descricaoFormaPagamento)
        {
            if(string.IsNullOrWhiteSpace(descricaoFormaPagamento))
                throw new Exception("O campo Descrição é obritagtório.");
            DescricaoFormaPagamento = descricaoFormaPagamento;
        }
    }
}