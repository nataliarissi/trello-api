using TrelloAPI.Repositorios.Implementacoes;
using TrelloAPI.Repositorios.Interfaces;
using TrelloAPI.Servicos.CardServicos;
using TrelloAPI.Servicos.ComentarioServicos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICardRepositorio, CardRepositorio>();
builder.Services.AddScoped<IComentarioRepositorio, ComentarioRepositorio>();
builder.Services.AddScoped<ICardServico, CardServico>();
builder.Services.AddScoped<IComentarioServico, ComentarioServico>();

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
