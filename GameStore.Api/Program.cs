using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new (
        1,
        "Street Fighter II",
         "Fighting",
         19.9M,
         new DateOnly(1992,7,15)
         ),
    new (
               2,
        "Final Fantansy XIV",
         "RolePlaying",
         59.99M,
         new DateOnly(1990,5,20)
         )
];

//GET /games
app.MapGet("games",()=> games);

//GET /games/1

app.MapGet("games/{id}",(int id)=> games.Find(game=> game.Id == id));


app.Run();
