using GameStore.Api.Entities;

namespace GameStore.Api;

public class Game
{
    public int Id { get; set; }
    public required string Name { get; set; }    //required because we are sure that it should not be null
    public int GenreId { get; set; }   //connect to the id of genre
    //these two property GenreId and Genre combined will be used when we want to asociate between genre and game for one to one relationship
    public Genre? Genre { get; set; } //may or maynot be null so we use nullable(?)
    public decimal Price { get; set; }
    public DateOnly ReleasedDate{ get; set; }
}
