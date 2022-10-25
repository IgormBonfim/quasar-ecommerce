using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Usuarios.Entidades;
using Quasar.Dominio.Usuarios.Enumeradores;
using Quasar.Dominio.Usuarios.Repositorios;
using Quasar.Dominio.Usuarios.Servicos.Interfaces;

namespace Quasar.Dominio.Usuarios.Servicos
{
    public class ClientesServico : IClientesServico
    {
        private readonly IClientesRepositorio clientesRepositorio;
        public ClientesServico(IClientesRepositorio clientesRepositorio)
        {
            this.clientesRepositorio = clientesRepositorio;
            
        }
        public void Deletar(int codigo)
        {
            Cliente cliente = Validar(codigo);
            clientesRepositorio.Deletar(cliente);
        }

        public Cliente Editar(Cliente cliente)
        {
            Cliente clienteEditar = Validar(cliente.Codigo);

            if (cliente.Nome != clienteEditar.Nome)
                clienteEditar.SetNome(cliente.Nome);

            if (cliente.NomeFantasia != clienteEditar.NomeFantasia) 
                clienteEditar.SetNomeFantasia(cliente.NomeFantasia);

            if (cliente.CpfCnpj != clienteEditar.CpfCnpj) 
                clienteEditar.SetCpfCnpj(cliente.CpfCnpj);

            if (cliente.InscricaoEstadual != clienteEditar.InscricaoEstadual)
                clienteEditar.SetInscricaoEstadual(cliente.InscricaoEstadual);

            return clienteEditar;
        }

        public Cliente Inserir(Cliente cliente)
        {
            int codigo = clientesRepositorio.Inserir(cliente);
            cliente.SetCodigo(codigo);
            return cliente;
        }

        public Cliente Instanciar(string? nome, string? nomeFantasia, string? cpfCnpj, string? inscricaoEstadual, string? razaoSocial, TipoClienteEnum? tipoCliente)
        {
            return new Cliente(nome, nomeFantasia, cpfCnpj, inscricaoEstadual, razaoSocial, tipoCliente);
        }

        public Cliente Validar(int codigo)
        {
            Cliente cliente = clientesRepositorio.Recuperar(codigo);

            if(cliente == null)
                throw new Exception("Cliente não encontrado");
            return cliente;
        }
    }
}