using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.Dominio.StatusVendas.Entidades
{
    public class StatusVenda
    {
        public virtual int IdStatusVenda { get; protected set; }
        public virtual string DescricaoStatusVenda { get; protected set; }

        public StatusVenda () {}

        public StatusVenda(string? DescricaoStatusVenda)
        {
            SetDescricaoStatusVenda(DescricaoStatusVenda);
        }

        public virtual void SetIdStatusVenda (int? idStatusVenda)
        {
            if(!idStatusVenda.HasValue)
            {
                throw new Exception("Código do Status da Venda é obrigatório!");
            }
            IdStatusVenda = idStatusVenda.Value;
        }

        public virtual void SetDescricaoStatusVenda (string? descricaoStatusVenda)
        {
            if(string.IsNullOrWhiteSpace(descricaoStatusVenda) && descricaoStatusVenda.Length < 20)
                throw new Exception("O campo descrição deve possuir ao menos 20 caracteres!");

            if(descricaoStatusVenda.Length > 50)
                throw new Exception("O campo descrição deve possuir até 50 caracteres!");

            DescricaoStatusVenda = descricaoStatusVenda;
        }

    }
}

