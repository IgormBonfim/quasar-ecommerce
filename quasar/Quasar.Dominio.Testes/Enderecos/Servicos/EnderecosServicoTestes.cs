using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;
using Quasar.Dominio.Cidades.Entidades;
using Quasar.Dominio.Cidades.Servicos.Interfaces;
using Quasar.Dominio.Enderecos.Entidades;
using Quasar.Dominio.Enderecos.Repositorios;
using Quasar.Dominio.Enderecos.Servicos;
using Quasar.Dominio.Usuarios.Entidades;
using Quasar.Dominio.Usuarios.Servicos.Interfaces;
using Xunit;

namespace Quasar.Dominio.Testes.Enderecos.Servicos
{
    public class EnderecosServicoTestes
    {
        private readonly EnderecosServico sut;
        private readonly IEnderecosRepositorio enderecosRepositorio;
        private readonly ICidadesServico cidadesServico;
        private readonly IUsuariosServico usuarioServico;
        private readonly Endereco enderecoValido;
        private readonly Cidade cidadeValida;
        private readonly Usuario usuarioValido;

        public EnderecosServicoTestes()
        {
            enderecoValido = Builder<Endereco>.CreateNew().Build();
            cidadeValida = Builder<Cidade>.CreateNew().Build();
            usuarioValido = Builder<Usuario>.CreateNew().Build();

            sut = new EnderecosServico(enderecosRepositorio, cidadesServico, usuarioServico);
        }
                public class ValidarMetodo : EnderecosServicoTestes
        {
            [Fact]
            public void Quando_EnderecoNaoEncontrado_Espero_Exception()
            {
                enderecosRepositorio.Recuperar(Arg.Any<int>()).Returns(x => null);

                sut.Invoking(x => x.Validar(1)).Should().Throw<Exception>();
            }

            [Fact]
            public void Quando_EnderecoEncontrado_Espero_EnderecoValido()
            {
                enderecosRepositorio.Recuperar(Arg.Any<int>()).Returns(enderecoValido);

                sut.Validar(1).Should().BeSameAs(enderecoValido);
            }
        }

        public class InstanciarMetodo : EnderecosServicoTestes
        {
            [Fact]
            public void Dado_ParametrosParaCriarEndereco_Espero_EnderecoInstanciado()
            {
                var endereco = sut.Instanciar(
                    21,
                    "Teste de nome do bairro",
                    "Teste de nome da rua",
                    "Teste de ponto de referencia",
                    "Teste de complemento",
                    "25101493",
                    1,
                    "1");

                endereco.Should().NotBeNull();
            }
        }

        public class InserirMetodo : EnderecosServicoTestes
        {
            [Fact]
            public void Dado_EnderecoValido_Espero_EnderecoValido()
            {
                sut.Inserir(enderecoValido);
                enderecosRepositorio.Received(1).Inserir(enderecoValido);
            }
        }

        public class EditarMetodo : EnderecosServicoTestes
        {
            [Fact]
            public void Dado_ParametrosParaEditarEndereco_Espero_EnderecoEditado()
            {
                //Arrange
                enderecosRepositorio.Recuperar(Arg.Any<int>()).Returns(enderecoValido);
                enderecosRepositorio.Editar(Arg.Any<Endereco>()).Returns(enderecoValido);
                var enderecoNovo = new Endereco( 
                    21,
                    "Teste de nome do bairro",
                    "Teste de nome da rua",
                    "Teste de ponto de referencia",
                    "Teste de complemento",
                    "25101493",
                    cidadeValida,
                    usuarioValido
                    );

                //Act 
                var enderecoEditado = sut.Editar(enderecoNovo);

                //Assert 
                enderecoEditado.Numero.Should().Be(21);
                enderecoEditado.Bairro.Should().Be("Teste de nome do bairro");
                enderecoEditado.Rua.Should().Be("Teste de nome da rua");
                enderecoEditado.PontoReferencia.Should().Be("Teste de ponto de referencia");
                enderecoEditado.Complemento.Should().Be("Teste de complemento");
                enderecoEditado.Cep.Should().Be("25101493");
                enderecoEditado.Cidade.Should().BeSameAs(enderecoNovo.Cidade);
                enderecoEditado.Usuario.Should().BeSameAs(enderecoNovo.Usuario);
            }
        }
    }
}