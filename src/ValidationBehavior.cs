using MediatR;

namespace BuildingBlocks.Behaviors;

public class ValidationBehavior<TRequest,TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    public Task<TResponse> Handle(TRequest request , RequestHandlerDelegate<TResponse> next , CancellationToken cancellationToken)
}
