using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.Dominio.Produtos.Entidades
{
    public class Especificacao
    {
        public virtual int Codigo { get; protected set; }
        public virtual string Posicao { get; protected set; }
        public virtual string Cor { get; protected set; }
        public virtual string Ano { get; protected set; }
        public virtual string Veiculo { get; protected set; }

        public Especificacao() { }
        public Especificacao(string? posicao, string? cor, string? ano, string? veiculo)
        {
            SetPosicao(posicao);
            SetCor(cor);
            SetAno(ano);
            SetVeiculo(veiculo);
        }

        public virtual void SetCodigo(int? codigo)
        {
            if(!codigo.HasValue || codigo <= 0)
            {
                throw new Exception("Código da especificacao é obrigatório!");
            }
            Codigo = codigo.Value;
        }
        public virtual void SetPosicao(string? posicao)
        {
            if(string.IsNullOrWhiteSpace(posicao) || posicao.Length < 2)
            throw new Exception("O campo posicao deve possuir no mínimo 2 caracteres!");
            if(posicao.Length > 50)
                throw new Exception ("O campo posicao deve possuir no máximo 50 caracteres!");
            Posicao = posicao;
        }
        public virtual void SetCor(string? cor)
        {
            if(string.IsNullOrWhiteSpace(cor) || cor.Length < 2)
                throw new Exception ("O campo cor deve possuir no mínimo 2 caracteres!");
            if(cor.Length > 20)
                throw new Exception ("O campo cor deve possuir no máximo 20 caracteres!");
            
            Cor = cor;
        }
        public virtual void SetAno(string? ano)
        {
            if(string.IsNullOrWhiteSpace(ano) || ano.Length < 4)
                throw new Exception ("O campo ano deve possuir no mínimo 4 caracteres!");
            if(ano.Length > 100)
                throw new Exception ("O campo ano deve possuir no máximo 100 caracteres!");
            Ano = ano;
        }
        public virtual void SetVeiculo(string? veiculo)
        {
            if(string.IsNullOrWhiteSpace(veiculo) || veiculo.Length < 2)
                throw new Exception ("O campo veiculo deve possuir no mínimo 2 caracteres!");
            if(veiculo.Length > 45)
                throw new Exception ("O campo veiculo deve possuir no máximo 45 caracteres!");
            Veiculo = veiculo;
        }
    }
}