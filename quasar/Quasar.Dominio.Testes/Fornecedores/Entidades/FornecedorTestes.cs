using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Quasar.Dominio.Fornecedores.Entidades;
using Xunit;

namespace Quasar.Dominio.Testes.Fornecedores.Entidades
{
    public class FornecedorTestes
    {
        private readonly Fornecedor sut;
        public FornecedorTestes()
        {
            sut = Builder<Fornecedor>.CreateNew().Build();
        }

        public class Construtor
        {
            [Fact]
            public void Quando_ParametrosForemValidos_Espero_ObjetoIntegro()
            {
                //Act
                var fornecedor = new Fornecedor(
                                    "Nome de um fornecedor",
                                    "578330008",
                                    "48567902000130",
                                    "785955070"
                                );

                //Assert
                fornecedor.Nome.Should().Be("Nome de um fornecedor");
                fornecedor.RazaoSocial.Should().Be("578330008");
                fornecedor.Cnpj.Should().Be("48567902000130");
                fornecedor.Ie.Should().Be("785955070");
            }
        }

        public class SetNomeMetodo : FornecedorTestes
        {
            [Theory]
            [InlineData("")]
            [InlineData(" ")]
            [InlineData(null)]
            public void Dado_NomeNuloOuEspacoEmBranco_Espero_Exception(string nome)
            {
                sut.Invoking(x => x.SetNome(new string(nome))).Should().Throw<Exception>();
            }
        }

        public class SetRazaoSocialMetodo : FornecedorTestes
        {
            [Theory]
            [InlineData("")]
            [InlineData(" ")]
            [InlineData(null)]
            public void Dado_RazaoSocialNulaOuEspacoEmBranco_Espero_Exception(string razaoSocial)
            {
                sut.Invoking(x => x.SetRazaoSocial(new string(razaoSocial))).Should().Throw<Exception>();
            }
        }

        public class SetCnpjMetodo : FornecedorTestes
        {
            [Theory]
            [InlineData("")]
            [InlineData(" ")]
            [InlineData(null)]
            public void Dado_CnpjNuloOuEspacoEmBranco_Espero_Exception(string cnpj)
            {
                sut.Invoking(x => x.SetCnpj(new string(cnpj))).Should().Throw<Exception>();
            }
        }

        public class SetIeMetodo : FornecedorTestes
        {
            [Theory]
            [InlineData("")]
            [InlineData(" ")]
            [InlineData(null)]
            public void Dado_IeNuloOuEspacoEmBranco_Espero_Exception(string ie)
            {
                sut.Invoking(x => x.SetIe(new string(ie))).Should().Throw<Exception>();
            }
        }
    }
}