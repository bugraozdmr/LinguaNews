using Carter;
using LinguaNews.Application.Dtos.Requests.Category;
using LinguaNews.Application.Dtos.Responses.Category;
using LinguaNews.Application.Features.CategoryFeature.Commands;
using Mapster;
using MediatR;

namespace LinguaNews.Api.Endpoints.Category;

public class DeleteCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/category/{id}", async (int id, ISender sender)  =>
            {
                var deleteCommand = new DeleteCategoryRequestDto { Id = id };
                var command = deleteCommand.Adapt<DeleteCategoryCommand>();
                
                var result = await sender.Send(command);
                var response = result.Adapt<DeleteCategoryResponseDto>();
            
                return Results.Ok(response);
            })
            .WithName("DeleteCategory")
            .Produces<DeleteCategoryResponseDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete Category")
            .WithDescription("Delete Category");
    }
}