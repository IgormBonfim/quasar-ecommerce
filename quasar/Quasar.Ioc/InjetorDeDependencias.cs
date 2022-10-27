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
using Quasar.Aplicacao.Vendas.Servicos;
using Quasar.Aplicacao.Vendas.Servicos.Interfaces;
using Quasar.Aplicacao.Ufs.Servicos;
using Quasar.Aplicacao.Ufs.Servicos.Interfaces;
using Quasar.Aplicacao.Usuarios.Servicos;
using Quasar.Aplicacao.Usuarios.Servicos.Interfaces;
using Quasar.Autenticacao.Servicos;
using Quasar.Autenticacao.Servicos.Interfaces;
using Quasar.Dominio.Categorias.Repositorios;
using Quasar.Dominio.Categorias.Servicos;
using Quasar.Dominio.Categorias.Servicos.Interfaces;
using Quasar.Dominio.Cidades.Repositorios;
using Quasar.Dominio.Cidades.Servicos;
using Quasar.Dominio.Cidades.Servicos.Interfaces;
using Quasar.Dominio.Estoques.Respositorios;
using Quasar.Dominio.Estoques.Servicos;
using Quasar.Dominio.Estoques.Servicos.Interfaces;
using Quasar.Dominio.FormasPagamento.Repositorios;
using Quasar.Dominio.FormasPagamento.Servicos;
using Quasar.Dominio.FormasPagamento.Servicos.Interfaces;
using Quasar.Dominio.Fornecedores.Repositorios;
using Quasar.Dominio.Fornecedores.Servicos;
using Quasar.Dominio.Fornecedores.Servicos.Interfaces;
using Quasar.Dominio.Produtos.Repositorios;
using Quasar.Dominio.Produtos.Servicos;
using Quasar.Dominio.Produtos.Servicos.Interfaces;
using Quasar.Dominio.Vendas.Repositorios;
using Quasar.Dominio.Vendas.Servicos;
using Quasar.Dominio.Vendas.Servicos.Interfaces;
using Quasar.Dominio.Ufs.Repositorios;
using Quasar.Dominio.Ufs.Servicos;
using Quasar.Dominio.Ufs.Servicos.Interfaces;
using Quasar.Infra.Categorias;
using Quasar.Infra.Cidades;
using Quasar.Infra.Estoques;
using Quasar.Infra.FormasPagamento;
using Quasar.Infra.Fornecedores;
using Quasar.Infra.Produtos;
using Quasar.Infra.Produtos.Mapeamentos;
using Quasar.Infra.Vendas;
using Quasar.Infra.Ufs;
using Quasar.Dominio.Enderecos.Repositorios;
using Quasar.Dominio.Enderecos.Servicos.Interfaces;
using Quasar.Aplicacao.Enderecos.Servicos.Interfaces;
using Quasar.Dominio.Enderecos.Servicos;
using Quasar.Infra.Enderecos;
using Quasar.Aplicacao.Enderecos.Servicos;
using Quasar.Ioc.Extensions;
using Quasar.Dominio.Usuarios.Servicos;
using Quasar.Dominio.Usuarios.Servicos.Interfaces;
using Quasar.Infra.Usuarios;
using Quasar.Dominio.Usuarios.Repositorios;
using Quasar.Aplicacao.Estoques.Servicos;
using Quasar.Aplicacao.Estoques.Servicos.Interfaces;
using Quasar.Aplicacao.Cidades.Servicos.Interfaces;
using Quasar.Aplicacao.Cidades.Servicos;
using Quasar.Aplicacao.Genericos.Servicos;
using Quasar.Aplicacao.Genericos.Servicos.Interfaces;
using Quasar.Aplicacao.Usuarios;

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

            services.AddAutenticacao(configuration);
            
            services.AddScoped<ISession>(factory => factory.GetService<ISessionFactory>().OpenSession());

            services.AddScoped<IAutenticacaoServico, AutenticacaoServico>();
            services.AddScoped<IJwtServico, JwtServico>();
            services.AddScoped<IUsuario, Usuario>();

            services.AddScoped<IUsuariosRepositorio, UsuariosRepositorio>();
            services.AddScoped<IUsuariosServico, UsuariosServico>();
            services.AddScoped<IUsuariosAppServico, UsuariosAppServico>();

            services.AddScoped<IFavoritosAppServico, FavoritosAppServico>();
            services.AddScoped<IFavoritosServico, FavoritosServico>();

            services.AddScoped<IClientesRepositorio, ClientesRepositorio>();
            services.AddScoped<IClientesServico, ClientesServico>();

            services.AddScoped<IProdutosRepositorio, ProdutosRepositorio>();
            services.AddScoped<IProdutosServico, ProdutosServico>();
            services.AddScoped<IProdutosAppServico, ProdutosAppServico>();

            services.AddScoped<IEspecificacoesRepositorio, EspecificacoesRepositorio>();
            services.AddScoped<IEspecificacoesServico, EspecificacoesServico>();

            services.AddScoped<ICategoriasRepositorio, CategoriasRepositorio>();
            services.AddScoped<ICategoriasServico, CategoriasServico>();
            services.AddScoped<ICategoriasAppServico, CategoriasAppServico>();

            services.AddScoped<IStatusVendasRepositorio, StatusVendasRepositorio>();
            services.AddScoped<IStatusVendasServico, StatusVendasServico>();
            services.AddScoped<IStatusVendasAppServico, StatusVendasAppServico>();

            services.AddScoped<IUfsAppServico, UfsAppServico>();
            services.AddScoped<IUfsRepositorio, UfsRepositorio>();
            services.AddScoped<IUfsServico, UfsServico>();

            services.AddScoped<IFormasPagamentoRepositorio, FormasPagamentoRepositorio>();
            services.AddScoped<IFormasPagamentoServico, FormasPagamentoServico>();
            services.AddScoped<IFormasPagamentoAppServico, FormasPagamentoAppServico>();

            services.AddScoped<IEstoquesAppServico, EstoquesAppServico>();
            services.AddScoped<IEstoquesRepositorio, EstoquesRepositorio>();
            services.AddScoped<IEstoquesServico, EstoquesServico>();
            
            services.AddScoped<IFornecedoresRepositorio, FornecedoresRepositorio>();
            services.AddScoped<IFornecedoresServico, FornecedoresServico>();
            services.AddScoped<IFornecedoresAppServico, FornecedoresAppServico>();

            services.AddScoped<ICidadesRepositorio, CidadesRepositorio>();
            services.AddScoped<ICidadesServico, CidadesServico>();
            services.AddScoped<ICidadesAppServico, CidadesAppServico>();

            services.AddScoped<IEnderecosRepositorio, EnderecosRepositorio>();
            services.AddScoped<IEnderecosServico, EnderecosServico>();
            services.AddScoped<IEnderecosAppServico, EnderecosAppServico>();
        
            services.AddAutoMapper(typeof(ProdutosProfile));
        }
    }
}