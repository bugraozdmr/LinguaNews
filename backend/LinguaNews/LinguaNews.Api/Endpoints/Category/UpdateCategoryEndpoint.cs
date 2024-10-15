using Carter;
using LinguaNews.Application.Dtos.Requests.Category;
using LinguaNews.Application.Dtos.Responses.Category;
using LinguaNews.Application.Features.CategoryFeature.Commands;
using Mapster;
using MediatR;

namespace LinguaNews.Api.Endpoints.Category;

public class UpdateCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/category", async (UpdateCategoryRequestDto request, ISender sender) =>
            {
                var command = request.Adapt<UpdateCategoryCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<UpdateCategoryResponseDto>();
                
                return Results.Ok(response);
            })
            .WithName("UpdateCategory")
            .Produces<UpdateCategoryResponseDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Category")
            .WithDescription("Update Category");
    }
}