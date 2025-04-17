using StockManagement.Mediator;

namespace StockManagement.Api.Games.GetAllGames;

public record GetAllGamesQueryRequest : IRequest<IList<string>>
{
}
