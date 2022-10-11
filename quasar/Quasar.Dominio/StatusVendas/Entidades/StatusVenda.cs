using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.Dominio.StatusVendas.Entidades
{
    public class StatusVenda
    {
        public virtual int CodStatusVenda { get; protected set; }
        public virtual string Descricao { get; protected set; }

        public StatusVenda () {}

        public StatusVenda(string? descricaoStatusVenda)
        {
            SetDescricaoStatusVenda(descricaoStatusVenda);
        }

        public virtual void SetIdStatusVenda (int? codStatusVenda)
        {
            if(!codStatusVenda.HasValue)
            {
                throw new Exception("Código do Status da Venda é obrigatório!");
            }
            CodStatusVenda = codStatusVenda.Value;
        }

        public virtual void SetDescricaoStatusVenda (string? descricao)
        {
            if(string.IsNullOrWhiteSpace(descricao) && descricao.Length < 3)
                throw new Exception("O campo descrição deve possuir ao menos 3 caracteres!");

            if(descricao.Length > 50)
                throw new Exception("O campo descrição deve possuir até 50 caracteres!");

            Descricao = descricao;
        }

    }
}

