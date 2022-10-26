using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NHibernate;
using Quasar.Aplicacao.Produtos.Servicos.Interfaces;
using Quasar.DataTransfer.Genericos.Responses;
using Quasar.DataTransfer.Produtos.Requests;
using Quasar.DataTransfer.Produtos.Responses;
using Quasar.Dominio.Genericos.Entidades;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Produtos.Repositorios;
using Quasar.Dominio.Produtos.Servicos.Interfaces;

namespace Quasar.Aplicacao.Produtos.Servicos
{
    public class ProdutosAppServico : IProdutosAppServico
    {
        private readonly ISession session;
        private readonly IProdutosServico produtosServico;
        private readonly IEspecificacoesServico especificacoesServico;
        private readonly IMapper mapper;
        private readonly IProdutosRepositorio produtosRepositorio;

        public ProdutosAppServico(ISession session, IProdutosServico produtosServico, IEspecificacoesServico especificacoesServico, IProdutosRepositorio produtosRepositorio, IMapper mapper)
        {
            this.produtosRepositorio = produtosRepositorio;
            this.session = session;
            this.produtosServico = produtosServico;
            this.especificacoesServico = especificacoesServico;
            this.mapper = mapper;
        }

        public ProdutoInserirResponse Inserir(ProdutoInserirRequest inserirRequest)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                Especificacao especificacaoInserir = especificacoesServico.Instanciar(inserirRequest.Especificacao.Posicao, inserirRequest.Especificacao.Cor, inserirRequest.Especificacao.Ano, inserirRequest.Especificacao.Veiculo);
                Especificacao especificacaoSalva = especificacoesServico.Inserir(especificacaoInserir);

                Produto produtoInserir = produtosServico.Instanciar(inserirRequest.Descricao, inserirRequest.Nome, inserirRequest.Valor, inserirRequest.Imagem, especificacaoSalva.Codigo, inserirRequest.CodigoCategoria, inserirRequest.CodigoFornecedor);
                Produto produtoSalvo = produtosServico.Inserir(produtoInserir);

                if (transacao.IsActive)
                    transacao.Commit();

                return mapper.Map<ProdutoInserirResponse>(produtoSalvo);
            }
            catch
            {
                if (transacao.IsActive)
                    transacao.Rollback();
                throw;
            }
        }

        public ListaPaginadaResponse<ProdutoResponse> Listar(ProdutoBuscarRequest buscarRequest)
        {
            var query = produtosRepositorio.Query();

            if (buscarRequest.Codigo != null)
            {
                query = query.Where(x => x.Codigo == buscarRequest.Codigo);
            }
            if (buscarRequest.Nome != null)
            {
                query = query.Where(x => x.Nome.Contains(buscarRequest.Nome));
            }

            ListaPaginada<Produto> produtos = produtosRepositorio.Listar(query, buscarRequest.Quantidade, buscarRequest.Pagina);

            return mapper.Map<ListaPaginadaResponse<ProdutoResponse>>(produtos);
        }
    }
}