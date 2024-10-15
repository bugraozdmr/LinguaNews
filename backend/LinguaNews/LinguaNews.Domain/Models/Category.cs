using LinguaNews.Domain.Abstractions;

namespace LinguaNews.Domain.Models;

public class Category : Entity<int>
{
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public string Image { get; private set; } = default!;

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
}