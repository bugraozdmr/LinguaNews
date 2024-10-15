using LinguaNews.Domain.Abstractions;
using LinguaNews.Domain.Events;

namespace LinguaNews.Domain.Models;

// string türü için varsayılan değeri (null) default!
public class News : Aggregate<Guid>
{
    public string Title { get; set; } = default!;
    public string Beginner { get; set; } = default!;
    public string Intermediate { get; set; } = default!;
    public string Advanced { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string Image { get; set; } = default!;
    
    public int CategoryId { get; set; }
    
    //! public Category Category { get; set; } configurationda kullanıldı zaten buna gerek yok
    //! (aksi taktirde categoryId1 diye ekstra sutun olusuyor !!)
    
    public static News Create(Guid? id, string title, string slug,
        string image, int categoryId,string beginner, 
        string intermediate,string advanced)
    {
        var news = new News
        {
            Id = id ?? Guid.NewGuid(),
            Title = title,
            Slug = slug,
            Image = image,
            CategoryId = categoryId,
            Beginner = beginner,
            Intermediate = intermediate,
            Advanced = advanced
        };

        news.AddDomainEvent(new NewsCreatedEvent(news));

        return news;
    }
    
    public void Update(string title, string slug,
        string image, int categoryId,string beginner, 
        string intermediate,string advanced)
    {
        Title = title;
        Slug = slug;
        Image = image;
        Beginner = beginner;
        Intermediate = intermediate;
        Advanced = advanced;
        CategoryId = categoryId;
        
        AddDomainEvent(new NewsUpdatedEvent(this));
    }
}