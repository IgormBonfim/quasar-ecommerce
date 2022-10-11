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
using Quasar.Aplicacao.FormasPagamento.Servicos;
using Quasar.Aplicacao.FormasPagamento.Servicos.Interfaces;
using Quasar.Aplicacao.Ufs.Servicos;
using Quasar.Aplicacao.Ufs.Servicos.Interfaces;
using Quasar.Dominio.Ufs.Repositorios;
using Quasar.Dominio.Ufs.Servicos;
using Quasar.Dominio.Ufs.Servicos.Interfaces;
using Quasar.Dominio.FormasPagamento.Repositorios;
using Quasar.Dominio.FormasPagamento.Servicos;
using Quasar.Dominio.FormasPagamento.Servicos.Interfaces;
using Quasar.Aplicacao.Fornecedores.Servicos;
using Quasar.Aplicacao.Fornecedores.Servicos.Interfaces;
using Quasar.Dominio.Fornecedores.Repositorios;
using Quasar.Dominio.Fornecedores.Servicos;
using Quasar.Dominio.Fornecedores.Servicos.Interfaces;
using Quasar.Infra.FormasPagamento;
using Quasar.Infra.Fornecedores;
using Quasar.Infra.Fornecedores.Mapeamentos;
using Quasar.Aplicacao.Vendas.Servicos;
using Quasar.Aplicacao.Vendas.Servicos.Interfaces;
using Quasar.Dominio.Vendas.Repositorios;
using Quasar.Dominio.Vendas.Servicos;
using Quasar.Dominio.Vendas.Servicos.Interfaces;
using Quasar.Infra.Produtos;
using Quasar.Infra.Vendas;
using Quasar.Infra.Ufs;
using ISession = NHibernate.ISession;
using Quasar.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.InjetarDependencias(builder.Configuration);

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
