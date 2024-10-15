using Carter;
using LinguaNews.Application.Dtos.Requests.Category;
using LinguaNews.Application.Dtos.Responses.Category;
using LinguaNews.Application.Features.CategoryFeature.Commands;
using Mapster;
using MediatR;

namespace LinguaNews.Api.Endpoints.Category;


public class CreateCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/category", async (CreateCategoryRequestDto request, ISender sender) =>
        {
            var command = request.Adapt<CreateCategoryCommand>();
            var result = await sender.Send(command);

            var response = result.Adapt<CreateCategoryResponseDto>();
        })
        .WithName("CreateCategory")
        .Produces<CreateCategoryResponseDto>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Category")
        .WithDescription("Create Category");
    }
}