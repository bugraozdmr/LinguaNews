using MediatR;

namespace LinguaNews.Application.CQRS;

// doesnt return response
public interface ICommand : IRequest<Unit>
{
    
}
// returns response
public interface ICommand<out TResponse> : IRequest<TResponse>
{
    
}