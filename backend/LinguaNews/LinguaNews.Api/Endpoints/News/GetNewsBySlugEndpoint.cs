using Carter;
using LinguaNews.Application.Dtos.Responses.News;
using LinguaNews.Application.Features.NewsFeature.Queries;
using MediatR;

namespace LinguaNews.Api.Endpoints.News;

public class GetNewsBySlugEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/news/{slug}", async (string slug,ISender sender) =>
            {
                var query = new GetNewsBySlugQuery()
                {
                    Slug = slug
                };
                var result = await sender.Send(query);
                
                return Results.Ok(result);
            })  
            .WithName("GetNewsBySlug")  // nameler farkli olmazsa patliyor
            .Produces<GetNewsBySlugResponseDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get News By Slug")
            .WithDescription("Get News By Slug");
    }
}