using GameStore.Api.Data;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var conString = builder.Configuration.GetConnectionString("GameStore");
// var conString = "Data Source = GameStore.db";  --> without using appsettings.jsom
builder.Services.AddSqlite<GameStoreContext>(conString);

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
