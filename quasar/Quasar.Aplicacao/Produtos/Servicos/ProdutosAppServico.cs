using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NHibernate;
using Quasar.Aplicacao.Produtos.Servicos.Interfaces;
using Quasar.DataTransfer.Produtos.Requests;
using Quasar.DataTransfer.Produtos.Responses;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Produtos.Servicos.Interfaces;

namespace Quasar.Aplicacao.Produtos.Servicos
{
    public class ProdutosAppServico : IProdutosAppServico
    {
        private readonly ISession session;
        private readonly IProdutosServico produtosServico;
        private readonly IMapper mapper;

        public ProdutosAppServico(ISession session, IProdutosServico produtosServico, IMapper mapper)
        {
            this.session = session;
            this.produtosServico = produtosServico;
            this.mapper = mapper;
        }

        public ProdutoInserirResponse Inserir(ProdutoInserirRequest inserirRequest)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                Produto produtoInserir = produtosServico.Instanciar(inserirRequest.DescricaoProduto, inserirRequest.NomeProduto, inserirRequest.ImgPrincipalProduto);
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
    }
}