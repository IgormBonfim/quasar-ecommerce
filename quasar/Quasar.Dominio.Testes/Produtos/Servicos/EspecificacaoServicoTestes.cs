using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Produtos.Repositorios;
using Quasar.Dominio.Produtos.Servicos;
using Quasar.Dominio.Produtos.Servicos.Interfaces;
using Xunit;

namespace Quasar.Dominio.Testes.Produtos.Servicos
{
    public class EspecificacoesServicoTestes
    {
        private readonly EspecificacoesServico sut;
        private readonly IEspecificacoesRepositorio especificacoesRepositorio;
        private readonly Especificacao especificacaoValido;

        public EspecificacoesServicoTestes()
        {
            especificacaoValido = Builder<Especificacao>.CreateNew().Build();
            especificacoesRepositorio = Substitute.For<IEspecificacoesRepositorio>();
            sut = new EspecificacoesServico(especificacoesRepositorio);
        }
        public class ValidarMetodo : EspecificacoesServicoTestes
        {
            [Fact]
            public void Quando_EspecificacaoNaoForEncontrado_Espero_Exception()
            {
                especificacoesRepositorio.Recuperar(Arg.Any<int>()).Returns(x => null);

                sut.Invoking(x => x.Validar(1)).Should().Throw<Exception>();                
            }
            [Fact]
            public void Quando_EspecificacaoForEncontrado_Espero_EspecificacaoValido()
            {
                especificacoesRepositorio.Recuperar(Arg.Any<int>()).Returns(especificacaoValido);
                sut.Validar(1).Should().BeSameAs(especificacaoValido);                
            }
        }
        public class EditarMetodo : EspecificacoesServicoTestes
        {
            [Fact]
            public void Dado_ParametrosParaEditarEspecificacao_Espero_EspecificacaoEditado()
            {
            //Arrange
            especificacoesRepositorio.Recuperar(Arg.Any<int>()).Returns(especificacaoValido);
            especificacoesRepositorio.Editar(Arg.Any<Especificacao>()).Returns(especificacaoValido);
            var especificacaoNovo = new Especificacao(
                                    "Teste de Posição",
                                    "Teste de Cor",
                                    "2021, 2022",
                                    "Teste de Veiculo");
             //Arc
             var especificacaoEditado = sut.Editar(especificacaoNovo);
             //Assert
             especificacaoEditado.Posicao.Should().Be("Teste de Posição");
             especificacaoEditado.Cor.Should().Be("Teste de Cor");
             especificacaoEditado.Ano.Should().Be("2021, 2022");
             especificacaoEditado.Veiculo.Should().Be("Teste de Veiculo");
            }
        }
        public class InserirMetodo : EspecificacoesServicoTestes
        {
            [Fact]
            public void Dado_EspecificacaoValido_Espero_EspecificacaoValido()
            {
                sut.Inserir(especificacaoValido);
                especificacoesRepositorio.Received(1).Inserir(especificacaoValido);
            }
        }
        public class InstanciarMetodo : EspecificacoesServicoTestes
        {
            [Fact]
            public void Dado_ParametrosParaCriarEspecificacao_Espero_EspecificacaoInstanciado()
            {
                var especificacao = sut.Instanciar(
                                    "Teste de Posição",
                                    "Teste de Cor",
                                    "2021, 2022",
                                    "Teste de Veiculo");
                especificacao.Should().NotBeNull();
            }
        }
    }
}