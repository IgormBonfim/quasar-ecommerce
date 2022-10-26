using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Cidades.Entidades;
using Quasar.Dominio.Cidades.Repositorios;
using Quasar.Dominio.Cidades.Servicos.Interfaces;
using Quasar.Dominio.Enderecos.Entidades;
using Quasar.Dominio.Enderecos.Repositorios;
using Quasar.Dominio.Enderecos.Servicos.Interfaces;
using Quasar.Dominio.Usuarios.Entidades;
using Quasar.Dominio.Usuarios.Repositorios;
using Quasar.Dominio.Usuarios.Servicos.Interfaces;

namespace Quasar.Dominio.Enderecos.Servicos
{
    public class EnderecosServico : IEnderecosServico
    {
        private readonly IEnderecosRepositorio enderecosRepositorio;
        private readonly ICidadesServico cidadesServico;
        private readonly IUsuariosServico usuariosServico;
        public EnderecosServico(IEnderecosRepositorio enderecosRepositorio, ICidadesServico cidadesServico , IUsuariosServico usuariosServico)
        {
            this.enderecosRepositorio = enderecosRepositorio;
            this.cidadesServico = cidadesServico;
            this.usuariosServico = usuariosServico;
        }
        public void Deletar(int codigo)
        {
            Endereco enderecoDeletar = Validar(codigo);
            enderecosRepositorio.Deletar(enderecoDeletar);
        }

        public Endereco Editar(Endereco endereco)
        {
            Endereco enderecoEditar = Validar(endereco.Codigo);

            if(endereco.Numero != enderecoEditar.Numero)
                enderecoEditar.SetNumero(endereco.Numero);

            if(endereco.Bairro != enderecoEditar.Bairro)
                enderecoEditar.SetBairro(endereco.Bairro);

            if(endereco.Rua != enderecoEditar.Rua)
                enderecoEditar.SetRua(endereco.Rua);

            if(endereco.PontoReferencia != enderecoEditar.PontoReferencia)
                enderecoEditar.SetPontoReferencia(endereco.PontoReferencia);

            if(endereco.Complemento != enderecoEditar.Complemento)
                enderecoEditar.SetComplemento(endereco.Complemento);

            if(endereco.Cep != enderecoEditar.Cep)
                enderecoEditar.SetCep(endereco.Cep);

            if(endereco.Cidade != enderecoEditar.Cidade)
                enderecoEditar.SetCidade(endereco.Cidade);

            if(endereco.Usuario != enderecoEditar.Usuario)
              enderecoEditar.SetUsuario(endereco.Usuario);

            return enderecosRepositorio.Editar(enderecoEditar);
        }

        public Endereco Inserir(Endereco endereco)
        {
            int codigo = enderecosRepositorio.Inserir(endereco);
            endereco.SetCodigo(codigo);
            return endereco;
        }

        public Endereco Instanciar(int numero, string bairro, string rua, string pontoReferencia, string complemento, string cep, int codCidade, string codUsuario)
        {
            Cidade cidade = cidadesServico.Validar(codCidade);
            Usuario usuario = usuariosServico.Validar(codUsuario);

            var endereco = new Endereco(numero, bairro, rua, pontoReferencia, complemento, cep, cidade, usuario);
            return endereco;
        }
        public Endereco Validar(int codigo)
        {
            Endereco enderecoValidar = enderecosRepositorio.Recuperar(codigo);
            if(enderecoValidar == null)
                throw new Exception("Endereço não encontrado.");
            return enderecoValidar;
        }
    }
}