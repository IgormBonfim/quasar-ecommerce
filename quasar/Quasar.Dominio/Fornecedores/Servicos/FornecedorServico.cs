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
        public void Deletar(int idFornecedor)
        {
            Fornecedor fornecedorDeletar = Validar(idFornecedor);
            fornecedoresRepositorio.Deletar(fornecedorDeletar);
        }

        public Fornecedor Editar(Fornecedor fornecedor)
        {
            Fornecedor fornecedorEditar = Validar(fornecedor.IdFornecedor);

            if(fornecedor.NomeFornecedor != fornecedorEditar.NomeFornecedor)
                fornecedorEditar.SetNomeFornecedor(fornecedorEditar.NomeFornecedor);

            if(fornecedor.RazaoSocialFornecedor != fornecedorEditar.RazaoSocialFornecedor)
                fornecedorEditar.SetRazaoSocialFornecedor(fornecedorEditar.RazaoSocialFornecedor);

            if(fornecedor.CnpjFornecedor != fornecedorEditar.CnpjFornecedor)
                fornecedorEditar.SetCnpjFornecedor(fornecedorEditar.CnpjFornecedor);

            if(fornecedor.IeFornecedor != fornecedorEditar.IeFornecedor)
                fornecedorEditar.SetIeFornecedor(fornecedorEditar.IeFornecedor);

            return fornecedoresRepositorio.Editar(fornecedor);
        }

        public Fornecedor Inserir(Fornecedor fornecedor)
        {
            return fornecedoresRepositorio.Inserir(fornecedor);
        }
        
        public Fornecedor Instanciar(string? nomeFornecedor, string? razaoSocialFornecedor, string? cnpjFornecedor, string? ieFornecedor)
        {
            var fornecedor = new Fornecedor(nomeFornecedor, razaoSocialFornecedor, cnpjFornecedor, ieFornecedor);
            return fornecedor;
        }

        public Fornecedor Validar(int id)
        {
            Fornecedor fornecedorValidar = fornecedoresRepositorio.Recuperar(id);
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