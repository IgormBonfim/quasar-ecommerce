using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Estoques.Entidades;
using Quasar.Dominio.Estoques.Respositorios;
using Quasar.Dominio.Estoques.Servicos.Interfaces;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Produtos.Servicos.Interfaces;

namespace Quasar.Dominio.Estoques.Servicos
{
    public class EstoquesServico : IEstoquesServico
    {
        private readonly IEstoquesRepositorio estoquesRepositorio;
        private readonly IProdutosServico produtosServico;

        public EstoquesServico(IEstoquesRepositorio estoquesRepositorio, IProdutosServico produtosServico)
        {
            this.estoquesRepositorio = estoquesRepositorio;
            this.produtosServico = produtosServico;
        }

    public Estoque Editar(Estoque estoque)
    {
        Estoque estoqueEditar = Validar(estoque.IdEstoque);

        if (estoque.QntEstoque != estoqueEditar.QntEstoque)
                estoqueEditar.SetQntEstoque(estoque.QntEstoque);
        return estoquesRepositorio.Editar(estoqueEditar);
    }

    public Estoque Inserir(Estoque estoque)
    { 
        return estoquesRepositorio.Inserir(estoque);  
    }
    public Estoque Instanciar(int qntEstoque, int CodProduto)
    {
        Produto produto = produtosServico.Validar(CodProduto);
        Estoque estoque = new Estoque(qntEstoque, produto);
        return estoque;
    }
    public Estoque Validar(int idEstoque)
    {
        Estoque estoqueValidar = estoquesRepositorio.Recuperar(idEstoque);
        if(estoqueValidar == null)
            throw new Exception("Produto não encontrado.");
            return estoqueValidar;

    }
    }
}