
namespace StockManagement.Mediator;

public class Sender(IServiceProvider provider) : ISender
{
    public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        dynamic? handler = provider.GetService(handlerType);
        return handler == null
            ? throw new InvalidOperationException($"Handler for request type {request.GetType()} not found.")
            : (Task<TResponse>)handler.Handle((dynamic)request, cancellationToken);
    }
}
