# Stock Management

A .NET application for managing stock inventory using the mediator pattern for clean, loosely coupled architecture.

## Overview

Stock Management is a .NET application that demonstrates the implementation of the mediator pattern in a web API context. It provides a clean separation of concerns between API controllers and business logic through a custom mediator implementation.

## Architecture

The project consists of two main components:

### StockManagement.Mediator

A lightweight implementation of the mediator pattern that:
- Facilitates request/response communication between components
- Provides automatic handler discovery and registration
- Abstracts the service resolution and handler invocation

Key components:
- `IRequest<TResponse>`: Interface for request objects
- `IRequestHandler<TRequest, TResponse>`: Interface for request handlers
- `ISender`: Interface for sending requests to handlers
- `Sender`: Implementation of the ISender interface
- `Mediator`: Static class with extension methods for service configuration

### StockManagement.Api

A .NET API that uses the mediator pattern to handle requests. It includes an example implementation for a Games API:
- `GetAllGamesController`: API controller that receives HTTP requests
- `GetAllGamesQueryRequest`: Request object
- `GetAllGamesQueryRequestHandler`: Handler that processes the request

## Usage Example

### Defining a Request

```csharp
public record GetAllGamesQueryRequest : IRequest<IList<string>>
{
}
```

### Implementing a Handler

```csharp
public class GetAllGamesQueryRequestHandler : IRequestHandler<GetAllGamesQueryRequest, IList<string>>
{
    public Task<IList<string>> Handle(GetAllGamesQueryRequest request, CancellationToken cancellationToken)
    {
        var games = new List<string>
        {
            "Game 1",
            "Game 2",
            "Game 3"
        };

        return Task.FromResult<IList<string>>(games);
    }
}
```

### Creating a Controller

```csharp
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
```

### Registering Services

```csharp
builder.Services.AddMediator(typeof(Program).Assembly);
```

## Getting Started

1. Clone the repository
2. Navigate to the project directory
3. Run `dotnet restore`
4. Run `dotnet build`
5. Run `dotnet run --project StockManagement.Api`

## API Endpoints

- GET `/api/games` - Returns a list of all games

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
