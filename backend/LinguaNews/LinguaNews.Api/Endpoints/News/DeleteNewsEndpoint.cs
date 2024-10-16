using Carter;
using LinguaNews.Application.Dtos.Requests.News;
using LinguaNews.Application.Dtos.Responses.News;
using LinguaNews.Application.Features.NewsFeature.Commands;
using Mapster;
using MediatR;

namespace LinguaNews.Api.Endpoints.News;

public class DeleteNewsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/news/{id}", async (Guid id, ISender sender)  =>
            {
                var deleteCommand = new DeleteNewsRequestDto { Id = id };
                var command = deleteCommand.Adapt<DeleteNewsCommand>();
                
                var result = await sender.Send(command);
                var response = result.Adapt<DeleteNewsResponseDto>();
            
                return Results.Ok(response);
            })
            .WithName("DeleteNews")
            .Produces<DeleteNewsResponseDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete News")
            .WithDescription("Delete News");
    }
}