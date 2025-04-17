
using StockManagement.Mediator;

namespace StockManagement.Api.Games.GetAllGames;

public class GetAllGamesQueryRequestHandler : IRequestHandler<GetAllGamesQueryRequest, IList<string>>
{
    public Task<IList<string>> Handle(GetAllGamesQueryRequest request, CancellationToken cancellationToken)
    {
        // Simulate fetching data from a database or service
        var games = new List<string>
        {
            "Game 1",
            "Game 2",
            "Game 3"
        };

        return Task.FromResult<IList<string>>(games);
    }
}
