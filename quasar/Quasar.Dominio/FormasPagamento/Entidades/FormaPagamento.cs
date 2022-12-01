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
                throw new Exception("O campo codigo não pode ter um valor inferior a 0!");
            Codigo = codigo.Value;
        }

        public virtual void SetDescricao(string? descricao)
        {
            if(string.IsNullOrWhiteSpace(descricao))
                throw new Exception("O campo Descrição é obritagtório.");
            Descricao = descricao;
        }
    }
}