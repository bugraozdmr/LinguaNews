using BuildingBlocks.Pagination;
using Carter;
using LinguaNews.Application.Dtos.Responses.News;
using LinguaNews.Application.Features.NewsFeature.Queries;
using Mapster;
using MediatR;

namespace LinguaNews.Api.Endpoints.News;

public class GetAllNewsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/news", async ([AsParameters] PaginationRequest request, ISender sender) =>
            {
                var result = await sender.Send(new GetAllNewsQuery(request));
                var response = result.Adapt<GetAllNewsResponseDto>();
                return Results.Ok(response);
            })
            .WithName("GetNews")
            .Produces<GetAllNewsResponseDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get news")
            .WithDescription("Get news");
    }
}