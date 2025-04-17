using Microsoft.AspNetCore.Mvc;

using StockManagement.Mediator;

namespace StockManagement.Api.Games.GetAllGames;

[ApiController]
[Route("api/games")]
public class GetAllGamesController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllGames(CancellationToken cancellationToken)
    {
        var games = await sender.Send(new GetAllGamesQueryRequest(), cancellationToken);
        return Ok(games);
    }
}
