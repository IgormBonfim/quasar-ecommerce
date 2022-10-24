using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Fornecedores.Entidades;
using Quasar.Dominio.Fornecedores.Repositorios;
using Quasar.Dominio.Fornecedores.Servicos.Interfaces;

namespace Quasar.Dominio.Fornecedores.Servicos
{
    public class FornecedoresServico : IFornecedoresServico
    {
        private readonly IFornecedoresRepositorio fornecedoresRepositorio;

        public FornecedoresServico(IFornecedoresRepositorio FornecedoresRepositorio)
        {
            fornecedoresRepositorio = FornecedoresRepositorio;
        }
        public void Deletar(int codigo)
        {
            Fornecedor fornecedorDeletar = Validar(codigo);
            fornecedoresRepositorio.Deletar(fornecedorDeletar);
        }

        public Fornecedor Editar(Fornecedor fornecedor)
        {
            Fornecedor fornecedorEditar = Validar(fornecedor.Codigo);

            if(fornecedor.Nome != fornecedorEditar.Nome)
                fornecedorEditar.SetNome(fornecedor.Nome);

            if(fornecedor.RazaoSocial != fornecedorEditar.RazaoSocial)
                fornecedorEditar.SetRazaoSocial(fornecedor.RazaoSocial);

            if(fornecedor.Cnpj != fornecedorEditar.Cnpj)
                fornecedorEditar.SetCnpj(fornecedor.Cnpj);

            if(fornecedor.Ie != fornecedorEditar.Ie)
                fornecedorEditar.SetIe(fornecedor.Ie);

            return fornecedoresRepositorio.Editar(fornecedorEditar);
        }

        public Fornecedor Inserir(Fornecedor fornecedor)
        {
            int codigo = fornecedoresRepositorio.Inserir(fornecedor);
            fornecedor.SetCodigo(codigo);
            return fornecedor;
        }
        
        public Fornecedor Instanciar(string? nome, string? razaoSocial, string? cnpj, string? ie)
        {
            var fornecedor = new Fornecedor(nome, razaoSocial, cnpj, ie);
            return fornecedor;
        }

        public Fornecedor Validar(int codigo)
        {
            Fornecedor fornecedorValidar = fornecedoresRepositorio.Recuperar(codigo);
            if(fornecedorValidar == null)
                throw new Exception("Fornecedor não encontrado.");
            return fornecedorValidar;
        }

        IList<Fornecedor> IFornecedoresServico.Listar(IQueryable<Fornecedor> query)
        {
            return query.ToList();
        }
    }
}