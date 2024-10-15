using LinguaNews.Domain.Abstractions;

namespace LinguaNews.Domain.Models;

public class Category : Entity<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Image { get; set; } = default!;

    public static Category Create(string name,
         string description, string image)
    {
        // not the image :/
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(description);

        var category = new Category
        {
            Name = name,
            Description = description,
            Image = image
        };

        return category;
    }
    
    /* Gerek yok
     public void Update(string name,
        string description, string image)
    {
        Name = name;
        Image = image;
        Description = description;
        
        //AddDomainEvent(new Category(this));
    }
    */
}