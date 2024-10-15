namespace LinguaNews.Application.Dtos.Requests.Category;

public record UpdateCategoryRequestDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
}