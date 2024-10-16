using Carter;
using LinguaNews.Application.Dtos.Requests.News;
using LinguaNews.Application.Dtos.Responses.News;
using LinguaNews.Application.Features.NewsFeature.Commands;
using Mapster;
using MediatR;

namespace LinguaNews.Api.Endpoints.News;

public class UpdateNewsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/news", async (UpdateNewsRequestDto request, ISender sender) =>
            {
                var command = request.Adapt<UpdateNewsCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<UpdateNewsResponseDto>();
                
                return Results.Ok(response);
            })
            .WithName("UpdateNews")
            .Produces<UpdateNewsResponseDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update News")
            .WithDescription("Update News");
    }
}