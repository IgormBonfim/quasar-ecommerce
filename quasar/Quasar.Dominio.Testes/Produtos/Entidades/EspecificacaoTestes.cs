using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Quasar.Dominio.Produtos.Entidades;
using Xunit;

namespace Quasar.Dominio.Testes.Produtos.Entidades
{
    public class EspecificacaoTestes
    {
        private readonly Especificacao sut;

        public EspecificacaoTestes()
        {
            sut = Builder<Especificacao>.CreateNew().Build();
        }

        public class Construtor
        {
            [Fact]
            public void Quando_ParametrosForemValidos_Espero_ObjetoIntegro()
            {
                //Arrange
                //Act
                var especificacao = new Especificacao(
                    "Teste de Posição",
                    "Teste de Cor do produto",
                    "2021, 2022",
                    "Teste de Veiculo"
                    );
                //Assert 
                especificacao.Posicao.Should().Be("Teste de Posição");
                especificacao.Cor.Should().Be("Teste de Cor do produto");
                especificacao.Ano.Should().Be("2021, 2022");
                especificacao.Veiculo.Should().Be("Teste de Veiculo");
            }
        }
        public class SetPosicaoMetodo : EspecificacaoTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData(" ")]

            public void Dado_PosicaoNuloOuEspacoEmBranco_Espero_Exception(string posicao)
            {
                sut.Invoking(x => x.SetPosicao(posicao)).Should().Throw<Exception>();
            }                  
            [Fact]
            public void Dado_PosicaoComMenosDeDoisCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetPosicao(new string('*', 1))).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_PosicaoComMaisDeCincoentaCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetPosicao(new string('*', 51))).Should().Throw<Exception>();
            }    
        }
        public class SetCorMetodo : EspecificacaoTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData(" ")]

            public void Dado_CorNuloOuEspacoEmBranco_Espero_Exception(string cor)
            {
                sut.Invoking(x => x.SetCor(cor)).Should().Throw<Exception>();
            }                  
            [Fact]
            public void Dado_CorComMenosDeDoisCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetCor(new string('*', 1))).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_CorComMaisDeVinteCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetCor(new string('*', 21))).Should().Throw<Exception>();
            }                
        }
        public class SetAnoMetodo : EspecificacaoTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData(" ")]

            public void Dado_AnoNuloOuEspacoEmBranco_Espero_Exception(string ano)
            {
                sut.Invoking(x => x.SetAno(ano)).Should().Throw<Exception>();
            }                  
            [Fact]
            public void Dado_AnoComMenosDeTresCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetAno(new string('*', 3))).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_AnoComMaisDeCemCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetAno(new string('*', 101))).Should().Throw<Exception>();
            }                
        }
        public class SetVeiculoMetodo : EspecificacaoTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData(" ")]

            public void Dado_VeiculoNuloOuEspacoEmBranco_Espero_Exception(string veiculo)
            {
                sut.Invoking(x => x.SetVeiculo(veiculo)).Should().Throw<Exception>();
            }                  
            [Fact]
            public void Dado_VeiculoComMenosDeDoisCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetVeiculo(new string('*', 1))).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_VeiculoComMaisDeQuarentaECinco_Espero_Exception()
            {
                sut.Invoking(x => x.SetVeiculo(new string('*', 46))).Should().Throw<Exception>();
            }                
        }
    }
}