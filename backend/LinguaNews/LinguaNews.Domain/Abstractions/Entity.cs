namespace LinguaNews.Domain.Abstractions;

public abstract class Entity<T> : IEntity<T>
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? LastModified { get; set; }
    public T Id { get; set; }
}