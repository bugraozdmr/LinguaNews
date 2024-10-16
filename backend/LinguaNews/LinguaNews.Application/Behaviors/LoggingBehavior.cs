using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LinguaNews.Application.Behaviors;

public class LoggingBehavior<TRequest,TResponse>
    (ILogger<LoggingBehavior<TRequest,TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation("[START] Handling request = {@Request} - Response = {@Response} - RequestData = {@RequestData}"
            , typeof(TRequest).Name, typeof(TResponse).Name, request);

        var timer = new Stopwatch();
        timer.Start();
        
        var response = await next();
        
        timer.Stop();
        var timeTaken = timer.Elapsed;
        if (timeTaken.Seconds > 3)  // log if greater than 3 seconds
            logger.LogWarning("[PERFORMANCE] The request {@Request} is being processed in {TimeTaken}",
                typeof(TRequest).Name, timeTaken.Seconds);
        
        return response;
    }
}