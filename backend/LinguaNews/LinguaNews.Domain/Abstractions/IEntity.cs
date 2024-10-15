namespace LinguaNews.Domain.Abstractions;

public interface IEntity<T> : IEntity
{
    public T Id { get; set; }
}

// common property
public interface IEntity
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? LastModified { get; set; }
}