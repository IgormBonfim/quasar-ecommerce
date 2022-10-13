using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.Dominio.StatusVendas.Entidades
{
    public class StatusVenda
    {
        public virtual int Codigo { get; protected set; }
        public virtual string Descricao { get; protected set; }

        public StatusVenda () {}

        public StatusVenda(string? descricao)
        {
            SetDescricao(descricao);
        }

        public virtual void SetCodigo (int? codigo)
        {
            if(!codigo.HasValue)
            {
                throw new Exception("Código do Status da Venda é obrigatório!");
            }
            Codigo = codigo.Value;
        }

        public virtual void SetDescricao (string? descricao)
        {
            if(string.IsNullOrWhiteSpace(descricao) && descricao.Length < 3)
                throw new Exception("O campo descrição deve possuir ao menos 3 caracteres!");

            if(descricao.Length > 50)
                throw new Exception("O campo descrição deve possuir até 50 caracteres!");

            Descricao = descricao;
        }

    }
}

