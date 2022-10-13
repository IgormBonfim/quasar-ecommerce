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
        private readonly IEspecificacoesServico especificacoesServico;
        private readonly IMapper mapper;

        public ProdutosAppServico(ISession session, IProdutosServico produtosServico, IEspecificacoesServico especificacoesServico, IMapper mapper)
        {
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

                Produto produtoInserir = produtosServico.Instanciar(inserirRequest.Descricao, inserirRequest.Nome, inserirRequest.Imagem, especificacaoSalva.Codigo);
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