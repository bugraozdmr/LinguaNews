namespace LinguaNews.Application.Dtos.Requests.News;

public class CreateNewsRequestDto
{
    public string Title { get; set; } = string.Empty;
    public string Intermediate { get; set; } = string.Empty;
    public string Beginner { get; set; } = string.Empty;
    public string Advanced { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int CategoryId { get; set; }
}