using Carter;
using LinguaNews.Application.Dtos.Responses.Category;
using LinguaNews.Application.Features.CategoryFeature.Queries;
using MediatR;

namespace LinguaNews.Api.Endpoints.Category;

public class GetCategoryByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/category/{id}", async (int id,ISender sender) =>
            {
                var query = new GetCategoryByIdQuery
                {
                    Id = id
                };
                var result = await sender.Send(query);
                
                return Results.Ok(result);
            })  
            .WithName("GetCategoryById")  // nameler farkli olmazsa patliyor
            .Produces<List<GetAllCategoriesResponseDto>>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Category By Id")
            .WithDescription("Get Category By Id");
    }
}