using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.Dominio.FormasPagamento.Entidades
{
    public class FormaPagamento
    {
        public virtual int Codigo { get; protected set; }
        public virtual string Descricao { get; set; }

        public FormaPagamento()
        {
            
        }

        public FormaPagamento(string? descricao)
        {
            SetDescricao(descricao);
        }

        public virtual void SetCodigo(int? codigo)
        {
            if(!codigo.HasValue || codigo.Value <= 0)
                throw new Exception("O campo Id não pode ter um valor inferior a 0!");
        }

        public virtual void SetDescricao(string? descricao)
        {
            if(string.IsNullOrWhiteSpace(descricao))
                throw new Exception("O campo Descrição é obritagtório.");
            Descricao = descricao;
        }
    }
}