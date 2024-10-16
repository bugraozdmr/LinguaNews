using MediatR;

namespace LinguaNews.Application.CQRS;

public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull
{
    
}