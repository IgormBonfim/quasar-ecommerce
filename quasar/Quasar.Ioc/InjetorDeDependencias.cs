using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using Quasar.Aplicacao.Categorias.Servicos;
using Quasar.Aplicacao.Categorias.Servicos.Interfaces;
using Quasar.Aplicacao.FormasPagamento.Servicos;
using Quasar.Aplicacao.FormasPagamento.Servicos.Interfaces;
using Quasar.Aplicacao.Fornecedores.Servicos;
using Quasar.Aplicacao.Fornecedores.Servicos.Interfaces;
using Quasar.Aplicacao.Produtos.Profiles;
using Quasar.Aplicacao.Produtos.Servicos;
using Quasar.Aplicacao.Produtos.Servicos.Interfaces;
using Quasar.Aplicacao.StatusVendas.Servicos;
using Quasar.Aplicacao.StatusVendas.Servicos.Interfaces;
using Quasar.Aplicacao.Ufs.Servicos;
using Quasar.Aplicacao.Ufs.Servicos.Interfaces;
using Quasar.Autenticacao.Data;
using Quasar.Dominio.Categorias.Repositorios;
using Quasar.Dominio.Categorias.Servicos;
using Quasar.Dominio.Categorias.Servicos.Interfaces;
using Quasar.Dominio.FormasPagamento.Repositorios;
using Quasar.Dominio.FormasPagamento.Servicos;
using Quasar.Dominio.FormasPagamento.Servicos.Interfaces;
using Quasar.Dominio.Fornecedores.Repositorios;
using Quasar.Dominio.Fornecedores.Servicos;
using Quasar.Dominio.Fornecedores.Servicos.Interfaces;
using Quasar.Dominio.Produtos.Repositorios;
using Quasar.Dominio.Produtos.Servicos;
using Quasar.Dominio.Produtos.Servicos.Interfaces;
using Quasar.Dominio.StatusVendas.Repositorios;
using Quasar.Dominio.StatusVendas.Servicos;
using Quasar.Dominio.StatusVendas.Servicos.Interfaces;
using Quasar.Dominio.Ufs.Repositorios;
using Quasar.Dominio.Ufs.Servicos;
using Quasar.Dominio.Ufs.Servicos.Interfaces;
using Quasar.Infra.Categorias;
using Quasar.Infra.FormasPagamento;
using Quasar.Infra.Fornecedores;
using Quasar.Infra.Produtos;
using Quasar.Infra.Produtos.Mapeamentos;
using Quasar.Infra.StatusVendas;
using Quasar.Infra.Ufs;

namespace Quasar.Ioc
{
    public static class InjetorDeDependencias
    {
        public static void InjetarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISessionFactory>(factory => 
            {
                string connectionString = configuration.GetConnectionString("MySql");
                return Fluently.Configure().Database(MySQLConfiguration.Standard
                                            .ConnectionString(connectionString)
                                            .FormatSql()
                                            .ShowSql())
                                            .Mappings(x => 
                                            {
                                                x.FluentMappings.AddFromAssemblyOf<ProdutoMap>();
                                            })
                                            .BuildSessionFactory();
            });

            services.AddSingleton<ISession>(factory => factory.GetService<ISessionFactory>().OpenSession());

            services.AddDbContext<IdentityDataContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("MySql"),
                    ServerVersion.Parse("8.0.28")
                )
            );

            services.AddSingleton<IProdutosRepositorio, ProdutosRepositorio>();
            services.AddSingleton<IProdutosServico, ProdutosServico>();
            services.AddSingleton<IProdutosAppServico, ProdutosAppServico>();

            services.AddSingleton<ICategoriasRepositorio, CategoriasRepositorio>();
            services.AddSingleton<ICategoriasServico, CategoriasServico>();
            services.AddSingleton<ICategoriasAppServico, CategoriasAppServico>();

            services.AddSingleton<IStatusVendasRepositorio, StatusVendasRepositorio>();
            services.AddSingleton<IStatusVendasServico, StatusVendasServico>();
            services.AddSingleton<IStatusVendasAppServico, StatusVendasAppServico>();

            services.AddSingleton<IUfsAppServico, UfsAppServico>();
            services.AddSingleton<IUfsRepositorio, UfsRepositorio>();
            services.AddSingleton<IUfsServico, UfsServico>();

            services.AddSingleton<IFormasPagamentoRepositorio, FormasPagamentoRepositorio>();
            services.AddSingleton<IFormasPagamentoServico, FormasPagamentoServico>();
            services.AddSingleton<IFormasPagamentoAppServico, FormasPagamentoAppServico>();

            services.AddSingleton<IFornecedoresRepositorio, FornecedoresRepositorio>();
            services.AddSingleton<IFornecedoresServico, FornecedoresServico>();
            services.AddSingleton<IFornecedoresAppServico, FornecedoresAppServico>();

            services.AddAutoMapper(typeof(ProdutosProfile));
        }
    }
}