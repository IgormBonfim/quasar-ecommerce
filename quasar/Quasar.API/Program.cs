using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Quasar.Aplicacao.Categorias.Servicos;
using Quasar.Aplicacao.Categorias.Servicos.Interfaces;
using Quasar.Aplicacao.Produtos.Profiles;
using Quasar.Aplicacao.Produtos.Servicos;
using Quasar.Aplicacao.Produtos.Servicos.Interfaces;
using Quasar.Dominio.Categorias.Repositorios;
using Quasar.Dominio.Categorias.Servicos;
using Quasar.Dominio.Categorias.Servicos.Interfaces;
using Quasar.Dominio.Produtos.Repositorios;
using Quasar.Dominio.Produtos.Servicos;
using Quasar.Dominio.Produtos.Servicos.Interfaces;
using Quasar.Infra.Categorias;
using Quasar.Infra.Categorias.Mapeamentos;
using Quasar.Infra.Produtos;
using Quasar.Infra.Produtos.Mapeamentos;
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
                                                x.FluentMappings.AddFromAssemblyOf<CategoriaMap>();
                                            })
                                            .BuildSessionFactory();
});

builder.Services.AddSingleton<ISession>(factory => factory.GetService<ISessionFactory>()?.OpenSession());

builder.Services.AddSingleton<IProdutosRepositorio, ProdutosRepositorio>();
builder.Services.AddSingleton<IProdutosServico, ProdutosServico>();
builder.Services.AddSingleton<IProdutosAppServico, ProdutosAppServico>();

builder.Services.AddSingleton<ICategoriasRepositorio, CategoriasRepositorio>();
builder.Services.AddSingleton<ICategoriasServico, CategoriasServico>();
builder.Services.AddSingleton<ICategoriasAppServico, CategoriasAppServico>();

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
