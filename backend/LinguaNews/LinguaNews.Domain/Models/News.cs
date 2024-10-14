namespace LinguaNews.Domain.Models;

// string türü için varsayılan değeri (null) default!
public class News
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Beginner { get; set; } = default!;
    public string Intermediate { get; set; } = default!;
    public string Advanced { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string Image { get; set; } = default!;
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public DateTime? CreatedAt { get; set; }
}