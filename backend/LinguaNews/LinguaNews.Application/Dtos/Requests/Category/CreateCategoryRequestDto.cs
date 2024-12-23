namespace LinguaNews.Application.Dtos.Requests.Category;

public record CreateCategoryRequestDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
}