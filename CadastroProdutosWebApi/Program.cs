using Microsoft.EntityFrameworkCore;
using BibliotecaData.Data;
using System;
using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(
    (DbContextOptionsBuilder optionsBuilder) =>
    {
        string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
    },
    ServiceLifetime.Scoped
);

builder.Services.AddScoped<IProdutoRepository, ProdutoRespository>();
builder.Services.AddScoped<CadastrarProdutoServices>();
builder.Services.AddScoped<AtualizarProdutoServices>();
builder.Services.AddScoped<ListarProdutoServices>();
builder.Services.AddScoped<ExcluirProdutoServices>();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
