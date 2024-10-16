using BuildingBlocks.Pagination;

namespace LinguaNews.Application.Dtos.Responses.News;

public record GetAllNewsResponseDto(PaginatedResult<GetAllNewsResponse> News);

public record GetAllNewsResponse
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Image { get; set; }
    public int CategoryId { get; set; }
    public Domain.Models.Category Category { get; set; }
}