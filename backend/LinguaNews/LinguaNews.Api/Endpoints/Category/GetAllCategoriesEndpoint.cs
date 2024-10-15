using Carter;
using LinguaNews.Application.Dtos.Responses.Category;
using LinguaNews.Application.Features.CategoryFeature.Queries;
using MediatR;

namespace LinguaNews.Api.Endpoints.Category;

public class GetAllCategoriesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/category/all", async (ISender sender) =>
            {
                var query = new GetAllCategoriesQuery();
                var result = await sender.Send(query);
                
                return Results.Ok(result);
            })
        .WithName("GetAllCategories")
        .Produces<List<GetAllCategoriesResponseDto>>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get All Categories")
        .WithDescription("Get All Categories");
    }
}