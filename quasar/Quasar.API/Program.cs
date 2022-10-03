using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Quasar.Aplicacao.FormasPagamento.Servicos;
using Quasar.Aplicacao.FormasPagamento.Servicos.Interfaces;
using Quasar.Aplicacao.Produtos.Profiles;
using Quasar.Aplicacao.Produtos.Servicos;
using Quasar.Aplicacao.Produtos.Servicos.Interfaces;
using Quasar.Aplicacao.StatusVendas.Profiles;
using Quasar.Aplicacao.StatusVendas.Servicos;
using Quasar.Aplicacao.StatusVendas.Servicos.Interfaces;
using Quasar.Dominio.Produtos.Repositorios;
using Quasar.Dominio.Produtos.Servicos;
using Quasar.Dominio.Produtos.Servicos.Interfaces;
using Quasar.Dominio.StatusVendas.Repositorios;
using Quasar.Dominio.StatusVendas.Servicos;
using Quasar.Dominio.StatusVendas.Servicos.Interfaces;
using Quasar.Infra.Produtos;
using Quasar.Infra.Produtos.Mapeamentos;
using Quasar.Infra.StatusVendas;
using Quasar.Infra.StatusVendas.Mapeamentos;
using Quasar.Aplicacao.Ufs.Servicos;
using Quasar.Aplicacao.Ufs.Servicos.Interfaces;
using Quasar.Dominio.Ufs.Repositorios;
using Quasar.Dominio.Ufs.Servicos;
using Quasar.Dominio.Ufs.Servicos.Interfaces;
using Quasar.Dominio.FormasPagamento.Repositorios;
using Quasar.Dominio.FormasPagamento.Servicos;
using Quasar.Dominio.FormasPagamento.Servicos.Interfaces;
using Quasar.Infra.FormasPagamento;
using Quasar.Infra.FormasPagamento.Mapeamentos;
using Quasar.Infra.Ufs;
using Quasar.Infra.Ufs.Mapeamentos;
using ISession = NHibernate.ISession;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISessionFactory>(factory =>
{
    string connectionString = builder.Configuration.GetConnectionString("MySql");
    return Fluently.Configure().Database(MySQLConfiguration.Standard
                                            .ConnectionString(connectionString)
                                            .FormatSql()
                                            .ShowSql())
                                            .Mappings(x => 
                                            {
                                                x.FluentMappings.AddFromAssemblyOf<StatusVendaMap>();
                                                x.FluentMappings.AddFromAssemblyOf<UfsMap>();
                                                x.FluentMappings.AddFromAssemblyOf<ProdutoMap>();
                                                x.FluentMappings.AddFromAssemblyOf<FormaPagamentoMap>();
                                            })
                                            .BuildSessionFactory();
});

builder.Services.AddSingleton<ISession>(factory => factory.GetService<ISessionFactory>()?.OpenSession());

builder.Services.AddSingleton<IProdutosRepositorio, ProdutosRepositorio>();
builder.Services.AddSingleton<IProdutosServico, ProdutosServico>();
builder.Services.AddSingleton<IProdutosAppServico, ProdutosAppServico>();

builder.Services.AddSingleton<IStatusVendasRepositorio, StatusVendasRepositorio>();
builder.Services.AddSingleton<IStatusVendasServico, StatusVendasServico>();
builder.Services.AddSingleton<IStatusVendasAppServico, StatusVendasAppServico>();
builder.Services.AddSingleton<IUfsAppServico, UfsAppServico>();
builder.Services.AddSingleton<IUfsRepositorio, UfsRepositorio>();
builder.Services.AddSingleton<IUfsServico, UfsServico>();

builder.Services.AddSingleton<IFormasPagamentoRepositorio, FormasPagamentoRepositorio>();
builder.Services.AddSingleton<IFormasPagamentoServico, FormasPagamentoServico>();
builder.Services.AddSingleton<IFormasPagamentoAppServico, FormasPagamentoAppServico>();

builder.Services.AddAutoMapper(typeof(ProdutosProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
