using Carter;
using LinguaNews.Application.Dtos.Requests.News;
using LinguaNews.Application.Dtos.Responses.News;
using LinguaNews.Application.Features.NewsFeature.Commands;
using Mapster;
using MediatR;

namespace LinguaNews.Api.Endpoints.News;

public class CreateNewsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/news", async (CreateNewsRequestDto request, ISender sender) =>
            {
                var command = request.Adapt<CreateNewsCommand>();
                var result = await sender.Send(command);

                var response = result.Adapt<CreateNewsResponseDto>();
            })
            .WithName("CreateNews")
            .Produces<CreateNewsResponseDto>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create News")
            .WithDescription("Create News");
    }
}