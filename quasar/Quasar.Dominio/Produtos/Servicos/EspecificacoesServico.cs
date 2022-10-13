using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Produtos.Repositorios;
using Quasar.Dominio.Produtos.Servicos.Interfaces;

namespace Quasar.Dominio.Produtos.Servicos
{
    public class EspecificacoesServico : IEspecificacoesServico
    {
        private readonly IEspecificacoesRepositorio especificacoesRepositorio;

        public EspecificacoesServico(IEspecificacoesRepositorio especificacoesRepositorio)
        {
            this.especificacoesRepositorio = especificacoesRepositorio;
        }
        public void Deletar(int codEspecificacao)
        {
            Especificacao especificacaoDeletar = Validar(codEspecificacao);
            especificacoesRepositorio.Deletar(especificacaoDeletar);
        }

        public Especificacao Editar(Especificacao especificacao)
        {
            Especificacao especificacaoEditar = Validar(especificacao.Codigo);

            if(especificacao.Posicao != especificacaoEditar.Posicao)
                especificacaoEditar.SetPosicao(especificacao.Posicao);

            if(especificacao.Cor != especificacaoEditar.Cor)
                especificacaoEditar.SetCor(especificacao.Cor);

            if(especificacao.Ano != especificacaoEditar.Ano)
                especificacaoEditar.SetAno(especificacao.Ano);

            if(especificacao.Veiculo != especificacaoEditar.Veiculo)
                especificacaoEditar.SetVeiculo(especificacao.Veiculo);

            return especificacoesRepositorio.Editar(especificacaoEditar);
        }

        public Especificacao Inserir(Especificacao especificacao)
        {
            return especificacoesRepositorio.Inserir(especificacao);
        }

        public Especificacao Instanciar(string? posicao, string? cor, DateTime? ano, string? veiculo)
        {
            Especificacao especificacao = new Especificacao(posicao, cor, ano, veiculo);
            return especificacao;
        }

        public Especificacao Validar(int cod)
        {
            Especificacao especificacaoValidar = especificacoesRepositorio.Recuperar(cod);
            if(especificacaoValidar == null)
                throw new Exception("Especificacao não encontrado.");
            return especificacaoValidar;
        }
    }
}