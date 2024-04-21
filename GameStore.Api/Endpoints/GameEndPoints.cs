using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GameEndPoints  //extension class
{
    const string GetGameEndpointName = "GetGame";

    private static readonly List<GameDto> games = [
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

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {

        //group field which define commin things upon all endpoints
        var group = app.MapGroup("games");


        // Defining endpoints

        //GET /games
        group.MapGet("/", () => games);

        //GET /games/id

        group.MapGet("/{id}", (int id) =>
        {
            GameDto? game = games.Find(game => game.Id == id);
            return game is null ? Results.NotFound() : Results.Ok(game);
        }).WithName("GetGameEndpointName");

        // POST /games
        group.MapPost("/", (CreateGameDto newGame) =>
        {

            if(string.IsNullOrEmpty(newGame.Name)){
                return Results.BadRequest("Name is Required");
            }

            GameDto game = new GameDto(
             games.Count + 1,
             newGame.Name,
             newGame.Genre,
             newGame.Price,
             newGame.ReleaseDate
            );
            games.Add(game);
            return Results.CreatedAtRoute("GetGameEndpointName", new { id = game.Id, game });
        });

        // PUT /games/id
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {

            var index = games.FindIndex(game => game.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            games[index] = new GameDto(
              id,
              updatedGame.Name,
              updatedGame.Genre,
              updatedGame.Price,
              updatedGame.ReleaseDate
            );
            return Results.NoContent();

        });

        // DELETE /games/id
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);
            return Results.NoContent();
        });
        return group;
    }
}
