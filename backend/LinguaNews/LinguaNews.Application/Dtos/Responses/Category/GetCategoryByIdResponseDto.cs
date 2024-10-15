namespace LinguaNews.Application.Dtos.Responses.Category;

public record GetCategoryByIdResponseDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? LastModified { get; set; }
}