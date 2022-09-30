using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
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
                                                x.FluentMappings.AddFromAssemblyOf<ProdutosMap>();
                                                x.FluentMappings.AddFromAssemblyOf<StatusVendaMap>();
                                            })
                                            .BuildSessionFactory();
});

builder.Services.AddSingleton<ISession>(factory => factory.GetService<ISessionFactory>()?.OpenSession());

builder.Services.AddSingleton<IProdutosRepositorio, ProdutosRepositorio>();
builder.Services.AddSingleton<IProdutosServico, ProdutosServico>();
builder.Services.AddSingleton<IProdutosAppServico, ProdutosAppServico>();

builder.Services.AddSingleton<IStatusVendasRepositorio, StatusVendasRepositorio>();
builder.Services.AddSingleton<IStatusVendasServico, StatusVendasServico>();
builder.Services.AddSingleton< IStatusVendasAppServico, StatusVendasAppServico>();

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
